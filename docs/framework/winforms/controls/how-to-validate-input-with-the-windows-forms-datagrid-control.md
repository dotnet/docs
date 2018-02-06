---
title: "How to: Validate Input with the Windows Forms DataGrid Control"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "DataGrid control [Windows Forms], examples"
  - "user input [Windows Forms], validating"
  - "examples [Windows Forms], DataGrid control"
  - "DataGrid control [Windows Forms], validating input"
  - "validation [Windows Forms], user input"
ms.assetid: f1e9c3a0-d0a1-4893-a615-b4b0db046c63
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Validate Input with the Windows Forms DataGrid Control
> [!NOTE]
>  The <xref:System.Windows.Forms.DataGridView> control replaces and adds functionality to the <xref:System.Windows.Forms.DataGrid> control; however, the <xref:System.Windows.Forms.DataGrid> control is retained for both backward compatibility and future use, if you choose. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).  
  
 There are two types of input validation available for the Windows Forms <xref:System.Windows.Forms.DataGrid> control. If the user attempts to enter a value that is of an unacceptable data type for the cell, for example a string into an integer, the new invalid value is replaced with the old value. This kind of input validation is done automatically and cannot be customized.  
  
 The other type of input validation can be used to reject any unacceptable data, for example a 0 value in a field that must be greater than or equal to 1, or an inappropriate string. This is done in the dataset by writing an event handler for the <xref:System.Data.DataTable.ColumnChanging> or <xref:System.Data.DataTable.RowChanging> event. The example below uses the <xref:System.Data.DataTable.ColumnChanging> event because the unacceptable value is disallowed for the "Product" column in particular. You might use the <xref:System.Data.DataTable.RowChanging> event for checking that the value of an "End Date" column is later than the "Start Date" column in the same row.  
  
### To validate user input  
  
1.  Write code to handle the <xref:System.Data.DataTable.ColumnChanging> event for the appropriate table. When inappropriate input is detected, call the <xref:System.Data.DataRow.SetColumnError%2A> method of the <xref:System.Data.DataRow> object.  
  
    ```vb  
    Private Sub Customers_ColumnChanging(ByVal sender As Object, _  
    ByVal e As System.Data.DataColumnChangeEventArgs)  
       ' Only check for errors in the Product column  
       If (e.Column.ColumnName.Equals("Product")) Then  
          ' Do not allow "Automobile" as a product.  
          If CType(e.ProposedValue, String) = "Automobile" Then  
             Dim badValue As Object = e.ProposedValue  
             e.ProposedValue = "Bad Data"  
             e.Row.RowError = "The Product column contians an error"  
             e.Row.SetColumnError(e.Column, "Product cannot be " & _  
             CType(badValue, String))  
          End If  
       End If  
    End Sub  
    ```  
  
    ```csharp  
    //Handle column changing events on the Customers table  
    private void Customers_ColumnChanging(object sender, System.Data.DataColumnChangeEventArgs e) {  
  
       //Only check for errors in the Product column  
       if (e.Column.ColumnName.Equals("Product")) {  
  
          //Do not allow "Automobile" as a product  
          if (e.ProposedValue.Equals("Automobile")) {  
             object badValue = e.ProposedValue;  
             e.ProposedValue = "Bad Data";  
             e.Row.RowError = "The Product column contains an error";  
             e.Row.SetColumnError(e.Column, "Product cannot be " + badValue);  
          }  
       }  
    }  
    ```  
  
2.  Connect the event handler to the event.  
  
     Place the following code within either the form's <xref:System.Windows.Forms.Form.Load> event or its constructor.  
  
    ```vb  
    ' Assumes the grid is bound to a dataset called customersDataSet1  
    ' with a table called Customers.  
    ' Put this code in the form's Load event or its constructor.  
    AddHandler customersDataSet1.Tables("Customers").ColumnChanging, AddressOf Customers_ColumnChanging  
    ```  
  
    ```csharp  
    // Assumes the grid is bound to a dataset called customersDataSet1  
    // with a table called Customers.  
    // Put this code in the form's Load event or its constructor.  
    customersDataSet1.Tables["Customers"].ColumnChanging += new DataColumnChangeEventHandler(this.Customers_ColumnChanging);  
    ```  
  
## See Also  
 <xref:System.Windows.Forms.DataGrid>  
 <xref:System.Data.DataTable.ColumnChanging>  
 <xref:System.Data.DataRow.SetColumnError%2A>  
 [DataGrid Control](../../../../docs/framework/winforms/controls/datagrid-control-windows-forms.md)
