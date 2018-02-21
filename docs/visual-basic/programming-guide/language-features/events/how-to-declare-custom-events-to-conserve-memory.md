---
title: "How to: Declare Custom Events To Conserve Memory (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "declaring events [Visual Basic], custom"
  - "events [Visual Basic], custom"
  - "custom events [Visual Basic]"
ms.assetid: 87ebee87-260c-462f-979c-407874debd19
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Declare Custom Events To Conserve Memory (Visual Basic)
There are several circumstances when it is important that an application keep its memory usage low. Custom events allow the application to use memory only for the events that it handles.  
  
 By default, when a class declares an event, the compiler allocates memory for a field to store the event information. If a class has many unused events, they needlessly take up memory.  
  
 Instead of using the default implementation of events that Visual Basic provides, you can use custom events to manage the memory usage more carefully.  
  
## Example  
 In this example, the class uses one instance of the <xref:System.ComponentModel.EventHandlerList> class, stored in the `Events` field, to store information about the events in use. The <xref:System.ComponentModel.EventHandlerList> class is an optimized list class designed to hold delegates.  
  
 All events in the class use the `Events` field to keep track of what methods are handling each event.  
  
 [!code-vb[VbVbalrEvents#22](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/how-to-declare-custom-events-to-conserve-memory_1.vb)]  
  
## See Also  
 <xref:System.ComponentModel.EventHandlerList>  
 [Events](../../../../visual-basic/programming-guide/language-features/events/index.md)  
 [How to: Declare Custom Events To Avoid Blocking](../../../../visual-basic/programming-guide/language-features/events/how-to-declare-custom-events-to-avoid-blocking.md)
