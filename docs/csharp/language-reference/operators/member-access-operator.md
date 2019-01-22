---
title: ". operator - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "._CSharpKeyword"
helpviewer_keywords: 
  - "member access operator (.) [C#]"
  - ". operator [C#]"
  - "dot operator (.) [C#]"
ms.assetid: a1f54b52-b686-4ae5-a48e-a2a9ebd0eb7b
---
# . operator (C# Reference)

The dot operator (`.`) is used for member access. The dot operator specifies a member of a type or namespace. For example, the dot operator is used to access specific methods within the .NET Framework class libraries:

[!code-csharp[csRefOperators#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#16)]

For example, consider the following class:

[!code-csharp[csRefOperators#17](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#17)]

[!code-csharp[csRefOperators#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#18)]

The variable `s` has two members, `a` and `b`; to access them, use the dot operator:

[!code-csharp[csRefOperators#19](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#19)]

The dot is also used to form qualified names, which are names that specify the namespace or interface, for example, to which they belong.

[!code-csharp[csRefOperators#20](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#20)]

The using directive makes some name qualification optional:

[!code-csharp[csRefOperators#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#21)]

But when an identifier is ambiguous, it must be qualified:

[!code-csharp[csRefOperators#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefOperators/CS/csrefOperators.cs#22)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)