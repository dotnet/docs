---
title: "How to combine delegates (Multicast Delegates)"
description: Learn how to combine delegates to create multicast delegates. See a code example and view more available resources.
ms.topic: how-to
ms.date: 12/20/2024
helpviewer_keywords: 
  - "delegates [C#], combining"
  - "multicast delegates [C#]"
---
# How to combine delegates (Multicast Delegates) (C# Programming Guide)

This example demonstrates how to create multicast delegates. A useful property of [delegate](../../language-reference/builtin-types/reference-types.md) objects is that multiple objects can be assigned to one delegate instance by using the `+` operator. The multicast delegate contains a list of the assigned delegates. When the multicast delegate is called, it invokes the delegates in the list, in order. Only delegates of the same type can be combined. The `-` operator can be used to remove a component delegate from a multicast delegate.

:::code language="csharp" source="./snippets/MulticastExample.cs":::

## See also

- <xref:System.MulticastDelegate>
- [Events](../events/index.md)
