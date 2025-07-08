---
title: Cluster management in Orleans
description: Learn about cluster management in .NET Orleans.
ms.date: 05/23/2025
ms.topic: conceptual
---

# Cluster management in Orleans

Orleans provides cluster management via a built-in membership protocol, sometimes referred to as **Cluster membership**. The goal of this protocol is for all silos (Orleans servers) to agree on the set of currently alive silos, detect failed silos, and allow new silos to join the cluster.

The protocol relies on an external service to provide an abstraction of <xref:Orleans.IMembershipTable>. `IMembershipTable` is a flat, durable table used for two purposes. First, it serves as a rendezvous point for silos to find each other and for Orleans clients to find silos. Second, it stores the current membership view (list of alive silos) and helps coordinate agreement on this view.

Currently, there are several implementations of `IMembershipTable`: based on [Azure Table Storage](/azure/storage/storage-dotnet-how-to-use-tables), [Azure Cosmos DB](https://azure.microsoft.com/services/cosmos-db), ADO.NET (PostgreSQL, MySQL/MariaDB, SQL Server, Oracle), [Apache ZooKeeper](https://ZooKeeper.apache.org/), [Consul IO](https://www.consul.io), [AWS DynamoDB](https://aws.amazon.com/dynamodb/), [MongoDB](https://www.mongodb.com/), [Redis](https://redis.io), [Apache Cassandra](https://cassandra.apache.org), and an in-memory implementation for development.

In addition to `IMembershipTable`, each silo participates in a fully distributed peer-to-peer membership protocol that detects failed silos and reaches an agreement on the set of alive silos. The internal implementation of Orleans's membership protocol is described below.

### The membership protocol

1. Upon startup, every silo adds an entry for itself into a well-known, shared table using an implementation of <xref:Orleans.IMembershipTable>. Orleans uses a combination of silo identity (`ip:port:epoch`) and service deployment ID (cluster ID) as unique keys in the table. Epoch is simply the time in ticks when this silo started, ensuring `ip:port:epoch` is unique within a given Orleans deployment.

1. Silos monitor each other directly via application probes ("are you alive" `heartbeats`). Probes are sent as direct messages from silo to silo over the same TCP sockets used for regular communication. This way, probes fully correlate with actual networking problems and server health. Every silo probes a configurable set of other silos. A silo picks whom to probe by calculating consistent hashes on other silos' identities, forming a virtual ring of all identities, and picking X successor silos on the ring. (This is a well-known distributed technique called [consistent hashing](https://en.wikipedia.org/wiki/Consistent_hashing) and is widely used in many distributed hash tables, like [Chord DHT](https://en.wikipedia.org/wiki/Chord_(peer-to-peer))).

1. If a silo S doesn't receive Y probe replies from a monitored server P, it suspects P by writing its timestamped suspicion into P's row in the `IMembershipTable`.

1. If P has more than Z suspicions within K seconds, S writes that P is dead into P's row and broadcasts a snapshot of the current membership table to all other silos. Silos refresh the table periodically, so the snapshot is an optimization to reduce the time it takes for all silos to learn about the new membership view.

1. In more detail:

   1. Suspicion is written to the `IMembershipTable`, in a special column in the row corresponding to P. When S suspects P, it writes: "at time TTT S suspected P".

   1. One suspicion isn't enough to declare P dead. You need Z suspicions from different silos within a configurable time window T (typically 3 minutes) to declare P dead. The suspicion is written using optimistic concurrency control provided by the `IMembershipTable`.

   1. The suspecting silo S reads P's row.

   1. If `S` is the last suspecter (there have already been Z-1 suspecters within period T, as recorded in the suspicion column), S decides to declare P dead. In this case, S adds itself to the list of suspecters and also writes in P's Status column that P is Dead.

   1. Otherwise, if S isn't the last suspecter, S just adds itself to the suspecter's column.

   1. In either case, the write-back uses the version number or ETag read previously, serializing updates to this row. If the write fails due to a version/ETag mismatch, S retries (reads again and tries to write, unless P was already marked dead).

   1. At a high level, this sequence of "read, local modify, write back" is a transaction. However, storage transactions aren't necessarily used. The "transaction" code executes locally on a server, and optimistic concurrency provided by the `IMembershipTable` ensures isolation and atomicity.

1. Every silo periodically reads the entire membership table for its deployment. This way, silos learn about new silos joining and about other silos being declared dead.

1. **Snapshot broadcast**: To reduce the frequency of periodic table reads, every time a silo writes to the table (suspicion, new join, etc.), it sends a snapshot of the current table state to all other silos. Since the membership table is consistent and monotonically versioned, each update produces a uniquely versioned snapshot that can be safely shared. This enables immediate propagation of membership changes without waiting for the periodic read cycle. The periodic read is still maintained as a fallback mechanism in case snapshot distribution fails.

1. **Ordered membership views**: The membership protocol ensures all membership configurations are globally totally ordered. This ordering provides two key benefits:

   1. **Guaranteed connectivity**: When a new silo joins the cluster, it must validate two-way connectivity to every other active silo. If any existing silo doesn't respond (potentially indicating a network connectivity problem), the new silo isn't allowed to join. This ensures full connectivity between all silos in the cluster at startup time. See the note about `IAmAlive` below for an exception in disaster recovery scenarios.

   1. **Consistent directory updates**: Higher-level protocols, such as the distributed grain directory, rely on all silos having a consistent, monotonic view of membership. This enables smarter resolution of duplicate grain activations. For more details, see the [Grain directory](grain-directory.md) documentation.

   **Implementation details**:

   1. The `IMembershipTable` requires atomic updates to guarantee a global total order of changes:

      - Implementations must update both the table entries (list of silos) and the version number atomically.
      - Achieve this using database transactions (as in SQL Server) or atomic compare-and-swap operations using ETags (as in Azure Table Storage).
      - The specific mechanism depends on the capabilities of the underlying storage system.

   1. A special membership-version row in the table tracks changes:

      - Every write to the table (suspicions, death declarations, joins) increments this version number.
      - All writes are serialized through this row using atomic updates.
      - The monotonically increasing version ensures a total ordering of all membership changes.

   1. When silo S updates the status of silo P:

      - S first reads the latest table state.
      - In a single atomic operation, it updates both P's row and increments the version number.
      - If the atomic update fails (for example, due to concurrent modifications), the operation retries with exponential backoff.

    **Scalability considerations**:

    Serializing all writes through the version row can impact scalability due to increased contention. The protocol has proven effective in production with up to 200 silos but might face challenges beyond a thousand silos. For very large deployments, other parts of Orleans (messaging, grain directory, hosting) remain scalable even if membership updates become a bottleneck.

1. **Default configuration**: The default configuration has been hand-tuned during production usage in Azure. By default: every silo is monitored by three other silos, two suspicions are enough to declare a silo dead, and suspicions are only considered from the last three minutes (otherwise they are outdated). Probes are sent every ten seconds, and you need to miss three probes to suspect a silo.

1. **Self-monitoring**: The fault detector incorporates ideas from Hashicorp's _Lifeguard_ research ([paper](https://arxiv.org/abs/1707.00788), [talk](https://www.youtube.com/watch?v=u-a7rVJ6jZY), [blog](https://www.hashicorp.com/blog/making-gossip-more-robust-with-lifeguard)) to improve cluster stability during catastrophic events where a large portion of the cluster experiences partial failure. The `LocalSiloHealthMonitor` component scores each silo's health using multiple heuristics:

    - Active status in the membership table
    - No suspicions from other silos
    - Recent successful probe responses
    - Recent probe requests received
    - Thread pool responsiveness (work items executing within 1 second)
    - Timer accuracy (firing within 3 seconds of schedule)

    A silo's health score affects its probe timeouts: unhealthy silos (scoring 1-8) have increased timeouts compared to healthy silos (score 0). This provides two benefits:

    - Gives more time for probes to succeed when the network or system is under stress.
    - Makes it more likely that unhealthy silos are voted dead before they can incorrectly vote out healthy silos.

    This is particularly valuable during scenarios like thread pool starvation, where slow nodes might otherwise incorrectly suspect healthy nodes simply because they cannot process responses quickly enough.

1. **Indirect probing**: Another [Lifeguard](https://arxiv.org/abs/1707.00788)-inspired feature improving failure detection accuracy by reducing the chance that an unhealthy or partitioned silo incorrectly declares a healthy silo dead. When a monitoring silo has two probe attempts remaining for a target silo before casting a vote to declare it dead, it employs indirect probing:

    - The monitoring silo randomly selects another silo as an intermediary and asks it to probe the target.
    - The intermediary attempts to contact the target silo.
    - If the target fails to respond within the timeout period, the intermediary sends a negative acknowledgment.
    - If the monitoring silo receives a negative acknowledgment from the intermediary, and the intermediary declares itself healthy (through self-monitoring, described above), the monitoring silo casts a vote to declare the target dead.
    - With the default configuration of two required votes, a negative acknowledgment from an indirect probe counts as both votes, allowing faster declaration of dead silos when multiple perspectives confirm the failure.

1. **Enforcing perfect failure detection**: Once a silo is declared dead in the table, everyone considers it dead, even if it isn't truly dead (e.g., just temporarily partitioned or heartbeat messages were lost). Everyone stops communicating with it. Once the silo learns it's dead (by reading its new status from the table), it terminates its process. Consequently, an infrastructure must be in place to restart the silo as a new process (a new epoch number is generated upon start). When hosted in Azure, this happens automatically. Otherwise, another infrastructure is required, such as a Windows Service configured to auto-restart on failure or a Kubernetes deployment.

1. **What happens if the table is inaccessible for some time**:

    When the storage service is down, unavailable, or experiencing communication problems, the Orleans protocol does NOT mistakenly declare silos dead. Operational silos continue working without issues. However, Orleans won't be able to declare a silo dead (if it detects a dead silo via missed probes, it can't write this fact to the table) and won't be able to allow new silos to join. So, completeness suffers, but accuracy doesn't—partitioning from the table never causes Orleans to mistakenly declare a silo dead. Also, in a partial network partition (where some silos can access the table and others can't), Orleans might declare a silo dead, but it takes time for all other silos to learn about it. Detection might be delayed, but Orleans never wrongly kills a silo due to table unavailability.

1. **`IAmAlive` writes for diagnostics and disaster recovery**:

    In addition to heartbeats sent between silos, each silo periodically updates an "I Am Alive" timestamp in its table row. This serves two purposes:

    1. **Diagnostics**: Provides system administrators a simple way to check cluster liveness and determine when a silo was last active. The timestamp is typically updated every 5 minutes.

    1. **Disaster recovery**: If a silo hasn't updated its timestamp for several periods (configured via `NumMissedTableIAmAliveLimit`), new silos ignore it during startup connectivity checks. This allows the cluster to recover from scenarios where silos crashed without proper cleanup.

### Membership table

As mentioned, `IMembershipTable` serves as a rendezvous point for silos to find each other and for Orleans clients to find silos. It also helps coordinate agreement on the membership view. The main Orleans repository contains implementations for many systems, including Azure Table Storage, Azure Cosmos DB, PostgreSQL, MySQL/MariaDB, SQL Server, Apache ZooKeeper, Consul IO, Apache Cassandra, MongoDB, Redis, AWS DynamoDB, and an in-memory implementation for development.

1. **[Azure Table Storage](/azure/storage/storage-dotnet-how-to-use-tables)**: In this implementation, the Azure deployment ID serves as the partition key, and the silo identity (`ip:port:epoch`) acts as the row key. Together, they guarantee a unique key per silo. For concurrency control, optimistic concurrency control based on [Azure Table ETags](/rest/api/storageservices/Update-Entity2) is used. Every time data is read from the table, the ETag for each read row is stored and used when trying to write back. The Azure Table service automatically assigns and checks ETags on every write. For multi-row transactions, the support for [batch transactions provided by Azure Table](/rest/api/storageservices/Performing-Entity-Group-Transactions) is utilized, guaranteeing serializable transactions over rows with the same partition key.

1. **SQL Server**: In this implementation, the configured deployment ID distinguishes between deployments and which silos belong to which deployments. The silo identity is defined as a combination of `deploymentID, ip, port, epoch` in appropriate tables and columns. The relational backend uses optimistic concurrency control and transactions, similar to using ETags in the Azure Table implementation. The relational implementation expects the database engine to generate the ETag. For SQL Server 2000, the generated ETag is acquired from a call to `NEWID()`. On SQL Server 2005 and later, [ROWVERSION](/sql/t-sql/data-types/rowversion-transact-sql) is used. Orleans reads and writes relational ETags as opaque `VARBINARY(16)` tags and stores them in memory as [base64](https://en.wikipedia.org/wiki/Base64) encoded strings. Orleans supports multi-row inserts using `UNION ALL` (for Oracle, including `DUAL`), which is currently used to insert statistics data. The exact implementation and rationale for SQL Server is available at [CreateOrleansTables_SqlServer.sql](https://github.com/dotnet/orleans/blob/ba30bbb2155168fc4b9f190727220583b9a7ae4c/src/OrleansSQLUtils/CreateOrleansTables_SqlServer.sql).

1. **[Apache ZooKeeper](https://zookeeper.apache.org/)**: In this implementation, the configured deployment ID is used as a root node, and the silo identity (`ip:port@epoch`) as its child node. Together, they guarantee a unique path per silo. For concurrency control, optimistic concurrency control based on the [node version](https://zookeeper.apache.org/doc/r3.4.6/zookeeperOver.html#Nodes+and+ephemeral+nodes) is used. Every time data is read from the deployment root node, the version for every read child silo node is stored and used when trying to write back. Each time a node's data changes, the ZooKeeper service atomically increases the version number. For multi-row transactions, the [multi method](https://zookeeper.apache.org/doc/r3.4.6/api/org/apache/zookeeper/ZooKeeper.html#multi(java.lang.Iterable)) is utilized, guaranteeing serializable transactions over silo nodes with the same parent deployment ID node.

1. **[Consul IO](https://www.consul.io)**: Consul's Key/Value store was used to implement the membership table. See [Consul Deployment](../deployment/consul-deployment.md) for more details.

1. **[AWS DynamoDB](https://aws.amazon.com/dynamodb/)**: In this implementation, the cluster Deployment ID is used as the Partition Key and Silo Identity (`ip-port-generation`) as the RangeKey, making the record unique. Optimistic concurrency is achieved using the `ETag` attribute by making conditional writes on DynamoDB. The implementation logic is quite similar to Azure Table Storage.

1. **[Apache Cassandra](https://cassandra.apache.org/_/index.html)**: In this implementation, the composite of Service ID and Cluster ID serves as the partition key, and the silo identity (`ip:port:epoch`) as the row key. Together, they guarantee a unique row per silo. For concurrency control, optimistic concurrency control based on a static column version using a Lightweight Transaction is used. This version column is shared for all rows in the partition/cluster, providing a consistent incrementing version number for each cluster's membership table. There are no multi-row transactions in this implementation.

1. **In-memory emulation for development setup**: A special system grain is used for this implementation. This grain lives on a designated primary silo, which is only used for a **development setup**. In any real production usage, a primary silo **isn't required**.

### Design rationale

A natural question might be why not rely completely on [Apache ZooKeeper](https://ZooKeeper.apache.org/) or [etcd](https://etcd.io/) for the cluster membership implementation, potentially using ZooKeeper's out-of-the-box support for group membership with ephemeral nodes? Why implement our membership protocol? There were primarily three reasons:

1. **Deployment/Hosting in the cloud**:

   Zookeeper isn't a hosted service. This means in a Cloud environment, Orleans customers would have to deploy, run, and manage their instance of a ZK cluster. This is an unnecessary burden that wasn't forced on customers. By using Azure Table, Orleans relies on a hosted, managed service, making customers' lives much simpler. _Basically, in the Cloud, use Cloud as a Platform, not Infrastructure._ On the other hand, when running on-premises and managing your servers, relying on ZK as an implementation of `IMembershipTable` is a viable option.

1. **Direct failure detection**:

   When using ZK's group membership with ephemeral nodes, failure detection occurs between the Orleans servers (ZK clients) and ZK servers. This might not necessarily correlate with actual network problems between Orleans servers. _The desire was that failure detection accurately reflects the intra-cluster state of communication._ Specifically, in this design, if an Orleans silo can't communicate with `IMembershipTable`, it isn't considered dead and can continue working. In contrast, if ZK group membership with ephemeral nodes were used, a disconnection from a ZK server might cause an Orleans silo (ZK client) to be declared dead, while it might be alive and fully functional.

1. **Portability and flexibility**:

   As part of Orleans's philosophy, Orleans doesn't force a strong dependence on any particular technology but rather provides a flexible design where different components can be easily switched with different implementations. This is exactly the purpose the `IMembershipTable` abstraction serves.

### Properties of the membership protocol

1. **Can handle any number of failures**:

   This algorithm can handle any number of failures (f<=n), including full cluster restart. This contrasts with "traditional" [Paxos](https://en.wikipedia.org/wiki/Paxos_(computer_science))-based solutions, which require a quorum (usually a majority). Production situations have shown scenarios where more than half of the silos were down. This system stayed functional, while Paxos-based membership wouldn't be able to make progress.

1. **Traffic to the table is very light**:

   Actual probes go directly between servers, not to the table. Routing probes through the table would generate significant traffic and be less accurate from a failure detection perspective – if a silo couldn't reach the table, it would miss writing its "I am alive" heartbeat, and others would declare it dead.

1. **Tunable accuracy versus completeness**:

   While you can't achieve both perfect and accurate failure detection, you usually want the ability to trade off accuracy (not wanting to declare a live silo dead) with completeness (wanting to declare a dead silo dead as soon as possible). The configurable votes to declare dead and missed probes allow trading these two aspects. For more information, see [Yale University: Computer Science Failure Detectors](https://www.cs.yale.edu/homes/aspnes/pinewiki/FailureDetectors.html).

1. **Scale**:

   The protocol can handle thousands, probably even tens of thousands, of servers. This contrasts with traditional Paxos-based solutions, such as group communication protocols, which are known not to scale beyond tens of nodes.

1. **Diagnostics**:

   The table is also very convenient for diagnostics and troubleshooting. System administrators can instantaneously find the current list of alive silos in the table, as well as see the history of all killed silos and suspicions. This is especially useful when diagnosing problems.

1. **Why is reliable persistent storage needed for the implementation of `IMembershipTable`**:

   Persistent storage is used for `IMembershipTable` for two purposes. First, it serves as a rendezvous point for silos to find each other and for Orleans clients to find silos. Second, reliable storage helps coordinate agreement on the membership view. While failure detection occurs directly peer-to-peer between silos, the membership view is stored in reliable storage, and the concurrency control mechanism provided by this storage is used to reach an agreement on who is alive and who is dead. In a sense, this protocol outsources the hard problem of distributed consensus to the cloud. In doing so, the full power of the underlying cloud platform is utilized, using it truly as Platform as a Service (PaaS).

1. **Direct `IAmAlive` writes into the table for diagnostics only**:

   In addition to heartbeats sent between silos, each silo also periodically updates an "I Am Alive" column in its table row. This "I Am Alive" column is only used **for manual troubleshooting and diagnostics** and isn't used by the membership protocol itself. It's usually written at a much lower frequency (once every 5 minutes) and serves as a very useful tool for system administrators to check the liveness of the cluster or easily find out when the silo was last alive.

### Acknowledgements

Acknowledgments for the contribution of Alex Kogan to the design and implementation of the first version of this protocol. This work was done as part of a summer internship in Microsoft Research in the Summer of 2011.
The implementation of ZooKeeper based `IMembershipTable` was done by [Shay Hazor](https://github.com/shayhatsor), the implementation of SQL `IMembershipTable` was done by [Veikko Eeva](https://github.com/veikkoeeva), the implementation of AWS DynamoDB `IMembershipTable` was done by [Gutemberg Ribeiro](https://github.com/galvesribeiro/), the implementation of Consul based `IMembershipTable` was done by [Paul North](https://github.com/PaulNorth), and finally the implementation of the Apache Cassandra `IMembershipTable` was adapted from `OrleansCassandraUtils` by [Arshia001](https://github.com/Arshia001).
