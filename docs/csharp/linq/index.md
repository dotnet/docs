---
title: Language Integrated Query (LINQ) in C#
description: Introduces Language Integrated Query (LINQ) in C#.
ms.topic: conceptual
ms.date: 11/30/2016
ms.assetid: 007cc736-f5cf-4919-b99b-0c00ab2814ce
---
# Language Integrated Query (LINQ)

Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the C# language. Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support. Furthermore, you have to learn a different query language for each type of data source: SQL databases, XML documents, various Web services, and so on. With LINQ, a query is a first-class language construct, just like classes, methods, events.

For a developer who writes queries, the most visible "language-integrated" part of LINQ is the query expression. Query expressions are written in a declarative *query syntax*. By using query syntax, you can perform filtering, ordering, and grouping operations on data sources with a minimum of code. You use the same basic query expression patterns to query and transform data in SQL databases, ADO.NET Datasets, XML documents and streams, and .NET collections.

The following example shows the complete query operation. The complete operation includes creating a data source, defining the query expression, and executing the query in a `foreach` statement.

:::code language="csharp" source="../../../samples/snippets/csharp/concepts/linq/LinqSamples/Index.cs" id="intro":::

## Query expression overview

- Query expressions can be used to query and to transform data from any LINQ-enabled data source. For example, a single query can retrieve data from a SQL database, and produce an XML stream as output.

- Query expressions are easy to grasp because they use many familiar C# language constructs.

- The variables in a query expression are all strongly typed, although in many cases you do not have to provide the type explicitly because the compiler can infer it. For more information, see [Type relationships in LINQ query operations](../programming-guide/concepts/linq/type-relationships-in-linq-query-operations.md).

- A query is not executed until you iterate over the query variable, for example, in a `foreach` statement. For more information, see [Introduction to LINQ queries](../programming-guide/concepts/linq/introduction-to-linq-queries.md).

- At compile time, query expressions are converted to Standard Query Operator method calls according to the rules set forth in the C# specification. Any query that can be expressed by using query syntax can also be expressed by using method syntax. However, in most cases query syntax is more readable and concise. For more information, see [C# language specification](~/_csharpstandard/standard/expressions.md#1220-query-expressions) and [Standard query operators overview](../programming-guide/concepts/linq/standard-query-operators-overview.md).

- As a rule when you write LINQ queries, we recommend that you use query syntax whenever possible and method syntax whenever necessary. There is no semantic or performance difference between the two different forms. Query expressions are often more readable than equivalent expressions written in method syntax.

- Some query operations, such as <xref:System.Linq.Enumerable.Count%2A> or <xref:System.Linq.Enumerable.Max%2A>, have no equivalent query expression clause and must therefore be expressed as a method call. Method syntax can be combined with query syntax in various ways. For more information, see [Query syntax and method syntax in LINQ](../programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq.md).

- Query expressions can be compiled to expression trees or to delegates, depending on the type that the query is applied to. <xref:System.Collections.Generic.IEnumerable%601> queries are compiled to delegates. <xref:System.Linq.IQueryable> and <xref:System.Linq.IQueryable%601> queries are compiled to expression trees. For more information, see [Expression trees](/dotnet/csharp/advanced-topics/expression-trees).

## How to Enable LINQ Querying of Your Data Source  
  
### In-Memory Data  

 There are two ways you can enable LINQ querying of in-memory data. If the data is of a type that implements <xref:System.Collections.Generic.IEnumerable%601>, you can query the data by using LINQ to Objects. If it does not make sense to enable enumeration of your type by implementing the <xref:System.Collections.Generic.IEnumerable%601> interface, you can define LINQ standard query operator methods in that type or create LINQ standard query operator methods that extend the type. Custom implementations of the standard query operators should use deferred execution to return the results.  
  
### Remote Data  

 The best option for enabling LINQ querying of a remote data source is to implement the <xref:System.Linq.IQueryable%601> interface. However, this differs from extending a provider such as [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] for a data source.
  
## IQueryable LINQ Providers  

 LINQ providers that implement <xref:System.Linq.IQueryable%601> can vary widely in their complexity.
  
 A less complex `IQueryable` provider might interface with a single method of a Web service. This type of provider is very specific because it expects specific information in the queries that it handles. It has a closed type system, perhaps exposing a single result type. Most of the execution of the query occurs locally, for example by using the <xref:System.Linq.Enumerable> implementations of the standard query operators. A less complex provider might examine only one method call expression in the expression tree that represents the query, and let the remaining logic of the query be handled elsewhere.  
  
 An `IQueryable` provider of medium complexity might target a data source that has a partially expressive query language. If it targets a Web service, it might interface with more than one method of the Web service and select the method to call based on the question that the query poses. A provider of medium complexity would have a richer type system than a simple provider, but it would still be a fixed type system. For example, the provider might expose types that have one-to-many relationships that can be traversed, but it would not provide mapping technology for user-defined types.  
  
 A complex `IQueryable` provider, such as the [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] provider, might translate complete LINQ queries to an expressive query language, such as SQL. A complex provider is more general than a less complex provider, because it can handle a wider variety of questions in the query. It also has an open type system and therefore must contain extensive infrastructure to map user-defined types. Developing a complex provider requires a significant amount of effort.  
  