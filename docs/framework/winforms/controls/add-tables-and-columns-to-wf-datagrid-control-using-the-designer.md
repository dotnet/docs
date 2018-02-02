---
title: "How to: Add Tables and Columns to the Windows Forms DataGrid Control Using the Designer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "columns [Windows Forms], adding to DataGrid control"
  - "tables [Windows Forms], adding to DataGrid control"
  - "DataGrid control [Windows Forms], adding tables and columns"
ms.assetid: 4a6d1b34-b696-476b-bf8a-57c6230aa9e1
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Add Tables and Columns to the Windows Forms DataGrid Control Using the Designer
> [!NOTE]
>  The <xref:System.Windows.Forms.DataGridView> control replaces and adds functionality to the <xref:System.Windows.Forms.DataGrid> control; however, the <xref:System.Windows.Forms.DataGrid> control is retained for both backward compatibility and future use, if you choose. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).  
  
 You can display data in the Windows Forms <xref:System.Windows.Forms.DataGrid> control in tables and columns by creating <xref:System.Windows.Forms.DataGridTableStyle> objects and adding them to the <xref:System.Windows.Forms.GridTableStylesCollection> object, which is accessed through the <xref:System.Windows.Forms.DataGrid> control's <xref:System.Windows.Forms.DataGrid.TableStyles%2A> property. Each table style displays the contents of whatever data table is specified in the <xref:System.Windows.Forms.DataGridTableStyle.MappingName%2A> property of the <xref:System.Windows.Forms.DataGridTableStyle>. By default, a table style without column styles specified will display all the columns within that data table. You can restrict which columns from the table appear by adding <xref:System.Windows.Forms.DataGridColumnStyle> objects to the <xref:System.Windows.Forms.GridColumnStylesCollection>, which is accessed through the <xref:System.Windows.Forms.DataGridTableStyle.GridColumnStyles%2A> property of each <xref:System.Windows.Forms.DataGridTableStyle>.  
  
 The following procedures require a **Windows Application** project with a form that contains a <xref:System.Windows.Forms.DataGrid> control. For information about how to set up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md). By default in [!INCLUDE[vsprvslong](../../../../includes/vsprvslong-md.md)], the <xref:System.Windows.Forms.DataGrid> control is not in the **Toolbox**. For information about adding it, see [How to: Add Items to the Toolbox](http://msdn.microsoft.com/library/458e119e-17fe-450b-b889-e31c128bd7e0).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To add a table to the DataGrid control in the designer  
  
1.  In order to display data in the table, you must first bind the <xref:System.Windows.Forms.DataGrid> control to a dataset. For more information, see [How to: Bind the Windows Forms DataGrid Control to a Data Source Using the Designer](../../../../docs/framework/winforms/controls/bind-wf-datagrid-control-to-a-data-source-using-the-designer.md).  
  
2.  Select the <xref:System.Windows.Forms.DataGrid> control's <xref:System.Windows.Forms.DataGrid.TableStyles%2A> property in the Properties window, and then click the ellipsis button (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) next to the property to display the **DataGridTableStyle Collection Editor**.  
  
3.  In the collection editor, click **Add** to insert a table style.  
  
4.  Click **OK** to close the collection editor, and then reopen it by clicking the ellipsis button next to the <xref:System.Windows.Forms.DataGrid.TableStyles%2A> property.  
  
     When you reopen the collection editor, any data tables bound to the control will appear in the drop-down list for the <xref:System.Windows.Forms.DataGridTableStyle.MappingName%2A> property of the table style.  
  
5.  In the **Members** box of the collection editor, click the table style.  
  
6.  In the **Properties** box of the collection editor, select the <xref:System.Windows.Forms.DataGridTableStyle.MappingName%2A> value for the table you want to display.  
  
### To add a column to the DataGrid control in the designer  
  
1.  In the **Members** box of the **DataGridTableStyle Collection Editor**, select the appropriate table style. In the **Properties** box of the collection editor, select the <xref:System.Windows.Forms.DataGridTableStyle.GridColumnStyles%2A> collection, and then click the ellipsis button (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) next to the property to display the **DataGridColumnStyle Collection Editor**.  
  
2.  In the collection editor, click **Add** to insert a column style or click the down arrow next to **Add** to specify a column type.  
  
     In the drop-down box, you can select either the <xref:System.Windows.Forms.DataGridTextBoxColumn> or <xref:System.Windows.Forms.DataGridBoolColumn> type.  
  
3.  Click OK to close the **DataGridColumnStyle Collection Editor**, and then reopen it by clicking the ellipsis button next to the <xref:System.Windows.Forms.DataGridTableStyle.GridColumnStyles%2A> property.  
  
     When you reopen the collection editor, any data columns in the bound data table will appear in the drop-down list for the <xref:System.Windows.Forms.DataGridColumnStyle.MappingName%2A> property of the column style.  
  
4.  In the **Members** box of the collection editor, click the column style.  
  
5.  In the **Properties** box of the collection editor, select the <xref:System.Windows.Forms.DataGridColumnStyle.MappingName%2A> value for the column you want to display.  
  
## See Also  
 [DataGrid Control](../../../../docs/framework/winforms/controls/datagrid-control-windows-forms.md)  
 [How to: Delete or Hide Columns in the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-delete-or-hide-columns-in-the-windows-forms-datagrid-control.md)
