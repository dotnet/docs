---
title: "TCP-UDP"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "protocols, TCP/UDP"
  - "network resources, TCP/UDP"
  - "sending data, TCP/UDP"
  - "TCP/UDP"
  - "TcpClient class, about TcpClient class"
  - "application protocols, TCP/UDP"
  - "receiving data, TCP/UDP"
  - "TcpListener class, about TcpListener class"
  - "Socket class, about Socket class"
  - "UDP"
  - "data requests, TCP/UDP"
  - "requesting data from Internet, TCP/UDP"
  - "Internet, TCP/UDP"
ms.assetid: df29b4b0-49e8-4923-82b9-13150dfc40f5
caps.latest.revision: 8
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# TCP-UDP
Applications can use Transmission Control Protocol (TCP) and User Datagram Protocol (UDP) services with the <xref:System.Net.Sockets.TcpClient>, <xref:System.Net.Sockets.TcpListener>, and <xref:System.Net.Sockets.UdpClient> classes. These protocol classes are built on top of the <xref:System.Net.Sockets.Socket?displayProperty=nameWithType> class and take care of the details of transferring data.  
  
 The protocol classes use the synchronous methods of the **Socket** class to provide simple and straightforward access to network services without the overhead of maintaining state information or knowing the details of setting up protocol-specific sockets. To use asynchronous **Socket** methods, you can use the asynchronous methods supplied by the <xref:System.Net.Sockets.NetworkStream> class. To access features of the **Socket** class not exposed by the protocol classes, you must use the **Socket** class.  
  
 **TcpClient** and **TcpListener** represent the network using the **NetworkStream** class. You use the <xref:System.Net.Sockets.TcpClient.GetStream%2A> method to return the network stream, and then call the stream's <xref:System.Net.Sockets.NetworkStream.Read%2A> and <xref:System.Net.Sockets.NetworkStream.Write%2A> methods. The **NetworkStream** does not own the protocol classes' underlying socket, so closing it does not affect the socket.  
  
 The **UdpClient** class uses an array of bytes to hold the UDP datagram. You use the <xref:System.Net.Sockets.UdpClient.Send%2A> method to send the data to the network and the <xref:System.Net.Sockets.UdpClient.Receive%2A> method to receive an incoming datagram.  
  
## See Also  
 [Using TCP Services](../../../docs/framework/network-programming/using-tcp-services.md)  
 [Using UDP Services](../../../docs/framework/network-programming/using-udp-services.md)  
 [Using Streams on the Network](../../../docs/framework/network-programming/using-streams-on-the-network.md)  
 [Using an Asynchronous Server Socket](../../../docs/framework/network-programming/using-an-asynchronous-server-socket.md)  
 [Using an Asynchronous Client Socket](../../../docs/framework/network-programming/using-an-asynchronous-client-socket.md)  
 [Using Application Protocols](../../../docs/framework/network-programming/using-application-protocols.md)
