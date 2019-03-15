---
title: "Walkthrough: Hosting a 3-D WPF Composite Control in Windows Forms"
ms.date: 08/18/2018
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "hosting WPF content in Windows Forms [WPF]"
  - "composite controls [WPF], hosting WPF in"
ms.assetid: 486369a9-606a-4a3b-b086-a06f2119c7b0
---
# Walkthrough: Hosting a 3-D WPF Composite Control in Windows Forms

This walkthrough demonstrates how you can create a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] composite control and host it in [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] controls and forms by using the <xref:System.Windows.Forms.Integration.ElementHost> control.

In this walkthrough, you will implement a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Controls.UserControl> that contains two child controls. The <xref:System.Windows.Controls.UserControl> displays a three-dimensional (3-D) cone. Rendering 3-D objects is much easier with the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] than with [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)]. Therefore, it makes sense to host a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Controls.UserControl> class to create 3-D graphics in [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)].

Tasks illustrated in this walkthrough include:

-   Creating the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Controls.UserControl>.

-   Creating the Windows Forms host project.

-   Hosting the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] <xref:System.Windows.Controls.UserControl>.

## Prerequisites

You need the following components to complete this walkthrough:

-   Visual Studio 2017

<a name="To_Create_the_UserControl"></a>
## Create the UserControl

1.  Create a **WPF User Control Library** project named `HostingWpfUserControlInWf`.

2.  Open UserControl1.xaml in the [!INCLUDE[wpfdesigner_current_short](../../../../includes/wpfdesigner-current-short-md.md)].

3.  Replace the generated code with the following code:

     [!code-xaml[HostingWpfUserControlInWf#1](~/samples/snippets/csharp/VS_Snippets_Wpf/HostingWpfUserControlInWf/CSharp/HostingWpfUserControlInWf/ConeControl.xaml#1)]

     This code defines a <xref:System.Windows.Controls.UserControl?displayProperty=nameWithType> that contains two child controls. The first child control is a <xref:System.Windows.Controls.Label?displayProperty=nameWithType> control; the second is a <xref:System.Windows.Controls.Viewport3D> control that displays a 3-D cone.

<a name="To_Create_the_Windows_Forms_Host_Project"></a>
## Create the host project

1.  Add a **WPF App (.NET Framework)** project named `WpfUserControlHost` to the solution. For more information, see [Walkthrough: My first WPF desktop application](../getting-started/walkthrough-my-first-wpf-desktop-application.md).

2.  In **Solution Explorer**, add a reference to the WindowsFormsIntegration assembly, which is named WindowsFormsIntegration.dll.

3.  Add references to the following [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] assemblies:

    -   PresentationCore

    -   PresentationFramework

    -   WindowsBase

4.  Add a reference to the `HostingWpfUserControlInWf` project.

5.  In Solution Explorer, set the `WpfUserControlHost` project to be the startup project.

<a name="To_Host_the_Windows_Presentation_Foundation"></a>
## Host the UserControl

1.  In the Windows Forms Designer, open Form1.

2.  In the Properties window, click **Events**, and then double-click the <xref:System.Windows.Forms.Form.Load> event to create an event handler.

     The Code Editor opens to the newly generated `Form1_Load` event handler.

3.  Replace the code in Form1.cs with the following code.

     The `Form1_Load` event handler creates an instance of `UserControl1` and adds itto the <xref:System.Windows.Forms.Integration.ElementHost> control's collection of child controls. The <xref:System.Windows.Forms.Integration.ElementHost> control is added to the form's collection of child controls.

     [!code-csharp[HostingWpfUserControlInWf#10](~/samples/snippets/csharp/VS_Snippets_Wpf/HostingWpfUserControlInWf/CSharp/WpfUserControlHost/Form1.cs#10)]
     [!code-vb[HostingWpfUserControlInWf#10](~/samples/snippets/visualbasic/VS_Snippets_Wpf/HostingWpfUserControlInWf/VisualBasic/WpfUserControlHost/Form1.vb#10)]

4.  Press **F5** to build and run the application.

## See also

- <xref:System.Windows.Forms.Integration.ElementHost>
- <xref:System.Windows.Forms.Integration.WindowsFormsHost>
- [Design XAML in Visual Studio](/visualstudio/designers/designing-xaml-in-visual-studio)
- [Walkthrough: Hosting a WPF Composite Control in Windows Forms](walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md)
- [Walkthrough: Hosting a Windows Forms Composite Control in WPF](walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md)
- [Hosting a WPF Composite Control in Windows Forms Sample](https://go.microsoft.com/fwlink/?LinkID=160001)