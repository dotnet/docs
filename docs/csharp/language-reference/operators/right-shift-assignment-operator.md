---
title: "&gt;&gt;= operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - ">>=_CSharpKeyword"
helpviewer_keywords: 
  - "right shift assignment operator (>>=) [C#]"
  - ">>= operator (right-shift assignment) [C#]"
ms.assetid: b593778c-b9b4-440d-8b29-c1ac22cb81c0
---
# &gt;&gt;= operator (C# Reference)

The right-shift assignment operator.

## Remarks

An expression of the form

```csharp
x >>= y
```

is evaluated as

```csharp
x = x >> y
```

except that `x` is only evaluated once. The [>> operator](right-shift-operator.md) shifts `x` right by an amount specified by `y`.

The >>= operator cannot be overloaded directly, but user-defined types can overload the [>> operator](right-shift-operator.md) (see [operator](../keywords/operator.md)).

## Example

[!code-csharp[csRefOperators#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#11)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# operators](index.md)