---
title: "new constraint (C# Reference)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "new constraint keyword [C#]"
ms.assetid: 58850b64-cb97-4136-be50-1f3bc7fc1da9
---
# new constraint (C# Reference)

The `new` constraint specifies that any type argument in a generic class declaration must have a public parameterless constructor. To use the new constraint, the type cannot be abstract.

## Example

Apply the `new` constraint to a type parameter when your generic class creates new instances of the type, as shown in the following example:

[!code-csharp[csrefKeywordsOperator#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#5)]

## Example

When you use the `new()` constraint with other constraints, it must be specified last:

[!code-csharp[csrefKeywordsOperator#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsOperator/CS/csrefKeywordsOperators.cs#6)]

For more information, see [Constraints on Type Parameters](../../programming-guide/generics/constraints-on-type-parameters.md).

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- <xref:System.Collections.Generic>
- [C# Reference](../../language-reference/index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Operator Keywords](operator-keywords.md)
- [Generics](../../programming-guide/generics/index.md)