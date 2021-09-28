---
title: "How to: Retrieve a Protocol-Specific WebResponse that Matches a WebRequest"
description: Learn how to retrieve a protocol-specific WebResponse that matches a WebRequest in the .NET Framework.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: d8c90785-f16b-42a5-8439-ed2f731b2ba8
---
# How to: Retrieve a Protocol-Specific WebResponse that Matches a WebRequest

This example shows how to retrieve a protocol-specific WebResponse that matches a WebRequest.  
  
## Example  
  
```csharp  
HttpWebRequest req = (HttpWebRequest)WebRequest.Create("http://www.contoso.com/");
HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
```  
  
```vb  
Dim req As HttpWebRequest = CType(WebRequest.Create("http://www.contoso.com"), HttpWebRequest)
Dim resp As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)
```  
  
## Compiling the Code  

 This example requires:  
  
- References to the **System.Net** namespace.  
  
## See also

- [Requesting Data](requesting-data.md)
