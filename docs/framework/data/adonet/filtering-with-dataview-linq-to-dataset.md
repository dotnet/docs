---
title: "Filtering with DataView (LINQ to DataSet)"
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
ms.assetid: 5632d74a-ff53-4ea7-9fe7-4a148eeb1c68
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Filtering with DataView (LINQ to DataSet)
The ability to filter data using specific criteria and then present the data to a client through a UI control is an important aspect of data binding. <xref:System.Data.DataView> provides several ways to filter data and return subsets of data rows meeting specific filter criteria. In addition to the string-based filtering capabilities <xref:System.Data.DataView> also provides the ability to use [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] expressions for the filtering criteria. [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] expressions allow for much more complex and powerful filtering operations than the string-based filtering.  
  
 There are two ways to filter data using a <xref:System.Data.DataView>:  
  
-   Create a <xref:System.Data.DataView> from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query with a Where clause.  
  
-   Use the existing, string-based filtering capabilities of <xref:System.Data.DataView>.  
  
## Creating DataView from a Query with Filtering Information  
 A <xref:System.Data.DataView> object can be created from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query. If that query contains a `Where` clause, the <xref:System.Data.DataView> is created with the filtering information from the query. The expression in the `Where` clause is used to determine which data rows will be included in the <xref:System.Data.DataView>, and is the basis for the filter.  
  
 Expression-based filters offer more powerful and complex filtering than the simpler string-based filters. The string-based and expression-based filters are mutually exclusive. When the string-based <xref:System.Data.DataView.RowFilter%2A> is set after a <xref:System.Data.DataView> is created from a query, the expression based filter inferred from the query is cleared.  
  
> [!NOTE]
>  In most cases, the expressions used for filtering should not have side effects and must be deterministic. Also, the expressions should not contain any logic that depends on a set number of executions, because the filtering operations might be executed any number of times.  
  
