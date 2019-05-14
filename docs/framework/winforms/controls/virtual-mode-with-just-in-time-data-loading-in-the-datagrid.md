---
title: "How to: Implement Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "examples [Windows Forms], just-in-time data loading"
  - "data [Windows Forms], managing large data sets"
  - "DataGridView control [Windows Forms], virtual mode"
  - "just-in-time data loading"
  - "DataGridView control [Windows Forms], large data sets"
  - "virtual mode [Windows Forms], just-in-time data loading"
ms.assetid: 33825f92-7a22-40ee-86d9-9a2ed1ead7b7
---
# How to: Implement Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control
The following code example shows how to use virtual mode in the <xref:System.Windows.Forms.DataGridView> control with a data cache that loads data from a server only when it is needed. This example is described in detail in [Implementing Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control](implementing-virtual-mode-jit-data-loading-in-the-datagrid.md).  
  
## Example  
 [!code-csharp[System.Windows.Forms.DataGridView.Virtual_lazyloading#000](~/samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/CS/lazyloading.cs#000)]
 [!code-vb[System.Windows.Forms.DataGridView.Virtual_lazyloading#000](~/samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridView.Virtual_lazyloading/VB/lazyloading.vb#000)]  
  
## Compiling the Code  
 This example requires:  
  
- References to the System, System.Data, System.Xml, and System.Windows.Forms assemblies.  
  
- Access to a server with the Northwind SQL Server sample database installed.  
  
## .NET Framework Security  
 Storing sensitive information, such as a password, within the connection string can affect the security of your application. Using Windows Authentication (also known as integrated security) is a more secure way to control access to a database. For more information, see [Protecting Connection Information](../../data/adonet/protecting-connection-information.md).  
  
## See also

- <xref:System.Windows.Forms.DataGridView>
- <xref:System.Windows.Forms.DataGridView.VirtualMode%2A>
- <xref:System.Windows.Forms.DataGridView.CellValueNeeded>
- [Implementing Virtual Mode with Just-In-Time Data Loading in the Windows Forms DataGridView Control](implementing-virtual-mode-jit-data-loading-in-the-datagrid.md)
- [Performance Tuning in the Windows Forms DataGridView Control](performance-tuning-in-the-windows-forms-datagridview-control.md)
- [Virtual Mode in the Windows Forms DataGridView Control](virtual-mode-in-the-windows-forms-datagridview-control.md)
