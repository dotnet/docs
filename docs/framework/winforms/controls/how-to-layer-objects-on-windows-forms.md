---
title: "How to: Layer Objects on Windows Forms"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-winforms"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "Windows Forms controls, layering"
  - "controls [Windows Forms], layering"
  - "z order"
  - "controls [Windows Forms], positioning"
  - "z-order"
ms.assetid: 1acc4281-2976-4715-86f4-bda68134baaf
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Layer Objects on Windows Forms
When you create a complex user interface, or work with a multiple document interface (MDI) form, you will often want to layer both controls and child forms to create more complex user interfaces (UI). To move and keep track of controls and windows within the context of a group, you manipulate their z-order. *Z-order* is the visual layering of controls on a form along the form's z-axis (depth). The window at the top of the z-order overlaps all other windows. All other windows overlap the window at the bottom of the z-order.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To layer controls at design time  
  
1.  Select a control that you want to layer.  
  
2.  On the **Format** menu, point to **Order**, and then click **Bring To Front** or **Send To Back**.  
  
### To layer controls programmatically  
  
-   Use the <xref:System.Windows.Forms.Control.BringToFront%2A> and <xref:System.Windows.Forms.Control.SendToBack%2A> methods to manipulate the z-order of the controls.  
  
     For example, if a <xref:System.Windows.Forms.TextBox> control, `txtFirstName`, is underneath another control and you want to have it on top, use the following code:  
  
    ```vb  
    txtFirstName.BringToFront()  
    ```  
  
    ```csharp  
    txtFirstName.BringToFront();  
    ```  
  
    ```cpp  
    txtFirstName->BringToFront();  
    ```  
  
> [!NOTE]
>  Windows Forms supports *control containment*. Control containment involves placing a number of controls within a containing control, such as a number of <xref:System.Windows.Forms.RadioButton> controls within a <xref:System.Windows.Forms.GroupBox> control. You can then layer the controls within the containing control. Moving the group box moves the controls as well, because they are contained inside it.  
  
## See Also  
 [Windows Forms Controls](../../../../docs/framework/winforms/controls/index.md)  
 [Arranging Controls on Windows Forms](../../../../docs/framework/winforms/controls/arranging-controls-on-windows-forms.md)  
 [Labeling Individual Windows Forms Controls and Providing Shortcuts to Them](../../../../docs/framework/winforms/controls/labeling-individual-windows-forms-controls-and-providing-shortcuts-to-them.md)  
 [Controls to Use on Windows Forms](../../../../docs/framework/winforms/controls/controls-to-use-on-windows-forms.md)  
 [Windows Forms Controls by Function](../../../../docs/framework/winforms/controls/windows-forms-controls-by-function.md)
