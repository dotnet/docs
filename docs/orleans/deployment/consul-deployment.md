---
title: Use Consul as a membership provider
description: Learn how to use Consul as a membership provider in .NET Orleans.
ms.date: 03/09/2022
---

# Use Consul as a membership provider

[Consul](https://www.consul.io) is a distributed, highly available, and datacenter-aware service discovery platform that includes simple service registration, health checking, failure detection, and key/value storage. It is built on the premise that every node in the data center is running a Consul agent which is either acting as a server or client which communicates via a scalable gossip protocol.

There is a very detailed overview of Consul including comparisons with similar solutions [here](https://www.consul.io/intro/index.html).

Consul is written in GO and is [open source](https://github.com/hashicorp/consul); compiled downloads are available for [Mac OS X, FreeBSD, Linux, Solaris and Windows](https://www.consul.io/downloads.html)

## Why choose Consul?

As an [Orleans Membership Provider](../implementation/cluster-management.md), Consul is a good choice when you need to deliver an on-premise solution that does not require your potential customers to have existing infrastructure and a cooperative IT provider. Consul is a very lightweight single executable, has no dependencies, and as such can easily be built into your middleware solution. And when Consul is already your solution for discovering, checking, and maintaining your microservices, it makes sense to fully integrate with Orleans membership for simplicity and ease of operation. We, therefore, implemented a membership table in Consul (also known as "Orleans Custom System Store"), which fully integrates with Orleans's [Cluster Management](../implementation/cluster-management.md).

## Set up Consul

There's extensive documentation available on [Consul.io](https://www.consul.io) about setting up a stable Consul cluster, and it doesn't make sense to repeat that here. However, for your convenience, we include this guide so you can quickly get Orleans running with a standalone Consul agent.

1. Create a folder to install Consul into, (for example _C:\Consul_).
1. Create a subfolder: _C:\Consul\Data_ (Consul will not create this if it doesn't exist).
1. [Download](https://www.consul.io/downloads.html) and unzip _Consul.exe_ into _C:\Consul_.
1. Open a command prompt at _C:\Consul_ and run the following command:

    ```powershell
    Consul.exe agent -server -bootstrap -data-dir "C:\Consul\Data" -client=0.0.0.0
    ```

    In the preceding command:

    - `agent` Instructs Consul to run the agent process that hosts the services. Without this, the Consul process will attempt to use RPC to configure a running agent.
    - `-server` Defines the agent as a server and not a client (A Consul _client_ is an agent that hosts all the services and data, but does not have voting rights to decide, and cannot become, the cluster leader.
    - `-bootstrap` The first (and only the first!) node in a cluster must be bootstrapped so that it assumes the cluster leadership.
    - `-data-dir [path]` Specifies the path where all Consul data is stored, including the cluster membership table.
    - `-client=0.0.0.0` Informs Consul which IP to open the service on.

    There are many other parameters, and the option to use a JSON configuration file. Please consult the Consul documentation for a full listing of the options.

1. Verify that Consul is running and ready to accept membership requests from Orleans by opening the services endpoint in your browser at `http://localhost:8500/v1/catalog/services`.

## Configure Orleans

There is a known issue with the "Custom" membership provider _OrleansConfiguration.xml_ configuration file that will fail to parse correctly. For this reason, you have to provide a placeholder SystemStore in the XML and then configure the provider in code before starting the silo.

**OrleansConfiguration.xml**

```xml
<OrleansConfiguration xmlns="urn:orleans">
    <Globals>
        <SystemStore SystemStoreType="None"
            DataConnectionString="http://localhost:8500"
            DeploymentId="MyOrleansDeployment" />
    </Globals>
    <Defaults>
        <Networking Address="localhost" Port="22222" />
        <ProxyingGateway Address="localhost" Port="30000" />
    </Defaults>
</OrleansConfiguration>
```

**Code**

```csharp
public void Start(ClusterConfiguration config)
{
    _siloHost = new SiloHost(System.Net.Dns.GetHostName(), config);

    _siloHost.Config.Globals.LivenessType =
        GlobalConfiguration.LivenessProviderType.Custom;
    _siloHost.Config.Globals.MembershipTableAssembly =
        "OrleansConsulUtils";
    _siloHost.Config.Globals.ReminderServiceType =
        GlobalConfiguration.ReminderServiceProviderType.Disabled;

    _siloHost.InitializeOrleansSilo();

    var started = _siloHost.StartOrleansSilo();
    if (started is false)
    {
        throw new SystemException(
            $"Failed to start Orleans silo '{_siloHost.Name}' as a {_siloHost.Type} node");
    }
}
```

Alternatively, you could configure the silo entirely in code. The client configuration is much simpler:

**ClientConfiguration.xml**

```xml
<ClientConfiguration xmlns="urn:orleans">
    <SystemStore SystemStoreType="Custom"
        CustomGatewayProviderAssemblyName="OrleansConsulUtils"
        DataConnectionString="http://192.168.1.26:8500"
        DeploymentId="MyOrleansDeployment" />
</ClientConfiguration>
```

## Client SDK

If you are interested in using Consul for your service discovery, there are [Client SDKs](https://www.consul.io/downloads_tools.html) for most popular languages.

## Implementation detail

The Membership Table Provider makes use of [Consul's Key/Value store](https://www.consul.io/intro/getting-started/kv.html) functionality with Check-And-Set (CAS) operations. When each Silo starts, it registers two KV entries, one that contains the Silo details and one that holds the last time the Silo reported it was alive (the latter refers to diagnostics "I am alive" entries and not to failure detection heartbeats, which are sent directly between the silos and are not written into the table). All writes to the table are performed with CAS to provide concurrency control, as necessitated by Orleans's [Cluster Management Protocol](../implementation/cluster-management.md).

Once the Silo is running, you can view these entries in your web browser at `http://localhost:8500/v1/kv/?keys`, which will display something like:

```json
[
    "orleans/MyOrleansDeployment/192.168.1.26:11111@191780753",
    "orleans/MyOrleansDeployment/192.168.1.26:11111@191780753/iamalive"
]
```

You'll notice that the keys are prefixed with `orleans`. This is hardcoded in the provider and is intended to avoid keyspace collision with other users of Consul. Each of these keys can be read by appending their key name (without quotes) to the Consul KV root at `http://localhost:8500/v1/kv/`. Doing so presents you with the following:

```json
[
    {
        "LockIndex": 0,
        "Key": "orleans/MyOrleansDeployment/192.168.1.26:22222@191780753",
        "Flags": 0,
        "Value": "[BASE64 UTF8 Encoded String]",
        "CreateIndex": 10,
        "ModifyIndex": 12
    }
]
```

Decoding the string gives you the actual Orleans Membership data:

**`http://localhost:8500/v1/KV/orleans/MyOrleansDeployment/[SiloAddress]`**

```json
{
    "Hostname": "[YOUR_MACHINE_NAME]",
    "ProxyPort": 22222,
    "StartTime": "2016-01-29T16:25:54.9538838Z",
    "Status": 3,
    "SuspectingSilos": []
}
```

**`http://localhost:8500/v1/KV/orleans/MyOrleansDeployment/[SiloAddress]/IAmAlive`**

```plaintext
2016-01-29T16:35:58.9193803Z
```

When the Clients connect, they read the KVs for all silos in the cluster in one HTTP GET by using the URI `http://192.168.1.26:8500/v1/KV/orleans/MyOrleansDeployment/?recurse`.

## Limitations

### Orleans extended membership protocol (table version & ETag)

Consul KV currently does not support atomic updates.
Therefore, the Orleans Consul Membership Provider only implements the Orleans basic membership protocol, as described in [Cluster management in Orleans](../implementation/cluster-management.md), and does not support the Extended Membership Protocol. This Extended protocol was introduced as an additional, but not essential, silo connectivity validation and as a foundation to functionality that has not yet been implemented.
Providing your infrastructure is correctly configured you will not experience any detrimental effect of the lack of support.

### Multiple datacenters

The key-value pairs in Consul are not currently replicated between Consul datacenters. There is a [separate project](https://github.com/hashicorp/consul-replicate) to address this but it has not yet been proven to support Orleans.

### When running on Windows

When Consul starts on Windows it logs the following message:

```Output
==> WARNING: Windows is not recommended as a Consul server. Do not use in production.
```

This is displayed simply due to a lack of focus on testing when running in a Windows environment and not because of any actual known issues.
Read the [discussion](https://groups.google.com/forum/#!topic/consul-tool/DvXYgZtUZyU) before deciding if Consul is the right choice for you.

## Potential future enhancements

1. Prove that the Consul KV replication project can support an Orleans cluster in a WAN environment between multiple Consul datacenters.
1. Implement the Reminder Table in Consul.
1. Implement the Extended Membership Protocol.
The team behind Consul does plan on implementing atomic operations, once this functionality is available it will be possible to remove the limitations in the provider.
