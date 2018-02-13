---
title: "Deriving from WebRequest"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WebRequest class, pluggable protocols"
  - "protocol-specific request handler"
  - "sending data, pluggable protocols"
  - "pluggable protocols, class criteria"
  - "Internet, pluggable protocols"
  - "receiving data, pluggable protocols"
  - "protocols, pluggable"
ms.assetid: 9810c177-973e-43d7-823c-14960bd625ea
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Deriving from WebRequest
The <xref:System.Net.WebRequest> class is an abstract base class that provides the basic methods and properties for creating a protocol-specific request handler that fits the .NET Framework pluggable protocol model. Applications that use the **WebRequest** class can request data using any supported protocol without needing to specify the protocol used.  
  
 Two criteria must be met in order for a protocol-specific class to be used as a pluggable protocol: The class must implement the <xref:System.Net.IWebRequestCreate> interface, and it must register with the <xref:System.Net.WebRequest.RegisterPrefix%2A?displayProperty=nameWithType> method. The class must override all the abstract methods and properties of **WebRequest** to provide the pluggable interface.  
  
 **WebRequest** instances are intended for one-time use; if you want to make another request, create a new **WebRequest**. **WebRequest** supports the <xref:System.Runtime.Serialization.ISerializable> interface to enable developers to serialize a template **WebRequest** and then reconstruct the template for additional requests.  
  
## IWebRequest Create Method  
 The <xref:System.Net.IWebRequestCreate.Create%2A> method is responsible for initializing a new instance of the protocol-specific class. When a new **WebRequest** is created, the <xref:System.Net.WebRequest.Create%2A?displayProperty=nameWithType> method matches the requested URI with the URI prefixes registered with the **RegisterPrefix** method. The **Create** method of the proper protocol-specific descendant must return an initialized instance of the descendant capable of performing a standard request/response transaction for the protocol without needing any protocol-specific fields modified.  
  
## ConnectionGroupName Property  
 The <xref:System.Net.WebRequest.ConnectionGroupName%2A> property is used to name a group of connections to a resource so that multiple requests can be made over a single connection. To implement connection-sharing, you must use a protocol-specific method of pooling and assigning connections. For example, the provided <xref:System.Net.ServicePointManager> class implements connection sharing for the <xref:System.Net.HttpWebRequest> class. The **ServicePointManager** class creates a <xref:System.Net.ServicePoint> that provides a connection to a specific server for each connection group.  
  
## ContentLength Property  
 The <xref:System.Net.WebRequest.ContentLength%2A> property specifies the number of bytes of data that will be sent to the server when uploading data.  
  
 Typically the <xref:System.Net.WebRequest.Method%2A> property must be set to indicate that an upload is taking place when the **ContentLength** property is set to a value greater than zero.  
  
## ContentType Property  
 The <xref:System.Net.WebRequest.ContentType%2A> property provides any special information that your protocol requires you to send to the server to identify the type of content that you are sending. Typically this is the MIME content type of any data uploaded.  
  
## Credentials Property  
 The <xref:System.Net.WebRequest.Credentials%2A> property contains information needed to authenticate the request with the server. You must implement the details of the authentication process for your protocol. The <xref:System.Net.AuthenticationManager> class is responsible for authenticating requests and providing an authentication token. The class that provides the credentials used by your protocol must implement the <xref:System.Net.ICredentials> interface.  
  
## Headers Property  
 The <xref:System.Net.WebRequest.Headers%2A> property contains an arbitrary collection of name/value pairs of metadata associated with the request. Any metadata needed by the protocol that can be expressed as a name/value pair can be included in the **Headers** property. Typically this information must be set before calling the <xref:System.Net.WebRequest.GetRequestStream%2A> or <xref:System.Net.WebRequest.GetResponse%2A> methods; once the request has been made, the metadata is considered read-only.  
  
 You are not required to use the **Headers** property to use header metadata. Protocol-specific metadata can be exposed as properties; for example, the <xref:System.Net.HttpWebRequest.UserAgent%2A?displayProperty=nameWithType> property exposes the **User-Agent** HTTP header. When you expose header metadata as a property, you should not allow the same property to be set using the **Headers** property.  
  
## Method Property  
 The <xref:System.Net.WebRequest.Method%2A> property contains the verb or action that the request is asking the server to perform. The default for the **Method** property must enable a standard request/response action without requiring any protocol-specific properties to be set. For example, the <xref:System.Net.HttpWebResponse.Method%2A> method defaults to GET, which requests a resource from a Web server and returns the response.  
  
 Typically the **ContentLength** property must be set to a value greater than zero when the **Method** property is set to a verb or action that indicates that an upload is taking place.  
  
