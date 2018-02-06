---
title: "Declaration Contexts and Default Access Levels (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "module level, defined"
  - "declaration contexts, Visual Basic"
  - "procedure level, defined"
  - "namespace level, defined"
  - "access levels, Visual Basic"
  - "access levels, default levels"
ms.assetid: bf63b96e-e825-4745-88c8-5dae222728db
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Declaration Contexts and Default Access Levels (Visual Basic)
This topic describes which Visual Basic types can be declared within which other types, and what their access levels default to if not specified.  
  
## Declaration Context Levels  
 The *declaration context* of a programming element is the region of code in which it is declared. This is often another programming element, which is then called the *containing element*.  
  
 The levels for declaration contexts are the following:  
  
-   *Namespace level* — within a source file or namespace but not within a class, structure, module, or interface  
  
-   *Module level* — within a class, structure, module, or interface but not within a procedure or block  
  
-   *Procedure level* — within a procedure or block (such as `If` or `For`)  
  
 The following table shows the default access levels for various declared programming elements, depending on their declaration contexts.  
  
|Declared element|Namespace level|Module level|Procedure level|  
|----------------------|---------------------|------------------|---------------------|  
|Variable ([Dim Statement](../../../visual-basic/language-reference/statements/dim-statement.md))|Not allowed|`Private` (`Public` in `Structure`, not allowed in `Interface`)|`Public`|  
|Constant ([Const Statement](../../../visual-basic/language-reference/statements/const-statement.md))|Not allowed|`Private` (`Public` in `Structure`, not allowed in `Interface`)|`Public`|  
|Enumeration ([Enum Statement](../../../visual-basic/language-reference/statements/enum-statement.md))|`Friend`|`Public`|Not allowed|  
|Class ([Class Statement](../../../visual-basic/language-reference/statements/class-statement.md))|`Friend`|`Public`|Not allowed|  
|Structure ([Structure Statement](../../../visual-basic/language-reference/statements/structure-statement.md))|`Friend`|`Public`|Not allowed|  
|Module ([Module Statement](../../../visual-basic/language-reference/statements/module-statement.md))|`Friend`|Not allowed|Not allowed|  
|Interface ([Interface Statement](../../../visual-basic/language-reference/statements/interface-statement.md))|`Friend`|`Public`|Not allowed|  
|Procedure ([Function Statement](../../../visual-basic/language-reference/statements/function-statement.md), [Sub Statement](../../../visual-basic/language-reference/statements/sub-statement.md))|Not allowed|`Public`|Not allowed|  
|External reference ([Declare Statement](../../../visual-basic/language-reference/statements/declare-statement.md))|Not allowed|`Public` (not allowed in `Interface`)|Not allowed|  
|Operator ([Operator Statement](../../../visual-basic/language-reference/statements/operator-statement.md))|Not allowed|`Public` (not allowed in `Interface` or `Module`)|Not allowed|  
|Property ([Property Statement](../../../visual-basic/language-reference/statements/property-statement.md))|Not allowed|`Public`|Not allowed|  
|Default property ([Default](../../../visual-basic/language-reference/modifiers/default.md))|Not allowed|`Public` (not allowed in `Module`)|Not allowed|  
|Event ([Event Statement](../../../visual-basic/language-reference/statements/event-statement.md))|Not allowed|`Public`|Not allowed|  
|Delegate ([Delegate Statement](../../../visual-basic/language-reference/statements/delegate-statement.md))|`Friend`|`Public`|Not allowed|  
  
 For more information, see [Access levels in Visual Basic](../../../visual-basic/programming-guide/language-features/declared-elements/access-levels.md).  
  
## See Also  
 [Friend](../../../visual-basic/language-reference/modifiers/friend.md)  
 [Private](../../../visual-basic/language-reference/modifiers/private.md)  
 [Public](../../../visual-basic/language-reference/modifiers/public.md)
