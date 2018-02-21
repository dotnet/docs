---
title: "Preview Events"
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
  - "Preview events [WPF]"
  - "suppressing events [WPF]"
  - "events [WPF], Preview"
  - "events [WPF], suppressing"
ms.assetid: b5032308-aa9c-4d02-af11-630ecec8df7e
caps.latest.revision: 7
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Preview Events
Preview events, also known as tunneling events, are routed events where the direction of the route travels from the application root towards the element that raised the event and is reported as the source in event data. Not all event scenarios support or require preview events; this topic describes the situations where preview events exist, how applications or components should handle them, and cases where creating preview events in custom components or classes might be appropriate.  
  
## Preview Events and Input  
 When you handle Preview events in general, be cautious about marking the events handled in the event data. Handling a Preview event on any element other than the element that raised it (the element that is reported as the source in the event data) has the effect of not providing an element the opportunity to handle the event that it originated. Sometimes this is the desired result, particularly if the elements in question exist in relationships within the compositing of a control.  
  
 For input events specifically, Preview events also share event data instances with the equivalent bubbling event. If you use a Preview event class handler to mark the input event handled, the bubbling input event class handler will not be invoked. Or, if you use a Preview event instance handler to mark the event handled, handlers for the bubbling event will not typically be invoked. Class handlers or instance handlers can be registered or attached with an option to be invoked even if the event is marked handled, but that technique is not commonly used.  
  
 For more information about class handling and how it relates to Preview events see [Marking Routed Events as Handled, and Class Handling](../../../../docs/framework/wpf/advanced/marking-routed-events-as-handled-and-class-handling.md).  
  
### Working Around Event Suppression by Controls  
 One scenario where Preview events are commonly used is for composited control handling of input events. Sometimes, the author of the control suppresses a certain event from originating from their control, perhaps in order to substitute a component-defined event that carries more information or implies a more specific behavior. For instance, a [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] <xref:System.Windows.Controls.Button> suppresses <xref:System.Windows.UIElement.MouseLeftButtonDown> and <xref:System.Windows.UIElement.MouseLeftButtonDown> bubbling events raised by the <xref:System.Windows.Controls.Button> or its composite elements in favor of capturing the mouse and raising a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event that is always raised by the <xref:System.Windows.Controls.Button> itself. The event and its data still continue along the route, but because the <xref:System.Windows.Controls.Button> marks the event data as <xref:System.Windows.RoutedEventArgs.Handled%2A>, only handlers for the event that specifically indicated they should act in the `handledEventsToo` case  are invoked.  If other elements towards the root of your application still wanted an opportunity to handle a control-suppressed event, one alternative is to attach handlers in code with `handledEventsToo` specified as `true`. But often a simpler technique is to change the routing direction you handle to be the Preview equivalent of an input event. For instance, if a control suppresses <xref:System.Windows.UIElement.MouseLeftButtonDown>, try attaching a handler for <xref:System.Windows.UIElement.PreviewMouseLeftButtonDown> instead. This technique only works for base element input events such as <xref:System.Windows.UIElement.MouseLeftButtonDown>. These input events use tunnel/bubble pairs, raise both events, and share the event data.  
  
 Each of these techniques has either side effects or limitations. The side effect of handling the Preview event is that handling the event at that point might disable handlers that expect to handle the bubbling event, and therefore the limitation is that it is usually not a good idea to mark the event handled while it is still on the Preview part of the route. The limitation of the `handledEventsToo` technique is that you cannot specify a `handledEventsToo` handler in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] as an attribute, you must register the event handler in code after obtaining an object reference to the element where the handler is to be attached.  
  
## See Also  
 [Marking Routed Events as Handled, and Class Handling](../../../../docs/framework/wpf/advanced/marking-routed-events-as-handled-and-class-handling.md)  
 [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md)
