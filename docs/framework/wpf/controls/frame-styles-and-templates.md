---
title: "Frame Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "parts [WPF], Frame"
  - "templates [WPF], Frame"
  - "ControlTemplate [WPF], Frame"
  - "Frame [WPF], styles and templates"
  - "states [WPF], Frame"
  - "styles [WPF], Frame"
ms.assetid: a01c32e2-c951-46a0-a82f-2614ca241f0b
---
# Frame Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.Frame> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](customizing-the-appearance-of-an-existing-control.md).  
  
## Frame Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.Frame> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_FrameCP|<xref:System.Windows.Controls.ContentPresenter>|The content area.|  
  
## Frame States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Frame> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## Frame ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Frame> control.  
  
 [!code-xaml[ControlTemplateExamples#Frame](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/frame.xaml#frame)]  
  
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
