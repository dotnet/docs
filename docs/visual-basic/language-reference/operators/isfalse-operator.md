---
title: "IsFalse Operator"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.isfalse"
helpviewer_keywords: 
  - "AndAlso operator [Visual Basic]"
  - "IsFalse operator [Visual Basic]"
ms.assetid: 37fc9dbf-e5cc-4570-b93f-7213447974df
---
# IsFalse Operator (Visual Basic)
Determines whether an expression is `False`.  
  
 You cannot call `IsFalse` explicitly in your code, but the Visual Basic compiler can use it to generate code from `AndAlso` clauses. If you define a class or structure and then use a variable of that type in an `AndAlso` clause, you must define `IsFalse` on that class or structure.  
  
 The compiler considers the `IsFalse` and `IsTrue` operators as a *matched pair*. This means that if you define one of them, you must also define the other one.  
  
> [!NOTE]
> The `IsFalse` operator can be *overloaded*, which means that a class or structure can redefine its behavior when its operand has the type of that class or structure. If your code uses this operator on such a class or structure, be sure you understand its redefined behavior. For more information, see [Operator Procedures](../../../visual-basic/programming-guide/language-features/procedures/operator-procedures.md).  
  
## Example  
 The following code example defines the outline of a structure that includes definitions for the `IsFalse` and `IsTrue` operators.  
  
 [!code-vb[VbVbalrOperators#28](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#28)]  
  
## See also

- [IsTrue Operator](../../../visual-basic/language-reference/operators/istrue-operator.md)
- [How to: Define an Operator](../../../visual-basic/programming-guide/language-features/procedures/how-to-define-an-operator.md)
- [AndAlso Operator](../../../visual-basic/language-reference/operators/andalso-operator.md)
