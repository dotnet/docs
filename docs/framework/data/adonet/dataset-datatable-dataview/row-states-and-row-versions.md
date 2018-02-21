---
title: "Row States and Row Versions"
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
ms.assetid: 2e6642c9-bfc6-425c-b3a7-e4912ffa6c1f
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# Row States and Row Versions
ADO.NET manages rows in tables using row states and versions. A row state indicates the status of a row; row versions maintain the values stored in a row as it is modified, including current, original, and default values. For example, after you have made a modification to a column in a row, the row will have a row state of `Modified`, and two row versions: `Current`, which contains the current row values, and `Original`, which contains the row values before the column was modified.  
  
 Each <xref:System.Data.DataRow> object has a <xref:System.Data.DataRow.RowState%2A> property that you can examine to determine the current state of the row. The following table gives a brief description of each `RowState` enumeration value.  
  
|RowState value|Description|  
|--------------------|-----------------|  
|<xref:System.Data.DataRowState.Unchanged>|No changes have been made since the last call to `AcceptChanges` or since the row was created by `DataAdapter.Fill`.|  
|<xref:System.Data.DataRowState.Added>|The row has been added to the table, but `AcceptChanges` has not been called.|  
|<xref:System.Data.DataRowState.Modified>|Some element of the row has been changed.|  
|<xref:System.Data.DataRowState.Deleted>|The row has been deleted from a table, and `AcceptChanges` has not been called.|  
|<xref:System.Data.DataRowState.Detached>|The row is not part of any `DataRowCollection`. The `RowState` of a newly created row is set to `Detached`. After the new `DataRow` is added to the `DataRowCollection` by calling the `Add` method, the value of the `RowState` property is set to `Added`.<br /><br /> `Detached` is also set for a row that has been removed from a `DataRowCollection` using the `Remove` method, or by the `Delete` method followed by the `AcceptChanges` method.|  
  
 When `AcceptChanges` is called on a <xref:System.Data.DataSet>, <xref:System.Data.DataTable> , or <xref:System.Data.DataRow>, all rows with a row state of `Deleted` are removed. The remaining rows are given a row state of `Unchanged`, and the values in the `Original` row version are overwritten with the `Current` row version values. When `RejectChanges` is called, all rows with a row state of `Added` are removed. The remaining rows are given a row state of `Unchanged`, and the values in the `Current` row version are overwritten with the `Original` row version values.  
  
 You can view the different row versions of a row by passing a <xref:System.Data.DataRowVersion> parameter with the column reference, as shown in the following example.  
  
```vb  
Dim custRow As DataRow = custTable.Rows(0)  
Dim custID As String = custRow("CustomerID", DataRowVersion.Original).ToString()  
```  
  
```csharp  
DataRow custRow = custTable.Rows[0];  
string custID = custRow["CustomerID", DataRowVersion.Original].ToString();  
```  
  
 The following table gives a brief description of each `DataRowVersion` enumeration value.  
  
|DataRowVersion value|Description|  
|--------------------------|-----------------|  
|<xref:System.Data.DataRowVersion.Current>|The current values for the row. This row version does not exist for rows with a `RowState` of `Deleted`.|  
|<xref:System.Data.DataRowVersion.Default>|The default row version for a particular row. The default row version for an `Added`, `Modified`, or `Unchanged` row is `Current`. The default row version for a `Deleted` row is `Original`. The default row version for a `Detached` row is `Proposed`.|  
|<xref:System.Data.DataRowVersion.Original>|The original values for the row. This row version does not exist for rows with a `RowState` of `Added`.|  
|<xref:System.Data.DataRowVersion.Proposed>|The proposed values for the row. This row version exists during an edit operation on a row, or for a row that is not part of a `DataRowCollection`.|  
  
 You can test whether a `DataRow` has a particular row version by calling the <xref:System.Data.DataRow.HasVersion%2A> method and passing a `DataRowVersion` as an argument. For example, `DataRow.HasVersion(DataRowVersion.Original)` will return `false` for newly added rows before `AcceptChanges` has been called.  
  
 The following code example displays the values in all the deleted rows of a table. `Deleted` rows do not have a `Current` row version, so you must pass `DataRowVersion.Original` when accessing the column values.  
  
```vb  
Dim catTable As DataTable = catDS.Tables("Categories")  
  
Dim delRows() As DataRow = catTable.Select(Nothing, Nothing, DataViewRowState.Deleted)  
  
Console.WriteLine("Deleted rows:" & vbCrLf)  
  
Dim catCol As DataColumn  
Dim delRow As DataRow  
  
For Each catCol In catTable.Columns  
  Console.Write(catCol.ColumnName & vbTab)  
Next  
Console.WriteLine()  
  
For Each delRow In delRows  
  For Each catCol In catTable.Columns  
    Console.Write(delRow(catCol, DataRowVersion.Original) & vbTab)  
  Next  
  Console.WriteLine()  
Next  
```  
  
```csharp  
DataTable catTable = catDS.Tables["Categories"];  
  
DataRow[] delRows = catTable.Select(null, null, DataViewRowState.Deleted);  
  
Console.WriteLine("Deleted rows:\n");  
  
foreach (DataColumn catCol in catTable.Columns)  
  Console.Write(catCol.ColumnName + "\t");  
Console.WriteLine();  
  
foreach (DataRow delRow in delRows)  
{  
  foreach (DataColumn catCol in catTable.Columns)  
    Console.Write(delRow[catCol, DataRowVersion.Original] + "\t");  
  Console.WriteLine();  
}  
```  
  
## See Also  
 [Manipulating Data in a DataTable](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/manipulating-data-in-a-datatable.md)  
 [DataSets, DataTables, and DataViews](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/index.md)  
 [DataAdapters and DataReaders](../../../../../docs/framework/data/adonet/dataadapters-and-datareaders.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
