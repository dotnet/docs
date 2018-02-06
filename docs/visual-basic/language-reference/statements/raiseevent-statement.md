---
title: "RaiseEvent Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.RaiseEventMethod"
  - "vb.RaiseEvent"
  - "RaiseEvent"
helpviewer_keywords: 
  - "raising events [Visual Basic], RaiseEvent statement"
  - "RaiseEvent statement [Visual Basic]"
  - "event handlers, connecting events to"
ms.assetid: f82e380a-1e6b-4047-bea8-c853f4d2c742
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# RaiseEvent Statement
Triggers an event declared at module level within a class, form, or document.  
  
## Syntax  
  
```  
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
  
 [!code-vb[VbVbalrEvents#37](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/raiseevent-statement_1.vb)]  
  
 You cannot use `RaiseEvent` to raise events that are not explicitly declared in the module. For example, all forms inherit a <xref:System.Windows.Forms.Control.Click> event from <xref:System.Windows.Forms.Form?displayProperty=nameWithType>, it cannot be raised using `RaiseEvent` in a derived form. If you declare a `Click` event in the form module, it shadows the form's own <xref:System.Windows.Forms.Control.Click> event. You can still invoke the form's <xref:System.Windows.Forms.Control.Click> event by calling the <xref:System.Windows.Forms.Control.OnClick%2A> method.  
  
 By default, an event defined in Visual Basic raises its event handlers in the order that the connections are established. Because events can have `ByRef` parameters, a process that connects late may receive parameters that have been changed by an earlier event handler. After the event handlers execute, control is returned to the subroutine that raised the event.  
  
> [!NOTE]
>  Non-shared events should not be raised within the constructor of the class in which they are declared. Although such events do not cause run-time errors, they may fail to be caught by associated event handlers. Use the `Shared` modifier to create a shared event if you need to raise an event from a constructor.  
  
> [!NOTE]
>  You can change the default behavior of events by defining a custom event. For custom events, the `RaiseEvent` statement invokes the event's `RaiseEvent` accessor. For more information on custom events, see [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md).  
  
## Example  
 The following example uses events to count down seconds from 10 to 0. The code illustrates several of the event-related methods, properties, and statements, including the `RaiseEvent` statement.  
  
 The class that raises an event is the event source, and the methods that process the event are the event handlers. An event source can have multiple handlers for the events it generates. When the class raises the event, that event is raised on every class that has elected to handle events for that instance of the object.  
  
 The example also uses a form (`Form1`) with a button (`Button1`) and a text box (`TextBox1`). When you click the button, the first text box displays a countdown from 10 to 0 seconds. When the full time (10 seconds) has elapsed, the first text box displays "Done".  
  
 The code for `Form1` specifies the initial and terminal states of the form. It also contains the code executed when events are raised.  
  
 To use this example, open a new Windows Application project, add a button named `Button1` and a text box named `TextBox1` to the main form, named `Form1`. Then right-click the form and click **View Code** to open the Code Editor.  
  
 Add a `WithEvents` variable to the declarations section of the `Form1` class.  
  
 [!code-vb[VbVbalrEvents#14](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/raiseevent-statement_2.vb)]  
  
## Example  
 Add the following code to the code for `Form1`. Replace any duplicate procedures that may exist, such as `Form_Load`, or `Button_Click`.  
  
 [!code-vb[VbVbalrEvents#15](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/raiseevent-statement_3.vb)]  
  
 Press F5 to run the preceding example, and click the button labeled **Start**. The first text box starts to count down the seconds. When the full time (10 seconds) has elapsed, the first text box displays "Done".  
  
> [!NOTE]
>  The `My.Application.DoEvents` method does not process events in exactly the same way as the form does. To allow the form to handle the events directly, you can use multithreading. For more information, see [Threading](../../programming-guide/concepts/threading/index.md).  
  
## See Also  
 [Events](../../../visual-basic/programming-guide/language-features/events/index.md)  
 [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)  
 [AddHandler Statement](../../../visual-basic/language-reference/statements/addhandler-statement.md)  
 [RemoveHandler Statement](../../../visual-basic/language-reference/statements/removehandler-statement.md)  
 [Handles](../../../visual-basic/language-reference/statements/handles-clause.md)
