---
title: "LINQ and collections"
description: This series of examples shows you a variety of LINQ techniques to use with collections and arrays
ms.topic: how-to
ms.date: 04/19/2024
---
# LINQ and collections

Say a few introductory words about LINQ and collections, LINQ to objects, and arrays.

## How to find the set difference between two lists

This example shows how to use LINQ to compare two lists of strings and output those lines that are in names1.txt but not in names2.txt.

Copy these names into a text file that is named names1.txt and save it in your project folder:

:::code language="txt" source="./snippets/HowToCollections/names1.txt" :::

Copy these names into a text file that is named names2.txt and save it in your project folder. Note that the two files have some names in common.

:::code language="txt" source="./snippets/HowToCollections/names2.txt" :::

The code follows:

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="SnippetSetDifferences":::

Some types of query operations in C#, such as <xref:System.Linq.Enumerable.Except%2A>, <xref:System.Linq.Enumerable.Distinct%2A>, <xref:System.Linq.Enumerable.Union%2A>, and <xref:System.Linq.Enumerable.Concat%2A>, can only be expressed in method-based syntax.

## How to combine and compare string collections

This example shows how to merge files that contain lines of text and then sort the results. Specifically, it shows how to perform a simple concatenation, a union, and an intersection on the two sets of text lines.

Copy these names into a text file that is named names1.txt and save it in your project folder:

:::code language="txt" source="./snippets/HowToCollections/names1.txt" :::

Copy these names into a text file that is named names2.txt and save it in your project folder. Note that the two files have some names in common.

:::code language="txt" source="./snippets/HowToCollections/names2.txt" :::

The code follows here:

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="CombineCompareStringCollections":::

## How to populate object collections from multiple sources

This example shows how to merge data from different sources into a sequence of new types.

> [!NOTE]
> Don't try to join in-memory data or data in the file system with data that is still in a database. Such cross-domain joins can yield undefined results because of different ways in which join operations might be defined for database queries and other types of sources. Additionally, there is a risk that such an operation could cause an out-of-memory exception if the amount of data in the database is large enough. To join data from a database to in-memory data, first call `ToList` or `ToArray` on the database query, and then perform the join on the returned collection.

Copy the names.csv and scores.csv files into your project folder, as described elsewhere in this file.

:::code language="txt" source="./snippets/HowToCollections/names.csv" :::

:::code language="txt" source="./snippets/HowToCollections/scores.csv" :::

The following example shows how to use a named type `Student` to store merged data from two in-memory collections of strings that simulate spreadsheet data in .csv format. The first collection of strings represents the student names and IDs, and the second collection represents the student ID (in the first column) and four exam scores. The ID is used as the foreign key.

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="PopulateCollection":::

In the [select](../language-reference/keywords/select-clause.md) clause, an object initializer is used to instantiate each new `Student` object by using the data from the two sources.

If you don't have to store the results of a query, anonymous types can be more convenient than named types. Named types are required if you pass the query results outside the method in which the query is executed. The following example executes the same task as the previous example, but uses anonymous types instead of named types:

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="PopulateCollection2":::

## How to query an ArrayList with LINQ

When using LINQ to query non-generic <xref:System.Collections.IEnumerable> collections such as <xref:System.Collections.ArrayList>, you must explicitly declare the type of the range variable to reflect the specific type of the objects in the collection. For example, if you have an <xref:System.Collections.ArrayList> of `Student` objects, your [from clause](../language-reference/keywords/from-clause.md) should look like this:

```csharp
var query = from Student s in arrList
//...
```

By specifying the type of the range variable, you are casting each item in the <xref:System.Collections.ArrayList> to a `Student`.

The use of an explicitly typed range variable in a query expression is equivalent to calling the <xref:System.Linq.Enumerable.Cast%2A> method. <xref:System.Linq.Enumerable.Cast%2A> throws an exception if the specified cast cannot be performed. <xref:System.Linq.Enumerable.Cast%2A> and <xref:System.Linq.Enumerable.OfType%2A> are the two Standard Query Operator methods that operate on non-generic <xref:System.Collections.IEnumerable> types. For more information, see [Type Relationships in LINQ Query Operations](get-started/type-relationships-in-linq-query-operations.md).

The following example shows a simple query over an <xref:System.Collections.ArrayList>. Note that this example uses object initializers when the code calls the <xref:System.Collections.ArrayList.Add%2A> method, but this is not a requirement.

:::code language="csharp" source="./snippets/HowToCollections/Program.cs" id="QueryArrayList":::
