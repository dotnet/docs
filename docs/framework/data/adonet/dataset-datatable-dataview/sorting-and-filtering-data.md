---
title: "Sorting and Filtering Data"
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
ms.assetid: fdd9c753-39df-48cd-9822-2781afe76200
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Sorting and Filtering Data
The <xref:System.Data.DataView> provides several ways of sorting and filtering data in a <xref:System.Data.DataTable>:  
  
-   You can use the <xref:System.Data.DataView.Sort%2A> property to specify single or multiple column sort orders and include ASC (ascending) and DESC (descending) parameters.  
  
-   You can use the <xref:System.Data.DataView.ApplyDefaultSort%2A> property to automatically create a sort order, in ascending order, based on the primary key column or columns of the table. <xref:System.Data.DataView.ApplyDefaultSort%2A> only applies when the **Sort** property is a null reference or an empty string, and when the table has a primary key defined.  
  
-   You can use the <xref:System.Data.DataView.RowFilter%2A> property to specify subsets of rows based on their column values. For details about valid expressions for the **RowFilter** property, see the reference information for the <xref:System.Data.DataColumn.Expression%2A> property of the <xref:System.Data.DataColumn> class.  
  
     If you want to return the results of a particular query on the data, as opposed to providing a dynamic view of a subset of the data, use the <xref:System.Data.DataView.Find%2A> or <xref:System.Data.DataView.FindRows%2A> methods of the **DataView** to achieve best performance rather than setting the **RowFilter** property. Setting the **RowFilter** property rebuilds the index for the data, adding overhead to your application and decreasing performance. The **RowFilter** property is best used in a data-bound application where a bound control displays filtered results. The **Find** and **FindRows** methods leverage the current index without requiring the index to be rebuilt. For more information about the **Find** and **FindRows** methods, see [Finding Rows](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/finding-rows.md).  
  
-   You can use the <xref:System.Data.DataView.RowStateFilter%2A> property to specify which row versions to view. The **DataView** implicitly manages which row version to expose depending upon the **RowState** of the underlying row. For example, if the **RowStateFilter** is set to **DataViewRowState.Deleted**, the **DataView** exposes the **Original** row version of all **Deleted** rows because there is no **Current** row version. You can determine which row version of a row is being exposed by using the **RowVersion** property of the **DataRowView**.  
  
     The following table shows the options for **DataViewRowState**.  
  
    |DataViewRowState options|Description|  
    |------------------------------|-----------------|  
    |**CurrentRows**|The **Current** row version of all **Unchanged**, **Added**, and **Modified** rows. This is the default.|  
    |**Added**|The **Current** row version of all **Added** rows.|  
    |**Deleted**|The **Original** row version of all **Deleted** rows.|  
    |**ModifiedCurrent**|The **Current** row version of all **Modified** rows.|  
    |**ModifiedOriginal**|The **Original** row version of all **Modified** rows.|  
    |**None**|No rows.|  
    |**OriginalRows**|The **Original** row version of all **Unchanged**, **Modified**, and **Deleted** rows.|  
    |**Unchanged**|The **Current** row version of all **Unchanged** rows.|  
  
 For more information about row states and row versions, see [Row States and Row Versions](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/row-states-and-row-versions.md).  
  
 The following code example creates a view that shows all the products where the number of units in stock is less than or equal to the reorder level, sorted first by supplier ID and then by product name.  
  
```vb  
Dim prodView As DataView = New DataView(prodDS.Tables("Products"), _  
   "UnitsInStock <= ReorderLevel", _  
   "SupplierID, ProductName", _  
   DataViewRowState.CurrentRows)  
```  
  
```csharp  
DataView prodView = new DataView(prodDS.Tables["Products"],  
   "UnitsInStock <= ReorderLevel",  
   "SupplierID, ProductName",  
   DataViewRowState.CurrentRows);  
```  
  
## See Also  
 <xref:System.Data.DataViewRowState>  
 <xref:System.Data.DataColumn.Expression%2A?displayProperty=nameWithType>  
 <xref:System.Data.DataTable>  
 <xref:System.Data.DataView>  
 [DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/dataviews.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
