---
title: "Cross-Table Queries (LINQ to DataSet)"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 6819a16f-8656-41af-a54d-dfec0cb66366
---
# Cross-Table Queries (LINQ to DataSet)
In addition to querying a single table, you can also perform cross-table queries in LINQ to DataSet. This is done by using a *join*. A join is the association of objects in one data source with objects that share a common attribute in another data source, such as a product or contact ID. In object-oriented programming, relationships between objects are relatively easy to navigate because each object has a member that references another object. In external database tables, however, navigating relationships is not as straightforward. Database tables do not contain built-in relationships. In these cases, the join operation can be used to match elements from each source. For example, given two tables that contain product information and sales information, you could use a join operation to match sales information and products for the same sales order.  
  
 The [!INCLUDE[vbteclinqext](../../../../includes/vbteclinqext-md.md)] framework provides two join operators, <xref:System.Linq.Enumerable.Join%2A> and <xref:System.Linq.Enumerable.GroupJoin%2A>. These operators perform *equi-joins*: that is, joins that match two data sources only when their keys are equal. (By contrast, Transact-SQL supports join operators other than `equals`, such as the `less than` operator.)  
  
 In relational database terms, <xref:System.Linq.Enumerable.Join%2A> implements an inner join. An inner join is a type of join in which only those objects that have a match in the opposite data set are returned.  
  
 The <xref:System.Linq.Enumerable.GroupJoin%2A> operators have no direct equivalent in relational database terms; they implement a superset of inner joins and left outer joins. A left outer join is a join that returns each element of the first (left) collection, even if it has no correlated elements in the second collection.  
  
 For more information about joins, see [Join Operations](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/bb397908(v=vs.120)).  
  
## Example  
 The following example performs a traditional join of the `SalesOrderHeader` and `SalesOrderDetail` tables from the AdventureWorks sample database to obtain online orders from the month of August.  
  
 [!code-csharp[DP LINQ to DataSet Examples#Join](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#join)]
 [!code-vb[DP LINQ to DataSet Examples#Join](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#join)]  
  
## See also

- [Querying DataSets](querying-datasets-linq-to-dataset.md)
- [Single-Table Queries](single-table-queries-linq-to-dataset.md)
- [Querying Typed DataSets](querying-typed-datasets.md)
- [Join Operations](https://docs.microsoft.com/previous-versions/visualstudio/visual-studio-2013/bb397908(v=vs.120))
- [LINQ to DataSet Examples](linq-to-dataset-examples.md)
