---
title: "bool keyword - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "bool_CSharpKeyword"
  - "bool"
helpviewer_keywords: 
  - "bool keyword [C#]"
ms.assetid: 551cfe35-2632-4343-af49-33ad12da08e2
---
# bool (C# Reference)

The `bool` keyword is an alias of <xref:System.Boolean?displayProperty=nameWithType>. It is used to declare variables to store the Boolean values: [true](true-literal.md) and [false](false-literal.md).

> [!NOTE]
> Use the `bool?` type, if you need to support the three-valued logic, for example, when you work with databases that support a three-valued Boolean type. For the `bool?` operands, the predefined `&` and `|` operators support the three-valued logic. For more information, see the [Nullable Boolean logical operators](../operators/boolean-logical-operators.md#nullable-boolean-logical-operators) section of the [Boolean logical operators](../operators/boolean-logical-operators.md) article.

## Literals

You can assign a Boolean value to a `bool` variable. You can also assign an expression that evaluates to `bool` to a `bool` variable.

[!code-csharp[csrefKeywordsTypes#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#1)]

The default value of a `bool` variable is `false`. The default value of a `bool?` variable is `null`.

## Conversions

In C++, a value of type `bool` can be converted to a value of type `int`; in other words, `false` is equivalent to zero and `true` is equivalent to nonzero values. In C#, there is no conversion between the `bool` type and other types. For example, the following `if` statement is invalid in C#:

[!code-csharp[csrefKeywordsTypes#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#2)]

To test a variable of the type `int`, you have to explicitly compare it to a value, such as zero, as follows:

[!code-csharp[csrefKeywordsTypes#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#3)]

## Example

In this example, you enter a character from the keyboard and the program checks if the input character is a letter. If it is a letter, it checks if it is lowercase or uppercase. These checks are performed with the <xref:System.Char.IsLetter%2A>, and <xref:System.Char.IsLower%2A>, both of which return the `bool` type:

[!code-csharp[csrefKeywordsTypes#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsTypes/CS/keywordsTypes.cs#4)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../../../csharp/language-reference/index.md)
- [C# Programming Guide](../../../csharp/programming-guide/index.md)
- [C# Keywords](../../../csharp/language-reference/keywords/index.md)
- [Integral types](../../../csharp/language-reference/builtin-types/integral-numeric-types.md)
- [Built-In Types Table](../../../csharp/language-reference/keywords/built-in-types-table.md)
- [Implicit Numeric Conversions Table](../../../csharp/language-reference/keywords/implicit-numeric-conversions-table.md)
- [Explicit Numeric Conversions Table](../../../csharp/language-reference/keywords/explicit-numeric-conversions-table.md)
