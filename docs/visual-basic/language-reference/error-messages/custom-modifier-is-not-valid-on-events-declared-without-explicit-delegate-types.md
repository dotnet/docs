---
title: "&#39;Custom&#39; modifier is not valid on events declared without explicit delegate types | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vbc31122"
  - "bc31122"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "BC31122"
ms.assetid: 6911f0d1-641a-473b-906d-8ee5681194be
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# &#39;Custom&#39; modifier is not valid on events declared without explicit delegate types
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Unlike a non-custom event, a `Custom Event` declaration requires an `As` clause following the event name that explicitly specifies the delegate type for the event.  
  
 Non-custom events can be defined either with an `As` clause and an explicit delegate type, or with a parameter list immediately following the event name.  
  
 **Error ID:** BC31122  
  
### To correct this error  
  
1.  Define a delegate with the same parameter list as the custom event.  
  
     For example, if the `Custom Event` was defined by `Custom Event Test(ByVal sender As Object, ByVal i As Integer)`, then the corresponding delegate would be the following.  
  
     [!code-vb[VbVbalrEventError#18](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEventError/VB/VbVbalrEventError.vb#18)]  
  
2.  Replace the parameter list of the custom event with an `As` clause specifying the delegate type.  
  
     Continuing with the example, `Custom Event` declaration would be rewritten as follows.  
  
     [!code-vb[VbVbalrEventError#19](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEventError/VB/VbVbalrEventError.vb#19)]  
  
## Example  
 This example declares a `Custom Event` and specifies the required `As` clause with a delegate type.  
  
 [!code-vb[VbVbalrEventError#2](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrEventError/VB/VbVbalrEventError.vb#2)]  
  
## See Also  
 [Event Statement](../../../visual-basic/language-reference/statements/event-statement.md)   
 [Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md)   
 [Events](../../../visual-basic/programming-guide/language-features/events/events.md)