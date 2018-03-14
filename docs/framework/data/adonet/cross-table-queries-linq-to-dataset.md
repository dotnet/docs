---
title: "Cross-Table Queries (LINQ to DataSet)"
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
ms.assetid: 6819a16f-8656-41af-a54d-dfec0cb66366
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Cross-Table Queries (LINQ to DataSet)
In addition to querying a single table, you can also perform cross-table queries in [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)]. This is done by using a *join*. A join is the association of objects in one data source with objects that share a common attribute in another data source, such as a product or contact ID. In object-oriented programming, relationships between objects are relatively easy to navigate because each object has a member that references another object. In external database tables, however, navigating relationships is not as straightforward. Database tables do not contain built-in relationships. In these cases, the join operation can be used to match elements from each source. For example, given two tables that contain product information and sales information, you could use a join operation to match sales information and products for the same sales order.  
  
 The [!INCLUDE[vbteclinqext](../../../../includes/vbteclinqext-md.md)] framework provides two join operators, <xref:System.Linq.Enumerable.Join%2A> and <xref:System.Linq.Enumerable.GroupJoin%2A>. These operators perform *equi-joins*: that is, joins that match two data sources only when their keys are equal. (By contrast, [!INCLUDE[tsql](../../../../includes/tsql-md.md)] supports join operators other than `equals`, such as the `less than` operator.)  
  
 In relational database terms, <xref:System.Linq.Enumerable.Join%2A> implements an inner join. An inner join is a type of join in which only those objects that have a match in the opposite data set are returned.  
  
 The <xref:System.Linq.Enumerable.GroupJoin%2A> operators have no direct equivalent in relational database terms; they implement a superset of inner joins and left outer joins. A left outer join is a join that returns each element of the first (left) collection, even if it has no correlated elements in the second collection.  
  
 For more information about joins, see [Join Operations](http://msdn.microsoft.com/library/442d176d-028c-4beb-8d22-407d4ef89107).  
  
## Example  
 The following example performs a traditional join of the `SalesOrderHeader` and `SalesOrderDetail` tables from the AdventureWorks sample database to obtain online orders from the month of August.  
  
 [!code-csharp[DP LINQ to DataSet Examples#Join](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#join)]
 [!code-vb[DP LINQ to DataSet Examples#Join](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#join)]  
  
## See Also  
 [Querying DataSets](../../../../docs/framework/data/adonet/querying-datasets-linq-to-dataset.md)  
 [Single-Table Queries](../../../../docs/framework/data/adonet/single-table-queries-linq-to-dataset.md)  
 [Querying Typed DataSets](../../../../docs/framework/data/adonet/querying-typed-datasets.md)  
 [Join Operations](http://msdn.microsoft.com/library/442d176d-028c-4beb-8d22-407d4ef89107)  
 [LINQ to DataSet Examples](../../../../docs/framework/data/adonet/linq-to-dataset-examples.md)
