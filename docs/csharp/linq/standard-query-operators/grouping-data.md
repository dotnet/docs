---
title: "Grouping Data (C#)"
description: Grouping puts data into groups of elements that share an attribute. Learn about the standard query operator methods in LINQ in C# that group data elements.
ms.date: 01/23/2024
---
# Grouping Data (C#)

Grouping refers to the operation of putting data into groups so that the elements in each group share a common attribute.

The following illustration shows the results of grouping a sequence of characters. The key for each group is the character.

:::image type="content" source="./media/grouping-data/linq-group-operation.png" alt-text="Diagram that shows a LINQ Grouping operation":::

The standard query operator methods that group data elements are listed in the following section.

## Methods

|Method Name|Description|C# Query Expression Syntax|More Information|
|-----------------|-----------------|---------------------------------|----------------------|
|GroupBy|Groups elements that share a common attribute. Each group is represented by an <xref:System.Linq.IGrouping%602> object.|`group … by`<br /><br /> -or-<br /><br /> `group … by … into …`|<xref:System.Linq.Enumerable.GroupBy%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.GroupBy%2A?displayProperty=nameWithType>|
|ToLookup|Inserts elements into a <xref:System.Linq.Lookup%602> (a one-to-many dictionary) based on a key selector function.|Not applicable.|<xref:System.Linq.Enumerable.ToLookup%2A?displayProperty=nameWithType>|

## Query Expression Syntax Example

The following code example uses the `group by` clause to group integers in a list according to whether they are even or odd.

:::code language="csharp" source="./snippets/standard-query-operators/GroupOverview.cs" id="OverviewSampleQuerySyntax":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/GroupOverview.cs" id="OverviewSampleMethodSyntax":::

## Group query results

Grouping is one of the most powerful capabilities of LINQ. The following examples show how to group data in various ways:

- By a single property.
- By the first letter of a string property.
- By a computed numeric range.
- By Boolean predicate or other expression.
- By a compound key.

In addition, the last two queries project their results into a new anonymous type that contains only the student's first and last name. For more information, see the [group clause](../../language-reference/keywords/group-clause.md).

> [!NOTE]
> The examples in this topic use the `Student` class and `students` list from the sample code in [the overview article](../index.md).

### Group by single property example

The following example shows how to group source elements by using a single property of the element as the group key. In this case the key is a `string`, the student's last name. It is also possible to use a substring for the key; see [the next example](#group-by-value-example). The grouping operation uses the default equality comparer for the type.

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByPropertyQuery":::

The equivalent code using method syntax is shown in the following example:

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByPropertyMethod":::

### Group by value example

The following example shows how to group source elements by using something other than a property of the object for the group key. In this example, the key is the first letter of the student's last name.

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByValueQuery":::

Note that nested foreach is required to access group items.

The equivalent code using method syntax is shown in the following example:

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByValueMethod":::

### Group by a range example

The following example shows how to group source elements by using a numeric range as a group key. The query then projects the results into an anonymous type that contains only the first and last name and the percentile range to which the student belongs. An anonymous type is used because it is not necessary to use the complete `Student` object to display the results. `GetPercentile` is a helper function that calculates a percentile based on the student's average score. The method returns an integer between 0 and 10.

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByRangeQuery":::

Note that nested foreach required to iterate over groups and group items.

The equivalent code using method syntax is shown in the following example:

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByRangeMethod":::

### Group by comparison example

The following example shows how to group source elements by using a Boolean comparison expression. In this example, the Boolean expression tests whether a student's average exam score is greater than 75. As in previous examples, the results are projected into an anonymous type because the complete source element is not needed. Note that the properties in the anonymous type become properties on the `Key` member and can be accessed by name when the query is executed.

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByBooleanQuerySyntax":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByBooleanMethodSyntax":::

### Group by anonymous type

The following example shows how to use an anonymous type to encapsulate a key that contains multiple values. In this example, the first key value is the first letter of the student's last name. The second key value is a Boolean that specifies whether the student scored over 85 on the first exam. You can order the groups by any property in the key.

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByCompundKeyQuerySyntax":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/GroupQueryResults.cs" id="GroupByCompundKeyMethodSyntax":::

## Create a nested group

The following example shows how to create nested groups in a LINQ query expression. Each group that is created according to student year or grade level is then further subdivided into groups based on the individuals' names.

:::code language="csharp" source="./snippets/standard-query-operators/NestedGroups.cs" id="NestedGroupsQuerySyntax":::

Note that three nested `foreach` loops are required to iterate over the inner elements of a nested group.
<br/>(Hover the mouse cursor over the iteration variables, `outerGroup`, `innerGroup` and `innerGroupElement` to see their actual type.)

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/NestedGroups.cs" id="NestedGroupsMethodSyntax":::

## Perform a subquery on a grouping operation

This article shows two different ways to create a query that orders the source data into groups, and then performs a subquery over each group individually. The basic technique in each example is to group the source elements by using a *continuation* named `newGroup`, and then generating a new subquery against `newGroup`. This subquery is run against each new group that is created by the outer query. Note that in this particular example the final output is not a group, but a flat sequence of anonymous types.

For more information about how to group, see [group clause](../../language-reference/keywords/group-clause.md).

For more information about continuations, see [into](../../language-reference/keywords/into.md). The following example uses an in-memory data structure as the data source, but the same principles apply for any kind of LINQ data source.

:::code language="csharp" source="./snippets/standard-query-operators/SubqueryOnGroup.cs" id="SubQueryOnGroupQuerySyntax":::

The query in the snippet above can also be written using method syntax. The following code snippet has a semantically equivalent query written using method syntax.

:::code language="csharp" source="./snippets/standard-query-operators/SubqueryOnGroup.cs" id="SubQueryOnGroupMethodSyntax":::

## See also

- <xref:System.Linq>
- <xref:System.Linq.Enumerable.GroupBy%2A>
- <xref:System.Linq.IGrouping%602>
- [group clause](../../language-reference/keywords/group-clause.md)
- [How to group files by extension (LINQ) (C#)](../../programming-guide/concepts/linq/how-to-group-files-by-extension-linq.md)
- [How to split a file into many files by using groups (LINQ) (C#)](../../programming-guide/concepts/linq/how-to-split-a-file-into-many-files-by-using-groups-linq.md)
