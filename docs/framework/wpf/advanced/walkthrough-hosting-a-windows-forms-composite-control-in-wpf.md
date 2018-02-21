---
title: "Walkthrough: Hosting a Windows Forms Composite Control in WPF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "hosting Windows Forms control in WPF [WPF]"
  - "composite controls [WPF], hosting in WPF"
ms.assetid: 96fcd78d-1c77-4206-8928-3a0579476ef4
caps.latest.revision: 33
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Hosting a Windows Forms Composite Control in WPF
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides a rich environment for creating applications. However, when you have a substantial investment in [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] code, it can be more effective to reuse at least some of that code in your [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application rather than to rewrite it from scratch. The most common scenario is when you have existing [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] controls. In some cases, you might not even have access to the source code for these controls. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] provides a straightforward procedure for hosting such controls in a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application. For example, you can use [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] for most of your programming while hosting your specialized <xref:System.Windows.Forms.DataGridView> controls.  
  
 This walkthrough steps you through an application that hosts a [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] composite control to perform data entry in a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application. The composite control is packaged in a DLL. This general procedure can be extended to more complex applications and controls. This walkthrough is designed to be nearly identical in appearance and functionality to [Walkthrough: Hosting a WPF Composite Control in Windows Forms](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md). The primary difference is that the hosting scenario is reversed.  
  
 The walkthrough is divided into two sections. The first section briefly describes the implementation of the [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] composite control. The second section discusses in detail how to host the composite control in a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application, receive events from the control, and access some of the control's properties.  
  
 Tasks illustrated in this walkthrough include:  
  
-   Implementing the Windows Forms composite control.  
  
