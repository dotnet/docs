---
title: "FTP"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "FTP"
ms.assetid: 9b43f8b4-89d7-46a7-89fc-71aca916dd32
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# FTP
The .NET Framework provides comprehensive support for the FTP protocol with the <xref:System.Net.FtpWebRequest> and <xref:System.Net.FtpWebResponse> classes. These classes are derived from <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse>. In most cases, the <xref:System.Net.WebRequest> and <xref:System.Net.WebResponse> classes provide all that is necessary to make the request, but if you need access to the FTP-specific features exposed as properties, you can typecast these classes to <xref:System.Net.FtpWebRequest> or <xref:System.Net.FtpWebResponse>.  
  
## Examples  
 For more information, see the following topics: [How to: Download Files with FTP](../../../docs/framework/network-programming/how-to-download-files-with-ftp.md), [How to: Upload Files with FTP](../../../docs/framework/network-programming/how-to-upload-files-with-ftp.md), and [How to: List Directory Contents with FTP](../../../docs/framework/network-programming/how-to-list-directory-contents-with-ftp.md).  
  
## FTP and proxies  
 If a proxy (specified by the <xref:System.Net.FtpWebRequest.Proxy%2A> property) is an HTTP proxy, then only the <xref:System.Net.WebRequestMethods.Ftp.DownloadFile>, <xref:System.Net.WebRequestMethods.Ftp.ListDirectory>, and <xref:System.Net.WebRequestMethods.Ftp.ListDirectoryDetails> commands are supported.  
  
## See Also  
 [Accessing the Internet Through a Proxy](../../../docs/framework/network-programming/accessing-the-internet-through-a-proxy.md)  
 [Network Programming Samples](../../../docs/framework/network-programming/network-programming-samples.md)  
 [FTP Client Technology Sample](http://go.microsoft.com/fwlink/?LinkID=179557)  
 [FTP Explorer Technology Sample](http://go.microsoft.com/fwlink/?LinkID=179569)  
 [Using Application Protocols](../../../docs/framework/network-programming/using-application-protocols.md)
