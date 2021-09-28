---
description: "Learn more about: Declaration Contexts and Default Access Levels (Visual Basic)"
title: "Declaration Contexts and Default Access Levels"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "module level, defined"
  - "declaration contexts, Visual Basic"
  - "procedure level, defined"
  - "namespace level, defined"
  - "access levels, Visual Basic"
  - "access levels, default levels"
ms.assetid: bf63b96e-e825-4745-88c8-5dae222728db
---
# Declaration Contexts and Default Access Levels (Visual Basic)

This topic describes which Visual Basic types can be declared within which other types, and what their access levels default to if not specified.  
  
## Declaration Context Levels  

 The *declaration context* of a programming element is the region of code in which it is declared. This is often another programming element, which is then called the *containing element*.  
  
 The levels for declaration contexts are the following:  
  
- *Namespace level* — within a source file or namespace but not within a class, structure, module, or interface  
  
- *Module level* — within a class, structure, module, or interface but not within a procedure or block  
  
- *Procedure level* — within a procedure or block (such as `If` or `For`)  
  
 The following table shows the default access levels for various declared programming elements, depending on their declaration contexts.  
  
|Declared element|Namespace level|Module level|Procedure level|  
|----------------------|---------------------|------------------|---------------------|  
|Variable ([Dim Statement](dim-statement.md))|Not allowed|`Private` (`Public` in `Structure`, not allowed in `Interface`)|`Public`|  
|Constant ([Const Statement](const-statement.md))|Not allowed|`Private` (`Public` in `Structure`, not allowed in `Interface`)|`Public`|  
|Enumeration ([Enum Statement](enum-statement.md))|`Friend`|`Public`|Not allowed|  
|Class ([Class Statement](class-statement.md))|`Friend`|`Public`|Not allowed|  
|Structure ([Structure Statement](structure-statement.md))|`Friend`|`Public`|Not allowed|  
|Module ([Module Statement](module-statement.md))|`Friend`|Not allowed|Not allowed|  
|Interface ([Interface Statement](interface-statement.md))|`Friend`|`Public`|Not allowed|  
|Procedure ([Function Statement](function-statement.md), [Sub Statement](sub-statement.md))|Not allowed|`Public`|Not allowed|  
|External reference ([Declare Statement](declare-statement.md))|Not allowed|`Public` (not allowed in `Interface`)|Not allowed|  
|Operator ([Operator Statement](operator-statement.md))|Not allowed|`Public` (not allowed in `Interface` or `Module`)|Not allowed|  
|Property ([Property Statement](property-statement.md))|Not allowed|`Public`|Not allowed|  
|Default property ([Default](../modifiers/default.md))|Not allowed|`Public` (not allowed in `Module`)|Not allowed|  
|Event ([Event Statement](event-statement.md))|Not allowed|`Public`|Not allowed|  
|Delegate ([Delegate Statement](delegate-statement.md))|`Friend`|`Public`|Not allowed|  
  
 For more information, see [Access levels in Visual Basic](../../programming-guide/language-features/declared-elements/access-levels.md).  
  
## See also

- [Friend](../modifiers/friend.md)
- [Private](../modifiers/private.md)
- [Public](../modifiers/public.md)