-   Implementing the WPF host application.  
  
 For a complete code listing of the tasks illustrated in this walkthrough, see [Hosting a Windows Forms Composite Control in WPF Sample](http://go.microsoft.com/fwlink/?LinkID=159999).  
  
## Prerequisites  
 You need the following components to complete this walkthrough:  
  
-   [!INCLUDE[vs_dev10_long](../../../../includes/vs-dev10-long-md.md)].  
  
## Implementing the Windows Forms Composite Control  
 The [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] composite control used in this example is a simple data-entry form. This form takes the user's name and address and then uses a custom event to return that information to the host. The following illustration shows the rendered control.  
  
 ![Simple Windows Forms control](../../../../docs/framework/wpf/advanced/media/wfcontrol.gif "WFControl")  
Windows Forms composite control  
  
### Creating the Project  
 To start the project:  
  
1.  Launch [!INCLUDE[TLA#tla_visualstu](../../../../includes/tlasharptla-visualstu-md.md)], and open the **New Project** dialog box.  
  
2.  In the Window category, select the **Windows Forms Control Library** template.  
  
3.  Name the new project `MyControls`.  
  
4.  For the location, specify a conveniently named top-level folder, such as `WpfHostingWindowsFormsControl`. Later, you will put the host application in this folder.  
  
5.  Click **OK** to create the project. The default project contains a single control named `UserControl1`.  
  
6.  In Solution Explorer, rename `UserControl1` to `MyControl1`.  
  
 Your project should have references to the following system DLLs. If any of these DLLs are not included by default, add them to the project.  
  
-   System  
  
-   System.Data  
  
-   System.Drawing  
  
-   System.Windows.Forms  
  
-   System.Xml  
  
### Adding Controls to the Form  
 To add controls to the form:  
  
-   Open `MyControl1` in the designer.  
  
 Add five <xref:System.Windows.Forms.Label> controls and their corresponding <xref:System.Windows.Forms.TextBox> controls, sized and arranged as they are in the preceding illustration, on the form. In the example, the <xref:System.Windows.Forms.TextBox> controls are named:  
  
-   `txtName`  
  
-   `txtAddress`  
  
-   `txtCity`  
  
-   `txtState`  
  
-   `txtZip`  
  
 Add two <xref:System.Windows.Forms.Button> controls labeled **OK** and **Cancel**. In the example, the button names are `btnOK` and `btnCancel`, respectively.  
  
### Implementing the Supporting Code  
 Open the form in code view. The control returns the collected data to its host by raising the custom `OnButtonClick` event. The data is contained in the event argument object. The following code shows the event and delegate declaration.  
  
 Add the following code to the `MyControl1` class.  
  
 [!code-csharp[WpfHostingWindowsFormsControl#2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/CSharp/MyControls/MyControl1.cs#2)]
 [!code-vb[WpfHostingWindowsFormsControl#2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/VisualBasic/MyControls/MyControl1.vb#2)]  
  
 The `MyControlEventArgs` class contains the information to be returned to the host.  
  
 Add the following class to the form.  
  
 [!code-csharp[WpfHostingWindowsFormsControl#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/CSharp/MyControls/MyControl1.cs#3)]
 [!code-vb[WpfHostingWindowsFormsControl#3](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/VisualBasic/MyControls/MyControl1.vb#3)]  
  
 When the user clicks the **OK** or **Cancel** button, the <xref:System.Windows.Forms.Control.Click> event handlers create a `MyControlEventArgs` object that contains the data and raises the `OnButtonClick` event. The only difference between the two handlers is the event argument's `IsOK` property. This property enables the host to determine which button was clicked. It is set to `true` for the **OK** button, and `false` for the **Cancel** button. The following code shows the two button handlers.  
  
 Add the following code to the `MyControl1` class.  
  
 [!code-csharp[WpfHostingWindowsFormsControl#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/CSharp/MyControls/MyControl1.cs#4)]
 [!code-vb[WpfHostingWindowsFormsControl#4](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/VisualBasic/MyControls/MyControl1.vb#4)]  
  
### Giving the Assembly a Strong Name and Building the Assembly  
 For this assembly to be referenced by a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application, it must have a strong name. To create a strong name, create a key file with Sn.exe and add it to your project.  
  
1.  Open a [!INCLUDE[TLA2#tla_visualstu](../../../../includes/tla2sharptla-visualstu-md.md)] command prompt. To do so, click the **Start** menu, and then select **All Programs/Microsoft Visual Studio 2010/Visual Studio Tools/Visual Studio Command Prompt**. This launches a console window with customized environment variables.  
  
2.  At the command prompt, use the `cd` command to go to your project folder.  
  
3.  Generate a key file named MyControls.snk by running the following command.  
  
    ```  
    Sn.exe -k MyControls.snk  
    ```  
  
4.  To include the key file in your project, right-click the project name in Solution Explorer and then click **Properties**. In the Project Designer, click the **Signing** tab, select the **Sign the assembly** check box and then browse to your key file.  
  
5.  Build the solution. The build will produce a DLL named MyControls.dll.  
  
## Implementing the WPF Host Application  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] host application uses the <xref:System.Windows.Forms.Integration.WindowsFormsHost> control to host `MyControl1`. The application handles the `OnButtonClick` event to receive the data from the control. It also has a collection of option buttons that enable you to change some of the control's properties from the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application. The following illustration shows the finished application.  
  
 ![A control embedded in a WPF page](../../../../docs/framework/wpf/advanced/media/avalonhost.gif "AvalonHost")  
The complete application, showing the control embedded in the WPF application  
  
### Creating the Project  
 To start the project:  
  
1.  Open [!INCLUDE[TLA2#tla_visualstu](../../../../includes/tla2sharptla-visualstu-md.md)], and select **New Project**.  
  
2.  In the Window category, select the **WPF Application** template.
  
3.  Name the new project `WpfHost`.  
  
4.  For the location, specify the same top-level folder that contains the MyControls project.  
  
5.  Click **OK** to create the project.  
  
 You also need to add references to the DLL that contains `MyControl1` and other assemblies.  
  
1.  Right-click the project name in Solution Explorer and select **Add Reference**.  
  
2.  Click the **Browse** tab, and browse to the folder that contains MyControls.dll. For this walkthrough, this folder is MyControls\bin\Debug.  
  
3.  Select MyControls.dll, and then click **OK**.  
  
4.  Add a reference to the WindowsFormsIntegration assembly, which is named WindowsFormsIntegration.dll.  
  
### Implementing the Basic Layout  
 The [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] of the host application is implemented in MainWindow.xaml. This file contains [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] markup that defines the layout, and hosts the [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] control. The application is divided into three regions:  
  
-   The **Control Properties** panel, which contains a collection of option buttons that you can use to modify various properties of the hosted control.  
  
-   The **Data from Control** panel, which contains several <xref:System.Windows.Controls.TextBlock> elements that display the data returned from the hosted control.  
  
-   The hosted control itself.  
  
 The basic layout is shown in the following XAML. The markup that is needed to host `MyControl1` is omitted from this example, but will be discussed later.  
  
 Replace the XAML in MainWindow.xaml with the following. If you are using Visual Basic, change the class to `x:Class="MainWindow"`.  
  
 [!code-xaml[WpfHostingWindowsFormsControl#100](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/CSharp/WpfHost/Page1.xaml#100)]  
  
 The first <xref:System.Windows.Controls.StackPanel> element contains several sets of <xref:System.Windows.Controls.RadioButton> controls that enable you to modify various default properties of the hosted control. That is followed by a <xref:System.Windows.Forms.Integration.WindowsFormsHost> element, which hosts `MyControl1`. The final <xref:System.Windows.Controls.StackPanel> element contains several <xref:System.Windows.Controls.TextBlock> elements that display the data that is returned by the hosted control. The ordering of the elements and the <xref:System.Windows.Controls.DockPanel.Dock%2A> and <xref:System.Windows.FrameworkElement.Height%2A> attribute settings embed the hosted control into the window with no gaps or distortion.  
  
#### Hosting the Control  
 The following edited version of the previous XAML focuses on the elements that are needed to host `MyControl1`.  
  
 [!code-xaml[WpfHostingWindowsFormsControl#101](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/CSharp/WpfHost/Page1.xaml#101)]  
[!code-xaml[WpfHostingWindowsFormsControl#102](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/CSharp/WpfHost/Page1.xaml#102)]  
  
 The `xmlns` namespace mapping attribute creates a reference to the `MyControls` namespace that contains the hosted control. This mapping enables you to represent `MyControl1` in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] as `<mcl:MyControl1>`.  
  
 Two elements in the XAML handle the hosting:  
  
-   `WindowsFormsHost` represents the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element that enables you to host a [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] control in a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application.  
  
-   `mcl:MyControl1`, which represents `MyControl1`, is added to the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element's child collection. As a result, this [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] control is rendered as part of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] window, and you can communicate with the control from the application.  
  
### Implementing the Code-Behind File  
 The code-behind file, MainWindow.xaml.vb or MainWindow.xaml.cs, contains the procedural code that implements the functionality of the [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] discussed in the preceding section. The primary tasks are:  
  
-   Attaching an event handler to `MyControl1`'s `OnButtonClick` event.  
  
-   Modifying various properties of `MyControl1`, based on how the collection of option buttons are set.  
  
-   Displaying the data collected by the control.  
  
#### Initializing the Application  
 The initialization code is contained in an event handler for the window's <xref:System.Windows.FrameworkElement.Loaded> event and attaches an event handler to the control's `OnButtonClick` event.  
  
 In MainWindow.xaml.vb or MainWindow.xaml.cs, add the following code to the `MainWindow` class.  
  
 [!code-csharp[WpfHostingWindowsFormsControl#11](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/CSharp/WpfHost/Page1.xaml.cs#11)]
 [!code-vb[WpfHostingWindowsFormsControl#11](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/VisualBasic/WpfHost/Page1.xaml.vb#11)]  
  
 Because the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] discussed previously added `MyControl1` to the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element's child element collection, you can cast the <xref:System.Windows.Forms.Integration.WindowsFormsHost> element's <xref:System.Windows.Forms.Integration.WindowsFormsHost.Child%2A> to get the reference to `MyControl1`. You can then use that reference to attach an event handler to `OnButtonClick`.  
  
 In addition to providing a reference to the control itself, <xref:System.Windows.Forms.Integration.WindowsFormsHost> exposes a number of the control's properties, which you can manipulate from the application. The initialization code assigns those values to private global variables for later use in the application.  
  
 So that you can easily access the types in the `MyControls` DLL, add the following `Imports` or `using` statement to the top of the file.  
  
```vb  
Imports MyControls  
```  
  
```csharp  
using MyControls;  
```  
  
#### Handling the OnButtonClick Event  
 `MyControl1` raises the `OnButtonClick` event when the user clicks either of the control's buttons.  
  
 Add the following code to the `MainWindow` class.  
  
 [!code-csharp[WpfHostingWindowsFormsControl#12](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/CSharp/WpfHost/Page1.xaml.cs#12)]
 [!code-vb[WpfHostingWindowsFormsControl#12](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/VisualBasic/WpfHost/Page1.xaml.vb#12)]  
  
 The data in the text boxes is packed into the `MyControlEventArgs` object. If the user clicks the **OK** button, the event handler extracts the data and displays it in the panel below `MyControl1`.  
  
#### Modifying the Control’s Properties  
 The <xref:System.Windows.Forms.Integration.WindowsFormsHost> element exposes several of the hosted control's default properties. As a result, you can change the appearance of the control to match the style of your application more closely. The sets of option buttons in the left panel enable the user to modify several color and font properties. Each set of buttons has a handler for the <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event, which detects the user's option button selections and changes the corresponding property on the control.  
  
 Add the following code to the `MainWindow` class.  
  
 [!code-csharp[WpfHostingWindowsFormsControl#13](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/CSharp/WpfHost/Page1.xaml.cs#13)]
 [!code-vb[WpfHostingWindowsFormsControl#13](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WpfHostingWindowsFormsControl/VisualBasic/WpfHost/Page1.xaml.vb#13)]  
  
 Build and run the application. Add some text in the Windows Forms composite control and then click **OK**. The text appears in the labels. Click the different radio buttons to see the effect on the control.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)  
 [Walkthrough: Hosting a Windows Forms Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-windows-forms-control-in-wpf.md)  
 [Walkthrough: Hosting a WPF Composite Control in Windows Forms](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-wpf-composite-control-in-windows-forms.md)
