---
description: "Learn more about: Writing Your First LINQ Query (Visual Basic)"
title: "Writing Your First LINQ Query"
ms.date: 07/20/2015
helpviewer_keywords:
  - "queries [LINQ in Visual Basic], writing"
  - "LINQ queries [Visual Basic]"
  - "LINQ [Visual Basic], writing queries"
ms.assetid: 4affb732-3e9b-4479-aa31-1f9bd8183cbe
---
# Writing Your First LINQ Query (Visual Basic)

A *query* is an expression that retrieves data from a data source. Queries are expressed in a dedicated query language. Over time, different languages have been developed for different types of data sources, for example, SQL for relational databases and XQuery for XML. This makes it necessary for the application developer to learn a new query language for each type of data source or data format that is supported.

 Language-Integrated Query (LINQ) simplifies the situation by offering a consistent model for working with data across various kinds of data sources and formats. In a LINQ query, you are always working with objects. You use the same basic coding patterns to query and transform data in XML documents, SQL databases, ADO.NET datasets and entities, .NET Framework collections, and any other source or format for which a LINQ provider is available. This document describes the three phases of the creation and use of basic LINQ queries.

## Three Stages of a Query Operation

 LINQ query operations consist of three actions:

1. Obtain the data source or sources.

2. Create the query.

3. Execute the query.

 In LINQ, the execution of a query is distinct from the creation of the query. You do not retrieve any data just by creating a query. This point is discussed in more detail later in this topic.

 The following example illustrates the three parts of a query operation. The example uses an array of integers as a convenient data source for demonstration purposes. However, the same concepts also apply to other data sources.

