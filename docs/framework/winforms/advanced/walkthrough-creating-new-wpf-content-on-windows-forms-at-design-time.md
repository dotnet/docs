---
title: "Walkthrough: Creating New WPF Content on Windows Forms at Design Time"
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
  - "interoperability [Windows Forms], WPF and Windows Forms"
  - "WPF content [Windows Forms], hosting in Windows Forms"
  - "hosting WPF content in Windows Forms"
  - "ElementHost control"
  - "WPF user control [Windows Forms], hosting in Windows Forms"
ms.assetid: 2e92d8e8-f0e4-4df7-9f07-2acf35cd798c
caps.latest.revision: 20
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Creating New WPF Content on Windows Forms at Design Time
This topic shows you how to create a Windows Presentation Foundation (WPF) control for use in your Windows Forms-based applications.  
  
 In this walkthrough, you perform the following tasks:  
  
-   Create the project.  
  
-   Create a new WPF control.  
  
-   Add the new WPF control to a Windows Form. The WPF control is hosted in an <xref:System.Windows.Forms.Integration.ElementHost> control.  
  
> [!NOTE]
>  The dialog boxes and menu commands you see might differ from those described in Help depending on your active settings or edition. To change your settings, choose **Import and Export Settings** on the **Tools** menu. For more information, see [Customizing Development Settings in Visual Studio](http://msdn.microsoft.com/library/22c4debb-4e31-47a8-8f19-16f328d7dcd3).  
  
## Prerequisites  
 You need the following components to complete this walkthrough:  
  
-   [!INCLUDE[vs_orcas_long](../../../../includes/vs-orcas-long-md.md)].  
  
## Creating the Project  
 The first step is to create the Windows Forms project.  
  
> [!NOTE]
>  When hosting WPF content, only C# and Visual Basic projects are supported.  
  
#### To create the project  
  
-   Create a new Windows Forms Application project in Visual Basic or Visual C# named `HostingWpf`.  
  
## Creating a New WPF Control  
 Creating a new WPF control and adding it to your project is as easy as adding any other item to your project. The Windows Forms Designer works with a particular kind of control named *composite control*, or *user control*. For more information about WPF user controls, see <xref:System.Windows.Controls.UserControl>.  
  
> [!NOTE]
>  The <xref:System.Windows.Controls.UserControl?displayProperty=nameWithType> type for WPF is distinct from the user control type provided by Windows Forms, which is also named <xref:System.Windows.Forms.UserControl?displayProperty=nameWithType>.  
  
#### To create a new WPF control  
  
1.  In **Solution Explorer**, add a new **WPF User Control Library** project to the solution. Use the default name for the control library, `WpfControlLibrary1`. The default control name is `UserControl1.xaml`.  
  
     Adding the new control has the following effects.  
  
    -   File UserControl1.xaml is added.  
  
    -   Either file UserControl1.xaml.cs or UserControl1.xaml.vb is added. This file contains the code-behind for event handlers and other implementation.  
  
    -   References to WPF assemblies are added.  
  
    -   File UserControl1.xaml opens in the [!INCLUDE[wpfdesigner_current_long](../../../../includes/wpfdesigner-current-long-md.md)].  
  
2.  In Design view, make sure that `UserControl1` is selected. For more information, see [How to: Select and Move Elements on the Design Surface](http://msdn.microsoft.com/library/54cb70b6-b35b-46e4-a0cc-65189399c474).  
  
3.  In the **Properties** window, set the value of the <xref:System.Windows.FrameworkElement.Width%2A> and <xref:System.Windows.FrameworkElement.Height%2A> properties to `200`.  
  
4.  From the **Toolbox**, drag a <xref:System.Windows.Controls.TextBox?displayProperty=nameWithType> control onto the design surface.  
  
5.  In the **Properties** window, set the value of the <xref:System.Windows.Controls.TextBox.Text%2A> property to **Hosted Content**.  
  
    > [!NOTE]
    >  In general, you should host more sophisticated WPF content. The <xref:System.Windows.Controls.TextBox?displayProperty=nameWithType> control is used here for illustrative purposes only.  
  
6.  Build the project.  
  
## Adding a WPF Control to a Windows Form  
 Your new WPF control is ready for use on the form. Windows Forms uses the <xref:System.Windows.Forms.Integration.ElementHost> control to host WPF content  
  
#### To add a WPF control to a Windows Form  
  
1.  Open `Form1` in the Windows Forms Designer.  
  
2.  In the **Toolbox**, find the tab labeled **WPFUserControlLibrary WPF User Controls**.  
  
3.  Drag an instance of `UserControl1` onto the form.  
  
    -   An <xref:System.Windows.Forms.Integration.ElementHost> control is created automatically on the form to host the WPF control.  
  
    -   The <xref:System.Windows.Forms.Integration.ElementHost> control is named `elementHost1` and in the **Properties** window, you can see its <xref:System.Windows.Forms.Integration.ElementHost.Child%2A> property is set to **UserControl1**.  
  
    -   References to WPF assemblies are added to the project.  
  
    -   The `elementHost1` control has a smart tag panel that shows the available hosting options.  
  
4.  In the **ElementHost Tasks** smart tag panel, select **Dock in parent container**.  
  
5.  Press F5 to build and run the application.  
  
## Next Steps  
 Windows Forms and WPF are different technologies, but they are designed to interoperate closely. To provide richer appearance and behavior in your applications, try the following.  
  
-   Host a Windows Forms control in a WPF page. For more information, see [Walkthrough: Hosting a Windows Forms Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-windows-forms-control-in-wpf.md).  
  
-   Apply Windows Forms visual styles to your WPF content. For more information, see [How to: Enable Visual Styles in a Hybrid Application](../../../../docs/framework/wpf/advanced/how-to-enable-visual-styles-in-a-hybrid-application.md).  
  
-   Change the style of your WPF content. For more information, see [Walkthrough: Styling WPF Content](../../../../docs/framework/winforms/advanced/walkthrough-styling-wpf-content.md).  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [Migration and Interoperability](../../../../docs/framework/wpf/advanced/migration-and-interoperability.md)  
 [Using WPF Controls](../../../../docs/framework/winforms/advanced/using-wpf-controls.md)  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)
