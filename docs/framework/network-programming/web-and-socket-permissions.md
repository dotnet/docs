---
title: "Web and Socket Permissions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Networking"
  - "positions [.NET Framework], accepting"
  - "sockets, permissions"
  - "network, permissions"
  - "Internet, permissions"
  - "Network Resources"
  - "SocketPermission class, about SocketPermission class"
  - "positions [.NET Framework], connecting"
  - "WebPermission class, about WebPermission class"
  - "permissions [.NET Framework], sockets"
  - "security [.NET Framework], Internet"
  - "positions [.NET Framework], granting"
ms.assetid: d51ad8cb-03ae-4a51-bfcd-cfcf6b98afa9
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Web and Socket Permissions
Internet security for applications using the <xref:System.Net> namespace is provided by the <xref:System.Net.WebPermission> and <xref:System.Net.SocketPermission> classes. The **WebPermission** class controls an application's right to request data from a URI or to serve a URI to the Internet. The **SocketPermission** class controls an application's right to use a <xref:System.Net.Sockets.Socket> to accept data on a local port or to contact remote devices using a transport protocol at another address, based on the host, port number, and transport protocol of the socket.  
  
 Which permission class you use depends on your application type. Applications that use <xref:System.Net.WebRequest> and its descendants should use the **WebPermission** class to manage permissions. Applications that use socket-level access should use the **SocketPermission** class to manage permissions.  
  
 **WebPermission** and **SocketPermission** define two permissions: accept and connect. Accept grants the application the right to answer an incoming connection from another party. Connect grants the application the right to initiate a connection to another party.  
  
 For **SocketPermission** instances, accept means that an application can accept incoming connections on a local transport address; connect means that an application can connect to some remote (or local) transport address.  
  
 For **WebPermission** instances, accept means that an application can export the URI controlled by the **WebPermission** to the world; connect means that an application can access that URI (whether it is remote or local).  
  
## See Also  
 [Security](../../../docs/standard/security/index.md)  
 [Security in Network Programming](../../../docs/framework/network-programming/security-in-network-programming.md)
