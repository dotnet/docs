---
title: "Quantifier Operations"
titleSuffix: LINQ
description: Learn about quantifier operations in LINQ. These methods, `All`, `Any`, and `Contains`, return a Boolean value indicating whether some or all elements in a sequence satisfy a condition.
ms.date: 05/29/2024
ms.topic: article
---
# Quantifier operations in LINQ (C#)

Quantifier operations return a <xref:System.Boolean> value that indicates whether some or all of the elements in a sequence satisfy a condition.

[!INCLUDE [Prerequisites](../includes/linq-syntax.md)]

The following illustration depicts two different quantifier operations on two different source sequences. The first operation asks if any of the elements are the character 'A'. The second operation asks if all the elements are the character 'A'. Both methods return `true` in this example.

:::image type="content" source="./media/quantifier-operations/linq-quantifier-operations.png" alt-text="LINQ Quantifier Operations":::

|Method Name|Description|C# Query Expression Syntax|More Information|
|-----------------|-----------------|---------------------------------|----------------------|
|All|Determines whether all the elements in a sequence satisfy a condition.|Not applicable.|<xref:System.Linq.Enumerable.All%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.All%2A?displayProperty=nameWithType>|
|Any|Determines whether any elements in a sequence satisfy a condition.|Not applicable.|<xref:System.Linq.Enumerable.Any%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Any%2A?displayProperty=nameWithType>|
|Contains|Determines whether a sequence contains a specified element.|Not applicable.|<xref:System.Linq.Enumerable.Contains%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Contains%2A?displayProperty=nameWithType>|

## All

The following example uses the `All` to find students that scored above 70 on all exams.

:::code language="csharp" source="./snippets/standard-query-operators/QuantifierExamples.cs" id="AllQuantifier":::
  
## Any

The following example uses the `Any` to find students that scored greater than 95 on any exam.

:::code language="csharp" source="./snippets/standard-query-operators/QuantifierExamples.cs" id="AnyQuantifier":::

## Contains

The following example uses the `Contains` to find students that scored exactly 95 on an exam.

:::code language="csharp" source="./snippets/standard-query-operators/QuantifierExamples.cs" id="ContainsQuantifier":::

## See also

- <xref:System.Linq>
- [Dynamically specify predicate filters at run time](../get-started/write-linq-queries.md)
- [How to query for sentences that contain a specified set of words (LINQ) (C#)](../how-to-query-strings.md)