## PreAuthenticate Property  
 Applications set the <xref:System.Net.WebRequest.PreAuthenticate%2A> property to indicate that authentication information should be sent with the initial request rather than waiting for an authentication challenge. The **PreAuthenticate** property is only meaningful if the protocol supports authentication credentials sent with the initial request.  
  
## Proxy Property  
 The <xref:System.Net.WebRequest.Proxy%2A> property contains an <xref:System.Net.IWebProxy> interface that is used to access the requested resource. The **Proxy** property is meaningful only if your protocol supports proxied requests. You must set the default proxy if one is required by your protocol.  
  
 In some environments, such as behind a corporate firewall, your protocol might be required to use a proxy. In that case, you must implement the **IWebProxy** interface to create a proxy class that will work for your protocol.  
  
## RequestUri Property  
 The <xref:System.Net.WebRequest.RequestUri%2A> property contains the URI that was passed to the **WebRequest.Create** method. It is read-only and cannot be changed once the **WebRequest** has been created. If your protocol supports redirection, the response can come from a resource identified by a different URI. If you need to provide access to the URI that responded, you must provide an additional property containing that URI.  
  
## Timeout Property  
 The <xref:System.Net.WebRequest.Timeout%2A> property contains the length of time, in milliseconds, to wait before the request times out and throws an exception. **Timeout** applies only to synchronous requests made with the <xref:System.Net.WebRequest.GetResponse%2A> method; asynchronous requests must use the <xref:System.Net.WebRequest.Abort%2A> method to cancel a pending request.  
  
 Setting the **Timeout** property is meaningful only if the protocol-specific class implements a time-out process.  
  
## Abort Method  
 The <xref:System.Net.WebRequest.Abort%2A> method cancels a pending asynchronous request to a server. After the request has been canceled, calling **GetResponse**, **BeginGetResponse**, **EndGetResponse**, **GetRequestStream**, **BeginGetRequestStream**, or **EndGetRequestStream** will throw a <xref:System.Net.WebException> with the <xref:System.Net.WebException.Status%2A> property set to <xref:System.Net.WebExceptionStatus>.  
  
## BeginGetRequestStream and EndGetRequestStream Methods  
 The <xref:System.Net.WebRequest.BeginGetRequestStream%2A> method starts an asynchronous request for the stream that is used to upload data to the server. The <xref:System.Net.WebRequest.EndGetRequestStream%2A> method completes the asynchronous request and returns the requested stream. These methods implement the **GetRequestStream** method using the standard .NET Framework asynchronous pattern.  
  
## BeginGetResponse and EndGetResponse Methods  
 The <xref:System.Net.WebRequest.BeginGetResponse%2A> method starts an asynchronous request to a server. The <xref:System.Net.WebRequest.EndGetResponse%2A> method completes the asynchronous request and returns the requested response. These methods implement the **GetResponse** method using the standard .NET Framework asynchronous pattern.  
  
## GetRequestStream Method  
 The <xref:System.Net.WebRequest.GetRequestStream%2A> method returns a stream that is used to write data to the requested server. The stream returned should be a write-only stream that does not seek; it is intended as a one-way stream of data that is written to the server. The stream returns false for the <xref:System.IO.Stream.CanRead%2A> and <xref:System.IO.Stream.CanSeek%2A> properties and true for the <xref:System.IO.Stream.CanWrite%2A> property.  
  
 The **GetRequestStream** method typically opens a connection to the server and, before returning the stream, sends header information that indicates that data is being sent to the server. Because **GetRequestStream** begins the request, setting any **Header** properties or the **ContentLength** property is typically not allowed after calling **GetRequestStream**.  
  
## GetResponse Method  
 The <xref:System.Net.WebRequest.GetResponse%2A> method returns a protocol-specific descendant of the <xref:System.Net.WebResponse> class that represents the response from the server. Unless the request has already been initiated by the **GetRequestStream** method, the **GetResponse** method creates a connection to the resource identified by **RequestUri**, sends header information indicating the type of request being made, and then receives the response from the resource.  
  
 Once the **GetResponse** method is called, all properties should be considered read-only. **WebRequest** instances are intended for one-time use; if you want to make another request, you should create a new **WebRequest**.  
  
 The **GetResponse** method is responsible for creating an appropriate **WebResponse** descendant to contain the incoming response.  
  
## See Also  
 <xref:System.Net.WebRequest>  
 <xref:System.Net.HttpWebRequest>  
 <xref:System.Net.FileWebRequest>  
 [Programming Pluggable Protocols](../../../docs/framework/network-programming/programming-pluggable-protocols.md)  
 [Deriving from WebResponse](../../../docs/framework/network-programming/deriving-from-webresponse.md)
