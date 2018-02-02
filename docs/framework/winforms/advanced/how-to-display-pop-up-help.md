---
title: "How to: Display Pop-up Help"
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
  - "pop-up Help"
  - "Help [Windows Forms], pop-up Help"
  - "Windows Forms, displaying Help"
  - "forms [Windows Forms], displaying Help"
  - "modal dialog boxes [Windows Forms], pop-up Help"
  - "F1 Help [Windows Forms], in dialog boxes"
  - "HelpProvider component [Windows Forms]"
  - "Help [Windows Forms], adding to dialog boxes"
ms.assetid: 218aa81e-e87e-4d67-af05-11627bbdce3b
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Display Pop-up Help
One way to display Help on Windows Forms is through the **Help** button, located on the right side of the title bar, accessible through the <xref:System.Windows.Forms.Form.HelpButton%2A> property. This type of Help display is well-suited for use with dialog boxes. Dialog boxes shown modally (with the <xref:System.Windows.Forms.Form.ShowDialog%2A> method) have trouble bringing up external Help systems, because modal dialog boxes need to be closed before focus can shift to another window. Additionally, using the **Help** button requires that there is no **Minimize** button or **Maximize** button shown in the title bar. This is a standard dialog-box convention, whereas forms usually have **Minimize** and **Maximize** buttons.  
  
 Be aware that you can also use the <xref:System.Windows.Forms.HelpProvider> component to link controls to files in a Help system, even if you have implemented pop-up Help. For more information, see [Providing Help in a Windows Application](../../../../docs/framework/winforms/advanced/how-to-provide-help-in-a-windows-application.md).  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To display pop-up Help  
  
1.  Drag a [HelpProvider](../../../../docs/framework/winforms/controls/helpprovider-component-windows-forms.md) component from the Toolbox to your form.  
  
     It will sit in the tray at the bottom of the Windows Forms Designer.  
  
2.  In the Properties window, set the <xref:System.Windows.Forms.Form.HelpButton%2A> property to `true`. This will display a button with a question mark in it on the right side of the title bar of the form.  
  
3.  In order for the <xref:System.Windows.Forms.Form.HelpButton%2A> to display, the form's <xref:System.Windows.Forms.Form.MinimizeBox%2A> and <xref:System.Windows.Forms.Form.MaximizeBox%2A> properties must be set to `false`, the <xref:System.Windows.Forms.Form.ControlBox%2A> property set to `true`, and the <xref:System.Windows.Forms.Form.FormBorderStyle%2A> property to one of the following values: <xref:System.Windows.Forms.FormBorderStyle.FixedSingle>, <xref:System.Windows.Forms.FormBorderStyle.Fixed3D>, <xref:System.Windows.Forms.FormBorderStyle.FixedDialog> or <xref:System.Windows.Forms.FormBorderStyle.Sizable>.  
  
4.  Select the control for which you want to show help on your form and set the Help string in the Properties window. This is the string of text that will be displayed in a window similar to a [ToolTip](../../../../docs/framework/winforms/controls/tooltip-component-windows-forms.md).  
  
5.  Press **F5**.  
  
6.  Press the **Help** button on the title bar and click the control on which you set the Help string.  
  
## See Also  
 [Control Help Using ToolTips](../../../../docs/framework/winforms/advanced/control-help-using-tooltips.md)  
 [Integrating User Help in Windows Forms](../../../../docs/framework/winforms/advanced/integrating-user-help-in-windows-forms.md)  
 [Windows Forms](../../../../docs/framework/winforms/index.md)
