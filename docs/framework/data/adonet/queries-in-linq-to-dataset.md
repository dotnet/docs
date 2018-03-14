---
title: "Queries in LINQ to DataSet"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: c1a78fa8-9f0c-40bc-a372-5575a48708fe
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Queries in LINQ to DataSet
A query is an expression that retrieves data from a data source. Queries are usually expressed in a specialized query language, such as SQL for relational databases and XQuery for XML. Therefore, developers have had to learn a new query language for each type of data source or data format that they query. [!INCLUDE[vbteclinqext](../../../../includes/vbteclinqext-md.md)] offers a simpler, consistent model for working with data across various kinds of data sources and formats. In a [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] query, you always work with programming objects.  
  
 A [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] query operation consists of three actions: obtain the data source or sources, create the query, and execute the query.  
  
 Data sources that implement the <xref:System.Collections.Generic.IEnumerable%601> generic interface can be queried through [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)]. Calling <xref:System.Data.DataTableExtensions.AsEnumerable%2A> on a <xref:System.Data.DataTable> returns an object which implements the generic <xref:System.Collections.Generic.IEnumerable%601> interface, which serves as the data source for [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] queries.  
  
 In the query, you specify exactly the information that you want to retrieve from the data source. A query can also specify how that information should be sorted, grouped, and shaped before it is returned. In [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)], a query is stored in a variable. If the query is designed to return a sequence of values, the query variable itself must be a enumerable type. This query variable takes no action and returns no data; it only stores the query information. After you create a query you must execute that query to retrieve any data.  
  
 In a query that returns a sequence of values, the query variable itself never holds the query results and only stores the query commands. Execution of the query is deferred until the query variable is iterated over in a `foreach` or `For Each` loop. This is called *deferred execution*; that is, query execution occurs some time after the query is constructed. This means that you can execute a query as often as you want to. This is useful when, for example, you have a database that is being updated by other applications. In your application, you can create a query to retrieve the latest information and repeatedly execute the query, returning the updated information every time.  
  
 In contrast to deferred queries, which return a sequence of values, queries that return a singleton value are executed immediately. Some examples of singleton queries are <xref:System.Linq.Enumerable.Count%2A>, <xref:System.Linq.Enumerable.Max%2A>, <xref:System.Linq.Enumerable.Average%2A>, and <xref:System.Linq.Enumerable.First%2A>. These execute immediately because the query results are required to calculate the singleton result. For example, in order to find the average of the query results the query must be executed so that the averaging function has input data to work with. You can also use the <xref:System.Linq.Enumerable.ToList%2A> or <xref:System.Linq.Enumerable.ToArray%2A> methods on a query to force immediate execution of a query that does not produce a singleton value. These techniques to force immediate execution can be useful when you want to cache the results of a query. For more information about deferred and immediate query execution, see [Getting Started with LINQ](http://msdn.microsoft.com/library/6cc9af04-950a-4cc3-83d4-2aeb4abe4de9).  
  
## Queries  
 [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] queries can be formulated in two different syntaxes: query expression syntax and method-based query syntax.  
  
### Query Expression Syntax  
 Query expressions are a declarative query syntax. This syntax enables a developer to write queries in C# or Visual Basic in a format similar to SQL. By using query expression syntax, you can perform even complex filtering, ordering, and grouping operations on data sources with minimal code. For more information, see [LINQ Query Expressions](http://msdn.microsoft.com/library/40638f19-fb46-4d26-a2d9-a383b48f5ed4) and [Basic Query Operations (Visual Basic)](~/docs/visual-basic/programming-guide/concepts/linq/basic-query-operations.md).  
  
 Query expression syntax is new in C# 3.0 and [!INCLUDE[vb_orcas_long](../../../../includes/vb-orcas-long-md.md)]. However, the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] common language runtime (CLR) cannot read the query expression syntax itself. Therefore, at compile time, query expressions are translated to something that the CLR does understand: method calls. These methods are referred to as the *standard query operators*. As a developer, you have the option of calling them directly by using method syntax, instead of using query syntax. For more information, see [Query Syntax and Method Syntax in LINQ](~/docs/csharp/programming-guide/concepts/linq/query-syntax-and-method-syntax-in-linq.md). For more information about how to use the standard query operators, see [NOT IN BUILD: LINQ General Programming Guide](http://msdn.microsoft.com/library/609c7a6b-cbdd-429d-99f3-78d13d3bc049).  
  
 The following example uses <xref:System.Linq.Enumerable.Select%2A> to return all the rows from `Product` table and display the product names.  
  
 [!code-csharp[DP LINQ to DataSet Examples#SelectSimple1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#selectsimple1)]
 [!code-vb[DP LINQ to DataSet Examples#SelectSimple1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#selectsimple1)]  
  
### Method-Based Query Syntax  
 The other way to formulate [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] queries is by using method-based queries. The method-based query syntax is a sequence of direct method calls to [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] operator methods, passing lambda expressions as the parameters. For more information, see [Lambda Expressions](~/docs/csharp/programming-guide/statements-expressions-operators/lambda-expressions.md).  
  
 This example uses <xref:System.Linq.Enumerable.Select%2A> to return all the rows from `Product` and display the product names.  
  
 [!code-csharp[DP LINQ to DataSet Examples#SelectAnonymousTypes_MQ](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#selectanonymoustypes_mq)]
 [!code-vb[DP LINQ to DataSet Examples#SelectAnonymousTypes_MQ](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#selectanonymoustypes_mq)]  
  
## Composing Queries  
 As mentioned earlier in this topic, the query variable itself only stores the query commands when the query is designed to return a sequence of values. If the query does not contain a method that will cause immediate execution, the actual execution of the query is deferred until you iterate over the query variable in a `foreach` or `For Each` loop. Deferred execution enables multiple queries to be combined or a query to be extended. When a query is extended, it is modified to include the new operations, and the eventual execution will reflect the changes. In the following example, the first query returns all the products. The second query extends the first by using `Where` to return all the products of size "L":  
  
 [!code-csharp[DP LINQ to DataSet Examples#Composing](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#composing)]
 [!code-vb[DP LINQ to DataSet Examples#Composing](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#composing)]  
  
 After a query has been executed, no additional queries can be composed, and all subsequent queries will use the in-memory [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] operators. Query execution will occur when you iterate over the query variable in a `foreach` or `For Each` statement, or by a call to one of the [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] conversion operators that cause immediate execution. These operators include the following: <xref:System.Linq.Enumerable.ToList%2A>, <xref:System.Linq.Enumerable.ToArray%2A>, <xref:System.Linq.Enumerable.ToLookup%2A>, and <xref:System.Linq.Enumerable.ToDictionary%2A>.  
  
 In the following example, the first query returns all the products ordered by list price. The <xref:System.Linq.Enumerable.ToArray%2A> method is used to force immediate query execution:  
  
 [!code-csharp[DP LINQ to DataSet Examples#ToArray2](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#toarray2)]
 [!code-vb[DP LINQ to DataSet Examples#ToArray2](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#toarray2)]  
  
## See Also  
 [Programming Guide](../../../../docs/framework/data/adonet/programming-guide-linq-to-dataset.md)  
 [Querying DataSets](../../../../docs/framework/data/adonet/querying-datasets-linq-to-dataset.md)  
 [Getting Started with LINQ in C#](~/docs/csharp/programming-guide/concepts/linq/getting-started-with-linq.md)  
 [Getting Started with LINQ in Visual Basic](~/docs/visual-basic/programming-guide/concepts/linq/getting-started-with-linq.md)
