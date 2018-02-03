---
title: "Creating a DataView"
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
ms.assetid: b1cc02d1-23b1-4439-a998-0da1899f3442
caps.latest.revision: 4
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Creating a DataView
There are two ways to create a <xref:System.Data.DataView>. You can use the **DataView** constructor, or you can create a reference to the <xref:System.Data.DataTable.DefaultView%2A> property of the <xref:System.Data.DataTable>. The **DataView** constructor can be empty, or it can take either a **DataTable** as a single argument, or a **DataTable** along with filter criteria, sort criteria, and a row state filter. For more information about the additional arguments available for use with the **DataView**, see [Sorting and Filtering Data](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/sorting-and-filtering-data.md).  
  
 Because the index for a **DataView** is built both when the **DataView** is created, and when any of the **Sort**, **RowFilter**, or **RowStateFilter** properties are modified, you achieve best performance by supplying any initial sort order or filtering criteria as constructor arguments when you create the **DataView**. Creating a **DataView** without specifying sort or filter criteria and then setting the **Sort**, **RowFilter**, or **RowStateFilter** properties later causes the index to be built at least twice: once when the **DataView** is created, and again when any of the sort or filter properties are modified.  
  
 Note that if you create a **DataView** using the constructor that does not take any arguments, you will not be able to use the **DataView** until you have set the **Table** property.  
  
 The following code example demonstrates how to create a **DataView** using the **DataView** constructor. A **RowFilter**, **Sort** column, and **DataViewRowState** are supplied along with the **DataTable**.  
  
```vb  
Dim custDV As DataView = New DataView(custDS.Tables("Customers"), _  
    "Country = 'USA'", _  
    "ContactName", _  
    DataViewRowState.CurrentRows)  
```  
  
```csharp  
DataView custDV = new DataView(custDS.Tables["Customers"],   
    "Country = 'USA'",   
    "ContactName",   
    DataViewRowState.CurrentRows);  
```  
  
 The following code example demonstrates how to obtain a reference to the default **DataView** of a **DataTable** using the **DefaultView** property of the table.  
  
```vb  
Dim custDV As DataView = custDS.Tables("Customers").DefaultView  
```  
  
```csharp  
DataView custDV = custDS.Tables["Customers"].DefaultView;  
```  
  
## See Also  
 <xref:System.Data.DataTable>  
 <xref:System.Data.DataView>  
 [DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/dataviews.md)  
 [Sorting and Filtering Data](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/sorting-and-filtering-data.md)  
 [DataTables](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/datatables.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
