---
title: "How to: Format the Windows Forms DataGrid Control Using the Designer"
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
  - "columns [Windows Forms], DataGrid controls"
  - "colors [Windows Forms], applying to DataGrid controls"
  - "DataGrid control [Windows Forms], formatting"
  - "DataGrid control [Windows Forms], default styles"
  - "tables [Windows Forms], formatting in DataGrid control"
  - "formatting [Windows Forms]"
ms.assetid: 533b9814-6124-49dc-9fda-085f1502609f
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Format the Windows Forms DataGrid Control Using the Designer
> [!NOTE]
>  The <xref:System.Windows.Forms.DataGridView> control replaces and adds functionality to the <xref:System.Windows.Forms.DataGrid> control; however, the <xref:System.Windows.Forms.DataGrid> control is retained for both backward compatibility and future use, if you choose. For more information, see [Differences Between the Windows Forms DataGridView and DataGrid Controls](../../../../docs/framework/winforms/controls/differences-between-the-windows-forms-datagridview-and-datagrid-controls.md).  
  
 Applying different colors to various parts of a <xref:System.Windows.Forms.DataGrid> control can help to make the information in it easier to read and interpret. Color can be applied to rows and columns. Rows and columns can also be hidden or shown at your discretion.  
  
 There are three basic aspects of formatting the <xref:System.Windows.Forms.DataGrid> control:  
  
-   You can set properties to establish a default style in which data is displayed.  
  
-   From that base, you can then customize the way certain tables are displayed at run time.  
  
