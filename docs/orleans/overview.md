---
title: Orleans overview
description: An introduction to .NET Orleans.
ms.date: 02/08/2022
---

# .NET Orleans

Orleans is a cross-platform framework for building robust, scalable distributed applications. It builds on the developer productivity of .NET and brings it to the world of distributed applications, such as cloud services. Orleans scales from a single on-premises server to globally distributed, highly-available applications in the cloud.

Orleans extends familiar concepts like objects, interfaces, `async` and `await`, and try/catch to multi-server environments. Accordingly, it helps developers experienced with single-server applications transition to building resilient, scalable cloud services and other distributed applications. For this reason, Orleans has often been referred to as "Distributed .NET".

It was created by [Microsoft Research](https://research.microsoft.com/projects/orleans/) and introduced the [Virtual Actor Model](https://research.microsoft.com/apps/pubs/default.aspx?id=210931) as a novel approach to building a new generation of distributed systems for the Cloud era. The core contribution of Orleans is its programming model which tames the complexity inherent to highly-parallel distributed systems without restricting capabilities or imposing onerous constraints on the developer.

## Grains

<!--
![A grain is composed of a stable identity, behavior, and state](~/images/grain_formulation.svg)
-->

The fundamental building block in any Orleans application is a *grain*. Grains are entities comprising user-defined identity, behavior, and state. Grain identities are user-defined keys that make grains always available for invocation. Grains can be invoked by other grains or by external clients such as Web frontend via strongly-typed communication interfaces (contracts). Each grain is an instance of a class that implements one or more of these interfaces.

Grains can have volatile or persistent state data that can be stored in any storage system. As such, grains implicitly partition application states, enabling automatic scalability and simplifying recovery from failures. Grain state is kept in memory while the grain is active, leading to lower latency and less load on data stores.

<!--
    <p align="center">
      ![](~/images/managed_lifecycle.svg)
    </p>
-->

Instantiation of grains is automatically performed on demand by the Orleans runtime. Grains that are not used for a while are automatically removed from memory to free up resources. This is possible because of their stable identity, which allows invoking grains whether they are already loaded into memory or not. This also allows for transparent recovery from failure because the caller does not need to know on which server a grain is instantiated at any point in time. Grains have a managed lifecycle, with the Orleans runtime responsible for activating/deactivating, and placing/locating grains as needed. This allows the developer to write code as if all grains are always in-memory.

Taken together, the stable identity, statefulness, and managing the lifecycle of grains are core factors that make systems built on Orleans scalable, performant, and reliable without forcing developers to write complex distributed systems code.

### Example scenario: IoT backend

Consider a cloud backend for an [Internet of Things](https://en.wikipedia.org/wiki/Internet_of_things) system. This application needs to process incoming device data. Then it must filter, aggregate, and process this information, as well as enable sending commands to devices. In Orleans, it is natural to model each device as a grain which becomes a *digital twin* of the physical device it corresponds to. These grains keep the latest device data in memory so that they can be quickly queried and processed without the need to communicate with the physical device directly. By observing streams of time-series data from the device, the grain can detect changes in conditions, such as measurements exceeding a threshold, and trigger an action.

A simple thermostat could be modeled as follows:

```csharp
public interface IThermostat : IGrainWithStringKey
{
    Task<List<Command>> OnUpdate(ThermostatStatus update);
}
```

Events arriving from the thermostat can be sent to its grain by invoking the `OnUpdate` method, which optionally returns a command to the device.

```csharp
var thermostat = client.GetGrain<IThermostat>(id);
return await thermostat.OnUpdate(update);
```

The same thermostat grain can implement a separate interface for control systems to interact with:

```csharp
public interface IThermostatControl : IGrainWithStringKey
{
    Task<ThermostatStatus> GetStatus();

    Task UpdateConfiguration(ThermostatConfiguration config);
}
```

These two interfaces (`IThermostat` and `IThermostatControl`) are implemented by a single implementation class:

```csharp
public class ThermostatGrain : Grain, IThermostat, IThermostatControl
{
    private ThermostatStatus _status;
    private List<Command> _commands;
    
    public Task<List<Command>> OnUpdate(ThermostatStatus status)
    {
        _status = status;
        var result = _commands;
        _commands = new List<Command>();
        return Task.FromResult(result);
    }

    public Task<ThermostatStatus> GetStatus() => Task.FromResult(_status);

    public Task UpdateConfiguration(ThermostatConfiguration config)
    {
        _commands.Add(new ConfigUpdateCommand(config));
        return Task.CompletedTask;
    }
}
```

The grain class above does not persist in its state. Examples demonstrating state persistence are available in the [documentation](grains/grain-persistence/index.md).

## Orleans runtime

The Orleans runtime is what implements the programming model for applications. The main component of the runtime is the *silo*, which is responsible for hosting grains.

Typically, a group of silos runs as a cluster for scalability and fault tolerance. When run as a cluster, silos coordinate with each other to distribute work, detect and recover from failures. The runtime enables grains hosted in the cluster to communicate with each other as if they are within a single process.

In addition to the core programming model, silos provide grains with a set of runtime services such as timers, reminders (persistent timers), persistence, transactions, streams, and more. See [Features](#features) for more detail.

Web frontends and other external clients call grains in the cluster using the client library, which automatically manages network communication. Clients can also be co-hosted in the same process with silos for simplicity.

Orleans is compatible with .NET Standard 2.0 and above, running on Windows, Linux, and macOS.

## Features

### Persistence

Orleans provides a simple persistence model which ensures that state is available to a grain before requests are processed and that consistency is maintained. Grains can have multiple named persistent data objects. For example, there might be one called "profile" for a user's profile and one called "inventory" for their inventory. This state can be stored in any storage system. Using the above example, profile data may be stored in one database and inventory in another.

While a grain is running, this state is kept in memory so that read requests can be served without accessing storage. When the grain updates its state, a `state.WriteStateAsync()` call ensures that the backing store is updated for durability and consistency.

For more information, see the [Grain persistence](grains/grain-persistence/index.md).

### Distributed ACID transactions

In addition to the simple persistence model described above, grains can have a *transactional state*. Multiple grains can participate in [ACID](https://en.wikipedia.org/wiki/ACID) transactions together regardless of where their state is ultimately stored. Transactions in Orleans are distributed and decentralized (there is no central transaction manager or transaction coordinator) and have [serializable isolation](https://en.wikipedia.org/wiki/Isolation_(database_systems)#Isolation_levels).

For more information on transactions in Orleans, see the [documentation](grains/transactions.md) and the [Microsoft Research technical report](https://www.microsoft.com/research/publication/transactions-distributed-actors-cloud-2/).

### Streams

Streams help developers to process a series of data items in near-real-time. Streams in Orleans are *managed*; Streams do not need to be created or registered before a grain or client publishes to a stream or subscribes to a stream. This allows for greater decoupling of stream producers and consumers from each other and the infrastructure.

Stream processing is reliable: grains can store checkpoints (cursors) and reset to a stored checkpoint during activation or at any subsequent time. Streams support batch delivery of messages to consumers to improve efficiency and recovery performance.

Streams are backed by queueing services such as Azure Event Hubs, Amazon Kinesis, and others.

An arbitrary number of streams can be multiplexed onto a smaller number of queues and the responsibility for processing these queues is balanced evenly across the cluster.

### Timers and reminders

Reminders are a durable scheduling mechanism for grains. They can be used to ensure that some action is completed at a future point even if the grain is not currently activated at that time. Timers are the non-durable counterpart to reminders and can be used for high-frequency events which do not require reliability.

For more information, see the [Timers and reminders](grains/timers-and-reminders.md) documentation.

### Flexible grain placement

When a grain is activated in Orleans, the runtime decides which server (silo) to activate that grain on. This is called grain placement.

The placement process in Orleans is fully configurable. Developers can choose from a set of out-of-the-box placement policies such as random, prefer-local, and load-based, or custom logic can be configured. This allows for full flexibility in deciding where grains are created. For example, grains can be placed on a server close to resources which they need to operate against or other grains with which they communicate.

For more information see the [Grain placement](grains/grain-placement.md) documentation.

### Grain versioning and heterogeneous clusters

Upgrading production systems in a manner that safely accounts for changes can be challenging, particularly in stateful systems. To account for this, grain interfaces in Orleans can be versioned.

The cluster maintains a mapping of which grain implementations are available on which silos in the cluster and the versions of those implementations. This version of the information is used by the runtime in conjunction with placement strategies to make placement decisions when routing calls to grains. In addition, to safely update a versioned grain, this also enables heterogeneous clusters, where different silos have different sets of grain implementations available.

For more information, see the [Grain Versioning](grains/grain-versioning/grain-versioning.md) documentation.

### Elastic scalability and fault tolerance

Orleans is designed to scale elastically. When a silo joins a cluster it can accept new activations. When a silo leaves the cluster, either because of scale down or a machine failure, the grains which were activated on that silo will be re-activated on the remaining silos as needed. An Orleans cluster can be scaled down to a single silo.

The same properties which enable elastic scalability also enable fault tolerance. The cluster automatically detects and quickly recovers from failures.

### Run anywhere

Orleans runs anywhere that .NET is supported. This includes hosting on Linux, Windows, and macOS. Orleans apps can be deployed to Kubernetes, virtual machines, and PaaS services such as Azure Cloud Services.

### Stateless workers

Stateless workers are specially marked grains that don't have any associated state and can be activated on multiple silos simultaneously. This enables increased parallelism for stateless functions.

For more information, see the [stateless worker grains](grains/stateless-worker-grains.md) documentation.

### Grain call filters

A call filter for a grain, is logic that is common to many grains can be expressed as [grain call filters](grains/interceptors.md). Orleans supports filters for both incoming and outgoing calls. Some common uses of filters are authorization, logging and telemetry, and error handling.

### Request context

Metadata and other information can be passed along a series of requests using [request context](grains/request-context.md). Request context can be used for holding distributed tracing information or any other user-defined values.

## Getting Started

Please see the [getting started tutorial](tutorials-and-samples/tutorial-1.md).

## Origin of Orleans

Orleans was created at [Microsoft Research and designed for use in the cloud](https://www.microsoft.com/research/publication/orleans-distributed-virtual-actors-for-programmability-and-scalability/). Since 2011, it has been used extensively in the cloud and on-premises by several Microsoft product groups, most notably by game studios, such as 343 Industries and The Coalition as a platform for cloud services behind Halo and Gears of War games, as well as by several other companies.

Orleans was open-sourced in January 2015 and attracted many developers that formed [one of the most vibrant open source communities in the .NET ecosystem](https://mattwarren.org/2016/11/23/open-source-net-2-years-later/).

In an active collaboration between the developer community and the Orleans team at Microsoft, features are added and improved daily. Microsoft Research continues to partner with the Orleans team to bring new major features, such as [geo-distribution](https://www.microsoft.com/research/publication/geo-distribution-actor-based-services/), [indexing](https://www.microsoft.com/research/publication/indexing-in-an-actor-oriented-database/), and [distributed transactions](https://www.microsoft.com/research/publication/transactions-distributed-actors-cloud-2/), that are pushing the state of the art.

Orleans has become the framework of choice for building distributed systems and cloud services for many .NET developers.
