---
title: "How to combine delegates (Multicast Delegates)"
description: Learn how to combine delegates to create multicast delegates. See a code example and view more available resources.
ms.topic: how-to
ms.date: 03/05/2026
helpviewer_keywords: 
  - "delegates [C#], combining"
  - "multicast delegates [C#]"
---
# How to combine delegates (Multicast Delegates) (C# Programming Guide)

This example demonstrates how to create multicast delegates. A useful property of [delegate](../../language-reference/builtin-types/reference-types.md) objects is that you can assign multiple methods to one delegate instance by using the `+` operator. The multicast delegate contains a list of the assigned delegates. When you call the multicast delegate, it invokes the delegates in the list, in order. You can only combine delegates of the same type. You can use the `-` operator to remove a component delegate from a multicast delegate.

:::code language="csharp" source="./snippets/MulticastExample.cs":::

> [!NOTE]
>
> You can add the same delegate to a multicast delegate multiple times. When you call the multicast delegate, it invokes all the delegates in the list, including duplicates. When you remove a delegate from a multicast delegate, it removes the rightmost matching entry, so only one instance is removed if there are multiple copies.

## See also

- <xref:System.MulticastDelegate>
- [Events](../events/index.md)
