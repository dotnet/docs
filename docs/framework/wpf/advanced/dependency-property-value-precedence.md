---
title: "Dependency Property Value Precedence"
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
  - "dependency properties [WPF], classes as owners"
  - "dependency properties [WPF], metadata"
  - "classes [WPF], owners of dependency properties"
  - "metadata [WPF], dependency properties"
ms.assetid: 1fbada8e-4867-4ed1-8d97-62c07dad7ebc
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Dependency Property Value Precedence
<a name="introduction"></a> This topic explains how the workings of the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] property system can affect the value of a dependency property, and describes the precedence by which aspects of the property system apply to the effective value of a property.  
    
  
<a name="prerequisites"></a>   
## Prerequisites  
 This topic assumes that you understand dependency properties from the perspective of a consumer of existing dependency properties on [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] classes, and have read [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md). To follow the examples in this topic, you should also understand [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] and know how to write [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications.  
  
<a name="intro"></a>   
## The WPF Property System  
 The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property system offers a powerful way to have the value of dependency properties be determined by a variety of factors, enabling features such as real-time property validation, late binding, and notifying related properties of changes to values for other properties. The exact order and logic that is used to determine dependency property values is reasonably complex. Knowing this order will help you avoid unnecessary property setting, and might also clear up confusion over exactly why some attempt to influence or anticipate a dependency property value did not end up resulting in the value you expected.  
  
<a name="multiple_sets"></a>   
## Dependency Properties Might Be "Set" in Multiple Places  
 The following is example [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] where the same property (<xref:System.Windows.Controls.Control.Background%2A>) has three different "set" operations that might influence the value.  
  
 [!code-xaml[PropertiesOvwSupport#DPPrecedence](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page4.xaml#dpprecedence)]  
  
 Here, which color do you expect will apply—red, green, or blue?  
  
 With the exception of animated values and coercion, local property sets are set at the highest precedence. If you set a value locally you can expect that the value will be honored, even above any styles or control templates. Here in the example, <xref:System.Windows.Controls.Control.Background%2A> is set to Red locally. Therefore, the style defined in this scope, even though it is an implicit style that would otherwise apply to all elements of that type in that scope, is not the highest precedence for giving the <xref:System.Windows.Controls.Control.Background%2A> property its value.  If you removed the local value of Red from that Button instance, then the style would have precedence and the button would obtain the Background value from the style.  Within the style, triggers take precedence, so the button will be blue if the mouse is over it, and green otherwise.  
  
<a name="listing"></a>   
## Dependency Property Setting Precedence List  
 The following is the definitive order that the property system uses when assigning the run-time values of dependency properties. Highest precedence is listed first. This list expands on some of the generalizations made in the [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md).  
  
1.  **Property system coercion.** For details on coercion, see [Coercion, Animation, and Base Value](#animations) later in this topic.  
  
2.  **Active animations, or animations with a Hold behavior.** In order to have any practical effect, an animation of a property must be able to have precedence over the base (unanimated) value, even if that value was set locally. For details, see [Coercion, Animation, and Base Value](#animations) later in this topic.  
  
3.  **Local value.** A local value might be set through the convenience of the "wrapper" property, which also equates to setting as an attribute or property element in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], or by a call to the <xref:System.Windows.DependencyObject.SetValue%2A> [!INCLUDE[TLA#tla_api](../../../../includes/tlasharptla-api-md.md)] using a property of a specific instance. If you set a local value by using a binding or a resource, these each act in the precedence as if a direct value was set.  
  
4.  **TemplatedParent template properties.** An element has a <xref:System.Windows.FrameworkElement.TemplatedParent%2A> if it was created as part of a template (a <xref:System.Windows.Controls.ControlTemplate> or <xref:System.Windows.DataTemplate>). For details on when this applies, see [TemplatedParent](#templatedparent) later in this topic. Within the template, the following precedence applies:  
  
    1.  Triggers from the <xref:System.Windows.FrameworkElement.TemplatedParent%2A> template.  
  
    2.  Property sets (typically through [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] attributes) in the <xref:System.Windows.FrameworkElement.TemplatedParent%2A> template.  
  
5.  **Implicit style.** Applies only to the `Style` property. The `Style` property is filled by any style resource with a key that matches the type of that element. That style resource must exist either in the page or the application; lookup for an implicit style resource does not proceed into the themes.  
  
6.  **Style triggers.** The triggers within styles from page or application (these styles might be either explicit or implicit styles, but not from the default styles, which have lower precedence).  
  
7.  **Template triggers.** Any trigger from a template within a style, or a directly applied template.  
  
8.  **Style setters.** Values from a <xref:System.Windows.Setter> within styles from page or application.  
  
9. **Default (theme) style.** For details on when this applies, and how theme styles relate to the templates within theme styles, see [Default (Theme) Styles](#themestyles) later in this topic. Within a default style, the following order of precedence applies:  
  
    1.  Active triggers in the theme style.  
  
    2.  Setters in the theme style.  
  
10. **Inheritance.** A few dependency properties inherit their values from parent element to child elements, such that they need not be set specifically on each element throughout an application. For details see [Property Value Inheritance](../../../../docs/framework/wpf/advanced/property-value-inheritance.md).  
  
11. **Default value from dependency property metadata.** Any given dependency property may have a default value as established by the property system registration of that particular property. Also, derived classes that inherit a dependency property have the option to override that metadata (including the default value) on a per-type basis. See [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md) for more information. Because inheritance is checked before default value, for an inherited property, a parent element default value takes precedence over a child element.  Consequently, if an inheritable property is not set anywhere, the default value as specified on the root or parent is used instead of the child element default value.  
  
<a name="templatedparent"></a>   
## TemplatedParent  
 TemplatedParent as a precedence item does not apply to any property of an element that you declare directly in standard application markup. The TemplatedParent concept exists only for child items within a visual tree that come into existence through the application of the template. When the property system searches the <xref:System.Windows.FrameworkElement.TemplatedParent%2A> template for a value, it is searching the template that created that element. The property values from the <xref:System.Windows.FrameworkElement.TemplatedParent%2A> template generally act as if they were set as a local value on the child element, but this lesser precedence versus the local value exists because the templates are potentially shared. For details, see <xref:System.Windows.FrameworkElement.TemplatedParent%2A>.  
  
<a name="style_property"></a>   
## The Style Property  
 The order of lookup described earlier applies to all possible dependency properties except one: the <xref:System.Windows.FrameworkElement.Style%2A> property. The <xref:System.Windows.FrameworkElement.Style%2A> property is unique in that it cannot itself be styled, so the precedence items 5 through 8 do not apply. Also, either animating or coercing <xref:System.Windows.FrameworkElement.Style%2A> is not recommended (and animating <xref:System.Windows.FrameworkElement.Style%2A> would require a custom animation class). This leaves three ways that the <xref:System.Windows.FrameworkElement.Style%2A> property might be set:  
  
-   **Explicit style.** The <xref:System.Windows.FrameworkElement.Style%2A> property is set directly. In most scenarios, the style is not defined inline, but instead is referenced as a resource, by explicit key. In this case the Style property itself acts as if it were a local value, precedence item 3.  
  
-   **Implicit style.** The <xref:System.Windows.FrameworkElement.Style%2A> property is not set directly. However, the <xref:System.Windows.FrameworkElement.Style%2A> exists at some level in the resource lookup sequence (page, application) and is keyed using a resource key that matches the type the style is to be applied to. In this case, the <xref:System.Windows.FrameworkElement.Style%2A> property itself acts by a precedence identified in the sequence as item 5. This condition can be detected by using <xref:System.Windows.DependencyPropertyHelper> against the <xref:System.Windows.FrameworkElement.Style%2A> property and looking for <xref:System.Windows.BaseValueSource.ImplicitStyleReference> in the results.  
  
-   **Default style**, also known as **theme style.** The <xref:System.Windows.FrameworkElement.Style%2A> property is not set directly, and in fact will read as `null` up until run time. In this case, the style comes from the run-time theme evaluation that is part of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] presentation engine.  
  
 For implicit styles not in themes, the type must match exactly—a `MyButton``Button`-derived class will not implicitly use a style for `Button`.  
  
<a name="themestyles"></a>   
## Default (Theme) Styles  
 Every control that ships with [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] has a default style. That default style potentially varies by theme, which is why this default style is sometimes referred to as a theme style.  
  
 The most important information that is found within a default style for a control is its control template, which exists in the theme style as a setter for its <xref:System.Windows.Controls.Control.Template%2A> property. If there were no template from default styles, a control without a custom template as part of a custom style would have no visual appearance at all. The template from the default style gives the visual appearance of each control a basic structure, and also defines the connections between properties defined in the visual tree of the template and the corresponding control class. Each control exposes a set of properties that can influence the visual appearance of the control without completely replacing the template. For example, consider the default visual appearance of a <xref:System.Windows.Controls.Primitives.Thumb> control, which is a component of a <xref:System.Windows.Controls.Primitives.ScrollBar>.  
  
 A <xref:System.Windows.Controls.Primitives.Thumb> has certain customizable properties. The default template of a <xref:System.Windows.Controls.Primitives.Thumb> creates a basic structure / visual tree with several nested <xref:System.Windows.Controls.Border> components to create a bevel look. If a property that is part of the template is intended to be exposed for customization by the <xref:System.Windows.Controls.Primitives.Thumb> class, then that property must be exposed by a [TemplateBinding](../../../../docs/framework/wpf/advanced/templatebinding-markup-extension.md), within the template. In the case of <xref:System.Windows.Controls.Primitives.Thumb>, various properties of these borders share a template binding to properties such as <xref:System.Windows.Controls.Border.Background%2A> or <xref:System.Windows.Controls.Border.BorderThickness%2A>. But certain other properties or visual arrangements are hard-coded into the control template or are bound to values that come directly from the theme, and cannot be changed short of replacing the entire template. Generally, if a property comes from a templated parent and is not exposed by a template binding, it cannot be adjusted by styles because there is no easy way to target it. But that property could still be influenced by property value inheritance in the applied template, or by default value.  
  
 The theme styles use a type as the key in their definitions. However, when themes are applied to a given element instance, themes lookup for this type is performed by checking the <xref:System.Windows.FrameworkElement.DefaultStyleKey%2A> property on a control. This is in contrast to using the literal Type, as implicit styles do. The value of <xref:System.Windows.FrameworkElement.DefaultStyleKey%2A> would inherit to derived classes even if the implementer did not change it (the intended way of changing the property is not to override it at the property level, but to instead change its default value in property metadata). This indirection enables base classes to define the theme styles for derived elements that do not otherwise have a style (or more importantly, do not have a template within that style and would thus have no default visual appearance at all). Thus, you can derive `MyButton` from <xref:System.Windows.Controls.Button> and will still get the <xref:System.Windows.Controls.Button> default template. If you were the control author of `MyButton` and you wanted a different behavior, you could override the dependency property metadata for <xref:System.Windows.FrameworkElement.DefaultStyleKey%2A> on `MyButton` to return a different key, and then define the relevant theme styles including template for `MyButton` that you must package with your `MyButton` control. For more details on themes, styles, and control authoring, see [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md).  
  
<a name="resources"></a>   
## Dynamic Resource References and Binding  
 Dynamic resource references and binding operations respect the precedence of the location at which they are set. For example, a dynamic resource applied to a local value acts per precedence item 3, a binding for a property setter within a theme style applies at precedence item 9, and so on. Because dynamic resource references and binding must both be able to obtain values from the run time state of the application, this entails that the actual process of determining the property value precedence for any given property extends into the run time as well.  
  
 Dynamic resource references are not strictly speaking part of the property system, but they do have a lookup order of their own which interacts with the sequence listed above. That precedence is documented more thoroughly in the [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md). The basic summation of that precedence is: element to page root, application, theme, system.  
  
 Dynamic resources and bindings have the precedence of where they were set, but the value is deferred. One consequence of this is that if you set a dynamic resource or binding to a local value, any change to the local value replaces the dynamic resource or binding entirely. Even if you call the <xref:System.Windows.DependencyObject.ClearValue%2A> method to clear the locally set value, the dynamic resource or binding will not be restored. In fact, if you call <xref:System.Windows.DependencyObject.ClearValue%2A> on a property that has a dynamic resource or binding in place (with no literal local value), they are cleared by the <xref:System.Windows.DependencyObject.ClearValue%2A> call too.  
  
<a name="setcurrentvalue"></a>   
## SetCurrentValue  
 The <xref:System.Windows.DependencyObject.SetCurrentValue%2A> method is another way to set a property, but it is not in the order of precedence. Instead, <xref:System.Windows.DependencyObject.SetCurrentValue%2A> enables you to change the value of a property without overwriting the source of a previous value. You can use <xref:System.Windows.DependencyObject.SetCurrentValue%2A> any time that you want to set a value without giving that value the precedence of a local value. For example, if a property is set by a trigger and then assigned another value via <xref:System.Windows.DependencyObject.SetCurrentValue%2A>, the property system still respects the trigger and the property will change if the trigger’s action occurs. <xref:System.Windows.DependencyObject.SetCurrentValue%2A> enables you to change the property’s value without giving it a source with a higher precedence. Likewise, you can use <xref:System.Windows.DependencyObject.SetCurrentValue%2A> to change the value of a property without overwriting a binding.  
  
<a name="animations"></a>   
## Coercion, Animations, and Base Value  
 Coercion and animation both act on a value that is termed as the "base value" throughout this [!INCLUDE[TLA2#tla_sdk](../../../../includes/tla2sharptla-sdk-md.md)]. The base value is thus whatever value is determined through evaluating upwards in the items until item 2 is reached.  
  
 For an animation, the base value can have an effect on the animated value, if that animation does not specify both "From" and "To" for certain behaviors, or if the animation deliberately reverts to the base value when completed. To see this in practice, run the [From, To, and By Animation Target Values Sample](http://go.microsoft.com/fwlink/?LinkID=159988). Try setting the local values of the rectangle height in the example, such that the initial local value differs from any "From" in the animation. You will note that the animations start right away using the "From" values and replace the base value once started. The animation might specify to return to the value found before animation once it is completed by specifying the Stop <xref:System.Windows.Media.Animation.FillBehavior>. Afterwards, normal precedence is used for the base value determination.  
  
 Multiple animations might be applied to a single property, with each of these animations possibly having been defined from different points in the value precedence. However, these animations will potentially composite their values, rather than just applying the animation from the higher precedence. This depends on exactly how the animations are defined, and the type of the value that is being animated. For more information about animating properties, see [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
 Coercion applies at the highest level of all. Even an already running animation is subject to value coercion. Certain existing dependency properties in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] have built-in coercion. For a custom dependency property, you define the coercion behavior for a custom dependency property by writing a <xref:System.Windows.CoerceValueCallback> and passing the callback as part of metadata when you create the property. You can also override coercion behavior of existing properties by overriding the metadata on that property in a derived class. Coercion interacts with the base value in such a way that the constraints on coercion are applied as those constraints exist at the time, but the base value is still retained. Therefore, if constraints in coercion are later lifted, the coercion will return the closest value possible to that base value, and potentially the coercion influence on a property will cease as soon as all constraints are lifted. For more information about coercion behavior, see [Dependency Property Callbacks and Validation](../../../../docs/framework/wpf/advanced/dependency-property-callbacks-and-validation.md).  
  
<a name="triggers"></a>   
## Trigger Behaviors  
 Controls often define trigger behaviors as part of their default style in themes. Setting local properties on controls might prevent the triggers from being able to respond to user-driven events either visually or behaviorally. The most common use of a property trigger is for control or state properties such as <xref:System.Windows.Controls.Primitives.Selector.IsSelected%2A>. For example, by default when a <xref:System.Windows.Controls.Button> is disabled (trigger for <xref:System.Windows.UIElement.IsEnabled%2A> is `false`) then the <xref:System.Windows.Controls.Control.Foreground%2A> value in the theme style is what causes the control to appear "grayed out". But if you have set a local <xref:System.Windows.Controls.Control.Foreground%2A> value, that normal gray-out color will be overruled in precedence by your local property set, even in this property-triggered scenario. Be cautious of setting values for properties that have theme-level trigger behaviors and make sure you are not unduly interfering with the intended user experience for that control.  
  
<a name="clearvalue"></a>   
## ClearValue and Value Precedence  
 The <xref:System.Windows.DependencyObject.ClearValue%2A> method provides an expedient means to clear any locally applied value from a dependency property that is set on an element. However, calling <xref:System.Windows.DependencyObject.ClearValue%2A> is not a guarantee that the default as established in metadata during property registration is the new effective value. All of the other participants in value precedence are still active. Only the locally set value has been removed from the precedence sequence. For example, if you call <xref:System.Windows.DependencyObject.ClearValue%2A> on a property where that property is also set by a theme style, then the theme value is applied as the new value rather than the metadata-based default. If you want to take all property value participants out of the process and set the value to the registered metadata default, you can obtain that default value definitively by querying the dependency property metadata, and then you can use the default value to locally set the property with a call to <xref:System.Windows.DependencyObject.SetValue%2A>.  
  
## See Also  
 <xref:System.Windows.DependencyObject>  
 <xref:System.Windows.DependencyProperty>  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)  
 [Dependency Property Callbacks and Validation](../../../../docs/framework/wpf/advanced/dependency-property-callbacks-and-validation.md)
