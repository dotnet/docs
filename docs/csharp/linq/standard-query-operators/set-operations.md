---
title: "Set operations"
description: Learn about set operations and the standard query operator methods that perform set operations in LINQ in C#.
ms.date: 05/29/2024
ms.topic: article
---
# Set operations (C#)

Set operations in LINQ refer to query operations that produce a result set based on the presence or absence of equivalent elements within the same or separate collections.

[!INCLUDE [Prerequisites](../includes/linq-syntax.md)]

| Method names | Description | C# query expression syntax | More information |
|--|--|--|--|
| `Distinct` or `DistinctBy` | Removes duplicate values from a collection. | Not applicable. | <xref:System.Linq.Enumerable.Distinct%2A?displayProperty=nameWithType><br /><xref:System.Linq.Enumerable.DistinctBy%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Distinct%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.DistinctBy%2A?displayProperty=nameWithType> |
| `Except` or `ExceptBy` | Returns the set difference, which means the elements of one collection that don't appear in a second collection. | Not applicable. | <xref:System.Linq.Enumerable.Except%2A?displayProperty=nameWithType><br /><xref:System.Linq.Enumerable.ExceptBy%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Except%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.ExceptBy%2A?displayProperty=nameWithType> |
| `Intersect` or `IntersectBy` | Returns the set intersection, which means elements that appear in each of two collections. | Not applicable. | <xref:System.Linq.Enumerable.Intersect%2A?displayProperty=nameWithType><br /><xref:System.Linq.Enumerable.IntersectBy%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Intersect%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.IntersectBy%2A?displayProperty=nameWithType> |
| `Union` or `UnionBy` | Returns the set union, which means unique elements that appear in either of two collections. | Not applicable. | <xref:System.Linq.Enumerable.Union%2A?displayProperty=nameWithType><br /><xref:System.Linq.Enumerable.UnionBy%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Union%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.UnionBy%2A?displayProperty=nameWithType> |

## `Distinct` and `DistinctBy`

The following example depicts the behavior of the <xref:System.Linq.Enumerable.Distinct%2A?displayProperty=nameWithType> method on a sequence of strings. The returned sequence contains the unique elements from the input sequence.

:::image type="content" source="./media/set-operations/distinct-method-behavior.png" alt-text="Graphic showing the behavior of Distinct()":::

:::code language="csharp" source="snippets/standard-query-operators/SetOperations.cs" id="Distinct":::

The [`DistinctBy`](xref:System.Linq.Enumerable.DistinctBy%2A?displayProperty=nameWithType) is an alternative approach to `Distinct` that takes a `keySelector`. The `keySelector` is used as the comparative discriminator of the source type. In the following code, words are discriminated based on their `Length`, and the first word of each length is displayed:

:::code source="./snippets/standard-query-operators/SetOperations.cs" id="DistinctBy":::

## `Except` and `ExceptBy`

The following example depicts the behavior of <xref:System.Linq.Enumerable.Except%2A?displayProperty=nameWithType>. The returned sequence contains only the elements from the first input sequence that aren't in the second input sequence.

:::image type="content" source="./media/set-operations/except-behavior-graphic.png" alt-text="Graphic showing the action of Except()":::

[!INCLUDE [Datasources](../includes/data-sources-definition.md)]

:::code language="csharp" source="./snippets/standard-query-operators/SetOperations.cs" id="Except":::

The <xref:System.Linq.Enumerable.ExceptBy%2A> method is an alternative approach to `Except` that takes two sequences of possibly heterogenous types and a `keySelector`. The `keySelector` is the same type as the first collection's type. Consider the following `Teacher` array and teacher IDs to exclude. To find teachers in the first collection that aren't in the second collection, you can project the teacher's ID onto the second collection:

:::code language="csharp" source="snippets/standard-query-operators/SetOperations.cs" id="ExceptBy":::

In the preceding C# code:

- The `teachers` array is filtered to only those teachers that aren't in the `teachersToExclude` array.
- The `teachersToExclude` array contains the `ID` value for all department heads.
- The call to `ExceptBy` results in a new set of values that are written to the console.

The new set of values is of type `Teacher`, which is the type of the first collection. Each `teacher` in the `teachers` array that doesn't have a corresponding ID value in the `teachersToExclude` array is written to the console.

## `Intersect` and `IntersectBy`

The following example depicts the behavior of <xref:System.Linq.Enumerable.Intersect%2A?displayProperty=nameWithType>. The returned sequence contains the elements that are common to both of the input sequences.

:::image type="content" source="./media/set-operations/intersection-two-sequences.png" alt-text="Graphic showing the intersection of two sequences":::

:::code language="csharp" source="./snippets/standard-query-operators/SetOperations.cs" id="Intersect":::

The <xref:System.Linq.Enumerable.IntersectBy%2A> method is an alternative approach to `Intersect` that takes two sequences of possibly heterogenous types and a `keySelector`. The `keySelector` is used as the comparative discriminator of the second collection's type. Consider the following student and teacher arrays. The query matches items in each sequence by name to find those students who are also teachers:

:::code language="csharp" source="./snippets/standard-query-operators/SetOperations.cs" id="IntersectBy":::

In the preceding C# code:

- The query produces the intersection of the `Teacher` and `Student` by comparing names.
- Only people that are found in both arrays are present in the resulting sequence.
- The resulting `Student` instances are written to the console.

## `Union` and `UnionBy`

The following example depicts a union operation on two sequences of strings. The returned sequence contains the unique elements from both input sequences.

:::image type="content" source="./media/set-operations/union-operation-two-sequences.png" alt-text="Graphic showing the union of two sequences.":::

:::code language="csharp" source="./snippets/standard-query-operators/SetOperations.cs" id="Union":::

The <xref:System.Linq.Enumerable.UnionBy%2A> method is an alternative approach to `Union` that takes two sequences of the same type and a `keySelector`. The `keySelector` is used as the comparative discriminator of the source type. The following query produces the list of all people that are either students or teachers. Students who are also teachers are added to the union set only once:

:::code language="csharp" source="./snippets/standard-query-operators/SetOperations.cs" id="UnionBy":::

In the preceding C# code:

- The `teachers` and `students` arrays are woven together using their names as the key selector.
- The resulting names are written to the console.

## See also

- <xref:System.Linq>
- [How to find the set difference between two lists (LINQ) (C#)](../how-to-query-collections.md)
