---
title: "How to: Enable a WebRequest to Use a Proxy to Communicate With the Internet"
description: Learn how to create a global proxy instance to enable any WebRequest to use a proxy to communicate with the internet in the .NET Framework.
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 63c0ef2c-44b5-4c54-9804-ba0b9b001ac7
---
# How to: Enable a WebRequest to Use a Proxy to Communicate With the Internet

This example creates a global proxy instance that will enable any <xref:System.Net.WebRequest> to use a proxy to communicate with the Internet. The example assumes that the proxy server is named `webproxy` and that it communicates on port 80, the standard HTTP port.

## Example

```csharp
var proxyObject = new WebProxy("http://webproxy:80/");
GlobalProxySelection.Select = proxyObject;
```

```vb
Dim proxyObject As New WebProxy("http://webproxy:80/")
GlobalProxySelection.Select = proxyObject
```

## Compiling the Code

This example requires:

- A C# [`using` directive](../../csharp/language-reference/keywords/using-directive.md) for the **System.Net** namespace.
- A Visual Basic [`Imports` statement](../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md) for the **System.Net** namespace.

## See also

- [Using Application Protocols](using-application-protocols.md)
- [Accessing the Internet Through a Proxy](accessing-the-internet-through-a-proxy.md)
