---
title: "Standard Query Operators Overview (C#)"
description: The LINQ standard query operators provide query capabilities including filtering, projection, aggregation, and sorting in C#.
ms.date: 01/22/2024
---
# Standard Query Operators Overview

The *standard query operators* are the methods that form the LINQ pattern. Most of these methods operate on sequences, where a sequence is an object whose type implements the <xref:System.Collections.Generic.IEnumerable%601> interface or the <xref:System.Linq.IQueryable%601> interface. The standard query operators provide query capabilities including filtering, projection, aggregation, sorting and more.

There are two sets of LINQ standard query operators: one that operates on objects of type <xref:System.Collections.Generic.IEnumerable%601>, another that operates on objects of type <xref:System.Linq.IQueryable%601>. The methods that make up each set are static members of the <xref:System.Linq.Enumerable> and <xref:System.Linq.Queryable> classes, respectively. They are defined as *extension methods* of the type that they operate on. Extension methods can be called by using either static method syntax or instance method syntax.

In addition, several standard query operator methods operate on types other than those based on <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Linq.IQueryable%601>. The <xref:System.Linq.Enumerable> type defines two such methods that both operate on objects of type <xref:System.Collections.IEnumerable>. These methods, <xref:System.Linq.Enumerable.Cast%60%601%28System.Collections.IEnumerable%29> and <xref:System.Linq.Enumerable.OfType%60%601%28System.Collections.IEnumerable%29>, let you enable a non-parameterized, or non-generic, collection to be queried in the LINQ pattern. They do this by creating a strongly typed collection of objects. The <xref:System.Linq.Queryable> class defines two similar methods, <xref:System.Linq.Queryable.Cast%60%601%28System.Linq.IQueryable%29> and <xref:System.Linq.Queryable.OfType%60%601%28System.Linq.IQueryable%29>, that operate on objects of type <xref:System.Linq.IQueryable>.

The standard query operators differ in the timing of their execution, depending on whether they return a singleton value or a sequence of values. Those methods that return a singleton value (for example, <xref:System.Linq.Enumerable.Average%2A> and <xref:System.Linq.Enumerable.Sum%2A>) execute immediately. Methods that return a sequence defer the query execution and return an enumerable object.

For methods that operate on in-memory collections, that is, those methods that extend <xref:System.Collections.Generic.IEnumerable%601>, the returned enumerable object captures the arguments that were passed to the method. When that object is enumerated, the logic of the query operator is employed and the query results are returned.

In contrast, methods that extend <xref:System.Linq.IQueryable%601> don't implement any querying behavior. They build an expression tree that represents the query to be performed. The query processing is handled by the source <xref:System.Linq.IQueryable%601> object.

Calls to query methods can be chained together in one query, which enables queries to become arbitrarily complex.

The following code example demonstrates how the standard query operators can be used to obtain information about a sequence.

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="FirstSentence":::

## Query expression syntax

Some of the more frequently used standard query operators have dedicated C# and Visual Basic language keyword syntax that enables them to be called as part of a *query* *expression*.

## Extending the standard query operators

You can augment the set of standard query operators by creating domain-specific methods that are appropriate for your target domain or technology. You can also replace the standard query operators with your own implementations that provide additional services such as remote evaluation, query translation, and optimization. See <xref:System.Linq.Enumerable.AsEnumerable%2A> for an example.

## Obtain a data source

In a LINQ query, the first step is to specify the data source. In C# as in most programming languages a variable must be declared before it can be used. In a LINQ query, the `from` clause comes first in order to introduce the data source (`customers`) and the *range variable* (`cust`).

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="ObtainDataSource":::

The range variable is like the iteration variable in a `foreach` loop except that no actual iteration occurs in a query expression. When the query is executed, the range variable will serve as a reference to each successive element in `customers`. Because the compiler can infer the type of `cust`, you do not have to specify it explicitly. Additional range variables can be introduced by a `let` clause. For more information, see [let clause](../../language-reference/keywords/let-clause.md).

