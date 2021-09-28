---
description: "Learn more about: How to: Test Whether Two Objects Are the Same (Visual Basic)"
title: "How to: Test Whether Two Objects Are the Same"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "variables [Visual Basic], reference"
  - "Is operator [Visual Basic], comparing objects"
  - "reference variables [Visual Basic]"
  - "variables [Visual Basic], referring to same object"
  - "objects [Visual Basic], variables referring to same"
  - "Visual Basic code, operators"
ms.assetid: f760e828-8704-4256-bc2d-c22a4c93b524
---
# How to: Test Whether Two Objects Are the Same (Visual Basic)

If you have two variables that refer to objects, you can use either the `Is` or `IsNot` operator, or both, to determine whether they refer to the same instance.  
  
### To test whether two objects are the same  
  
- Use the [Is Operator](../../../language-reference/operators/is-operator.md) or the [IsNot Operator](../../../language-reference/operators/isnot-operator.md) with the two variables as operands.  
  
     [!code-vb[VbVbalrOperators#69](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#69)]  
  
 You might want to take a certain action depending on whether two objects refer to the same instance. The preceding example compares control `c` against the active control on form `f`. If there is no active control, or if there is one but it is not the same control instance as `c`, then the `If` statement fails and the procedure returns without further processing.  
  
 Whether you use `Is` or `IsNot` is a matter of personal convenience to you. One might be easier to read than the other in a given expression.  
  
## See also

- [Comparison Operators in Visual Basic](comparison-operators.md)
