---
title: "How to: Display Bound Data in a DataRepeater Control (Visual Studio)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "DataRepeater, data-binding"
  - "DataRepeater, displaying bound controls"
ms.assetid: 56a15326-1334-4275-af4e-075cad79e6f7
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Display Bound Data in a DataRepeater Control (Visual Studio)
The most common use of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control is to display bound data from a database or other data source.  
  
 In addition to bound controls, you may want to add other controls, such as a static label or an image that is repeated on each item in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. For more information, see [How to: Display Unbound Controls in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-unbound-controls-in-a-datarepeater-control-visual-studio.md).  
  
 You can also bind to a data source at run time by setting the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.VirtualMode%2A> property to `True` and assigning a data source to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.DataSource%2A> property. In this case, you will need to manage all interaction with the data source. For more information, see [Virtual Mode in the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/virtual-mode-in-the-datarepeater-control-visual-studio.md).  
  
[!INCLUDE[note_settings_general](~/includes/note-settings-general-md.md)]  
  
### To create a data-bound DataRepeater  
  
1.  Drag a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control from the **Visual Basic PowerPacks** tab in the **Toolbox** to a form or container control.  
  
2.  Drag the sizing and position handles to size and position the control.  
  
     Note that the control has two rectangular regions. The upper region is the *item template*; controls added to the template will be repeated in each item in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control at run time. The lower region is the *viewport*, where the items will be displayed.  
  
     You can also size and position the control or the item template by changing the **Size** and **Position** properties in the Properties window.  
  
3.  On the **Data** menu, click **Show Data Sources**.  
  
    > [!NOTE]
    >  If the **Data Sources** window is empty, add a data source to it. For more information, see [Add new data sources](/visualstudio/data-tools/add-new-data-sources).  
  
4.  In the **Data Sources** window, select the top-level node for the table that contains the data that you want to bind.  
  
5.  Change the drop type of the table to `Details` by clicking `Details` in the drop-down list on the table node.  
  
6.  Select the table node and drag it onto the item template region of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
     You can specify which types of controls are displayed for each field. For more information, see [Set the control to be created when dragging from the Data Sources window](/visualstudio/data-tools/set-the-control-to-be-created-when-dragging-from-the-data-sources-window).  
  
## See Also  
 <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater>  
 [Introduction to the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/introduction-to-the-datarepeater-control-visual-studio.md)  
 [How to: Display Unbound Controls in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-unbound-controls-in-a-datarepeater-control-visual-studio.md)  
 [How to: Create a Master/Detail Form by Using Two DataRepeater Controls (Visual Studio)](../../../visual-basic/developing-apps/windows-forms/how-to-create-a-master-detail-form-by-using-two-datarepeater-controls.md)  
 [How to: Change the Appearance of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-appearance-of-a-datarepeater-control-visual-studio.md)  
 [Troubleshooting the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/troubleshooting-the-datarepeater-control-visual-studio.md)