> [!NOTE]
> On the [Compile Page, Project Designer (Visual Basic)](/visualstudio/ide/reference/compile-page-project-designer-visual-basic), ensure that **Option infer** is set to **On**.

 [!code-vb[VbLINQFirstQuery#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQFirstQuery/VB/Class1.vb#1)]

 Output:

 `0 2 4 6`

## The Data Source

 Because the data source in the previous example is an array, it implicitly supports the generic <xref:System.Collections.Generic.IEnumerable%601> interface. It is this fact that enables you to use an array as a data source for a LINQ query. Types that support <xref:System.Collections.Generic.IEnumerable%601> or a derived interface such as the generic <xref:System.Linq.IQueryable%601> are called *queryable types*.

 As an implicitly queryable type, the array requires no modification or special treatment to serve as a LINQ data source. The same is true for any collection type that supports <xref:System.Collections.Generic.IEnumerable%601>, including the generic <xref:System.Collections.Generic.List%601>, <xref:System.Collections.Generic.Dictionary%602>, and other classes in the .NET Framework class library.

 If the source data does not already implement <xref:System.Collections.Generic.IEnumerable%601>, a LINQ provider is needed to implement the functionality of the *standard query operators* for that data source. For example, LINQ to XML handles the work of loading an XML document into a queryable <xref:System.Xml.Linq.XElement> type, as shown in the following example. For more information about standard query operators, see [Standard Query Operators Overview (Visual Basic)](standard-query-operators-overview.md).

 [!code-vb[VbLINQFirstQuery#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQFirstQuery/VB/Class1.vb#2)]

 With [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)], you first create an object-relational mapping at design time, either manually or by using the [LINQ to SQL Tools in Visual Studio](/visualstudio/data-tools/linq-to-sql-tools-in-visual-studio2) in Visual Studio. You write your queries against the objects, and at run-time [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] handles the communication with the database. In the following example, `customers` represents a specific table in the database, and <xref:System.Data.Linq.Table%601> supports generic <xref:System.Linq.IQueryable%601>.

```vb
' Create a data source from a SQL table.
Dim db As New DataContext("C:\Northwind\Northwnd.mdf")
Dim customers As Table(Of Customer) = db.GetTable(Of Customer)
```

 For more information about how to create specific types of data sources, see the documentation for the various LINQ providers. (For a list of these providers, see [LINQ (Language-Integrated Query)](index.md).) The basic rule is simple: a LINQ data source is any object that supports the generic <xref:System.Collections.Generic.IEnumerable%601> interface, or an interface that inherits from it.

> [!NOTE]
> Types such as <xref:System.Collections.ArrayList> that support the non-generic <xref:System.Collections.IEnumerable> interface can also be used as LINQ data sources. For an example that uses an <xref:System.Collections.ArrayList>, see [How to: Query an ArrayList with LINQ (Visual Basic)](how-to-query-an-arraylist-with-linq.md).

## The Query

 In the query, you specify what information you want to retrieve from the data source or sources. You also have the option of specifying how that information should be sorted, grouped, or structured before it is returned. To enable query creation, Visual Basic has incorporated new query syntax into the language.

 When it is executed, the query in the following example returns all the even numbers from an integer array, `numbers`.

 [!code-vb[VbLINQFirstQuery#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQFirstQuery/VB/Class1.vb#1)]

 The query expression contains three clauses: `From`, `Where`, and `Select`. The specific function and purpose of each query expression clause is discussed in [Basic Query Operations (Visual Basic)](basic-query-operations.md). For more information, see [Queries](../../../language-reference/queries/index.md). Note that in LINQ, a query definition often is stored in a variable and executed later. The query variable, such as `evensQuery` in the previous example, must be a queryable type. The type of `evensQuery` is `IEnumerable(Of Integer)`, assigned by the compiler using local type inference.

 It is important to remember that the query variable itself takes no action and returns no data. It only stores the query definition. In the previous example, it is the `For Each` loop that executes the query.

## Query Execution

 Query execution is separate from query creation. Query creation defines the query, but execution is triggered by a different mechanism. A query can be executed as soon as it is defined (*immediate execution*), or the definition can be stored and the query can be executed later (*deferred execution*).

### Deferred Execution

 A typical LINQ query resembles the one in the previous example, in which `evensQuery` is defined. It creates the query but does not execute it immediately. Instead, the query definition is stored in the query variable `evensQuery`. You execute the query later, typically by using a `For Each` loop, which returns a sequence of values, or by applying a standard query operator, such as `Count` or `Max`. This process is referred to as *deferred execution*.

 [!code-vb[VbLINQFirstQuery#7](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQFirstQuery/VB/Class1.vb#7)]

 For a sequence of values, you access the retrieved data by using the iteration variable in the `For Each` loop (`number` in the previous example). Because the query variable, `evensQuery`, holds the query definition rather than the query results, you can execute a query as often as you want by using the query variable more than one time. For example, you might have a database in your application that is being updated continually by a separate application. After you have created a query that retrieves data from that database, you can use a `For Each` loop to execute the query repeatedly, retrieving the most recent data every time.

 The following example demonstrates how deferred execution works. After `evensQuery2` is defined and executed with a `For Each` loop, as in the previous examples, some elements in the data source `numbers` are changed. Then a second `For Each` loop runs `evensQuery2` again. The results are different the second time, because the `For Each` loop executes the query again, using the new values in `numbers`.

 [!code-vb[VbLINQFirstQuery#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQFirstQuery/VB/Class1.vb#3)]

 Output:

 `Evens in original array:`

 `0  2  4  6`

 `Evens in changed array:`

 `0  10  2  22  8`

### Immediate Execution

 In deferred execution of queries, the query definition is stored in a query variable for later execution. In immediate execution, the query is executed at the time of its definition. Execution is triggered when you apply a method that requires access to individual elements of the query result. Immediate execution often is forced by using one of the standard query operators that return single values. Examples are `Count`, `Max`, `Average`, and `First`. These standard query operators execute the query as soon as they are applied in order to calculate and return a singleton result. For more information about standard query operators that return single values, see [Aggregation Operations](aggregation-operations.md), [Element Operations](element-operations.md), and [Quantifier Operations](quantifier-operations.md).

 The following query returns a count of the even numbers in an array of integers. The query definition is not saved, and `numEvens` is a simple `Integer`.

 [!code-vb[VbLINQFirstQuery#4](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQFirstQuery/VB/Class1.vb#4)]

 You can achieve the same result by using the `Aggregate` method.

 [!code-vb[VbLINQFirstQuery#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQFirstQuery/VB/Class1.vb#5)]

 You can also force execution of a query by calling the `ToList` or `ToArray` method on a query (immediate) or query variable (deferred), as shown in the following code.

 [!code-vb[VbLINQFirstQuery#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbLINQFirstQuery/VB/Class1.vb#6)]

 In the previous examples, `evensQuery3` is a query variable, but `evensList` is a list and `evensArray` is an array.

 Using `ToList` or `ToArray` to force immediate execution is especially useful in scenarios in which you want to execute the query immediately and cache the results in a single collection object. For more information about these methods, see [Converting Data Types](converting-data-types.md).

 You can also cause a query to be executed by using an `IEnumerable` method such as the <xref:Microsoft.VisualBasic.Collection.System%23Collections%23IEnumerable%23GetEnumerator%2A> method.

## See also

- [Getting Started with LINQ in Visual Basic](getting-started-with-linq.md)
- [Local Type Inference](../../language-features/variables/local-type-inference.md)
- [Standard Query Operators Overview (Visual Basic)](standard-query-operators-overview.md)
- [Introduction to LINQ in Visual Basic](../../language-features/linq/introduction-to-linq.md)
- [LINQ](../../language-features/linq/index.md)
- [Queries](../../../language-reference/queries/index.md)
