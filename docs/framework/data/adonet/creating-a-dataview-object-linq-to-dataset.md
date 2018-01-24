---
title: "Creating a DataView Object (LINQ to DataSet)"
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
ms.assetid: 76057508-e12d-4779-a707-06a4c2568acf
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Creating a DataView Object (LINQ to DataSet)
There are two ways to create a <xref:System.Data.DataView> in the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] context. You can create a <xref:System.Data.DataView> from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query over a <xref:System.Data.DataTable>, or you can create it from a typed or un-typed <xref:System.Data.DataTable>. In both cases, you create the <xref:System.Data.DataView> by using one of the <xref:System.Data.DataTableExtensions.AsDataView%2A> extension methods; <xref:System.Data.DataView> is not directly constructible in the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] context.  
  
 After the <xref:System.Data.DataView> has been created, you can bind it to a UI control in a Windows forms application or an ASP.NET application, or change the filtering and sorting settings.  
  
 <xref:System.Data.DataView> constructs an index, which significantly increases the performance of operations that can use the index, such as filtering and sorting. The index for a <xref:System.Data.DataView> is built both when the <xref:System.Data.DataView> is created and when any of the sorting or filtering information is modified. Creating a <xref:System.Data.DataView> and then setting the sorting or filtering information later causes the index to be built at least twice: once when the <xref:System.Data.DataView> is created, and again when any of the sort or filter properties are modified.  
  
 For more information about filtering and sorting with <xref:System.Data.DataView>, see [Filtering with DataView](../../../../docs/framework/data/adonet/filtering-with-dataview-linq-to-dataset.md) and [Sorting with DataView](../../../../docs/framework/data/adonet/sorting-with-dataview-linq-to-dataset.md).  
  
## Creating DataView from a LINQ to DataSet Query  
 A <xref:System.Data.DataView> object can be created from the results of a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query, where the results are a projection of <xref:System.Data.DataRow> objects. The newly created <xref:System.Data.DataView> inherits the filtering and sorting information from the query it is created from.  
  
> [!NOTE]
>  In most cases, the expressions used for filtering and sorting should not have side effects and must be deterministic. Also, the expressions should not contain any logic that depend on a set number of executions, as the sorting and filtering operations may be executed any number of times.  
  
 Creating a <xref:System.Data.DataView> from a query that returns anonymous types or queries that perform join operations is not supported.  
  
 Only the following query operators are supported in a query used to create <xref:System.Data.DataView>:  
  
-   <xref:System.Data.EnumerableRowCollectionExtensions.Cast%2A>  
  
-   <xref:System.Data.EnumerableRowCollectionExtensions.OrderBy%2A>  
  
-   <xref:System.Data.EnumerableRowCollectionExtensions.OrderByDescending%2A>  
  
-   <xref:System.Data.EnumerableRowCollectionExtensions.Select%2A>  
  
-   <xref:System.Data.EnumerableRowCollectionExtensions.ThenBy%2A>  
  
-   <xref:System.Data.EnumerableRowCollectionExtensions.ThenByDescending%2A>  
  
-   <xref:System.Data.EnumerableRowCollectionExtensions.Where%2A>  
  
 Note that when a <xref:System.Data.DataView> is created from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query the <xref:System.Data.EnumerableRowCollectionExtensions.Select%2A> method must be the final method called in the query. This is shown in the following example, which creates a <xref:System.Data.DataView> of online orders sorted by total due:  
  
 [!code-csharp[DP DataView Samples#CreateLDVFromQuery1](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#createldvfromquery1)]
 [!code-vb[DP DataView Samples#CreateLDVFromQuery1](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#createldvfromquery1)]  
  
 You can also use the string-based <xref:System.Data.DataView.RowFilter%2A> and <xref:System.Data.DataView.Sort%2A> properties to filter and sort a <xref:System.Data.DataView> after it has been created from a query. Note that this will clear the sorting and filtering information inherited from the query. The following example creates a <xref:System.Data.DataView> from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query that filters by last names that start with 'S'. The string-based <xref:System.Data.DataView.Sort%2A> property is set to sort on last names in ascending order and then first names in descending order:  
  
 [!code-csharp[DP DataView Samples#CreateLDVFromQueryStringSort](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#createldvfromquerystringsort)]
 [!code-vb[DP DataView Samples#CreateLDVFromQueryStringSort](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#createldvfromquerystringsort)]  
  
## Creating a DataView from a DataTable  
 In addition to being created from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query, a <xref:System.Data.DataView> object can be created from a <xref:System.Data.DataTable> by using the <xref:System.Data.DataTableExtensions.AsDataView%2A> method.  
  
 The following example creates a <xref:System.Data.DataView> from the SalesOrderDetail table and sets it as the data source of a <xref:System.Windows.Forms.BindingSource> object. This object acts as a proxy for a <xref:System.Windows.Forms.DataGridView> control.  
  
 [!code-csharp[DP DataView Samples#CreateLDVFromTable](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#createldvfromtable)]
 [!code-vb[DP DataView Samples#CreateLDVFromTable](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#createldvfromtable)]  
  
 Filtering and sorting can be set on the <xref:System.Data.DataView> after it has been created from a <xref:System.Data.DataTable>. The following example creates a <xref:System.Data.DataView> from the Contact table and sets the <xref:System.Data.DataView.Sort%2A> property to sort on last names in ascending order and then first names in descending order:  
  
 [!code-csharp[DP DataView Samples#LDVStringSort](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvstringsort)]
 [!code-vb[DP DataView Samples#LDVStringSort](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvstringsort)]  
  
 However, there is a performance loss that comes with setting the <xref:System.Data.DataView.RowFilter%2A> or <xref:System.Data.DataView.Sort%2A> property after the <xref:System.Data.DataView> has been created from a query, because <xref:System.Data.DataView> constructs an index to support filtering and sorting operations. Setting the <xref:System.Data.DataView.RowFilter%2A> or <xref:System.Data.DataView.Sort%2A> property rebuilds the index for the data, adding overhead to your application and decreasing performance. When possible, it is better to specify the filtering and sorting information when you first create the <xref:System.Data.DataView> and avoid modifying it afterwards.  
  
## See Also  
 [Data Binding and LINQ to DataSet](../../../../docs/framework/data/adonet/data-binding-and-linq-to-dataset.md)  
 [Filtering with DataView](../../../../docs/framework/data/adonet/filtering-with-dataview-linq-to-dataset.md)  
 [Sorting with DataView](../../../../docs/framework/data/adonet/sorting-with-dataview-linq-to-dataset.md)
