---
title: "'Is' requires operands that have reference types, but this operand has the value type '<typename>'"
ms.date: 07/20/2015
f1_keywords: 
  - "bc30020"
  - "vbc30020"
helpviewer_keywords: 
  - "BC30020"
ms.assetid: 228afebd-1203-4bd3-8d7a-c5c56f3cedc4
---
# 'Is' requires operands that have reference types, but this operand has the value type '\<typename>'
The `Is` comparison operator determines whether two object variables refer to the same instance. This comparison is not defined for value types.  
  
 **Error ID:** BC30020  
  
## To correct this error  
  
- Use the appropriate arithmetic comparison operator or the `Like` operator to compare two value types.  
  
## See also

- [Is Operator](../../../visual-basic/language-reference/operators/is-operator.md)
- [Like Operator](../../../visual-basic/language-reference/operators/like-operator.md)
- [Comparison Operators](../../../visual-basic/language-reference/operators/comparison-operators.md)
