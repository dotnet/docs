---
title: "<<= operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "<<=_CSharpKeyword"
helpviewer_keywords: 
  - "<<= operator (left-shift assignment) [C#]"
  - "left shift assignment operator (<<=) [C#]"
ms.assetid: 3bc99c78-1edb-4827-86fc-bce6c3048871
---
# \<\<= operator (C# Reference)

The left-shift assignment operator.

## Remarks

An expression of the form

```csharp
x <<= y
```

is evaluated as

```csharp
x = x << y
```

except that `x` is only evaluated once. The [<< operator](left-shift-operator.md) shifts `x` left by the number of bits specified by `y`.

The `<<=` operator cannot be overloaded directly, but user-defined types can overload the [<< operator](left-shift-operator.md) (see [operator](../keywords/operator.md)).

## Example

[!code-csharp[csRefOperators#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#12)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
