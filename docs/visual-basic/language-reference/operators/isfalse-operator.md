---
title: "IsFalse Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.isfalse"
helpviewer_keywords: 
  - "AndAlso operator [Visual Basic]"
  - "IsFalse operator [Visual Basic]"
ms.assetid: 37fc9dbf-e5cc-4570-b93f-7213447974df
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
---
# IsFalse Operator (Visual Basic)
Determines whether an expression is `False`.  
  
 You cannot call `IsFalse` explicitly in your code, but the Visual Basic compiler can use it to generate code from `AndAlso` clauses. If you define a class or structure and then use a variable of that type in an `AndAlso` clause, you must define `IsFalse` on that class or structure.  
  
 The compiler considers the `IsFalse` and `IsTrue` operators as a *matched pair*. This means that if you define one of them, you must also define the other one.  
  
> [!NOTE]
>  The `IsFalse` operator can be *overloaded*, which means that a class or structure can redefine its behavior when its operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following code example defines the outline of a structure that includes definitions for the `IsFalse` and `IsTrue` operators.  
  
 [!code-vb[VbVbalrOperators#28](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/isfalse-operator_1.vb)]  
  
## See Also  
 [IsTrue Operator](../../../visual-basic/language-reference/operators/istrue-operator.md)  
 [How to: Define an Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-an-operator.md)  
 [AndAlso Operator](../../../visual-basic/language-reference/operators/andalso-operator.md)
