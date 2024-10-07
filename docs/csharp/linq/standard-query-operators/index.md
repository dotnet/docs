---
title: "Standard Query Operators Overview"
description: The LINQ standard query operators provide query capabilities including filtering, projection, aggregation, and sorting in C#.
ms.date: 05/29/2024
---
# Standard Query Operators Overview

The *standard query operators* are the keywords and methods that form the LINQ pattern. The C# language defines [LINQ query keywords](../../language-reference/keywords/query-keywords.md) that you use for the most common query expression. The compiler translates expressions using these keywords to the equivalent method calls. The two forms are synonymous. Other methods that are part of the <xref:System.Linq?displayProperty=fullName> namespace don't have equivalent query keywords. In those cases, you must use the method syntax. This section covers all the query operator keywords. The runtime and other NuGet packages add more methods designed to work with LINQ queries each release. The most common methods, including those that have query keyword equivalents are covered in this section. For the full list of query methods supported by the .NET Runtime, see the <xref:System.Linq.Enumerable?displayProperty=fullName> API documentation. In addition to the methods covered here, this class contains methods for concatenating data sources, computing a single value from a data source, such as a sum, average, or other value.

[!INCLUDE [Prerequisites](../includes/linq-syntax.md)]

Most of these methods operate on sequences, where a sequence is an object whose type implements the <xref:System.Collections.Generic.IEnumerable%601> interface or the <xref:System.Linq.IQueryable%601> interface. The standard query operators provide query capabilities including filtering, projection, aggregation, sorting and more. The methods that make up each set are static members of the <xref:System.Linq.Enumerable> and <xref:System.Linq.Queryable> classes, respectively. They're defined as [*extension methods*](../../programming-guide/classes-and-structs/extension-methods.md) of the type that they operate on.

The distinction between <xref:System.Collections.Generic.IEnumerable%601> and <xref:System.Linq.IQueryable%601> sequences determines how the query is executed at runtime.

For `IEnumerable<T>`, the returned enumerable object captures the arguments that were passed to the method. When that object is enumerated, the logic of the query operator is employed and the query results are returned.

For `IQueryable<T>`, the query is translated into an [expression tree](../../advanced-topics/expression-trees/index.md). The expression tree can be translated to a native query when the data source can optimize the query. Libraries such as [Entity Framework](/ef/core/) translate LINQ queries into native SQL queries that execute at the database.

The following code example demonstrates how the standard query operators can be used to obtain information about a sequence.

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="FirstSentence":::

Where possible, the queries in this section use a sequence of words or numbers as the input source. For queries where more complicated relationships between objects are used, the following sources that model a school are used:

:::code language="csharp" source="./snippets/standard-query-operators/DataSources.cs" id="QueryDataSource":::

Each `Student` has a grade level, a primary department, and a series of scores. A `Teacher` also has a `City` property that identifies the campus where the teacher holds classes. A `Department` has a name, and a reference to a `Teacher` who serves as the department head.

