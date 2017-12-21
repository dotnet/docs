---
title: "Deriving from WebResponse"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Deriving from WebResponse"
ms.assetid: f11d4866-a199-4087-9306-a5a4c18b13db
caps.latest.revision: 7
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Deriving from WebResponse
The <xref:System.Net.WebResponse> class is an abstract base class that provides the basic methods and properties for creating a protocol-specific response that fits the .NET Framework pluggable protocol model. Applications that use the <xref:System.Net.WebRequest> class to request data from resources receive the responses in a **WebResponse**. Protocol-specific **WebResponse** descendants must implement the abstract members of the **WebResponse** class.  
  
 The associated **WebRequest** class must create **WebResponse** descendants. For example, <xref:System.Net.HttpWebResponse> instances are created only as the result of calling <xref:System.Net.HttpWebRequest.GetResponse%2A?displayProperty=nameWithType> or <xref:System.Net.HttpWebRequest.EndGetResponse%2A?displayProperty=nameWithType>. Each **WebResponse** contains the result of a request to a resource and is not intended to be reused.  
  
## ContentLength Property  
 The <xref:System.Net.WebResponse.ContentLength%2A> property indicates the number of bytes of data that are available from the stream returned by the <xref:System.Net.WebResponse.GetResponseStream%2A> method. The **ContentLength** property does not indicate the number of bytes of header or metadata information returned by the server; it indicates only the number of bytes of data in the requested resource itself.  
  
## ContentType Property  
 The <xref:System.Net.WebResponse.ContentType%2A> property provides any special information that your protocol requires you to send to the client to identify the type of content being sent by the server. Typically this is the MIME content type of any data returned.  
  
## Headers Property  
 The <xref:System.Net.WebResponse.Headers%2A> property contains an arbitrary collection of name/value pairs of metadata associated with the response. Any metadata needed by the protocol that can be expressed as a name/value pair can be included in the **Headers** property.  
  
 You are not required to use the **Headers** property to use header metadata. Protocol-specific metadata can be exposed as properties; for example, the <xref:System.Net.HttpWebResponse.LastModified%2A?displayProperty=nameWithType> property exposes the **Last-Modified** HTTP header. When you expose header metadata as a property, you should not allow the same property to be set using the **Headers** property.  
  
## ResponseUri Property  
 The <xref:System.Net.WebResponse.ResponseUri%2A> property contains the URI of the resource that actually provided the response. For protocols that do not support redirection, **ResponseUri** will be the same as the <xref:System.Net.WebRequest.RequestUri%2A> property of the **WebRequest** that created the response. If the protocol supports redirecting the request, **ResponseUri** will contain the URI of the response.  
  
## Close Method  
 The <xref:System.Net.WebResponse.Close%2A> method closes any connections made by the request and response and cleans up resources used by the response. The **Close** method closes any stream instances used by the response, but it does not throw an exception if the response stream was previously closed by a call to the <xref:System.IO.Stream.Close%2A?displayProperty=nameWithType> method.  
  
## GetResponseStream Method  
 The <xref:System.Net.WebResponse.GetResponseStream%2A> method returns a stream containing the response from the requested resource. The response stream contains only the data returned by the resource; any header or metadata included in the response should be stripped from the response and exposed to the application through protocol-specific properties or the **Headers** property.  
  
 The stream instance returned by the **GetResponseStream** method is owned by the application and can be closed without closing the **WebResponse**. By convention, calling the **WebResponse.Close** method also closes the stream returned by **GetResponse**.  
  
## See Also  
 <xref:System.Net.WebResponse>  
 <xref:System.Net.HttpWebResponse>  
 <xref:System.Net.FileWebResponse>  
 [Programming Pluggable Protocols](../../../docs/framework/network-programming/programming-pluggable-protocols.md)  
 [Deriving from WebRequest](../../../docs/framework/network-programming/deriving-from-webrequest.md)
