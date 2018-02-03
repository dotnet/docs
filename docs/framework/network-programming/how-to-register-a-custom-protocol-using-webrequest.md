---
title: "How to: Register a Custom Protocol Using WebRequest"
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
ms.assetid: 98ddbdb9-66b1-4080-92ad-51f5c447fcf8
caps.latest.revision: 11
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# How to: Register a Custom Protocol Using WebRequest
This example shows how to register a protocol specific classthat is defined elsewhere. In this example, `CustomWebRequestCreator` is the user-implemented object that implements the **Create** method that returns the `CustomWebRequest` object. The code example assumes that you have written the `CustomWebRequest` code that implements the custom protocol.  
  
## Example  
  
```csharp  
WebRequest.RegisterPrefix("custom", new CustomWebRequestCreator());  
WebRequest req = WebRequest.Create("custom://customHost.contoso.com/");  
```  
  
```vb  
WebRequest.RegisterPrefix("custom", New CustomWebRequestCreator())  
Dim req As WebRequest = WebRequest.Create("custom://customHost.contoso.com/")  
```  
  
## Compiling the Code  
 This example requires:  
  
 References to the <xref:System.Net> namespace.  
  
## See Also  
 [Programming Pluggable Protocols](../../../docs/framework/network-programming/programming-pluggable-protocols.md)
