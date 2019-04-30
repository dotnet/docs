---
title: "GroupBox Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "ControlTemplate [WPF], GroupBox"
  - "parts [WPF], GroupBox"
  - "GroupBox [WPF], styles and templates"
  - "states [WPF], GroupBox"
  - "styles [WPF], GroupBox"
  - "templates [WPF], GroupBox"
ms.assetid: 33df7037-0a1b-476f-b9d0-41566a777699
---
# GroupBox Styles and Templates
<a name="introduction"></a> This topic describes the styles and templates for the <xref:System.Windows.Controls.GroupBox> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](customizing-the-appearance-of-an-existing-control.md).  
  
<a name="groupbox_parts"></a>   
## GroupBox Parts  
 The <xref:System.Windows.Controls.GroupBox> control does not have any named parts.  
  
<a name="groupbox_states"></a>   
## GroupBox States  
 The following table lists the visual states for the <xref:System.Windows.Controls.GroupBox> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
<a name="groupbox_controltemplate_example"></a>   
## GroupBox ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.GroupBox> control.  
  
 [!code-xaml[ControlTemplateExamples#GroupBox](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/groupbox.xaml#groupbox)]  
  
 The <xref:System.Windows.Controls.ControlTemplate> uses one or more of the following resources.  
  
 [!code-xaml[ControlTemplateExamples#Resources](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]  
  
 For the complete sample, see [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).  
  
## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Styles and Templates](control-styles-and-templates.md)
- [Control Customization](control-customization.md)
- [Styling and Templating](styling-and-templating.md)
- [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](customizing-the-appearance-of-an-existing-control.md)
