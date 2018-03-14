---
title: "How to: Determine Whether Two Objects Are Identical (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "testing [Visual Basic], objects"
  - "objects [Visual Basic], comparing"
  - "object variables [Visual Basic], determining identity"
ms.assetid: 7829f817-0d1f-4749-a707-de0b95e0cf5c
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Determine Whether Two Objects Are Identical (Visual Basic)
In [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)], two variable references are considered identical if their pointers are the same, that is, if both variables point to the same class instance in memory. For example, in a Windows Forms application, you might want to make a comparison to determine whether the current instance (`Me`) is the same as a particular instance, such as `Form2`.  
  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] provides two operators to compare pointers. The [Is Operator](../../../../visual-basic/language-reference/operators/is-operator.md) returns `True` if the objects are identical, and the [IsNot Operator](../../../../visual-basic/language-reference/operators/isnot-operator.md) returns `True` if they are not.  
  
## Determining if Two Objects Are Identical  
  
#### To determine if two objects are identical  
  
1.  Set up a `Boolean` expression to test the two objects.  
  
2.  In your testing expression, use the `Is` operator with the two objects as operands.  
  
     `Is` returns `True` if the objects point to the same class instance.  
  
## Determining if Two Objects Are Not Identical  
 Sometimes you want to perform an action if the two objects are not identical, and it can be awkward to combine `Not` and `Is`, for example `If Not obj1 Is obj2`. In such a case you can use the `IsNot` operator.  
  
#### To determine if two objects are not identical  
  
1.  Set up a `Boolean` expression to test the two objects.  
  
2.  In your testing expression, use the `IsNot` operator with the two objects as operands.  
  
     `IsNot` returns `True` if the objects do not point to the same class instance.  
  
## Example  
 The following example tests pairs of `Object` variables to see if they point to the same class instance.  
  
 [!code-vb[VbVbalrKeywords#14](../../../../visual-basic/language-reference/codesnippet/VisualBasic/how-to-determine-whether-two-objects-are-identical_1.vb)]  
  
 The preceding example displays the following output.  
  
 `objA different from objB? True`  
  
 `objA identical to objC? True`  
  
## See Also  
 [Object Data Type](../../../../visual-basic/language-reference/data-types/object-data-type.md)  
 [Object Variables](../../../../visual-basic/programming-guide/language-features/variables/object-variables.md)  
 [Object Variable Values](../../../../visual-basic/programming-guide/language-features/variables/object-variable-values.md)  
 [Is Operator](../../../../visual-basic/language-reference/operators/is-operator.md)  
 [IsNot Operator](../../../../visual-basic/language-reference/operators/isnot-operator.md)  
 [How to: Determine Whether Two Objects Are Related](../../../../visual-basic/programming-guide/language-features/variables/how-to-determine-whether-two-objects-are-related.md)  
 [Me, My, MyBase, and MyClass](../../../../visual-basic/programming-guide/program-structure/me-my-mybase-and-myclass.md)
