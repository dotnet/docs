---
title: "%= Operator - C# Reference"
ms.custom: seodec18

ms.date: 09/04/2018
f1_keywords: 
  - "%=_CSharpKeyword"
helpviewer_keywords: 
  - "remainder assignment operator (%=) [C#]"
  - "%= assignment operator (remainder assignment) [C#]"
ms.assetid: 47e5f068-1d97-4010-bd3b-e21b5d3a77f5
---
# %= Operator (C# Reference)

The remainder assignment operator.

An expression using the `%=` operator, such as  

```csharp
x %= y
```  

is equivalent to  

```csharp
x = x % y
```  

except that `x` is only evaluated once.
  
The [remainder operator](remainder-operator.md) `%` computes the remainder after division of its operands. It's supported by all numeric types.

If a user-defined type [overloads](../keywords/operator.md) the [remainder operator](remainder-operator.md) `%`, the remainder assignment operator `%=` is implicitly overloaded.
  
The following example demonstrates the usage of the `%=` operator:

[!code-csharp-interactive[%= example](~/samples/snippets/csharp/language-reference/operators/RemainderExamples.cs#3)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
