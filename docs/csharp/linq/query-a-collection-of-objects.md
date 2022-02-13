---
title: Query a collection of objects (LINQ in C#)
description: Learn how query collections using LINQ in C#.
ms.date: 11/30/2016
ms.assetid: 87a76f8a-0b58-4791-90ea-2fe0a30416c9
---
# Query a collection of objects

This topic shows an example of how to perform a simple query over a list of `Student` objects. Each `Student` object contains some basic information about the student, and a list that represents the student's scores on four examinations.

> [!NOTE]
> Many other examples in this section use the same `Student` class and `students` collection.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/DataClasses.cs" id="query_a_collection_of_objects_1":::

## Example

The following query returns the students who received a score of 90 or greater on their first exam.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/QueryCollectionOfObjects.cs" id="query_a_collection_of_objects_2":::
  
This query is intentionally simple to enable you to experiment. For example, you can try more conditions in the `where` clause, or use an `orderby` clause to sort the results.
  
## See also

- [Language Integrated Query (LINQ)](index.md)
- [String interpolation](../language-reference/tokens/interpolated.md)
