---
title: "How to: Disable Adding and Deleting DataRepeater Items (Visual Studio) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "DataRepeater, disabling delete"
  - "DataRepeater, disabling add"
ms.assetid: 298d8f60-ddfe-4361-ab66-cf76d0df5220
caps.latest.revision: 9
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# How to: Disable Adding and Deleting DataRepeater Items (Visual Studio)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

By default, users can add and delete items in a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control. Users can add a new item by pressing CTRL+N when a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs.DataRepeaterItem%2A> has focus or by clicking the **AddNewItem** button on the <xref:System.Windows.Forms.BindingNavigator> control. Users can delete an item by pressing DELETE when a <xref:Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs.DataRepeaterItem%2A> has focus or by clicking the **DeleteItem** button on the <xref:System.Windows.Forms.BindingNavigator> control.  
  
 You can disable adding and/or deleting at design time or at run time.  
  
### To disable adding and deleting at design time  
  
1.  In the Windows Forms Designer, select the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> control.  
  
    > [!NOTE]
    >  You must select the lower section of the control. If you select the item template section, a different set of properties will be displayed.  
  
2.  In the Properties window, set the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.AllowUserToAddItems%2A> property to **False**.  
  
3.  Set the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater.AllowUserToDeleteItems%2A> property to **False**.  
  
4.  In the Windows Forms Designer, select the <xref:System.Windows.Forms.BindingNavigator> control, and then click the **AddNewItem** button (the button with a plus sign on it).  
  
5.  In the Properties window, set the <xref:System.Windows.Forms.ToolBarButton.Enabled%2A> property to **False**.  
  
6.  In the Windows Forms Designer, select the <xref:System.Windows.Forms.BindingNavigator> control, and then click the **DeleteItem** button (the button with a red X on it).  
  
7.  In the Properties window, set the <xref:System.Windows.Forms.ToolBarButton.Enabled%2A> property to **False**.  
  
8.  In the Component Tray, select the <xref:System.Windows.Forms.BindingSource> to which the <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater> is bound.  
  
9. In the Properties window, set the <xref:System.Windows.Forms.BindingSource.AllowNew%2A> property to **False**.  
  
10. In the Windows Forms Designer, double-click the **DeleteItem** button to open the Code Editor.  
  
11. In the Events drop-down list, select the `BindingNavigatorDeleteItem_EnabledChanged` event.  
  
12. Add the following code to the `BindingNavigatorDeleteItem_EnabledChanged` event handler:  
  
     [!code-csharp[VbPowerPacksDataRepeaterDisableAddDelete#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbPowerPacksDataRepeaterDisableAddDelete/CS/DisableAddDelete.cs#1)]
     [!code-vb[VbPowerPacksDataRepeaterDisableAddDelete#1](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbPowerPacksDataRepeaterDisableAddDelete/vb/form1.vb#1)]  
  
    > [!NOTE]
    >  This step is necessary because the <xref:System.Windows.Forms.BindingSource> will enable the **DeleteItem** button every time that the current record changes.  
  
### To disable adding and deleting at run time  
  
1.  In the Windows Forms Designer, double-click the form to open the Code Editor.  
  
2.  Add the following code to the `Form_Load` event:  
  
     [!code-csharp[VbPowerPacksDataRepeaterDisableAddDelete#2](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbPowerPacksDataRepeaterDisableAddDelete/CS/DisableAddDelete.cs#2)]
     [!code-vb[VbPowerPacksDataRepeaterDisableAddDelete#2](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbPowerPacksDataRepeaterDisableAddDelete/vb/form1.vb#2)]  
  
3.  Add the following code to the `BindingNavigatorDeleteItem_EnabledChanged` event handler:  
  
     [!code-csharp[VbPowerPacksDataRepeaterDisableAddDelete#1](../../../samples/snippets/csharp/VS_Snippets_VBCSharp/VbPowerPacksDataRepeaterDisableAddDelete/CS/DisableAddDelete.cs#1)]
     [!code-vb[VbPowerPacksDataRepeaterDisableAddDelete#1](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbPowerPacksDataRepeaterDisableAddDelete/vb/form1.vb#1)]  
  
    > [!NOTE]
    >  This step is necessary because the <xref:System.Windows.Forms.BindingSource> will enable the **DeleteItem** button every time that the current record changes.  
  
## See Also  
 <xref:Microsoft.VisualBasic.PowerPacks.DataRepeater>   
 [Introduction to the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/introduction-to-the-datarepeater-control-visual-studio.md)   
 [Troubleshooting the DataRepeater Control](../../../visual-basic/developing-apps/windows-forms/troubleshooting-the-datarepeater-control-visual-studio.md)