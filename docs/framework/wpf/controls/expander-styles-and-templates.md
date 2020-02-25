---
title: "Expander Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "styles [WPF], Expander"
  - "ControlTemplate [WPF], Expander"
  - "templates [WPF], Expander"
  - "Expander [WPF], styles and templates"
  - "states [WPF], Expander"
  - "parts [WPF], Expander"
ms.assetid: da2e5a1c-5230-4c21-98a5-59c7895facd7
---
# Expander Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.Expander> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](../../../desktop-wpf/themes/how-to-create-apply-template.md).  
  
## Expander Parts  
 The <xref:System.Windows.Controls.Expander> control does not have any named parts.  
  
## Expander States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Expander> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|  
|Disabled|CommonStates|The control is disabled.|  
|Focused|FocusStates|The control has focus.|  
|Unfocused|FocusStates|The control does not have focus.|  
|Expanded|ExpansionStates|The control is expanded.|  
|Collapsed|ExpansionStates|The control is not expanded.|  
|ExpandDown|ExpandDirectionStates|The control expands down.|  
|ExpandUp|ExpandDirectionStates|The control expands up.|  
|ExpandLeft|ExpandDirectionStates|The control expands left.|  
|ExpandRight|ExpandDirectionStates|The control expands right.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## Expander ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Expander> control.  
  
 [!code-xaml[ControlTemplateExamples#Expander](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/expander.xaml#expander)]  
  
 The preceding example uses one or more of the following resources.  
  
 [!code-xaml[ControlTemplateExamples#Resources](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]  
  
 For the complete sample, see [Styling with ControlTemplates Sample](https://github.com/Microsoft/WPF-Samples/tree/master/Styles%20&%20Templates/IntroToStylingAndTemplating).  
  
## See also

- <xref:System.Windows.FrameworkElement.Style%2A>
- <xref:System.Windows.Controls.ControlTemplate>
- [Control Styles and Templates](control-styles-and-templates.md)
- [Control Customization](control-customization.md)
- [Styling and Templating](../../../desktop-wpf/fundamentals/styles-templates-overview.md)
- [Create a template for a control](../../../desktop-wpf/themes/how-to-create-apply-template.md)
