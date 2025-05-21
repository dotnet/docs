---
title: Use Consul as a membership provider
description: Learn how to use Consul as a membership provider in .NET Orleans.
ms.date: 07/03/2024
---

# Use Consul as a membership provider

[Consul](https://www.consul.io) is a distributed, highly available, and data center-aware service discovery platform that includes simple service registration, health checking, failure detection, and key-value storage. It's built on the premise that every node in the data center is running a Consul agent that is either acting as a server or client. Each agent communicates via a scalable gossip protocol.

There's a detailed overview of Consul including comparisons with similar solutions at [What is Consul?](https://www.consul.io/intro/index.html).

Consul is written in [Go](https://go.dev) and is [open source](https://github.com/hashicorp/consul); compiled downloads are available for [macOS X, FreeBSD, Linux, Solaris, and Windows](https://www.consul.io/downloads.html).

## Why choose Consul?

As an [Orleans Membership Provider](../implementation/cluster-management.md), Consul is a good choice when you need to deliver an on-premises solution that doesn't require your potential customers to have existing infrastructure and a cooperative IT provider. Consul is a lightweight single executable, has no dependencies, and as such can easily be built into your middleware solution. When Consul is your solution for discovering, checking, and maintaining your microservices, it makes sense to fully integrate with Orleans membership for simplicity and ease of operation. There also exists a membership table in Consul (also known as "Orleans Custom System Store"), which fully integrates with Orleans's [Cluster Management](../implementation/cluster-management.md).

## Set up Consul

There's extensive documentation available on [Consul.io](https://www.consul.io) about setting up a stable Consul cluster, and it doesn't make sense to repeat that here. However, for your convenience, we include this guide so you can quickly get Orleans running with a standalone Consul agent.

1. Create a folder to install Consul into (for example _C:\Consul_).
1. Create a subfolder: _C:\Consul\Data_ (Consul doesn't create this directory if it doesn't exist).
1. [Download](https://www.consul.io/downloads.html) and unzip _Consul.exe_ into _C:\Consul_.
1. Open a command prompt at _C:\Consul_ and run the following command:

   ```powershell
   ./consul.exe agent -server -bootstrap -data-dir "C:\Consul\Data" -client='0.0.0.0'
   ```

   In the preceding command:

   - `agent`: Instructs Consul to run the agent process that hosts the services. Without this switch, the Consul process attempts to use RPC to configure a running agent.
   - `-server`: Defines the agent as a server and not a client (A Consul _client_ is an agent that hosts all the services and data, but doesn't have voting rights to decide, and can't become, the cluster leader.
   - `-bootstrap`: The first (and only the first!) node in a cluster must be bootstrapped so that it assumes the cluster leadership.
   - `-data-dir [path]`: Specifies the path where all Consul data is stored, including the cluster membership table.
   - `-client='0.0.0.0'`: Informs Consul which IP to open the service on.

   There are many other parameters, and the option to use a JSON configuration file. For a full listing of the options, see the Consul documentation.

1. Verify that Consul is running and ready to accept membership requests from Orleans by opening the services endpoint in your browser at `http://localhost:8500/v1/catalog/services`. When functioning correctly, the browser displays the following JSON:

    ```json
    {
        "consul": []
    }
    ```

## Configure Orleans

To configure Orleans to use Consul as a membership provider, your silo project will need to reference the [Microsoft.Orleans.Clustering.Consul](https://www.nuget.org/packages/Microsoft.Orleans.Clustering.Consul) NuGet package. Once you've done that, you can configure the membership provider in your silo's _Program.cs_ file as follows:

:::code source="snippets/consul/Silo/Program.cs":::

The preceding code:

- Creates a <xref:Microsoft.Extensions.Hosting.IHostBuilder> with defaults from the <xref:Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder?displayProperty=nameWithType>.
- Chains a call to <xref:Microsoft.Extensions.Hosting.GenericHostExtensions.UseOrleans(Microsoft.Extensions.Hosting.IHostBuilder,System.Action{Microsoft.Extensions.Hosting.HostBuilderContext,Orleans.Hosting.ISiloBuilder})> which configures the Orleans silo.
- Given the <xref:Orleans.Hosting.ISiloBuilder> calls <xref:Orleans.Hosting.ConsulUtilsHostingExtensions.UseConsulSiloClustering%2A>.
- Configures the cluster membership provider to use Consul, given the Consul `address`.

To configure the client, reference the same NuGet package and call the <xref:Orleans.Hosting.ConsulUtilsHostingExtensions.UseConsulClientClustering%2A> extension method.

## Client SDK

If you're interested in using Consul for your service discovery, there are [Client SDKs](https://www.consul.io/downloads_tools.html) for most popular languages.

### Implementation detail

The Membership Table Provider makes use of [Consul's Key/Value store](https://www.consul.io/intro/getting-started/kv.html) functionality with Check-And-Set (CAS) operations. When each Silo starts, it registers two key-value entries, one that contains the Silo details and one that holds the last time the Silo reported it was alive. The latter refers to diagnostics "I'm alive" entries and not to failure detection heartbeats, which are sent directly between the silos and aren't written into the table. All writes to the table are performed with CAS to provide concurrency control, as necessitated by Orleans's [Cluster Management Protocol](../implementation/cluster-management.md).

Once the Silo is running, you can view these entries in your web browser at `http://localhost:8500/v1/kv/?keys&pretty`, which displays something like:

```json
[
    "orleans/default/192.168.1.11:11111@43165319",
    "orleans/default/192.168.1.11:11111@43165319/iamalive",
    "orleans/default/version"
]
```

All of the keys are prefixed with `orleans`, which is hard coded in the provider and is intended to avoid keyspace collision with other users of Consul. You can use any of these keys to retrieve additional information about  Each of these keys can be read by appending their key name (without quotes) to the Consul KV root at `http://localhost:8500/v1/kv/`. Doing so presents you with the following JSON:

```json
[
    {
        "LockIndex": 0,
        "Key": "orleans/default/192.168.1.11:11111@43165319",
        "Flags": 0,
        "Value": "[BASE64 UTF8 Encoded String]",
        "CreateIndex": 321,
        "ModifyIndex": 322
    }
]
```

Decoding the Base64 UTF-8 encoded string `Value` gives you the actual Orleans membership data:

**`http://localhost:8500/v1/KV/orleans/default/[SiloAddress]`**

```json
{
    "Hostname": "[YOUR_MACHINE_NAME]",
    "ProxyPort": 30000,
    "StartTime": "2023-05-15T14:22:00.004977Z",
    "Status": 3,
    "SiloName": "Silo_fcad0",
    "SuspectingSilos": []
}
```

**`http://localhost:8500/v1/KV/orleans/default/[SiloAddress]/IAmAlive`**

```plaintext
"2023-05-15T14:27:01.1832828Z"
```

When the clients connect, they read the KVs for all silos in the cluster in one HTTP GET by using the URI `http://192.168.1.26:8500/v1/KV/orleans/default/?recurse`.

## Limitations

There are a few limitations to be aware of when using Consul as a membership provider.

### Orleans extended membership protocol (table version & ETag)

Consul KV currently doesn't support atomic updates. Therefore, the Orleans Consul Membership Provider only implements the Orleans basic membership protocol, as described in [Cluster management in Orleans](../implementation/cluster-management.md), and doesn't support the Extended Membership Protocol. This Extended protocol was introduced as an extra, but not essential, silo connectivity validation and as a foundation to functionality that hasn't yet been implemented.

### Multiple datacenters

The key-value pairs in Consul aren't currently replicated between Consul data centers. There's a [separate project](https://github.com/hashicorp/consul-replicate) to address this replication effort, but it hasn't yet been proven to support Orleans.

### When running on Windows

When Consul starts on Windows, it logs the following message:

```Output
==> WARNING: Windows is not recommended as a Consul server. Do not use in production.
```

This warning message is displayed due to a lack of focus on testing when running in a Windows environment and not because of any actual known issues. Read the [discussion](https://groups.google.com/forum/#!topic/consul-tool/DvXYgZtUZyU) before deciding if Consul is the right choice for you.

## Potential future enhancements

1. Prove that the Consul KV replication project can support an Orleans cluster in a WAN environment between multiple Consul data centers.
1. Implement the Reminder Table in Consul.
1. Implement the Extended Membership Protocol.
The team behind Consul does plan on implementing atomic operations, once this functionality is available it's possible to remove the limitations in the provider.
