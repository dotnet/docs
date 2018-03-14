---
title: "DataGrid Styles and Templates"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "states [WPF], DataGrid"
  - "ControlTemplate [WPF], DataGrid"
  - "DataGrid [WPF], styles and templates"
  - "templates [WPF], DataGrid"
  - "styles [WPF], DataGrid"
  - "parts [WPF], DataGrid"
ms.assetid: 9cb31d63-f148-4d25-b079-816e73f988c7
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DataGrid Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.DataGrid> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](../../../../docs/framework/wpf/controls/customizing-the-appearance-of-an-existing-control.md).  
  
## DataGrid Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.DataGrid> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_ColumnHeadersPresenter|<xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter>|The row that contains the column headers.|  
  
 When you create a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.DataGrid>, your template might contain an <xref:System.Windows.Controls.ItemsPresenter> within a <xref:System.Windows.Controls.ScrollViewer>. (The <xref:System.Windows.Controls.ItemsPresenter> displays each item in the <xref:System.Windows.Controls.DataGrid>; the <xref:System.Windows.Controls.ScrollViewer> enables scrolling within the control).  If the <xref:System.Windows.Controls.ItemsPresenter> is not the direct child of the <xref:System.Windows.Controls.ScrollViewer>, you must give the <xref:System.Windows.Controls.ItemsPresenter> the name, `ItemsPresenter`.  
  
 The default template for the <xref:System.Windows.Controls.DataGrid> contains a <xref:System.Windows.Controls.ScrollViewer> control. For more information about the parts defined by the <xref:System.Windows.Controls.ScrollViewer>, see [ScrollViewer Styles and Templates](../../../../docs/framework/wpf/controls/scrollviewer-styles-and-templates.md).  
  
## DataGrid States  
 The following table lists the visual states for the <xref:System.Windows.Controls.DataGrid> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|Disabled|CommonStates|The control is disabled.|  
|InvalidFocused|ValidationStates|The control is not valid and has focus.|  
|InvalidUnfocused|ValidationStates|The control is not valid and does not have focus.|  
|Valid|ValidationStates|The control is valid.|  
  
## DataGridCell Parts  
 The <xref:System.Windows.Controls.DataGridCell> element does not have any named parts.  
  
## DataGridCell States  
 The following table lists the visual states for the <xref:System.Windows.Controls.DataGridCell> element.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the cell.|  
|Focused|FocusStates|The cell has focus.|  
|Unfocused|FocusStates|The cell does not have focus|  
|Current|CurrentStates|The cell is the current cell.|  
|Regular|CurrentStates|The cell is not the current cell.|  
|Display|InteractionStates|The cell is in display mode.|  
|Editing|InteractionStates|The cell is in edit mode.|  
|Selected|SelectionStates|The cell is selected.|  
|Unselected|SelectionStates|The cell is not selected.|  
|InvalidFocused|ValidationStates|The cell is not valid and has focus.|  
|InvalidUnfocused|ValidationStates|The cell is not valid and does not have focus.|  
|Valid|ValidationStates|The cell is valid.|  
  
## DataGridRow Parts  
 The <xref:System.Windows.Controls.DataGridRow> element does not have any named parts.  
  
## DataGridRow States  
 The following table lists the visual states for the <xref:System.Windows.Controls.DataGridRow> element.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the row.|  
|MouseOver_Editing|CommonStates|The mouse pointer is positioned over the row and the row is in edit mode.|  
|MouseOver_Selected|CommonStates|The mouse pointer is positioned over the row and the row is selected.|  
|MouseOver_Unfocused_Editing|CommonStates|The mouse pointer is positioned over the row, the row is in edit mode, and does not have focus.|  
|MouseOver_Unfocused_Selected|CommonStates|The mouse pointer is positioned over the row, the row is selected, and does not have focus.|  
|Normal_AlternatingRow|CommonStates|The row is an alternating row.|  
|Normal_Editing|CommonStates|The row is in edit mode.|  
|Normal_Selected|CommonStates|The row is selected.|  
|Unfocused_Editing|CommonStates|The row is in edit mode and does not have focus.|  
|Unfocused_Selected|CommonStates|The row is selected and does not have focus.|  
|InvalidFocused|ValidationStates|The control is not valid and has focus.|  
|InvalidUnfocused|ValidationStates|The control is not valid and does not have focus.|  
|Valid|ValidationStates|The control is valid.|  
  
