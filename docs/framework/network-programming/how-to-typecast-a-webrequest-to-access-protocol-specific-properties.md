---
title: "How to: Typecast a WebRequest to Access Protocol Specific Properties"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: d9a8eae2-7454-46f9-b43b-c98477c5bcde
---
# How to: Typecast a WebRequest to Access Protocol Specific Properties
This example shows how to typecast a WebRequest so that you can access protocol specific properties.  
  
## Example  
  
```csharp  
HttpWebRequest httpreq =   
   (HttpWebRequest) WebRequest.Create("http://www.contoso.com/");  
```  
  
```vb  
Dim httpreq As HttpWebRequest = _  
   CType(WebRequest.Create("http://www.contoso.com/"), HttpWebRequest)  
```  
  
## See also

- [Programming Pluggable Protocols](../../../docs/framework/network-programming/programming-pluggable-protocols.md)
