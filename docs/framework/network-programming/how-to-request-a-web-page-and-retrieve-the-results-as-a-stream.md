---
title: "How to: Request a Web Page and Retrieve the Results as a Stream"
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
ms.assetid: d32b7f35-29d8-4fb7-ad71-d219edc5e359
caps.latest.revision: 12
author: "mcleblanc"
ms.author: "markl"
manager: "markl"
ms.workload: 
  - "dotnet"
---
# How to: Request a Web Page and Retrieve the Results as a Stream
This example shows how to request a Web page and retrieve the results in a stream.  
  
## Example  
  
```csharp  
WebClient myClient = new WebClient();  
Stream response = myClient.OpenRead("http://www.contoso.com/index.htm");  
// The stream data is used here.  
response.Close();  
```  
  
```vb  
Dim myClient As WebClient = New WebClient()  
Dim response As Stream = myClient.OpenRead("http://www.contoso.com/index.htm")  
' The stream data is used here.  
response.Close()  
```  
  
## Compiling the Code  
 This example requires:  
  
-   References to the <xref:System.IO> and <xref:System.Net> namespaces.  
  
## See Also  
 [Requesting Data](../../../docs/framework/network-programming/requesting-data.md)
