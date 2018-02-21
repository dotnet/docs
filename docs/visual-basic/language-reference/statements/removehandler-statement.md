---
title: "RemoveHandler Statement"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.RemoveHandlerMethod"
  - "vb.RemoveHandler"
  - "RemoveHandler"
helpviewer_keywords: 
  - "RemoveHandler keyword [Visual Basic]"
  - "RemoveHandler statement [Visual Basic]"
ms.assetid: 647cd825-e877-4910-b4f1-8d168beebe6a
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# RemoveHandler Statement
Removes the association between an event and an event handler.  
  
## Syntax  
  
```  
RemoveHandler event, AddressOf eventhandler  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`event`|The name of the event being handled.|  
|`eventhandler`|The name of the procedure currently handling the event.|  
  
## Remarks  
 The `AddHandler` and `RemoveHandler` statements allow you to start and stop event handling for a specific event at any time during program execution.  
  
> [!NOTE]
>  For custom events, the `RemoveHandler` statement invokes the event's `RemoveHandler` accessor. For more information on custom events, see [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md).  
  
## Example  
 [!code-vb[VbVbalrEvents#17](../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/removehandler-statement_1.vb)]  
  
## See Also  
 [AddHandler Statement](../../../visual-basic/language-reference/statements/addhandler-statement.md)  
 [Handles](../../../visual-basic/language-reference/statements/handles-clause.md)  
 [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)  
 [Events](../../../visual-basic/programming-guide/language-features/events/index.md)
