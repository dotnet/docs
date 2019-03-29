---
title: "|= operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "|=_CSharpKeyword"
helpviewer_keywords: 
  - "OR assignment operator (|=) [C#]"
  - "|= operator (OR assignment) [C#]"
ms.assetid: 8315b8cf-dd15-402f-92f0-c7db931696ca
---
# |= operator (C# Reference)

The OR assignment operator.

## Remarks

An expression using the `|=` assignment operator, such as

```csharp
x |= y
```

is equivalent to

```csharp
x = x | y
```

except that `x` is only evaluated once. The [&#124; operator](or-operator.md) performs a bitwise logical OR operation on integral operands and logical OR on bool operands.

The `|=` operator cannot be overloaded directly, but user-defined types can overload the [&#124; operator](or-operator.md) (see [operator](../keywords/operator.md)).

## Example

[!code-csharp[csRefOperators#10](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#10)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# operators](index.md)