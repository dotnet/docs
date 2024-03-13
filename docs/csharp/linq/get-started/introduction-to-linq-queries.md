---
title: "Introduction to LINQ Queries (C#)"
description: LINQ offers a consistent model for queries on data across various kinds of data sources and formats. In a LINQ query, you're always working with objects.
ms.date: 12/14/2023
helpviewer_keywords:
  - "deferred execution [LINQ]"
  - "LINQ, queries"
  - "LINQ, deferred execution"
  - "queries [LINQ], about LINQ queries"
---
# Introduction to LINQ Queries (C#)

A *query* is an expression that retrieves data from a data source. Different data sources have different native query languages, for example SQL for relational databases and XQuery for XML. Developers must learn a new query language for each type of data source or data format that they must support. LINQ simplifies this situation by offering a consistent C# language model for kinds of data sources and formats. In a LINQ query, you always work with C# objects. You use the same basic coding patterns to query and transform data in XML documents, SQL databases, .NET collections, and any other format when a LINQ provider is available.

## Three Parts of a Query Operation

All LINQ query operations consist of three distinct actions:

1. Obtain the data source.
1. Create the query.
1. Execute the query.

The following example shows how the three parts of a query operation are expressed in source code. The example uses an integer array as a data source for convenience; however, the same concepts apply to other data sources also. This example is referred to throughout the rest of this article.

:::code language="csharp" source="./snippets/SnippetApp/Program.cs" id="PartsOfAQuery":::

The following illustration shows the complete query operation. In LINQ, the execution of the query is distinct from the query itself. In other words, you don't retrieve any data by creating a query variable.

![Diagram of the complete LINQ query operation.](./media/introduction-to-linq-queries/linq-query-complete-operation.png)

## The Data Source

The data source in the preceding example is an array, which supports the generic <xref:System.Collections.Generic.IEnumerable%601> interface. This fact means it can be queried with LINQ. A query is executed in a `foreach` statement, and `foreach` requires <xref:System.Collections.IEnumerable> or <xref:System.Collections.Generic.IEnumerable%601>. Types that support <xref:System.Collections.Generic.IEnumerable%601> or a derived interface such as the generic <xref:System.Linq.IQueryable%601> are called *queryable types*.

A queryable type requires no modification or special treatment to serve as a LINQ data source. If the source data isn't already in memory as a queryable type, the LINQ provider must represent it as such. For example, LINQ to XML loads an XML document into a queryable <xref:System.Xml.Linq.XElement> type:

:::code language="csharp" source="./snippets/SnippetApp/Program.cs" id="LoadXML":::

With [EntityFramework](/ef/core/), you create an object-relational mapping between C# classes and your database schema. You write your queries against the objects, and at run-time EntityFramework handles the communication with the database. In the following example, `Customers` represents a specific table in the database, and the type of the query result, <xref:System.Linq.IQueryable%601>, derives from <xref:System.Collections.Generic.IEnumerable%601>.

```csharp
Northwnd db = new Northwnd(@"c:\northwnd.mdf");

// Query for customers in London.
IQueryable<Customer> custQuery =
    from cust in db.Customers
    where cust.City == "London"
    select cust;
```

For more information about how to create specific types of data sources, see the documentation for the various LINQ providers. However, the basic rule is simple: a LINQ data source is any object that supports the generic <xref:System.Collections.Generic.IEnumerable%601> interface, or an interface that inherits from it, typically <xref:System.Linq.IQueryable%601>.

> [!NOTE]
> Types such as <xref:System.Collections.ArrayList> that support the non-generic <xref:System.Collections.IEnumerable> interface can also be used as a LINQ data source. For more information, see [How to query an ArrayList with LINQ (C#)](../../programming-guide/concepts/linq/how-to-query-an-arraylist-with-linq.md).

## The Query

The query specifies what information to retrieve from the data source or sources. Optionally, a query also specifies how that information should be sorted, grouped, and shaped before being returned. A query is stored in a query variable and initialized with a query expression. You use [C# query syntax](../../language-reference/keywords/query-keywords.md) to write queries.

The query in the previous example returns all the even numbers from the integer array. The query expression contains three clauses: `from`, `where` and `select`. (If you're familiar with SQL, you noticed that the ordering of the clauses is reversed from the order in SQL.) The `from` clause specifies the data source, the `where` clause applies the filter, and the `select` clause specifies the type of the returned elements. All the query clauses are discussed in detail in this section. For now, the important point is that in LINQ, the query variable itself takes no action and returns no data. It just stores the information that is required to produce the results when the query is executed at some later point. For more information about how queries are constructed, see [Standard Query Operators Overview (C#)](../standard-query-operators/index.md).

> [!NOTE]
> Queries can also be expressed by using method syntax. For more information, see [Query Syntax and Method Syntax in LINQ](write-linq-queries.md).

## Query Execution

### Deferred Execution

The query variable itself only stores the query commands. The actual execution of the query is deferred until you iterate over the query variable in a `foreach` statement. This concept is referred to as *deferred execution* and is demonstrated in the following example:

:::code language="csharp" source="./snippets/SnippetApp/Program.cs" id="QueryExecution":::

The `foreach` statement is also where the query results are retrieved. For example, in the previous query, the iteration variable `num` holds each value (one at a time) in the returned sequence.

Because the query variable itself never holds the query results, you can execute it repeatedly to retrieve updated data. For example, you might have a database that is being updated continually by a separate application. In your application, you could create one query that retrieves the latest data, and you could execute it at intervals to retrieve updated results.

### Forcing Immediate Execution

Queries that perform aggregation functions over a range of source elements must first iterate over those elements. Examples of such queries are `Count`, `Max`, `Average`, and `First`. These methods execute without an explicit `foreach` statement because the query itself must use `foreach` in order to return a result. These queries return a single value, not an `IEnumerable` collection. The following query returns a count of the even numbers in the source array:

:::code language="csharp" source="./snippets/SnippetApp/Program.cs" id="EagerEvaluation":::

To force immediate execution of any query and cache its results, you can call the <xref:System.Linq.Enumerable.ToList%2A> or <xref:System.Linq.Enumerable.ToArray%2A> methods.

:::code language="csharp" source="./snippets/SnippetApp/Program.cs" id="MoreEagerEvaluation":::

You can also force execution by putting the `foreach` loop immediately after the query expression. However, by calling `ToList` or `ToArray` you also cache all the data in a single collection object.

## See also

- [Walkthrough: Writing Queries in C#](../../programming-guide/concepts/linq//walkthrough-writing-queries-linq.md)
- [foreach, in](../../language-reference/statements/iteration-statements.md#the-foreach-statement)
- [Query Keywords (LINQ)](../../language-reference/keywords/query-keywords.md)
