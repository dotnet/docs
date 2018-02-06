---
title: "Requesting Data"
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
  - "sending data"
  - "WebRequest class, sending and receiving data"
  - "requesting data from Internet, about requesting data"
  - "WebClient class, sending and receiving data"
  - "network, requesting data"
  - "receiving data"
  - "sending data, about sending data"
  - "response to Internet request, about responding to Internet requests"
  - "data requests"
  - "receiving data, about receiving data"
  - "Internet, requesting data"
ms.assetid: df6f1e1d-6f2a-45dd-8141-4a85c3dafe1d
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Requesting Data
Developing applications that run in the distributed operating environment of today's Internet requires an efficient, easy-to-use method for retrieving data from resources of all types. Pluggable protocols let you develop applications that use a single interface to retrieve data from multiple Internet protocols.  
  
## Uploading and Downloading Data from an Internet Server  
 For simple request and response transactions, the <xref:System.Net.WebClient> class provides the easiest method for uploading data to or downloading data from an Internet server. **WebClient** provides methods for uploading and downloading files, sending and receiving streams, and sending a data buffer to the server and receiving a response. **WebClient** uses the <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes to make the actual connections to the Internet resource, so any registered pluggable protocol is available for use.  
  
 Client applications that need to make more complex transactions request data from servers using the **WebRequest** class and its descendants. **WebRequest** encapsulates the details of connecting to the server, sending the request, and receiving the response. **WebRequest** is an abstract class that defines a set of properties and methods that are available to all applications that use pluggable protocols. Descendants of **WebRequest**, such as <xref:System.Net.HttpWebRequest>, implement the properties and methods defined by **WebRequest** in a way that is consistent with the underlying protocol.  
  
 The **WebRequest** class creates protocol-specific instances of **WebRequest** descendants, using the value of the URI passed to its <xref:System.Net.WebRequest.Create%2A> method to determine the specific derived-class instance to create. Applications indicate which **WebRequest** descendant should be used to handle a request by registering the descendant's constructor with the <xref:System.Net.WebRequest.RegisterPrefix%2A?displayProperty=nameWithType> method.  
  
 A request is made to the Internet resource by calling the <xref:System.Net.WebRequest.GetResponse%2A> method on the **WebRequest**. The **GetResponse** method constructs the protocol-specific request from the properties of the **WebRequest**, makes the TCP or UDP socket connection to the server, and sends the request. For requests that send data to the server, such as HTTP **Post** or FTP **Put** requests, the <xref:System.Net.WebRequest.GetRequestStream%2A?displayProperty=nameWithType> method provides a network stream in which to send the data.  
  
 The **GetResponse** method returns a protocol-specific **WebResponse** that matches the **WebRequest.**  
  
 The **WebResponse** class is also an abstract class that defines properties and methods that are available to all applications that use pluggable protocols. **WebResponse** descendants implement these properties and methods for the underlying protocol. The <xref:System.Net.HttpWebResponse> class, for example, implements the **WebResponse** class for HTTP.  
  
 The data returned by the server is presented to the application in the stream returned by the <xref:System.Net.WebResponse.GetResponseStream%2A?displayProperty=nameWithType> method. You can use this stream like any other, as shown in the following example.  
  
```csharp  
StreamReader sr =  
   new StreamReader(resp.GetResponseStream(), Encoding.ASCII);  
```  
  
```vb  
Dim sr As StreamReader  
sr = New StreamReader(resp.GetResponseStream(), Encoding.ASCII)  
```  
  
## See Also  
 [Network Programming in the .NET Framework](../../../docs/framework/network-programming/index.md)  
 [How to: Request a Web Page and Retrieve the Results as a Stream](../../../docs/framework/network-programming/how-to-request-a-web-page-and-retrieve-the-results-as-a-stream.md)  
 [How to: Retrieve a Protocol-Specific WebResponse that Matches a WebRequest](../../../docs/framework/network-programming/how-to-retrieve-a-protocol-specific-webresponse-that-matches-a-webrequest.md)
