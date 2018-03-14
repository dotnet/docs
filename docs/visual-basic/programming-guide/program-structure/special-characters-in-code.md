---
title: "Special Characters in Code (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.)"
  - "vb.("
  - "vb.colon"
  - "vb.!"
  - "vb.."
  - "vb.:"
helpviewer_keywords: 
  - "special characters [Visual Basic], in code"
  - "parentheses [Visual Basic], using in code"
  - "colons (:)"
  - "period character in code"
  - "dot operator (.)"
  - "dictionary access operator [Visual Basic]"
  - "concatenation operators [Visual Basic], special characters in code"
  - "concatenation operators [Visual Basic], vs. addition operator"
  - "! operator"
  - "separators [Visual Basic], using in code"
  - "operators [Visual Basic], dictionary access"
  - ": separator character"
  - "member access operator [Visual Basic]"
  - "addition operator [Visual Basic]"
  - "operators [Visual Basic], member access"
  - ". operator"
  - "exclamation points"
  - "separators"
  - "exclamation point operator (!)"
  - "Visual Basic code, special characters"
ms.assetid: 310dce0c-45b5-4e0d-83e9-32df258d2a3e
caps.latest.revision: 21
author: dotnet-bot
ms.author: dotnetcontent
---
# Special Characters in Code (Visual Basic)
Sometimes you have to use special characters in your code, that is, characters that are not alphabetical or numeric. The punctuation and special characters in the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] character set have various uses, from organizing program text to defining the tasks that the compiler or the compiled program performs. They do not specify an operation to be performed.  
  
## Parentheses  
 Use parentheses when you define a procedure, such as a `Sub` or `Function`. You must enclose all procedure argument lists in parentheses. You also use parentheses for putting variables or arguments into logical groups, especially to override the default order of operator precedence in a complex expression. The following example illustrates this.  
  
 [!code-vb[VbVbcnConventions#11](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/special-characters-in-code_1.vb)]  
  
 Following execution of the previous code, the value of `d` is 8.225 and the value of `e` is 3. The calculation for `d` uses the default precedence of `/` over `+` and is equivalent to `d = b + (c / a)`. The parentheses in the calculation for `e` override the default precedence.  
  
## Separators  
 Separators do what their name suggests: they separate sections of code. In [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], the separator character is the colon (`:`). Use separators when you want to include multiple statements on a single line instead of separate lines. This saves space and improves the readability of your code. The following example shows three statements separated by colons.  
  
 [!code-vb[VbVbcnConventions#12](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/special-characters-in-code_2.vb)]  
  
 For more information, see [How to: Break and Combine Statements in Code](../../../visual-basic/programming-guide/program-structure/how-to-break-and-combine-statements-in-code.md).  
  
 The colon (`:`) character is also used to identify a statement label. For more information, see [How to: Label Statements](../../../visual-basic/programming-guide/program-structure/how-to-label-statements.md).  
  
## Concatenation  
 Use the `&` operator for *concatenation*, or linking strings together. Do not confuse it with the `+` operator, which adds together numeric values. If you use the `+` operator to concatenate when you operate on numeric values, you can obtain incorrect results. The following example demonstrates this.  
  
 [!code-vb[VbVbcnConventions#13](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/special-characters-in-code_3.vb)]  
  
 Following execution of the previous code, the value of `resultA` is 21.01 and the value of `resultB` is "10.0111".  
  
## Member Access Operators  
 To access a member of a type, you use the dot (`.`) or exclamation point (`!`) operator between the type name and the member name.  
  
### Dot (.) Operator  
 Use the `.` operator on a class, structure, interface, or enumeration as a member access operator. The member can be a field, property, event, or method. The following example illustrates this.  
  
 [!code-vb[VbVbcnConventions#14](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/special-characters-in-code_4.vb)]  
  
### Exclamation Point (!) Operator  
 Use the `!` operator only on a class or interface as a dictionary access operator. The class or interface must have a default property that accepts a single `String` argument. The identifier immediately following the `!` operator becomes the argument value passed to the default property as a string. The following example demonstrates this.  
  
 [!code-vb[VbVbcnConventions#15](../../../visual-basic/programming-guide/language-features/codesnippet/VisualBasic/special-characters-in-code_5.vb)]  
  
 The three output lines of `MsgBox` all display the value `32856`. The first line uses the traditional access to property `index`, the second makes use of the fact that `index` is the default property of class `hasDefault`, and the third uses dictionary access to the class.  
  
 Note that the second operand of the `!` operator must be a valid Visual Basic identifier not enclosed in double quotation marks (`" "`). In other words, you cannot use a string literal or string variable. The following change to the last line of the `MsgBox` call generates an error because `"X"` is an enclosed string literal.  
  
 `"Dictionary access returns " & hD!"X")`  
  
> [!NOTE]
>  References to default collections must be explicit. In particular, you cannot use the `!` operator on a late-bound variable.  
  
 The `!` character is also used as the `Single` type character.  
  
## See Also  
 [Program Structure and Code Conventions](../../../visual-basic/programming-guide/program-structure/program-structure-and-code-conventions.md)  
 [Type Characters](../../../visual-basic/programming-guide/language-features/data-types/type-characters.md)