## DataGridRowHeader Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DataGridRowHeader> element.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_TopHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the row header from the top.|  
|PART_BottomHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the row header from the bottom.|  
  
## DataGridRowHeader States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DataGridRowHeader> element.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the row.|  
|MouseOver_CurrentRow|CommonStates|The mouse pointer is positioned over the row and the row is the current row.|  
|MouseOver_CurrentRow_Selected|CommonStates|The mouse pointer is positioned over the row, and the row is current and selected.|  
|MouseOver_EditingRow|CommonStates|The mouse pointer is positioned over the row and the row is in edit mode.|  
|MouseOver_Selected|CommonStates|The mouse pointer is positioned over the row and the row is selected.|  
|MouseOver_Unfocused_CurrentRow_Selected|CommonStates|The mouse pointer is positioned over the row, the row is current and selected, and does not have focus.|  
|MouseOver_Unfocused_EditingRow|CommonStates|The mouse pointer is positioned over the row, the row is in edit mode, and does not have focus.|  
|MouseOver_Unfocused_Selected|CommonStates|The mouse pointer is positioned over the row, the row is selected, and does not have focus.|  
|Normal_CurrentRow|CommonStates|The row is the current row.|  
|Normal_CurrentRow_Selected|CommonStates|The row is the current row and is selected.|  
|Normal_EditingRow|CommonStates|The row is in edit mode.|  
|Normal_Selected|CommonStates|The row is selected.|  
|Unfocused_CurrentRow_Selected|CommonStates|The row is the current row, is selected, and does not have focus.|  
|Unfocused_EditingRow|CommonStates|The row is in edit mode and does not have focus.|  
|Unfocused_Selected|CommonStates|The row is selected and does not have focus.|  
|InvalidFocused|ValidationStates|The control is not valid and has focus.|  
|InvalidUnfocused|ValidationStates|The control is not valid and does not have focus.|  
|Valid|ValidationStates|The control is valid.|  
  
## DataGridColumnHeadersPresenter Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter> element.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_FillerColumnHeader|<xref:System.Windows.Controls.Primitives.DataGridColumnHeader>|The placeholder for column headers.|  
  
## DataGridColumnHeadersPresenter States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeadersPresenter> element.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|InvalidFocused|ValidationStates|The cell is not valid and has focus.|  
|InvalidUnfocused|ValidationStates|The cell is not valid and does not have focus.|  
|Valid|ValidationStates|The cell is valid.|  
  
## DataGridColumnHeader Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeader> element.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_LeftHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the column header from the left.|  
|PART_RightHeaderGripper|<xref:System.Windows.Controls.Primitives.Thumb>|The element that is used to resize the column header from the right.|  
  
## DataGridColumnHeader States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DataGridColumnHeader> element.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|  
|Pressed|CommonStates|The control is pressed.|  
|SortAscending|SortStates|The column is sorted in ascending order.|  
|SortDescending|SortStates|The column is sorted in descending order.|  
|Unsorted|SortStates|The column is not sorted.|  
|InvalidFocused|ValidationStates|The control is not valid and has focus.|  
|InvalidUnfocused|ValidationStates|The control is not valid and does not have focus.|  
|Valid|ValidationStates|The control is valid.|  
  
## DataGrid ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.DataGrid> control and its associated types.  
  
 [!code-xaml[ControlTemplateExamples#DataGrid](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/datagrid.xaml#datagrid)]  
  
 The preceding example uses one or more of the following resources.  
  
 [!code-xaml[ControlTemplateExamples#Resources](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]  
  
 For the complete sample, see [Styling with ControlTemplates Sample](http://go.microsoft.com/fwlink/?LinkID=160041).  
  
## See Also  
 <xref:System.Windows.FrameworkElement.Style%2A>  
 <xref:System.Windows.Controls.ControlTemplate>  
 [Control Styles and Templates](../../../../docs/framework/wpf/controls/control-styles-and-templates.md)  
 [Control Customization](../../../../docs/framework/wpf/controls/control-customization.md)  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](../../../../docs/framework/wpf/controls/customizing-the-appearance-of-an-existing-control.md)
