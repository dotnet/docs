---
title: "How to: Enable Tile View in a Windows Forms ListView Control Using the Designer"
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
  - "tile view feature"
  - "ListView control [Windows Forms], tile view"
  - "tiling [Windows Forms], Windows Forms, controls"
ms.assetid: 12f0816a-52b8-41ee-a6d9-ded3a8a5817a
caps.latest.revision: 6
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Enable Tile View in a Windows Forms ListView Control Using the Designer
The tile view feature of the <xref:System.Windows.Forms.ListView> control enables you to provide a visual balance between graphical and textual information. The textual information displayed for an item in tile view is the same as the column information defined for details view. Tile view functions in combination with either the grouping or insertion mark features in the <xref:System.Windows.Forms.ListView> control.  
  
 The tile view uses a 32 x 32 icon and several lines of text, as shown in the following image.  
  
 ![Tile View in a ListView Control](../../../../docs/framework/winforms/controls/media/listviewtile.gif "ListViewTile")  
  
 Tile view properties and methods enable you to specify which column fields to display for each item, and to collectively control the size and appearance of all items within a tile view window. For clarity, the first line of text in a tile is always the item's name; it cannot be changed.  
  
 The following procedure requires a **Windows Application** project with a form containing a <xref:System.Windows.Forms.ListView> control. For information about setting up such a project, see [How to: Create a Windows Application Project](http://msdn.microsoft.com/library/b2f93fed-c635-4705-8d0e-cf079a264efa) and [How to: Add Controls to Windows Forms](../../../../docs/framework/winforms/controls/how-to-add-controls-to-windows-forms.md).  
  
> [!NOTE]
>  The tile view is available only on [!INCLUDE[WinXpFamily](../../../../includes/winxpfamily-md.md)] when your application calls the <xref:System.Windows.Forms.Application.EnableVisualStyles%2A?displayProperty=nameWithType> method. On earlier operating systems, any code related to the tile view has no effect, and the <xref:System.Windows.Forms.ListView> control displays in the large icon view. For more information, see <xref:System.Windows.Forms.ListView.View%2A?displayProperty=nameWithType>.  
>   
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To set tile view in the designer  
  
1.  Select the <xref:System.Windows.Forms.ListView> control on your form.  
  
2.  In the **Properties** window, select the <xref:System.Windows.Forms.ListView.View%2A> property and choose **Tile**.  
  
## See Also  
 <xref:System.Windows.Forms.ListView.TileSize%2A>  
 [Windows XP Features and Windows Forms Controls](http://msdn.microsoft.com/library/bc7fab94-fce9-4bf1-a8ad-a5837c91c3c0)  
 [ListView Control Overview](../../../../docs/framework/winforms/controls/listview-control-overview-windows-forms.md)
