---
description: "let clause - C# Reference"
title: "let clause - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "let_CSharpKeyword"
  - "let"
helpviewer_keywords: 
  - "let keyword [C#]"
  - "let clause [C#]"
ms.assetid: 13c9c1a4-ce57-48ef-8e1b-4c2a59b99fb4
---
# let clause (C# Reference)

In a query expression, it is sometimes useful to store the result of a sub-expression in order to use it in subsequent clauses. You can do this with the `let` keyword, which creates a new range variable and initializes it with the result of the expression you supply. Once initialized with a value, the range variable cannot be used to store another value. However, if the range variable holds a queryable type, it can be queried.

## Example

In the following example `let` is used in two ways:

1. To create an enumerable type that can itself be queried.

2. To enable the query to call `ToLower` only one time on the range variable `word`. Without using `let`, you would have to call `ToLower` in each predicate in the `where` clause.

[!code-csharp[cscsrefQueryKeywords#28](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsCsrefQueryKeywords/CS/Let.cs#28)]

## See also

- [C# Reference](../index.md)
- [Query Keywords (LINQ)](query-keywords.md)
- [LINQ in C#](../../linq/index.md)
- [Language Integrated Query (LINQ)](../../programming-guide/concepts/linq/index.md)
- [Handle exceptions in query expressions](../../linq/handle-exceptions-in-query-expressions.md)
