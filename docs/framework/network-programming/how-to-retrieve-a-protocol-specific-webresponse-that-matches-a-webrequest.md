---
title: "How to: Retrieve a Protocol-Specific WebResponse that Matches a WebRequest"
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
ms.assetid: d8c90785-f16b-42a5-8439-ed2f731b2ba8
caps.latest.revision: 8
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# How to: Retrieve a Protocol-Specific WebResponse that Matches a WebRequest
This example shows how to retrieve a protocol-specific WebResponse that matches a WebRequest.  
  
## Example  
  
```csharp  
WebRequest req = WebRequest.Create("http://www.contoso.com/");  
WebResponse resp = req.GetResponse();  
```  
  
```vb  
Dim req As WebRequest = WebRequest.Create("http://www.contoso.com")  
Dim resp As WebResponse = req.GetResponse()  
```  
  
## Compiling the Code  
 This example requires:  
  
-   References to the **System.Net** namespace.  
  
## See Also  
 [Requesting Data](../../../docs/framework/network-programming/requesting-data.md)
