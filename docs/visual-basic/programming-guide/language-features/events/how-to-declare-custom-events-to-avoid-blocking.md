---
title: "How to: Declare Custom Events To Avoid Blocking (Visual Basic)"
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
ms.assetid: 998b6a90-67c5-4d2c-8b11-366d3e355505
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Declare Custom Events To Avoid Blocking (Visual Basic)
There are several circumstances when it is important that one event handler not block subsequent event handlers. Custom events allow the event to call its event handlers asynchronously.  
  
 By default, the backing-store field for an event declaration is a multicast delegate that serially combines all the event handlers. This means that if one handler takes a long time to complete, it blocks the other handlers until it completes. (Well-behaved event handlers should never perform lengthy or potentially blocking operations.)  
  
 Instead of using the default implementation of events that Visual Basic provides, you can use a custom event to execute the event handlers asynchronously.  
  
## Example  
 In this example, the `AddHandler` accessor adds the delegate for each handler of the `Click` event to an <xref:System.Collections.ArrayList> stored in the `EventHandlerList` field.  
  
 When code raises the `Click` event, the `RaiseEvent` accessor invokes all the event handler delegates asynchronously using the <xref:System.Web.Services.Protocols.LogicalMethodInfo.BeginInvoke%2A> method. That method invokes each handler on a worker thread and returns immediately, so handlers cannot block one another.  
  
 [!code-vb[VbVbalrEvents#27](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/how-to-declare-custom-events-to-avoid-blocking_1.vb)]  
  
## See Also  
 <xref:System.Collections.ArrayList>  
 <xref:System.Web.Services.Protocols.LogicalMethodInfo.BeginInvoke%2A>  
 [Events](../../../../visual-basic/programming-guide/language-features/events/index.md)  
 [How to: Declare Custom Events To Conserve Memory](../../../../visual-basic/programming-guide/language-features/events/how-to-declare-custom-events-to-conserve-memory.md)
