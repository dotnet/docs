---
title: Sockets in .NET
description: Learn how the Socket class functions as a cross-platform abstraction of socket networking communication in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/24/2022
helpviewer_keywords:
  - "application protocols, sockets"
  - "sending data, sockets"
  - "data requests, sockets"
  - "Windows Sockets"
  - "sockets, about sockets"
  - "Socket class, about Socket class"
  - "sockets"
  - "requesting data from Internet, sockets"
  - "network, sockets"
  - "receiving data, sockets"
  - "protocols, sockets"
  - "Internet, sockets"
ms.topic: article
---

# Sockets in .NET

The <xref:System.Net.Sockets> namespace contains a managed, cross-platform socket networking implementation. All other network-access classes in the <xref:System.Net> namespace are built on top of this implementation of sockets.

The <xref:System.Net.Sockets.Socket> class is a managed-code version of the socket services provided relying on native interoperability with Linux, macOS, or Windows. In most cases, the `Socket` class methods simply marshal data into their native counterparts and handle any necessary security checks.

The `Socket` class supports two basic modes, synchronous and asynchronous. In synchronous mode, calls to functions that perform network operations (such as <xref:System.Net.Sockets.Socket.SendAsync%2A> and <xref:System.Net.Sockets.Socket.ReceiveAsync%2A>) wait until the operation completes before returning control to the calling program. In asynchronous mode, these calls return immediately.

## See also

- [Use Sockets to send and receive data](socket-services.md)
- [Networking in .NET](../overview.md)
- <xref:System.Net.Sockets>
- <xref:System.Net.Sockets.Socket>
