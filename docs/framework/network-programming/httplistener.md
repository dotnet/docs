---
title: "HttpListener"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "HTTP"
ms.assetid: 5b89d3fb-3c9a-49e2-af1f-c34c020c68ac
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# HttpListener
The <xref:System.Net.HttpListener> class provides a programmatically controlled HTTP protocol listener. The listener is active for the lifetime of the <xref:System.Net.HttpListener> object and runs within your application.  
  
## HTTP.SYS  
 The <xref:System.Net.HttpListener> class is built on top of HTTP.sys, which is the kernel mode listener that handles all HTTP traffic for Windows. HTTP.sys provides connection management, bandwidth throttling, and Web server logging. Use the `HttpCfg.exe` tool to add SSL certificates. For more information, see the documentation on the [HttpCfg.exe](http://go.microsoft.com/fwlink/?LinkID=178284) tool in the [Server](http://go.microsoft.com/fwlink/?LinkID=178285) documentation.  
  
## See Also  
 <xref:System.Net.HttpListener>  
 <xref:System.Net.HttpWebRequest>  
 <xref:System.Net.HttpWebResponse>  
 [HTTP Server](http://go.microsoft.com/fwlink/?LinkID=178285)  
 [Security Enhancements in Internet Information](http://go.microsoft.com/fwlink/?LinkID=178286)  
 [HttpListener ASPX Host Application Sample](http://go.microsoft.com/fwlink/?LinkID=179560)  
 [HttpListener Technology Sample](http://go.microsoft.com/fwlink/?LinkID=179558)  
 [Network Programming Samples](../../../docs/framework/network-programming/network-programming-samples.md)
