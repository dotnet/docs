---
title: "Is Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.is"
helpviewer_keywords: 
  - "comparison operators [Visual Basic]"
  - "equivalent objects"
  - "TypeOf...Is expression"
  - "Is operator [Visual Basic]"
ms.assetid: 8045a6c8-2a83-45b6-ad47-d09a704c656d
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
---
# Is Operator (Visual Basic)
Compares two object reference variables.  
  
## Syntax  
  
```  
result = object1 Is object2  
```  
  
## Parts  
 `result`  
 Required. Any `Boolean` value.  
  
 `object1`  
 Required. Any `Object` name.  
  
 `object2`  
 Required. Any `Object` name.  
  
## Remarks  
 The `Is` operator determines if two object references refer to the same object. However, it does not perform value comparisons. If `object1` and `object2` both refer to the exact same object instance, `result` is `True`; if they do not, `result` is `False`.  
  
 `Is` can also be used with the `TypeOf` keyword to make a `TypeOf`...`Is` expression, which tests whether an object variable is compatible with a data type.  
  
> [!NOTE]
>  The `Is` keyword is also used in the [Select...Case Statement](../../../visual-basic/language-reference/statements/select-case-statement.md).  
  
## Example  
 The following example uses the `Is` operator to compare pairs of object references. The results are assigned to a `Boolean` value representing whether the two objects are identical.  
  
 [!code-vb[VbVbalrOperators#27](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/is-operator_1.vb)]  
  
 As the preceding example demonstrates, you can use the `Is` operator to test both early bound and late bound objects.  
  
## See Also  
 [TypeOf Operator](../../../visual-basic/language-reference/operators/typeof-operator.md)  
 [IsNot Operator](../../../visual-basic/language-reference/operators/isnot-operator.md)  
 [Comparison Operators in Visual Basic](../../../visual-basic/programming-guide/language-features/operators-and-expressions/comparison-operators.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [Operators Listed by Functionality](../../../visual-basic/language-reference/operators/operators-listed-by-functionality.md)  
 [Operators and Expressions](../../../visual-basic/programming-guide/language-features/operators-and-expressions/index.md)
