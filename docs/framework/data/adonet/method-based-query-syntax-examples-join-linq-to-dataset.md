---
description: "Learn more about: Method-Based Query Syntax Examples: Join (LINQ to DataSet)"
title: "Method-Based Query Syntax Examples: Join (LINQ to DataSet)"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 4fd5ed2c-b03a-4054-a3ed-3ddb380d7d9d
---
# Method-Based Query Syntax Examples: Join (LINQ to DataSet)

Joining is an important operation in queries that target data sources that have no navigable relationships to each other, such as relational database tables. A join of two data sources is the association of objects in one data source with objects that share a common attribute in the other data source. For more information, see [Standard Query Operators Overview (C#)](../../../csharp/programming-guide/concepts/linq/standard-query-operators-overview.md) or [Standard Query Operators Overview (Visual Basic)](../../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md).  
  
 The examples in this topic demonstrate how to use the <xref:System.Linq.Enumerable.Join%2A> method to query a <xref:System.Data.DataSet> using the method query syntax.  
  
 The `FillDataSet` method used in these examples is specified in [Loading Data Into a DataSet](loading-data-into-a-dataset.md).  
  
 The examples in this topic use the Contact, Address, Product, SalesOrderHeader, and SalesOrderDetail tables in the AdventureWorks sample database.  
  
 The examples in this topic use the following `using`/`Imports` statements:  
  
 [!code-csharp[DP LINQ to DataSet Examples#ImportsUsing](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#importsusing)]
 [!code-vb[DP LINQ to DataSet Examples#ImportsUsing](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#importsusing)]  
  
 For more information, see [How to: Create a LINQ to DataSet Project In Visual Studio](how-to-create-a-linq-to-dataset-project-in-vs.md).  
  
## Join  
  
### Example  

 This example performs a join over the `Contact` and `SalesOrderHeader` tables.  
  
 [!code-csharp[DP LINQ to DataSet Examples#JoinSimple_MQ](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#joinsimple_mq)]
 [!code-vb[DP LINQ to DataSet Examples#JoinSimple_MQ](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#joinsimple_mq)]  
  
### Example  

 This example performs a join over the `Contact` and `SalesOrderHeader` tables, grouping the results by contact ID.  
  
 [!code-csharp[DP LINQ to DataSet Examples#JoinWithGroupedResults_MQ](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#joinwithgroupedresults_mq)]
 [!code-vb[DP LINQ to DataSet Examples#JoinWithGroupedResults_MQ](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#joinwithgroupedresults_mq)]  
  
## See also

- [Loading Data Into a DataSet](loading-data-into-a-dataset.md)
- [LINQ to DataSet Examples](linq-to-dataset-examples.md)
- [Standard Query Operators Overview (C#)](../../../csharp/programming-guide/concepts/linq/standard-query-operators-overview.md)
- [Standard Query Operators Overview (Visual Basic)](../../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md)
