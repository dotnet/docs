---
title: "Data Binding and LINQ to DataSet"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-ado"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 310bff4a-32dd-4f20-a271-6dbd82912631
caps.latest.revision: 2
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Data Binding and LINQ to DataSet
*Data binding* is the process that establishes a connection between the application UI and business logic. If the binding has the correct settings and the data provides the proper notifications, when the data changes its value, the elements that are bound to the data reflect changes automatically. The <xref:System.Data.DataSet> is an in- memory representation of data that provides a consistent relational programming model, regardless of the source of the data it contains. The ADO.NET 2.0 <xref:System.Data.DataView> enables you to sort and filter the data stored in a <xref:System.Data.DataTable>. This functionality is often used in data-binding applications. By using a <xref:System.Data.DataView>, you can expose the data in a table with different sort orders, and you can filter the data by row state or based on a filter expression. For more information about the <xref:System.Data.DataView> object, see [DataViews](../../../../docs/framework/data/adonet/dataset-datatable-dataview/dataviews.md).  
  
 [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] allows developers to create complex, powerful queries over a <xref:System.Data.DataSet> by using [!INCLUDE[vbteclinqext](../../../../includes/vbteclinqext-md.md)]. However, a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query returns an enumeration of <xref:System.Data.DataRow> objects, which is not easily used in a binding scenario. To make binding easier, you can create a <xref:System.Data.DataView> from a [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] query. This <xref:System.Data.DataView> uses the filtering and sorting specified in the query, but is better suited for data binding. [!INCLUDE[linq_dataset](../../../../includes/linq-dataset-md.md)] extends the functionality of the <xref:System.Data.DataView> by providing [!INCLUDE[vbteclinq](../../../../includes/vbteclinq-md.md)] expression-based filtering and sorting, which allows for much more complex and powerful filtering and sorting operations than string-based filtering and sorting.  
  
 Note that the <xref:System.Data.DataView> represents the query itself and is not a view on top of the query. The <xref:System.Data.DataView> is bound to a UI control, such as a <xref:System.Windows.Forms.DataGrid> or a <xref:System.Windows.Forms.DataGridView>, providing a simple data binding model. A <xref:System.Data.DataView> can also be created from a <xref:System.Data.DataTable>, providing a default view of that table.  
  
## In This Section  
 [Creating a DataView Object](../../../../docs/framework/data/adonet/creating-a-dataview-object-linq-to-dataset.md)  
 Provides information about creating a <xref:System.Data.DataView>.  
  
 [Filtering with DataView](../../../../docs/framework/data/adonet/filtering-with-dataview-linq-to-dataset.md)  
 Describes how to filter with the <xref:System.Data.DataView>.  
  
 [Sorting with DataView](../../../../docs/framework/data/adonet/sorting-with-dataview-linq-to-dataset.md)  
 Describes how to sort with the <xref:System.Data.DataView>.  
  
 [Querying the DataRowView Collection in a DataView](../../../../docs/framework/data/adonet/querying-the-datarowview-collection-in-a-dataview.md)  
 Provides information about querying the <xref:System.Data.DataRowView> collection exposed by <xref:System.Data.DataView>.  
  
 [DataView Performance](../../../../docs/framework/data/adonet/dataview-performance.md)  
 Provides information about <xref:System.Data.DataView> and performance.  
  
 [How to: Bind a DataView Object to a Windows Forms DataGridView Control](../../../../docs/framework/data/adonet/how-to-bind-a-dataview-object-to-a-winforms-datagridview-control.md)  
 Describes how to bind a <xref:System.Data.DataView> object to a <xref:System.Windows.Forms.DataGridView>.  
  
## See Also  
 [Programming Guide](../../../../docs/framework/data/adonet/programming-guide-linq-to-dataset.md)
