---
description: "Learn more about: AcceptChanges and RejectChanges"
title: "AcceptChanges and RejectChanges"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: e2d1a6fe-31f9-4b83-9728-06c406a3394e
---
# AcceptChanges and RejectChanges

After verifying the accuracy of changes made to data in a <xref:System.Data.DataTable>, you can accept the changes using the <xref:System.Data.DataRow.AcceptChanges%2A> method of the <xref:System.Data.DataRow>, <xref:System.Data.DataTable>, or <xref:System.Data.DataSet>, which will set the **Current** row values to be the **Original** values and will set the **RowState** property to **Unchanged**. Accepting or rejecting changes clears out any **RowError** information and sets the **HasErrors** property to **false**. Accepting or rejecting changes can also affect updating data in the data source. For more information, see [Updating Data Sources with DataAdapters](../updating-data-sources-with-dataadapters.md).  
  
 If foreign key constraints exist on the **DataTable**, changes accepted or rejected using **AcceptChanges** and **RejectChanges** are propagated to child rows of the **DataRow** according to the **ForeignKeyConstraint.AcceptRejectRule**. For more information, see [DataTable Constraints](datatable-constraints.md).  
  
 The following example checks for rows with errors, resolves the errors where applicable, and rejects the rows where the error cannot be resolved. Note that, for resolved errors, the **RowError** value is reset to an empty string, causing the **HasErrors** property to be set to **false**. When all the rows with errors have been resolved or rejected, **AcceptChanges** is called to accept all changes for the entire **DataTable**.  
  
```vb  
If workTable.HasErrors Then  
  Dim errRow As DataRow  
  
  For Each errRow in workTable.GetErrors()  
  
    If errRow.RowError = "Total cannot exceed 1000." Then  
      errRow("Total") = 1000  
      errRow.RowError = ""    ' Clear the error.  
    Else  
      errRow.RejectChanges()  
    End If  
  Next  
End If  
  
workTable.AcceptChanges()  
```  
  
```csharp  
if (workTable.HasErrors)  
{  
  
  foreach (DataRow errRow in workTable.GetErrors())  
  {  
    if (errRow.RowError == "Total cannot exceed 1000.")  
    {  
      errRow["Total"] = 1000;  
      errRow.RowError = "";    // Clear the error.  
    }  
    else  
      errRow.RejectChanges();  
  }  
}  
  
workTable.AcceptChanges();  
```  
  
## See also

- <xref:System.Data.DataRow>
- <xref:System.Data.DataSet>
- <xref:System.Data.DataTable>
- [Manipulating Data in a DataTable](manipulating-data-in-a-datatable.md)
- [ADO.NET Overview](../ado-net-overview.md)
