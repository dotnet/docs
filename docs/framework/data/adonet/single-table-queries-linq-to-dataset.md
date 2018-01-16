---
title: "Single-Table Queries (LINQ to DataSet)"
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
ms.assetid: 0b74bcf8-3f87-449f-bff7-6bcb0d69d212
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Single-Table Queries (LINQ to DataSet)
[!INCLUDE[vbteclinqext](../../../../includes/vbteclinqext-md.md)] queries work on data sources that implement the <xref:System.Collections.Generic.IEnumerable%601> interface or the <xref:System.Linq.IQueryable%601> interface. The <xref:System.Data.DataTable> class does not implement either interface, so you must call the <xref:System.Data.DataTableExtensions.AsEnumerable%2A> method if you want to use the <xref:System.Data.DataTable> as a source in the `From` clause of a [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] query.  
  
 The following example gets all the online orders from the SalesOrderHeader table and outputs the order ID, order date, and order number to the console.  
  
 [!code-csharp[DP LINQ to DataSet Examples#Where1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/CS/Program.cs#where1)]  
 [!code-vb[DP LINQ to DataSet Examples#Where1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP LINQ to DataSet Examples/VB/Module1.vb#where1)] 
  
 The local variable query is initialized with a query expression, which operates on one or more information sources by applying one or more query operators from either the standard query operators or, in the case of [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)], operators specific to the <xref:System.Data.DataSet> class. The query expression in the previous example uses two of the standard query operators: `Where` and `Select`.  
  
 The `Where` clause filters the sequence based on a condition, in this case that the `OnlineOrderFlag` is set to `true`. The `Select` operator allocates and returns an enumerable object that captures the arguments passed to the operator. In this above example, an anonymous type is created with three properties: `SalesOrderID`, `OrderDate`, and `SalesOrderNumber`. The values of these three properties are set to the values of the `SalesOrderID`, `OrderDate`, and `SalesOrderNumber` columns from the `SalesOrderHeader` table.  
  
 The `foreach` loop then enumerates the enumerable object returned by `Select` and yields the query results. Because query is an <xref:System.Linq.Enumerable> type, which implements <xref:System.Collections.Generic.IEnumerable%601>, the evaluation of the query is deferred until the query variable is iterated over using the `foreach` loop. Deferred query evaluation allows queries to be kept as values that can be evaluated multiple times, each time yielding potentially different results.  
  
 The <xref:System.Data.DataRowExtensions.Field%2A> method provides access to the column values of a <xref:System.Data.DataRow> and the <xref:System.Data.DataRowExtensions.SetField%2A> (not shown in the previous example) sets column values in a <xref:System.Data.DataRow>. Both the <xref:System.Data.DataRowExtensions.Field%2A> method and <xref:System.Data.DataRowExtensions.SetField%2A> method handle nullable types, so you do not have to explicitly check for null values. Both methods are generic methods, also, which means you do not have to cast the return type. You could use the pre-existing column accessor in <xref:System.Data.DataRow> (for example, `o["OrderDate"]`), but doing so would require you to cast the return object to the appropriate type.  If the column is nullable you have to check if the value is null by using the <xref:System.Data.DataRow.IsNull%2A> method. For more information, see [Generic Field and SetField Methods](../../../../docs/framework/data/adonet/generic-field-and-setfield-methods-linq-to-dataset.md).  
  
 Note that the data type specified in the generic parameter `T` of the <xref:System.Data.DataRowExtensions.Field%2A> method and <xref:System.Data.DataRowExtensions.SetField%2A> method must match the type of the underlying value or an <xref:System.InvalidCastException> will be thrown. The specified column name must also match the name of a column in the <xref:System.Data.DataSet> or an <xref:System.ArgumentException> will be thrown. In both cases, the exception is thrown at run time data enumeration when the query is executed.  
  
## See Also  
 [Cross-Table Queries](../../../../docs/framework/data/adonet/cross-table-queries-linq-to-dataset.md)  
 [Querying Typed DataSets](../../../../docs/framework/data/adonet/querying-typed-datasets.md)  
 [Generic Field and SetField Methods](../../../../docs/framework/data/adonet/generic-field-and-setfield-methods-linq-to-dataset.md)
