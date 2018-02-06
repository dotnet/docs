---
title: "Operator Precedence in Visual Basic"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "arithmetic operators [Visual Basic], precedence"
  - "operator precedence"
  - "logical operators [Visual Basic], precedence"
  - "operators [Visual Basic], associativity"
  - "operators [Visual Basic], resolution"
  - "associativity of operators [Visual Basic]"
  - "operators [Visual Basic], precedence"
  - "precedence [Visual Basic], of operators"
  - "comparison operators [Visual Basic], precedence"
  - "math operators [Visual Basic]"
  - "order of precedence"
ms.assetid: cbbdb282-f572-458e-a520-008a675f8063
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Operator Precedence in Visual Basic
When several operations occur in an expression, each part is evaluated and resolved in a predetermined order called *operator precedence*.  
  
## Precedence Rules  
 When expressions contain operators from more than one category, they are evaluated according to the following rules:  
  
-   The arithmetic and concatenation operators have the order of precedence described in the following section, and all have greater precedence than the comparison, logical, and bitwise operators.  
  
-   All comparison operators have equal precedence, and all have greater precedence than the logical and bitwise operators, but lower precedence than the arithmetic and concatenation operators.  
  
-   The logical and bitwise operators have the order of precedence described in the following section, and all have lower precedence than the arithmetic, concatenation, and comparison operators.  
  
-   Operators with equal precedence are evaluated left to right in the order in which they appear in the expression.  
  
## Precedence Order  
 Operators are evaluated in the following order of precedence:  
  
### Await Operator  
 Await  
  
### Arithmetic and Concatenation Operators  
 Exponentiation (`^`)  
  
 Unary identity and negation (`+`, `–`)  
  
 Multiplication and floating-point division (`*`, `/`)  
  
 Integer division (`\`)  
  
 Modulus arithmetic (`Mod`)  
  
 Addition and subtraction (`+`, `–`)  
  
 String concatenation (`&`)  
  
 Arithmetic bit shift (`<<`, `>>`)  
  
### Comparison Operators  
 All comparison operators (`=`, `<>`, `<`, `<=`, `>`, `>=`, `Is`, `IsNot`, `Like`, `TypeOf`...`Is`)  
  
### Logical and Bitwise Operators  
 Negation (`Not`)  
  
 Conjunction (`And`, `AndAlso`)  
  
 Inclusive disjunction (`Or`, `OrElse`)  
  
 Exclusive disjunction (`Xor`)  
  
### Comments  
 The `=` operator is only the equality comparison operator, not the assignment operator.  
  
 The string concatenation operator (`&`) is not an arithmetic operator, but in precedence it is grouped with the arithmetic operators.  
  
 The `Is` and `IsNot` operators are object reference comparison operators. They do not compare the values of two objects; they check only to determine whether two object variables refer to the same object instance.  
  
## Associativity  
 When operators of equal precedence appear together in an expression, for example multiplication and division, the compiler evaluates each operation as it encounters it from left to right. The following example illustrates this.  
  
```  
Dim n1 As Integer = 96 / 8 / 4  
Dim n2 As Integer = (96 / 8) / 4  
Dim n3 As Integer = 96 / (8 / 4)  
```  
  
 The first expression evaluates the division 96 / 8 (which results in 12) and then the division 12 / 4, which results in three. Because the compiler evaluates the operations for `n1` from left to right, the evaluation is the same when that order is explicitly indicated for `n2`. Both `n1` and `n2` have a result of three. By contrast, `n3` has a result of 48, because the parentheses force the compiler to evaluate 8 / 4 first.  
  
 Because of this behavior, operators are said to be *left associative* in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)].  
  
## Overriding Precedence and Associativity  
 You can use parentheses to force some parts of an expression to be evaluated before others. This can override both the order of precedence and the left associativity. [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] always performs operations that are enclosed in parentheses before those outside. However, within parentheses, it maintains ordinary precedence and associativity, unless you use parentheses within the parentheses. The following example illustrates this.  
  
```  
Dim a, b, c, d, e, f, g As Double  
a = 8.0  
b = 3.0  
c = 4.0  
d = 2.0  
e = 1.0  
f = a - b + c / d * e  
' The preceding line sets f to 7.0. Because of natural operator   
' precedence and associativity, it is exactly equivalent to the   
' following line.  
f = (a - b) + ((c / d) * e)  
' The following line overrides the natural operator precedence   
' and left associativity.  
g = (a - (b + c)) / (d * e)  
' The preceding line sets g to 0.5.  
```  
  
## See Also  
 [= Operator](../../../visual-basic/language-reference/operators/assignment-operator.md)  
 [Is Operator](../../../visual-basic/language-reference/operators/is-operator.md)  
 [IsNot Operator](../../../visual-basic/language-reference/operators/isnot-operator.md)  
 [Like Operator](../../../visual-basic/language-reference/operators/like-operator.md)  
 [TypeOf Operator](../../../visual-basic/language-reference/operators/typeof-operator.md)  
 [Await Operator](../../../visual-basic/language-reference/operators/await-operator.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Operators and Expressions](../../../visual-basic/programming-guide/language-features/operators-and-expressions/index.md)
