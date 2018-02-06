---
title: "Using Streams on the Network"
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
  - "requesting data from Internet, streams"
  - "Networking"
  - "response to Internet request, streams"
  - "network resources, stream capabilities"
  - "receiving data, stream capabilities"
  - "Network Resources"
  - "sending data, stream capabilities"
  - "downloading Internet resources, streams"
  - "streams, capabilities"
  - "Internet, streams"
  - "streams"
ms.assetid: 02b05fba-7235-45ce-94e5-060436ee0875
caps.latest.revision: 10
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Using Streams on the Network
Network resources are represented in the .NET Framework as streams. By treating streams generically, the .NET Framework offers the following capabilities:  
  
-   A common way to send and receive Web data. Whatever the actual contents of the file — HTML, XML, or anything else — your application will use <xref:System.IO.Stream.Write%2A?displayProperty=nameWithType> and <xref:System.IO.Stream.Read%2A?displayProperty=nameWithType> to send and receive data.  
  
-   Compatibility with streams across the .NET Framework. Streams are used throughout the .NET Framework, which has a rich infrastructure for handling them. For example, you can modify an application that reads XML data from a <xref:System.IO.FileStream> to read data from a <xref:System.Net.Sockets.NetworkStream> instead by changing only the few lines of code that initialize the stream. The major differences between the **NetworkStream** class and other streams are that **NetworkStream** is not seekable, the <xref:System.Net.Sockets.NetworkStream.CanSeek%2A> property always returns **false**, and the <xref:System.Net.Sockets.NetworkStream.Seek%2A> and <xref:System.Net.Sockets.NetworkStream.Position%2A> methods throw a <xref:System.NotSupportedException>.  
  
-   Processing of data as it arrives. Streams provide access to data as it arrives from the network, rather than forcing your application to wait for an entire data set to be downloaded.  
  
 The <xref:System.Net.Sockets> namespace contains a **NetworkStream** class that implements the <xref:System.IO.Stream> class specifically for use with network resources. Classes in the <xref:System.Net.Sockets> namespace use the **NetworkStream** class to represent streams.  
  
 To send data to the network using the returned stream, call <xref:System.Net.WebRequest.GetRequestStream%2A> on your <xref:System.Net.WebRequest>. The **WebRequest** will send request headers to the server; then you can send data to the network resource by calling the <xref:System.IO.Stream.BeginWrite%2A>, <xref:System.IO.Stream.EndWrite%2A>, or <xref:System.IO.Stream.Write%2A> method on the returned stream. Some protocols, such as HTTP, may require you to set protocol-specific properties before sending data. The following code example shows how to set HTTP-specific properties for sending data. It assumes that the variable `sendData` contains the data to send and that the variable `sendLength` is the number of bytes of data to send.  
  
```csharp  
HttpWebRequest request =   
   (HttpWebRequest) WebRequest.Create("http://www.contoso.com/");  
request.Method = "POST";  
request.ContentLength = sendLength;  
try  
{  
   Stream sendStream = request.GetRequestStream();  
   sendStream.Write(sendData,0,sendLength);  
   sendStream.Close();  
}  
catch  
{  
   // Handle errors . . .  
}  
```  
  
```vb  
Dim request As HttpWebRequest = _  
   CType(WebRequest.Create("http://www.contoso.com/"), HttpWebRequest)  
request.Method = "POST"  
request.ContentLength = sendLength  
Try  
   Dim sendStream As Stream = request.GetRequestStream()  
   sendStream.Write(sendData, 0, sendLength)  
   sendStream.Close()  
Catch  
   ' Handle errors . . .  
End Try  
```  
  
 To receive data from the network, call <xref:System.Net.WebResponse.GetResponseStream%2A> on your <xref:System.Net.WebResponse>. You can then read data from the network resource by calling the <xref:System.IO.Stream.BeginRead%2A>, <xref:System.IO.Stream.EndRead%2A>, or <xref:System.IO.Stream.Read%2A> method on the returned stream.  
  
 When using streams from network resources, keep in mind the following points:  
  
-   The **CanSeek** property always returns **false** since the **NetworkStream** class cannot change position in the stream. The **Seek** and **Position** methods throw a **NotSupportedException**.  
  
-   When you use **WebRequest** and **WebResponse**, stream instances created by calling **GetResponseStream** are read-only and stream instances created by calling **GetRequestStream** are write-only.  
  
-   Use the <xref:System.IO.StreamReader> class to make encoding easier. The following code example uses a **StreamReader** to read an ASCII-encoded stream from a **WebResponse** (the example does not show creating the request).  
  
-   The call to **GetResponse** can block if network resources are not available. You should consider using an asynchronous request with the <xref:System.Net.WebRequest.BeginGetResponse%2A> and <xref:System.Net.WebRequest.EndGetResponse%2A> methods.  
  
-   The call to **GetRequestStream** can block while the connection to the server is created. You should consider using an asynchronous request for the stream with the <xref:System.Net.WebRequest.BeginGetRequestStream%2A> and <xref:System.Net.WebRequest.EndGetRequestStream%2A> methods.  
  
```csharp  
// Create a response object.  
WebResponse response = request.GetResponse();  
// Get a readable stream from the server.  
StreamReader sr =   
   new StreamReader(response.GetResponseStream(), Encoding.ASCII);  
// Use the stream. Remember when you are through with the stream to close it.  
sr.Close();  
```  
  
```vb  
' Create a response object.  
Dim response As WebResponse = request.GetResponse()  
' Get a readable stream from the server.  
Dim sr As _   
   New StreamReader(response.GetResponseStream(), Encoding.ASCII)  
' Use the stream. Remember when you are through with the stream to close it.  
sr.Close()  
```  
  
## See Also  
 [How to: Request Data Using the WebRequest Class](../../../docs/framework/network-programming/how-to-request-data-using-the-webrequest-class.md)  
 [Requesting Data](../../../docs/framework/network-programming/requesting-data.md)
