---
title: "Events (C# Programming Guide) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "classes [C#], events"
  - "C# language, events"
  - "events [C#]"
ms.assetid: a8e51b22-d294-44fb-9539-0072f06c4cb3
caps.latest.revision: 43
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
---
# Events (C# Programming Guide)
[!INCLUDE[csharpbanner](../../../includes/csharpbanner.md)]

Events enable a [class](../../../csharp/language-reference/keywords/class.md) or object to notify other classes or objects when something of interest occurs. The class that sends (or *raises*) the event is called the *publisher* and the classes that receive (or *handle*) the event are called *subscribers*.  
  
 In a typical C# Windows Forms or Web application, you subscribe to events raised by controls such as buttons and list boxes. You can use the [!INCLUDE[csprcs](../../../includes/csprcs-md.md)] integrated development environment (IDE) to browse the events that a control publishes and select the ones that you want to handle. The IDE automatically adds an empty event handler method and the code to subscribe to the event. For more information, see [How to: Subscribe to and Unsubscribe from Events](../../../csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).  
  
## Events Overview  
 Events have the following properties:  
  
-   The publisher determines when an event is raised; the subscribers determine what action is taken in response to the event.  
  
-   An event can have multiple subscribers. A subscriber can handle multiple events from multiple publishers.  
  
-   Events that have no subscribers are never raised.  
  
-   Events are typically used to signal user actions such as button clicks or menu selections in graphical user interfaces.  
  
-   When an event has multiple subscribers, the event handlers are invoked synchronously when an event is raised. To invoke events asynchronously, see [Calling Synchronous Methods Asynchronously](../Topic/Calling%20Synchronous%20Methods%20Asynchronously.md).  
  
-   In the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] class library, events are based on the <xref:System.EventHandler> delegate and the <xref:System.EventArgs> base class.  
  
## Related Sections  
 For more information, see:  
  
-   [How to: Subscribe to and Unsubscribe from Events](../../../csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md)  
  
-   [How to: Publish Events that Conform to .NET Framework Guidelines](../../../csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines.md)  
  
-   [How to: Raise Base Class Events in Derived Classes](../../../csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes.md)  
  
-   [How to:  Implement Interface Events](../../../csharp/programming-guide/events/how-to-implement-interface-events.md)  
  
-   [Thread Synchronization](../Topic/Thread%20Synchronization%20\(C%23%20and%20Visual%20Basic\).md)  
  
-   [How to: Use a Dictionary to Store Event Instances](../../../csharp/programming-guide/events/how-to-use-a-dictionary-to-store-event-instances.md)  
  
-   [How to: Implement Custom Event Accessors](../../../csharp/programming-guide/events/how-to-implement-custom-event-accessors.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../includes/csharplangspec-md.md)]  
  
## Featured Book Chapters  
 [Delegates, Events, and Lambda Expressions](http://go.microsoft.com/fwlink/?LinkId=195395) in [C# 3.0 Cookbook, Third Edition: More than 250 solutions for C# 3.0 programmers](http://go.microsoft.com/fwlink/?LinkId=195369)  
  
 [Delegates and Events](http://go.microsoft.com/fwlink/?LinkId=195418) in [Learning C# 3.0: Master the fundamentals of C# 3.0](http://go.microsoft.com/fwlink/?LinkId=195412)  
  
## See Also  
 <xref:System.EventHandler>   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Delegates](../../../csharp/programming-guide/delegates/index.md)   
 [Creating Event Handlers in Windows Forms](../Topic/Creating%20Event%20Handlers%20in%20Windows%20Forms.md)   
 [Multithreaded Programming with the Event-based Asynchronous Pattern](../Topic/Multithreaded%20Programming%20with%20the%20Event-based%20Asynchronous%20Pattern.md)