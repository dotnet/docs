---
title: "How to: Copy and Paste an ElementHost Control at Design Time"
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
  - "Windows Forms, content copying and pasting"
  - "interoperability [WPF]"
  - "ElementHost control [Windows Forms], copying and pasting at design time"
  - "WPF user control [Windows Forms], hosting in Windows Forms"
ms.assetid: e570375d-2a68-44ba-b4f7-c781af2d20e8
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Copy and Paste an ElementHost Control at Design Time
This procedure shows you how to copy a Windows Presentation Foundation (WPF) control on a Windows Form.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
### To copy and paste an ElementHost control at design time  
  
1.  Add a new WPF <xref:System.Windows.Controls.UserControl> to your Windows Forms project. Use the default name for the control type, `UserControl1.xaml`. For more information, see [Walkthrough: Creating New WPF Content on Windows Forms at Design Time](../../../../docs/framework/winforms/advanced/walkthrough-creating-new-wpf-content-on-windows-forms-at-design-time.md).  
  
2.  In the **Properties** window, set the value of the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties of `UserControl1` to `200`.  
  
3.  Set the value of the <xref:System.Windows.Controls.Control.Background%2A> property to `Blue`.  
  
4.  Build the project.  
  
5.  Open `Form1` in the Windows Forms Designer.  
  
6.  From the **Toolbox**, drag an instance of `UserControl1` onto the form.  
  
     An instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost1`.  
  
7.  With `elementHost1` selected, press CTRL+C to copy it to the clipboard.  
  
8.  Press CTRL+V to paste the copied control onto the form.  
  
     A new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost2` is created on the form.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [Walkthrough: Copying and Pasting an ElementHost Control into Separate Windows Forms](../../../../docs/framework/winforms/advanced/copy--paste-an-elementhost-control-into-forms.md)  
 [Migration and Interoperability](../../../../docs/framework/wpf/advanced/migration-and-interoperability.md)  
 [Using WPF Controls](../../../../docs/framework/winforms/advanced/using-wpf-controls.md)  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)
