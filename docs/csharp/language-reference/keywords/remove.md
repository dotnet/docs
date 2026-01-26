---
description: "The `remove` contextual keyword declares an event accessor that removes a handler from that event. - C# Reference"
title: "The `remove` contextual keyword"
ms.date: 01/22/2026
f1_keywords: 
  - "remove_CSharpKeyword"
helpviewer_keywords: 
  - "remove event accessor [C#]"
---
# The `remove` contextual keyword (C# Reference)

Use the `remove` contextual keyword to define a custom event accessor that's invoked when client code unsubscribes from your [event](event.md). If you supply a custom `remove` accessor, you must also supply an [add](add.md) accessor.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

The following example shows an event with custom [add](add.md) and `remove` accessors. For the full example, see [How to implement interface events](../../programming-guide/events/how-to-implement-interface-events.md).

:::code language="csharp" source="./snippets/events.cs" id="AddHandler":::

You don't typically need to provide your own custom event accessors. The automatically generated accessors when you declare an event are sufficient for most scenarios. Starting with C# 14, you can declare [`partial`](./partial-member.md) events. The implementing declaration of a partial event must declare the `add` and `remove` handlers.

## See also

- [Events](../../programming-guide/events/index.md)
