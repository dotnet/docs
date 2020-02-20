---
title: "Slider Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "parts [WPF], Slider"
  - "states [WPF], Slider"
  - "Slider [WPF], styles and templates"
  - "styles [WPF], Slider"
  - "templates [WPF], Slider"
  - "ControlTemplate [WPF], Slider"
ms.assetid: d89aa97b-075a-4752-9c41-9679df65c491
---
# Slider Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.Slider> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](../../../desktop-wpf/themes/how-to-create-apply-template.md).  
  
## Slider Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.Slider> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_Track|<xref:System.Windows.Controls.Primitives.Track>|The container for the element that indicates the position of the <xref:System.Windows.Controls.Slider>.|  
|PART_SelectionRange|<xref:System.Windows.FrameworkElement>|The element that displays a selection range along the <xref:System.Windows.Controls.Slider>.  The selection range is visible only if the <xref:System.Windows.Controls.Slider.IsSelectionRangeEnabled%2A> property is `true`.|  
  
## Slider States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Slider> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|----------------------|---------------------------|-----------------|  
|Normal|CommonStates|The default state.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|  
|Disabled|CommonStates|The control is disabled.|  
|Focused|FocusStates|The control has focus.|  
|Unfocused|FocusStates|The control does not have focus.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## Slider ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Slider> control.  
  
 [!code-xaml[ControlTemplateExamples#Slider](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/slider.xaml#slider)]  
  
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
