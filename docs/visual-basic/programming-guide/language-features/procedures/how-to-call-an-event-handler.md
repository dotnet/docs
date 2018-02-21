---
title: "How to: Call an Event Handler in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "Visual Basic code, procedures"
  - "event handlers [Visual Basic], calling"
  - "event handlers"
  - "procedures [Visual Basic], event handlers"
  - "procedures [Visual Basic], calling"
ms.assetid: 72e18ef8-144e-40df-a1f4-066a57271e28
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Call an Event Handler in Visual Basic
An *event* is an action or occurrence — such as a mouse click or a credit limit exceeded — that is recognized by some program component, and for which you can write code to respond. An *event handler* is the code you write to respond to an event.  
  
 An event handler in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] is a `Sub` procedure. However, you do not normally call it the same way as other `Sub` procedures. Instead, you identify the procedure as a handler for the event. You can do this either with a [Handles](../../../../visual-basic/language-reference/statements/handles-clause.md) clause and a [WithEvents](../../../../visual-basic/language-reference/modifiers/withevents.md) variable, or with an [AddHandler Statement](../../../../visual-basic/language-reference/statements/addhandler-statement.md). Using a `Handles` clause is the default way to declare an event handler in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)]. This is the way the event handlers are written by the designers when you program in the integrated development environment (IDE). The `AddHandler` statement is suitable for raising events dynamically at run time.  
  
 When the event occurs, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] automatically calls the event handler procedure. Any code that has access to the event can cause it to occur by executing a [RaiseEvent Statement](../../../../visual-basic/language-reference/statements/raiseevent-statement.md).  
  
 You can associate more than one event handler with the same event. In some cases you can dissociate a handler from an event. For more information, see [Events](../../../../visual-basic/programming-guide/language-features/events/index.md).  
  
### To call an event handler using Handles and WithEvents  
  
1.  Make sure the event is declared with an [Event Statement](../../../../visual-basic/language-reference/statements/event-statement.md).  
  
2.  Declare an object variable at module or class level, using the [WithEvents](../../../../visual-basic/language-reference/modifiers/withevents.md) keyword. The `As` clause for this variable must specify the class that raises the event.  
  
3.  In the declaration of the event-handling `Sub` procedure, add a [Handles](../../../../visual-basic/language-reference/statements/handles-clause.md) clause that specifies the `WithEvents` variable and the event name.  
  
4.  When the event occurs, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] automatically calls the `Sub` procedure. Your code can use a `RaiseEvent` statement to make the event occur.  
  
     The following example defines an event and a `WithEvents` variable that refers to the class that raises the event. The event-handling `Sub` procedure uses a `Handles` clause to specify the class and event it handles.  
  
     [!code-vb[VbVbcnProcedures#4](./codesnippet/VisualBasic/how-to-call-an-event-handler_1.vb)]  
  
### To call an event handler using AddHandler  
  
1.  Make sure the event is declared with an `Event` statement.  
  
2.  Execute an [AddHandler Statement](../../../../visual-basic/language-reference/statements/addhandler-statement.md) to dynamically connect the event-handling `Sub` procedure with the event.  
  
3.  When the event occurs, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] automatically calls the `Sub` procedure. Your code can use a `RaiseEvent` statement to make the event occur.  
  
     The following example defines a `Sub` procedure to handle the <xref:System.Windows.Forms.Form.Closing> event of a form. It then uses the [AddHandler Statement](../../../../visual-basic/language-reference/statements/addhandler-statement.md) to associate the `catchClose` procedure as an event handler for <xref:System.Windows.Forms.Form.Closing>.  
  
     [!code-vb[VbVbcnProcedures#5](./codesnippet/VisualBasic/how-to-call-an-event-handler_2.vb)]  
  
     You can dissociate an event handler from an event by executing the [RemoveHandler Statement](../../../../visual-basic/language-reference/statements/removehandler-statement.md).  
  
## See Also  
 [Procedures](./index.md)  
 [Sub Procedures](./sub-procedures.md)  
 [Sub Statement](../../../../visual-basic/language-reference/statements/sub-statement.md)  
 [AddressOf Operator](../../../../visual-basic/language-reference/operators/addressof-operator.md)  
 [How to: Create a Procedure](./how-to-create-a-procedure.md)  
 [How to: Call a Procedure that Does Not Return a Value](./how-to-call-a-procedure-that-does-not-return-a-value.md)
