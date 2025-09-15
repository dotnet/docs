---
description: "Learn more about: RaiseEvent Statement"
title: "RaiseEvent Statement"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.RaiseEventMethod"
  - "vb.RaiseEvent"
  - "RaiseEvent"
helpviewer_keywords: 
  - "raising events [Visual Basic], RaiseEvent statement"
  - "RaiseEvent statement [Visual Basic]"
  - "event handlers, connecting events to"
ms.assetid: f82e380a-1e6b-4047-bea8-c853f4d2c742
---
# RaiseEvent Statement

Triggers an event declared at module level within a class, form, or document.  
  
## Syntax  
  
```vb  
RaiseEvent eventname[( argumentlist )]  
```  
  
## Parts  

 `eventname`  
 Required. Name of the event to trigger.  
  
 `argumentlist`  
 Optional. Comma-delimited list of variables, arrays, or expressions. The `argumentlist` argument must be enclosed by parentheses. If there are no arguments, the parentheses must be omitted.  
  
## Remarks  

 The required `eventname` is the name of an event declared within the module. It follows Visual Basic variable naming conventions.  
  
 If the event has not been declared within the module in which it is raised, an error occurs. The following code fragment illustrates an event declaration and a procedure in which the event is raised.  
  
 [!code-vb[VbVbalrEvents#37](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#37)]  
  
 You cannot use `RaiseEvent` to raise events that are not explicitly declared in the module. For example, all forms inherit a <xref:System.Windows.Forms.Control.Click> event from <xref:System.Windows.Forms.Form?displayProperty=nameWithType>, it cannot be raised using `RaiseEvent` in a derived form. If you declare a `Click` event in the form module, it shadows the form's own <xref:System.Windows.Forms.Control.Click> event. You can still invoke the form's <xref:System.Windows.Forms.Control.Click> event by calling the <xref:System.Windows.Forms.Control.OnClick%2A> method.  
  
 By default, an event defined in Visual Basic raises its event handlers in the order that the connections are established. Because events can have `ByRef` parameters, a process that connects late may receive parameters that have been changed by an earlier event handler. After the event handlers execute, control is returned to the subroutine that raised the event.  
  
> [!NOTE]
> Non-shared events should not be raised within the constructor of the class in which they are declared. Although such events do not cause run-time errors, they may fail to be caught by associated event handlers. Use the `Shared` modifier to create a shared event if you need to raise an event from a constructor.  
  
> [!NOTE]
> You can change the default behavior of events by defining a custom event. For custom events, the `RaiseEvent` statement invokes the event's `RaiseEvent` accessor. For more information on custom events, see [Event Statement](event-statement.md).  
  
## Example 1

 The following example uses events to count down seconds from 10 to 0. The code illustrates several of the event-related methods, properties, and statements, including the `RaiseEvent` statement.  
  
 The class that raises an event is the event source, and the methods that process the event are the event handlers. An event source can have multiple handlers for the events it generates. When the class raises the event, that event is raised on every class that has elected to handle events for that instance of the object.  
  
 The example demonstrates a simple timer that counts down from 10 to 0 seconds and displays the progress to the console. When the countdown finishes, it displays "Done".  
  
 Add a `WithEvents` variable to your class declarations.  
  
 [!code-vb[VbVbalrEvents#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#14)]  
  
## Example 2  

 Add the following code to implement the event handlers and timer logic. This example shows how to use the `RaiseEvent` statement to notify event handlers when the timer updates or completes.  
  
 [!code-vb[VbVbalrEvents#15](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEvents/VB/Class1.vb#15)]  
  
 When you run the preceding example, it starts counting down the seconds from 10 to 0, displaying the progress to the console. When the full time (10 seconds) has elapsed, it displays "Done".  
  
## See also

- [Events](../../programming-guide/language-features/events/index.md)
- [Event Statement](event-statement.md)
- [AddHandler Statement](addhandler-statement.md)
- [RemoveHandler Statement](removehandler-statement.md)
- [Handles](handles-clause.md)
