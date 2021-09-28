---
title: "Enabling a Data Source for LINQ Querying"
description: Learn how to extend LINQ in C# to enable any data source to be queried in the LINQ pattern, which makes it easy for clients to query a data source.
ms.date: 07/20/2015
ms.assetid: d2ef04a5-31a6-45cb-af9a-a5ce7732662c
---
# Enabling a Data Source for LINQ Querying

There are various ways to extend LINQ to enable any data source to be queried in the LINQ pattern. The data source might be a data structure, a Web service, a file system, or a database, to name some. The LINQ pattern makes it easy for clients to query a data source for which LINQ querying is enabled, because the syntax and pattern of the query does not change. The ways in which LINQ can be extended to these data sources include the following:  
  
- Implementing the <xref:System.Collections.Generic.IEnumerable%601> interface in a type to enable LINQ to Objects querying of that type.  
  
- Creating standard query operator methods such as <xref:System.Linq.Enumerable.Where%2A> and <xref:System.Linq.Enumerable.Select%2A> that extend a type, to enable custom LINQ querying of that type.  
  
- Creating a provider for your data source that implements the <xref:System.Linq.IQueryable%601> interface. A provider that implements this interface receives LINQ queries in the form of expression trees, which it can execute in a custom way, for example remotely.  
  
- Creating a provider for your data source that takes advantage of an existing LINQ technology. Such a provider would enable not only querying, but also insert, update, and delete operations and mapping for user-defined types.  
  
 This topic discusses these options.  
  
## How to Enable LINQ Querying of Your Data Source  
  
### In-Memory Data  

 There are two ways you can enable LINQ querying of in-memory data. If the data is of a type that implements <xref:System.Collections.Generic.IEnumerable%601>, you can query the data by using LINQ to Objects. If it does not make sense to enable enumeration of your type by implementing the <xref:System.Collections.Generic.IEnumerable%601> interface, you can define LINQ standard query operator methods in that type or create LINQ standard query operator methods that extend the type. Custom implementations of the standard query operators should use deferred execution to return the results.  
  
### Remote Data  

 The best option for enabling LINQ querying of a remote data source is to implement the <xref:System.Linq.IQueryable%601> interface. However, this differs from extending a provider such as [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] for a data source.
  
## IQueryable LINQ Providers  

 LINQ providers that implement <xref:System.Linq.IQueryable%601> can vary widely in their complexity. This section discusses the different levels of complexity.  
  
 A less complex `IQueryable` provider might interface with a single method of a Web service. This type of provider is very specific because it expects specific information in the queries that it handles. It has a closed type system, perhaps exposing a single result type. Most of the execution of the query occurs locally, for example by using the <xref:System.Linq.Enumerable> implementations of the standard query operators. A less complex provider might examine only one method call expression in the expression tree that represents the query, and let the remaining logic of the query be handled elsewhere.  
  
 An `IQueryable` provider of medium complexity might target a data source that has a partially expressive query language. If it targets a Web service, it might interface with more than one method of the Web service and select the method to call based on the question that the query poses. A provider of medium complexity would have a richer type system than a simple provider, but it would still be a fixed type system. For example, the provider might expose types that have one-to-many relationships that can be traversed, but it would not provide mapping technology for user-defined types.  
  
 A complex `IQueryable` provider, such as the [!INCLUDE[vbtecdlinq](~/includes/vbtecdlinq-md.md)] provider, might translate complete LINQ queries to an expressive query language, such as SQL. A complex provider is more general than a less complex provider, because it can handle a wider variety of questions in the query. It also has an open type system and therefore must contain extensive infrastructure to map user-defined types. Developing a complex provider requires a significant amount of effort.  
  
## See also

- <xref:System.Linq.IQueryable%601>
- <xref:System.Collections.Generic.IEnumerable%601>
- <xref:System.Linq.Enumerable>
- [Standard Query Operators Overview (C#)](./standard-query-operators-overview.md)
- [LINQ to Objects (C#)](./linq-to-objects.md)
