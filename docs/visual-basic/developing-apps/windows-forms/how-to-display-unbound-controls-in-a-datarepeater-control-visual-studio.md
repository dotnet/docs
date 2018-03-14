---
title: "How to: Display Unbound Controls in a DataRepeater Control (Visual Studio)"
ms.date: 07/20/2015
ms.prod: .net
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "DataRepeater, adding unbound controls"
  - "DataRepeater"
  - "displaying unbound data"
ms.assetid: f234fa40-5a13-4209-930e-7c5f81e86e66
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Display Unbound Controls in a DataRepeater Control (Visual Studio)
In addition to bound controls, you may want to add other controls to a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater>, such as a static label or an image that is repeated on each item in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
> [!NOTE]
>  You must also have at least one bound control on the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> or nothing will be displayed at run time.  
  
### To add unbound controls to a DataRepeater  
  
1.  Drag a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control from the **Visual Basic PowerPacks** tab in the **Toolbox** to a form or container control.  
  
2.  Drag the sizing and position handles to size and position the control.  
  
     You can also size and position the control by changing the **Size** and **Position** properties in the Properties window.  
  
3.  Add at least one data-bound control to the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. For more information, see [How to: Display Bound Data in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-bound-data-in-a-datarepeater-control-visual-studio.md).  
  
4.  Drag a control from the **Toolbox** onto the item template region of the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
     Note that the control has two rectangular regions. The inner region is the *item template*; controls added to the template will be repeated in each item in the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control at run time. The outer region is the *viewport*, where the items will be displayed; controls that are added to this region will not be displayed at run time.  
  
## See Also  
 <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater>  
 [Introduction to the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/introduction-to-the-datarepeater-control-visual-studio.md)  
 [Troubleshooting the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/troubleshooting-the-datarepeater-control-visual-studio.md)  
 [How to: Display Bound Data in a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-display-bound-data-in-a-datarepeater-control-visual-studio.md)  
 [How to: Create a Master/Detail Form by Using Two DataRepeater Controls (Visual Studio)](../../../visual-basic/developing-apps/windows-forms/how-to-create-a-master-detail-form-by-using-two-datarepeater-controls.md)  
 [How to: Change the Appearance of a DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/how-to-change-the-appearance-of-a-datarepeater-control-visual-studio.md)
