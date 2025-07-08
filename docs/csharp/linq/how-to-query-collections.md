---
title: "How to: use LINQ to query or modify collections"
description: This series of examples shows you Language Integrated Query (LINQ) techniques to use with collections and arrays.
ms.topic: how-to
ms.date: 04/22/2024
---
# LINQ and collections

Most collections model a *sequence* of elements. You can use LINQ to query any collection type. Other LINQ methods find elements in a collection, compute values from the elements in a collection, or modify the collection or its elements. These examples help you learn about LINQ methods and how you can use them with your collections, or other data sources.

## How to find the set difference between two lists

This example shows how to use LINQ to compare two lists of strings and output those lines that are in first collection, but not in the second. The first collection of names is stored in the file *names1.txt*:

:::code language="txt" source="./snippets/HowToCollections/names1.txt" :::

The second collection of names is stored in the file *names2.txt*. Some names appear in both sequences.

:::code language="txt" source="./snippets/HowToCollections/names2.txt" :::

The following code shows how you can use the <xref:System.Linq.Enumerable.Except%2A?displayProperty=nameWithType> method to find elements in the first list that aren't in the second list:

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="SnippetSetDifferences":::

Some types of query operations, such as <xref:System.Linq.Enumerable.Except%2A>, <xref:System.Linq.Enumerable.Distinct%2A>, <xref:System.Linq.Enumerable.Union%2A>, and <xref:System.Linq.Enumerable.Concat%2A>, can only be expressed in method-based syntax.

## How to combine and compare string collections

This example shows how to merge files that contain lines of text and then sort the results. Specifically, it shows how to perform a concatenation, a union, and an intersection on the two sets of text lines. It uses the same two text files shows in the preceding example. The code shows examples of the <xref:System.Linq.Enumerable.Concat%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.Union%2A?displayProperty=nameWithType>, and <xref:System.Linq.Enumerable.Except%2A?displayProperty=nameWithType>.

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="CombineCompareStringCollections":::

## How to populate object collections from multiple sources

This example shows how to merge data from different sources into a sequence of new types.

> [!NOTE]
> Don't try to join in-memory data or data in the file system with data that is still in a database. Such cross-domain joins can yield undefined results because of different ways in which join operations might be defined for database queries and other types of sources. Additionally, there is a risk that such an operation could cause an out-of-memory exception if the amount of data in the database is large enough. To join data from a database to in-memory data, first call `ToList` or `ToArray` on the database query, and then perform the join on the returned collection.

This example uses two files. The first, *names.csv*, contains student names and student IDs.

:::code language="txt" source="./snippets/HowToCollections/names.csv" :::

The second, *scores.csv*, contains student IDs in the first column, followed by exam scores.

:::code language="txt" source="./snippets/HowToCollections/scores.csv" :::

The following example shows how to use a named record `Student` to store merged data from two in-memory collections of strings that simulate spreadsheet data in .csv format. The ID is used as the key to map students to their scores.

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="PopulateCollection":::

In the [select](../language-reference/keywords/select-clause.md) clause, each new `Student` object is initialized from the data in the two sources.

If you don't have to store the results of a query, tuples or anonymous types can be more convenient than named types. The following example executes the same task as the previous example, but uses tuples instead of named types:

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="PopulateCollection2":::

## How to query an ArrayList with LINQ

When using LINQ to query nongeneric <xref:System.Collections.IEnumerable> collections such as <xref:System.Collections.ArrayList>, you must explicitly declare the type of the range variable to reflect the specific type of the objects in the collection. If you have an <xref:System.Collections.ArrayList> of `Student` objects, your [from clause](../language-reference/keywords/from-clause.md) should look like this:

```csharp
var query = from Student s in arrList
//...
```

By specifying the type of the range variable, you're casting each item in the <xref:System.Collections.ArrayList> to a `Student`.

The use of an explicitly typed range variable in a query expression is equivalent to calling the <xref:System.Linq.Enumerable.Cast%2A> method. <xref:System.Linq.Enumerable.Cast%2A> throws an exception if the specified cast can't be performed. <xref:System.Linq.Enumerable.Cast%2A> and <xref:System.Linq.Enumerable.OfType%2A> are the two Standard Query Operator methods that operate on nongeneric <xref:System.Collections.IEnumerable> types. For more information, see [Type Relationships in LINQ Query Operations](get-started/type-relationships-in-linq-query-operations.md). The following example shows a query over an <xref:System.Collections.ArrayList>.

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="QueryArrayList":::
