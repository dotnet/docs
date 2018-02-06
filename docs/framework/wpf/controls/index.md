---
title: "Controls"
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
  - "controls [WPF], about WPF controls"
ms.assetid: 3f255a8a-35a8-4712-9065-472ff7d75599
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Controls
<a name="introduction"></a>
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] ships with many of the common UI components that are used in almost every Windows application, such as <xref:System.Windows.Controls.Button>, <xref:System.Windows.Controls.Label>, <xref:System.Windows.Controls.TextBox>, <xref:System.Windows.Controls.Menu>, and <xref:System.Windows.Controls.ListBox>. Historically, these objects have been referred to as controls. While the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] SDK continues to use the term "control" to loosely mean any class that represents a visible object in an application, it is important to note that a class does not need to inherit from the <xref:System.Windows.Controls.Control> class to have a visible presence. Classes that inherit from the <xref:System.Windows.Controls.Control> class contain a <xref:System.Windows.Controls.ControlTemplate>, which allows the consumer of a control to radically change the control's appearance without having to create a new subclass.  This topic discusses how controls (both those that do inherit from the <xref:System.Windows.Controls.Control> class and those that do not) are commonly used in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  

<a name="creating_an_instance_of_a_control"></a>   
## Creating an Instance of a Control  
 You can add a control to an application by using either [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] or code.  The following example shows how to create a simple application that asks a user for their first and last name.  This example creates six controls: two labels, two text boxes, and two buttons, in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)]. All controls can be created similarly.  
  
 [!code-xaml[ControlsOverview#1](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/Window1.xaml#1)]  
  
 The following example creates the same application in code. For brevity, the creation of the <xref:System.Windows.Controls.Grid>, `grid1`, has been excluded from the sample. `grid1` has the same column and row definitions as shown in the preceding [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] example.  
  
 [!code-csharp[ControlsOverview#2](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/AppInCode.xaml.cs#2)]
 [!code-vb[ControlsOverview#2](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ControlsOverview/VisualBasic/AppInCode.xaml.vb#2)]  
  
<a name="changing_the_appearance_of_a_control"></a>   
## Changing the Appearance of a Control  
 It is common to change the appearance of a control to fit the look and feel of your application. You can change the appearance of a control by doing one of the following, depending on what you want to accomplish:  
  
-   Change the value of a property of the control.  
  
-   Create a <xref:System.Windows.Style> for the control.  
  
-   Create a new <xref:System.Windows.Controls.ControlTemplate> for the control.  
  
### Changing a Control's Property Value  
 Many controls have properties that allow you to change how the control appears, such as the <xref:System.Windows.Controls.Control.Background%2A> of a <xref:System.Windows.Controls.Button>. You can set the value properties in both [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] and code. The following example sets the <xref:System.Windows.Controls.Control.Background%2A>, <xref:System.Windows.Controls.Control.FontSize%2A>, and <xref:System.Windows.Controls.Control.FontWeight%2A> properties on a <xref:System.Windows.Controls.Button> in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)].  
  
 [!code-xaml[ControlsOverview#3](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/AppInCode.xaml#3)]  
  
 The following example sets the same properties in code.  
  
 [!code-csharp[ControlsOverview#4](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/AppInCode.xaml.cs#4)]
 [!code-vb[ControlsOverview#4](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ControlsOverview/VisualBasic/AppInCode.xaml.vb#4)]  
  
### Creating a Style for a Control  
 [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] gives you the ability to specify the appearance of controls wholesale, instead of setting properties on each instance in the application, by creating a <xref:System.Windows.Style>. The following example creates a <xref:System.Windows.Style> that is applied to each <xref:System.Windows.Controls.Button> in the application. <xref:System.Windows.Style> definitions are typically defined in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] in a <xref:System.Windows.ResourceDictionary>, such as the <xref:System.Windows.FrameworkElement.Resources%2A> property of the <xref:System.Windows.FrameworkElement>.  
  
 [!code-xaml[ControlsOverview#5](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/AppInCode.xaml#5)]  
  
 You can also apply a style to only certain controls of a specific type by assigning a key to the style and specifying that key in the `Style` property of your control.  For more information about styles, see [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md).  
  
### Creating a ControlTemplate  
 A <xref:System.Windows.Style> allows you to set properties on multiple controls at a time, but sometimes you might want to customize the appearance of a <xref:System.Windows.Controls.Control> beyond what you can do by creating a <xref:System.Windows.Style>. Classes that inherit from the <xref:System.Windows.Controls.Control> class have a <xref:System.Windows.Controls.ControlTemplate>, which defines the structure and appearance of a <xref:System.Windows.Controls.Control>. The <xref:System.Windows.Controls.Control.Template%2A> property of a <xref:System.Windows.Controls.Control> is public, so you can give a <xref:System.Windows.Controls.Control> a <xref:System.Windows.Controls.ControlTemplate> that is different than its default. You can often specify a new <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.Control> instead of inheriting from a control to customize the appearance of a <xref:System.Windows.Controls.Control>.  
  
 Consider the very common control, <xref:System.Windows.Controls.Button>.  The primary behavior of a <xref:System.Windows.Controls.Button> is to enable an application to take some action when the user clicks it.  By default, the <xref:System.Windows.Controls.Button> in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] appears as a raised rectangle.  While developing an application, you might want to take advantage of the behavior of a <xref:System.Windows.Controls.Button>--that is, by handling the button's click event--but you might change the button's appearance beyond what you can do by changing the button's properties.  In this case, you can create a new <xref:System.Windows.Controls.ControlTemplate>.  
  
 The following example creates a <xref:System.Windows.Controls.ControlTemplate> for a <xref:System.Windows.Controls.Button>.  The <xref:System.Windows.Controls.ControlTemplate> creates a <xref:System.Windows.Controls.Button> with rounded corners and a gradient background.  The <xref:System.Windows.Controls.ControlTemplate> contains a <xref:System.Windows.Controls.Border> whose <xref:System.Windows.Controls.Border.Background%2A> is a <xref:System.Windows.Media.LinearGradientBrush> with two <xref:System.Windows.Media.GradientStop> objects.  The first <xref:System.Windows.Media.GradientStop> uses data binding to bind the <xref:System.Windows.Media.GradientStop.Color%2A> property of the <xref:System.Windows.Media.GradientStop> to the color of the button's background.  When you set the <xref:System.Windows.Controls.Control.Background%2A> property of the <xref:System.Windows.Controls.Button>, the color of that value will be used as the first <xref:System.Windows.Media.GradientStop>. For more information about data binding, see [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md). The example also creates a <xref:System.Windows.Trigger> that changes the appearance of the <xref:System.Windows.Controls.Button> when <xref:System.Windows.Controls.Primitives.ButtonBase.IsPressed%2A> is `true`.  
  
 [!code-xaml[ControlsOverview#6](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/Window1.xaml#6)]  
[!code-xaml[ControlsOverview#7](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/AppInCode.xaml#7)]  
  
> [!NOTE]
>  The <xref:System.Windows.Controls.Control.Background%2A> property of the <xref:System.Windows.Controls.Button> must be set to a <xref:System.Windows.Media.SolidColorBrush> for the example to work properly.  
  
<a name="subscribing_to_events"></a>   
## Subscribing to Events  
 You can subscribe to a control's event by using either [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] or code, but you can only handle an event in code.  The following example shows how to subscribe to the `Click` event of a <xref:System.Windows.Controls.Button>.  
  
 [!code-xaml[ControlsOverview#10](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/Window1.xaml#10)]  
  
 [!code-csharp[ControlsOverview#8](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/AppInCode.xaml.cs#8)]
 [!code-vb[ControlsOverview#8](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ControlsOverview/VisualBasic/AppInCode.xaml.vb#8)]  
  
 The following example handles the `Click` event of a <xref:System.Windows.Controls.Button>.  
  
 [!code-csharp[ControlsOverview#9](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlsOverview/CSharp/AppInCode.xaml.cs#9)]
 [!code-vb[ControlsOverview#9](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/ControlsOverview/VisualBasic/AppInCode.xaml.vb#9)]  
  
<a name="rich_content_in_controls"></a>   
## Rich Content in Controls  
 Most classes that inherit from the <xref:System.Windows.Controls.Control> class have the capacity to contain rich content. For example, a <xref:System.Windows.Controls.Label> can contain any object, such as a string, an <xref:System.Windows.Controls.Image>, or a <xref:System.Windows.Controls.Panel>.  The following classes provide support for rich content and act as base classes for most of the controls in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)].  
  
-   <xref:System.Windows.Controls.ContentControl>-- Some examples of classes that inherit from this class are <xref:System.Windows.Controls.Label>, <xref:System.Windows.Controls.Button>, and <xref:System.Windows.Controls.ToolTip>.  
  
-   <xref:System.Windows.Controls.ItemsControl>-- Some examples of classes that inherit from this class are <xref:System.Windows.Controls.ListBox>, <xref:System.Windows.Controls.Menu>, and <xref:System.Windows.Controls.Primitives.StatusBar>.  
  
-   <xref:System.Windows.Controls.HeaderedContentControl>-- Some examples of classes that inherit from this class are <xref:System.Windows.Controls.TabItem>, <xref:System.Windows.Controls.GroupBox>, and <xref:System.Windows.Controls.Expander>.  
  
-   <xref:System.Windows.Controls.HeaderedItemsControl>--Some examples of classes that inherit from this class are <xref:System.Windows.Controls.MenuItem>, <xref:System.Windows.Controls.TreeViewItem>, and <xref:System.Windows.Controls.ToolBar>.  
  
-  
  
 For more information about these base classes, see [WPF Content Model](../../../../docs/framework/wpf/controls/wpf-content-model.md).  
  
## See Also  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [Controls by Category](../../../../docs/framework/wpf/controls/controls-by-category.md)  
 [Control Library](../../../../docs/framework/wpf/controls/control-library.md)  
 [Data Templating Overview](../../../../docs/framework/wpf/data/data-templating-overview.md)  
 [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md)  
 [Input](../../../../docs/framework/wpf/advanced/input-wpf.md)  
 [Enable a Command](../../../../docs/framework/wpf/advanced/how-to-enable-a-command.md)  
 [Walkthroughs: Create a Custom Animated Button](../../../../docs/framework/wpf/controls/walkthroughs-create-a-custom-animated-button.md)  
 [Control Customization](../../../../docs/framework/wpf/controls/control-customization.md)
