---
title: "Walkthrough: Copying and Pasting an ElementHost Control into Separate Windows Forms"
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
ms.assetid: 6e81bb13-577c-46c3-a1cf-8d15969fb83e
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Copying and Pasting an ElementHost Control into Separate Windows Forms
This walkthrough shows you how to copy a Windows Presentation Foundation (WPF) control from one Windows Form to another.  
  
 In this walkthrough, you perform the following tasks:  
  
-   Create the project.  
  
-   Copy a WPF Control.  
  
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
  
-   Create a new Windows Forms Application project in Visual Basic or Visual C# named `CopyElementHost`.  
  
## Copying a WPF Control  
 After you add a WPF control to the project, you can copy it to other forms in the project.  
  
#### To copy a WPF control  
  
1.  Add a new WPF <xref:System.Windows.Controls.UserControl> project to the solution. Use the default name for the control type, `UserControl1.xaml`. For more information, see [Walkthrough: Creating New WPF Content on Windows Forms at Design Time](../../../../docs/framework/winforms/advanced/walkthrough-creating-new-wpf-content-on-windows-forms-at-design-time.md).  
  
2.  Build the project.  
  
3.  Open `Form1` in the Windows Forms Designer.  
  
4.  From the **Toolbox**, drag an instance of `UserControl1` onto the form.  
  
     An instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost1`.  
  
5.  With `elementHost1` selected, press CTRL+C to copy it to the clipboard.  
  
6.  Add a new Windows Form to the project. Use the default name for the form type, `Form2`.  
  
7.  With `Form2` open in the Windows Forms Designer, press CTRL+V to paste a copy of `elementHost1` onto the form.  
  
     The copied control is also named `elementHost1`, because it is a private field of the `Form2` class. There is no name collision with the `elementHost1` in the `Form1` class.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [Migration and Interoperability](../../../../docs/framework/wpf/advanced/migration-and-interoperability.md)  
 [Using WPF Controls](../../../../docs/framework/winforms/advanced/using-wpf-controls.md)  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)
