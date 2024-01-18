---
title: "Grouping Data (C#)"
description: Grouping puts data into groups of elements that share an attribute. Learn about the standard query operator methods in LINQ in C# that group data elements.
ms.date: 01/23/2024
---
# Grouping Data (C#)

Grouping refers to the operation of putting data into groups so that the elements in each group share a common attribute.

The following illustration shows the results of grouping a sequence of characters. The key for each group is the character.

:::image type="content" source="./media/index/linq-group-operation.png" alt-text="Diagram that shows a LINQ Grouping operation":::

The standard query operator methods that group data elements are listed in the following section.

## Methods

|Method Name|Description|C# Query Expression Syntax|More Information|
|-----------------|-----------------|---------------------------------|----------------------|
|GroupBy|Groups elements that share a common attribute. Each group is represented by an <xref:System.Linq.IGrouping%602> object.|`group … by`<br /><br /> -or-<br /><br /> `group … by … into …`|<xref:System.Linq.Enumerable.GroupBy%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.GroupBy%2A?displayProperty=nameWithType>|
|ToLookup|Inserts elements into a <xref:System.Linq.Lookup%602> (a one-to-many dictionary) based on a key selector function.|Not applicable.|<xref:System.Linq.Enumerable.ToLookup%2A?displayProperty=nameWithType>|

## Query Expression Syntax Example

The following code example uses the `group by` clause to group integers in a list according to whether they are even or odd.

:::code language="csharp" source="../snippets/standard-query-operators/GroupOverview.cs" id="OverviewSampleQuerySyntax":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="../snippets/standard-query-operators/GroupOverview.cs" id="OverviewSampleMethodSyntax":::

## See also

- <xref:System.Linq>
- [group clause](../../../language-reference/keywords/group-clause.md)
- [Create a nested group](../../../linq/create-a-nested-group.md)
- [How to group files by extension (LINQ) (C#)](../../../programming-guide/concepts/linq/how-to-group-files-by-extension-linq.md)
- [How to split a file into many files by using groups (LINQ) (C#)](./../../../programming-guide/concepts/linq/how-to-split-a-file-into-many-files-by-using-groups-linq.md)
