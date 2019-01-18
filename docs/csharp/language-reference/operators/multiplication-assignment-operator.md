---
title: "*= Operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "*=_CSharpKeyword"
helpviewer_keywords: 
  - "*= operator [C#]"
  - "binary multiplication assignment operator (*=) [C#]"
ms.assetid: 2e472155-59db-4dbf-bb94-bcccfa1a794d
---
# \*= Operator (C# Reference)

The binary multiplication assignment operator.

## Remarks

An expression using the `*=` assignment operator, such as

```csharp
x *= y
```

is equivalent to

```csharp
x = x * y
```

except that `x` is only evaluated once. The [\* operator](multiplication-operator.md) is predefined for numeric types to perform multiplication.

The `*=` operator cannot be overloaded directly, but user-defined types can overload the [\* operator](multiplication-operator.md) (see [operator](../keywords/operator.md)).

## Example

[!code-csharp[csRefOperators#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#13)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
