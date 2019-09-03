---
title: "DataTableReaders"
ms.date: "03/30/2017"
ms.assetid: 97546ae2-0e42-4d26-961d-e0b244d81ded
---
# DataTableReaders
The <xref:System.Data.DataTableReader> presents the contents of a <xref:System.Data.DataTable> or a <xref:System.Data.DataSet> in the form of one or more read-only, forward-only result sets.  
  
 When you create a **DataTableReader** from a **DataTable**, the resulting **DataTableReader** object contains one result set with the same data as the **DataTable** from which it was created, except for any rows that have been marked as deleted. The columns appear in the same order as in the original **DataTable**.  
  
 A **DataTableReader** may contain multiple result sets if it was created by calling <xref:System.Data.DataSet.CreateDataReader%2A>. The results are in the same order as the **DataTables** in the **DataSet** object's <xref:System.Data.DataSet.Tables%2A> collection.  
  
## In This Section  
 [Creating a DataReader](creating-a-datareader.md)  
 Discusses how to create a **DataTableReader** object.  
  
 [Navigating DataTables](navigating-datatables.md)  
 Describes the use of the **Read** method to move through the contents of a **DataTableReader**.  
  
## See also

- [Retrieving and Modifying Data in ADO.NET](../retrieving-and-modifying-data.md)
- [ADO.NET Managed Providers and DataSet Developer Center](https://go.microsoft.com/fwlink/?LinkId=217917)