-   Finally, you can modify which columns are displayed in the data grid as well as the colors and other formatting that is shown.  
  
 As an initial step in formatting a data grid, you can set the properties of the <xref:System.Windows.Forms.DataGrid> itself. These color and format choices form a base from which you can then make changes depending on the data tables and columns displayed.  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.DataGrid> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md). In [!INCLUDE[vsprvslong](../../../../includes/vsprvslong-md.md)], the <xref:System.Windows.Forms.DataGrid> control is not in the **Toolbox** by default. For more information, see [How to: Add Items to the Toolbox](http://msdn.microsoft.com/library/458e119e-17fe-450b-b889-e31c128bd7e0).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To establish a default style for the DataGrid control  
  
1.  Select the <xref:System.Windows.Forms.DataGrid> control.  
  
2.  In the **Properties** window, set the following properties, as appropriate.  
  
    |Property|Description|  
    |--------------|-----------------|  
    |<xref:System.Windows.Forms.DataGrid.AlternatingBackColor%2A>|The `BackColor` property defines the color of the even-numbered rows of the grid. When you set the <xref:System.Windows.Forms.DataGrid.AlternatingBackColor%2A> property to a different color, every other row is set to this new color (rows 1, 3, 5, and so on).|  
    |<xref:System.Windows.Forms.DataGrid.BackColor%2A>|The background color of the even-numbered rows of the grid (rows 0, 2, 4, 6, and so on).|  
    |<xref:System.Windows.Forms.DataGrid.BackgroundColor%2A>|Whereas the <xref:System.Windows.Forms.DataGrid.BackColor%2A> and <xref:System.Windows.Forms.DataGrid.AlternatingBackColor%2A> properties determines the color of rows in the grid, the <xref:System.Windows.Forms.DataGrid.BackgroundColor%2A> property determines the color of the area outside the row area, which is only visible when the grid is scrolled to the bottom, or if only a few rows are contained in the grid.|  
    |<xref:System.Windows.Forms.DataGrid.BorderStyle%2A>|The grid's border style, one of the <xref:System.Windows.Forms.BorderStyle> enumeration values.|  
    |<xref:System.Windows.Forms.DataGrid.CaptionBackColor%2A>|The background color of the grid's window caption which appears immediately above the grid.|  
    |<xref:System.Windows.Forms.DataGrid.CaptionFont%2A>|The font of the caption at the top of the grid.|  
    |<xref:System.Windows.Forms.DataGrid.CaptionForeColor%2A>|The background color of the grid's window caption.|  
    |<xref:System.Windows.Forms.Control.Font%2A>|The font used to display the text in the grid.|  
    |<xref:System.Windows.Forms.DataGrid.ForeColor%2A>|The color of the font displayed by the data in the rows of the data grid.|  
    |<xref:System.Windows.Forms.DataGrid.GridLineColor%2A>|The color of the grid lines of the data grid.|  
    |<xref:System.Windows.Forms.DataGrid.GridLineStyle%2A>|The style of the lines separating the cells of the grid, one of the <xref:System.Windows.Forms.DataGridLineStyle> enumeration values.|  
    |<xref:System.Windows.Forms.DataGrid.HeaderBackColor%2A>|The background color of row and column headers.|  
    |<xref:System.Windows.Forms.DataGrid.HeaderFont%2A>|The font used for the column headers.|  
    |<xref:System.Windows.Forms.DataGrid.HeaderForeColor%2A>|The foreground color of the grid's column headers, including the column header text and the plus sign (+) and minus sign (-) glyphs that expand and collapse rows when multiple related tables are displayed.|  
    |<xref:System.Windows.Forms.DataGrid.LinkColor%2A>|The color of text of all the links in the data grid, including links to child tables, the relation name, and so on.|  
    |<xref:System.Windows.Forms.DataGrid.ParentRowsBackColor%2A>|In a child table, this is the background color of the parent rows.|  
    |<xref:System.Windows.Forms.DataGrid.ParentRowsForeColor%2A>|In a child table, this is the foreground color of the parent rows.|  
    |<xref:System.Windows.Forms.DataGrid.ParentRowsLabelStyle%2A>|Determines whether the table and column names are displayed in the parent row, by means of the <xref:System.Windows.Forms.DataGridParentRowsLabelStyle> enumeration.|  
    |<xref:System.Windows.Forms.DataGrid.PreferredColumnWidth%2A>|The default width (in pixels) of columns in the grid. Set this property before resetting the <xref:System.Windows.Forms.DataGrid.DataSource%2A> and <xref:System.Windows.Forms.DataGrid.DataMember%2A> properties (either separately, or through the <xref:System.Windows.Forms.DataGrid.SetDataBinding%2A> method), or the property will have no effect.<br /><br /> The property cannot be set to a value less than 0.|  
    |<xref:System.Windows.Forms.DataGrid.PreferredRowHeight%2A>|The row height (in pixels) of rows in the grid. Set this property before resetting the <xref:System.Windows.Forms.DataGrid.DataSource%2A> and <xref:System.Windows.Forms.DataGrid.DataMember%2A> properties (either separately, or through the <xref:System.Windows.Forms.DataGrid.SetDataBinding%2A> method), or the property will have no effect.<br /><br /> The property cannot be set to a value less than 0.|  
    |<xref:System.Windows.Forms.DataGrid.RowHeaderWidth%2A>|The width of the row headers of the grid.|  
    |<xref:System.Windows.Forms.DataGrid.SelectionBackColor%2A>|When a row or cell is selected, this is the background color.|  
    |<xref:System.Windows.Forms.DataGrid.SelectionForeColor%2A>|When a row or cell is selected, this is the foreground color.|  
  
    > [!NOTE]
    >  When you are customizing the colors of controls, it is possible to make the control inaccessible due to poor color choice (for example, red and green). Use the colors available on the **System Colors** palette to avoid this issue.  
  
     The following procedure requires a <xref:System.Windows.Forms.DataGrid> control bound to a data table. For more information, see [How to: Bind the Windows Forms DataGrid Control to a Data Source](../../../../docs/framework/winforms/controls/how-to-bind-the-windows-forms-datagrid-control-to-a-data-source.md).  
  
### To set the table and column style of a data table at design time  
  
1.  Select the <xref:System.Windows.Forms.DataGrid> control on your form.  
  
2.  In the **Properties** window, select the <xref:System.Windows.Forms.DataGrid.TableStyles%2A> property and click the **Ellipsis** (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")) button.  
  
3.  In the **DataGridTableStyle Collection Editor** dialog box, click **Add** to add a table style to the collection.  
  
     With the **DataGridTableStyle Collection Editor**, you can add and remove table styles, set display and layout properties, and set the mapping name for the table styles.  
  
4.  Set the <xref:System.Windows.Forms.DataGridTableStyle.MappingName%2A> property to the mapping name for each table style.  
  
     The mapping name is used to specify which table style should be used with which table.  
  
5.  In the **DataGridTableStyle Collection Editor**, select the <xref:System.Windows.Forms.DataGridTableStyle.GridColumnStyles%2A> property and click the ellipsis button (![VisualStudioEllipsesButton screenshot](../../../../docs/framework/winforms/media/vbellipsesbutton.png "vbEllipsesButton")).  
  
6.  In the **DataGridColumnStyle Collection Editor** dialog box, add column styles to the table style you created.  
  
     With the **DataGridColumnStyle Collection Editor**, you can add and remove column styles, set display and layout properties, and set the mapping name and formatting strings for the data columns.  
  
    > [!NOTE]
    >  For more information about formatting strings, see [Formatting Types](../../../../docs/standard/base-types/formatting-types.md).  
  
## See Also  
 <xref:System.Windows.Forms.GridTableStylesCollection>  
 <xref:System.Windows.Forms.GridColumnStylesCollection>  
 <xref:System.Windows.Forms.DataGrid>  
 [How to: Delete or Hide Columns in the Windows Forms DataGrid Control](../../../../docs/framework/winforms/controls/how-to-delete-or-hide-columns-in-the-windows-forms-datagrid-control.md)  
 [DataGrid Control](../../../../docs/framework/winforms/controls/datagrid-control-windows-forms.md)
