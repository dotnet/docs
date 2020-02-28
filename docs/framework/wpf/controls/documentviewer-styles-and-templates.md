---
title: "DocumentViewer Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "templates [WPF], DocumentViewer"
  - "DocumentViewer [WPF], styles and templates"
  - "states [WPF], DocumentViewer"
  - "ControlTemplate [WPF], DocumentViewer"
  - "parts [WPF], DocumentViewer"
  - "styles [WPF], DocumentViewer"
ms.assetid: 6bd4ff8f-ea6a-4084-ac58-e7a67446ce1c
---
# DocumentViewer Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.DocumentViewer> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](../../../desktop-wpf/themes/how-to-create-apply-template.md).  
  
## DocumentViewer Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.DocumentViewer> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_ContentHost|<xref:System.Windows.Controls.ScrollViewer>|The content and scrolling area.|  
|PART_FindToolBarHost|<xref:System.Windows.Controls.ContentControl>|The search box, at the bottom by default.|  
  
## DocumentViewer States  
 The following table lists the visual states for the <xref:System.Windows.Controls.DocumentViewer> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## DocumentViewer ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.DocumentViewer> control.  
  
 [!code-xaml[ControlTemplateExamples#DocumentViewer](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/documentviewer.xaml#documentviewer)]  
  
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
