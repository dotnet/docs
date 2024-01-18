---
title: Create a nested group (LINQ in C#)
description: Learn how to create a nested group in a LINQ query expression in C#.
ms.date: 01/23/2024
---
# Create a nested group

The following example shows how to create nested groups in a LINQ query expression. Each group that is created according to student year or grade level is then further subdivided into groups based on the individuals' names.

> [!NOTE]
> The examples in this topic use the `Student` class and `students` list from the sample code in [the overview article](../index.md).

:::code language="csharp" source="../snippets/standard-query-operators/NestedGroups.cs" id="NestedGroupsQuerySyntax":::

Note that three nested `foreach` loops are required to iterate over the inner elements of a nested group.
<br/>(Hover the mouse cursor over the iteration variables, `outerGroup`, `innerGroup` and `innerGroupElement` to see their actual type.)

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="../snippets/standard-query-operators/NestedGroups.cs" id="NestedGroupsMethodSyntax":::
