---
title: "How to: Get type and member information by using reflection"
ms.date: "09/03/2019"
helpviewer_keywords: 
  - "reflection, obtaining member information"
  - "types [.NET Framework], obtaining member information from"
ms.assetid: 348ae651-ccda-4f13-8eda-19e8337e9438
dev_langs: 
  - "cpp"
  - "csharp"
  - "vb"
---
# How to: Get type and member information by using reflection
The <xref:System.Reflection> namespace contains many methods for obtaining information about types and their members. This article demonstrates one of these methods, <xref:System.Type.GetMembers%2A?displayProperty=nameWithType>. For additional information, see [Reflection overview](reflection.md).
  
## Example

The following example obtains type and member information by using reflection:

[!code-cpp[Get type members](../../../samples/snippets/standard/reflection/memberinfo/gettypemembers.cpp)]
[!code-csharp[Get type members](../../../samples/snippets/standard/reflection/memberinfo/gettypemembers.cs)]
[!code-vb[Get type members](../../../samples/snippets/standard/reflection/memberinfo/gettypemembers.vb)]

## See also

- [Program with application domains](../app-domains/application-domains.md#programming-with-application-domains)
- [Reflection](reflection.md)
- [Use application domains](../app-domains/use.md)
