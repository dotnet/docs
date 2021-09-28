---
description: "into - C# Reference"
title: "into - C# Reference"
ms.date: 07/20/2015
f1_keywords: 
  - "into_CSharpKeyword"
  - "into"
helpviewer_keywords: 
  - "into keyword [C#]"
ms.assetid: 81ec62c1-f0b1-4755-8a31-959876e77f65
---
# into (C# Reference)

The `into` contextual keyword can be used to create a temporary identifier to store the results of a [group](group-clause.md), [join](join-clause.md) or [select](select-clause.md) clause into a new identifier. This identifier can itself be a generator for additional query commands. When used in a `group` or `select` clause, the use of the new identifier is sometimes referred to as a *continuation*.

## Example

The following example shows the use of the `into` keyword to enable a temporary identifier `fruitGroup` which has an inferred type of `IGrouping`. By using the identifier, you can invoke the <xref:System.Linq.Enumerable.Count%2A> method on each group and select only those groups that contain two or more words.

[!code-csharp[cscsrefQueryKeywords#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/CsCsrefQueryKeywords/CS/Into.cs#18)]

The use of `into` in a `group` clause is only necessary when you want to perform additional query operations on each group. For more information, see [group clause](group-clause.md).

For an example of the use of `into` in a `join` clause, see [join clause](join-clause.md).

## See also

- [Query Keywords (LINQ)](query-keywords.md)
- [LINQ in C#](../../linq/index.md)
- [group clause](group-clause.md)
