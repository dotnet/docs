---
title: "User-Defined Constants (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "constants [Visual Basic], circular references"
  - "Const statement [Visual Basic], user-defined constants"
  - "user-defined constants [Visual Basic]"
  - "scope [Visual Basic], constants"
  - "constants [Visual Basic], user-defined"
  - "circular references between constants [Visual Basic]"
ms.assetid: a1206d5c-c45e-4ac2-970a-4a0be6a05fdd
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# User-Defined Constants (Visual Basic)
A constant is a meaningful name that takes the place of a number or string that does not change. Constants store values that, as the name implies, remain constant throughout the execution of an application. You can use constants that are defined by the controls or components you work with, or you can create your own. Constants you create yourself are described as *user-defined*.  
  
 You declare a constant with the `Const` statement, using the same guidelines you would for creating a variable name. If `Option Strict` is `On`, you must explicitly declare the constant type.  
  
## Const Statement Usage  
 A `Const` statement can represent a mathematical or date/time quantity:  
  
 [!code-vb[VbEnumsTask#10](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/user-defined-constants_1.vb)]  
  
 It also can define `String` constants:  
  
 [!code-vb[VbEnumsTask#13](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/user-defined-constants_2.vb)]  
  
 The expression on the right side of the equal sign ( `=` ) is often a number or literal string, but it also can be an expression that results in a number or string (although that expression cannot contain calls to functions). You can even define constants in terms of previously defined constants:  
  
 [!code-vb[VbEnumsTask#15](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/user-defined-constants_3.vb)]  
  
## Scope of User-Defined Constants  
 A `Const` statement's scope is the same as that of a variable declared in the same location. You can specify scope in any of the following ways:  
  
-   To create a constant that exists only within a procedure, declare it within that procedure.  
  
-   To create a constant available to all procedures within a class, but not to any code outside that module, declare it in the declarations section of the class.  
  
-   To create a constant that is available to all members of an assembly, but not to outside clients of the assembly, declare it using the `Friend` keyword in the declarations section of the class.  
  
-   To create a constant available throughout the application, declare it using the `Public` keyword in the declarations section the class.  
  
 For more information, see [How to: Declare A Constant](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-a-constant.md).  
  
### Avoiding Circular References  
 Because constants can be defined in terms of other constants, it is possible to inadvertently create a *cycle*, or circular reference, between two or more constants. A cycle occurs when you have two or more public constants, each of which is defined in terms of the other, as in the following example:  
  
 [!code-vb[VbEnumsTask#16](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/user-defined-constants_4.vb)]  
[!code-vb[VbEnumsTask#17](../../../../visual-basic/language-reference/statements/codesnippet/VisualBasic/user-defined-constants_5.vb)]  
  
 If a cycle occurs, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] generates a compiler error.  
  
## See Also  
 [Const Statement](../../../../visual-basic/language-reference/statements/const-statement.md)  
 [Constant and Literal Data Types](../../../../visual-basic/programming-guide/language-features/constants-enums/constant-and-literal-data-types.md)  
 [Constants and Enumerations](../../../../visual-basic/programming-guide/language-features/constants-enums/index.md)  
 [Constants and Enumerations](../../../../visual-basic/language-reference/constants-and-enumerations.md)  
 [Enumerations Overview](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-overview.md)  
 [Constants Overview](../../../../visual-basic/programming-guide/language-features/constants-enums/constants-overview.md)  
 [How to: Declare an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-enumerations.md)  
 [Enumerations and Name Qualification](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-and-name-qualification.md)  
 [Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)
