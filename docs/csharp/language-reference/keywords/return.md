---
title: "return statement - C# Reference"
ms.custom: seodec18

ms.date: 07/20/2015
f1_keywords: 
  - "return_CSharpKeyword"
  - "return"
helpviewer_keywords: 
  - "return statement [C#]"
  - "return keyword [C#]"
ms.assetid: 6da6e152-5b58-4448-8f3f-470dd0617ecd
---
# return (C# Reference)

The `return` statement terminates execution of the method in which it appears and returns control to the calling method. It can also return an optional value. If the method is a `void` type, the `return` statement can be omitted.

 If the return statement is inside a `try` block, the `finally` block, if one exists, will be executed before control returns to the calling method.

## Example

 In the following example, the method `CalculateArea()` returns the local variable `area` as a [double](double.md) value.

[!code-csharp[csrefKeywordsJump#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsJump/CS/csrefKeywordsJump.cs#6)]  

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [return Statement](/cpp/cpp/return-statement-cpp)
- [Jump Statements](jump-statements.md)
