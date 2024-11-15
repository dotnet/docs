---
title: Language Integrated Query (LINQ)
description: Introduces Language Integrated Query (LINQ) in C#.
ms.topic: conceptual
ms.date: 12/14/2023
---
# Language Integrated Query (LINQ)

Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration of query capabilities directly into the C# language. Traditionally, queries against data are expressed as simple strings without type checking at compile time or IntelliSense support. Furthermore, you have to learn a different query language for each type of data source: SQL databases, XML documents, various Web services, and so on. With LINQ, a query is a first-class language construct, just like classes, methods, and events.

When you write queries, the most visible "language-integrated" part of LINQ is the query expression. Query expressions are written in a declarative *query syntax*. By using query syntax, you perform filtering, ordering, and grouping operations on data sources with a minimum of code. You use the same query expression patterns to query and transform data from any type of data source.

The following example shows a complete query operation. The complete operation includes creating a data source, defining the query expression, and executing the query in a [`foreach`](../language-reference/statements/iteration-statements.md#the-foreach-statement) statement.

:::code language="csharp" source="./snippets/linq-index/Index.cs" id="intro":::

You might need to add a [`using`](../language-reference/keywords/using-directive.md) directive, `using System.Linq;`, for the preceding example to compile. The most recent versions of .NET make use of [implicit usings](../../core/project-sdk/overview.md#implicit-using-directives) to add this directive as a [global using](../language-reference/keywords/using-directive.md#the-global-modifier). Older versions require you to add it in your source.

## Query expression overview

- Query expressions query and transform data from any LINQ-enabled data source. For example, a single query can retrieve data from an SQL database and produce an XML stream as output.
- Query expressions use many familiar C# language constructs, which make them easy to read.
- The variables in a query expression are all strongly typed.
- A query isn't executed until you iterate over the query variable, for example in a `foreach` statement.
- At compile time, query expressions are converted to standard query operator method calls according to the rules defined in the C# specification. Any query that can be expressed by using query syntax can also be expressed by using method syntax. In some cases, query syntax is more readable and concise. In others, method syntax is more readable. There's no semantic or performance difference between the two different forms. For more information, see [C# language specification](~/_csharpstandard/standard/expressions.md#1220-query-expressions) and [Standard query operators overview](standard-query-operators/index.md).
- Some query operations, such as <xref:System.Linq.Enumerable.Count%2A> or <xref:System.Linq.Enumerable.Max%2A>, have no equivalent query expression clause and must therefore be expressed as a method call. Method syntax can be combined with query syntax in various ways.
- Query expressions can be compiled to expression trees or to delegates, depending on the type that the query is applied to. <xref:System.Collections.Generic.IEnumerable%601> queries are compiled to delegates. <xref:System.Linq.IQueryable> and <xref:System.Linq.IQueryable%601> queries are compiled to expression trees. For more information, see [Expression trees](/dotnet/csharp/advanced-topics/expression-trees).

## How to enable LINQ querying of your data source  
  
### In-memory data

 There are two ways you enable LINQ querying of in-memory data. If the data is of a type that implements <xref:System.Collections.Generic.IEnumerable%601>, you query the data by using LINQ to Objects. If it doesn't make sense to enable enumeration by implementing the <xref:System.Collections.Generic.IEnumerable%601> interface, you define LINQ standard query operator methods, either in that type or as [extension methods](../programming-guide/classes-and-structs/extension-methods.md) for that type. Custom implementations of the standard query operators should use deferred execution to return the results.  
  
### Remote data

 The best option for enabling LINQ querying of a remote data source is to implement the <xref:System.Linq.IQueryable%601> interface.
  
## IQueryable LINQ providers

 LINQ providers that implement <xref:System.Linq.IQueryable%601> can vary widely in their complexity.
  
 A less complex `IQueryable` provider might access a single method from a Web service. This type of provider is very specific because it expects specific information in the queries that it handles. It has a closed type system, perhaps exposing a single result type. Most of the execution of the query occurs locally, for example by using the <xref:System.Linq.Enumerable> implementations of the standard query operators. A less complex provider might examine only one method call expression in the expression tree that represents the query, and let the remaining logic of the query be handled elsewhere.  
  
 An `IQueryable` provider of medium complexity might target a data source that has a partially expressive query language. If it targets a Web service, it might access more than one method of the Web service and select which method to call based on the information that the query seeks. A provider of medium complexity would have a richer type system than a simple provider, but it would still be a fixed type system. For example, the provider might expose types that have one-to-many relationships that can be traversed, but it wouldn't provide mapping technology for user-defined types.  
  
 A complex `IQueryable` provider, such as the [Entity Framework Core](/ef/core/) provider, might translate complete LINQ queries to an expressive query language, such as SQL. A complex provider is more general because it can handle a wider variety of questions in the query. It also has an open type system and therefore must contain extensive infrastructure to map user-defined types. Developing a complex provider requires a significant amount of effort.  
  