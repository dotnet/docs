---
title: "IsTrue Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.istrue"
helpviewer_keywords: 
  - "IsTrue operator [Visual Basic]"
  - "OrElse operator [Visual Basic]"
ms.assetid: b6cec0f2-61b1-4331-a7f0-4d07ee3179d6
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# IsTrue Operator (Visual Basic)
Determines whether an expression is `True`.  
  
 You cannot call `IsTrue` explicitly in your code, but the Visual Basic compiler can use it to generate code from `OrElse` clauses. If you define a class or structure and then use a variable of that type in an `OrElse` clause, you must define `IsTrue` on that class or structure.  
  
 The compiler considers the `IsTrue` and `IsFalse` operators as a *matched pair*. This means that if you define one of them, you must also define the other one.  
  
## Compiler Use of IsTrue  
 When you have defined a class or structure, you can use a variable of that type in a `For`, `If`, `Else``If`, or `While` statement, or in a `When` clause. If you do this, the compiler requires an operator that converts your type into a `Boolean` value so it can test a condition. It searches for a suitable operator in the following order:  
  
1.  A widening conversion operator from your class or structure to `Boolean`.  
  
2.  A widening conversion operator from your class or structure to `Boolean?`.  
  
3.  The `IsTrue` operator on your class or structure.  
  
4.  A narrowing conversion to `Boolean?` that does not involve a conversion from `Boolean` to `Boolean?`.  
  
5.  A narrowing conversion operator from your class or structure to `Boolean`.  
  
 If you have not defined any conversion to `Boolean` or an `IsTrue` operator, the compiler signals an error.  
  
> [!NOTE]
>  The `IsTrue` operator can be *overloaded*, which means that a class or structure can redefine its behavior when its operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following code example defines the outline of a structure that includes definitions for the `IsFalse` and `IsTrue` operators.  
  
 [!code-vb[VbVbalrOperators#28](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/istrue-operator_1.vb)]  
  
## See Also  
 [IsFalse Operator](../../../visual-basic/language-reference/operators/isfalse-operator.md)  
 [How to: Define an Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-an-operator.md)  
 [OrElse Operator](../../../visual-basic/language-reference/operators/orelse-operator.md)
