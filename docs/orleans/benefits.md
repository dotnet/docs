---
title: Orleans benefits
description: Learn the many benefits of .NET Orleans.
ms.date: 07/03/2024
ms.topic: article
---

# Orleans benefits

The main benefits of Orleans are:

- **Developer productivity**, even for non-expert programmers.
- **Transparent scalability by default** with no special effort from the programmer.

## Developer productivity

The Orleans programming model raises the productivity of both expert and non-expert programmers by providing the following key abstractions, guarantees, and system services.

### Familiar object-oriented programming (OOP) paradigm

Grains are .NET classes that implement declared .NET grain interfaces with asynchronous methods. Grains appear to the programmer as remote objects whose methods can be directly invoked. This provides the programmer the familiar OOP paradigm by turning method calls into messages, routing them to the right endpoints, invoking the target grain's methods, and dealing with failures and corner cases transparently.

### Single-threaded execution of grains

The runtime guarantees that a grain never executes on more than one thread at a time. Combined with the isolation from other grains, the programmer never faces concurrency at the grain level, and never needs to use locks or other synchronization mechanisms to control access to shared data. This feature alone makes the development of distributed applications tractable for non-expert programmers.

### Transparent activation

The runtime activates a grain only when there is a message for it to process. This cleanly separates the notion of creating a reference to a grain, which is visible to and controlled by application code, and physical activation of the grain in memory, which is transparent to the application. This is similar to virtual memory in that it decides when to "page out" (deactivate) or "page in" (activate) a grain; The application has uninterrupted access to the full "memory space" of logically created grains, whether or not they are in the physical memory at any particular point in time.

Transparent activation enables dynamic, adaptive load balancing via placement and migration of grains across the pool of hardware resources. This feature is a significant improvement on the traditional actor model, in which actor lifetime is application-managed.

### Location transparency

A grain reference (proxy object) that the programmer uses to invoke the grain's methods or pass to other components contains only the logical identity of the grain. The translation of the grain's logical identity to its physical location and the corresponding routing of messages is done transparently by the Orleans runtime.

Application code communicates with grains while remaining oblivious to their physical location, which may change over time due to failures or resource management or because a grain is deactivated at the time it is called.

### Transparent integration with a persistent store

Orleans allows for declarative mapping of a grain's in-memory state to a persistent store. It synchronizes updates, transparently guaranteeing that callers receive results only after the persistent state has been successfully updated. Extending and/or customizing the set of existing persistent storage providers available is straightforward.

### Automatic propagation of errors

The runtime automatically propagates unhandled errors up the call chain with the semantics of asynchronous and distributed try/catch. As a result, errors do not get lost within an application. This allows the programmer to put error handling logic at the appropriate places, without the tedious work of manually propagating errors at each level.

## Transparent scalability by default

The Orleans programming model is designed to guide the programmer down a path of likely success in scaling an application or service through several orders of magnitude. This is done by incorporating proven best practices and patterns and by providing an efficient implementation of the lower-level system functionality.

Here are some key factors that enable scalability and performance:

### Implicit fine-grain partitioning of application state

By using grains as directly addressable entities, the programmer implicitly breaks down the overall state of their application.
While the Orleans programming model does not prescribe how big or small a grain should be, in most cases it makes sense to have a relatively large number of grains – millions or more – with each representing a natural entity of the application, such as a user account or a purchase order.

With grains being individually addressable and their physical location abstracted away by the runtime, Orleans has enormous flexibility in balancing load and dealing with hot spots transparently and generically without any thought from the application developer.

### Adaptive resource management

Grains do not assume the locality of other grains as they interact with them. Because of this location transparency, the runtime can manage and adjust the allocation of available hardware resources dynamically. The runtime does this by making fine-grained decisions on placement and migration of grains across the compute cluster in reaction to load and communication patterns&mdash;without failing incoming requests. By creating multiple replicas of a particular grain, the runtime can increase the throughput of the grain without making any changes to the application code.

### Multiplexed communication

Grains in Orleans have logical endpoints, and messaging among them is multiplexed across a fixed set of all-to-all physical connections (TCP sockets). This allows the runtime to host millions of addressable entities with low OS overhead per grain. In addition, activation and deactivation of a grain doesn't incur the cost of registering/unregistering a physical endpoint, such as a TCP port or HTTP URL or even closing a TCP connection.

### Efficient scheduling

The runtime schedules execution of a large number of single-threaded grains using the .NET Thread Pool, which is highly optimized for performance. With grain code written in the non-blocking, continuation-based style (a requirement of the Orleans programming model), application code runs in a very efficient "cooperative" multi-threaded manner with no contention. This allows the system to reach high throughput and run at very high CPU utilization (up to 90%+) with great stability.

The fact that growth in the number of grains in the system and an increase in the load does not lead to additional threads or other OS primitives helps scalability of individual nodes and the whole system.

### Explicit asynchrony

The Orleans programming model makes the asynchronous nature of a distributed application explicit and guides programmers to write non-blocking asynchronous code. Combined with asynchronous messaging and efficient scheduling, this enables a large degree of distributed parallelism and overall throughput without the explicit use of multi-threading.
