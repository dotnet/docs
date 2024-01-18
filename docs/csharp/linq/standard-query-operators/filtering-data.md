---
title: "Filtering Data with LINQ"
description: Filtering, also known as selection, restricts results based on a condition. Learn about the standard query operator methods in LINQ in C# that perform filtering.
ms.date: 01/22/2024
---
# Filtering Data (C#)

Filtering refers to the operation of restricting the result set to contain only those elements that satisfy a specified condition. It is also known as selection.

The following illustration shows the results of filtering a sequence of characters. The predicate for the filtering operation specifies that the character must be 'A'.

:::image type="content" source="./media/filtering-data/linq-filter-operation.png" alt-text="Diagram that shows a LINQ filtering operation":::

The standard query operator methods that perform selection are listed in the following section.

## Methods

|Method Name|Description|C# Query Expression Syntax|More Information|
|-----------------|-----------------|---------------------------------|----------------------|
|OfType|Selects values, depending on their ability to be cast to a specified type.|Not applicable.|<xref:System.Linq.Enumerable.OfType%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.OfType%2A?displayProperty=nameWithType>|
|Where|Selects values that are based on a predicate function.|`where`|<xref:System.Linq.Enumerable.Where%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Where%2A?displayProperty=nameWithType>|

## Query Expression Syntax Example

The following example uses the `where` clause to filter from an array those strings that have a specific length.

:::code language="csharp" source="./snippets/standard-query-operators/WhereFilter.cs" id="FilterExampleQuery":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/WhereFilter.cs" id="FilterExampleMethod":::

## See also

- <xref:System.Linq>
- [where clause](../../language-reference/keywords/where-clause.md)
- [How to query an assembly's metadata with Reflection (LINQ) (C#)](../../advanced-topics/reflection-and-attributes/how-to-query-assembly-metadata-with-reflection-linq.md)
- [How to query for files with a specified attribute or name (C#)](../../programming-guide/concepts/linq/how-to-query-for-files-with-a-specified-attribute-or-name.md)
- [How to sort or filter text data by any word or field (LINQ) (C#)](../../programming-guide/concepts/linq/how-to-sort-or-filter-text-data-by-any-word-or-field-linq.md)
