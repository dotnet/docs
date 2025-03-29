---
title: Cluster management in Orleans
description: Learn about cluster management in .NET Orleans.
ms.date: 11/23/2024
---

# Cluster management in Orleans

Orleans provides cluster management via a built-in membership protocol, which we sometimes refer to as **Cluster membership**. The goal of this protocol is for all silos (Orleans servers) to agree on the set of currently alive silos, detect failed silos, and allow new silos to join the cluster.

The protocol relies on an external service to provide an abstraction of <xref:Orleans.IMembershipTable>. <xref:Orleans.IMembershipTable> is a flat durable table that we use for two purposes. First, it is used as a rendezvous point for silos to find each other and Orleans clients to find silos. Second, it is used to store the current membership view  (list of alive silos) and helps coordinate the agreement on the membership view.

We currently have 6 implementations of the <xref:Orleans.IMembershipTable>: based on [Azure Table Storage](/azure/storage/storage-dotnet-how-to-use-tables), [Azure Cosmos DB](https://azure.microsoft.com/services/cosmos-db), ADO.NET (PostgreSQL, MySQL/MariaDB, SQL Server, Oracle), [Apache ZooKeeper](https://ZooKeeper.apache.org/), [Consul IO](https://www.consul.io), [AWS DynamoDB](https://aws.amazon.com/dynamodb/), [MongoDB](https://www.mongodb.com/), [Redis](https://redis.io), [Apache Cassandra](https://cassandra.apache.org), and an in-memory implementation for development.

In addition to the <xref:Orleans.IMembershipTable> each silo participates in a fully distributed peer-to-peer membership protocol that detects failed silos and reaches an agreement on a set of alive silos. We describing the internal implementation of Orleans's membership protocol below.

### The membership protocol

1. Upon startup every silo adds an entry for itself into a well-known, shared table, using an implementation of <xref:Orleans.IMembershipTable>. Orleans uses a combination of silo identity (`ip:port:epoch`) and service deployment ID (cluster ID) as unique keys in the table. Epoch is just time in ticks when this silo started, and as such `ip:port:epoch` is guaranteed to be unique in a given Orleans deployment.

1. Silos monitor each other directly, via application probes ("are you alive" `heartbeats`). probes are sent as direct messages from silo to silo, over the same TCP sockets that silos communicate. That way, probes fully correlate with actual networking problems and server health. Every silo probes a configurable set of other silos. A silo picks whom to probe by calculating consistent hashes on other silos' identity, forming a virtual ring of all identities, and picking X successor silos on the ring (this is a well-known distributed technique called [consistent hashing](https://en.wikipedia.org/wiki/Consistent_hashing) and is widely used in many distributed hash tables, like [Chord DHT](https://en.wikipedia.org/wiki/Chord_(peer-to-peer))).

1. If a silo S does not get Y probe replies from a monitored server P, it suspects it by writing its timestamped suspicion into P's row in the <xref:Orleans.IMembershipTable>.

1. If P has more than Z suspicions within K seconds, then S writes that P is dead into P's row and sends a snapshot of the current membership table to all other silos. Silos refresh the table periodically, so the snapshot is an optimization to reduce the time taken for all silos to learn about the new membership view.

1. In more details:

    1. Suspicion is written to the <xref:Orleans.IMembershipTable>, in a special column in the row corresponding to P. When S suspects P it writes: "at time TTT S suspected P".

    1. One suspicion is not enough to declare P as dead. You need Z suspicions from different silos in a configurable time window T, typically 3 minutes, to declare P as dead. The suspicion is written using optimistic concurrency control provided by the <xref:Orleans.IMembershipTable>.

    1. The suspecting silo S reads P's row.

    1. If `S` is the last suspecter (there have already been Z-1 suspecters within a period of T, as written in the suspicion column), S decides to declare P as Dead. In this case, S adds itself to the list of suspecters and also writes in P's Status column that P is Dead.

    1. Otherwise, if S is not the last suspecter, S just adds itself to the suspecter's column.

    1. In either case the write-back uses the version number or ETag that was read, so the updates to this row are serialized. In case the write has failed due to version/ETag mismatch, S retries (read again, and try to write, unless P was already marked dead).

    1. At a high level this sequence of "read, local modify, write back" is a transaction. However, we are not necessarily using storage transactions to do that. "Transaction" code executes locally on a server and we use optimistic concurrency provided by the <xref:Orleans.IMembershipTable> to ensure isolation and atomicity.

1. Every silo periodically reads the entire membership table for its deployment. That way silos learn about new silos joining and about other silos being declared dead.

1. **Snapshot broadcast**: To reduce the frequency of periodical table reads, every time a silo writes to the table (suspicion, new join, etc.) it sends a snapshot of the current table state to all other silos. Since the membership table is consistent and monotonically versioned, each update produces a uniquely versioned snapshot that can be safely shared. This enables immediate propagation of membership changes without waiting for the periodic read cycle. The periodic read is still maintained as a fallback mechanism in case snapshot distribution fails.

1. **Ordered membership views**: The membership protocol ensures that all membership configurations are globally totally ordered. This ordering provides two key benefits:

    1. **Guaranteed connectivity**: When a new silo joins the cluster, it must validate two-way connectivity to every other active silo. If any existing silo does not respond (potentially indicating a network connectivity problem), the new silo is not allowed to join. This ensures full connectivity between all silos in the cluster at startup time. See the note about IAmAlive below for an exception in the case of disaster recovery.

    2. **Consistent directory updates**: Higher level protocols, such as the distributed grain directory, rely on all silos having a consistent, monotonic view of membership. This enables smarter resolution of duplicate grain activations. For more details, see the [grain directory](grain-directory.md) documentation.

    **Implementation details**:

    1. The <xref:Orleans.IMembershipTable> requires atomic updates to guarantee a global total order of changes:
       - Implementations must update both the table entries (list of silos) and version number atomically
       - This can be achieved using database transactions (as in SQL Server) or atomic compare-and-swap operations using ETags (as in Azure Table Storage)
       - The specific mechanism depends on the capabilities of the underlying storage system

    2. A special membership-version row in the table tracks changes:
       - Every write to the table (suspicions, death declarations, joins) increments this version number
       - All writes are serialized through this row using atomic updates
       - The monotonically increasing version ensures a total ordering of all membership changes

    3. When silo S updates the status of silo P:
       - S first reads the latest table state
       - In a single atomic operation, it updates both P's row and increments the version number
       - If the atomic update fails (e.g., due to concurrent modifications), the operation is retried with exponential backoff

    **Scalability considerations**:

    Serializing all writes through the version row can impact scalability due to increased contention. The protocol has been proven in production with up to 200 silos, but may face challenges beyond a thousand silos. For very large deployments, other parts of Orleans (messaging, grain directory, hosting) remain scalable even if membership updates become a bottleneck.

1. **Default configuration**: The default configuration has been hand-tuned during production usage in Azure. By default: every silo is monitored by three other silos, two suspicions are enough to declare a silo dead, suspicions only from the last three minutes (otherwise they are outdated). probes are sent every ten seconds and you'd need to miss three probes to suspect a silo.

1. **Self-monitoring**: The fault detector incorporates ideas from Hashicorp's _Lifeguard_ research ([paper](https://arxiv.org/abs/1707.00788), [talk](https://www.youtube.com/watch?v=u-a7rVJ6jZY), [blog](https://www.hashicorp.com/blog/making-gossip-more-robust-with-lifeguard)) to improve cluster stability during catastrophic events where a large portion of the cluster experiences partial failure. The `LocalSiloHealthMonitor` component scores each silo's health using multiple heuristics:

    * Active status in membership table
    * No suspicions from other silos
    * Recent successful probe responses
    * Recent probe requests received
    * Thread pool responsiveness (work items executing within 1 second)
    * Timer accuracy (firing within 3 seconds of schedule)

    A silo's health score affects its probe timeouts: unhealthy silos (scoring 1-8) have increased timeouts compared to healthy silos (score 0). This has two benefits:
    * Gives more time for probes to succeed when the network or system is under stress
    * Makes it more likely that unhealthy silos will be voted dead before they can incorrectly vote out healthy silos

    This is particularly valuable during scenarios like thread pool starvation, where slow nodes might otherwise incorrectly suspect healthy nodes simply because they cannot process responses quickly enough.

1. **Indirect probing**: Another [Lifeguard](https://arxiv.org/abs/1707.00788)-inspired feature that improves failure detection accuracy by reducing the chance that an unhealthy or partitioned silo will incorrectly declare a healthy silo dead. When a monitoring silo has two probe attempts remaining for a target silo before casting a vote to declare it dead, it employs indirect probing:

    * The monitoring silo randomly selects another silo as an intermediary and asks it to probe the target
    * The intermediary attempts to contact the target silo
    * If the target fails to respond within the timeout period, the intermediary sends a negative acknowledgement
    * If the monitoring silo received a negative acknowledgement from the intermediary and the intermediary declares itself healthy (through self-monitoring, described above), the monitoring silo casts a vote to declare the target dead
    * With the default configuration of two required votes, a negative acknowledgement from an indirect probe counts as both votes, allowing faster declaration of dead silos when the failure is confirmed by multiple perspectives

1. **Enforcing perfect failure detection**: Once a silo is declared dead in the table, it is considered dead by everyone, even if it is not dead (just partitioned temporarily or heartbeat messages got lost). Everyone stops communicating with it and once it learns that it is dead (by reading its new status from the table) it commits suicide and shuts down its process. As a result, there must be an infrastructure in place to restart the silo as a new process (a new epoch number is generated upon start). When it's hosted in Azure, that happens automatically. When it isn't, another infrastructure is required, such as a Windows Service configured to auto restart on failure or a Kubernetes deployment.

1. **What happens if the table is not accessible for some time**:

    When the storage service is down, unavailable, or there are communication problems with it, the Orleans protocol does NOT declare silos as dead by mistake. Operational silos will keep working without any problems. However, Orleans won't be able to declare a silo dead (if it detects some silo is dead via missed probes, it won't be able to write this fact to the table) and also won't be able to allow new silos to join. So completeness will suffer, but accuracy will not &mdash; partitioning from the table will never cause Orleans to declare silo as dead by mistake. Also, in case of a partial network partition (if some silos can access the table and some not), it could happen that Orleans will declare a dead silo as dead, but it will take some time until all other silos learn about it. So detection could be delayed, but Orleans will never wrongly kill a silo due to table unavailability.

1. **IAmAlive writes for diagnostics and disaster recovery**:

    In addition to heartbeats that are sent between the silos, each silo periodically updates an "I Am Alive" timestamp in its row in the table. This serves two purposes:
    1. For diagnostics, it provides system administrators with a simple way to check cluster liveness and determine when a silo was last active. The timestamp is typically updated every 5 minutes.
    2. For disaster recovery, if a silo has not updated its timestamp for several periods (configured via `NumMissedTableIAmAliveLimit`), new silos will ignore it during startup connectivity checks, allowing the cluster to recover from scenarios where silos crashed without proper cleanup.

### Membership table

As already mentioned, <xref:Orleans.IMembershipTable> is used as a rendezvous point for silos to find each other and Orleans clients to find silos and also helps coordinate the agreement on the membership view. The main Orleans repository contains implementations for many systems, such as Azure Table Storage, Azure Cosmos DB, PostgreSQL, MySQL/MariaDB, SQL server, Apache ZooKeeper, Consul IO, Apache Cassandra, MongoDB, Redis, AWS DynamoDB, and an in-memory implementation for development.

1. [Azure Table Storage](/azure/storage/storage-dotnet-how-to-use-tables) - in this implementation we use Azure deployment ID as partition key and the silo identity (`ip:port:epoch`) as row key. Together they guarantee a unique key per silo. For concurrency control, we use optimistic concurrency control based on [Azure Table ETags](/rest/api/storageservices/Update-Entity2). Every time we read from the table we store the ETag for every read row and use that ETag when we try to write back. ETags are automatically assigned and checked by the Azure Table service on every write. For multi-row transactions, we utilize the support for [batch transactions provided by Azure table](/rest/api/storageservices/Performing-Entity-Group-Transactions), which guarantees serializable transactions over rows with the same partition key.

1. SQL Server - in this implementation, the configured deployment ID is used to distinguish between deployments and which silos belong to which deployments. The silo identity is defined as a combination of `deploymentID, ip, port, epoch` in appropriate tables and columns. The relational backend uses optimistic concurrency control and transactions, similar to the procedure of using ETags on Azure Table implementation. The relational implementation expects the database engine to generate the ETag used. In the case of SQL Server, on SQL Server 2000 the generated ETag is one acquired from a call to `NEWID()`. On SQL Server 2005 and later [ROWVERSION](/sql/t-sql/data-types/rowversion-transact-sql) is used. Orleans reads and writes relational ETags as opaque `VARBINARY(16)` tags and stores them in memory as [base64]( https://en.wikipedia.org/wiki/Base64) encoded strings. Orleans supports multi-row inserts using `UNION ALL` (for Oracle including DUAL), which is currently used to insert statistics data. The exact implementation and rationale for SQL Server can be seen at [CreateOrleansTables_SqlServer.sql](https://github.com/dotnet/orleans/blob/ba30bbb2155168fc4b9f190727220583b9a7ae4c/src/OrleansSQLUtils/CreateOrleansTables_SqlServer.sql).

1. [Apache ZooKeeper](https://zookeeper.apache.org/) - in this implementation we use the configured deployment ID as a root node and the silo identity (`ip:port@epoch`) as its child node. Together they guarantee a unique path per silo. For concurrency control, we use optimistic concurrency control based on the [node version](https://zookeeper.apache.org/doc/r3.4.6/zookeeperOver.html#Nodes+and+ephemeral+nodes). Every time we read from the deployment root node we store the version for every read child silo node and use that version when we try to write back. Each time a node's data changes, the version number increases atomically by the ZooKeeper service. For multi-row transactions, we utilize the [multi method](https://zookeeper.apache.org/doc/r3.4.6/api/org/apache/zookeeper/ZooKeeper.html#multi(java.lang.Iterable)), which guarantees serializable transactions over silo nodes with the same parent deployment ID node.

1. [Consul IO](https://www.consul.io) - we used [Consul's Key/Value store](https://www.consul.io/intro/getting-started/kv.html) to implement the membership table. Refer to [Consul-Deployment](../deployment/consul-deployment.md) for more details.

1. [AWS DynamoDB](https://aws.amazon.com/dynamodb/) - In this implementation, we use the cluster Deployment ID as the Partition Key and Silo Identity (`ip-port-generation`) as the RangeKey making the record unity. The optimistic concurrency is made by the `ETag` attribute by making conditional writes on DynamoDB. The implementation logic is quite similar to Azure Table Storage.

1. [Apacha Cassandra](https://cassandra.apache.org/_/index.html) - In this implementation we use the composite of Service Id and Cluster Id as partition key and the silo identity (`ip:port:epoch`) as row key. Together they guarantee a unique row per silo. For concurrency control, we use optimistic concurrency control based on a static column version using a Lightweight Transaction. This version column is shared for all rows in the partition/cluster so provides the consistent incrementing version number for each cluster's membership table. There are no multi-row transactions in this implementation.

1. In-memory emulation for development setup. We use a special system grain for that implementation. This grain lives on a designated primary silo, which is only used for a **development setup**. In any real production usage primary silo **is not required**.

### Design rationale

A natural question that might be asked is why not rely completely on [Apache ZooKeeper](https://ZooKeeper.apache.org/) or [etcd](https://etcd.io/) for the cluster membership implementation, potentially by using ZooKeeper's out-of-the-box support for group membership with ephemeral nodes? Why did we bother implementing our membership protocol? There were primarily three reasons:

1. **Deployment/Hosting in the cloud**:

    Zookeeper is not a hosted service. It means that in the Cloud environment Orleans customers would have to deploy/run/manage their instance of a ZK cluster. This is just yet another unnecessary burden, that we did not want to force on our customers. By using Azure Table we rely on a hosted, managed service which makes our customer's lives much simpler. _Basically, in the Cloud, use Cloud as a Platform, not as an Infrastructure._ On the other hand, when running on-premises and managing your servers, relying on ZK as an implementation of the <xref:Orleans.IMembershipTable> is a viable option.

1. **Direct failure detection**:

    When using ZK's group membership with ephemeral nodes the failure detection is performed between the Orleans servers (ZK clients) and ZK servers. This may not necessarily correlate with the actual network problems between Orleans servers. _Our desire was that the failure detection would accurately reflect the intra-cluster state of the communication._ Specifically, in our design, if an Orleans silo cannot communicate with the <xref:Orleans.IMembershipTable> it is not considered dead and can keep working. As opposed to that, have we used ZK group membership with ephemeral nodes a disconnection from a ZK server may cause an Orleans silo (ZK client) to be declared dead, while it may be alive and fully functional.

1. **Portability and flexibility**:

    As part of Orleans's philosophy, we do not want to force a strong dependence on any particular technology, but rather have a flexible design where different components can be easily switched with different implementations. This is exactly the purpose that <xref:Orleans.IMembershipTable> abstraction serves.

### Properties of the membership protocol

1. **Can handle any number of failures**:

    Our algorithm can handle any number of failures (that is, f<=n), including full cluster restart. This is in contrast with "traditional" [Paxos](https://en.wikipedia.org/wiki/Paxos_(computer_science)) based solutions, which require a quorum, which is usually a majority. We have seen in production situations when more than half of the silos were down. Our system stayed functional, while Paxos-based membership would not be able to make progress.

1. **Traffic to the table is very light**:

    The actual probes go directly between servers and not to the table. This would generate a lot of traffic plus would be less accurate from the failure detection perspective - if a silo could not reach the table, it would miss writing its I am alive heartbeat, and others would kill him.

1. **Tunable accuracy versus completeness**:

    While you cannot achieve both perfect and accurate failure detection, one usually wants an ability to tradeoff accuracy (don't want to declare a silo that is alive as dead) with completeness (want to declare dead a silo that is indeed dead as soon as possible). The configurable votes to declare dead and missed probes allow trading those two. For more information, see [Yale University: Computer Science Failure Detectors](https://www.cs.yale.edu/homes/aspnes/pinewiki/FailureDetectors.html).

1. **Scale**:

    The protocol can handle thousands and probably even tens of thousands of servers. This is in contrast with traditional Paxos-based solutions, such as group communication protocols, which are known not to scale beyond tens.

1. **Diagnostics**:

    The table is also very convenient for diagnostics and troubleshooting. The system administrators can instantaneously find in the table the current list of alive silos, as well as see the history of all killed silos and suspicions. This is especially useful when diagnosing problems.

1. **Why do we need reliable persistent storage for implementation of the <xref:Orleans.IMembershipTable>**:

    We use persistent storage for the <xref:Orleans.IMembershipTable> for two purposes. First, it is used as a rendezvous point for silos to find each other and Orleans clients to find silos. Second, we use reliable storage to help us coordinate the agreement on the membership view. While we perform failure detection directly in a peer-to-peer fashion between the silos, we store the membership view in reliable storage and use the concurrency control mechanism provided by this storage to reach an agreement of who is alive and who is dead. That way, in a sense, our protocol outsources the hard problem of distributed consensus to the cloud. In that we fully utilize the power of the underlying cloud platform, using it truly as Platform as a Service (PaaS).

1. **Direct IAmAlive writes into the table for diagnostics only**:

    In addition to heartbeats that are sent between the silos, each silo also periodically updates an "I Am Alive" column in his row in the table. This "I Am Alive" column is only used **for manual troubleshooting and diagnostics** and is not used by the membership protocol itself. It is usually written at a much lower frequency (once every 5 minutes) and serves as a very useful tool for system administrators to check the liveness of the cluster or easily find out when the silo was last alive.

### Acknowledgements

We would like to acknowledge the contribution of Alex Kogan to the design and implementation of the first version of this protocol. This work was done as part of a summer internship in Microsoft Research in the Summer of 2011.
The implementation of ZooKeeper based <xref:Orleans.IMembershipTable> was done by [Shay Hazor](https://github.com/shayhatsor), the implementation of SQL <xref:Orleans.IMembershipTable> was done by [Veikko Eeva](https://github.com/veikkoeeva), the implementation of AWS DynamoDB <xref:Orleans.IMembershipTable> was done by [Gutemberg Ribeiro](https://github.com/galvesribeiro/) and the implementation of Consul based <xref:Orleans.IMembershipTable> was done by [Paul North](https://github.com/PaulNorth), and finally the implementation of the Apache Cassandra <xref:Orleans.IMembershipTable> was adapted from `OrleansCassandraUtils` by [Arshia001](https://github.com/Arshia001).
