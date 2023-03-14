---
title: Why we recommend gRPC for WCF developers - gRPC for WCF developers
description: A discussion of why gRPC is a good fit for WCF developers who want to migrate to modern architectures and platforms.
ms.date: 12/14/2021
---

# Why we recommend gRPC for WCF developers

[!INCLUDE [download-alert](includes/download-alert.md)]

Before we dive deeply into the language and techniques of gRPC, it's worth discussing why gRPC is the right solution for Windows Communication Foundation (WCF) developers who want to migrate to .NET.

## Similarity to WCF

Although the implementation and approach are different for gRPC, the experience of developing and consuming services with gRPC should be intuitive for WCF developers. The underlying goal is the same: make it possible to code as though the client and server are on the same platform, without needing to worry about networking.

Both platforms share the principle of declaring and then implementing an interface, even though the process for declaring that interface is different. And as you'll see in chapter 5, the different types of RPC calls that gRPC supports map well to the bindings available to WCF services.

## Benefits of gRPC

gRPC stands above other solutions for the following reasons.

### Performance

Using HTTP/2 rather than HTTP/1.1 removes the requirement for human-readable messages and instead uses the smaller, faster binary protocol. This is more efficient for computers to parse. HTTP/2 also supports multiplexing requests over a single connection. This support enables responses to be sent as soon as they're ready without the need to wait in a queue. (In HTTP/1.1, this issue is known as "head-of-line (HOL) blocking.") You need fewer resources when using gRPC, which makes it a good solution to use for mobile devices and over slower networks.

### Interoperability

There are gRPC tools and libraries for all major programming languages and platforms, including .NET, Java, Python, Go, C++, Node.js, Swift, Dart, Ruby, and PHP. Thanks to the Protocol Buffers binary wire format and the efficient code generation for each platform, developers can build performant apps while still enjoying full cross-platform support.

### Usability and productivity

gRPC is a comprehensive RPC solution. It works consistently across multiple languages and platforms. It also provides excellent tooling, with much of the necessary boilerplate code automatically generated. So more developer time is freed up to focus on business logic.

### Streaming

gRPC has full bidirectional streaming, which provides similar functionality to WCF's full-duplex services. gRPC streaming can operate over regular internet connections, load balancers, and service meshes.

### Deadline/timeouts and cancellation

gRPC allows clients to specify a maximum time for an RPC to finish. If the specified deadline is exceeded, the server can cancel the operation independently of the client. Deadlines and cancellations can be propagated through further gRPC calls to help enforce resource usage limits. Clients can also stop operations when a deadline is exceeded, or earlier if necessary (for example, because of a user interaction).

### Security

gRPC is implicitly secure when it's using HTTP/2 over a TLS end-to-end encrypted connection. Support for client certificate authentication (see [chapter 6](security.md)) further increases security and trust between client and server.

## Comparison with CoreWCF

A notable alternative to gRPC for replacing WCF services when migrating to .NET is [CoreWCF](https://github.com/corewcf/corewcf). Both gRPC and CoreWCF are Microsoft endorsed paths forward for WCF applications and each comes with its own benefits and drawbacks.

CoreWCF is a community-owned .NET Foundation project supported by Microsoft that implements WCF server APIs for .NET. CoreWCF is an effort to allow existing WCF services to work with minimal changes on .NET. Your Data Contracts for WCF are unchanged with CoreWCF, and it supports many of the bindings and APIs from WCF. The main differences are around the patterns for starting WCF services, and not all configuration options are available (some configuration must now be done in code).

Services and interfaces can often migrate with few changes. Because of this, a key benefit of CoreWCF is its very high compatibility with WCF. Where changes have been made, they are to adapt to the programming style of modern .NET, for example hosting now through ASP.NET Core, and APIs now use the `Task` based async patterns usable with `await` rather than the older BeginXXX / EndXXX pattern.

On the other hand, gRPC is a modern remote communication solution with a number of features, as discussed previously. Benefits of using gRPC include better interoperability across languages, its relatively simple modern API, and a broad community ecosystem.

When deciding whether to use CoreWCF or gRPC to migrate a WCF application to .NET, CoreWCF is typically a better fit if the goal is to migrate the application with minimal changes whereas gRPC may be a better fit if the goal is to modernize the application while retargeting to .NET. The remainder of this guide focuses on that modernization with gRPC.

>[!div class="step-by-step"]
>[Previous](network-protocols.md)
>[Next](protocol-buffers.md)
