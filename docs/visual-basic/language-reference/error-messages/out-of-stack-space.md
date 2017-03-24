---
title: "Out of stack space (Visual Basic) | Microsoft Docs"
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
  - "vbrID28"
dev_langs: 
  - "VB"
ms.assetid: bfcd792b-ac29-4158-81fc-ea0c13f4ffa2
caps.latest.revision: 8
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# Out of stack space (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

The stack is a working area of memory that grows and shrinks dynamically with the demands of your executing program. Its limits have been exceeded.  
  
### To correct this error  
  
1.  Check that procedures are not nested too deeply.  
  
2.  Make sure recursive procedures terminate properly.  
  
3.  If local variables require more local variable space than is available, try declaring some variables at the module level. You can also declare all variables in the procedure static by preceding the `Property`, `Sub`, or `Function` keyword with `Static`. Or you can use the `Static` statement to declare individual static variables within procedures.  
  
4.  Redefine some of your fixed-length strings as variable-length strings, as fixed-length strings use more stack space than variable-length strings. You can also define the string at module level where it requires no stack space.  
  
5.  Check the number of nested `DoEvents` function calls, by using the `Calls` dialog box to view which procedures are active on the stack.  
  
6.  Make sure you did not cause an "event cascade" by triggering an event that calls an event procedure already on the stack. An event cascade is similar to an unterminated recursive procedure call, but it is less obvious, since the call is made by [!INCLUDE[vbprvb](../../../includes/vbprvb-md.md)] rather than an explicit call in the code. Use the `Calls`dialog box to view which procedures are active on the stack.  
  
## See Also  
 [Memory Windows](/visual-studio/debugger/memory-windows)