---
title: "Walkthrough: Validating Data in the Windows Forms DataGridView Control"
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
  - "validating data [Windows Forms], Windows Forms"
  - "data [Windows Forms], validation"
  - "DataGridView control [Windows Forms], data validation"
  - "data grids [Windows Forms], validating data"
  - "data validation [Windows Forms], Windows Forms"
  - "walkthroughs [Windows Forms], DataGridView control"
ms.assetid: a4f1d015-2969-430c-8ea2-b612d179c290
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Validating Data in the Windows Forms DataGridView Control
When you display data entry functionality to users, you frequently have to validate the data entered into your form. The <xref:System.Windows.Forms.DataGridView> class provides a convenient way to perform validation before data is committed to the data store. You can validate data by handling the <xref:System.Windows.Forms.DataGridView.CellValidating> event, which is raised by the <xref:System.Windows.Forms.DataGridView> when the current cell changes.  
  
 In this walkthrough, you will retrieve rows from the `Customers` table in the Northwind sample database and display them in a <xref:System.Windows.Forms.DataGridView> control. When a user edits a cell in the `CompanyName` column and tries to leave the cell, the <xref:System.Windows.Forms.DataGridView.CellValidating> event handler will examine new company name string to make sure it is not empty; if the new value is an empty string, the <xref:System.Windows.Forms.DataGridView> will prevent the user's cursor from leaving the cell until a non-empty string is entered.  
  
 To copy the code in this topic as a single listing, see [How to: Validate Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-validate-data-in-the-windows-forms-datagridview-control.md).  
  
## Prerequisites  
 In order to complete this walkthrough, you will need:  
  
-   Access to a server that has the Northwind SQL Server sample database.  
  
## Creating the Form  
  
#### To validate data entered in a DataGridView  
  
1.  Create a class that derives from <xref:System.Windows.Forms.Form> and contains a <xref:System.Windows.Forms.DataGridView> control and a <xref:System.Windows.Forms.BindingSource> component.  
  
     The following code example provides basic initialization and includes a `Main` method.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewDataValidation#01](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/CS/datavalidation.cs#01)]
     [!code-vb[System.Windows.Forms.DataGridViewDataValidation#01](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/VB/datavalidation.vb#01)]  
    [!code-csharp[System.Windows.Forms.DataGridViewDataValidation#02](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/CS/datavalidation.cs#02)]
    [!code-vb[System.Windows.Forms.DataGridViewDataValidation#02](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/VB/datavalidation.vb#02)]  
  
2.  Implement a method in your form's class definition for handling the details of connecting to the database.  
  
     This code example uses a `GetData` method that returns a populated <xref:System.Data.DataTable> object. Be sure that you set the `connectionString` variable to a value that is appropriate for your database.  
  
    > [!IMPORTANT]
    >  Storing sensitive information, such as a password, within the connection string can affect the security of your application. Using Windows Authentication, also known as integrated security, is a more secure way to control access to a database. For more information, see [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md).  
  
     [!code-csharp[System.Windows.Forms.DataGridViewDataValidation#30](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/CS/datavalidation.cs#30)]
     [!code-vb[System.Windows.Forms.DataGridViewDataValidation#30](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/VB/datavalidation.vb#30)]  
  
3.  Implement a handler for your form's <xref:System.Windows.Forms.Form.Load> event that initializes the <xref:System.Windows.Forms.DataGridView> and <xref:System.Windows.Forms.BindingSource> and sets up the data binding.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewDataValidation#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/CS/datavalidation.cs#10)]
     [!code-vb[System.Windows.Forms.DataGridViewDataValidation#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/VB/datavalidation.vb#10)]  
  
4.  Implement handlers for the <xref:System.Windows.Forms.DataGridView> control's <xref:System.Windows.Forms.DataGridView.CellValidating> and <xref:System.Windows.Forms.DataGridView.CellEndEdit> events.  
  
     The <xref:System.Windows.Forms.DataGridView.CellValidating> event handler is where you determine whether the value of a cell in the `CompanyName` column is empty. If the cell value fails validation, set the <xref:System.ComponentModel.CancelEventArgs.Cancel%2A> property of the <xref:System.Windows.Forms.DataGridViewCellValidatingEventArgs?displayProperty=nameWithType> class to `true`. This causes the <xref:System.Windows.Forms.DataGridView> control to prevent the cursor from leaving the cell. Set the <xref:System.Windows.Forms.DataGridViewRow.ErrorText%2A> property on the row to an explanatory string. This displays an error icon with a ToolTip that contains the error text. In the <xref:System.Windows.Forms.DataGridView.CellEndEdit> event handler, set the <xref:System.Windows.Forms.DataGridViewRow.ErrorText%2A> property on the row to the empty string. The <xref:System.Windows.Forms.DataGridView.CellEndEdit> event occurs only when the cell exits edit mode, which it cannot do if it fails validation.  
  
     [!code-csharp[System.Windows.Forms.DataGridViewDataValidation#20](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/CS/datavalidation.cs#20)]
     [!code-vb[System.Windows.Forms.DataGridViewDataValidation#20](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/VB/datavalidation.vb#20)]  
  
## Testing the Application  
 You can now test the form to make sure it behaves as expected.  
  
#### To test the form  
  
-   Compile and run the application.  
  
     You will see a <xref:System.Windows.Forms.DataGridView> filled with data from the `Customers` table. When you double-click a cell in the `CompanyName` column, you can edit the value. If you delete all the characters and hit the TAB key to exit the cell, the <xref:System.Windows.Forms.DataGridView> prevents you from exiting. When you type a non-empty string into the cell, the <xref:System.Windows.Forms.DataGridView> control lets you exit the cell.  
  
## Next Steps  
 This application gives you a basic understanding of the <xref:System.Windows.Forms.DataGridView> control's capabilities. You can customize the appearance and behavior of the <xref:System.Windows.Forms.DataGridView> control in several ways:  
  
-   Change border and header styles. For more information, see [How to: Change the Border and Gridline Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/change-the-border-and-gridline-styles-in-the-datagrid.md).  
  
-   Enable or restrict user input to the <xref:System.Windows.Forms.DataGridView> control. For more information, see [How to: Prevent Row Addition and Deletion in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/prevent-row-addition-and-deletion-datagridview.md), and [How to: Make Columns Read-Only in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-make-columns-read-only-in-the-windows-forms-datagridview-control.md).  
  
-   Check user input for database-related errors. For more information, see [Walkthrough: Handling Errors that Occur During Data Entry in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/handling-errors-that-occur-during-data-entry-in-the-datagrid.md).  
  
-   Handle very large data sets using virtual mode. For more information, see [Walkthrough: Implementing Virtual Mode in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/implementing-virtual-mode-wf-datagridview-control.md).  
  
-   Customize the appearance of cells. For more information, see [How to: Customize the Appearance of Cells in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/customize-the-appearance-of-cells-in-the-datagrid.md) and [How to: Set Font and Color Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-set-font-and-color-styles-in-the-windows-forms-datagridview-control.md).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.BindingSource>  
 [Data Entry in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/data-entry-in-the-windows-forms-datagridview-control.md)  
 [How to: Validate Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-validate-data-in-the-windows-forms-datagridview-control.md)  
 [Walkthrough: Handling Errors that Occur During Data Entry in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/handling-errors-that-occur-during-data-entry-in-the-datagrid.md)  
 [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md)
