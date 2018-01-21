---
title: "Walkthrough: Hosting a WPF Composite Control in Windows Forms"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "hosting WPF content in Windows Forms [WPF]"
ms.assetid: 0ac41286-4c1b-4b17-9196-d985cb844ce1
caps.latest.revision: 34
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Walkthrough: Hosting a WPF Composite Control in Windows Forms
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides a rich environment for creating applications. However, when you have a substantial investment in [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] code, it can be more effective to extend your existing [!INCLUDE[TLA#tla_winforms](../../../../includes/tlasharptla-winforms-md.md)] application with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] rather than to rewrite it from scratch. A common scenario is when you want to embed one or more controls implemented with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] within your [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] application. For more information about customizing WPF controls, see [Control Customization](../../../../docs/framework/wpf/controls/control-customization.md).  
  
 This walkthrough steps you through an application that hosts a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] composite control to perform data-entry in a [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] application. The composite control is packaged in a DLL. This general procedure can be extended to more complex applications and controls. This walkthrough is designed to be nearly identical in appearance and functionality to [Walkthrough: Hosting a Windows Forms Composite Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md). The primary difference is that the hosting scenario is reversed.  
  
 The walkthrough is divided into two sections. The first section briefly describes the implementation of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] composite control. The second section discusses in detail how to host the composite control in a [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] application, receive events from the control, and access some of the control’s properties.  
  
 Tasks illustrated in this walkthrough include:  
  
-   Implementing the WPF composite control.  
  
