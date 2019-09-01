---
title: Network Protocols
description: gRPC for WCF Developers | Network Protocols
ms.date: 08/31/2019
---

# Network protocols

Unlike WCF, gRPC uses HTTP/2 as a base for its networking. This offers significant advantages over WCF and SOAP which only operate on HTTP/1. Given that, for developers wanting to use gRPC, there is no alternative to HTTP/2 it would seem to be the optimum moment to explore http/2 in more detail. This will in turn help us to identify additional benefits to using gRPC.

HTTP/2, released by Internet Engineering Task Force in 2015 was derived from the experimental SPDY protocol which was already being used by Google. It was specifically designed to be simpler, faster and more secure than HTTP/1.

[probably a diagram here]

## Key features of HTTP/2

Some of the key features and advantages of HTTP/2 are discussed below.

### Binary protocol

Request/response cycles no longer needs text commands. This simplifies and speeds up implementation of commands. Specifically, parsing data is faster and uses less memory, network latency is reduced with obvious related improvements to speed and there is an overall better utilisation of network resources.

### Server Push

Servers are now able to send data to the client without receiving a request. Another efficiency saving. This further increases the efficient utilization of network resources by anticipating additional information which has not yet been requested and push it at the same time as the original request thereby freeing up future TCP connections.

### Request multiplexing over a single TCP connection

This is one of the most important features of HTTP/2. By allowing multiple parallel requests for data It was now possible to download web files concurrently from a single server. Websites load faster and the need for optimization is reduced.

## NetTCP-like performance, cross-platform

Fundamentally, the combination of gRPC and HTTP/2 offer developers at least the equivalent speed and efficiency of NetTCP bindings for WCF, and in some cases even greater speed and efficiency. However, unlike NetTCP, gRPC over HTTP/2 is not constrained to C# or VB.NET.

>[!div class="step-by-step"]
<!-->[Next](why-grpc.md)-->
