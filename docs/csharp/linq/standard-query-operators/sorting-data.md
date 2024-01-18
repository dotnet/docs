---
title: "Sorting Data (C#)"
description: Learn about sort operations and the standard query operator methods that perform sort operations in LINQ in C#.  
ms.date: 01/22/2024
---
# Sorting Data (C#)

A sorting operation orders the elements of a sequence based on one or more attributes. The first sort criterion performs a primary sort on the elements. By specifying a second sort criterion, you can sort the elements within each primary sort group.

The following illustration shows the results of an alphabetical sort operation on a sequence of characters:

:::image type="content" source="./media/sorting-data/alphabetical-sort-operation.png" alt-text="Graphic that shows an alphabetical sort operation.":::

The standard query operator methods that sort data are listed in the following section.

## Methods

|Method Name|Description|C# Query Expression Syntax|More Information|
|-----------------|-----------------|---------------------------------|----------------------|
|OrderBy|Sorts values in ascending order.|`orderby`|<xref:System.Linq.Enumerable.OrderBy%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.OrderBy%2A?displayProperty=nameWithType>|
|OrderByDescending|Sorts values in descending order.|`orderby … descending`|<xref:System.Linq.Enumerable.OrderByDescending%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.OrderByDescending%2A?displayProperty=nameWithType>|
|ThenBy|Performs a secondary sort in ascending order.|`orderby …, …`|<xref:System.Linq.Enumerable.ThenBy%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.ThenBy%2A?displayProperty=nameWithType>|
|ThenByDescending|Performs a secondary sort in descending order.|`orderby …, … descending`|<xref:System.Linq.Enumerable.ThenByDescending%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.ThenByDescending%2A?displayProperty=nameWithType>|
|Reverse|Reverses the order of the elements in a collection.|Not applicable.|<xref:System.Linq.Enumerable.Reverse%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Reverse%2A?displayProperty=nameWithType>|

## Query Expression Syntax Examples

### Primary Sort Examples

#### Primary Ascending Sort

The following example demonstrates how to use the `orderby` clause in a LINQ query to sort the strings in an array by string length, in ascending order.

:::code language="csharp" source="./snippets/standard-query-operators/SortExamples.cs" id="PrimaryAscendingSortQuery":::

The equivalent query written using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/SortExamples.cs" id="PrimaryAscendingSortMethod":::

#### Primary Descending Sort

The next example demonstrates how to use the `orderby descending` clause in a LINQ query to sort the strings by their first letter, in descending order.

:::code language="csharp" source="./snippets/standard-query-operators/SortExamples.cs" id="PrimaryDescendingSortQuery":::

The equivalent query written using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/SortExamples.cs" id="PrimaryDescendingSortMethod":::

### Secondary Sort Examples

#### Secondary Ascending Sort

The following example demonstrates how to use the `orderby` clause in a LINQ query to perform a primary and secondary sort of the strings in an array. The strings are sorted primarily by length and secondarily by the first letter of the string, both in ascending order.

:::code language="csharp" source="./snippets/standard-query-operators/SortExamples.cs" id="SecondaryAscendingSortQuery":::

The equivalent query written using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/SortExamples.cs" id="SecondaryAscendingSortMethod":::

#### Secondary Descending Sort

The next example demonstrates how to use the `orderby descending` clause in a LINQ query to perform a primary sort, in ascending order, and a secondary sort, in descending order. The strings are sorted primarily by length and secondarily by the first letter of the string.

:::code language="csharp" source="./snippets/standard-query-operators/SortExamples.cs" id="SecondaryDescendingSortQuery":::

The equivalent query written using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/SortExamples.cs" id="SecondaryDescendingSortMethod":::

## See also

- <xref:System.Linq>
- [orderby clause](../../language-reference/keywords/orderby-clause.md)
- [How to sort or filter text data by any word or field (LINQ) (C#)](../../programming-guide/concepts/linq//how-to-sort-or-filter-text-data-by-any-word-or-field-linq.md)
