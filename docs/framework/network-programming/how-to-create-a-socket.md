---
title: "How to: Create a Socket"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "application protocols, sockets"
  - "Networking"
  - "sending data, sockets"
  - "data requests, sockets"
  - "requesting data from Internet, sockets"
  - "Socket class, creating sockets"
  - "Network Resources"
  - "receiving data, sockets"
  - "protocols, sockets"
  - "Internet, sockets"
  - "sockets, creating"
ms.assetid: c64a049c-5981-43bc-a2dc-1851473589c7
caps.latest.revision: 7
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# How to: Create a Socket
Before you can use a socket to communicate with remote devices, the socket must be initialized with protocol and network address information. The constructor for the <xref:System.Net.Sockets.Socket> class has parameters that specify the address family, socket type, and protocol type that the socket uses to make connections.  
  
## Example  
 The following example creates a Socket that can be used to communicate on a TCP/IP-based network, such as the Internet.  
  
```csharp  
Socket s = new Socket(AddressFamily.InterNetwork,   
   SocketType.Stream, ProtocolType.Tcp);  
```  
  
```vb  
Dim s as New Socket(AddressFamily.InterNetwork, _  
   SocketType.Stream, ProtocolType.Tcp)  
```  
  
 To use UDP instead of TCP, change the protocol type, as in the following example:  
  
```csharp  
Socket s = new Socket(AddressFamily.InterNetwork,   
   SocketType.Dgram, ProtocolType.Udp);  
```  
  
```vb  
Dim s as New Socket(AddressFamily.InterNetwork, _  
   SocketType.Dgram, ProtocolType.Udp)  
```  
  
 The <xref:System.Net.Sockets.AddressFamily> enumeration specifies the standard address families used by the **Socket** class to resolve network addresses (for example, the **AddressFamily.InterNetwork** member specifies the IP version 4 address family).  
  
 The <xref:System.Net.Sockets.SocketType> enumeration specifies the type of socket (for example, the **SocketType.Stream** member indicates a standard socket for sending and receiving data with flow control).  
  
 The <xref:System.Net.Sockets.ProtocolType> enumeration specifies the network protocol to use when communicating on the **Socket** (for example, **ProtocolType.Tcp** indicates that the socket uses TCP; **ProtocolType.Udp** indicates that the socket uses UDP).  
  
 After a **Socket** is created, it can either initiate a connection to a remote endpoint or receive connections from remote devices.  
  
## See Also  
 [Using Client Sockets](../../../docs/framework/network-programming/using-client-sockets.md)  
 [Listening with Sockets](../../../docs/framework/network-programming/listening-with-sockets.md)
