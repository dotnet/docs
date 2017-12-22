---
title: "Calendar Styles and Templates"
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
  - "styles [WPF], Calendar"
  - "templates [WPF], Calendar"
  - "states [WPF], Calendar"
  - "parts [WPF], Calendar"
  - "Calendar [WPF], styles and templates"
  - "ControlTemplate [WPF], Calendar"
ms.assetid: f4fcf046-7a8f-41b8-b5a8-534b64e0345c
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Calendar Styles and Templates
This topic describes the styles and templates for the <xref:System.Windows.Controls.Calendar> control. You can modify the default <xref:System.Windows.Controls.ControlTemplate> to give the control a unique appearance. For more information, see [Customizing the Appearance of an Existing Control by Creating a ControlTemplate](../../../../docs/framework/wpf/controls/customizing-the-appearance-of-an-existing-control.md).  
  
## Calendar Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.Calendar> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_CalendarItem|<xref:System.Windows.Controls.Primitives.CalendarItem>|The currently displayed month or year on the <xref:System.Windows.Controls.Calendar>.|  
|PART_Root|<xref:System.Windows.Controls.Panel>|The panel that contains the <xref:System.Windows.Controls.Primitives.CalendarItem>.|  
  
## Calendar States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Calendar> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|----------------------|---------------------------|-----------------|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## CalendarItem Parts  
 The following table lists the named parts for the <xref:System.Windows.Controls.Primitives.CalendarItem> control.  
  
|Part|Type|Description|  
|-|-|-|  
|PART_Root|<xref:System.Windows.FrameworkElement>|The root of the control.|  
|PART_PreviousButton|<xref:System.Windows.Controls.Button>|The button that displays the previous page of the calendar when it is clicked.|  
|PART_NextButton|<xref:System.Windows.Controls.Button>|The button that displays the next page of the calendar when it is clicked.|  
|PART_HeaderButton|<xref:System.Windows.Controls.Button>|The button that allows switching between month mode, year mode, and decade mode.|  
|PART_MonthView|<xref:System.Windows.Controls.Grid>|Hosts the content when in month mode.|  
|PART_YearView|<xref:System.Windows.Controls.Grid>|Hosts the content when in year or decade mode.|  
|PART_DisabledVisual|<xref:System.Windows.FrameworkElement>|The overlay for the disabled state.|  
|DayTitleTemplate|<xref:System.Windows.DataTemplate>|The <xref:System.Windows.DataTemplate> that describes the visual structure.|  
  
## CalendarItem States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.CalendarItem> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal State|CommonStates|The default state.|  
|Disabled State|CommonStates|The state of the calendar when the <xref:System.Windows.UIElement.IsEnabled%2A> property is `false`.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## CalendarDayButton Parts  
 The <xref:System.Windows.Controls.Primitives.CalendarDayButton> control does not have any named parts.  
  
## CalendarDayButton States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.CalendarDayButton> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|Disabled|CommonStates|The <xref:System.Windows.Controls.Primitives.CalendarDayButton> is disabled.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the <xref:System.Windows.Controls.Primitives.CalendarDayButton>.|  
|Pressed|CommonStates|The <xref:System.Windows.Controls.Primitives.CalendarDayButton> is pressed.|  
|Selected|SelectionStates|The button is selected.|  
|Unselected|SelectionStates|The button is not selected.|  
|CalendarButtonFocused|CalendarButtonFocusStates|The button has focus.|  
|CalendarButtonUnfocused|CalendarButtonFocusStates|The button does not have focus.|  
|Focused|FocusStates|The button has focus.|  
|Unfocused|FocusStates|The button does not have focus.|  
|Active|ActiveStates|The button is active.|  
|Inactive|ActiveStates|The button is inactive.|  
|RegularDay|DayStates|The button does not represent <xref:System.DateTime.Today%2A?displayProperty=nameWithType>.|  
|Today|DayStates|The button represents <xref:System.DateTime.Today%2A?displayProperty=nameWithType>.|  
|NormalDay|BlackoutDayStates|The button represents a day that can be selected.|  
|BlackoutDay|BlackoutDayStates|The button represents a day that cannot be selected.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## CalendarButton Parts  
 The <xref:System.Windows.Controls.Primitives.CalendarButton> control does not have any named parts.  
  
## CalendarButton States  
 The following table lists the visual states for the <xref:System.Windows.Controls.Primitives.CalendarButton> control.  
  
|VisualState Name|VisualStateGroup Name|Description|  
|-|-|-|  
|Normal|CommonStates|The default state.|  
|Disabled|CommonStates|The <xref:System.Windows.Controls.Primitives.CalendarButton> is disabled.|  
|MouseOver|CommonStates|The mouse pointer is positioned over the <xref:System.Windows.Controls.Primitives.CalendarButton>.|  
|Pressed|CommonStates|The <xref:System.Windows.Controls.Primitives.CalendarButton> is pressed.|  
|Selected|SelectionStates|The button is selected.|  
|Unselected|SelectionStates|The button is not selected.|  
|CalendarButtonFocused|CalendarButtonFocusStates|The button has focus.|  
|CalendarButtonUnfocused|CalendarButtonFocusStates|The button does not have focus.|  
|Focused|FocusStates|The button has focus.|  
|Unfocused|FocusStates|The button does not have focus.|  
|Active|ActiveStates|The button is active.|  
|Inactive|ActiveStates|The button is inactive.|  
|Valid|ValidationStates|The control uses the <xref:System.Windows.Controls.Validation> class and the <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `false`.|  
|InvalidFocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control has focus.|  
|InvalidUnfocused|ValidationStates|The <xref:System.Windows.Controls.Validation.HasError%2A?displayProperty=nameWithType> attached property is `true` has the control does not have focus.|  
  
## Calendar ControlTemplate Example  
 The following example shows how to define a <xref:System.Windows.Controls.ControlTemplate> for the <xref:System.Windows.Controls.Calendar> control and associated types.  
  
 [!code-xaml[ControlTemplateExamples#Calendar](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ControlTemplateExamples/CS/resources/calendar.xaml#calendar)]  
  
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
