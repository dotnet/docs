---
title: "Property Change Events"
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
  - "dependency properties [WPF], change events"
  - "property value changes [WPF]"
  - "change events [WPF], property"
  - "events [WPF], change in property values"
  - "creating property triggers [WPF]"
  - "property change events [WPF], types of"
  - "property change events [WPF]"
  - "property triggers [WPF]"
  - "identifying changed property events [WPF]"
  - "property triggers [WPF], definition of"
ms.assetid: 0a7989df-9674-4cc1-bc50-5d8ef5d9c055
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Property Change Events
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] defines several events that are raised in response to a change in the value of a property. Often the property is a dependency property. The event itself is sometimes a routed event and is sometimes a standard [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] event. The definition of the event varies depending on the scenario, because some property changes are more appropriately routed through an element tree, whereas other property changes are generally only of concern to the object where the property changed.  
  
## Identifying a Property Change Event  
 Not all events that report a property change are explicitly identified as a property changed event, either by virtue of a signature pattern or a naming pattern. Generally, the description of the event in the [!INCLUDE[TLA#tla_sdk](../../../../includes/tlasharptla-sdk-md.md)] documentation indicates whether the event is directly tied to a property value change and provides cross-references between the property and event.  
  
### RoutedPropertyChanged Events  
 Certain events use an event data type and delegate that are explicitly used for property change events. The event data type is <xref:System.Windows.RoutedPropertyChangedEventArgs%601>, and the delegate is <xref:System.Windows.RoutedPropertyChangedEventHandler%601>. The event data and delegate both have a generic type parameter that is used to specify the actual type of the changing property when you define the handler. The event data contains two properties, <xref:System.Windows.RoutedPropertyChangedEventArgs%601.OldValue%2A> and <xref:System.Windows.RoutedPropertyChangedEventArgs%601.NewValue%2A>, which are both then passed as the type argument in the event data.  
  
 The "Routed" part of the name indicates that the property changed event is registered as a routed event. The advantage of routing a property changed event is that the top level of a control can receive property changed events if properties on the child elements (the control's composite parts) change values. For instance, you might create a control that incorporates a <xref:System.Windows.Controls.Primitives.RangeBase> control such as a <xref:System.Windows.Controls.Slider>. If the value of the <xref:System.Windows.Controls.Primitives.RangeBase.Value%2A> property changes on the slider part, you might want to handle that change on the parent control rather than on the part.  
  
 Because you have an old value and a new value, it might be tempting to use this event handler as a validator for the property value. However, that is not the design intention of most property changed events. Generally, the values are provided so that you can act on those values in other logic areas of your code, but actually changing the values from within the event handler is not advisable, and may cause unintentional recursion depending on how your handler is implemented.  
  
 If your property is a custom dependency property, or if you are working with a derived class where you have defined the instantiation code, there is a much better mechanism for tracking property changes that is built in to the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property system: the property system callbacks <xref:System.Windows.CoerceValueCallback> and <xref:System.Windows.PropertyChangedCallback>. For more details about how you can use the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] property system for validation and coercion, see [Dependency Property Callbacks and Validation](../../../../docs/framework/wpf/advanced/dependency-property-callbacks-and-validation.md) and [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md).  
  
### DependencyPropertyChanged Events  
 Another pair of types that are part of a property changed event scenario is <xref:System.Windows.DependencyPropertyChangedEventArgs> and <xref:System.Windows.DependencyPropertyChangedEventHandler>. Events for these property changes are not routed; they are standard [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] events. <xref:System.Windows.DependencyPropertyChangedEventArgs> is an unusual event data reporting type because it does not derive from <xref:System.EventArgs>; <xref:System.Windows.DependencyPropertyChangedEventArgs> is a structure, not a class.  
  
 Events that use <xref:System.Windows.DependencyPropertyChangedEventArgs> and <xref:System.Windows.DependencyPropertyChangedEventHandler> are slightly more common than `RoutedPropertyChanged` events. An example of an event that uses these types is <xref:System.Windows.UIElement.IsMouseCapturedChanged>.  
  
 Like <xref:System.Windows.RoutedPropertyChangedEventArgs%601>, <xref:System.Windows.DependencyPropertyChangedEventArgs> also reports an old and new value for the property. Also, the same considerations about what you can do with the values apply; it is generally not recommended that you attempt to change the values again on the sender in response to the event.  
  
## Property Triggers  
 A closely related concept to a property changed event is a property trigger. A property trigger is created within a style or template and enables you to create a conditional behavior based on the value of the property where the property trigger is assigned.  
  
 The property for a property trigger must be a dependency property. It can be (and frequently is) a read-only dependency property. A good indicator for when a dependency property exposed by a control is at least partially designed to be a property trigger is if the property name begins with "Is". Properties that have this naming are often a read-only Boolean dependency property where the primary scenario for the property is reporting control state that might have consequences to the real-time UI and is thus a property trigger candidate.  
  
 Some of these properties also have a dedicated property changed event. For instance, the property <xref:System.Windows.UIElement.IsMouseCaptured%2A> has a property changed event <xref:System.Windows.UIElement.IsMouseCapturedChanged>. The property itself is read-only, with its value adjusted by the input system, and the input system raises <xref:System.Windows.UIElement.IsMouseCapturedChanged> on each real-time change.  
  
 Compared to a true property changed event, using a property trigger to act on a property change has some limitations.  
  
 Property triggers work through an exact match logic. You specify a property and a value that indicates the specific value for which the trigger will act. For instance: `<Setter Property="IsMouseCaptured" Value="true"> ... </Setter>`. Because of this limitation, the majority of property trigger usages will be for Boolean properties, or properties that take a dedicated enumeration value, where the possible value range is manageable enough to define a trigger for each case. Or property triggers might exist only for special values, such as when an items count reaches zero, and there would be no trigger that accounts for the cases when the property value changes away from zero again (instead of triggers for all cases, you might need a code event handler here, or a default behavior that toggles back from the trigger state again when the value is nonzero).  
  
 The property trigger syntax is analogous to an "if" statement in programming. If the trigger condition is true, then the "body" of the property trigger is "executed". The "body" of a property trigger is not code, it is markup. That markup is limited to using one or more <xref:System.Windows.Setter> elements to set other properties of the object where the style or template is being applied.  
  
 To offset the "if" condition of a property trigger that has a wide variety of possible values, it is generally advisable to set that same property value to a default by using a <xref:System.Windows.Setter>. This way, the <xref:System.Windows.Trigger> contained setter will have precedence when the trigger condition is true, and the <xref:System.Windows.Setter> that is not within a <xref:System.Windows.Trigger> will have precedence whenever the trigger condition is false.  
  
 Property triggers are generally appropriate for scenarios where one or more appearance properties should change, based on the state of another property on the same element.  
  
 To learn more about property triggers, see [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md).  
  
## See Also  
 [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md)  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)
