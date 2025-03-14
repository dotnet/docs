---
description: "Learn how to declare events with the `event` keyword - C# Reference"
title: "The `event` keyword"
ms.date: 03/13/2025
f1_keywords:
  - "event"
  - "remove"
  - "event_CSharpKeyword"
  - "add"
helpviewer_keywords:
  - "event keyword [C#]"
---
# The `event` keyword (C# reference)

An ***event*** is a member that enables an object to trigger notifications. Event users can attach executable code for events by supplying ***event handlers***. The `event` keyword declares an ***event***. The event is of a delegate type. While an object triggers an event, the event invokes all supplied event handlers. Event handlers are delegate instances added to the event and executed when the event is raised. Event users can add or remove their event handlers on an event.

The following example shows how to declare and raise an event that uses <xref:System.EventHandler> as the underlying delegate type. For the complete code example, see [How to publish events that conform to .NET Guidelines](/dotnet/standard/events). That sample demonstrates the generic <xref:System.EventHandler%601> delegate type, how to subscribe to an event, and create an event handler method,

:::code language="csharp" source="./snippets/Events.cs" id="EventExample":::

Events are multicast delegates that can only be invoked from within the class (or derived classes) or struct where they're declared (the publisher class). If other classes or structs subscribe to the event, their event handler methods are called when the publisher class raises the event. For more information and code examples, see [Events](../../programming-guide/events/index.md) and [Delegates](../../programming-guide/delegates/index.md).

Events can be marked as [`public`](./public.md), [`private`](./private.md), [`protected`](./protected.md), [`internal`](./internal.md), [`protected internal`](./protected-internal.md), or [`private protected`](./private-protected.md). These access modifiers define how users of the class can access the event. For more information, see [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

Beginning with C# 14, events can be [`partial`](./partial-member.md). Partial events have one defining declaration and one implementing declaration. The defining declaration must use the field-like syntax. The implementing declaration must declare the `add` and `remove` handlers.

## Keywords and events

The following keywords apply to events.

| Keyword                   | Description     | For more information |
|---------------------------|-----------------|----------------------|
| [`static`](./static.md)     | Makes the event available to callers at any time, even if no instance of the class exists. | [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md) |
| [`virtual`](./virtual.md)   | Allows derived classes to override the event behavior by using the [override](./override.md) keyword. | [Inheritance](../../fundamentals/object-oriented/inheritance.md)|
| [`sealed`](./sealed.md)     | Specifies that for derived classes it's no longer virtual. | |
| [`abstract`](./abstract.md) | The compiler doesn't generate the `add` and `remove` event accessor blocks and therefore derived classes must provide their own implementation. | |

An event can be declared as a static event by using the [static](./static.md) keyword. Static events are available to callers at any time, even if no instance of the class exists. For more information, see [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md).

An event can be marked as a virtual event by using the [`virtual`](./virtual.md) keyword. Derived classes can override the event behavior by using the [`override`](./override.md) keyword. For more information, see [Inheritance](../../fundamentals/object-oriented/inheritance.md). An event overriding a virtual event can also be [`sealed`](./sealed.md), which specifies that for derived classes it's no longer virtual. Lastly, an event can be declared [`abstract`](./abstract.md), which means that the compiler doesn't generate the `add` and `remove` event accessor blocks. Therefore derived classes must provide their own implementation.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Keywords](./index.md)
- [add](./add.md)
- [remove](./remove.md)
- [Modifiers](index.md)
- [How to combine delegates (Multicast Delegates)](../../programming-guide/delegates/how-to-combine-delegates-multicast-delegates.md)
