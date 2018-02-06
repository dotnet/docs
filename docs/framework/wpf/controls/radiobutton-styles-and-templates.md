---
title: "RadioButton Styles and Templates"
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
  - "styles [WPF], RadioButton"
  - "RadioButton [WPF], styles and templates"
  - "ControlTemplate [WPF], RadioButton"
  - "states [WPF], RadioButton"
  - "templates [WPF], RadioButton"
  - "parts [WPF], RadioButton"
ms.assetid: 9acf93f7-dd2f-4010-8ce0-1edd81c52ae2
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# RadioButton Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.RadioButton> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](../../../../docs/framework/wpf/controls/customizing-the-appearance-of-an-existing-control.md).  
  
## RadioButton Parts  
 The <xref:System.Windows.Controls.RadioButton> control does not have any named parts.  
  
## RadioButton States  
 The following table lists the visual states for the <xref:System.Windows.Controls.RadioButton> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|----------------------|---------------------------|-----------------|  
|Normal|CommonStates|The default state.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the control.|  
|Pressed|CommonStates|The control is pressed.|  
|Disabled|CommonStates|The control is disabled.|  
|Focused|FocusStates|The control has focus.|  
|Unfocused|FocusStates|The control does not have focus.|  
|Checked|CheckStates|<xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> is `true`.|  
|Unchecked|CheckStates|<xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> is `false`.|  
|Indeterminate|CheckStates|<xref:System.Windows.Controls.Primitives.ToggleButton.IsThreeState%2A> is `true`, and <xref:System.Windows.Controls.Primitives.ToggleButton.IsChecked%2A> is `null`.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## RadioButton ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.RadioButton> control.  
  
 [!code-xaml[ControlTemplateExamples#RadioButton](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/radiobutton.xaml#radiobutton)]  
  
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
