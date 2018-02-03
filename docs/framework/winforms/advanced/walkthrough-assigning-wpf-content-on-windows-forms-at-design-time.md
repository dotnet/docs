---
title: "Walkthrough: Assigning WPF Content on Windows Forms at Design Time"
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
  - "WPF content [Windows Forms], assigning at design time"
  - "ElementHost control [Windows Forms], assigning WPF content at design time"
  - "interoperability [WPF]"
  - "Windows Forms, content assignments"
  - "WPF user control [Windows Forms], hosting in Windows Forms"
ms.assetid: b3e9ef93-7e0f-4a2f-8f1e-3437609a1eb7
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Assigning WPF Content on Windows Forms at Design Time
This walkthrough show you how to select the Windows Presentation Foundation (WPF) control types you want to display on your form. You can select any WPF control types which are included in your project.  
  
 In this walkthrough, you perform the following tasks:  
  
-   Create the project.  
  
-   Create the WPF control types.  
  
-   Select WPF controls.  
  
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
  
-   Create a new Windows Forms Application project in Visual Basic or Visual C# named `SelectingWpfContent`.  
  
## Creating the WPF Control Types  
 After you add WPF control types to the project, you can host them in different <xref:System.Windows.Forms.Integration.ElementHost> controls.  
  
#### To create WPF control types  
  
1.  Add a new WPF <xref:System.Windows.Controls.UserControl> project to the solution. Use the default name for the control type, `UserControl1.xaml`. For more information, see [Walkthrough: Creating New WPF Content on Windows Forms at Design Time](../../../../docs/framework/winforms/advanced/walkthrough-creating-new-wpf-content-on-windows-forms-at-design-time.md).  
  
2.  In Design view, make sure that `UserControl1` is selected. For more information, see [How to: Select and Move Elements on the Design Surface](http://msdn.microsoft.com/library/54cb70b6-b35b-46e4-a0cc-65189399c474).  
  
3.  In the **Properties** window, set the value of the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties to `200`.  
  
4.  Add a <xref:System.Windows.Controls.TextBox?displayProperty=nameWithType> control to the <xref:System.Windows.Controls.UserControl> and set the value of the <xref:System.Windows.Controls.TextBox.Text%2A> property to **Hosted Content**.  
  
5.  Add a second WPF <xref:System.Windows.Controls.UserControl> to the project. Use the default name for the control type, `UserControl2.xaml`.  
  
6.  In the **Properties** window, set the value of the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties to `200`.  
  
7.  Add a <xref:System.Windows.Controls.TextBox?displayProperty=nameWithType> control to the <xref:System.Windows.Controls.UserControl> and set the value of the <xref:System.Windows.Controls.TextBox.Text%2A> property to **Hosted Content 2**.  
  
 **Note** In general, you should host more sophisticated WPF content. The <xref:System.Windows.Controls.TextBox?displayProperty=nameWithType> control is used here for illustrative purposes only.  
  
1.  Build the project.  
  
## Selecting WPF Controls  
 You can assign different WPF content to an <xref:System.Windows.Forms.Integration.ElementHost> control, which is already hosting content.  
  
#### To select WPF controls  
  
1.  Open `Form1` in the Windows Forms Designer.  
  
2.  In the **Toolbox**, double-click `UserControl1` to create an instance of `UserControl1` on the form.  
  
     An instance of `UserControl1` is hosted in a new <xref:System.Windows.Forms.Integration.ElementHost> control named `elementHost1`.  
  
3.  In the smart tag panel for `elementHost1`, open the **Select Hosted Content** drop-down list.  
  
4.  Select **UserControl2** from the drop-down list box.  
  
     The `elementHost1` control now hosts an instance of the `UserControl2` type.  
  
5.  In the **Properties** window, confirm that the <xref:System.Windows.Forms.Integration.ElementHost.Child%2A> property is set to **UserControl2**.  
  
6.  From the **Toolbox**, in the **WPF Interoperability** group, drag an <xref:System.Windows.Forms.Integration.ElementHost> control onto the form.  
  
     The default name for the new control is `elementHost2`.  
  
7.  In the smart tag panel for `elementHost2`, open the **Select Hosted Content** drop-down list.  
  
8.  Select **UserControl1** from the drop-down list.  
  
9. The `elementHost2` control now hosts an instance of the `UserControl1` type.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [Migration and Interoperability](../../../../docs/framework/wpf/advanced/migration-and-interoperability.md)  
 [Using WPF Controls](../../../../docs/framework/winforms/advanced/using-wpf-controls.md)  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)
