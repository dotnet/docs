---
title: TCP in .NET
description: Learn how the TcpClient and TcpListener classes handle TCP communication in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/19/2022
helpviewer_keywords: 
  - "protocols, TCP"
  - "network resources, TCP"
  - "sending data, TCP"
  - "TCP"
  - "TcpClient class, about TcpClient class"
  - "application protocols, TCP"
  - "receiving data, TCP"
  - "TcpListener class, about TcpListener class"
  - "Socket class, about Socket class"
  - "data requests, TCP"
  - "requesting data from Internet, TCP"
  - "Internet, TCP"
---

# TCP in .NET

To use the Transmission Control Protocol (TCP) services in .NET, use the <xref:System.Net.Sockets.TcpClient> and <xref:System.Net.Sockets.TcpListener> classes. These protocol classes are built on top of the <xref:System.Net.Sockets.Socket?displayProperty=nameWithType> class and take care of the details of transferring data.

The protocol classes use the underlying `Socket` class to provide simple access to network services without the overhead of maintaining state information or knowing the details of setting up protocol-specific sockets. To use asynchronous `Socket` methods, you can use the asynchronous methods supplied by the <xref:System.Net.Sockets.NetworkStream> class. To access features of the `Socket` class not exposed by the protocol classes, you must use the `Socket` class.

`TcpClient` and `TcpListener` represent the network using the `NetworkStream` class. You use the <xref:System.Net.Sockets.TcpClient.GetStream%2A> method to return the network stream, and then call the stream's <xref:System.Net.Sockets.NetworkStream.ReadAsync%2A?displayProperty=nameWithType> and <xref:System.Net.Sockets.NetworkStream.WriteAsync%2A?displayProperty=nameWithType> methods. The `NetworkStream` does not own the protocol classes' underlying socket, so closing it does not affect the socket.

## See also

- [Networking in .NET](../overview.md)
