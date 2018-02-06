---
title: "How to: Enable a WebRequest to Use a Proxy to Communicate With the Internet"
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
ms.assetid: 63c0ef2c-44b5-4c54-9804-ba0b9b001ac7
caps.latest.revision: 9
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# How to: Enable a WebRequest to Use a Proxy to Communicate With the Internet
This example creates a global proxy instance that will enable any <xref:System.Net.WebRequest> to use a proxy to communicate with the Internet. The example assumes that the proxy server is named `webproxy` and that it communicates on port 80, the standard HTTP port.  
  
## Example  
  
```csharp  
WebProxy proxyObject = new WebProxy("http://webproxy:80/");  
GlobalProxySelection.Select = proxyObject;  
```  
  
```vb  
Dim proxyObject As WebProxy = New WebProxy("http://webproxy:80/")  
GlobalProxySelection.Select = proxyObject  
```  
  
## Compiling the Code  
 This example requires:  
  
-   References to the **System.Net** namespace.  
  
## See Also  
 [Using Application Protocols](../../../docs/framework/network-programming/using-application-protocols.md)  
 [Accessing the Internet Through a Proxy](../../../docs/framework/network-programming/accessing-the-internet-through-a-proxy.md)
