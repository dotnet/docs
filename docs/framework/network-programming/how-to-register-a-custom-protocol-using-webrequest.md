---
description: "Learn more about: How to: Register a Custom Protocol Using WebRequest"
title: "How to: Register a Custom Protocol Using WebRequest"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 98ddbdb9-66b1-4080-92ad-51f5c447fcf8
---
# How to: Register a Custom Protocol Using WebRequest

This example shows how to register a protocol specific class that is defined elsewhere. In this example, `CustomWebRequestCreator` is the user-implemented object that implements the **Create** method that returns the `CustomWebRequest` object. The code example assumes that you have written the `CustomWebRequest` code that implements the custom protocol.  
  
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
  
## See also

- [Programming Pluggable Protocols](programming-pluggable-protocols.md)
