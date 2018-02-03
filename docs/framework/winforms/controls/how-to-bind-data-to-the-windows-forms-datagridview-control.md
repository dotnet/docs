---
title: "How to: Bind Data to the Windows Forms DataGridView Control"
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
  - "cpp"
helpviewer_keywords: 
  - "data binding [Windows Forms], grids"
  - "data binding [Windows Forms], DataGridView control"
  - "DataGridView control [Windows Forms], data binding"
ms.assetid: 1660f69c-5711-45d2-abc1-e25bc6779124
caps.latest.revision: 30
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Bind Data to the Windows Forms DataGridView Control
The <xref:System.Windows.Forms.DataGridView> control supports the standard Windows Forms data binding model, so it will bind to a variety of data sources. In most circumstances, however, you will bind to a <xref:System.Windows.Forms.BindingSource> component which will manage the details of interacting with the data source. The <xref:System.Windows.Forms.BindingSource> component can represent any Windows Forms data source and gives you great flexibility when choosing or modifying the location of your data. For more information about the data sources supported by the <xref:System.Windows.Forms.DataGridView> control, see [DataGridView Control Overview](../../../../docs/framework/winforms/controls/datagridview-control-overview-windows-forms.md).  
  
 There is extensive support for this task in Visual Studio.  Also see [How to: Bind Data to the Windows Forms DataGridView Control Using the Designer](http://msdn.microsoft.com/library/33w255ac\(v=vs.110\)).  
  
## Procedure  
  
#### To connect a DataGridView control to data  
  
1.  Implement a method to handle the details of retrieving data from a database. The following code example implements a `GetData` method that initializes a <xref:System.Data.SqlClient.SqlDataAdapter> component and uses it to populate a <xref:System.Data.DataTable>. The <xref:System.Data.DataTable> is then bound to the <xref:System.Windows.Forms.BindingSource> component. Be sure to set the `connectionString` variable to a value that is appropriate for your database. You will need access to a server with the Northwind SQL Server sample database installed.  
  
     [!code-cpp[System.Windows.Forms.DataGridViewBoundEditable#20](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/cpp/datagridviewboundeditable.cpp#20)]
     [!code-csharp[System.Windows.Forms.DataGridViewBoundEditable#20](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/CS/datagridviewboundeditable.cs#20)]
     [!code-vb[System.Windows.Forms.DataGridViewBoundEditable#20](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/VB/datagridviewboundeditable.vb#20)]  
  
2.  In your form's <xref:System.Windows.Forms.Form.Load> event handler, bind the <xref:System.Windows.Forms.DataGridView> control to the <xref:System.Windows.Forms.BindingSource> component and call the `GetData` method to retrieve the data from the database.  
  
     [!code-cpp[System.Windows.Forms.DataGridViewBoundEditable#10](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/cpp/datagridviewboundeditable.cpp#10)]
     [!code-csharp[System.Windows.Forms.DataGridViewBoundEditable#10](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/CS/datagridviewboundeditable.cs#10)]
     [!code-vb[System.Windows.Forms.DataGridViewBoundEditable#10](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/VB/datagridviewboundeditable.vb#10)]  
  
## Example  
 The following complete code example provides buttons for reloading data from the database and submitting changes to the database.  
  
 [!code-cpp[System.Windows.Forms.DataGridViewBoundEditable#00](../../../../samples/snippets/cpp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/cpp/datagridviewboundeditable.cpp#00)]
 [!code-csharp[System.Windows.Forms.DataGridViewBoundEditable#00](../../../../samples/snippets/csharp/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/CS/datagridviewboundeditable.cs#00)]
 [!code-vb[System.Windows.Forms.DataGridViewBoundEditable#00](../../../../samples/snippets/visualbasic/VS_Snippets_Winforms/System.Windows.Forms.DataGridViewBoundEditable/VB/datagridviewboundeditable.vb#00)]  
  
## Compiling the Code  
 This example requires:  
  
-   References to the System, System.Windows.Forms, System.Data, and System.XML assemblies.  
  
 For information about building this example from the command line for [!INCLUDE[vbprvb](../../../../includes/vbprvb-md.md)] or [!INCLUDE[csprcs](../../../../includes/csprcs-md.md)], see [Building from the Command Line](~/docs/visual-basic/reference/command-line-compiler/building-from-the-command-line.md) or [Command-line Building With csc.exe](~/docs/csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md). You can also build this example in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] by pasting the code into a new project.  Also see [How to: Compile and Run a Complete Windows Forms Code Example Using Visual Studio](http://msdn.microsoft.com/library/Bb129228\(v=vs.110\)).  
  
## .NET Framework Security  
 Storing sensitive information, such as a password, within the connection string can affect the security of your application. Using Windows Authentication (also known as integrated security) is a more secure way to control access to a database. For more information, see [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md).  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridView.DataSource%2A?displayProperty=nameWithType>  
 <xref:System.Windows.Forms.BindingSource>  
 [Displaying Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/displaying-data-in-the-windows-forms-datagridview-control.md)  
 [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md)
