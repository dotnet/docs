---
title: "-= operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "-=_CSharpKeyword"
helpviewer_keywords: 
  - "subtraction assignment operator (-=) [C#]"
  - "-= operator (subtraction assignment ) [C#]"
ms.assetid: 05c7d68a-423f-4de8-891b-cf24e8fb6ed7
---
# -= operator (C# Reference)

The subtraction assignment operator.

## Remarks

An expression using the `-=` assignment operator, such as

```csharp
x -= y
```

 is equivalent to

```csharp
x = x - y
```

except that `x` is only evaluated once. The meaning of the [- operator](subtraction-operator.md) is dependent on the types of `x` and `y` (subtraction for numeric operands, delegate removal for delegate operands, and so forth).

The `-=` operator cannot be overloaded directly, but user-defined types can overload the [- operator](subtraction-operator.md) (see [operator](../keywords/operator.md)).

The -= operator is also used in C# to unsubscribe from an event. For more information, see [How to: Subscribe to and Unsubscribe from Events](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

## Example

[!code-csharp[csRefOperators#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#6)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# operators](index.md)
