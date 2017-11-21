---
title: "&#39;Custom&#39; modifier is not valid on events declared without explicit delegate types"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbc31122"
  - "bc31122"
helpviewer_keywords: 
  - "BC31122"
ms.assetid: 6911f0d1-641a-473b-906d-8ee5681194be
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# &#39;Custom&#39; modifier is not valid on events declared without explicit delegate types
Unlike a non-custom event, a `Custom Event` declaration requires an `As` clause following the event name that explicitly specifies the delegate type for the event.  
  
 Non-custom events can be defined either with an `As` clause and an explicit delegate type, or with a parameter list immediately following the event name.  
  
 **Error ID:** BC31122  
  
## To correct this error  
  
1.  Define a delegate with the same parameter list as the custom event.  
  
     For example, if the `Custom Event` was defined by `Custom Event Test(ByVal sender As Object, ByVal i As Integer)`, then the corresponding delegate would be the following.  
  
     [!code-vb[VbVbalrEventError#18](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/custom-modifier-is-not-valid-on-events-declared-without-explicit-delegate-types_1.vb)]  
  
2.  Replace the parameter list of the custom event with an `As` clause specifying the delegate type.  
  
     Continuing with the example, `Custom Event` declaration would be rewritten as follows.  
  
     [!code-vb[VbVbalrEventError#19](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/custom-modifier-is-not-valid-on-events-declared-without-explicit-delegate-types_2.vb)]  
  
## Example  
 This example declares a `Custom Event` and specifies the required `As` clause with a delegate type.  
  
 [!code-vb[VbVbalrEventError#2](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/custom-modifier-is-not-valid-on-events-declared-without-explicit-delegate-types_3.vb)]  
  
## See Also  
 [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)  
 [Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md)  
 [Events](../../../visual-basic/programming-guide/language-features/events/index.md)
