---
title: Network protocols - gRPC for WCF developers
description: An overview of the gRPC network protocols.
ms.date: 09/02/2019
---

# Network protocols

[!INCLUDE [download-alert](includes/download-alert.md)]

Unlike Windows Communication Foundation (WCF), gRPC uses HTTP/2 as a base for its networking. This protocol offers significant advantages over WCF and SOAP, which operate only on HTTP/1.1. For developers wanting to use gRPC, given that there's no alternative to HTTP/2, it would seem to be the ideal moment to explore HTTP/2 in more detail and identify additional benefits of using gRPC.

HTTP/2, released by Internet Engineering Task Force in 2015, was derived from the experimental SPDY protocol, which was already being used by Google. It was specifically designed to be more efficient, faster, and more secure than HTTP/1.1.

## Key features of HTTP/2

This list shows some of the key features and advantages of HTTP/2:

### Binary protocol

Request/response cycles no longer need text commands. This activity simplifies and speeds up the implementation of commands. Specifically, parsing data is faster and uses less memory, network latency is reduced with obvious related improvements to speed, and there's an overall better use of network resources.

### Streams

Streams allow you to create long-lived connections between sender and receiver, over which multiple messages or frames can be sent asynchronously. Multiple streams can operate independently over a single HTTP/2 connection.

### Request multiplexing over a single TCP connection

This feature is one of the most important innovations of HTTP/2. Because it allows multiple parallel requests for data, it's now possible to download web files concurrently from a single server. Websites load faster, and the need for optimization is reduced. Head-of-line (HOL) blocking, where responses that are ready must wait to be sent until an earlier request is completed, is also mitigated (although HOL blocking can still occur at the TCP-transport level).

### Net.TCP-like performance, cross-platform

Fundamentally, the combination of gRPC and HTTP/2 offers developers at least the equivalent speed and efficiency of Net.TCP bindings for WCF, and in some cases even greater speed and efficiency. But, unlike Net.TCP, gRPC over HTTP/2 isn't constrained to .NET applications.

>[!div class="step-by-step"]
>[Previous](interface-definition-language.md)
>[Next](why-grpc.md)
