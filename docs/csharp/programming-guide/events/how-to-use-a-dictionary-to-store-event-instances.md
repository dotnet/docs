---
title: "How to: use a dictionary to store event instances - C# Programming Guide"
ms.custom: seodec18
ms.date: 03/11/2019
helpviewer_keywords: 
  - "events [C#], storing instances in a Dictionary"
ms.assetid: 9512c64d-5aaf-40cd-b941-ca2a592f0064
---
# How to: use a dictionary to store event instances (C# Programming Guide)

One use for the `add` and `remove` custom event accessors is to expose many events without allocating a field for each event, but instead using a <xref:System.Collections.Generic.Dictionary%602> instance to store the event instances, as the example below demonstrates. This is only useful if a type has many events, but you expect that most of the events will not be subscribed to.

[!code-csharp[csProgGuideEvents#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideEvents/CS/Events.cs#9)]

This implementation conforms to the behavior for [adding and removing delegates](~/_csharplang/spec/delegates.md#delegate-invocation) in the C# language specification.

Note that the [lock](../../language-reference/keywords/lock-statement.md) statement is used only to *access* the dictionary with event handlers. Don't invoke an event handler inside the body of the `lock` statement, as it could lead to deadlocks or lock contention.

## See also

- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Events](../../../csharp/programming-guide/events/index.md)
- [Delegates](../../../csharp/programming-guide/delegates/index.md)
