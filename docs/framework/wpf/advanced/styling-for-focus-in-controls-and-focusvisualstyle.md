---
title: "Styling for Focus in Controls, and FocusVisualStyle"
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
  - "keyboard focus [WPF]"
  - "focus [WPF], visual styling"
  - "styles [WPF], focus visual style"
ms.assetid: 786ac576-011b-4d72-913b-558deccb9b35
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Styling for Focus in Controls, and FocusVisualStyle
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] provides two parallel mechanisms for changing the visual appearance of a control when it receives keyboard focus. The first mechanism is to use property setters for properties such as <xref:System.Windows.UIElement.IsKeyboardFocused%2A> within the style or template that is applied to the control. The second mechanism is to provide a separate style as the value of the <xref:System.Windows.FrameworkElement.FocusVisualStyle%2A> property; the "focus visual style" creates a separate visual tree for an adorner that draws on top of the control, rather than changing the visual tree of the control or other UI element by replacing it. This topic discusses the scenarios where each of these mechanisms is appropriate.  
   
  
<a name="Purpose"></a>   
## The Purpose of Focus Visual Style  
 The focus visual style feature provides a common "object model" for introducing visual user feedback based on keyboard navigation to any UI element. This is possible without applying a new template to the control, or knowing the specific template composition.  
  
 However, precisely because the focus visual style feature works without knowing the control templates, the visual feedback that can be displayed for a control using a focus visual style is necessarily limited. What the feature actually does is to overlay a different visual tree (an adorner) on top of the visual tree as created by a control's rendering through its template. You define this separate visual tree using a style that fills the <xref:System.Windows.FrameworkElement.FocusVisualStyle%2A> property.  
  
<a name="Default"></a>   
## Default Focus Visual Style Behavior  
 Focus visual styles act only when the focus action was initiated by the keyboard. Any mouse action or programmatic focus change disables the mode for focus visual styles. For more information about the distinctions between focus modes, see [Focus Overview](../../../../docs/framework/wpf/advanced/focus-overview.md).  
  
 The themes for controls include a default focus visual style behavior that becomes the focus visual style for all controls in the theme. This theme style is identified by the value of the static key <xref:System.Windows.SystemParameters.FocusVisualStyleKey%2A>. When you declare your own focus visual style at the application level, you replace this default style behavior from the themes. Alternatively, if you define the entire theme, then you should use this same key to define the style for the default behavior for your entire theme.  
  
 In the themes, the default focus visual style is generally very simple. The following is a rough approximation:  
  
```  
<Style x:Key="{x:Static SystemParameters.FocusVisualStyleKey}">  
  <Setter Property="Control.Template">  
    <Setter.Value>  
      <ControlTemplate>  
        <Rectangle StrokeThickness="1"  
          Stroke="Black"  
          StrokeDashArray="1 2"  
          SnapsToDevicePixels="true"/>  
      </ControlTemplate>  
    </Setter.Value>  
  </Setter>  
</Style>  
```  
  
<a name="When"></a>   
## When to Use Focus Visual Styles  
 Conceptually, the appearance of focus visual styles applied to controls should be coherent from control to control. One way to ensure coherence is to change the focus visual style only if you are composing an entire theme, where each control that is defined in the theme gets either the very same focus visual style, or some variation of a style that is visually related from control to control. Alternatively, you might use the same style (or similar styles) to style every keyboard-focusable element on a page or in a UI.  
  
 Setting <xref:System.Windows.FrameworkElement.FocusVisualStyle%2A> on individual control styles that are not part of a theme is not the intended usage of focus visual styles. This is because an inconsistent visual behavior between controls can lead to a confusing user experience regarding keyboard focus. If you are intending control-specific behaviors for keyboard focus that are deliberately not coherent across a theme, a much better approach is to use triggers in styles for individual input state properties, such as <xref:System.Windows.UIElement.IsFocused%2A> or <xref:System.Windows.UIElement.IsKeyboardFocused%2A>.  
  
 Focus visual styles act exclusively for keyboard focus. As such, focus visual styles are a type of accessibility feature. If you want UI changes for any type of focus, whether via mouse, keyboard, or programmatically, then you should not use focus visual styles, and should instead use setters and triggers in styles or templates that are working from the value of general focus properties such as `IsFocused` or `IsFocusWithin`.  
  
<a name="How"></a>   
## How to Create a Focus Visual Style  
 The style you create for a focus visual style should always have the <xref:System.Windows.Style.TargetType%2A> of <xref:System.Windows.Controls.Control>. The style should consist mainly of a <xref:System.Windows.Controls.ControlTemplate>. You do not specify the target type to be the type where the focus visual style is assigned to the <xref:System.Windows.FrameworkElement.FocusVisualStyle%2A>.  
  
 Because the target type is always <xref:System.Windows.Controls.Control>, you must style by using properties that are common to all controls (using properties of the <xref:System.Windows.Controls.Control> class and its base classes). You should create a template that will properly function as an overlay to a UI element and that will not obscure functional areas of the control. Generally, this means that the visual feedback should appear outside the control margins, or as temporary or unobtrusive effects that will not block the hit testing on the control where the focus visual style is applied. Properties that you can use in template binding that are useful for determining sizing and positioning of your overlay template include <xref:System.Windows.FrameworkElement.ActualHeight%2A>, <xref:System.Windows.FrameworkElement.ActualWidth%2A>, <xref:System.Windows.FrameworkElement.Margin%2A>, and <xref:System.Windows.Controls.Control.Padding%2A>.  
  
<a name="Alternatives"></a>   
## Alternatives to Using a Focus Visual Style  
 For situations where using a focus visual style is not appropriate, either because you are only styling single controls or because you want greater control over the control template, there are many other accessible properties and techniques that can create visual behavior in response to changes in focus.  
  
 Triggers, setters, and event setters are all discussed in detail in [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md). Routed event handling is discussed in [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md).  
  
### IsKeyboardFocused  
 If you are specifically interested in keyboard focus, the <xref:System.Windows.UIElement.IsKeyboardFocused%2A> dependency property can be used for a property <xref:System.Windows.Trigger>. A property trigger in either a style or template is a more appropriate technique for defining a keyboard focus behavior that is very specifically for a single control, and which might not visually match the keyboard focus behavior for other controls.  
  
 Another similar dependency property is <xref:System.Windows.UIElement.IsKeyboardFocusWithin%2A>, which might be appropriate to use if you want to visually call out that keyboard focus is somewhere within compositing or within the functional area of the control. For example, you might place an <xref:System.Windows.UIElement.IsKeyboardFocusWithin%2A> trigger such that a panel that groups several controls appears differently, even though keyboard focus might more precisely be on an individual element within that panel.  
  
 You can also use the events <xref:System.Windows.UIElement.GotKeyboardFocus> and <xref:System.Windows.UIElement.LostKeyboardFocus> (as well as their Preview equivalents). You can use these events as the basis for an <xref:System.Windows.EventSetter>, or you can write handlers for the events in code-behind.  
  
### Other Focus Properties  
 If you want all possible causes of changing focus to produce a visual behavior, you should base a setter or trigger on the <xref:System.Windows.UIElement.IsFocused%2A> dependency property, or alternatively on the <xref:System.Windows.UIElement.GotFocus> or <xref:System.Windows.UIElement.LostFocus> events used for an <xref:System.Windows.EventSetter>.  
  
## See Also  
 <xref:System.Windows.FrameworkElement.FocusVisualStyle%2A>  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [Focus Overview](../../../../docs/framework/wpf/advanced/focus-overview.md)  
 [Input Overview](../../../../docs/framework/wpf/advanced/input-overview.md)
