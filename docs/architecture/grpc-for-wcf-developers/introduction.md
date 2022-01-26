---
title: Introduction - gRPC for WCF developers
description: Introduction
ms.date: 12/14/2021
---

# Introduction to gRPC for WCF developers

Helping machines communicate with each other has been one of the primary preoccupations of the digital age. In particular, there's an ongoing effort to determine the optimal remote communication mechanism that will suit the interoperability demands of the current infrastructure. As you can imagine, that mechanism changes as either the demands or the infrastructure evolves.

The release of .NET Core 3.0 marks a shift in the way that Microsoft delivers remote communication solutions to developers who want to deliver services across a range of platforms. .NET Core and later doesn't offer Windows Communication Foundation (WCF) out of the box but, with the release of ASP.NET Core 3.0, it does provide built-in gRPC functionality.

gRPC is a popular framework in the wider software community. It's used by developers across many programming languages for modern RPC scenarios. The community and the ecosystem are vibrant and active. Support for the gRPC protocol is being added to infrastructure components like Kubernetes, service meshes, load balancers, and more. These factors, together with its performance, efficiency, and cross-platform compatibility, make gRPC a natural choice for new apps and WCF apps moving to .NET.

## History

The fundamental principle of a computer network as nothing more than a group of computers exchanging data with each other to achieve a set of interrelated tasks hasn't changed since its inception. But the complexity, scale, and expectations have grown exponentially.

During the 1990s, the emphasis was mainly on improving internal networks that used the same language and platforms. TCP/IP became the gold standard for this type of communication.

The focus soon shifted to how best to optimize communication across multiple platforms by promoting a language-agnostic approach. Service-oriented architecture (SOA) provided a structure for loosely coupling a broad collection of services that could be provided to an application.

The development of *web services* occurred when all major platforms could access the internet, but they still couldn't interact with each other. Web services have open standards and protocols, including:

- XML to tag and code data.
- Simple Object Access Protocol (SOAP) to transfer data.
- Web Services Definition Language (WSDL) to describe and connect web services to client applications.
- Universal Description, Discovery, and Integration (UDDI) to make web services discoverable by other services.

SOAP defines the rules by which distributed elements of an application can communicate with each other, even if they're on different platforms. SOAP is based on XML, so it's human-readable. The sacrifice for making SOAP easily understood is size; SOAP messages are larger than messages in comparable protocols. SOAP was designed to break monolithic applications into multicomponent form without losing security or control. So WCF was designed to work with that kind of system, unlike gRPC, which began as a distributed system. WCF addressed some of these limitations by developing and documenting proprietary extension protocols for the SOAP stack, but at the cost of a lack of support from other platforms.

Windows Communication Foundation is a framework for building services. It was designed in the early 2000s to help developers using early SOA to manage the complexities of working with SOAP. Although it removes the requirement for the developers to write their own SOAP protocols, WCF still uses SOAP to enable interoperability with other systems. WCF was also designed to deliver solutions across multiple protocols (HTTP/1.1, Net.TCP, and so on).

## Microservices

In microservice architectures, large applications are built as a collection of smaller modular services. Each component does a specific task or process, and components are designed to work interoperably but can be isolated as necessary.

Advantages to microservices include:

- Changes and upgrades can be handled independently.
- Error handling becomes more efficient because problems can be traced to specific services that are then isolated, rebuilt, tested, and redeployed independently of the other services.
- Scalability can be confined to specific instances or services rather than the whole application.
- Development can happen across multiple teams, with less friction than occurs when many teams work on a single codebase.

The move towards increasing virtualization, cloud computing, containers, and the Internet of Things has contributed to the ongoing rise of microservices. But microservices aren't without their challenges. The fragmented/decentralized infrastructure put more emphasis on the need for simplicity and speed when communicating between services. This in turn drew attention to the sometimes laborious and contorted nature of SOAP.

It was into this environment that gRPC was launched, 10 years after Microsoft first released WCF. Evolved directly from Google's internal infrastructure RPC (Stubby), gRPC was never based on the same standards and protocols that had informed the parameters of many earlier RPCs. And gRPC was only ever based on HTTP/2. That's why it could draw on the new capabilities that advanced transport protocol provided. In particular, bidirectional streaming, binary messaging, and multiplexing.

## About this guide

This guide covers the key features of gRPC. The early chapters take a high-level look at the main features of WCF and compare them to those of gRPC. It identifies where there are direct correlations between WCF and gRPC and also where gRPC offers an advantage. When there's no correlation between WCF and gRPC, or when gRPC isn't able to offer an equivalent solution to WCF, this guide will suggest workarounds or where to go for more information.

Using a set of sample WCF applications, Chapter 5 is a deep-dive look at converting the main types of WCF service (simple request-reply, one-way, and streaming) to their equivalents in gRPC.

The final section of the book looks at how to get the best from gRPC in practice. This section includes information on using additional tools, like Docker containers or Kubernetes, to take advantage of the efficiency of gRPC. It also includes a detailed look at monitoring with logging, metrics, and distributed tracing.

## Who this guide is for

This guide was written for developers working in .NET Framework or .NET Core who have used WCF and who are seeking to migrate their applications to a modern RPC environment for .NET Core 3.0 and later versions. The guide might also be useful more generally for developers upgrading or considering upgrading to .NET and who want to use the built-in gRPC tools.

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](grpc-overview.md)
