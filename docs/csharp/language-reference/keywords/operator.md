---
title: "operator keyword (C# Reference)"
description: "Learn how to overload a built-in C# operator"
ms.date: 08/27/2018
f1_keywords: 
  - "operator_CSharpKeyword"
  - "operator"
helpviewer_keywords: 
  - "operator keyword [C#]"
ms.assetid: 59218cce-e90e-42f6-a6bb-30300981b86a
---
# operator (C# Reference)

Use the `operator` keyword to overload a built-in operator or to provide a user-defined conversion in a class or struct declaration.

To overload an operator on a custom class or struct, you create an operator declaration in the corresponding type. The operator declaration that overloads a built-in C# operator must satisfy the following rules:

- It includes both a `public` and a `static` modifier.
- It includes `operator X` where `X` is the name or symbol of the operator being overloaded.
- Unary operators have one parameter, and binary operators have two parameters. In each case, at least one parameter must be the same type as the class or struct that declares the operator.

For information about how to define conversion operators, see the [explicit](explicit.md) and [implicit](implicit.md) keyword articles.

For an overview of the C# operators that can be overloaded, see the [Overloadable operators](../../programming-guide/statements-expressions-operators/overloadable-operators.md) article.

## Example

The following example defines a `Fraction` type that represents fractional numbers. It overloads the `+` and `*` operators to perform fractional addition and multiplication, and also provides a conversion operator that converts a `Fraction` type to a `double` type.

[!code-csharp[csrefKeywordsConversion#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsConversion/CS/csrefKeywordsConversion.cs#6)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [implicit](implicit.md)
- [explicit](explicit.md)
- [Overloadable operators](../../programming-guide/statements-expressions-operators/overloadable-operators.md)
- [How to: Implement User-Defined Conversions Between Structs](../../programming-guide/statements-expressions-operators/how-to-implement-user-defined-conversions-between-structs.md)
