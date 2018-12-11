---
title: "goto statement - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "goto_CSharpKeyword"
  - "goto"
helpviewer_keywords: 
  - "goto keyword [C#]"
ms.assetid: 2c03c9c1-8119-44ef-b740-fb3d287a42fe
---
# goto (C# Reference)

The `goto` statement transfers the program control directly to a labeled statement.

A common use of `goto` is to transfer control to a specific switch-case label or the default label in a `switch` statement.

The `goto` statement is also useful to get out of deeply nested loops.

## Example

The following example demonstrates using `goto` in a [switch](switch.md) statement.

[!code-csharp[csrefKeywordsJump#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#4)]

## Example

The following example demonstrates using `goto` to break out from nested loops.

[!code-csharp[csrefKeywordsJump#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#5)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)  
- [C# Programming Guide](../../programming-guide/index.md)  
- [C# Keywords](index.md)  
- [goto Statement (C++)](/cpp/cpp/goto-statement-cpp)  
- [Jump Statements](jump-statements.md)  
