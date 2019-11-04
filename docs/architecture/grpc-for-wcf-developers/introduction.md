---
title: Introduction - gRPC for WCF Developers
description: Introduction
author: markrendle
ms.date: 09/02/2019
---

# Introduction

Helping machines communicate with each other has been one of the primary preoccupations of the digital age. In particular, there is an ongoing effort to determine the optimal remote communication mechanism that will suit the interoperability demands of the current infrastructure. As you can imagine, that mechanism changes as either the demands or the infrastructure evolves.

The release of .NET Core 3.0 marks a shift in the way that Microsoft delivers remote communication solutions to developers who want to deliver services across a range of platforms. .NET Core doesn't offer Windows Communication Foundation (WCF) out of the box but, with the release of version ASP.NET Core 3.0, it does provide built-in gRPC functionality.

gRPC is a popular framework in the wider software community, used by developers across many programming languages for modern RPC scenarios. The community and the ecosystem are vibrant and active, with support for the gRPC protocol being added to infrastructure components like Kubernetes, service meshes, load balancers and more. These factors, as well as its performance, efficiency and cross-platform compatibility, make gRPC a natural choice for new apps and WCF apps moving to .NET Core.

## History

The fundamental principle of a computer network as nothing more than a group of computers exchanging data with each other to achieve a set of interrelated tasks hasn't changed since its inception. However, the complexity, scale, and expectations have grown exponentially.  

During the 1990s, the emphasis had been mainly focused on improving internal networks using the same language and platforms. TCP/IP became the gold standard for this type of communication.

However, the focus soon shifted to how best to optimize communication across multiple platforms promoting a language agnostic approach. Service-oriented architecture (SOA) provided a structure for loosely coupling a broad collection of services that could be provided to an application.

The development of *Web Services* occurred once all major platforms could access the Internet, but they still couldn’t interact with each other. Web services have open standards and protocols including:

- XML to tag and code data;
- Simple Object Access Protocol (SOAP) to transfer data;
- Web Services Definition Language (WSDL) – describes and connects the web service to the client application; *and*
- Universal Description Discovery Integration (UDDI)- enables Web Services to be discoverable by other Services

SOAP defines the rules by which distributed elements of an application can communicate with each other even if they are on different platforms. SOAP is based on XML, so it's human-readable. The sacrifice for making SOAP easily understood is size; SOAP messages are larger than messages in comparable protocols. SOAP was designed to break down monolithic applications into multi-component form without losing security or control. Therefore, WCF was designed to work with that kind of system, unlike gRPC, which began as a distributed system. WCF addressed some of these limitations by developing and documenting proprietary extension protocols for the SOAP stack, but at the cost of lack of support from other platforms.

Windows Communication Foundation is a framework for building services. It was designed in the early 2000s to help developers using early SOA to manage the complexities of working with SOAP. Although it removes the requirement for the developer to write their own SOAP protocols, WCF still uses SOAP to enable interoperability with other systems. WCF was also designed to deliver solutions across multiple protocols (HTTP/1.1, NetTCP, and so on).

## Microservices

In microservice architectures, large applications are built as a collection of smaller modular services. Each component does a specific task or process, and components are designed to work interoperably but can be isolated as necessary.

Advantages to microservices include:

- Changes and upgrades can be handled independently.
- Error handling becomes more efficient as problems can be traced to specific services that are then isolated, rebuilt, tested, and redeployed independent of the other services.
- Scalability can be confined to the specific instances or services rather than the whole application.
- Development can happen across multiple teams, with less friction than occurs when many teams work on a single codebase.

The move towards increasing virtualization, cloud computing, containers and the Internet of Things have contributed to the ongoing rise of microservices. However, microservices aren't without their challenges. The fragmented/decentralized infrastructure placed more emphasis on the need for simplicity and speed when communicating between services. This in turn drew attention to the sometimes laborious and contorted nature of SOAP.

It was into this environment that gRPC was launched, 10 years after Microsoft first released WCF. Evolved directly from Google’s internal infrastructure RPC (Stubby), gRPC was never based on the same standards and protocols that had informed the parameters of many earlier RPCs. Additionally, gRPC was only ever based on HTTP/2 and that's why it could draw on the new capabilities that advanced transport protocol provided. In particular, bidirectional streaming, binary messaging, and multiplexing.

## About this guide

This guide covers the key features of gRPC. The early chapters take a high-level look at the main features of WCF and compare them to gRPC. It identifies where the are direct correlations between WCF and gRPC and also where gRPC offers an advantage. Where there's no correlation between WCF and gRPC or where gRPC isn't able to offer an equivalent solution to WCF, this guide will suggest workarounds or places to go for further information.

Using a set of sample WCF applications, Chapter 5 is a deep dive look at a converting the main types of WCF service (simple request-reply, one-way, and streaming) to their equivalents in gRPC.

The final section of the book looks at how to get the best from gRPC in practice, including using additional tools like Docker containers or Kubernetes to leverage to the efficiency of gRPC, and a detailed look at the monitoring with logging, metrics, and distributed tracing.

## Whom this guide is for

This guide was written for developers working in .NET Framework or .NET Core who have previously used WCF and who are seeking to migrate their applications to a modern RPC environment for .NET Core 3.0 and later versions. The guide may also be of use more generally for developers upgrading or considering upgrading to .NET Core 3.0 who want to use the built-in gRPC tools.

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](grpc-overview.md)
