---
title: "Reliable Sessions Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a7fc4146-ee2c-444c-82d4-ef6faffccc2d
caps.latest.revision: 30
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---

# Reliable Sessions Overview

[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] SOAP reliable messaging provides end-to-end message transfer reliability between SOAP endpoints. It does this on networks that are unreliable by overcoming transport failures and SOAP message-level failures. In particular, it provides session-based, single, and (optionally) ordered delivery for messages sent across SOAP or transport intermediaries. Session-based delivery provides for grouping messages in a session with optional ordering of the messages.

This topic describes reliable sessions, how and when to use them, and how to secure them.

## WCF reliable sessions

[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] reliable sessions is an implementation of SOAP reliable messaging as defined by the WS-ReliableMessaging protocol.

[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] SOAP reliable messaging provides an end-to-end reliable session between two endpoints, regardless of the number or type of intermediaries that separate the messaging endpoints. This includes any transport intermediaries that don't use SOAP (for example, HTTP proxies) or intermediaries that use SOAP (for example, SOAP-based routers or bridges) that are required for messages to flow between the endpoints. A reliable session channel supports *interactive* communication so that the services connected by such a channel run concurrently and exchange and process messages under conditions of low latency, that is, within relatively short intervals of time. This coupling means that these components make progress together or fail together, so there's no isolation provided between them.

A reliable session masks two kinds of failures:

- SOAP message-level failures, which includes lost or duplicated messages and messages that arrive in a different order from the order in which they were sent.

- Transport failures.

A reliable session implements the WS-ReliableMessaging protocol and an in-memory transfer window to mask SOAP message-level failures and re-establishes connections in the case of transport failures.

A reliable session provides for SOAP messages what TCP provides for IP packets. A TCP socket connection provides a singular, in-order transfer of IP packets between nodes. The reliable channel provides the same type of reliable transfer, but it differs from TCP socket reliability in the following ways:

- The reliability is at the SOAP message level, not for an arbitrarily sized packet of bytes.

- The reliability is transport-neutral, not just for transfer over TCP.

- The reliability isn't tied to a particular transport session (for example, the session a TCP connection provides) and can use multiple transport sessions concurrently or sequentially over the lifetime of the reliable session.

- The reliable session is between the sender and receiver SOAP endpoints, regardless of the number of transport connections required for connectivity between them. In short, TCP reliability ends where the transport connection ends, while a reliable session provides end-to-end reliability.

## Reliable sessions and bindings

As mentioned earlier, a reliable session is transport neutral. Also, you can establish a reliable session over many message exchange patterns, such as request-reply or duplex. A [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] reliable session is exposed as a property of a set of bindings.

Use a reliable session on endpoints that use:

- HTTP-based transport standard bindings:

  - `WsHttpBinding` and expose request-reply or one-way contracts.

  - When using reliable session over a request-reply or simple one-way service contract.

  - `WsDualHttpBinding` and expose duplex, request-reply, or one-way contracts.

  - `WsFederationHttpBinding` and expose request-reply or one-way contracts.

- TCP-based transport standard bindings:

  - `NetTcpBinding` and expose duplex, request reply, or one-way contracts.

Use a reliable session on any other bindings by creating a custom binding, such as HTTPS (for more information about issues, see <a href="#reliable-sessions-and-security">Reliable sessions and security</a>) or a named pipe binding.

You can stack a reliable session on different underlying channel types, and the resulting reliable session channel shape varies. On both the client and the server, the type of reliable session channel supported depends on the type of underlying channel used. The following table lists the types of session channels supported on the client as a function of the underlying channel type.

| Supported reliable session channel types&#8224; | `IRequestChannel` | `IRequestSessionChannel` | `IDuplexChannel` | `IDuplexSessionChannel` |
| ----------------------------------------------- | :---------------: | :----------------------: | :--------------: | :---------------------: |
| `IOutputSessionChannel`                         | Yes               | Yes                      | Yes              | Yes                     |
| `IRequestSessionChannel`                        | Yes               | Yes                      | No               | No                      |
| `IDuplexSessionChannel`                         | No                | No                       | Yes              | Yes                     |

