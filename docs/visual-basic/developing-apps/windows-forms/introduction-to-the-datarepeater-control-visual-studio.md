---
title: "Introduction to the DataRepeater Control (Visual Studio)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "repeating data"
  - "DataRepeater, overview"
  - "DataRepeater"
ms.assetid: 78a52a1d-65f0-4ecb-97ff-53bc114300c5
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# Introduction to the DataRepeater Control (Visual Studio)
The Visual Basic Power Packs <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control is a scrollable container for controls that display repeated data, for example, rows in a database table. It can be used as an alternative to the <xref:System.Windows.Forms.DataGridView> control when you need more control over the layout of the data. The <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> "repeats" a group of related controls by creating multiple instances in a scrolling view. This enables users to view several records at the same time.  
  
## Overview  
 At design time, the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control consists of two sections. The outer section is the *viewport*, where the scrolling data will be displayed at run time. The inner (top) section, known as the *item template*, is where you position controls that will be repeated at run time, typically one control for each field in the data source. The properties and controls in the item template are encapsulated in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemTemplate%2A> property.  
  
 At run time, the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemTemplate%2A> is copied to a virtual <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem> object that is used to display the data when each record is scrolled into view. You can customize the display of individual records in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.DrawItem> event, for example, highlighting a field based on the value that it contains. For more information, see [How to: Change the Appearance of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-appearance-of-a-datarepeater-control-visual-studio.md).  
  
 The most common use for a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control is to display data from a database table or other bound data source. In addition to [!INCLUDE[vstecado](~/includes/vstecado-md.md)] data objects, the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control can bind to any class that implements the <xref:System.Collections.IList> interface (including arrays), any class that implements the <xref:System.ComponentModel.IListSource> interface, any class that implements the <xref:System.ComponentModel.IBindingList> interface, or any class that implements the <xref:System.ComponentModel.IBindingListView> interface.  
  
### Data Binding  
 Typically, you accomplish data binding by dragging fields from the **Data Sources** window onto the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. For more information, see [How to: Display Bound Data in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-bound-data-in-a-datarepeater-control-visual-studio.md).  
  
 When working with large amounts of data, you can set the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.VirtualMode%2A> property to `True` to display a subset of the available data. Virtual mode requires the implementation of a data cache from which the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> is populated, and you must control all interactions with the data cache at run time. For more information, see [Virtual Mode in the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/virtual-mode-in-the-datarepeater-control-visual-studio.md).  
  
 You can also display unbound controls on a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. For example, you can display an image that is repeated on each item. For more information, see [How to: Display Unbound Controls in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-unbound-controls-in-a-datarepeater-control-visual-studio.md).  
  
### Events  
 The most important events for the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control are the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.DrawItem> event, which is raised when new items are scrolled into view, and the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.CurrentItemIndexChanged> event, which is raised when an item is selected. You can use the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.DrawItem> event to change the appearance of the item. For example, you can highlight negative values. Use the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.CurrentItemIndexChanged> event to access the values of controls when an item is selected.  
  
 The <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control exposes all the standard control events in the Code Editor. However, some of the events should not be used. Keyboard and mouse events such as `KeyDown`, `Click`, and `MouseDown` will not be raised at run time because the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control itself never has focus.  
  
 The <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem> does not expose events at design time because it is created only at run time. If you want to handle keyboard and mouse events, you can add a <xref:System.Windows.Forms.Panel> control to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemTemplate%2A> at design time and then handle the events for the <xref:System.Windows.Forms.Panel>. For more information, see [Troubleshooting the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/troubleshooting-the-datarepeater-control-visual-studio.md).  
  
### Customizations  
 There are many ways to customize the appearance and behavior of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control, both at run time and at design time. Properties can be set to change colors, hide or modify the item headers, change the orientation from vertical to horizontal, and much more. For more information, see [How to: Change the Appearance of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-appearance-of-a-datarepeater-control-visual-studio.md), [How to: Display Item Headers in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-item-headers-in-a-datarepeater-control-visual-studio.md), and [How to: Change the Layout of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-layout-of-a-datarepeater-control-visual-studio.md).  
  
 Note that some properties apply to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control itself whereas others apply only to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemTemplate%2A>. Make sure that you have the correct section of the control selected before you set properties. For more information, see [How to: Change the Appearance of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-appearance-of-a-datarepeater-control-visual-studio.md).  
  
 Other customizations include controlling the ability to add or delete records, adding search capabilities, and displaying related data in a master and detail format. For more information, see [How to: Disable Adding and Deleting DataRepeater Items](../../../visual-basic/developing-apps/windows-forms/how-to-disable-adding-and-deleting-datarepeater-items-visual-studio.md), [How to: Search Data in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-search-data-in-a-datarepeater-control-visual-studio.md), and [How to: Create a Master/Detail Form by Using Two DataRepeater Controls (Visual Studio)](../../../visual-basic/developing-apps/windows-forms/how-to-create-a-master-detail-form-by-using-two-datarepeater-controls.md).  
  
## See Also  
 [DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/datarepeater-control-visual-studio.md)  
 [Walkthrough: Displaying Data in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/walkthrough-displaying-data-in-a-datarepeater-control-visual-studio.md)  
 [Troubleshooting the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/troubleshooting-the-datarepeater-control-visual-studio.md)
