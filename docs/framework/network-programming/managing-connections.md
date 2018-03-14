---
title: "Managing Connections"
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
  - "Internet, connections"
  - "HTTP, classes for connecting"
  - "requesting data from Internet, connections"
  - "sending data, connections"
  - "receiving data, connections"
  - "ServicePoint class, about ServicePoint class"
  - "response to Internet request, connections"
  - "connections [.NET Framework], classes"
  - "network resources, connections"
  - "downloading Internet resources, connections"
  - "ServicePointManager class, about ServicePointManager class"
ms.assetid: 9b3d3de7-189f-4f7d-81ae-9c29c441aaaa
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Managing Connections
Applications that use HTTP to connect to data resources can use the .NET Framework's <xref:System.Net.ServicePoint> and <xref:System.Net.ServicePointManager> classes to manage connections to the Internet and to help them achieve optimum scale and performance.  
  
 The **ServicePoint** class provides an application with an endpoint to which the application can connect to access Internet resources. Each **ServicePoint** contains information that helps optimize connections with an Internet server by sharing optimization information between connections to improve performance.  
  
 Each **ServicePoint** is identified by a Uniform Resource Identifier (URI) and is categorized according to the scheme identifier and host fragments of the URI. For example, the same **ServicePoint** instance would provide requests to the URIs http://www.contoso.com/index.htm and http://www.contoso.com/news.htm?date=today since they have the same scheme identifier (http) and host fragments (www.contoso.com). If the application already has a persistent connection to the server www.contoso.com, it uses that connection to retrieve both requests, avoiding the need to create two connections.  
  
 **ServicePointManager** is a static class that manages the creation and destruction of **ServicePoint** instances. The **ServicePointManager** creates a **ServicePoint** when the application requests an Internet resource that is not in the collection of existing **ServicePoint** instances. **ServicePoint** instances are destroyed when they have exceeded their maximum idle time or when the number of existing **ServicePoint** instances exceeds the maximum number of **ServicePoint** instances for the application. You can control both the default maximum idle time and the maximum number of **ServicePoint** instances by setting the <xref:System.Net.ServicePointManager.MaxServicePointIdleTime%2A> and <xref:System.Net.ServicePointManager.MaxServicePoints%2A> properties on the **ServicePointManager**.  
  
 The number of connections between a client and server can have a dramatic impact on application throughput. By default, an application using the <xref:System.Net.HttpWebRequest> class uses a maximum of two persistent connections to a given server, but you can set the maximum number of connections on a per-application basis.  
  
> [!NOTE]
>  The HTTP/1.1 specification limits the number of connections from an application to two connections per server.  
  
 The optimum number of connections depends on the actual conditions in which the application runs. Increasing the number of connections available to the application may not affect application performance. To determine the impact of more connections, run performance tests while varying the number of connections. You can change the number of connections that an application uses by changing the static <xref:System.Net.ServicePointManager.DefaultConnectionLimit%2A> property on the **ServicePointManager** class at application initialization, as shown in the following code sample.  
  
```csharp  
// Set the maximum number of connections per server to 4.  
ServicePointManager.DefaultConnectionLimit = 4;  
```  
  
```vb  
' Set the maximum number of connections per server to 4.  
ServicePointManager.DefaultConnectionLimit = 4  
```  
  
 Changing the **ServicePointManager.DefaultConnectionLimit** property does not affect previously initialized **ServicePoint** instances. The following code demonstrates changing the connection limit on an existing **ServicePoint** for the server http://www.contoso.com to the value stored in `newLimit`.  
  
```csharp  
Uri uri = new Uri("http://www.contoso.com/");  
ServicePoint sp = ServicePointManager.FindServicePoint(uri);  
sp.ConnectionLimit = newLimit;  
```  
  
```vb  
Dim uri As New Uri("http://www.contoso.com/")  
Dim sp As ServicePoint = ServicePointManager.FindServicePoint(uri)  
sp.ConnectionLimit = newLimit  
```  
  
## See Also  
 [Connection Grouping](../../../docs/framework/network-programming/connection-grouping.md)  
 [Using Application Protocols](../../../docs/framework/network-programming/using-application-protocols.md)
