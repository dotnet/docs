---
description: "Learn more about: How to: Determine Whether Two Objects Are Identical (Visual Basic)"
title: "How to: Determine Whether Two Objects Are Identical"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "testing [Visual Basic], objects"
  - "objects [Visual Basic], comparing"
  - "object variables [Visual Basic], determining identity"
ms.assetid: 7829f817-0d1f-4749-a707-de0b95e0cf5c
---
# How to: Determine Whether Two Objects Are Identical (Visual Basic)

In Visual Basic, two variable references are considered identical if their pointers are the same, that is, if both variables point to the same class instance in memory. For example, in a Windows Forms application, you might want to make a comparison to determine whether the current instance (`Me`) is the same as a particular instance, such as `Form2`.  
  
 Visual Basic provides two operators to compare pointers. The [Is Operator](../../../language-reference/operators/is-operator.md) returns `True` if the objects are identical, and the [IsNot Operator](../../../language-reference/operators/isnot-operator.md) returns `True` if they are not.  
  
## Determining if Two Objects Are Identical  
  
#### To determine if two objects are identical  
  
1. Set up a `Boolean` expression to test the two objects.  
  
2. In your testing expression, use the `Is` operator with the two objects as operands.  
  
     `Is` returns `True` if the objects point to the same class instance.  
  
## Determining if Two Objects Are Not Identical  

 Sometimes you want to perform an action if the two objects are not identical, and it can be awkward to combine `Not` and `Is`, for example `If Not obj1 Is obj2`. In such a case you can use the `IsNot` operator.  
  
#### To determine if two objects are not identical  
  
1. Set up a `Boolean` expression to test the two objects.  
  
2. In your testing expression, use the `IsNot` operator with the two objects as operands.  
  
     `IsNot` returns `True` if the objects do not point to the same class instance.  
  
## Example  

 The following example tests pairs of `Object` variables to see if they point to the same class instance.  
  
 [!code-vb[VbVbalrKeywords#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrKeywords/VB/class7.vb#14)]  
  
 The preceding example displays the following output.  
  
 `objA different from objB? True`  
  
 `objA identical to objC? True`  
  
## See also

- [Object Data Type](../../../language-reference/data-types/object-data-type.md)
- [Object Variables](object-variables.md)
- [Object Variable Values](object-variable-values.md)
- [Is Operator](../../../language-reference/operators/is-operator.md)
- [IsNot Operator](../../../language-reference/operators/isnot-operator.md)
- [How to: Determine Whether Two Objects Are Related](how-to-determine-whether-two-objects-are-related.md)
- [Me, My, MyBase, and MyClass](../../program-structure/me-my-mybase-and-myclass.md)
