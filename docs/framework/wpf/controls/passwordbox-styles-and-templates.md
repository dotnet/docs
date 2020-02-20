---
title: "PasswordBox Styles and Templates"
ms.date: "03/30/2017"
helpviewer_keywords:
  - "styles [WPF], PasswordBox"
  - "templates [WPF], PasswordBox"
  - "ControlTemplate [WPF], PasswordBox"
  - "states [WPF], PasswordBox"
  - "PasswordBox [WPF], styles and templates"
  - "parts [WPF], PasswordBox"
ms.assetid: deb52107-959f-4a60-b303-d21a0a933060
---

# PasswordBox Styles and Templates

This topic describes the styles and templates for the <xref:System.Windows.Controls.PasswordBox> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Create a template for a control](../../../desktop-wpf/themes/how-to-create-apply-template.md).

## PasswordBox Parts

The following table lists the named parts for the <xref:System.Windows.Controls.PasswordBox> control.

|Part|Type|Description|
|-|-|-|
|PART_ContentHost|<xref:System.Windows.FrameworkElement>|A visual element that can contain a <xref:System.Windows.FrameworkElement>. The text of the <xref:System.Windows.Controls.PasswordBox> is displayed in this element.|

## PasswordBox States

The following table lists the visual states for the <xref:System.Windows.Controls.PasswordBox> control.

|VisualState Name|VisualStateGroup Name|Description|
|-|-|-|
|Normal|CommonStates|The default state.|
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|
|Disabled|CommonStates|The control is disabled.|
|Focused|FocusStates|The control has focus.|
|Unfocused|FocusStates|The control does not have focus.|
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|

## PasswordBox ControlTemplate Example

The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.PasswordBox> control.

[!code-xaml[ControlTemplateExamples#PasswordBox](~/samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/textbox.xaml#passwordbox)]

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