### Example  
 The following example queries the SalesOrderDetail table for orders with a quantity greater than 2 and less than 6; creates a <xref:System.Data.DataView> from that query; and binds the <xref:System.Data.DataView> to a <xref:System.Windows.Forms.BindingSource>:  
  
 [!code-csharp[DP DataView Samples#LDVFromQueryWhere](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvfromquerywhere)]
 [!code-vb[DP DataView Samples#LDVFromQueryWhere](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvfromquerywhere)]  
  
### Example  
 The following example creates a <xref:System.Data.DataView> from a query for orders placed after June 6, 2001:  
  
 [!code-csharp[DP DataView Samples#LDVFromQueryWhere3](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvfromquerywhere3)]
 [!code-vb[DP DataView Samples#LDVFromQueryWhere3](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvfromquerywhere3)]  
  
### Example  
 Filtering can also be combined with sorting. The following example creates a <xref:System.Data.DataView> from a query for contacts whose last name start with "S" and sorted by last name, then first name:  
  
 [!code-csharp[DP DataView Samples#LDVFromQueryWhereOrderByThenBy](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvfromquerywhereorderbythenby)]
 [!code-vb[DP DataView Samples#LDVFromQueryWhereOrderByThenBy](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvfromquerywhereorderbythenby)]  
  
### Example  
 The following example uses the SoundEx algorithm to find contacts whose last name is similar to "Zhu". The SoundEx algorithm is implemented in the SoundEx method.  
  
 [!code-csharp[DP DataView Samples#LDVSoundExFilter](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvsoundexfilter)]
 [!code-vb[DP DataView Samples#LDVSoundExFilter](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvsoundexfilter)]  
  
 SoundEx is a phonetic algorithm used for indexing names by sound, as they are pronounced in English, originally developed by the U.S. Census Bureau. The SoundEx method returns a four character code for a name consisting of an English letter followed by three numbers. The letter is the first letter of the name and the numbers encode the remaining consonants in the name. Similar sounding names share the same SoundEx code. The SoundEx implementation used in the SoundEx method of the previous example is shown here:  
  
 [!code-csharp[DP DataView Samples#SoundEx](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#soundex)]
 [!code-vb[DP DataView Samples#SoundEx](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#soundex)]  
  
## Using the RowFilter Property  
 The existing string-based filtering functionality of <xref:System.Data.DataView> still works in the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] context. For more information about string-based <xref:System.Data.DataView.RowFilter%2A> filtering, see [Sorting and Filtering Data](../../../../docs/framework/data/adonet/dataset-datatable-dataview/sorting-and-filtering-data.md).  
  
 The following example creates a <xref:System.Data.DataView> from the Contact table and then sets the <xref:System.Data.DataView.RowFilter%2A> property to return rows where the contact's last name is "Zhu":  
  
 [!code-csharp[DP DataView Samples#LDVRowFilter](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvrowfilter)]
 [!code-vb[DP DataView Samples#LDVRowFilter](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvrowfilter)]  
  
 After a <xref:System.Data.DataView> has been created from a <xref:System.Data.DataTable> or [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query, you can use the <xref:System.Data.DataView.RowFilter%2A> property to specify subsets of rows based on their column values. The string-based and expression-based filters are mutually exclusive. Setting the <xref:System.Data.DataView.RowFilter%2A> property will clear the filter expression inferred from the [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query, and the filter expression cannot be reset.  
  
 [!code-csharp[DP DataView Samples#LDVFromQueryWhereSetRowFilter](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvfromquerywheresetrowfilter)]
 [!code-vb[DP DataView Samples#LDVFromQueryWhereSetRowFilter](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvfromquerywheresetrowfilter)]  
  
 If you want to return the results of a particular query on the data, as opposed to providing a dynamic view of a subset of the data, you can use the <xref:System.Data.DataView.Find%2A> or <xref:System.Data.DataView.FindRows%2A> methods of the <xref:System.Data.DataView>, rather than setting the <xref:System.Data.DataView.RowFilter%2A> property. The <xref:System.Data.DataView.RowFilter%2A> property is best used in a data-bound application where a bound control displays filtered results. Setting the <xref:System.Data.DataView.RowFilter%2A> property rebuilds the index for the data, adding overhead to your application and decreasing performance. The <xref:System.Data.DataView.Find%2A> and <xref:System.Data.DataView.FindRows%2A> methods use the current index without requiring the index to be rebuilt. If you are going to call <xref:System.Data.DataView.Find%2A> or <xref:System.Data.DataView.FindRows%2A> only once, then you should use the existing <xref:System.Data.DataView>. If you are going to call <xref:System.Data.DataView.Find%2A> or <xref:System.Data.DataView.FindRows%2A> multiple times, you should create a new <xref:System.Data.DataView> to rebuild the index on the column you want to search on, and then call the <xref:System.Data.DataView.Find%2A> or <xref:System.Data.DataView.FindRows%2A> methods. For more information about the <xref:System.Data.DataView.Find%2A> and <xref:System.Data.DataView.FindRows%2A> methods see [Finding Rows](../../../../docs/framework/data/adonet/dataset-datatable-dataview/finding-rows.md) and [DataView Performance](../../../../docs/framework/data/adonet/dataview-performance.md).  
  
## Clearing the Filter  
 The filter on a <xref:System.Data.DataView> can be cleared after filtering has been set using the <xref:System.Data.DataView.RowFilter%2A> property. The filter on a <xref:System.Data.DataView> can be cleared in two different ways:  
  
-   Set the <xref:System.Data.DataView.RowFilter%2A> property to `null`.  
  
-   Set the <xref:System.Data.DataView.RowFilter%2A> property to an empty string.  
  
### Example  
 The following example creates a <xref:System.Data.DataView> from a query and then clears the filter by setting <xref:System.Data.DataView.RowFilter%2A> property to `null`:  
  
 [!code-csharp[DP DataView Samples#LDVClearRowFilter2](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvclearrowfilter2)]
 [!code-vb[DP DataView Samples#LDVClearRowFilter2](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvclearrowfilter2)]  
  
### Example  
 The following example creates a <xref:System.Data.DataView> from a table sets the <xref:System.Data.DataView.RowFilter%2A> property, and then clears the filter by setting the <xref:System.Data.DataView.RowFilter%2A> property to an empty string:  
  
 [!code-csharp[DP DataView Samples#LDVClearRowFilter](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataView Samples/CS/Form1.cs#ldvclearrowfilter)]
 [!code-vb[DP DataView Samples#LDVClearRowFilter](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataView Samples/VB/Form1.vb#ldvclearrowfilter)]  
  
## See Also  
 [Data Binding and LINQ to DataSet](../../../../docs/framework/data/adonet/data-binding-and-linq-to-dataset.md)  
 [Sorting with DataView](../../../../docs/framework/data/adonet/sorting-with-dataview-linq-to-dataset.md)
