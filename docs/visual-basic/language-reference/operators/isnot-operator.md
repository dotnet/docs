---
title: "IsNot Operator (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.isnot"
helpviewer_keywords: 
  - "IsNot operator [Visual Basic]"
ms.assetid: 8dd2bcdb-0166-48a2-9094-60dfb448f36c
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# IsNot Operator (Visual Basic)
Compares two object reference variables.  
  
## Syntax  
  
```  
result = object1 IsNot object2  
```  
  
## Parts  
 `result`  
 Required. A `Boolean` value.  
  
 `object1`  
 Required. Any `Object` variable or expression.  
  
 `object2`  
 Required. Any `Object` variable or expression.  
  
## Remarks  
 The `IsNot` operator determines if two object references refer to different objects. However, it does not perform value comparisons. If `object1` and `object2` both refer to the exact same object instance, `result` is `False`; if they do not, `result` is `True`.  
  
 `IsNot` is the opposite of the `Is` operator. The advantage of `IsNot` is that you can avoid awkward syntax with `Not` and `Is`, which can be difficult to read.  
  
 You can use the `Is` and `IsNot` operators to test both early-bound and late-bound objects.  
  
> [!NOTE]
>  The `IsNot` operator cannot be used to compare expressions returned from the `TypeOf` operator. Instead, you must use the `Not` and `Is` operators.  
  
## Example  
 The following code example uses both the `Is` operator and the `IsNot` operator to accomplish the same comparison.  
  
 [!code-vb[VbVbalrOperators#29](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/isnot-operator_1.vb)]  
  
## See Also  
 [Is Operator](../../../visual-basic/language-reference/operators/is-operator.md)  
 [TypeOf Operator](../../../visual-basic/language-reference/operators/typeof-operator.md)  
 [Operator Precedence in Visual Basic](../../../visual-basic/language-reference/operators/operator-precedence.md)  
 [How to: Test Whether Two Objects Are the Same](../../../visual-basic/programming-guide/language-features/operators-and-expressions/how-to-test-whether-two-objects-are-the-same.md)
