---
title: WCF Bindings and Transports
description: gRPC for WCF Developers | WCF Bindings and Transports
author: markrendle
ms.date: 09/02/2019
---

# WCF Bindings and Transports

WCF has lots of different built in *bindings* specifying different network protocols, wire formats and other implementation details. gRPC effectively has just one network protocol and one wire format. However, you are still likely to discover that gRPC offers the best solution in most cases. What follows is a short discussion about the most relevant WCF Bindings and how they compare to their equivalent in gRPC.

## NetTCP

WCF's NetTCP binding allows for persistent connections, small messages and two-way messaging but only works between .NET clients and servers. gRPC allows the same functionality but based on an open standard. gRPC has almost all the features of WCF NetTCP binding, although not always in the same way. For example, in WCF, encryption is controlled through configuration and handled in the framework. In gRPC, encryption is built in because the HTTP/2 transport layer uses TLS encryption natively.

## HTTP

WCF is only cross-platform when using SOAP over HTTP/1. WCF HTTP binding is text based, uses SOAP as the wire format, and is very slow by the standards of modern networked applications. It's only really used to provide cross-platform interoperability, or connection over internet infrastructure. The equivalent in gRPC&mdash;because it uses HTTP/2 as the underlying transport layer with the binary Protobuf wire format for messages&mdash;can offer Net TCP service level performance but with full cross-platform interoperability with all modern programming languages and frameworks.

## Named Pipes

WCF provided a Named Pipes binding for communication between processes on the same physical machine. Named Pipes is a proprietary Windows feature and doesn’t work like TCP, so HTTP/2 doesn’t work over Named Pipes, meaning gRPC can’t work over Named Pipes.

Outside Windows, the functionality provided by Named Pipes is instead generally provided by Unix Domain Sockets. These are regular TCP-like sockets represented with file-system addresses, such as `/var/run/docker.sock`, which gRPC can work with as both client and server. If you need to use Named Pipes style functionality on Windows, the next update to Windows 10 and Windows Server, in Fall 2019, adds Domain Sockets as a fully supported native feature within Windows. Therefore, gRPC services running on these and later versions of Windows (or on Linux) can use Domain Sockets instead of Named Pipes. However, if your team is unable to update to the latest version of Windows then it will be necessary to use localhost TCP addresses. Security concerns about using local TCP sockets can be alleviated with the use of certificate authentication between client and server.

## MSMQ

MSMQ is a proprietary Windows message queue. WCF's binding to MSMQ enables "fire and forget" requests from clients that may be processed at any time in the future. gRPC does not natively provide any message queue functionality. The best alternative would be to directly use a messaging system like Azure Service Bus, RabbitMQ, Kafka, etc. This could be implemented with the client placing messages directly onto the queue, or a gRPC client streaming service that enqueues the messages.

## WCF ReST

The WCF ReST extensions (e.g. `WebGet`, `WebInvoke`) enabled you to develop ReSTful APIs which could speak JSON at a time when this was less common than now. Therefore, if you have a ReSTful API built with WCF ReST, you should consider migrating it to a regular ASP.NET Core MVC Web API application which would provide equivalent functionality rather than convert to gRPC.

>[!div class="step-by-step"]
<!-->[Next](why-grpc.md)-->
