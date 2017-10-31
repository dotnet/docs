---
title: "Handles Clause (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "Handles"
  - "vb.Handles"
helpviewer_keywords: 
  - "Handles keyword [Visual Basic]"
ms.assetid: 1b051c0e-f499-42f6-acb5-6f4f27824b40
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# Handles Clause (Visual Basic)
Declares that a procedure handles a specified event.  
  
## Syntax  
  
```  
proceduredeclaration Handles eventlist  
```  
  
## Parts  
 `proceduredeclaration`  
 The `Sub` procedure declaration for the procedure that will handle the event.  
  
 `eventlist`  
 List of the events for `proceduredeclaration` to handle, separated by commas. The events must be raised by either the base class for the current class, or by an object declared using the `WithEvents` keyword.  
  
## Remarks  
 Use the `Handles` keyword at the end of a procedure declaration to cause it to handle events raised by an object variable declared using the `WithEvents` keyword. The `Handles` keyword can also be used in a derived class to handle events from a base class.  
  
 The `Handles` keyword and the `AddHandler` statement both allow you to specify that particular procedures handle particular events, but there are differences. Use the `Handles` keyword when defining a procedure to specify that it handles a particular event. The `AddHandler` statement connects procedures to events at run time. For more information, see [AddHandler Statement](../../../visual-basic/language-reference/statements/addhandler-statement.md).  
  
 For custom events, the application invokes the event's `AddHandler` accessor when it adds the procedure as an event handler. For more information on custom events, see [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md).  
  
## Example  
 [!code-vb[VbVbalrEvents#2](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/handles-clause_1.vb)]  
  
 The following example demonstrates how a derived class can use the `Handles` statement to handle an event from a base class.  
  
 [!code-vb[VbVbalrEvents#3](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/handles-clause_2.vb)]  
  
## Example  
 The following example contains two button event handlers for a **WPF Application** project.  
  
 [!code-vb[VbVbalrEvents#41](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/handles-clause_3.vb)]  
  
## Example  
 The following example is equivalent to the previous example. The `eventlist` in the `Handles` clause contains the events for both buttons.  
  
 [!code-vb[VbVbalrEvents#42](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/handles-clause_4.vb)]  
  
## See Also  
 [WithEvents](../../../visual-basic/language-reference/modifiers/withevents.md)  
 [AddHandler Statement](../../../visual-basic/language-reference/statements/addhandler-statement.md)  
 [RemoveHandler Statement](../../../visual-basic/language-reference/statements/removehandler-statement.md)  
 [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)  
 [RaiseEvent Statement](../../../visual-basic/language-reference/statements/raiseevent-statement.md)  
 [Events](../../../visual-basic/programming-guide/language-features/events/index.md)
