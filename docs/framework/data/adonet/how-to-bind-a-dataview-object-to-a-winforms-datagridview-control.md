---
description: "Learn more about: How to: Bind a DataView Object to a Windows Forms DataGridView Control"
title: "How to: Bind a DataView Object to a Windows Forms DataGridView Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
ms.assetid: 2b73d60a-6049-446a-85a7-3e5a68b183e2
---
# How to: Bind a DataView Object to a Windows Forms DataGridView Control

The <xref:System.Windows.Forms.DataGridView> control provides a powerful and flexible way to display data in a tabular format. The <xref:System.Windows.Forms.DataGridView> control supports the standard Windows Forms data binding model, so it will bind to <xref:System.Data.DataView> and a variety of other data sources. In most situations, however, you will bind to a <xref:System.Windows.Forms.BindingSource> component that will manage the details of interacting with the data source.  
  
 For more information about the <xref:System.Windows.Forms.DataGridView> control, see [DataGridView Control Overview](/dotnet/desktop/winforms/controls/datagridview-control-overview-windows-forms).  
  
### To connect a DataGridView control to a DataView  
  
1. Implement a method to handle the details of retrieving data from a database. The following code example implements a `GetData` method that initializes a <xref:System.Data.SqlClient.SqlDataAdapter> component and uses it to fill a <xref:System.Data.DataSet>. Be sure to set the `connectionString` variable to a value that is appropriate for your database. You will need access to a server with the AdventureWorks SQL Server sample database installed.  
  
     [!code-csharp[DP DataViewWinForms Sample#LDVSample1GetData](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataViewWinForms Sample/CS/Form1.cs#ldvsample1getdata)]
     [!code-vb[DP DataViewWinForms Sample#LDVSample1GetData](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataViewWinForms Sample/VB/Form1.vb#ldvsample1getdata)]  
  
2. In the <xref:System.Windows.Forms.Form.Load> event handler of your form, bind the <xref:System.Windows.Forms.DataGridView> control to the <xref:System.Windows.Forms.BindingSource> component and call the `GetData` method to retrieve the data from the database. The <xref:System.Data.DataView> is created from a LINQ to DataSet query over the Contact <xref:System.Data.DataTable> and is then bound to the <xref:System.Windows.Forms.BindingSource> component.  
  
     [!code-csharp[DP DataViewWinForms Sample#LDVSample1FormLoad](../../../../samples/snippets/csharp/VS_Snippets_ADO.NET/DP DataViewWinForms Sample/CS/Form1.cs#ldvsample1formload)]
     [!code-vb[DP DataViewWinForms Sample#LDVSample1FormLoad](../../../../samples/snippets/visualbasic/VS_Snippets_ADO.NET/DP DataViewWinForms Sample/VB/Form1.vb#ldvsample1formload)]  
  
## See also

- [Data Binding and LINQ to DataSet](data-binding-and-linq-to-dataset.md)
