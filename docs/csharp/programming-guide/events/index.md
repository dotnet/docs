---
title: "Events - C# Programming Guide"
description: Learn about events. Events enable a class or object to notify other classes or objects when something of interest occurs.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "classes [C#], events"
  - "C# language, events"
  - "events [C#]"
ms.assetid: a8e51b22-d294-44fb-9539-0072f06c4cb3
---
# Events (C# Programming Guide)

Events enable a [class](../../language-reference/keywords/class.md) or object to notify other classes or objects when something of interest occurs. The class that sends (or *raises*) the event is called the *publisher* and the classes that receive (or *handle*) the event are called *subscribers*.  
  
In a typical C# Windows Forms or Web application, you subscribe to events raised by controls such as buttons and list boxes. You can use the Visual C# integrated development environment (IDE) to browse the events that a control publishes and select the ones that you want to handle. The IDE provides an easy way to automatically add an empty event handler method and the code to subscribe to the event. For more information, see [How to subscribe to and unsubscribe from events](./how-to-subscribe-to-and-unsubscribe-from-events.md).
  
## Events Overview  

 Events have the following properties:  
  
- The publisher determines when an event is raised; the subscribers determine what action is taken in response to the event.  
  
- An event can have multiple subscribers. A subscriber can handle multiple events from multiple publishers.  
  
- Events that have no subscribers are never raised.  
  
- Events are typically used to signal user actions such as button clicks or menu selections in graphical user interfaces.  
  
- When an event has multiple subscribers, the event handlers are invoked synchronously when an event is raised. To invoke events asynchronously, see [Calling Synchronous Methods Asynchronously](../../../standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously.md).  
  
- In the .NET class library, events are based on the <xref:System.EventHandler> delegate and the <xref:System.EventArgs> base class.  
  
## Related Sections  

 For more information, see:  
  
- [How to subscribe to and unsubscribe from events](./how-to-subscribe-to-and-unsubscribe-from-events.md)

- [How to publish events that conform to .NET Guidelines](./how-to-publish-events-that-conform-to-net-framework-guidelines.md)

- [How to raise base class events in derived classes](./how-to-raise-base-class-events-in-derived-classes.md)

- [How to implement interface events](./how-to-implement-interface-events.md)

- [How to implement custom event accessors](./how-to-implement-custom-event-accessors.md)

## C# Language Specification  

For more information, see [Events](~/_csharplang/spec/classes.md#events) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.
  
## Featured Book Chapters  

 [Delegates, Events, and Lambda Expressions](/previous-versions/visualstudio/visual-studio-2008/ff518994(v=orm.10)) in [C# 3.0 Cookbook, Third Edition: More than 250 solutions for C# 3.0 programmers](/previous-versions/visualstudio/visual-studio-2008/ff518995(v=orm.10))  
  
 [Delegates and Events](/previous-versions/visualstudio/visual-studio-2008/ff652490(v=orm.10)) in [Learning C# 3.0: Fundamentals of C# 3.0](/previous-versions/visualstudio/visual-studio-2008/ff652493(v=orm.10))  
  
## See also

- <xref:System.EventHandler>
- [C# Programming Guide](../index.md)
- [Delegates](../delegates/index.md)
- [Creating Event Handlers in Windows Forms](/dotnet/desktop/winforms/creating-event-handlers-in-windows-forms)
