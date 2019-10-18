---
title: "HttpListener"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "HTTP"
ms.assetid: 5b89d3fb-3c9a-49e2-af1f-c34c020c68ac
---
# HttpListener
The <xref:System.Net.HttpListener> class provides a programmatically controlled HTTP protocol listener. The listener is active for the lifetime of the <xref:System.Net.HttpListener> object and runs within your application.  
  
## HTTP.SYS  
 The <xref:System.Net.HttpListener> class is built on top of HTTP.sys, which is the kernel mode listener that handles all HTTP traffic for Windows. HTTP.sys provides connection management, bandwidth throttling, and Web server logging. Use the `HttpCfg.exe` tool to add SSL certificates. For more information, see the documentation on the [HttpCfg.exe](https://go.microsoft.com/fwlink/?LinkID=178284) tool in the [Server](https://go.microsoft.com/fwlink/?LinkID=178285) documentation.  
  
## See also

- <xref:System.Net.HttpListener>
- <xref:System.Net.HttpWebRequest>
- <xref:System.Net.HttpWebResponse>
- [HTTP Server](https://go.microsoft.com/fwlink/?LinkID=178285)
- [Security Enhancements in Internet Information](https://go.microsoft.com/fwlink/?LinkID=178286)
- [HttpListener ASPX Host Application Sample](https://go.microsoft.com/fwlink/?LinkID=179560)
- [HttpListener Technology Sample](https://go.microsoft.com/fwlink/?LinkID=179558)
- [Network Programming Samples](network-programming-samples.md)
