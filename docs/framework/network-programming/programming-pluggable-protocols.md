---
title: "Programming Pluggable Protocols"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "downloading Internet resources, pluggable protocols"
  - "WebRequest class, pluggable protocols"
  - "response to Internet request, pluggable protocols"
  - "WebResponse class, pluggable protocols"
  - "sending data, pluggable protocols"
  - "network resources, pluggable protocols"
  - "Internet, pluggable protocols"
  - "programming pluggable protocols"
  - "pluggable protocols, programming"
  - "requesting data from Internet, pluggable protocols"
  - "receiving data, pluggable protocols"
  - "protocols, pluggable"
ms.assetid: 66ef8456-7576-4e97-8956-959b216373db
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Programming Pluggable Protocols
The abstract <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes provide the base for pluggable protocols. By deriving protocol-specific classes from <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse>, an application can request data from an Internet resource and read the response without specifying the protocol being used.  
  
 Before you can create a protocol-specific <xref:System.Net.WebRequest>, you must register its Create method. Use the static <xref:System.Net.WebRequest.RegisterPrefix%28System.String%2CSystem.Net.IWebRequestCreate%29> method of <xref:System.Net.WebRequest> to register a <xref:System.Net.WebRequest> descendant to handle a set of requests to a particular Internet scheme, to a scheme and server, or to a scheme, server, and path.  
  
 In most cases you will be able to send and receive data using the methods and properties of the <xref:System.Net.WebRequest> class. However, if you need to access protocol-specific properties, you can typecast a <xref:System.Net.WebRequest> to a specific derived-class instance.  
  
 To take advantage of pluggable protocols, your <xref:System.Net.WebRequest> descendants must provide a default request-and-response transaction that does not require protocol-specific properties to be set. For example, the <xref:System.Net.HttpWebRequest> class, which implements the <xref:System.Net.WebRequest> class for HTTP, provides a `GET` request by default and returns an <xref:System.Net.HttpWebResponse> that contains the stream returned from the Web server.  
  
## See Also  
 [Deriving from WebRequest](../../../docs/framework/network-programming/deriving-from-webrequest.md)  
 [Deriving from WebResponse](../../../docs/framework/network-programming/deriving-from-webresponse.md)  
 [Network Programming in the .NET Framework](../../../docs/framework/network-programming/index.md)  
 [How to: Typecast a WebRequest to Access Protocol Specific Properties](../../../docs/framework/network-programming/how-to-typecast-a-webrequest-to-access-protocol-specific-properties.md)
