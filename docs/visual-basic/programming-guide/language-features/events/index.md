---
description: "Learn more about: Events (Visual Basic)"
title: "Events"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "events [Visual Basic], about events"
  - "events [Visual Basic]"
ms.assetid: 8fb0353a-e41b-4e23-b78f-da65db832f70
---
# Events (Visual Basic)

While you might visualize a Visual Studio project as a series of procedures that execute in a sequence, in reality, most programs are event driven—meaning the flow of execution is determined by external occurrences called *events*.  
  
 An event is a signal that informs an application that something important has occurred. For example, when a user clicks a control on a form, the form can raise a `Click` event and call a procedure that handles the event. Events also allow separate tasks to communicate. Say, for example, that your application performs a sort task separately from the main application. If a user cancels the sort, your application can send a cancel event instructing the sort process to stop.  
  
## Event Terms and Concepts  

 This section describes the terms and concepts used with events in Visual Basic.  
  
### Declaring Events  

 You declare events within classes, structures, modules, and interfaces using the `Event` keyword, as in the following example:  
  
 [!code-vb[VbVbalrEvents#24](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#24)]  
  
### Raising Events  

 An event is like a message announcing that something important has occurred. The act of broadcasting the message is called *raising* the event. In Visual Basic, you raise events with the `RaiseEvent` statement, as in the following example:  
  
 [!code-vb[VbVbalrEvents#25](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#25)]  
  
 Events must be raised within the scope of the class, module, or structure where they are declared. For example, a derived class cannot raise events inherited from a base class.  
  
### Event Senders  

 Any object capable of raising an event is an *event sender*, also known as an *event source*. Forms, controls, and user-defined objects are examples of event senders.  
  
### Event Handlers  

 *Event handlers* are procedures that are called when a corresponding event occurs. You can use any valid subroutine with a matching signature as an event handler. You cannot use a function as an event handler, however, because it cannot return a value to the event source.  
  
 Visual Basic uses a standard naming convention for event handlers that combines the name of the event sender, an underscore, and the name of the event. For example, the `Click` event of a button named `button1` would be named `Sub button1_Click`.  
  
> [!NOTE]
> We recommend that you use this naming convention when defining event handlers for your own events, but it is not required; you can use any valid subroutine name.  
  
## Associating Events with Event Handlers  

 Before an event handler becomes usable, you must first associate it with an event by using either the `Handles` or `AddHandler` statement.  
  
### WithEvents and the Handles Clause  

 The `WithEvents` statement and `Handles` clause provide a declarative way of specifying event handlers. An event raised by an object declared with the `WithEvents` keyword can be handled by any procedure with a `Handles` statement for that event, as shown in the following example:  
  
 [!code-vb[VbVbalrEvents#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#1)]  
  
 The `WithEvents` statement and the `Handles` clause are often the best choice for event handlers because the declarative syntax they use makes event handling easier to code, read and debug. However, be aware of the following limitations on the use of `WithEvents` variables:  
  
- You cannot use a `WithEvents` variable as an object variable. That is, you cannot declare it as `Object`—you must specify the class name when you declare the variable.  
  
- Because shared events are not tied to class instances, you cannot use `WithEvents` to declaratively handle shared events. Similarly, you cannot use `WithEvents` or `Handles` to handle events from a `Structure`. In both cases, you can use the `AddHandler` statement to handle those events.  
  
- You cannot create arrays of `WithEvents` variables.  
  
 `WithEvents` variables allow a single event handler to handle one or more kind of event, or one or more event handlers to handle the same kind of event.  
  
 Although the `Handles` clause is the standard way of associating an event with an event handler, it is limited to associating events with event handlers at compile time.  
  
 In some cases, such as with events associated with forms or controls, Visual Basic automatically stubs out an empty event handler and associates it with an event. For example, when you double-click a command button on a form in design mode, Visual Basic creates an empty event handler and a `WithEvents` variable for the command button, as in the following code:  
  
 [!code-vb[VbVbalrEvents#26](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#26)]  
  
### AddHandler and RemoveHandler  

 The `AddHandler` statement is similar to the `Handles` clause in that both allow you to specify an event handler. However, `AddHandler`, used with `RemoveHandler`, provides greater flexibility than the `Handles` clause, allowing you to dynamically add, remove, and change the event handler associated with an event. If you want to handle shared events or events from a structure, you must use `AddHandler`.  
  
 `AddHandler` takes two arguments: the name of an event from an event sender such as a control, and an expression that evaluates to a delegate. You do not need to explicitly specify the delegate class when using `AddHandler`, since the `AddressOf` statement always returns a reference to the delegate. The following example associates an event handler with an event raised by an object:  
  
 [!code-vb[VbVbalrEvents#28](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#28)]  
  
 `RemoveHandler`, which disconnects an event from an event handler, uses the same syntax as `AddHandler`. For example:  
  
 [!code-vb[VbVbalrEvents#29](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#29)]  
  
 In the following example, an event handler is associated with an event, and the event is raised. The event handler catches the event and displays a message.  
  
 Then the first event handler is removed and a different event handler is associated with the event. When the event is raised again, a different message is displayed.  
  
 Finally, the second event handler is removed and the event is raised for a third time. Because there is no longer an event handler associated with the event, no action is taken.  
  
 [!code-vb[VbVbalrEvents#38](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class2.vb#38)]  
  
## Handling Events Inherited from a Base Class  

 *Derived classes*—classes that inherit characteristics from a base class—can handle events raised by their base class using the `Handles MyBase` statement.  
  
### To handle events from a base class  
  
- Declare an event handler in the derived class by adding a `Handles MyBase.`*eventname* statement to the declaration line of your event-handler procedure, where *eventname* is the name of the event in the base class you are handling. For example:  
  
     [!code-vb[VbVbalrEvents#12](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#12)]  
  
## Related Sections  
  
|Title|Description|  
|-----------|-----------------|  
|[Walkthrough: Declaring and Raising Events](walkthrough-declaring-and-raising-events.md)|Provides a step-by-step description of how to declare and raise events for a class.|  
|[Walkthrough: Handling Events](walkthrough-handling-events.md)|Demonstrates how to write an event-handler procedure.|  
|[How to: Declare Custom Events To Avoid Blocking](how-to-declare-custom-events-to-avoid-blocking.md)|Demonstrates how to define a custom event that allows its event handlers to be called asynchronously.|  
|[How to: Declare Custom Events To Conserve Memory](how-to-declare-custom-events-to-conserve-memory.md)|Demonstrates how to define a custom event that uses memory only when the event is handled.|  
|[Troubleshooting Inherited Event Handlers in Visual Basic](troubleshooting-inherited-event-handlers.md)|Lists common issues that arise with event handlers in inherited components.|  
|[Events](../../../../standard/events/index.md)|Provides an overview of the event model in the .NET Framework.|  
|[Creating Event Handlers in Windows Forms](/dotnet/desktop/winforms/creating-event-handlers-in-windows-forms)|Describes how to work with events associated with Windows Forms objects.|  
|[Delegates](../delegates/index.md)|Provides an overview of delegates in Visual Basic.|
