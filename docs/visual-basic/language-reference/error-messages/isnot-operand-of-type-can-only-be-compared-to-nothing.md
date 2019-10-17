---
title: "'IsNot' operand of type 'typename' can only be compared to 'Nothing', because 'typename' is a nullable type"
ms.date: 07/20/2015
f1_keywords:
  - "bc32128"
  - "vbc32128"
helpviewer_keywords:
  - "BC32128"
ms.assetid: 1155b23a-ad75-4bab-b9da-73f35c767a36
---
# 'IsNot' operand of type 'typename' can only be compared to 'Nothing', because 'typename' is a nullable type

A variable declared as nullable has been compared to an expression other than `Nothing` using the `IsNot` operator.

**Error ID:** BC32128

## To correct this error

To compare a nullable type to an expression other than `Nothing` by using the `IsNot` operator, call the `GetType` method on the nullable type and compare the result to the expression, as shown in the following example.

```vb
Dim number? As Integer = 5

If number IsNot Nothing Then
  If number.GetType() IsNot Type.GetType("System.Int32") Then

  End If
End If
```

## See also

- [Nullable Value Types](../../../visual-basic/programming-guide/language-features/data-types/nullable-value-types.md)
- [IsNot Operator](../../../visual-basic/language-reference/operators/isnot-operator.md)
