---
description: "Learn more about: Is operator (Visual Basic)"
title: Is operator
ms.date: 07/20/2015
f1_keywords: 
  - "vb.is"
helpviewer_keywords: 
  - "comparison operators [Visual Basic]"
  - "equivalent objects"
  - "TypeOf...Is expression"
  - "Is operator [Visual Basic]"
ms.assetid: 8045a6c8-2a83-45b6-ad47-d09a704c656d
---
# Is operator (Visual Basic)

Compares two object reference variables.

## Syntax

```vb
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

> [!NOTE]
> The `Is` keyword is also used in the [Select...Case Statement](../statements/select-case-statement.md).
  
## Example

The following example uses the `Is` operator to compare pairs of object references. The results are assigned to a `Boolean` value representing whether the two objects are identical.

[!code-vb[VbVbalrOperators#27](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#27)]

As the preceding example demonstrates, you can use the `Is` operator to test both early bound and late bound objects.

## Use TypeOf operator with Is operator

`Is` operator can also be used with the `TypeOf` keyword to make a `TypeOf`...`Is` expression, which tests whether an object variable is compatible with a data type. For example:

```vb
If TypeOf sender Is Button Then
```

## See also

- [TypeOf Operator](typeof-operator.md)
- [IsNot Operator](isnot-operator.md)
- [Comparison Operators in Visual Basic](../../programming-guide/language-features/operators-and-expressions/comparison-operators.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [Operators Listed by Functionality](operators-listed-by-functionality.md)
- [Operators and Expressions](../../programming-guide/language-features/operators-and-expressions/index.md)