You can find the data set in the [source repo](https://github.com/dotnet/docs/blob/main/docs/csharp/linq/standard-query-operators/snippets/standard-query-operators/DataSources.cs#L41).

## Types of query operators

The standard query operators differ in the timing of their execution, depending on whether they return a singleton value or a sequence of values. Those methods that return a singleton value (such as <xref:System.Linq.Enumerable.Average%2A> and <xref:System.Linq.Enumerable.Sum%2A>) execute immediately. Methods that return a sequence defer the query execution and return an enumerable object. You can use the output sequence of one query as the input sequence to another query. Calls to query methods can be chained together in one query, which enables queries to become arbitrarily complex.

## Query operators

In a LINQ query, the first step is to specify the data source. In a LINQ query, the `from` clause comes first in order to introduce the data source (`students`) and the *range variable* (`student`).

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="ObtainDataSource":::

The range variable is like the iteration variable in a `foreach` loop except that no actual iteration occurs in a query expression. When the query is executed, the range variable serves as a reference to each successive element in `students`. Because the compiler can infer the type of `student`, you don't have to specify it explicitly. You can introduce more range variables in a `let` clause. For more information, see [let clause](../../language-reference/keywords/let-clause.md).

> [!NOTE]
> For non-generic data sources such as <xref:System.Collections.ArrayList>, the range variable must be explicitly typed. For more information, see [How to query an ArrayList with LINQ (C#)](../how-to-query-collections.md) and [from clause](../../language-reference/keywords/from-clause.md).

Once you obtain a data source, you can perform any number of operations on that data source:

- [Filter data](filtering-data.md) using the `where` keyword.
- [Order data](sorting-data.md) using the `orderby` and optionally `descending` keywords.
- [Group data](grouping-data.md) using the `group` and optionally `into` keywords.
- [Join data](join-operations.md) using the `join` keyword.
- [Project data](projection-operations.md) using the `select` keyword.

## Query Expression Syntax Table

The following table lists the standard query operators that have equivalent query expression clauses.

| Method | C# query expression syntax |
|------------|---------------------------------|
|<xref:System.Linq.Enumerable.Cast%2A>|Use an explicitly typed range variable:<br /><br /> `from int i in numbers`<br /><br /> (For more information, see [from clause](../../language-reference/keywords/from-clause.md).)|
|<xref:System.Linq.Enumerable.GroupBy%2A>|`group … by`<br /><br /> -or-<br /><br /> `group … by … into …`<br /><br /> (For more information, see [group clause](../../language-reference/keywords/group-clause.md).)|
|<xref:System.Linq.Enumerable.GroupJoin%60%604%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Collections.Generic.IEnumerable%7B%60%601%7D%2CSystem.Func%7B%60%600%2C%60%602%7D%2CSystem.Func%7B%60%601%2C%60%602%7D%2CSystem.Func%7B%60%600%2CSystem.Collections.Generic.IEnumerable%7B%60%601%7D%2C%60%603%7D%29>|`join … in … on … equals … into …`<br /><br /> (For more information, see [join clause](../../language-reference/keywords/join-clause.md).)|
|<xref:System.Linq.Enumerable.Join%60%604%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Collections.Generic.IEnumerable%7B%60%601%7D%2CSystem.Func%7B%60%600%2C%60%602%7D%2CSystem.Func%7B%60%601%2C%60%602%7D%2CSystem.Func%7B%60%600%2C%60%601%2C%60%603%7D%29>|`join … in … on … equals …`<br /><br /> (For more information, see [join clause](../../language-reference/keywords/join-clause.md).)|
|<xref:System.Linq.Enumerable.OrderBy%60%602%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%600%2C%60%601%7D%29>|`orderby`<br /><br /> (For more information, see [orderby clause](../../language-reference/keywords/orderby-clause.md).)|
|<xref:System.Linq.Enumerable.OrderByDescending%60%602%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%600%2C%60%601%7D%29>|`orderby … descending`<br /><br /> (For more information, see [orderby clause](../../language-reference/keywords/orderby-clause.md).)|
|<xref:System.Linq.Enumerable.Select%2A>|`select`<br /><br /> (For more information, see [select clause](../../language-reference/keywords/select-clause.md).)|
|<xref:System.Linq.Enumerable.SelectMany%2A>|Multiple `from` clauses.<br /><br /> (For more information, see [from clause](../../language-reference/keywords/from-clause.md).)|
|<xref:System.Linq.Enumerable.ThenBy%60%602%28System.Linq.IOrderedEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%600%2C%60%601%7D%29>|`orderby …, …`<br /><br /> (For more information, see [orderby clause](../../language-reference/keywords/orderby-clause.md).)|
|<xref:System.Linq.Enumerable.ThenByDescending%60%602%28System.Linq.IOrderedEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%600%2C%60%601%7D%29>|`orderby …, … descending`<br /><br /> (For more information, see [orderby clause](../../language-reference/keywords/orderby-clause.md).)|
|<xref:System.Linq.Enumerable.Where%2A>|`where`<br /><br /> (For more information, see [where clause](../../language-reference/keywords/where-clause.md).)|

## Data Transformations with LINQ

Language-Integrated Query (LINQ) isn't only about retrieving data. It's also a powerful tool for transforming data. By using a LINQ query, you can use a source sequence as input and modify it in many ways to create a new output sequence. You can modify the sequence itself without modifying the elements themselves by sorting and grouping. But perhaps the most powerful feature of LINQ queries is the ability to create new types. The [select](../../language-reference/keywords/select-clause.md) clause creates an output element from an input element. You use it to transform an input element into an output element:

- Merge multiple input sequences into a single output sequence that has a new type.
- Create output sequences whose elements consist of only one or several properties of each element in the source sequence.
- Create output sequences whose elements consist of the results of operations performed on the source data.
- Create output sequences in a different format. For example, you can transform data from SQL rows or text files into XML.

These transformations can be combined in various ways in the same query. Furthermore, the output sequence of one query can be used as the input sequence for a new query. The following example transforms objects in an in-memory data structure into XML elements.

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="XmlTransformation":::

The code produces the following XML output:

:::code language="xml" source="./snippets/standard-query-operators/IndexExamples.cs" id="XmlTransformationOutput":::

For more information, see [Creating XML Trees in C# (LINQ to XML)](../../../standard/linq/create-xml-trees.md).

You can use the results of one query as the data source for a subsequent query. This example shows how to order the results of a join operation. This query creates a group join, and then sorts the groups based on the category element, which is still in scope. Inside the anonymous type initializer, a subquery orders all the matching elements from the products sequence.

:::code language="csharp" source="./snippets/standard-query-operators/OrderResultsOfJoin.cs" id="OrderResultsOfJoinQuery":::

The equivalent query using method syntax is shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/OrderResultsOfJoin.cs" id="OrderResultsOfJoinMethod":::

Although you can use an `orderby` clause with one or more of the source sequences before the join, generally we don't recommend it. Some LINQ providers might not preserve that ordering after the join. For more information, see [join clause](../../language-reference/keywords/join-clause.md).

## See also

- <xref:System.Linq.Enumerable>
- <xref:System.Linq.Queryable>
- [select clause](../../language-reference/keywords/select-clause.md)
- [Extension Methods](../../programming-guide/classes-and-structs/extension-methods.md)
- [Query Keywords (LINQ)](../../language-reference/keywords/query-keywords.md)
- [Anonymous Types](../../fundamentals/types/anonymous-types.md)
