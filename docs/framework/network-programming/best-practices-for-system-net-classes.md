---
title: "Best Practices for System.Net Classes"
description: Follow these recommendations to use the classes contained in System.Net to their best advantage in .NET Framework programming.
ms.date: 07/21/2022
helpviewer_keywords: 
  - "sending data, best practices"
  - "requesting data from internet, best practices"
  - "WebRequest class, best practices"
  - "data requests, best practices"
  - "WebResponse class, best practices"
  - "best practices, data requests"
  - "receiving data, best practices"
ms.assetid: 716decc6-5952-47b7-9c5a-ba6fc5698684
---
# Best practices for System.Net classes

The following recommendations will help you use the classes contained in <xref:System.Net> to their best advantage:  
  
- For Transport Layer Security (TLS) best practices, see [Transport Layer Security (TLS) best practices with .NET Framework](tls.md).

- Use <xref:System.Net.Http.HttpClient> to send HTTP requests instead of <xref:System.Net.WebRequest>, which was obsoleted in .NET 6. In .NET Framework, create a new `HttpClient` instance each time you need to send a request. (The guidance for .NET 5+/.NET Core is more nuanced. For more information, see [Guidelines for using HttpClient](../../fundamentals/networking/http/httpclient-guidelines.md).)
  
- When writing ASP.NET applications that run on a server using the `System.Net` classes, it's often better, from a performance standpoint, to use the asynchronous method <xref:System.Net.Http.HttpClient.SendAsync%2A> instead of <xref:System.Net.Http.HttpClient.Send%2A>.
  
- The number of connections opened to an internet resource can have a significant impact on network performance and throughput. **System.Net** uses two connections per application per host by default. Setting the <xref:System.Net.ServicePoint.ConnectionLimit%2A> property in the <xref:System.Net.ServicePoint> for your application can increase this number for a particular host. Setting the <xref:System.Net.ServicePointManager.DefaultPersistentConnectionLimit?displayProperty=nameWithType> property can increase this default for all hosts.  
  
- When writing socket-level protocols, try to use <xref:System.Net.Sockets.TcpClient> or <xref:System.Net.Sockets.UdpClient> whenever possible instead of writing directly to a <xref:System.Net.Sockets.Socket>. These two client classes encapsulate the creation of TCP and UDP sockets without requiring you to handle the details of the connection.  
  
- When accessing sites that require credentials, use the <xref:System.Net.CredentialCache> class to create a cache of credentials rather than supplying them with every request. The **CredentialCache** class searches the cache to find the appropriate credential to present with a request, relieving you of the responsibility of creating and presenting credentials based on the URL.  
  
## See also

- [Network programming in .NET](../../fundamentals/networking/overview.md)
