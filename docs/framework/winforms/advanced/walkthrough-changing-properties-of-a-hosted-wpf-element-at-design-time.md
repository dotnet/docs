---
title: "Walkthrough: Changing Properties of a Hosted WPF Element at Design Time"
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
  - "WPF content [Windows Forms], changing properties at design time"
  - "Windows Forms, changing properties of WPF content at design time"
  - "WPF content [Windows Forms], hosting in Windows Forms"
  - "interoperability [WPF]"
ms.assetid: a1f7a90c-0bbb-4781-8c3c-8cc8bef2488d
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Changing Properties of a Hosted WPF Element at Design Time
This walkthrough shows you how to change property values of a Windows Presentation Foundation (WPF) control hosted on a Windows Form.  
  
 In this walkthrough, you perform the following tasks:  
  
-   Create the project.  
  
-   Create the WPF control.  
  
-   Host the WPF controls on a Windows Form.  
  
-   Use the WPF Designer for Visual Studio to change property values.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Prerequisites  
 You need the following components to complete this walkthrough:  
  
-   [!INCLUDE[vs_dev11_long](../../../../includes/vs-dev11-long-md.md)].  
  
## Creating the Project  
 The first step is to create the Windows Forms project.  
  
> [!NOTE]
>  When hosting WPF content, only C# and Visual Basic projects are supported.  
  
#### To create the project  
  
-   Create a new Windows Forms Application project in Visual Basic or Visual C# named `WpfHost`.  
  
## Creating the WPF Control  
 After you add a WPF control to the project, you can arrange it on the form.  
  
#### To create WPF controls  
  
1.  Add a new WPF <xref:System.Windows.Controls.UserControl> to the project. Use the default name for the control type, `UserControl1.xaml`. For more information, see [Walkthrough: Creating New WPF Content on Windows Forms at Design Time](../../../../docs/framework/winforms/advanced/walkthrough-creating-new-wpf-content-on-windows-forms-at-design-time.md).  
  
2.  In the **Properties** window, set the value of the <xref:System.Windows.Controls.Control.Background%2A> property to `Blue`.  
  
3.  Build the project.  
  
## Changing Property Values on the WPF Control  
 The <xref:System.Windows.Forms.Integration.ElementHost> smart tag makes it easy to change properties of hosted WPF content by using the WPF Designer.  
  
#### To host a WPF control  
  
1.  Open `Form1` in the Windows Forms Designer.  
  
2.  In the **Toolbox**, in the **WPF User Controls** tab, double-click `UserControl1` to create an instance of `UserControl1` on the form.  
  
     The instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost1`.  
  
3.  In the **ElementHost Tasks** smart tag panel, select **Edit Hosted Content**.  
  
     UserControl1.xaml opens in the WPF Designer.  
  
4.  In the **Properties** window, set the value of the <xref:System.Windows.Controls.Control.Background%2A> property to `Red`.  
  
5.  Rebuild the project.  
  
6.  Open `Form1` in the Windows Forms Designer.  
  
     The instance of `UserControl1` has a red background.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [How to: Anchor and Dock Child Controls in a TableLayoutPanel Control](../../../../docs/framework/winforms/controls/how-to-anchor-and-dock-child-controls-in-a-tablelayoutpanel-control.md)  
 [How to: Align a Control to the Edges of Forms at Design Time](../../../../docs/framework/winforms/controls/how-to-align-a-control-to-the-edges-of-forms-at-design-time.md)  
 [Walkthrough: Arranging Controls on Windows Forms Using Snaplines](../../../../docs/framework/winforms/controls/walkthrough-arranging-controls-on-windows-forms-using-snaplines.md)  
 [Migration and Interoperability](../../../../docs/framework/wpf/advanced/migration-and-interoperability.md)  
 [Using WPF Controls](../../../../docs/framework/winforms/advanced/using-wpf-controls.md)  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)
