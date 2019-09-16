---
title: "How to: Override a Global Proxy Selection"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 0da481a9-b414-4230-beb0-e3ceba882fe5
---
# How to: Override a Global Proxy Selection
This example sends a **WebRequest** to `www.contoso.com` that overrides the global proxy selection with a proxy server named `alternateproxy` on port 80.  
  
## Example  
  
```csharp  
WebRequest req = WebRequest.Create("http://www.contoso.com/");  
req.Proxy = new WebProxy("http://alternateproxy:80/");  
```  
  
```vb  
Dim req As WebRequest = WebRequest.Create("http://www.contoso.com/")  
req.Proxy = New WebProxy("http://alternateproxy:80/")  
```  
  
## Compiling the Code  
 This example requires:  
  
- A [`using` directive](../../csharp/language-reference/keywords/using-directive.md) for the **System.Net** namespace.  
  
## See also

- [Using Application Protocols](../../../docs/framework/network-programming/using-application-protocols.md)
- [Accessing the Internet Through a Proxy](../../../docs/framework/network-programming/accessing-the-internet-through-a-proxy.md)
