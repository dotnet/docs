---
title: "Introducing Pluggable Protocols"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "data requests, pluggable protocols"
  - "WebRequest class, pluggable protocols"
  - "response to Internet request, pluggable protocols"
  - "URI"
  - "Windows Sockets"
  - "request/response model"
  - "sending data, pluggable protocols"
  - "pluggable protocols"
  - "WebClient class, about WebClient class"
  - "pluggable protocols, about pluggable protocols"
  - "Internet, pluggable protocols"
  - "path identifiers"
  - "Uniform Resource Identifier"
  - "application development [.NET Framework], pluggable protocols"
  - "requesting data from Internet, pluggable protocols"
  - "receiving data, pluggable protocols"
  - "protocols, pluggable"
  - "server identifiers"
  - "scheme identifiers"
ms.assetid: 4b48e22d-e4e5-48f0-be80-d549bda97415
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Introducing Pluggable Protocols
The Microsoft .NET Framework provides a layered, extensible, and managed implementation of Internet services that can be integrated quickly and easily into your applications. The Internet access classes in the <xref:System.Net> and <xref:System.Net.Sockets> namespaces can be used to implement both Web-based and Internet-based applications.  
  
## Internet Applications  
 Internet applications can be classified broadly into two kinds: client applications that request information and server applications that respond to information requests from clients. The classic Internet client-server application is the World Wide Web, where people use browsers to access documents and other data stored on Web servers worldwide.  
  
 Applications are not limited to just one of these roles; for instance, the familiar middle-tier application server responds to requests from clients by requesting data from another server, in which case it is acting as both a server and a client.  
  
 The client application makes a request by identifying the requested Internet resource and the communication protocol to use for the request and response. If necessary, the client also provides any additional data required to complete the request, such as proxy location or authentication information (user name, password, and so on). Once the request is formed, the request can be sent to the server.  
  
## Identifying Resources  
 The .NET Framework uses a Uniform Resource Identifier (URI) to identify the requested Internet resource and communication protocol. The URI consists of at least three, and possibly four, fragments: the scheme identifier, which identifies the communications protocol for the request and response; the server identifier, which consists of either a Domain Name System (DNS) host name or a TCP address that uniquely identifies the server on the Internet; the path identifier, which locates the requested information on the server; and an optional query string, which passes information from the client to the server. For example, the URI "http://www.contoso.com/whatsnew.aspx?date=today" consists of the scheme identifier "http", the server identifier "www.contoso.com", the path "/whatsnew.aspx", and the query string "?date=today".  
  
 After the server has received the request and processed the response, it returns the response to the client application. The response includes supplemental information, such as the type of the content (raw text or XML data, for example).  
  
## Requests and Responses in the .NET Framework  
 The .NET Framework uses specific classes to provide the three pieces of information required to access Internet resources through a request/response model: the <xref:System.Uri> class, which contains the URI of the Internet resource you are seeking; the <xref:System.Net.WebRequest> class, which contains a request for the resource; and the <xref:System.Net.WebResponse> class, which provides a container for the incoming response.  
  
 Client applications create `WebRequest` instances by passing the URI of the network resource to the <xref:System.Net.WebRequest.Create%2A> method. This static method creates a `WebRequest` for a specific protocol, such as HTTP. The `WebRequest` that is returned provides access to properties that control both the request to the server and access to the data stream that is sent when the request is made. The <xref:System.Net.WebRequest.GetResponse%2A> method on the `WebRequest` sends the request from the client application to the server identified in the URI. In cases in which the response might be delayed, the request can be made asynchronously using the <xref:System.Net.WebRequest.BeginGetResponse%2A> method on the **WebRequest**, and the response can be returned at a later time using the <xref:System.Net.WebRequest.EndGetResponse%2A> method.  
  
 The **GetResponse** and **EndGetResponse** methods return a **WebResponse** that provides access to the data returned by the server. Because this data is provided to the requesting application as a stream by the <xref:System.Net.WebResponse.GetResponseStream%2A> method, it can be used in an application anywhere data streams are used.  
  
 The **WebRequest** and **WebResponse** classes are the basis of pluggable protocols — an implementation of network services that enables you to develop applications that use Internet resources without worrying about the specific details of the protocol that each resource uses. Descendant classes of **WebRequest** are registered with the **WebRequest** class to manage the details of making the actual connections to Internet resources.  
  
 As an example, the <xref:System.Net.HttpWebRequest> class manages the details of connecting to an Internet resource using HTTP. By default, when the **WebRequest.Create** method encounters a URI that begins with "http:" or "https:" (the protocol identifiers for HTTP and secure HTTP), the **WebRequest** that is returned can be used as is, or it can be typecast to **HttpWebRequest** to access protocol-specific properties. In most cases, the **WebRequest** provides all the necessary information for making a request.  
  
 Any protocol that can be represented as a request/response transaction can be used in a **WebRequest**. You can derive protocol-specific classes from **WebRequest** and **WebResponse** and then register them for use by the application with the static <xref:System.Net.WebRequest.RegisterPrefix%2A?displayProperty=nameWithType> method.  
  
 When client authorization for Internet requests is required, the <xref:System.Net.WebRequest.Credentials%2A> property of the **WebRequest** supplies the necessary credentials. These credentials can be a simple name/password pair for basic HTTP or digest authentication, or a name/password/domain set for NTLM or Kerberos authentication. One set of credentials can be stored in a <xref:System.Net.NetworkCredential> instance, or multiple sets can be stored simultaneously in a <xref:System.Net.CredentialCache> instance. The **CredentialCache** uses the URI of the request and the authentication scheme that the server supports to determine which credentials to send to the server.  
  
## Simple Requests with WebClient  
 For applications that need to make simple requests for Internet resources, the <xref:System.Net.WebClient> class provides common methods for uploading data to or downloading data from an Internet server. **WebClient** relies on the **WebRequest** class to provide access to Internet resources; therefore, the **WebClient** class can use any registered pluggable protocol.  
  
 For applications that cannot use the request/response model, or for applications that need to listen on the network as well as send requests, the **System.Net.Sockets** namespace provides the <xref:System.Net.Sockets.TcpClient>, <xref:System.Net.Sockets.TcpListener>, and <xref:System.Net.Sockets.UdpClient> classes. These classes handle the details of making connections using different transport protocols and expose the network connection to the application as a stream.  
  
 Developers familiar with the Windows Sockets interface or those who need the control provided by programming at the socket level will find that the **System.Net.Sockets** classes meet their needs. The **System.Net.Sockets** classes are a transition point from managed to native code within the **System.Net** classes. In most cases, **System.Net.Sockets** classes marshal data into their Windows 32-bit counterparts, as well as handling any necessary security checks.  
  
## See Also  
 [Programming Pluggable Protocols](../../../docs/framework/network-programming/programming-pluggable-protocols.md)  
 [Network Programming in the .NET Framework](../../../docs/framework/network-programming/index.md)  
 [Network Programming Samples](../../../docs/framework/network-programming/network-programming-samples.md)  
 [Networking Samples for .NET on MSDN Code Gallery](http://code.msdn.microsoft.com/Wiki/View.aspx?ProjectName=nclsamples)
