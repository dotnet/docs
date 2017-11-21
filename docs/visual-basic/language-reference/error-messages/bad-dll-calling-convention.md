---
title: "Bad DLL calling convention"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vbrID49"
ms.assetid: 7c7def45-b0ab-450f-ad3f-4383dfd9aed7
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Bad DLL calling convention
Arguments passed to a dynamic-link library (DLL) must exactly match those expected by the routine. Calling conventions deal with number, type, and order of arguments. Your program may be calling a routine in a DLL that is being passed the wrong type or number of arguments.  
  
## To correct this error  
  
1.  Make sure all argument types agree with those specified in the declaration of the routine that you are calling.  
  
2.  Make sure you are passing the same number of arguments indicated in the declaration of the routine that you are calling.  
  
3.  If the DLL routine expects arguments by value, make sure `ByVal` is specified for those arguments in the declaration for the routine.  
  
## See Also  
 [Error Types](../../../visual-basic/programming-guide/language-features/error-types.md)  
 [Call Statement](../../../visual-basic/language-reference/statements/call-statement.md)  
 [Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md)
