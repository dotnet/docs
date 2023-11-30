---
title: Create a nested group (LINQ in C#)
description: Learn how to create a nested group in a LINQ query expression in C#.
ms.date: 12/01/2016
ms.assetid: e9f00708-362e-4d13-98c5-d77549347ba0
---
# Create a nested group

The following example shows how to create nested groups in a LINQ query expression. Each group that is created according to student year or grade level is then further subdivided into groups based on the individuals' names.

## Example

> [!NOTE]
> The example in this topic uses the `Student` class and `students` list from the sample code in [Query a collection of objects](query-a-collection-of-objects.md).

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/NestedGroups.cs" id="nested_groups_1":::

Note that three nested `foreach` loops are required to iterate over the inner elements of a nested group.
<br/>(Hover the mouse cursor over the iteration variables, `outerGroup`, `innerGroup` and `innerGroupElement` to see their actual type.)

## See also

- [Language Integrated Query (LINQ)](index.md)
