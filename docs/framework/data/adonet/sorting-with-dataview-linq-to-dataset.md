---
title: "Sorting with DataView (LINQ to DataSet)"
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
ms.assetid: 885b3b7b-51c1-42b3-bb29-b925f4f69a6f
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Sorting with DataView (LINQ to DataSet)
The ability to sort data based on specific criteria and then present the data to a client through a UI control is an important aspect of data binding. <xref:System.Data.DataView> provides several ways to sort data and return data rows ordered by specific ordering criteria. In addition to its string-based sorting capabilities, <xref:System.Data.DataView> also enables you to use [!INCLUDE[vbteclinqext](../../../../includes/vbteclinqext-md.md)] expressions for the sorting criteria. [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] expressions allow for much more complex and powerful sorting operations than string-based sorting. This topic describes both approaches to sorting using <xref:System.Data.DataView>.  
  
## Creating DataView from a Query with Sorting Information  
 A <xref:System.Data.DataView> object can be created from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query. If that query contains an <xref:System.Linq.Enumerable.OrderBy%2A>, <xref:System.Linq.Enumerable.OrderByDescending%2A>, <xref:System.Linq.Enumerable.ThenBy%2A>, or <xref:System.Linq.Enumerable.ThenByDescending%2A> clause the expressions in these clauses are used as the basis for sorting the data in the <xref:System.Data.DataView>. For example, if the query contains the `Order By…`and `Then By…` clauses, the resulting <xref:System.Data.DataView> would order the data by both columns specified.  
  
 Expression-based sorting offers more powerful and complex sorting than the simpler string-based sorting. Note that string-based and expression-based sorting are mutually exclusive. If the string-based <xref:System.Data.DataView.Sort%2A> is set after a <xref:System.Data.DataView> is created from a query, the expression-based filter inferred from the query is cleared and cannot be reset.  
  
 The index for a <xref:System.Data.DataView> is built both when the <xref:System.Data.DataView> is created and when any of the sorting or filtering information is modified. You get the best performance by supplying sorting criteria in the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query that the <xref:System.Data.DataView> is created from and not modifying the sorting information, later. For more information, see [DataView Performance](../../../../docs/framework/data/adonet/dataview-performance.md).  
  
> [!NOTE]
>  In most cases, the expressions used for sorting should not have side effects and must be deterministic. Also, the expressions should not contain any logic that depends on a set number of executions, because the sorting operations might be executed any number of times.  
  
### Example  
 The following example queries the SalesOrderHeader table and orders the returned rows by the order date; creates a <xref:System.Data.DataView> from that query; and binds the <xref:System.Data.DataView> to a <xref:System.Windows.Forms.BindingSource>.  
  
 [!code-csharp[DP DataView Samples#CreateLDVFromQueryOrderBy](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#createldvfromqueryorderby)]
 [!code-vb[DP DataView Samples#CreateLDVFromQueryOrderBy](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#createldvfromqueryorderby)]  
  
### Example  
 The following example queries the SalesOrderHeader table and orders the returned row by total amount due; creates a <xref:System.Data.DataView> from that query; and binds the <xref:System.Data.DataView> to a <xref:System.Windows.Forms.BindingSource>.  
  
 [!code-csharp[DP DataView Samples#CreateLDVFromQueryOrderBy2](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#createldvfromqueryorderby2)]
 [!code-vb[DP DataView Samples#CreateLDVFromQueryOrderBy2](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#createldvfromqueryorderby2)]  
  
### Example  
 The following example queries the SalesOrderDetail table and orders the returned rows by order quantity and then by sales order ID; creates a <xref:System.Data.DataView> from that query; and binds the <xref:System.Data.DataView> to a <xref:System.Windows.Forms.BindingSource>.  
  
 [!code-csharp[DP DataView Samples#CreateLDVFromQueryOrderByThenBy](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#createldvfromqueryorderbythenby)]
 [!code-vb[DP DataView Samples#CreateLDVFromQueryOrderByThenBy](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#createldvfromqueryorderbythenby)]  
  
## Using the String-Based Sort Property  
 The string-based sorting functionality of <xref:System.Data.DataView> still works with [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)]. After a <xref:System.Data.DataView> has been created from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query, you can use the <xref:System.Data.DataView.Sort%2A> property to set the sorting on the <xref:System.Data.DataView>.  
  
 The string-based and expression-based sorting functionality are mutually exclusive. Setting the <xref:System.Data.DataView.Sort%2A> property will clear the expression-based sort inherited from the query that the <xref:System.Data.DataView> was created from.  
  
 For more information about string-based <xref:System.Data.DataView.Sort%2A> filtering, see [Sorting and Filtering Data](../../../../docs/framework/data/adonet/dataset-datatable-dataview/sorting-and-filtering-data.md).  
  
### Example  
 The follow example creates a <xref:System.Data.DataView> from the Contact table and sorts the rows by last name in descending order, then first name in ascending order:  
  
 [!code-csharp[DP DataView Samples#LDVStringSort](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvstringsort)]
 [!code-vb[DP DataView Samples#LDVStringSort](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvstringsort)]  
  
### Example  
 The following example queries the Contact table for last names that start with the letter "S".  A <xref:System.Data.DataView> is created from that query and bound to a <xref:System.Windows.Forms.BindingSource> object.  
  
 [!code-csharp[DP DataView Samples#CreateLDVFromQueryStringSort](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#createldvfromquerystringsort)]
 [!code-vb[DP DataView Samples#CreateLDVFromQueryStringSort](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#createldvfromquerystringsort)]  
  
## Clearing the Sort  
 The sorting information on a <xref:System.Data.DataView> can be cleared after it has been set using the <xref:System.Data.DataView.Sort%2A> property. There are two ways to clear the sorting information in <xref:System.Data.DataView>:  
  
-   Set the <xref:System.Data.DataView.Sort%2A> property to `null`.  
  
-   Set the <xref:System.Data.DataView.Sort%2A> property to an empty string.  
  
### Example  
 The following example creates a <xref:System.Data.DataView> from a query and clears the sorting by setting the <xref:System.Data.DataView.Sort%2A> property to an empty string:  
  
 [!code-csharp[DP DataView Samples#LDVClearSort](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvclearsort)]
 [!code-vb[DP DataView Samples#LDVClearSort](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvclearsort)]  
  
### Example  
 The following example creates a <xref:System.Data.DataView> from the Contact table and sets the <xref:System.Data.DataView.Sort%2A> property to sort by last name in descending order. The sorting information is then cleared by setting the <xref:System.Data.DataView.Sort%2A> property to `null`:  
  
 [!code-csharp[DP DataView Samples#LDVClearSort2](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvclearsort2)]
 [!code-vb[DP DataView Samples#LDVClearSort2](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvclearsort2)]  
  
## See Also  
 [Data Binding and LINQ to DataSet](../../../../docs/framework/data/adonet/data-binding-and-linq-to-dataset.md)  
 [Filtering with DataView](../../../../docs/framework/data/adonet/filtering-with-dataview-linq-to-dataset.md)  
 [Sorting Data](http://msdn.microsoft.com/library/6d76e2d7-b418-49b5-ac78-2bcd61169c48)
