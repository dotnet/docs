---
title: "How to: Parse Strings Using String.Split (C# Guide)"
description: String.Split returns an array of strings split from a set of delimiters. It's an easy way to parse strings.
ms.date: 01/03/2018
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "splitting strings [C#]"
  - "Split method [C#]"
  - "strings [C#], splitting"
  - "parse strings"
ms.assetid: 729c2923-4169-41c6-9c90-ef176c1e2953
author: "BillWagner"
ms.author: "wiwagn"
ms.custom: mvc
---
# How to: Parse Strings Using String.Split (C# Guide)

The <xref:System.String.Split%2A?displayProperty=nameWithType> method creates an
array of substrings by splitting the input string based on one or more delimiters. It is often the easiest way to separate a string on word boundaries. It is also used
to split strings on other specific characters or strings.

[!INCLUDE[interactive-note](~/includes/csharp-interactive-note.md)]

The following code splits a common phrase into an array of strings for each word.

[!code-csharp-interactive[split strings on word boundaries](../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs#1)]

Every instance of a separator character produces a value in the
returned array. Consecutive separator characters produce the empty string
as a value in the returned array.  You can see this in the following example,
which uses space as a separator:

[!code-csharp-interactive[split strings with repeated separators](../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs#2)]

This behavior makes it easier for formats like comma separated values (CSV)
files representing tabular data. Consecutive commas represent a blank column.

You can pass an optional <xref:System.StringSplitOptions.RemoveEmptyEntries?displayProperty=nameWithType> parameter to
exclude any empty strings in the returned array. For more complicated processing of the returned
collection, you can use [LINQ](../programming-guide/concepts/linq/index.md) to manipulate
the result sequence.    

<xref:System.String.Split%2A?displayProperty=nameWithType> can use
multiple separator characters. The following example uses spaces, commas, periods, colons, and tabs, all passed in an array containing these separating characters, to <xref:System.String.Split%2A>.  The loop at the bottom of the code 
displays each of the words in the returned array.  

[!code-csharp-interactive[split strings using multiple separators](../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs#3)]

Consecutive instances of any separator produce the empty string in the output array:

[!code-csharp-interactive[split strings using multiple consecutive separators](../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs#4)]

<xref:System.String.Split%2A?displayProperty=nameWithType> can take an array of strings (character sequences that act as separators for parsing the target string, instead of single characters).  
  
[!code-csharp-interactive[split strings using strings as separators](../../../samples/snippets/csharp/how-to/strings/ParseStringsUsingSplit.cs#5)]

You can try these samples by looking at the code in our [GitHub repository](https://github.com/dotnet/samples/tree/master/snippets/csharp/how-to/strings). Or you can download the samples [as a zip file](https://github.com/dotnet/samples/raw/master/snippets/csharp/how-to/strings.zip).

## See Also  
 [C# Programming Guide](../programming-guide/index.md)  
 [Strings](../programming-guide/strings/index.md)  
 [.NET Regular Expressions](../../standard/base-types/regular-expressions.md)
