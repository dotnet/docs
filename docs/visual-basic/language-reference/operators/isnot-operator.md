---
title: "IsNot Operator (Visual Basic)"
ms.date: 07/20/2015
f1_keywords: 
  - "vb.isnot"
helpviewer_keywords: 
  - "IsNot operator [Visual Basic]"
ms.assetid: 8dd2bcdb-0166-48a2-9094-60dfb448f36c
---
# IsNot Operator (Visual Basic)

Compares two object reference variables.

## Syntax

```vb
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

## Example
 The following code example uses both the `Is` operator and the `IsNot` operator to accomplish the same comparison.

 [!code-vb[VbVbalrOperators#29](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbalrOperators/VB/Class1.vb#29)]

## See also

- [Is Operator](is-operator.md)
- [TypeOf Operator](typeof-operator.md)
- [Operator Precedence in Visual Basic](operator-precedence.md)
- [How to: Test Whether Two Objects Are the Same](../../programming-guide/language-features/operators-and-expressions/how-to-test-whether-two-objects-are-the-same.md)
