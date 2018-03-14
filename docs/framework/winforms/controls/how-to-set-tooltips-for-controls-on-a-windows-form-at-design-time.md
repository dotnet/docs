---
title: "How to: Set ToolTips for Controls on a Windows Form at Design Time"
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
  - "tooltips [Windows Forms], for controls"
  - "examples [Windows Forms], tooltips"
ms.assetid: c4b60637-4c0a-44c2-a103-f66dff887936
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Set ToolTips for Controls on a Windows Form at Design Time
You can set a <xref:System.Windows.Forms.ToolTip> string in code or in the Windows Forms Designer. For more information about the <xref:System.Windows.Forms.ToolTip> component, see [ToolTip Component Overview](../../../../docs/framework/winforms/controls/tooltip-component-overview-windows-forms.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To set a ToolTip programmatically  
  
1.  Add the control that will display the ToolTip.  
  
2.  Use the <xref:System.Windows.Forms.ToolTip.SetToolTip%2A> method of the <xref:System.Windows.Forms.ToolTip> component.  
  
    ```vb  
    ' In this example, Button1 is the control to display the ToolTip.  
    ToolTip1.SetToolTip(Button1, "Save changes")  
    ```  
  
    ```csharp  
    // In this example, button1 is the control to display the ToolTip.  
    toolTip1.SetToolTip(button1, "Save changes");  
    ```  
  
    ```cpp  
    // In this example, button1 is the control to display the ToolTip.  
    toolTip1->SetToolTip(button1, "Save changes");  
    ```  
  
### To set a ToolTip in the designer  
  
1.  Add a <xref:System.Windows.Forms.ToolTip> component to the form.  
  
2.  Select the control that will display the ToolTip, or add it to the form.  
  
3.  In the **Properties** window, set the **ToolTip on ToolTip1** value to an appropriate string of text.  
  
## See Also  
 [ToolTip Component Overview](../../../../docs/framework/winforms/controls/tooltip-component-overview-windows-forms.md)  
 [How to: Change the Delay of the Windows Forms ToolTip Component](../../../../docs/framework/winforms/controls/how-to-change-the-delay-of-the-windows-forms-tooltip-component.md)  
 [ToolTip Component](../../../../docs/framework/winforms/controls/tooltip-component-windows-forms.md)
