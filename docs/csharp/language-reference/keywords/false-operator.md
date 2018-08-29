---
title: "false operator (C# Reference)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "false operator keyword [C#]"
ms.assetid: 81a888fd-011e-4589-b242-6c261fea505e
---
# false operator (C# Reference)

Returns the [bool](bool.md) value `true` to indicate that an operand is `false` and returns `false` otherwise.

Prior to C# 2.0, the `true` and `false` operators were used to create user-defined nullable value types that were compatible with types such as `SqlBool`. However, the language now provides built-in support for nullable value types, and whenever possible you should use those instead of overloading the `true` and `false` operators. For more information, see [Nullable Types](../../programming-guide/nullable-types/index.md).

With nullable Booleans, the expression `a != b` is not necessarily equal to `!(a == b)` because one or both of the values might be null. You have to overload both the `true` and `false` operators separately to correctly handle the null values in the expression. The following example shows how to overload and use the `true` and `false` operators.

[!code-csharp[csrefKeywordsOperator#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#16)]

A type that overloads the `true` and `false` operators can be used for the controlling expression in [if](if-else.md), [do](do.md), [while](while.md), and [for](for.md) statements and in [conditional expressions](../operators/conditional-operator.md).

If a type defines operator `false`, it must also define operator [true](true.md).

A type cannot directly overload the conditional logical operators [&&](../operators/conditional-and-operator.md) and [&#124;&#124;](../operators/conditional-or-operator.md), but an equivalent effect can be achieved by overloading the regular logical operators and operators `true` and `false`.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)  
- [C# Programming Guide](../../programming-guide/index.md)  
- [C# Keywords](index.md)  
- [C# Operators](../operators/index.md)  
- [true](true.md)  