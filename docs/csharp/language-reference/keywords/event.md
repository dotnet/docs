---
title: "event (C# Reference)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "event"
  - "remove"
  - "event_CSharpKeyword"
  - "add"
helpviewer_keywords: 
  - "event keyword [C#]"
ms.assetid: 7858fd85-153b-4259-85d0-6aa13c35f174
caps.latest.revision: 28
author: "BillWagner"
ms.author: "wiwagn"
---
# event (C# Reference)
The `event` keyword is used to declare an event in a publisher class.  
  
## Example  
 The following example shows how to declare and raise an event that uses <xref:System.EventHandler> as the underlying delegate type. For the complete code example that also shows how to use the generic <xref:System.EventHandler%601> delegate type and how to subscribe to an event and create an event handler method, see [How to: Publish Events that Conform to .NET Framework Guidelines](../../../csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines.md).  
  
 [!code-csharp[csrefKeywordsModifiers#7](../../../csharp/language-reference/keywords/codesnippet/CSharp/event_1.cs)]  
  
 Events are a special kind of multicast delegate that can only be invoked from within the class or struct where they are declared (the publisher class). If other classes or structs subscribe to the event, their event handler methods will be called when the publisher class raises the event. For more information and code examples, see [Events](../../../csharp/programming-guide/events/index.md) and [Delegates](../../../csharp/programming-guide/delegates/index.md).  
  
 Events can be marked as [public](../../../csharp/language-reference/keywords/public.md), [private](../../../csharp/language-reference/keywords/private.md), [protected](../../../csharp/language-reference/keywords/protected.md), [internal](../../../csharp/language-reference/keywords/internal.md), [protected internal](../../../csharp/language-reference/keywords/protected-internal.md) or [private protected](../../../csharp/language-reference/keywords/private-protected.md). These access modifiers define how users of the class can access the event. For more information, see [Access Modifiers](../../../csharp/programming-guide/classes-and-structs/access-modifiers.md).  
  
## Keywords and Events  
 The following keywords apply to events.  
  
|Keyword|Description|For more information|  
|-------------|-----------------|--------------------------|  
|[static](../../../csharp/language-reference/keywords/static.md)|Makes the event available to callers at any time, even if no instance of the class exists.|[Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md)|  
|[virtual](../../../csharp/language-reference/keywords/virtual.md)|Allows derived classes to override the event behavior by using the [override](../../../csharp/language-reference/keywords/override.md) keyword.|[Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md)|  
|[sealed](../../../csharp/language-reference/keywords/sealed.md)|Specifies that for derived classes it is no longer virtual.||  
|[abstract](../../../csharp/language-reference/keywords/abstract.md)|The compiler will not generate the `add` and `remove` event accessor blocks and therefore derived classes must provide their own implementation.||  
  
 An event may be declared as a static event by using the [static](../../../csharp/language-reference/keywords/static.md) keyword. This makes the event available to callers at any time, even if no instance of the class exists. For more information, see [Static Classes and Static Class Members](../../../csharp/programming-guide/classes-and-structs/static-classes-and-static-class-members.md).  
  
 An event can be marked as a virtual event by using the [virtual](../../../csharp/language-reference/keywords/virtual.md) keyword. This enables derived classes to override the event behavior by using the [override](../../../csharp/language-reference/keywords/override.md) keyword. For more information, see [Inheritance](../../../csharp/programming-guide/classes-and-structs/inheritance.md). An event overriding a virtual event can also be [sealed](../../../csharp/language-reference/keywords/sealed.md), which specifies that for derived classes it is no longer virtual. Lastly, an event can be declared [abstract](../../../csharp/language-reference/keywords/abstract.md), which means that the compiler will not generate the `add` and `remove` event accessor blocks. Therefore derived classes must provide their own implementation.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]  
  
## See Also  
 [C# Reference](../../../csharp/language-reference/index.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [C# Keywords](../../../csharp/language-reference/keywords/index.md)  
 [add](../../../csharp/language-reference/keywords/add.md)  
 [remove](../../../csharp/language-reference/keywords/remove.md)  
 [Modifiers](../../../csharp/language-reference/keywords/modifiers.md)  
 [How to: Combine Delegates (Multicast Delegates)](../../../csharp/programming-guide/delegates/how-to-combine-delegates-multicast-delegates.md)
