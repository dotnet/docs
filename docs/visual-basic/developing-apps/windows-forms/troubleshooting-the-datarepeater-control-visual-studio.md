---
title: "Troubleshooting the DataRepeater Control (Visual Studio)"
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
  - "DataRepeater, troubleshooting"
ms.assetid: c0ab9469-eced-4f52-aa18-4bd8dd4f1a9a
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Troubleshooting the DataRepeater Control (Visual Studio)
This topic lists common issues that may occur when you are working with the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
## DataRepeater Keyboard and Mouse Events Are Not Raised  
 Some <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control events, such as keyboard and mouse events, are not raised. This is by design. The <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control itself is a container for <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem> objects and cannot be accessed at run time. The <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem> does not expose events at design time. Therefore, clicking an item or pressing a key when the item has focus does not raise an event.  
  
 The exception to this is when the <xref:System.Windows.Forms.Control.Padding%2A> property is set to a large enough value to expose the edges of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. In this case, clicking in the exposed margin will raise mouse events.  
  
 To resolve this issue, add a <xref:System.Windows.Forms.Panel> control to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemTemplate%2A> section of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control, and then add the rest of the controls to the <xref:System.Windows.Forms.Panel>. You can then add code to the <xref:System.Windows.Forms.Panel> control's event handlers for keyboard and mouse events.  
  
## The DataRepeater Is Partially Hidden Behind the Binding Navigator  
 When you first add a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control to a form and then add data-bound controls from the **Data Sources** window, the <xref:System.Windows.Forms.BindingNavigator> control may appear on top of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. This is a known limitation of the **Data Sources** window and is consistent with the behavior of other controls, such as the <xref:System.Windows.Forms.DataGridView> control.  
  
 You can either move the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> lower than the <xref:System.Windows.Forms.BindingNavigator> control at design time, or add code resembling the following in the `Load` event handler.  
  
```vb  
DataRepeater1.Top = ProductsBindingNavigator.Height  
```  
  
```csharp  
dataRepeater1.Top = productsBindingNavigator.Height;  
```  
  
## Controls Are Not Displayed Correctly at Run Time  
 Some controls in a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control may not be displayed as expected at run time. The process used to clone controls from the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemTemplate%2A> to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem> cannot always determine all the properties of all controls. For example, if you add an unbound <xref:System.Windows.Forms.ListBox> control to a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control at design time and populate its <xref:System.Windows.Forms.ListBox.Items%2A> collection with a list of strings, the <xref:System.Windows.Forms.ListBox> will be empty at run time. This is because the cloning process cannot take into account the <xref:System.Windows.Forms.ListBox.Items%2A> property.  
  
 You can fix problems such as this by restoring the missing properties in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemCloned> event, which occurs after the default cloning is completed. The following example demonstrates how to repair the <xref:System.Windows.Forms.ListBox.Items%2A> collection of a <xref:System.Windows.Forms.ListBox> control in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemCloned> event handler.  
  
 [!code-csharp[VbPowerPacksDataRepeaterItemCloned#1](../../../visual-basic/developing-apps/windows-forms/codesnippet/CSharp/troubleshooting-the-datarepeater-control-visual-studio_1.cs)]
 [!code-vb[VbPowerPacksDataRepeaterItemCloned#1](../../../visual-basic/developing-apps/windows-forms/codesnippet/VisualBasic/troubleshooting-the-datarepeater-control-visual-studio_1.vb)]  
  
## The Selection Symbol on the Item Header Is Missing  
 When you change the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.SelectionColor%2A> property of the item header in a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control, some color choices may cause the selection symbol to disappear. Changing the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemHeaderSize%2A> property may also cause the selection symbol to disappear.  
  
 The color and size of the selection symbol cannot be changed.  
  
-   If you set the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.SelectionColor%2A> to <xref:System.Drawing.Color.White%2A>, the selection symbol will not be visible when an item is first selected.  
  
-   If you set the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.SelectionColor%2A> to <xref:System.Drawing.Color.Black%2A>, the selection symbol will not be visible when a control is selected, and the pencil symbol will not be visible when a control is in edit mode.  
  
-   If the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.ItemHeaderSize%2A> property is set to a value that is less than 11, the indicator symbols in the item header will not be displayed.  
  
 You can provide your own item header and selection symbol by using a <xref:System.Windows.Forms.PictureBox> control and monitoring the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem.IsCurrent%2A> property of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem> in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.DrawItem> event of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. For more information, see <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItem.IsCurrent%2A>.  
  
## See Also  
 [Introduction to the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/introduction-to-the-datarepeater-control-visual-studio.md)  
 [How to: Display Bound Data in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-bound-data-in-a-datarepeater-control-visual-studio.md)  
 [How to: Display Unbound Controls in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-unbound-controls-in-a-datarepeater-control-visual-studio.md)  
 [How to: Change the Layout of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-layout-of-a-datarepeater-control-visual-studio.md)  
 [How to: Change the Appearance of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-appearance-of-a-datarepeater-control-visual-studio.md)  
 [How to: Display Item Headers in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-item-headers-in-a-datarepeater-control-visual-studio.md)  
 [How to: Disable Adding and Deleting DataRepeater Items](../../../visual-basic/developing-apps/windows-forms/how-to-disable-adding-and-deleting-datarepeater-items-visual-studio.md)  
 [How to: Search Data in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-search-data-in-a-datarepeater-control-visual-studio.md)  
 [How to: Create a Master/Detail Form by Using Two DataRepeater Controls (Visual Studio)](../../../visual-basic/developing-apps/windows-forms/how-to-create-a-master-detail-form-by-using-two-datarepeater-controls.md)
