---
title: "Data Formatting in the Windows Forms DataGridView Control"
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
  - "DataGridView control [Windows Forms], formatting data"
  - "data [Windows Forms], formatting in grids"
  - "data grids [Windows Forms], formatting data"
ms.assetid: 07bf558d-3748-42ba-8ba0-37fdef924081
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Data Formatting in the Windows Forms DataGridView Control
The <xref:System.Windows.Forms.DataGridView> control provides automatic conversion between cell values and the data types that the parent columns display. Text box columns, for example, display string representations of date, time, number, and enumeration values, and convert user-entered string values to the types required by the data store.  
  
## Formatting with the DataGridViewCellStyle class  
 The <xref:System.Windows.Forms.DataGridView> control provides basic data formatting of cell values through the <xref:System.Windows.Forms.DataGridViewCellStyle> class. You can use the <xref:System.Windows.Forms.DataGridViewCellStyle.Format%2A> property to format date, time, number, and enumeration values for the current default culture using the format specifiers described in [Formatting Types](../../../../docs/standard/base-types/formatting-types.md). You can also format these values for specific cultures using the <xref:System.Windows.Forms.DataGridViewCellStyle.FormatProvider%2A> property. The specified format is used both to display data and to parse data that the user enters in the specified format.  
  
 The <xref:System.Windows.Forms.DataGridViewCellStyle> class provides additional formatting properties for wordwrap, text alignment, and the custom display of null database values. For more information, see [How to: Format Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-format-data-in-the-windows-forms-datagridview-control.md).  
  
## Formatting with the CellFormatting Event  
 If the basic formatting does not meet your needs, you can provide custom data formatting in a handler for the <xref:System.Windows.Forms.DataGridView.CellFormatting?displayProperty=nameWithType> event. The <xref:System.Windows.Forms.DataGridViewCellFormattingEventArgs> passed to the handler has a <xref:System.Windows.Forms.ConvertEventArgs.Value%2A> property that initially contains the cell value. Normally, this value is automatically converted to the display type. To convert the value yourself, set the <xref:System.Windows.Forms.ConvertEventArgs.Value%2A> property to a value of the display type.  
  
> [!NOTE]
>  If a format string is in effect for the cell, it overrides your change of the <xref:System.Windows.Forms.ConvertEventArgs.Value%2A> property value unless you set the <xref:System.Windows.Forms.DataGridViewCellFormattingEventArgs.FormattingApplied%2A> property to `true`.  
  
 The <xref:System.Windows.Forms.DataGridView.CellFormatting> event is also useful when you want to set <xref:System.Windows.Forms.DataGridViewCellStyle> properties for individual cells based on their values. For more information, see [How to: Customize Data Formatting in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-customize-data-formatting-in-the-windows-forms-datagridview-control.md).  
  
 If the default parsing of user-specified values does not meet your needs, you can handle the <xref:System.Windows.Forms.DataGridView.CellParsing> event of the <xref:System.Windows.Forms.DataGridView> control to provide custom parsing.  
  
## See Also  
 <xref:System.Windows.Forms.DataGridView>  
 <xref:System.Windows.Forms.DataGridViewCellStyle>  
 [Displaying Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/displaying-data-in-the-windows-forms-datagridview-control.md)  
 [Cell Styles in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/cell-styles-in-the-windows-forms-datagridview-control.md)  
 [How to: Format Data in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-format-data-in-the-windows-forms-datagridview-control.md)  
 [How to: Customize Data Formatting in the Windows Forms DataGridView Control](../../../../docs/framework/winforms/controls/how-to-customize-data-formatting-in-the-windows-forms-datagridview-control.md)
