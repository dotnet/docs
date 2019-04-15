---
title: "How to: Validate Data in the Windows Forms DataGridView Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "data [Windows Forms], validation"
  - "DataGridView control [Windows Forms], data validation"
  - "data grids [Windows Forms], validating data"
  - "data validation [Windows Forms], Windows Forms"
ms.assetid: d10aef35-701e-4a3c-a684-2a2ed1aeaca6
---
# How to: Validate Data in the Windows Forms DataGridView Control
The following code example demonstrates how to validate data entered by a user into a <xref:System.Windows.Forms.DataGridView> control. In this example, the <xref:System.Windows.Forms.DataGridView> is populated with rows from the `Customers` table of the Northwind sample database. When the user edits a cell in the `CompanyName` column, its value is tested for validity by checking that it is not empty. If the event handler for the <xref:System.Windows.Forms.DataGridView.CellValidating> event finds that the value is an empty string, the <xref:System.Windows.Forms.DataGridView> prevents the user from exiting the cell until a non-empty string is entered.  
  
 For a complete explanation of this code example, see [Walkthrough: Validating Data in the Windows Forms DataGridView Control](walkthrough-validating-data-in-the-windows-forms-datagridview-control.md).  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridViewDataValidation#00](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/CS/datavalidation.cs#00)]
 [!code-vb[System.Windows.Forms.DataGridViewDataValidation#00](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewDataValidation/VB/datavalidation.vb#00)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Data, System.Windows.Forms and System.XML assemblies.  
  
 For information about building this example from the command line for Visual Basic or Visual C#, see [Building from the Command Line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in Visual Studio by pasting the code into a new project.  
  
## .NET Framework Security  
 Storing sensitive information, such as a password, within the connection string can affect the security of your application. Using Windows Authentication (also known as integrated security) is a more secure way to control access to a database. For more information, see [Protecting Connection Information](../../data/adonet/protecting-connection-information.md).  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.BindingSource>
- [Walkthrough: Validating Data in the Windows Forms DataGridView Control](walkthrough-validating-data-in-the-windows-forms-datagridview-control.md)
- [Data Entry in the Windows Forms DataGridView Control](data-entry-in-the-windows-forms-datagridview-control.md)
- [Walkthrough: Handling Errors that Occur During Data Entry in the Windows Forms DataGridView Control](handling-errors-that-occur-during-data-entry-in-the-datagrid.md)
- [Protecting Connection Information](../../data/adonet/protecting-connection-information.md)
