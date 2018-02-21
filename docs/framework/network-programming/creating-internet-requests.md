---
title: "Creating Internet Requests"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "WebRequest class, sending and receiving data"
  - "Networking"
  - "HttpWebResponse class, sending and receiving data"
  - "requesting data from Internet, creating requests"
  - "Network Resources"
  - "Internet, requesting data"
  - "data requests, creating requests"
ms.assetid: faab683e-3f1e-4eee-b5e9-59f7245033d5
caps.latest.revision: 8
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# Creating Internet Requests
Applications create <xref:System.Net.WebRequest> instances through the <xref:System.Net.WebRequest.Create%2A?displayProperty=nameWithType> method. This is a static method that creates a class derived from **WebRequest** based on the URI scheme passed to it.  
  
## Web, File and FTP Requests  
 The .NET Framework provides the <xref:System.Net.HttpWebRequest> class, which is derived from **WebRequest**, to handle HTTP and HTTPS requests. In most cases, the **WebRequest** class provides all the properties you need to make a request; however, if necessary, you can cast **WebRequest** objects created by the **WebRequest.Create** method to the **HttpWebRequest** type to access the HTTP-specific properties of the request. Similarly, the **HttpWebResponse** object handles the responses from HTTP and HTTPS requests. To access the HTTP-specific properties of the **HttpWebResponse** object, you need to cast **WebResponse** objects to the **HttpWebResponse** type.  
  
 The .NET Framework also provides the <xref:System.Net.FileWebRequest> and <xref:System.Net.FileWebResponse> classes to handle requests for resources that use the "file:" URI scheme. Likewise, the <xref:System.Net.FtpWebRequest> and <xref:System.Net.FtpWebResponse> classes are provided to handle requests for resources that use the "ftp:" scheme. If your request is for a resource that uses any of these schemes, you can use the **WebRequest.Create** method to obtain an object with which to make your request.  
  
 To handle requests that use other application-level protocols, you need to implement protocol-specific classes derived from **WebRequest** and **WebResponse**. For more information, see [Programming Pluggable Protocols](../../../docs/framework/network-programming/programming-pluggable-protocols.md).  
  
## See Also  
 [How to: Request Data Using the WebRequest Class](../../../docs/framework/network-programming/how-to-request-data-using-the-webrequest-class.md)  
 [Requesting Data](../../../docs/framework/network-programming/requesting-data.md)
