---
title: Why gRPC is recommended for WCF developers - gRPC for WCF Developers
description: A discussion of why gRPC is a good fit for WCF developers looking to migrate to modern architectures and platforms.
author: markrendle
ms.date: 09/02/2019
---

# Why gRPC is recommended for WCF developers

Before diving deeply into the language and techniques of gRPC, it's worth discussing why gRPC is the right solution for WCF developers who want to migrate to .NET Core, given there are alternatives available.

## Similarity to WCF

Although its implementation and approach is different, the actual experience of developing and consuming services with gRPC should be very intuitive for WCF developers. The underlying goal of making it possible to code as though the client and server were on the same platform, without needing to worry about networking, is the same. Both platforms share the principle of declaring and then implementing an interface, even though the process for declaring that interface is different. And as you'll see in chapter 5, the different types of RPC calls supported by gRPC map very well to the different bindings available to WCF services.

## Benefits of gRPC

Additional reasons why gRPC stands above other solutions are:

### Performance

As already discussed, using HTTP/2 rather than HTTP/1.1 removes the requirement for human-readable messages and instead uses the smaller faster binary protocol. This is more efficient for computers to parse. HTTP/2 also supports multiplexing requests over a single connection enabling responses to be sent as soon as they're ready without the need to wait in a queue (an issue in HTTP/1.1 known as "head-of-line (HOL) blocking"). Fewer resources are needed when using gRPC, which makes it a good solution to use for mobile devices and over slower networks.

### Interoperability

There are gRPC tools and libraries for all major programming languages and platforms, including .NET, Java, Python, Go, C++, Node.js, Swift, Dart, Ruby, and PHP. Thanks to the Protocol Buffers binary wire format and the efficient code generation for each platform, developers can achieve better performance than WCF's NetTCP bindings while still enjoying full cross-platform support.

### Usability and productivity

gRPC is a comprehensive RPC solution. It has thoroughly addressed the full range of networking and connectivity concerns. gRPC works consistently across multiple languages. gRPC provides excellent tooling, with much of the boilerplate auto-generated, so more developer time is freed up to focus on business logic.

### Streaming

gRPC has full bidirectional streaming, which is very similar to WCF's Full Duplex services but without the dependency on complicated network bindings and transports. gRPC streaming can operate over regular internet connections, load balancers, and service meshes.

### Deadline/timeouts and cancellation

gRPC allows clients to specify a maximum time for an RPC to complete. If the specified deadline is exceeded the server can cancel the operation independently of the client. Deadlines and cancellations can be propagated through further gRPC calls to help enforce resource usage limits. Clients may also abort operations when a deadline is exceeded, or earlier if necessary (e.g. due to a user interaction).

### Security

gRPC is implicitly secure when using HTTP/2 over an TLS end-to-end encrypted connection. Support for Client Certificate authentication (see chapter 6) further increases security and trust between client and server.

>[!div class="step-by-step"]
<!-->[Next](protocol-buffers.md)-->
