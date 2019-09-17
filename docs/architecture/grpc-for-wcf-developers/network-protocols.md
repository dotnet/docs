---
title: Network protocols - gRPC for WCF Developers
description: An overview of the gRPC network protocols.
author: markrendle
ms.date: 09/02/2019
---

# Network protocols

Unlike WCF, gRPC uses HTTP/2 as a base for its networking. This offers significant advantages over WCF and SOAP, which only operate on HTTP/1.1. For developers wanting to use gRPC, given that there's no alternative to HTTP/2, it would seem to be the ideal moment to explore HTTP/2 in more detail and identify additional benefits to using gRPC.

HTTP/2, released by Internet Engineering Task Force in 2015, was derived from the experimental SPDY protocol, which was already being used by Google. It was specifically designed to be simpler, faster, and more secure than HTTP/1.1.

## Key features of HTTP/2

The following list shows some of the key features and advantages of HTTP/2:

### Binary protocol

Request/response cycles no longer need text commands. This simplifies and speeds up implementation of commands. Specifically, parsing data is faster and uses less memory, network latency is reduced with obvious related improvements to speed and there's an overall better use of network resources.

### Server push

Servers are now able to send data to the client without receiving a request. Another efficiency saving. This further increases the efficient use of network resources by anticipating additional information that hasn't been requested yet and pushing it at the same time as the original request, freeing up future TCP connections by doing that.

### Request multiplexing over a single TCP connection

This is one of the most important features of HTTP/2. By allowing multiple parallel requests for data, it's now possible to download web files concurrently from a single server. Websites load faster and the need for optimization is reduced.

### NetTCP-like performance, cross-platform

Fundamentally, the combination of gRPC and HTTP/2 offer developers at least the equivalent speed and efficiency of NetTCP bindings for WCF, and in some cases even greater speed and efficiency. However, unlike NetTCP, gRPC over HTTP/2 isn't constrained to .NET applications.

>[!div class="step-by-step"]
<!-->[Next](why-grpc.md)-->
