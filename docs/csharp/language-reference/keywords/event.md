---
description: "event - C# Reference"
title: "event - C# Reference"
ms.date: 07/20/2015
f1_keywords:
  - "event"
  - "remove"
  - "event_CSharpKeyword"
  - "add"
helpviewer_keywords:
  - "event keyword [C#]"
ms.assetid: 7858fd85-153b-4259-85d0-6aa13c35f174
---
# event (C# reference)

The `event` keyword is used to declare an event in a publisher class.

## Example

The following example shows how to declare and raise an event that uses <xref:System.EventHandler> as the underlying delegate type. For the complete code example that also shows how to use the generic <xref:System.EventHandler%601> delegate type and how to subscribe to an event and create an event handler method, see [How to publish events that conform to .NET Guidelines](../../programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines.md).

[!code-csharp[csrefKeywordsModifiers#7](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsModifiers/CS/csrefKeywordsModifiers.cs#7)]

Events are a special kind of multicast delegate that can only be invoked from within the class or struct where they are declared (the publisher class). If other classes or structs subscribe to the event, their event handler methods will be called when the publisher class raises the event. For more information and code examples, see [Events](../../programming-guide/events/index.md) and [Delegates](../../programming-guide/delegates/index.md).

Events can be marked as [public](./public.md), [private](./private.md), [protected](./protected.md), [internal](./internal.md), [protected internal](./protected-internal.md), or [private protected](./private-protected.md). These access modifiers define how users of the class can access the event. For more information, see [Access Modifiers](../../programming-guide/classes-and-structs/access-modifiers.md).

## Keywords and events

The following keywords apply to events.

|Keyword|Description|For more information|
|-------------|-----------------|--------------------------|
|[static](./static.md)|Makes the event available to callers at any time, even if no instance of the class exists.|[Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md)|
|[virtual](./virtual.md)|Allows derived classes to override the event behavior by using the [override](./override.md) keyword.|[Inheritance](../../fundamentals/object-oriented/inheritance.md)|
|[sealed](./sealed.md)|Specifies that for derived classes it is no longer virtual.||
|[abstract](./abstract.md)|The compiler will not generate the `add` and `remove` event accessor blocks and therefore derived classes must provide their own implementation.||

An event may be declared as a static event by using the [static](./static.md) keyword. This makes the event available to callers at any time, even if no instance of the class exists. For more information, see [Static Classes and Static Class Members](../../programming-guide/classes-and-structs/static-classes-and-static-class-members.md).

An event can be marked as a virtual event by using the [virtual](./virtual.md) keyword. This enables derived classes to override the event behavior by using the [override](./override.md) keyword. For more information, see [Inheritance](../../fundamentals/object-oriented/inheritance.md). An event overriding a virtual event can also be [sealed](./sealed.md), which specifies that for derived classes it is no longer virtual. Lastly, an event can be declared [abstract](./abstract.md), which means that the compiler will not generate the `add` and `remove` event accessor blocks. Therefore derived classes must provide their own implementation.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](./index.md)
- [add](./add.md)
- [remove](./remove.md)
- [Modifiers](index.md)
- [How to combine delegates (Multicast Delegates)](../../programming-guide/delegates/how-to-combine-delegates-multicast-delegates.md)
