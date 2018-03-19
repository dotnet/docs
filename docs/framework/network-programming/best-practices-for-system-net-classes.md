---
title: "Best Practices for System.Net Classes"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "sending data, best practices"
  - "requesting data from Internet, best practices"
  - "WebRequest class, best practices"
  - "data requests, best practices"
  - "WebResponse class, best practices"
  - "best practices, data requests"
  - "receiving data, best practices"
ms.assetid: 716decc6-5952-47b7-9c5a-ba6fc5698684
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Best Practices for System.Net Classes
The following recommendations will help you use the classes contained in <xref:System.Net> to their best advantage:  
  
-   For Transport Layer Security (TLS) best practices, see [Transport Layer Security (TLS) best practices with .NET Framework](tls.md).

-   Use <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> whenever possible instead of type casting to descendant classes. Applications that use **WebRequest** and **WebResponse** can take advantage of new Internet protocols without needing extensive code changes.  
  
-   When writing ASP.NET applications that run on a server using the **System.Net** classes, it is often better, from a performance standpoint, to use the asynchronous methods for <xref:System.Net.WebRequest.GetResponse%2A> and <xref:System.Net.WebResponse.GetResponseStream%2A>.  
  
-   The number of connections opened to an Internet resource can have a significant impact on network performance and throughput. **System.Net** uses two connections per application per host by default. Setting the <xref:System.Net.ServicePoint.ConnectionLimit%2A> property in the <xref:System.Net.ServicePoint> for your application can increase this number for a particular host. Setting the <xref:System.Net.ServicePointManager.DefaultPersistentConnectionLimit?displayProperty=nameWithType> property can increase this default for all hosts.  
  
-   When writing socket-level protocols, try to use <xref:System.Net.Sockets.TcpClient> or <xref:System.Net.Sockets.UdpClient> whenever possible instead of writing directly to a <xref:System.Net.Sockets.Socket>. These two client classes encapsulate the creation of TCP and UDP sockets without requiring you to handle the details of the connection.  
  
-   When accessing sites that require credentials, use the <xref:System.Net.CredentialCache> class to create a cache of credentials rather than supplying them with every request. The **CredentialCache** class searches the cache to find the appropriate credential to present with a request, relieving you of the responsibility of creating and presenting credentials based on the URL.  
  
## See Also  
 [Network Programming in the .NET Framework](../../../docs/framework/network-programming/index.md)
