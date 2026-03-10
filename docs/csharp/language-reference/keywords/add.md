---
description: The `add` contextual keyword declares an event accessor that adds a handler to that event.
title: "The `add` keyword"
ms.date: 01/21/2026
f1_keywords: 
  - "add_CSharpKeyword"
helpviewer_keywords: 
  - "add event accessor [C#]"
---
# The `add` contextual keyword (C# Reference)

Use the `add` contextual keyword to define a custom event accessor that's invoked when client code subscribes to your [event](./event.md). If you supply a custom `add` accessor, you must also supply a [remove](./remove.md) accessor.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The following example shows an event that has custom `add` and [remove](./remove.md) accessors. For the full example, see [How to implement interface events](../../programming-guide/events/how-to-implement-interface-events.md).

:::code language="csharp" source="./snippets/events.cs" id="AddHandler":::

You don't typically need to provide your own custom event accessors. The automatically generated accessors when you declare an event are sufficient for most scenarios. Starting with C# 14, you can declare [`partial`](./partial-member.md) events. The implementing declaration of a partial event must declare the `add` and `remove` handlers.

## See also

- [Events](../../programming-guide/events/index.md)
