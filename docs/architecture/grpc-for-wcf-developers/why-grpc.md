---
title: Why gRPC is recommended for WCF developers - gRPC for WCF Developers
description: A discussion of why gRPC is a good fit for WCF developers looking to migrate to modern architectures and platforms
author: markrendle
ms.date: 09/02/2019
---

# Why gRPC is recommended for WCF developers

Before diving deeply into the language and techniques of gRPC it is worth pulling together some ideas about why, given there are alternatives available, gRPC is the right solution for WCF developers who want to migrate to .NetCore.

## Similarity to WCF

Although its implementation and approach is different, the actual experience of developing and consuming services with gRPC should be very intuitive for WCF developers. The underlying goal of making it possible to code as though the client and server were on the same platform, without needing to worry about networking, is the same. Both platforms share the principle of declaring and then implementing an interface, even though the process for declaring that interface is different. And as you will see in Chapter 5, the different types of RPC calls supported by gRPC map very well to the different bindings available to WCF services.

## Benefits of gRPC

Additional reasons why gRPC stands above other solutions are:

### Performance

As already discussed, using HTTP/2 rather than HTTP/1.1 removes the requirement for human-readability code and instead use the smaller faster binary protocol. This is more efficient for computers to parse. HTTP/2 also supports multiplexing requests over a single connection enabling responses to be sent as soon as they are ready without the need to wait in a queue.  Fewer resources are needed when using gRPC which makes it a good solution to use for mobile devices and over slower networks. [Mark to check]

### Interoperability

There are gRPC tools and libraries for all major programming languages and platforms, including .NET, Java, Python, Go, C++, Node.js, Swift, Dart, Ruby, and PHP. Thanks to the Protocol Buffers binary wire format and the efficient code generation for each platform, developers can achieve performance better than WCF's NetTCP bindings while still enjoying full cross-platform support.

### Simplicity and productivity

gRPC is a comprehensive RPC solution. It has thoroughly addressed the full range of connectivity issues. gRPC works consistently across multiple languages. gRPC is simple with much of the boilerplate auto-generated. Therefore more developer time is freed up to focus on business Logic.

### Streaming

gRPC has full bi-directional streaming, which is very similar to WCF's Full Duplex services but without the dependency on complicated network bindings and transports. gRPC streaming can operate over regular internet connections, load balancers and service meshes.

### Security

gRPC is implicitly secure when using HTTP/2 over an SSL/TLS end-to-end encrypted connection. Support for Client Certificate authentication (see chapter 6) further increases security and trust between client and server.

>[!div class="step-by-step"]
<!-->[Next](protocol-buffers.md)-->
