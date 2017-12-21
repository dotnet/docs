---
title: "TableLayoutPanel Control Overview"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "TableLayoutPanel"
helpviewer_keywords: 
  - "controls [Windows Forms], resizing"
  - "resizable controls [Windows Forms]"
  - "Windows Forms controls, proportional resizing"
  - "Windows Forms, proportional resizing of controls"
  - "layout [Windows Forms], TableLayoutPanel control"
  - "TableLayoutPanel control [Windows Forms], about TableLayoutPanel control"
ms.assetid: 337661c8-61cb-44ee-93e0-3662bddec327
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# TableLayoutPanel Control Overview
The <xref:System.Windows.Forms.TableLayoutPanel> control arranges its contents in a grid. Because the layout is performed both at design time and run time, it can change dynamically as the application environment changes. This gives the controls in the panel the ability to proportionally resize, so they can respond to changes such as the parent control resizing or text length changing due to localization.  
  
 Any Windows Forms control can be a child of the <xref:System.Windows.Forms.TableLayoutPanel> control, including other instances of <xref:System.Windows.Forms.TableLayoutPanel>. This allows you to construct sophisticated layouts that adapt to changes at run time.  
  
 The <xref:System.Windows.Forms.TableLayoutPanel> control can expand to accommodate new controls when they are added, depending on the value of the <xref:System.Windows.Forms.TableLayoutPanel.RowCount%2A>, <xref:System.Windows.Forms.TableLayoutPanel.ColumnCount%2A>, and <xref:System.Windows.Forms.TableLayoutPanel.GrowStyle%2A> properties. Setting either the <xref:System.Windows.Forms.TableLayoutPanel.RowCount%2A> or <xref:System.Windows.Forms.TableLayoutPanel.ColumnCount%2A> property to a value of 0 specifies that the <xref:System.Windows.Forms.TableLayoutPanel> will be unbound in the corresponding direction.  
  
 You can also control the direction of expansion (horizontal or vertical) after the <xref:System.Windows.Forms.TableLayoutPanel> control is full of child controls. By default, the <xref:System.Windows.Forms.TableLayoutPanel> control expands downward by adding rows.  
  
 If you want rows and columns that behave differently from the default behavior, you can control the properties of rows and columns by using the <xref:System.Windows.Forms.TableLayoutPanel.RowStyles%2A> and <xref:System.Windows.Forms.TableLayoutPanel.ColumnStyles%2A> properties. You can set the properties of rows or columns individually.  
  
 The <xref:System.Windows.Forms.TableLayoutPanel> control adds the following properties to its child controls: `Cell`, `Column`, `Row`, `ColumnSpan`, and `RowSpan`.  
  
 You can merge cells in the <xref:System.Windows.Forms.TableLayoutPanel> control by setting the `ColumnSpan` or `RowSpan` properties on a child control.  
  
1.  [How to: Align and Stretch a Control in a TableLayoutPanel Control](http://msdn.microsoft.com/library/ms171688\(v=vs.110\))  
  
2.  [How to: Span Rows and Columns in a TableLayoutPanel Control](http://msdn.microsoft.com/library/ms171687\(v=vs.110\))  
  
3.  [How to: Edit Columns and Rows in a TableLayoutPanel Control](http://msdn.microsoft.com/library/ms171686\(v=vs.110\))  
  
4.  [Walkthrough: Arranging Controls on Windows Forms Using a TableLayoutPanel](http://msdn.microsoft.com/library/w4yc3e8c\(v=vs.110\))  
  
## See Also  
 <xref:System.Windows.Forms.FlowLayoutPanel>  
 <xref:System.Windows.Forms.TableLayoutSettings>  
 [How to: Design a Windows Forms Layout that Responds Well to Localization](../../../../docs/framework/winforms/controls/how-to-design-a-windows-forms-layout-that-responds-well-to-localization.md)  
 [How to: Create a Resizable Windows Form for Data Entry](../../../../docs/framework/winforms/controls/how-to-create-a-resizable-windows-form-for-data-entry.md)  
 [Best Practices for the TableLayoutPanel Control](../../../../docs/framework/winforms/controls/best-practices-for-the-tablelayoutpanel-control.md)
