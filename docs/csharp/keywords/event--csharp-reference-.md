---
title: "event (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "event"
  - "remove"
  - "event_CSharpKeyword"
  - "add"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "event keyword [C#]"
ms.assetid: 7858fd85-153b-4259-85d0-6aa13c35f174
caps.latest.revision: 28
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# event (C# Reference)
The `event` keyword is used to declare an event in a publisher class.  
  
## Example  
 The following example shows how to declare and raise an event that uses <xref:System.EventHandler> as the underlying delegate type. For the complete code example that also shows how to use the generic <xref:System.EventHandler`1> delegate type and how to subscribe to an event and create an event handler method, see [How to: Publish Events that Conform to .NET Framework Guidelines](../events/9310ae16-8627-44a2-b08c-05e5976202b1.md).  
  
 [!code[csrefKeywordsModifiers#7](../keywords/codesnippet/CSharp/event--csharp-reference-_1.cs)]  
  
 Events are a special kind of multicast delegate that can only be invoked from within the class or struct where they are declared (the publisher class). If other classes or structs subscribe to the event, their event handler methods will be called when the publisher class raises the event. For more information and code examples, see [Events](../events/events--csharp-programming-guide-.md) and [Delegates](../delegates/delegates--csharp-programming-guide-.md).  
  
 Events can be marked as [public](../keywords/public--csharp-reference-.md), [private](../keywords/private--csharp-reference-.md), [protected](../keywords/protected--csharp-reference-.md), [internal](../keywords/internal--csharp-reference-.md), or `protected``internal`. These access modifiers define how users of the class can access the event. For more information, see [Access Modifiers](../classes-and-structs/access-modifiers--csharp-programming-guide-.md).  
  
## Keywords and Events  
 The following keywords apply to events.  
  
|Keyword|Description|For more information|  
|-------------|-----------------|--------------------------|  
|[static](../keywords/static--csharp-reference-.md)|Makes the event available to callers at any time, even if no instance of the class exists.|[Static Classes and Static Class Members](../classes-and-structs/static-classes-and-static-class-members--csharp-programming-guide-.md)|  
|[virtual](../keywords/virtual--csharp-reference-.md)|Allows derived classes to override the event behavior by using the [override](../keywords/override--csharp-reference-.md) keyword.|[Inheritance](../classes-and-structs/inheritance--csharp-programming-guide-.md)|  
|[sealed](../keywords/sealed--csharp-reference-.md)|Specifies that for derived classes it is no longer virtual.||  
|[abstract](../keywords/abstract--csharp-reference-.md)|The compiler will not generate the `add` and `remove` event accessor blocks and therefore derived classes must provide their own implementation.||  
  
 An event may be declared as a static event by using the [static](../keywords/static--csharp-reference-.md) keyword. This makes the event available to callers at any time, even if no instance of the class exists. For more information, see [Static Classes and Static Class Members](../classes-and-structs/static-classes-and-static-class-members--csharp-programming-guide-.md).  
  
 An event can be marked as a virtual event by using the [virtual](../keywords/virtual--csharp-reference-.md) keyword. This enables derived classes to override the event behavior by using the [override](../keywords/override--csharp-reference-.md) keyword. For more information, see [Inheritance](../classes-and-structs/inheritance--csharp-programming-guide-.md). An event overriding a virtual event can also be [sealed](../keywords/sealed--csharp-reference-.md), which specifies that for derived classes it is no longer virtual. Lastly, an event can be declared [abstract](../keywords/abstract--csharp-reference-.md), which means that the compiler will not generate the `add` and `remove` event accessor blocks. Therefore derived classes must provide their own implementation.  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [add](../keywords/add--csharp-reference-.md)   
 [remove](../keywords/remove--csharp-reference-.md)   
 [Modifiers](../keywords/modifiers--csharp-reference-.md)   
 [How to: Combine Delegates (Multicast Delegates)](../delegates/how-to--combine-delegates--multicast-delegates--csharp-programming-guide-.md)