---
title: "User-Defined Constants (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "constants [Visual Basic], circular references"
  - "Const statement [Visual Basic], user-defined constants"
  - "user-defined constants [Visual Basic]"
  - "scope [Visual Basic], constants"
  - "constants [Visual Basic], user-defined"
  - "circular references between constants [Visual Basic]"
ms.assetid: a1206d5c-c45e-4ac2-970a-4a0be6a05fdd
---
# User-Defined Constants (Visual Basic)
A constant is a meaningful name that takes the place of a number or string that does not change. Constants store values that, as the name implies, remain constant throughout the execution of an application. You can use constants that are defined by the controls or components you work with, or you can create your own. Constants you create yourself are described as *user-defined*.  
  
 You declare a constant with the `Const` statement, using the same guidelines you would for creating a variable name. If `Option Strict` is `On`, you must explicitly declare the constant type.  
  
## Const Statement Usage  
 A `Const` statement can represent a mathematical or date/time quantity:  
  
 [!code-vb[VbEnumsTask#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#10)]  
  
 It also can define `String` constants:  
  
 [!code-vb[VbEnumsTask#13](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#13)]  
  
 The expression on the right side of the equal sign ( `=` ) is often a number or literal string, but it also can be an expression that results in a number or string (although that expression cannot contain calls to functions). You can even define constants in terms of previously defined constants:  
  
 [!code-vb[VbEnumsTask#15](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#15)]  
  
## Scope of User-Defined Constants  
 A `Const` statement's scope is the same as that of a variable declared in the same location. You can specify scope in any of the following ways:  
  
-   To create a constant that exists only within a procedure, declare it within that procedure.  
  
-   To create a constant available to all procedures within a class, but not to any code outside that module, declare it in the declarations section of the class.  
  
-   To create a constant that is available to all members of an assembly, but not to outside clients of the assembly, declare it using the `Friend` keyword in the declarations section of the class.  
  
-   To create a constant available throughout the application, declare it using the `Public` keyword in the declarations section the class.  
  
 For more information, see [How to: Declare A Constant](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-a-constant.md).  
  
### Avoiding Circular References  
 Because constants can be defined in terms of other constants, it is possible to inadvertently create a *cycle*, or circular reference, between two or more constants. A cycle occurs when you have two or more public constants, each of which is defined in terms of the other, as in the following example:  
  
 [!code-vb[VbEnumsTask#16](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#16)]  
[!code-vb[VbEnumsTask#17](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbEnumsTask/VB/Class2.vb#17)]  
  
 If a cycle occurs, Visual Basic generates a compiler error.  
  
## See also

- [Const Statement](../../../../visual-basic/language-reference/statements/const-statement.md)
- [Constant and Literal Data Types](../../../../visual-basic/programming-guide/language-features/constants-enums/constant-and-literal-data-types.md)
- [Constants and Enumerations](../../../../visual-basic/programming-guide/language-features/constants-enums/index.md)
- [Constants and Enumerations](../../../../visual-basic/language-reference/constants-and-enumerations.md)
- [Enumerations Overview](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-overview.md)
- [Constants Overview](../../../../visual-basic/programming-guide/language-features/constants-enums/constants-overview.md)
- [How to: Declare an Enumeration](../../../../visual-basic/programming-guide/language-features/constants-enums/how-to-declare-enumerations.md)
- [Enumerations and Name Qualification](../../../../visual-basic/programming-guide/language-features/constants-enums/enumerations-and-name-qualification.md)
- [Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)
