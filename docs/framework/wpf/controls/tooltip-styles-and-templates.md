---
title: "ToolTip Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "parts [WPF], ToolTip"
  - "styles [WPF], ToolTip"
  - "states [WPF], ToolTip"
  - "ToolTip [WPF], styles and templates"
  - "ControlTemplate [WPF], ToolTip"
  - "templates [WPF], ToolTip"
ms.assetid: 405fe385-4de9-49ee-a448-d8f4d1f740dd
---
# ToolTip Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.ToolTip> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](customizing-the-appearance-of-an-existing-control.md).  
  
## ToolTip Parts  
 The <xref:System.Windows.Controls.ToolTip> control does not have any named parts.  
  
## ToolTip States  
 The following table lists the visual states for the <xref:System.Windows.Controls.ToolTip> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Closed|OpenStates|The default state.|  
|Open|OpenStates|The <xref:System.Windows.Controls.ToolTip> is visible.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## ToolTip ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.ToolTip> control.  
  
 [!code-xaml[ControlTemplateExamples#ToolTip](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/tooltip.xaml#tooltip)]  
  
 The preceding example uses one or more of the following resources.  
  
 [!code-xaml[ControlTemplateExamples#Resources](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]  
  
 For the complete sample, see [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).  
  
## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Styles and Templates](control-styles-and-templates.md)
- [Control Customization](control-customization.md)
- [Styling and Templating](styling-and-templating.md)
- [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](customizing-the-appearance-of-an-existing-control.md)
