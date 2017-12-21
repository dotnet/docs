---
title: "DatePicker Styles and Templates"
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
  - "ControlTemplate [WPF], DatePicker"
  - "DatePicker [WPF], styles and templates"
  - "templates [WPF], DatePicker"
  - "parts [WPF], DatePicker"
  - "styles [WPF], DatePicker"
  - "states [WPF], DatePicker"
ms.assetid: c430a657-692f-44bd-a549-2341f92d6115
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# DatePicker Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.DatePicker> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](../../../../docs/framework/wpf/controls/customizing-the-appearance-of-an-existing-control.md).  
  
## DatePicker Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.DatePicker> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_Root|<xref:System.Windows.Controls.Grid>|The root of the control.|  
|PART_Button|<xref:System.Windows.Controls.Button>|The button that opens and closes the <xref:System.Windows.Controls.Calendar>.|  
|PART_TextBox|<xref:System.Windows.Controls.Primitives.DatePickerTextBox>|The text box that allows you to input a date.|  
|PART_Popup|<xref:System.Windows.Controls.Primitives.Popup>|The popup for the <xref:System.Windows.Controls.DatePicker> control.|  
  
## DatePicker States  
 The following table lists the visual states for the <xref:System.Windows.Controls.DatePicker> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|Disabled|CommonStates|The <xref:System.Windows.Controls.DatePicker> is disabled.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## DatePickerTextBox Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.DatePickerTextBox> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_Watermark|<xref:System.Windows.Controls.ContentControl>|The element that contains the initial text in the <xref:System.Windows.Controls.DatePicker>.|  
|PART_ContentElement|<xref:System.Windows.FrameworkElement>|A visual element that can contain a <xref:System.Windows.FrameworkElement>. The text of the <xref:System.Windows.Controls.TextBox> is displayed in this element.|  
  
## DatePickerTextBox States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.DatePickerTextBox> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|Disabled|CommonStates|The <xref:System.Windows.Controls.Primitives.DatePickerTextBox> is disabled.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the <xref:System.Windows.Controls.Primitives.DatePickerTextBox>.|  
|ReadOnly|CommonStates|The user cannot change the text in the <xref:System.Windows.Controls.Primitives.DatePickerTextBox>.|  
|Focused|FocusStates|The control has focus.|  
|Unfocused|FocusStates|The control does not have focus.|  
|Watermarked|WatermarkStates|The control displays its initial text.  The <xref:System.Windows.Controls.Primitives.DatePickerTextBox> is in the state when the user has not entered text or selected a date.|  
|Unwatermarked|WatermarkStates|The user has entered text into the <xref:System.Windows.Controls.Primitives.DatePickerTextBox> or selected a date in the <xref:System.Windows.Controls.DatePicker>.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## DatePicker ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.DatePicker> control.  
  
 [!code-xaml[ControlTemplateExamples#DatePicker](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/datepicker.xaml#datepicker)]  
  
 The preceding example uses one or more of the following resources.  
  
 [!code-xaml[ControlTemplateExamples#Resources](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/shared.xaml#resources)]  
  
 For the complete sample, see [Styling with ControlTemplates Sample](http://go.microsoft.com/fwlink/?LinkID=160041).  
  
## See Also  
 <xref:System.Windows.FrameworkElement.Style%2A>  
 <xref:System.Windows.Controls.ControlTemplate>  
 [Control Styles and Templates](../../../../docs/framework/wpf/controls/control-styles-and-templates.md)  
 [Control Customization](../../../../docs/framework/wpf/controls/control-customization.md)  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](../../../../docs/framework/wpf/controls/customizing-the-appearance-of-an-existing-control.md)