&#8224;The supported channel types are the values available for the generic `TChannel` parameter value that is passed into the <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.BuildChannelFactory%60%601%28System.ServiceModel.Channels.BindingContext%29> method.

The following table lists the types of session channels supported on the server as a function of the underlying channel type.

| Supported reliable session channel types&#8225; | `IReplyChannel` | `IReplySessionChannel` | `IDuplexChannel` | `IDuplexSessionChannel` |
| ----------------------------------------------- | :-------------: | :--------------------: | :--------------: | :---------------------: |
| `IInputSessionChannel`                          | Yes             | Yes                    | Yes              | Yes                     |
| `IReplySessionChannel`                          | Yes             | Yes                    | No               | No                      |
| `IDuplexSessionChannel`                         | No              | No                     | Yes              | Yes                     |

&#8225;The supported channel types are the values available for the generic `TChannel` parameter value that is passed into the <xref:System.ServiceModel.Channels.ReliableSessionBindingElement.BuildChannelListener%60%601%28System.ServiceModel.Channels.BindingContext%29> method.

## Reliable sessions and security

Securing a reliable session is important to ensure that the communicating parties (service and client) are authenticated and that the messages exchanged in the session aren't tampered with. Furthermore, it's important to ensure the integrity of each individual reliable session. A reliable session is secured by binding it to a security context that's represented and managed by a security session channel. The security channel provides a security session. Security tokens exchanged during the session establishment are then used to secure the messages in the reliable session.

When a reliable session is over TCP-S, the TCP session is tied to the reliable session. Therefore, transport security ensures that security is also tied to the reliable session. In this case, connection re-establishment is turned off.

The only exception is when using HTTPS. The Secure Sockets Layer (SSL) session isn't bound to the reliable session. This imposes a threat because sessions that are sharing a security context (the SSL session) aren't protected from each other; this might or might not be a real threat depending on the application.

## Using reliable sessions

To use [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] reliable sessions, create an endpoint with a binding that supports a reliable session. Use one of the system-provided bindings that [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] provides with the reliable session enabled or create your own custom binding that does this.

The system-defined bindings that support and enable a reliable session by default include:

- <xref:System.ServiceModel.WSDualHttpBinding>

The system-provided bindings that support a reliable session as an option but don't enable one by default include:

- <xref:System.ServiceModel.WSHttpBinding>

- <xref:System.ServiceModel.WSFederationHttpBinding>

- <xref:System.ServiceModel.NetTcpBinding>

For an example of how to create a custom binding, see [How to: Create a Custom Reliable Session Binding with HTTPS](../../../../docs/framework/wcf/feature-details/how-to-create-a-custom-reliable-session-binding-with-https.md).

For a discussion of [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] bindings that support reliable sessions, see [System-Provided Bindings](../../../../docs/framework/wcf/system-provided-bindings.md).

## When to use reliable sessions

It's important to understand when to use reliable sessions in your application. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] supports reliable sessions between endpoints that are active and alive at the same time. If your application requires one of the endpoints be unavailable for a duration of time, then use queues to achieve reliability.

If the scenario requires two endpoints connected over TCP, then TCP may be sufficient to provide reliable message exchanges. Although, it isn't necessary to use a reliable session, since TCP ensures that the packets arrive in order and only once.

If your scenario has any of the following characteristics, then you must seriously consider using a reliable session.

- SOAP intermediaries, such as SOAP routers

- Proxy intermediaries or transport bridges

- Intermittent connectivity

- Sessions over HTTP

## See also

[Using Bindings to Configure Services and Clients](../../../../docs/framework/wcf/using-bindings-to-configure-services-and-clients.md)   
[WS Reliable Session](../../../../docs/framework/wcf/samples/ws-reliable-session.md)
