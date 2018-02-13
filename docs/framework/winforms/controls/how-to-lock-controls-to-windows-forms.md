---
title: "How to: Lock Controls to Windows Forms"
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
  - "Windows Forms controls, locking"
  - "controls [Windows Forms], locking"
ms.assetid: 94efe0d2-c14e-4d14-b903-63ea9b07e290
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Lock Controls to Windows Forms
When you design the user interface (UI) of your Windows application, you can lock the controls once they are positioned correctly, so that you do not inadvertently move or resize them when setting other properties.  
  
 Additionally, you can lock and unlock all the controls on the form at once, which is helpful for forms with many controls, or you can unlock individual controls. Once you have placed all the controls where you want them on the form, lock them all in place to prevent erroneous movement.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To lock a control  
  
1.  In the **Properties** window, click the **Locked** property and select `true`. (Double-clicking the name toggles the property setting.)  
  
     Alternatively, right-click the control and choose **Lock Controls**.  
  
    > [!NOTE]
    >  Locking controls prevents them from being dragged to a new size or location on the design surface. However, you can still change the size or location of controls by means of the **Properties** window or in code.  
  
### To lock all the controls on a form  
  
1.  From the **Format** menu, choose **Lock Controls**.  
  
    > [!NOTE]
    >  This command locks the form's size as well, because a form is a control.  
  
### To unlock all locked controls on a form  
  
1.  From the **Format** menu, choose **Lock Controls**.  
  
     All previously locked controls on the form are now unlocked.  
  
### To unlock locked controls individually  
  
1.  In the **Properties** window, click the **Locked** property and select `false`. (Double-clicking the name toggles the property setting.)  
  
## See Also  
 [Windows Forms Controls](../../../../docs/framework/winforms/controls/index.md)  
 [Arranging Controls on Windows Forms](../../../../docs/framework/winforms/controls/arranging-controls-on-windows-forms.md)  
 [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](../../../../docs/framework/winforms/controls/labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)  
 [Windows Forms Controls by Function](../../../../docs/framework/winforms/controls/windows-forms-controls-by-function.md)
