---
title: "Label Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "templates [WPF], Label"
  - "parts [WPF], Label"
  - "ControlTemplate [WPF], Label"
  - "styles [WPF], Label"
  - "Label [WPF], styles and templates"
  - "states [WPF], Label"
ms.assetid: c1d5359a-8e4a-4925-ab3e-e92bf6694859
---
# Label Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.Label> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](../../../desktop-wpf/themes/how-to-create-apply-template.md).  
  
## Label Parts  
 The <xref:System.Windows.Controls.Label> control does not have any named parts.  
  
## Label States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Label> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## Label ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Label> control.  
  
 [!code-xaml[ControlTemplateExamples#Label](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/label.xaml#label)]  
  
 The <xref:System.Windows.Controls.ControlTemplate> uses one or more of the following resources.  
  
 [!code-xaml[ControlTemplateExamples#Resources](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]  
  
 For the complete sample, see [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).  
  
## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Styles and Templates](control-styles-and-templates.md)
- [Control Customization](control-customization.md)
- [Styling and Templating](../../../desktop-wpf/fundamentals/styles-templates-overview.md)
- [Create a template for a control](../../../desktop-wpf/themes/how-to-create-apply-template.md)
