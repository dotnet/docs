---
title: "How to: Bind the Windows Forms DataGrid Control to a Data Source Using the Designer"
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
  - "datasets [Windows Forms], binding to DataGrid control"
  - "data binding [Windows Forms], DataGrid control"
  - "DataGrid control [Windows Forms], data binding"
  - "Windows Forms controls, data binding"
  - "bound controls [Windows Forms]"
ms.assetid: 4e96e3d0-b1cc-4de1-8774-bc9970ec4554
caps.latest.revision: 15
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Bind the Windows Forms DataGrid Control to a Data Source Using the Designer
> [!NOTE]
>  The <xref:System.Windows.Forms.DataGridView> control replaces and adds functionality to the <xref:System.Windows.Forms.DataGrid> control; however, the <xref:System.Windows.Forms.DataGrid> control is retained for both backward compatibility and future use, if you choose. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).  
  
 The Windows Forms <xref:System.Windows.Forms.DataGrid> control is specifically designed to display information from a data source. You bind the control at design time by setting the <xref:System.Windows.Forms.DataGrid.DataSource%2A> and <xref:System.Windows.Forms.DataGrid.DataMember%2A> properties, or at run time by calling the <xref:System.Windows.Forms.DataGrid.SetDataBinding%2A> method. Although you can display data from a variety of data sources, the most typical sources are datasets and data views.  
  
 If the data source is available at design time—for example, if the form contains an instance of a dataset or a data view—you can bind the grid to the data source at design time. You can then preview what the data will look like in the grid.  
  
 You can also bind the grid programmatically, at run time. This is useful when you want to set a data source based on information you get at run time. For example, the application might let the user specify the name of a table to view. It is also necessary in situations where the data source does not exist at design time. This includes data sources such as arrays, collections, untyped datasets, and data readers.  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGrid> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md). In [!INCLUDE[vsprvslong](../../../../includes/vsprvslong-md.md)], the <xref:System.Windows.Forms.DataGrid> control is not in the **Toolbox** by default. For information about adding it, see [How to: Add Items to the Toolbox](http://msdn.microsoft.com/library/458e119e-17fe-450b-b889-e31c128bd7e0). Additionally in [!INCLUDE[vsprvslong](../../../../includes/vsprvslong-md.md)], you can use the **Data Sources** window for design-time data binding. For more information see [Bind controls to data in Visual Studio](/visualstudio/data-tools/bind-controls-to-data-in-visual-studio).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To data-bind the DataGrid control to a single table in the designer  
  
1.  Set the control's <xref:System.Windows.Forms.DataGrid.DataSource%2A> property to the object containing the data items you want to bind to.  
  
2.  If the data source is a dataset, set the <xref:System.Windows.Forms.DataGrid.DataMember%2A> property to the name of the table to bind to.  
  
3.  If the data source is a dataset or a data view based on a dataset table, add code to the form to fill the dataset.  
  
     The exact code you use depends on where the dataset is getting data. If the dataset is being populated directly from a database, you typically call the `Fill` method of a data adapter, as in the following code example, which populates a dataset called `DsCategories1`:  
  
    ```vb  
    sqlDataAdapter1.Fill(DsCategories1)  
    ```  
  
    ```csharp  
    sqlDataAdapter1.Fill(DsCategories1);  
    ```  
  
    ```cpp  
    sqlDataAdapter1->Fill(dsCategories1);  
    ```  
  
4.  (Optional) Add the appropriate table styles and column styles to the grid.  
  
     If there are no table styles, you will see the table, but with minimal formatting and with all columns visible.  
  
### To data-bind the DataGrid control to multiple tables in a dataset in the designer  
  
1.  Set the control's <xref:System.Windows.Forms.DataGrid.DataSource%2A> property to the object containing the data items you want to bind to.  
  
2.  If the dataset contains related tables (that is, if it contains a relation object), set the <xref:System.Windows.Forms.DataGrid.DataMember%2A> property to the name of the parent table.  
  
3.  Write code to fill the dataset.  
  
## See Also  
 [DataGrid Control Overview](../../../../docs/framework/winforms/controls/datagrid-control-overview-windows-forms.md)  
 [How to: Add Tables and Columns to the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-add-tables-and-columns-to-the-windows-forms-datagrid-control.md)  
 [DataGrid Control](../../../../docs/framework/winforms/controls/datagrid-control-windows-forms.md)  
 [Windows Forms Data Binding](../../../../docs/framework/winforms/windows-forms-data-binding.md)  
 [Accessing data in Visual Studio](/visualstudio/data-tools/accessing-data-in-visual-studio)
