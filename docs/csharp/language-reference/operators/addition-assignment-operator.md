---
title: "+= Operator (C# Reference)"
ms.date: 10/22/2018
f1_keywords: 
  - "+=_CSharpKeyword"
helpviewer_keywords: 
  - "+= operator [C#]"
  - "addition assignment operator (+=) [C#]"
  - "event subscription [C#]"
ms.assetid: 9cdf97e6-331d-492b-85e1-3ec3171484e9
---
# += Operator (C# Reference)

The addition assignment operator.

An expression using the `+=` operator, such as  

```csharp
x += y
```  

is equivalent to  

```csharp
x = x + y
```  

except that `x` is only evaluated once.
  
For numeric types, the [addition operator](addition-operator.md) `+` computes the sum of its operands. If one or both operands is of type [string](../keywords/string.md), it concatenates the string representations of its operands. For delegate types, the `+` operator returns a new delegate instance that is combination of its operands.

If a user-defined type [overloads](../keywords/operator.md) the [addition operator](addition-operator.md) `+`, the addition assignment operator `+=` is implicitly overloaded.

You also use the `+=` operator to specify an event handler method when you subscribe to an [event](../keywords/event.md). For more information, see [How to: Subscribe to and Unsubscribe from Events](../../programming-guide/events/how-to-subscribe-to-and-unsubscribe-from-events.md).

The following example demonstrates the usage of the `+=` operator:

[!code-csharp-interactive[+= examples](~/samples/snippets/csharp/language-reference/operators/AdditionExamples.cs#AddAndAssign)]
  
## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Events](../../programming-guide/events/index.md)
- [Delegates](../../programming-guide/delegates/index.md)
