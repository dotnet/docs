---
title: "How to: Get type and member information by using reflection"
description: Learn how to get type and member information with reflection, using the System.Reflection namespace.
ms.date: "09/03/2019"
ms.topic: how-to
helpviewer_keywords:
  - "reflection, obtaining member information"
  - "types [.NET], obtaining member information from"
dev_langs:
  - "csharp"
  - "vb"
---
# How to: Get type and member information by using reflection

The <xref:System.Reflection> namespace contains many methods for obtaining information about types and their members. This article demonstrates one of these methods, <xref:System.Type.GetMembers%2A?displayProperty=nameWithType>. For additional information, see [Reflection overview](reflection.md).

## Example

The following example obtains type and member information by using reflection:

[!code-csharp[Get type members](../../../samples/snippets/standard/reflection/memberinfo/gettypemembers.cs)]
[!code-vb[Get type members](../../../samples/snippets/standard/reflection/memberinfo/gettypemembers.vb)]

## See also

- [Reflection](reflection.md)
