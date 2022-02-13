---
title: Group query results (LINQ in C#)
description: Learn how to group results using LINQ in C#.
ms.date: 12/01/2016
ms.assetid: 2e4ec27f-06fb-4de7-8973-0189906d4520
---
# Group query results

Grouping is one of the most powerful capabilities of LINQ. The following examples show how to group data in various ways:

- By a single property.

- By the first letter of a string property.

- By a computed numeric range.

- By Boolean predicate or other expression.

- By a compound key.

In addition, the last two queries project their results into a new anonymous type that contains only the student's first and last name. For more information, see the [group clause](../language-reference/keywords/group-clause.md).

> [!NOTE]
> The examples in this topic use the `Student` class and `students` list from the sample code in [Query a collection of objects](query-a-collection-of-objects.md).

## Group by single property example

The following example shows how to group source elements by using a single property of the element as the group key. In this case the key is a `string`, the student's last name. It is also possible to use a substring for the key; see [the next example](#group-by-value-example). The grouping operation uses the default equality comparer for the type.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/GroupQueryResults.cs" id="group_query_results_1":::

## Group by value example

The following example shows how to group source elements by using something other than a property of the object for the group key. In this example, the key is the first letter of the student's last name.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/GroupQueryResults.cs" id="group_query_results_2":::

## Group by a range example

The following example shows how to group source elements by using a numeric range as a group key. The query then projects the results into an anonymous type that contains only the first and last name and the percentile range to which the student belongs. An anonymous type is used because it is not necessary to use the complete `Student` object to display the results. `GetPercentile` is a helper function that calculates a percentile based on the student's average score. The method returns an integer between 0 and 10.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/GroupQueryResults.cs" id="group_query_results_3":::

## Group by comparison example

The following example shows how to group source elements by using a Boolean comparison expression. In this example, the Boolean expression tests whether a student's average exam score is greater than 75. As in previous examples, the results are projected into an anonymous type because the complete source element is not needed. Note that the properties in the anonymous type become properties on the `Key` member and can be accessed by name when the query is executed.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/GroupQueryResults.cs" id="group_query_results_4":::

## Group by anonymous type

The following example shows how to use an anonymous type to encapsulate a key that contains multiple values. In this example, the first key value is the first letter of the student's last name. The second key value is a Boolean that specifies whether the student scored over 85 on the first exam. You can order the groups by any property in the key.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/GroupQueryResults.cs" id="group_query_results_5":::

## See also

- <xref:System.Linq.Enumerable.GroupBy%2A>
- <xref:System.Linq.IGrouping%602>
- [Language Integrated Query (LINQ)](index.md)
- [group clause](../language-reference/keywords/group-clause.md)
- [Anonymous Types](../fundamentals/types/anonymous-types.md)
- [Perform a Subquery on a Grouping Operation](perform-a-subquery-on-a-grouping-operation.md)
- [Create a Nested Group](create-a-nested-group.md)
- [Grouping Data](../programming-guide/concepts/linq/grouping-data.md)
