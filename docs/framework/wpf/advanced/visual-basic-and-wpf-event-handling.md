---
title: "Visual Basic and WPF Event Handling"
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
  - "Visual Basic [WPF], event handlers"
  - "event handlers [WPF], Visual Basic"
ms.assetid: ad4eb9aa-3afc-4a71-8cf6-add3fbea54a1
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Visual Basic and WPF Event Handling
For the [!INCLUDE[TLA#tla_visualbnet](../../../../includes/tlasharptla-visualbnet-md.md)] language specifically, you can use the language-specific `Handles` keyword to associate event handlers with instances, instead of attaching event handlers with attributes or using the <xref:System.Windows.UIElement.AddHandler%2A> method. However, the `Handles` technique for attaching handlers to instances does have some limitations, because the `Handles` syntax cannot support some of the specific routed event features of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] event system.  
  
## Using "Handles" in a WPF Application  
 The event handlers that are connected to instances and events with `Handles` must all be defined within the partial class declaration of the instance, which is also a requirement for event handlers that are assigned through attribute values on elements. You can only specify `Handles` for an element on the page that has a <xref:System.Windows.FrameworkContentElement.Name%2A> property value (or [x:Name Directive](../../../../docs/framework/xaml-services/x-name-directive.md) declared). This is because the <xref:System.Windows.FrameworkContentElement.Name%2A> in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] creates the instance reference that is necessary to support the *Instance.Event* reference format required by the `Handles` syntax. The only element that can be used for `Handles` without a <xref:System.Windows.FrameworkContentElement.Name%2A> reference is the root-element instance that defines the partial class.  
  
 You can assign the same handler to multiple elements by separating *Instance.Event* references after `Handles` with commas.  
  
 You can use `Handles` to assign more than one handler to the same *Instance.Event*reference. Do not assign any importance to the order in which handlers are given in the `Handles` reference; you should assume that handlers that handle the same event can be invoked in any order.  
  
 To remove a handler that was added with `Handles` in the declaration, you can call <xref:System.Windows.UIElement.RemoveHandler%2A>.  
  
 You can use `Handles` to attach handlers for routed events, so long as you attach handlers to instances that define the event being handled in their members tables. For routed events, handlers that are attached with `Handles` follow the same routing rules as do handlers that are attached as [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] attributes, or with the common signature of <xref:System.Windows.UIElement.AddHandler%2A>. This means that if the event is already marked handled (the <xref:System.Windows.RoutedEventArgs.Handled%2A> property in the event data is `True`), then handlers attached with `Handles` are not invoked in response to that event instance. The event could be marked handled by instance handlers on another element in the route, or by class handling either on the current element or earlier elements along the route. For input events that support paired tunnel/bubble events, the tunneling route may have marked the event pair handled. For more information about routed events, see [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md).  
  
## Limitations of "Handles" for Adding Handlers  
 `Handles` cannot reference handlers for attached events. You must use the `add` accessor method for that attached event, or *typename.eventname* event attributes in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)]. For details, see [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md).  
  
 For routed events, you can only use `Handles` to assign handlers for instances where that event exists in the instance members table. However, with routed events in general, a parent element can be a listener for an event from child elements, even if the parent element does not have that event in its members table. In attribute syntax, you can specify this through a *typename.membername* attribute form that qualifies which type actually defines the event you want to handle. For instance, a parent `Page` (with no `Click` event defined) can listen for button-click events by assigning an attribute handler in the form `Button.Click`. But `Handles` does not support the *typename.membername* form, because it must support a conflicting *Instance.Event* form. For details, see [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md).  
  
 `Handles` cannot attach handlers that are invoked for events that are already marked handled. Instead, you must use code and call the `handledEventsToo` overload of <xref:System.Windows.UIElement.AddHandler%28System.Windows.RoutedEvent%2CSystem.Delegate%2CSystem.Boolean%29>.  
  
> [!NOTE]
>  Do not use the `Handles` syntax in [!INCLUDE[vb_current_short](../../../../includes/vb-current-short-md.md)] code when you specify an event handler for the same event in XAML. In this case, the event handler is called twice.  
  
## How WPF Implements "Handles" Functionality  
 When a [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] page is compiled, the intermediate file declares `Friend` `WithEvents` references to every element on the page that has a <xref:System.Windows.FrameworkContentElement.Name%2A> property set (or [x:Name Directive](../../../../docs/framework/xaml-services/x-name-directive.md) declared). Each named instance is potentially an element that can be assigned to a handler through `Handles`.  
  
> [!NOTE]
>  Within [!INCLUDE[TLA#tla_visualstu](../../../../includes/tlasharptla-visualstu-md.md)], [!INCLUDE[TLA2#tla_intellisense](../../../../includes/tla2sharptla-intellisense-md.md)] can show you completion for which elements are available for a `Handles` reference in a page. However, this might take one compile pass so that the intermediate file can populate all the `Friends` references.  
  
## See Also  
 <xref:System.Windows.UIElement.AddHandler%2A>  
 [Marking Routed Events as Handled, and Class Handling](../../../../docs/framework/wpf/advanced/marking-routed-events-as-handled-and-class-handling.md)  
 [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md)  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)