-   Implementing the Windows Forms host application.  
  
 For a complete code listing of the tasks illustrated in this walkthrough, see [Hosting a WPF Composite Control in Windows Forms Sample](http://go.microsoft.com/fwlink/?LinkID=159996).  
  
## Prerequisites  
 You need the following components to complete this walkthrough:  
  
-   [!INCLUDE[vs_dev10_long](../../../../includes/vs-dev10-long-md.md)].  
  
## Implementing the WPF Composite Control  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] composite control used in this example is a simple data-entry form that takes the user's name and address. When the user clicks one of two buttons to indicate that the task is finished, the control raises a custom event to return that information to the host. The following illustration shows the rendered control.  
  
 ![Simple WPF control](../../../../docs/framework/wpf/advanced/media/avaloncontrol.png "AvalonControl")  
WPF composite control  
  
### Creating the Project  
 To start the project:  
  
1.  Launch [!INCLUDE[TLA#tla_visualstu](../../../../includes/tlasharptla-visualstu-md.md)], and open the **New Project** dialog box.  
  
2.  In Visual C# and the Windows category, select the **WPF User Control Library** template.  
  
3.  Name the new project `MyControls`.  
  
4.  For the location, specify a conveniently named top-level folder, such as `WindowsFormsHostingWpfControl`. Later, you will put the host application in this folder.  
  
5.  Click **OK** to create the project. The default project contains a single control named `UserControl1`.  
  
6.  In Solution Explorer, rename `UserControl1` to `MyControl1`.  
  
 Your project should have references to the following system DLLs. If any of these DLLs are not included by default, add them to your project.  
  
-   PresentationCore  
  
-   PresentationFramework  
  
-   System  
  
-   WindowsBase  
  
### Creating the User Interface  
 The [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] for the composite control is implemented with [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)]. The composite control [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] consists of five <xref:System.Windows.Controls.TextBox> elements. Each <xref:System.Windows.Controls.TextBox> element has an associated <xref:System.Windows.Controls.TextBlock> element that serves as a label. There are two <xref:System.Windows.Controls.Button> elements at the bottom, **OK** and **Cancel**. When the user clicks either button, the control raises a custom event to return the information to the host.  
  
#### Basic Layout  
 The various [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] elements are contained in a <xref:System.Windows.Controls.Grid> element. You can use <xref:System.Windows.Controls.Grid> to arrange the contents of the composite control in much the same way you would use a `Table` element in HTML. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] also has a <xref:System.Windows.Documents.Table> element, but <xref:System.Windows.Controls.Grid> is more lightweight and better suited for simple layout tasks.  
  
 The following XAML shows the basic layout. This XAML defines the overall structure of the control by specifying the number of columns and rows in the <xref:System.Windows.Controls.Grid> element.  
  
 In MyControl1.xaml, replace the existing XAML with the following XAML.  
  
 [!code-xaml[WindowsFormsHostingWpfControl#101](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml#101)]  
[!code-xaml[WindowsFormsHostingWpfControl#102](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml#102)]  
  
#### Adding TextBlock and TextBox Elements to the Grid  
 You place a [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] element in the grid by setting the element's <xref:System.Windows.Controls.Grid.RowProperty> and <xref:System.Windows.Controls.Grid.ColumnProperty> attributes to the appropriate row and column number. Remember that row and column numbering are zero-based. You can have an element span multiple columns by setting its <xref:System.Windows.Controls.Grid.ColumnSpanProperty> attribute. For more information about <xref:System.Windows.Controls.Grid> elements, see [Create a Grid Element](../../../../docs/framework/wpf/controls/how-to-create-a-grid-element.md).  
  
 The following XAML shows the composite control’s <xref:System.Windows.Controls.TextBox> and <xref:System.Windows.Controls.TextBlock> elements with their <xref:System.Windows.Controls.Grid.RowProperty> and <xref:System.Windows.Controls.Grid.ColumnProperty> attributes, which are set to place the elements properly in the grid.  
  
 In MyControl1.xaml, add the following XAML within the <xref:System.Windows.Controls.Grid> element.  
  
 [!code-xaml[WindowsFormsHostingWpfControl#103](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml#103)]  
  
#### Styling the UI Elements  
 Many of the elements on the data-entry form have a similar appearance, which means that they have identical settings for several of their properties. Rather than setting each element's attributes separately, the previous XAML uses <xref:System.Windows.Style> elements to define standard property settings for classes of elements. This approach reduces the complexity of the control and enables you to change the appearance of multiple elements through a single style attribute.  
  
 The <xref:System.Windows.Style> elements are contained in the <xref:System.Windows.Controls.Grid> element's <xref:System.Windows.FrameworkElement.Resources%2A> property, so they can be used by all elements in the control. If a style is named, you apply it to an element by adding a <xref:System.Windows.Style> element set to the style's name. Styles that are not named become the default style for the element. For more information about [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] styles, see [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md).  
  
 The following XAML shows the <xref:System.Windows.Style> elements for the composite control. To see how the styles are applied to elements, see the previous XAML. For example, the last <xref:System.Windows.Controls.TextBlock> element has the `inlineText` style, and the last <xref:System.Windows.Controls.TextBox> element uses the default style.  
  
 In MyControl1.xaml, add the following XAML just after the <xref:System.Windows.Controls.Grid> start element.  
  
 [!code-xaml[WindowsFormsHostingWpfControl#104](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml#104)]  
  
#### Adding the OK and Cancel Buttons  
 The final elements on the composite control are the **OK** and **Cancel**<xref:System.Windows.Controls.Button> elements, which occupy the first two columns of the last row of the <xref:System.Windows.Controls.Grid>. These elements use a common event handler, `ButtonClicked`, and the default <xref:System.Windows.Controls.Button> style defined in the previous XAML.  
  
 In MyControl1.xaml, add the following XAML after the last <xref:System.Windows.Controls.TextBox> element. The [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] part of the composite control is now complete.  
  
 [!code-xaml[WindowsFormsHostingWpfControl#105](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml#105)]  
  
### Implementing the Code-Behind File  
 The code-behind file, MyControl1.xaml.cs, implements three essential tasks:
  
1.  Handles the event that occurs when the user clicks one of the buttons.  
  
2.  Retrieves the data from the <xref:System.Windows.Controls.TextBox> elements, and packages it in a custom event argument object.  
  
3.  Raises the custom `OnButtonClick` event, which notifies the host that the user is finished and passes the data back to the host.  
  
 The control also exposes a number of color and font properties that enable you to change the appearance. Unlike the <xref:System.Windows.Forms.Integration.WindowsFormsHost> class, which is used to host a [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] control, the <xref:System.Windows.Forms.Integration.ElementHost> class exposes the control’s <xref:System.Windows.Controls.Panel.Background%2A> property only. To maintain the similarity between this code example and the example discussed in [Walkthrough: Hosting a Windows Forms Composite Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md), the control exposes the remaining properties directly.  
  
#### The Basic Structure of the Code-Behind File  
 The code-behind file consists of a single namespace, `MyControls`, which will contain two classes, `MyControl1` and `MyControlEventArgs`.  
  
```  
namespace MyControls  
{  
  public partial class MyControl1 : Grid  
  {  
    //...  
  }  
  public class MyControlEventArgs : EventArgs  
  {  
    //...  
  }  
}  
```  
  
 The first class, `MyControl1`, is a partial class containing the code that implements the functionality of the [!INCLUDE[TLA2#tla_ui](../../../../includes/tla2sharptla-ui-md.md)] defined in MyControl1.xaml. When MyControl1.xaml is parsed, the [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] is converted to the same partial class, and the two partial classes are merged to form the compiled control. For this reason, the class name in the code-behind file must match the class name assigned to MyControl1.xaml, and it must inherit from the root element of the control. The second class, `MyControlEventArgs`, is an event arguments class that is used to send the data back to the host.  
  
 Open MyControl1.xaml.cs. Change the existing class declaration so that it has the following name and inherits from <xref:System.Windows.Controls.Grid>.  
  
 [!code-csharp[WindowsFormsHostingWpfControl#21](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml.cs#21)]  
  
#### Initializing the Control  
 The following code implements several basic tasks:  
  
-   Declares a private event, `OnButtonClick`, and its associated delegate, `MyControlEventHandler`.  
  
-   Creates several private global variables that store the user's data. This data is exposed through corresponding properties.  
  
-   Implements a handler, `Init`, for the control’s <xref:System.Windows.FrameworkElement.Loaded> event. This handler initializes the global variables by assigning them the values defined in MyControl1.xaml. To do this, it uses the <xref:System.Windows.FrameworkElement.Name%2A> assigned to a typical <xref:System.Windows.Controls.TextBlock> element, `nameLabel`, to access that element's property settings.  
  
 Delete the existing constructor and add the following code to your `MyControl1` class.  
  
 [!code-csharp[WindowsFormsHostingWpfControl#11](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml.cs#11)]  
  
#### Handling the Buttons' Click Events  
 The user indicates that the data-entry task is finished by clicking either the **OK** button or the **Cancel** button. Both buttons use the same <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler, `ButtonClicked`. Both buttons have a name, `btnOK` or `btnCancel`, that enables the handler to determine which button was clicked by examining the value of the `sender` argument. The handler does the following:  
  
-   Creates a `MyControlEventArgs` object that contains the data from the <xref:System.Windows.Controls.TextBox> elements.  
  
-   If the user clicked the **Cancel** button, sets the `MyControlEventArgs` object's `IsOK` property to `false`.  
  
-   Raises the `OnButtonClick` event to indicate to the host that the user is finished, and passes back the collected data.  
  
 Add the following code to your `MyControl1` class, after the `Init` method.  
  
 [!code-csharp[WindowsFormsHostingWpfControl#12](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml.cs#12)]  
  
#### Creating Properties  
 The remainder of the class simply exposes properties that correspond to the global variables discussed previously. When a property changes, the set accessor modifies the appearance of the control by changing the corresponding element properties and updating the underlying global variables.  
  
 Add the following code to your `MyControl1` class.  
  
 [!code-csharp[WindowsFormsHostingWpfControl#13](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml.cs#13)]  
  
#### Sending the Data Back to the Host  
 The final component in the file is the `MyControlEventArgs` class, which is used to send the collected data back to the host.  
  
 Add the following code to your `MyControls` namespace. The implementation is straightforward, and is not discussed further.  
  
 [!code-csharp[WindowsFormsHostingWpfControl#14](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/MyControls/Page1.xaml.cs#14)]  
  
 Build the solution. The build will produce a DLL named MyControls.dll.  
  
<a name="winforms_host_section"></a>   
## Implementing the Windows Forms Host Application  
 The [!INCLUDE[TLA2#tla_winforms](../../../../includes/tla2sharptla-winforms-md.md)] host application uses an <xref:System.Windows.Forms.Integration.ElementHost> object to host the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] composite control. The application handles the `OnButtonClick` event to receive the data from the composite control. The application also has a set of option buttons that you can use to modify the control’s appearance. The following illustration shows the application.  
  
 ![Windows Form Hosting Avalon Control](../../../../docs/framework/wpf/advanced/media/wfhost.png "WFHost")  
WPF composite control hosted in a Windows Forms application  
  
### Creating the Project  
 To start the project:  
  
1.  Launch [!INCLUDE[TLA2#tla_visualstu](../../../../includes/tla2sharptla-visualstu-md.md)], and open the **New Project** dialog box.  
  
2.  In Visual C# and the Windows category, select  the **Windows Forms Application** template.  
  
3.  Name the new project `WFHost`.  
  
4.  For the location, specify the same top-level folder that contains the MyControls project.  
  
5.  Click **OK** to create the project.  
  
 You also need to add references to the DLL that contains `MyControl1` and other assemblies.  
  
1.  Right-click the project name in Solution Explorer, and select **Add Reference**.  
  
2.  Click the **Browse** tab, and browse to the folder that contains MyControls.dll. For this walkthrough, this folder is MyControls\bin\Debug.  
  
3.  Select MyControls.dll, and then click **OK**.  
  
4.  Add references to the following assemblies.  
  
    -   PresentationCore  
  
    -   PresentationFramework  
  
    -   System.Xaml  
  
    -   WindowsBase  
  
    -   WindowsFormsIntegration  
  
### Implementing the User Interface for the Application  
 The UI for the Windows Form application contains several controls to interact with the WPF composite control.  
  
1.  Open Form1 in the Windows Form Designer.  
  
2.  Enlarge the form to accommodate the controls.  
  
3.  In the upper-right corner of the form, add a <xref:System.Windows.Forms.Panel?displayProperty=nameWithType> control to hold the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] composite control.  
  
4.  Add the following <xref:System.Windows.Forms.GroupBox?displayProperty=nameWithType> controls to the form.  
  
    |Name|Text|  
    |----------|----------|  
    |groupBox1|Background Color|  
    |groupBox2|Foreground Color|  
    |groupBox3|Font Size|  
    |groupBox4|Font Family|  
    |groupBox5|Font Style|  
    |groupBox6|Font Weight|  
    |groupBox7|Data from control|  
  
5.  Add the following <xref:System.Windows.Forms.RadioButton?displayProperty=nameWithType> controls to the <xref:System.Windows.Forms.GroupBox?displayProperty=nameWithType> controls.  
  
    |GroupBox|Name|Text|  
    |--------------|----------|----------|  
    |groupBox1|radioBackgroundOriginal|Original|  
    |groupBox1|radioBackgroundLightGreen|LightGreen|  
    |groupBox1|radioBackgroundLightSalmon|LightSalmon|  
    |groupBox2|radioForegroundOriginal|Original|  
    |groupBox2|radioForegroundRed|Red|  
    |groupBox2|radioForegroundYellow|Yellow|  
    |groupBox3|radioSizeOriginal|Original|  
    |groupBox3|radioSizeTen|10|  
    |groupBox3|radioSizeTwelve|12|  
    |groupBox4|radioFamilyOriginal|Original|  
    |groupBox4|radioFamilyTimes|Times New Roman|  
    |groupBox4|radioFamilyWingDings|WingDings|  
    |groupBox5|radioStyleOriginal|Normal|  
    |groupBox5|radioStyleItalic|Italic|  
    |groupBox6|radioWeightOriginal|Original|  
    |groupBox6|radioWeightBold|Bold|  
  
6.  Add the following <xref:System.Windows.Forms.Label?displayProperty=nameWithType> controls to the last <xref:System.Windows.Forms.GroupBox?displayProperty=nameWithType>. These controls display the data returned by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] composite control.  
  
    |GroupBox|Name|Text|  
    |--------------|----------|----------|  
    |groupBox7|lblName|Name:|  
    |groupBox7|lblAddress|Street Address:|  
    |groupBox7|lblCity|City:|  
    |groupBox7|lblState|State:|  
    |groupBox7|lblZip|Zip:|  
  
### Initializing the Form  
 You generally implement the hosting code in the form's <xref:System.Windows.Forms.Form.Load> event handler. The following code shows the <xref:System.Windows.Forms.Form.Load> event handler, a handler for the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] composite control’s <xref:System.Windows.FrameworkElement.Loaded> event, and declarations for several global variables that are used later.  
  
 In the Windows Forms Designer, double-click the form to create a <xref:System.Windows.Forms.Form.Load> event handler. At the top of Form1.cs, add the following `using` statements.  
  
 [!code-csharp[WindowsFormsHostingWpfControl#10](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/WFHost/Form1.cs#10)]  
  
 Replace the contents of the existing `Form1` class with the following code.  
  
 [!code-csharp[WindowsFormsHostingWpfControl#2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/WFHost/Form1.cs#2)]  
  
 The `Form1_Load` method in the preceding code shows the general procedure for hosting a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control:  
  
1.  Create a new <xref:System.Windows.Forms.Integration.ElementHost> object.  
  
2.  Set the control's <xref:System.Windows.Forms.Control.Dock%2A> property to <xref:System.Windows.Forms.DockStyle.Fill?displayProperty=nameWithType>.  
  
3.  Add the <xref:System.Windows.Forms.Integration.ElementHost> control to the <xref:System.Windows.Forms.Panel> control's <xref:System.Windows.Forms.Control.Controls%2A> collection.  
  
4.  Create an instance of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control.  
  
5.  Host the composite control on the form by assigning the control to the <xref:System.Windows.Forms.Integration.ElementHost> control's <xref:System.Windows.Forms.Integration.ElementHost.Child%2A> property.  
  
 The remaining two lines in the `Form1_Load` method attach handlers to two control events:  
  
-   `OnButtonClick` is a custom event that is fired by the composite control when the user clicks the **OK** or **Cancel** button. You handle the event to get the user's response and to collect any data that the user specified.  
  
-   <xref:System.Windows.FrameworkElement.Loaded> is a standard event that is raised by a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control when it is fully loaded. The event is used here because the example needs to initialize several global variables using properties from the control. At the time of the form's <xref:System.Windows.Forms.Form.Load> event, the control is not fully loaded and those values are still set to `null`. You need to wait until the control’s <xref:System.Windows.FrameworkElement.Loaded> event occurs before you can access those properties.  
  
 The <xref:System.Windows.FrameworkElement.Loaded> event handler is shown in the preceding code. The `OnButtonClick` handler is discussed in the next section.  
  
### Handling OnButtonClick  
 The `OnButtonClick` event occurs when the user clicks the **OK** or **Cancel** button.  
  
 The event handler checks the event argument's `IsOK` field to determine which button was clicked. The `lbl`*data* variables correspond to the <xref:System.Windows.Forms.Label> controls that were discussed earlier. If the user clicks the **OK** button, the data from the control’s <xref:System.Windows.Controls.TextBox> controls is assigned to the corresponding <xref:System.Windows.Forms.Label> control. If the user clicks **Cancel**, the <xref:System.Windows.Forms.Label.Text%2A> values are set to the default strings.  
  
 Add the following button click event handler code to the `Form1` class.  
  
 [!code-csharp[WindowsFormsHostingWpfControl#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/WFHost/Form1.cs#3)]  
  
 Build and run the application. Add some text in the WPF composite control and then click **OK**. The text appears in the labels. At this point, code has not been added to handle the radio buttons.  
  
### Modifying the Appearance of the Control  
 The <xref:System.Windows.Forms.RadioButton> controls on the form will enable the user to change the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] composite control’s foreground and background colors as well as several font properties. The background color is exposed by the <xref:System.Windows.Forms.Integration.ElementHost> object. The remaining properties are exposed as custom properties of the control.  
  
 Double-click each <xref:System.Windows.Forms.RadioButton> control on the form to create <xref:System.Windows.Forms.RadioButton.CheckedChanged> event handlers. Replace the <xref:System.Windows.Forms.RadioButton.CheckedChanged> event handlers with the following code.  
  
 [!code-csharp[WindowsFormsHostingWpfControl#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WindowsFormsHostingWpfControl/CSharp/WFHost/Form1.cs#4)]  
  
 Build and run the application. Click the different radio buttons to see the effect on the WPF composite control.  
  
## See Also  
 <xref:System.Windows.Forms.Integration.ElementHost>  
 <xref:System.Windows.Forms.Integration.WindowsFormsHost>  
 [WPF Designer](http://msdn.microsoft.com/library/c6c65214-8411-4e16-b254-163ed4099c26)  
 [Walkthrough: Hosting a Windows Forms Composite Control in WPF](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-windows-forms-composite-control-in-wpf.md)  
 [Walkthrough: Hosting a 3-D WPF Composite Control in Windows Forms](../../../../docs/framework/wpf/advanced/walkthrough-hosting-a-3-d-wpf-composite-control-in-windows-forms.md)
