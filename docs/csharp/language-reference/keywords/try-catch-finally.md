---
title: "try-catch-finally - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "catch-finally_CSharpKeyword"
  - "catch-finally"
helpviewer_keywords: 
  - "finally blocks [C#]"
  - "try-catch statement [C#]"
ms.assetid: a1b443b0-ff7a-43ab-b835-0cc9bfbd15ca
---
# try-catch-finally (C# Reference)

A common usage of `catch` and `finally` together is to obtain and use resources in a `try` block, deal with exceptional circumstances in a `catch` block, and release the resources in the `finally` block.

 For more information and examples on re-throwing exceptions, see [try-catch](try-catch.md) and [Throwing Exceptions](../../../standard/exceptions/index.md). For more information about the `finally` block, see [try-finally](try-finally.md).

## Example

[!code-csharp[csrefKeywordsExceptions#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsExceptions/CS/csrefKeywordsExceptions.cs#1)]  

## C# language specification

For more information, see [The try statement](~/_csharplang/spec/statements.md#the-try-statement) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [try, throw, and catch Statements (C++)](/cpp/cpp/try-throw-and-catch-statements-cpp)
- [throw](throw.md)
- [How to: Explicitly Throw Exceptions](../../../standard/exceptions/how-to-explicitly-throw-exceptions.md)
- [using Statement](using-statement.md)
