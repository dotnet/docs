---
title: "Events - C# Programming Guide"
ms.custom: seodec18
ms.date: 07/20/2015
helpviewer_keywords: 
  - "classes [C#], events"
  - "C# language, events"
  - "events [C#]"
ms.assetid: a8e51b22-d294-44fb-9539-0072f06c4cb3
---
# Events (C# Programming Guide)
Events enable a [class](../../../csharp/language-reference/keywords/class.md) or object to notify other classes or objects when something of interest occurs. The class that sends (or *raises*) the event is called the *publisher* and the classes that receive (or *handle*) the event are called *subscribers*.  
  
 In a typical C# Windows Forms or Web application, you subscribe to events raised by controls such as buttons and list boxes. You can use the Visual C# integrated development environment (IDE) to browse the events that a control publishes and select the ones that you want to handle. The IDE provides an easy way to automatically add an empty event handler method and the code to subscribe to the event. For more information, see [How to: Subscribe to and Unsubscribe from Events](../../../csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).  
  
## Events Overview  
 Events have the following properties:  
  
-   The publisher determines when an event is raised; the subscribers determine what action is taken in response to the event.  
  
-   An event can have multiple subscribers. A subscriber can handle multiple events from multiple publishers.  
  
-   Events that have no subscribers are never raised.  
  
-   Events are typically used to signal user actions such as button clicks or menu selections in graphical user interfaces.  
  
-   When an event has multiple subscribers, the event handlers are invoked synchronously when an event is raised. To invoke events asynchronously, see [Calling Synchronous Methods Asynchronously](../../../../docs/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously.md).  
  
-   In the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)] class library, events are based on the <xref:System.EventHandler> delegate and the <xref:System.EventArgs> base class.  
  
## Related Sections  
 For more information, see:  
  
-   [How to: Subscribe to and Unsubscribe from Events](../../../csharp/programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md)  
  
-   [How to: Publish Events that Conform to .NET Framework Guidelines](../../../csharp/programming-guide/events/how-to-publish-events-that-conform-to-net-framework-guidelines.md)  
  
-   [How to: Raise Base Class Events in Derived Classes](../../../csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes.md)  
  
-   [How to:  Implement Interface Events](../../../csharp/programming-guide/events/how-to-implement-interface-events.md)  
  
-   [How to: Use a Dictionary to Store Event Instances](../../../csharp/programming-guide/events/how-to-use-a-dictionary-to-store-event-instances.md)  
  
-   [How to: Implement Custom Event Accessors](../../../csharp/programming-guide/events/how-to-implement-custom-event-accessors.md)  
  
## C# Language Specification  

For more information, see [Events](~/_csharplang/spec/classes.md#events) in the [C# Language Specification](../../language-reference/language-specification/index.md). The language specification is the definitive source for C# syntax and usage.
  
## Featured Book Chapters  
 [Delegates, Events, and Lambda Expressions](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/ff518994%28v=orm.10%29) in [C# 3.0 Cookbook, Third Edition: More than 250 solutions for C# 3.0 programmers](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/ff518995%28v=orm.10%29)  
  
 [Delegates and Events](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/ff652490%28v=orm.10%29) in [Learning C# 3.0: Master the fundamentals of C# 3.0](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2008/ff652493%28v=orm.10%29)  
  
## See also

- <xref:System.EventHandler>
- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [Delegates](../../../csharp/programming-guide/delegates/index.md)
- [Creating Event Handlers in Windows Forms](../../../../docs/framework/winforms/creating-event-handlers-in-windows-forms.md)
