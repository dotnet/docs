---
title: "How to: Bind data to the Windows Forms DataGridView control"
ms.date: "02/08/2019"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "data binding [Windows Forms], grids"
  - "data binding [Windows Forms], DataGridView control"
  - "DataGridView control [Windows Forms], data binding"
ms.assetid: 1660f69c-5711-45d2-abc1-e25bc6779124
author: rpetrusha
ms.author: ronpet
---
# How to: Bind data to the Windows Forms DataGridView control

The <xref:System.Windows.Forms.DataGridView> control supports the standard Windows Forms data binding model, so it can bind to a variety of data sources. Usually, you bind to a <xref:System.Windows.Forms.BindingSource> that manages the interaction with the data source. The <xref:System.Windows.Forms.BindingSource> can be any Windows Forms data source, which gives you great flexibility when choosing or modifying your data's location. For more information about data sources the <xref:System.Windows.Forms.DataGridView> control supports, see the [DataGridView control overview](datagridview-control-overview-windows-forms.md).  

Visual Studio has extensive support for data binding to the DataGridView control. For more information, see [How to: Bind data to the Windows Forms DataGridView control using the Designer](bind-data-to-the-datagrid-using-the-designer.md).  

To connect a DataGridView control to data:

1. Implement a method to handle the details of retrieving the data. The following code example implements a `GetData` method that initializes a <xref:System.Data.SqlClient.SqlDataAdapter>, and uses it to populate a <xref:System.Data.DataTable>. It then binds the <xref:System.Data.DataTable> to the <xref:System.Windows.Forms.BindingSource>. 

2. In the form's <xref:System.Windows.Forms.Form.Load> event handler, bind the <xref:System.Windows.Forms.DataGridView> control to the <xref:System.Windows.Forms.BindingSource>, and call the `GetData` method to retrieve the data.  

## Example

This complete code example retrieves data from a database to populate a DataGridView control in a Windows form. The form also has buttons to reload data and submit changes to the database.  

This example requires: 

- Access to a Northwind SQL Server sample database. For more information about installing the Northwind sample database, see [Get the sample databases for ADO.NET code samples](../../data/adonet/sql/linq/downloading-sample-databases.md). 

- References to the System, System.Windows.Forms, System.Data, and System.Xml assemblies.  

To build and run this example, paste the code into the *Form1* code file in a new Windows Forms project. For information about building from the C# or Visual Basic command line, see [Command-line building with csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md) or [Build from the command line](../../../visual-basic/reference/command-line-compiler/building-from-the-command-line.md).  
  
Populate the `connectionString` variable in the example with the values for your Northwind SQL Server sample database connection. Windows Authentication, also called integrated security, is a more secure way to connect to the database than storing a password in the connection string. For more information about connection security, see [Protect connection information](../../data/adonet/protecting-connection-information.md).  

[!code-csharp[System.Windows.Forms.DataGridViewBoundEditable](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/CS/datagridviewboundeditable.cs)]
[!code-vb[System.Windows.Forms.DataGridViewBoundEditable](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/VB/datagridviewboundeditable.vb)]  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridView.DataSource%2A?displayProperty=nameWithType>
- <xref:System.Windows.Forms.BindingSource>
- [Display data in the Windows Forms DataGridView control](displaying-data-in-the-windows-forms-datagridview-control.md)
- [Protect connection information](../../data/adonet/protecting-connection-information.md)