> [!NOTE]
> For non-generic data sources such as <xref:System.Collections.ArrayList>, the range variable must be explicitly typed. For more information, see [How to query an ArrayList with LINQ (C#)](../../programming-guide/concepts/linq/how-to-query-an-arraylist-with-linq.md) and [from clause](../../language-reference/keywords/from-clause.md).

## Filtering

Probably the most common query operation is to apply a filter in the form of a Boolean expression. The filter causes the query to return only those elements for which the expression is true. The result is produced by using the `where` clause. The filter in effect specifies which elements to exclude from the source sequence. In the following example, only those `customers` who have an address in London are returned.

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="CityFilter":::

You can use the familiar C# logical `AND` and `OR` operators to apply as many filter expressions as necessary in the `where` clause. For example, to return only customers from "London" `AND` whose name is "Devon" you would write the following code:

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="AndFilter":::

To return customers from London or Paris, you would write the following code:

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="OrFilter":::

For more information, see [where clause](../../language-reference/keywords/where-clause.md).

## Ordering

Often it is convenient to sort the returned data. The `orderby` clause will cause the elements in the returned sequence to be sorted according to the default comparer for the type being sorted. For example, the following query can be extended to sort the results based on the `Name` property. Because `Name` is a string, the default comparer performs an alphabetical sort from A to Z.

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="Ordering":::

To order the results in reverse order, from Z to A, use the `orderby…descending` clause.

For more information, see [orderby clause](../../language-reference/keywords/orderby-clause.md).

## Grouping

The `group` clause enables you to group your results based on a key that you specify. For example you could specify that the results should be grouped by the `City` so that all customers from London or Paris are in individual groups. In this case, `cust.City` is the key.

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="Grouping":::

When you end a query with a `group` clause, your results take the form of a list of lists. Each element in the list is an object that has a `Key` member and a list of elements that are grouped under that key. When you iterate over a query that produces a sequence of groups, you must use a nested `foreach` loop. The outer loop iterates over each group, and the inner loop iterates over each group's members.

If you must refer to the results of a group operation, you can use the `into` keyword to create an identifier that can be queried further. The following query returns only those groups that contain more than two customers:

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="GroupInto":::

For more information, see [group clause](../../language-reference/keywords/group-clause.md).

## Joining

Join operations create associations between sequences that are not explicitly modeled in the data sources. For example you can perform a join to find all the customers and distributors who have the same location. In LINQ the `join` clause always works against object collections instead of database tables directly.

ard-query-operators/IndexExamples.cs" id="Join":::

In LINQ, you do not have to use `join` as often as you do in SQL, because foreign keys in LINQ are represented in the object model as properties that hold a collection of items. For example, a `Customer` object contains a collection of `Order` objects. Rather than performing a join, you access the orders by using dot notation:

```csharp
from order in Customer.Orders
```

For more information, see [join clause](../../language-reference/keywords/join-clause.md).

## Selecting (Projections)

The `select` clause produces the results of the query and specifies the "shape" or type of each returned element. For example, you can specify whether your results will consist of complete `Customer` objects, just one member, a subset of members, or some completely different result type based on a computation or new object creation. When the `select` clause produces something other than a copy of the source element, the operation is called a *projection*. The use of projections to transform data is a powerful capability of LINQ query expressions. For more information, see [Data Transformations with LINQ (C#)](../../programming-guide/concepts/linq/data-transformations-with-linq.md) and [select clause](../../language-reference/keywords/select-clause.md).

## Query Expression Syntax Table

The following table lists the standard query operators that have equivalent query expression clauses.

| Method | C# query expression syntax |
|------------|---------------------------------|
|<xref:System.Linq.Enumerable.Cast%2A>|Use an explicitly typed range variable, for example:<br /><br /> `from int i in numbers`<br /><br /> (For more information, see [from clause](../../language-reference/keywords/from-clause.md).)|
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

Language-Integrated Query (LINQ) is not only about retrieving data. It is also a powerful tool for transforming data. By using a LINQ query, you can use a source sequence as input and modify it in many ways to create a new output sequence. You can modify the sequence itself without modifying the elements themselves by sorting and grouping. But perhaps the most powerful feature of LINQ queries is the ability to create new types. This is accomplished in the [select](../../language-reference/keywords/select-clause.md) clause. For example, you can perform the following tasks:

- Merge multiple input sequences into a single output sequence that has a new type.
- Create output sequences whose elements consist of only one or several properties of each element in the source sequence.
- Create output sequences whose elements consist of the results of operations performed on the source data.
- Create output sequences in a different format. For example, you can transform data from SQL rows or text files into XML.

These are just several examples. Of course, these transformations can be combined in various ways in the same query. Furthermore, the output sequence of one query can be used as the input sequence for a new query.

### Joining Multiple Inputs into One Output Sequence

You can use a LINQ query to create an output sequence that contains elements from more than one input sequence. The following example shows how to combine two in-memory data structures, but the same principles can be applied to combine data from XML or SQL or DataSet sources. Assume the following two class types:

:::code language="csharp" source="./snippets/standard-query-operators/DataSources.cs" id="QueryDataSource":::

The following example shows the query:

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="Transformations":::

For more information, see [join clause](../../language-reference/keywords/join-clause.md) and [select clause](../../language-reference/keywords/select-clause.md).

### Selecting a Subset of each Source Element

There are two primary ways to select a subset of each element in the source sequence:

1. To select just one member of the source element, use the dot operation. In the following example, assume that a `Customer` object contains several public properties including a string named `City`. When executed, this query will produce an output sequence of strings.
   :::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="Properties":::
1. To create elements that contain more than one property from the source element, you can use an object initializer with either a named object or an anonymous type. The following example shows the use of an anonymous type to encapsulate two properties from each `Customer` element:
   :::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="AnonymousTypes":::

For more information, see [Object and Collection Initializers](../../programming-guide/classes-and-structs/object-and-collection-initializers.md) and [Anonymous Types](../../fundamentals/types/anonymous-types.md).

### Transforming in-Memory Objects into XML

LINQ queries make it easy to transform data between in-memory data structures, SQL databases, ADO.NET Datasets and XML streams or documents. The following example transforms objects in an in-memory data structure into XML elements.

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="XmlTransformation":::

The code produces the following XML output:

:::code language="xml" source="./snippets/standard-query-operators/IndexExamples.cs" id="XmlTransformationOutput":::

For more information, see [Creating XML Trees in C# (LINQ to XML)](../../../standard/linq/create-xml-trees.md).

### Performing Operations on Source Elements

An output sequence might not contain any elements or element properties from the source sequence. The output might instead be a sequence of values that is computed by using the source elements as input arguments.

The following query will take a sequence of numbers that represent radii of circles, calculate the area for each radius, and return an output sequence containing strings formatted with the calculated area.

Each string for the output sequence will be formatted using [string interpolation](../../language-reference/tokens/interpolated.md). An interpolated string will have a `$` in front of the string's opening quotation mark, and operations can be performed within curly braces placed inside the interpolated string. Once those operations are performed, the results will be concatenated.

> [!NOTE]
> Calling methods in query expressions is not supported if the query will be translated into some other domain. For example, you cannot call an ordinary C# method in [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] because SQL Server has no context for it. However, you can map stored procedures to methods and call those. For more information, see [Stored Procedures](../../../framework/data/adonet/sql/linq/stored-procedures.md).

:::code language="csharp" source="./snippets/standard-query-operators/IndexExamples.cs" id="MethodQuery":::

Many of the samples in this section use a common data source, shown in the following code:

:::code language="csharp" source="./snippets/standard-query-operators/DataSources.cs" id="QueryDataSource":::

## Concepts to add in this article

- The result of most queries (other than aggregations) is a sequence. It can be the source of subsequent queries. (e.g. multiple joins, join, order, etc.)

## See also

- <xref:System.Linq.Enumerable>
- <xref:System.Linq.Queryable>
- [select clause](../../language-reference/keywords/select-clause.md)
- [Extension Methods](../../programming-guide/classes-and-structs/extension-methods.md)
- [Query Keywords (LINQ)](../../language-reference/keywords/query-keywords.md)
- [Anonymous Types](../../fundamentals/types/anonymous-types.md)
