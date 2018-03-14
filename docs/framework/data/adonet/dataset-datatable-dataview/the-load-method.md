---
title: "The Load Method"
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
  - "vb"
ms.assetid: e22e5812-89c6-41f0-9302-bb899a46dbff
caps.latest.revision: 3
author: "douglaslMS"
ms.author: "douglasl"
manager: "craigg"
ms.workload: 
  - "dotnet"
---
# The Load Method
You can use the <xref:System.Data.DataTable.Load%2A> method to load a <xref:System.Data.DataTable> with rows from a data source. This is an overloaded method which, in its simplest form, accepts a single parameter, a **DataReader**. In this form, it simply loads the **DataTable** with rows. Optionally, you can specify the **LoadOption** parameter to control how data is added to the **DataTable**.  
  
 The **LoadOption** parameter is particularly useful in cases where the **DataTable** already contains rows of data, because it describes how incoming data from the data source will be combined with the data already in the table. For example, **PreserveCurrentValues** (the default) specifies that in cases where a row is marked as **Added** in the **DataTable**, the **Original** value or each column is set to the contents of the matching row from the data source. The **Current** value will retain the values assigned when the row was added, and the **RowState** of the row will be set to **Changed**.  
  
 The following table gives a short description of the <xref:System.Data.LoadOption> enumeration values.  
  
|LoadOption value|Description|  
|----------------------|-----------------|  
|**OverwriteRow**|If incoming rows have the same **PrimaryKey** value as a row already in the **DataTable**, the **Original** and **Current** values of each column are replaced with the values in the incoming row, and the **RowState** property is set to **Unchanged**.<br /><br /> Rows from the data source that do not already exist in the **DataTable** are added with a **RowState** value of **Unchanged**.<br /><br /> This option in effect refreshes the contents of the **DataTable** so that it matches the contents of the data source.|  
|**PreserveCurrentValues (default)**|If incoming rows have the same **PrimaryKey** value as a row already in the **DataTable**, the **Original** value is set to the contents of the incoming row, and the **Current** value is not changed.<br /><br /> If the **RowState** is **Added** or **Modified**, it is set to **Modified**.<br /><br /> If the **RowState** was **Deleted**, it remains **Deleted**.<br /><br /> Rows from the data source that do not already exist in the **DataTable** are added, and the **RowState** is set to **Unchanged**.|  
|**UpdateCurrentValues**|If incoming rows have the same **PrimaryKey** value as the row already in the **DataTable**, the **Current** value is copied to the **Original** value, and the **Current** value is then set to the contents of the incoming row.<br /><br /> If the **RowState** in the **DataTable** was **Added**, the **RowState** remains **Added**. For rows marked as **Modified** or **Deleted**, the **RowState** is **Modified**.<br /><br /> Rows from the data source that do not already exist in the **DataTable** are added, and the **RowState** is set to **Added**.|  
  
 The following sample uses the **Load** method to display a list of birthdays for the employees in the **Northwind** database.  
  
```vb  
Private Sub LoadBirthdays(ByVal connectionString As String)  
    ' Assumes that connectionString is a valid connection string  
    ' to the Northwind database on SQL Server.  
    Dim queryString As String = _  
    "SELECT LastName, FirstName, BirthDate " & _  
      " FROM dbo.Employees " & _  
      "ORDER BY BirthDate, LastName, FirstName"  
  
    ' Open and fill a DataSet.   
    Dim adapter As SqlDataAdapter = New SqlDataAdapter( _  
        queryString, connectionString)  
    Dim employees As New DataSet  
    adapter.Fill(employees, "Employees")  
  
    ' Create a SqlDataReader for use with the Load Method.  
    Dim reader As DataTableReader = employees.GetDataReader()  
  
    ' Create an instance of DataTable and assign the first  
    ' DataTable in the DataSet.Tables collection to it.  
    Dim dataTableEmp As DataTable = employees.Tables(0)  
  
    ' Fill the DataTable with data by calling Load and  
    ' passing the SqlDataReader.  
    dataTableEmp.Load(reader, LoadOption.OverwriteRow)  
  
    ' Loop through the rows collection and display the values  
    ' in the console window.  
    Dim employeeRow As DataRow  
    For Each employeeRow In dataTableEmp.Rows  
        Console.WriteLine("{0:MM\\dd\\yyyy}" & ControlChars.Tab & _  
          "{1}, {2}", _  
          employeeRow("BirthDate"), _  
          employeeRow("LastName"), _  
          employeeRow("FirstName"))  
    Next employeeRow  
  
    ' Keep the window opened to view the contents.  
    Console.ReadLine()  
End Sub  
```  
  
## See Also  
 [Manipulating Data in a DataTable](../../../../../docs/framework/data/adonet/dataset-datatable-dataview/manipulating-data-in-a-datatable.md)  
 [ADO.NET Managed Providers and DataSet Developer Center](http://go.microsoft.com/fwlink/?LinkId=217917)
