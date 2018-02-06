---
title: "Virtual Mode in the DataRepeater Control (Visual Studio)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "virtual data binding [Visual Basic]"
  - "DataRepeater"
  - "DataRepeater, virtual mode"
ms.assetid: 5fb805dc-2d8b-4139-b1e3-86e4c2667221
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
---
# Virtual Mode in the DataRepeater Control (Visual Studio)
When you want to display large quantities of tabular data in a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control, you can improve performance by setting the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.VirtualMode%2A> property to `True` and explicitly managing the control's interaction with its data source. The <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control provides several events that you can handle to interact with your data source and display the data as needed at run time.  
  
## How Virtual Mode Works  
 The most common scenario for the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control is to bind the child controls of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemTemplate%2A> to a data source at design time and allow the <xref:System.Windows.Forms.BindingSource> to pass data back and forth as needed. When you use virtual mode, the controls are not bound to a data source, and data is passed back and forth to the underlying data source at run time.  
  
 When the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.VirtualMode%2A> property is set to `True`, you create the user interface by adding controls from the **Toolbox** instead of adding bound controls from the **Data Sources** window.  
  
 Events are raised on a control-by-control basis, and you must add code to handle the display of data. When a new <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem> is scrolled into view, the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemValueNeeded> event is raised one time for each control and you must supply the values for each control in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemValueNeeded> event handler.  
  
 If data in one of the controls is changed by the user, the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemValuePushed> event is raised and you must validate the data and save it to your data source.  
  
 If the user adds a new item, the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.NewItemNeeded> event is raised. Use this event's handler to create a new record in your data source. To prevent unintended changes, you must also monitor the <xref:System.Windows.Forms.Control.KeyDown> event for each control and call <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.CancelEdit%2A> if the user presses the ESC key.  
  
 If your data source changes, you can refresh the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control by calling the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.BeginResetItemTemplate%2A> and <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.EndResetItemTemplate%2A> methods. Both methods must be called in order.  
  
 Finally, you must implement event handlers for the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemsRemoved> event, which occurs when an item is deleted, and optionally for the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.UserDeletingItems> and <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.UserDeletedItems> events, which occur whenever a user deletes an item by pressing the DELETE key.  
  
## Implementing Virtual Mode  
 Following are the steps that are required to implement virtual mode.  
  
#### To implement virtual mode  
  
1.  Drag a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control from the **Visual Basic PowerPacks** tab in the **Toolbox** to a form or container control. Set the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.VirtualMode%2A> property to `True`.  
  
2.  Drag controls from the **Toolbox** onto the item template region (the upper region) of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. You will need one control for each field in your data source that you want to display.  
  
3.  Implement a handler for the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemValueNeeded> event to provide values for each control. This event is raised when a new <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem> is scrolled into view. The code will resemble the following example, which is for a data source named `Employees`.  
  
     [!code-vb[VbPowerPacksDataRepeaterVirtualMode#1](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/virtual-mode-in-the-datarepeater-control-visual-studio_1.vb)]
     [!code-csharp[VbPowerPacksDataRepeaterVirtualMode#1](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/virtual-mode-in-the-datarepeater-control-visual-studio_1.cs)]  
  
4.  Implement a handler for the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemValuePushed> event to store the data. This event is raised when the user commits changes to a child control of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem>. The code will resemble the following example, which is for a data source named `Employees`.  
  
     [!code-vb[VbPowerPacksDataRepeaterVirtualMode#2](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/virtual-mode-in-the-datarepeater-control-visual-studio_2.vb)]
     [!code-csharp[VbPowerPacksDataRepeaterVirtualMode#2](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/virtual-mode-in-the-datarepeater-control-visual-studio_2.cs)]  
  
5.  Implement a handler for each child control's <xref:System.Windows.Forms.Control.KeyDown> event and monitor the ESC key. Call the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.CancelEdit%2A> method to prevent the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemValuePushed> event from being raised. The code will resemble the following example.  
  
     [!code-vb[VbPowerPacksDataRepeaterVirtualMode#3](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/virtual-mode-in-the-datarepeater-control-visual-studio_3.vb)]
     [!code-csharp[VbPowerPacksDataRepeaterVirtualMode#3](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/virtual-mode-in-the-datarepeater-control-visual-studio_3.cs)]  
  
6.  Implement a handler for the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.NewItemNeeded> event. This event is raised when the user adds a new item to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. The code will resemble the following example, which is for a data source named `Employees`.  
  
     [!code-vb[VbPowerPacksDataRepeaterVirtualMode#4](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/virtual-mode-in-the-datarepeater-control-visual-studio_4.vb)]
     [!code-csharp[VbPowerPacksDataRepeaterVirtualMode#4](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/virtual-mode-in-the-datarepeater-control-visual-studio_4.cs)]  
  
7.  Implement a handler for the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemsRemoved> event. This event occurs when a user deletes an existing item. The code will resemble the following example, which is for a data source named `Employees`.  
  
     [!code-vb[VbPowerPacksDataRepeaterVirtualMode#5](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/virtual-mode-in-the-datarepeater-control-visual-studio_5.vb)]
     [!code-csharp[VbPowerPacksDataRepeaterVirtualMode#5](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/virtual-mode-in-the-datarepeater-control-visual-studio_5.cs)]  
  
8.  For control-level validation, optionally implement handlers for the <xref:System.Windows.Forms.Control.Validating> events of the child controls. The code will resemble the following example.  
  
     [!code-vb[VbPowerPacksDataRepeaterVirtualMode#6](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/virtual-mode-in-the-datarepeater-control-visual-studio_6.vb)]
     [!code-csharp[VbPowerPacksDataRepeaterVirtualMode#6](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/virtual-mode-in-the-datarepeater-control-visual-studio_6.cs)]  
  
## See Also  
 <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemValuePushed>  
 <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.NewItemNeeded>  
 <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemValueNeeded>  
 [Introduction to the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/introduction-to-the-datarepeater-control-visual-studio.md)
