---
title: "Object Lifetime Events"
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
  - "events [WPF], ContentRendered"
  - "events [WPF], Deactivated"
  - "events [WPF], Unloaded"
  - "Activated events [WPF]"
  - "events [WPF], Loaded"
  - "Application objects [WPF], lifetime events"
  - "events [WPF], Activated"
  - "ContentRendered events [WPF]"
  - "Deactivated events [WPF]"
  - "events [WPF], Initialized"
  - "events [WPF], Closing"
  - "Unloaded events [WPF]"
  - "exit events [WPF]"
  - "objects' lifetime events [WPF]"
  - "Loaded events [WPF]"
  - "Closing events [WPF]"
  - "events [WPF], Closed"
  - "Initialized events [WPF]"
  - "Closed events [WPF]"
  - "startup events [WPF]"
  - "lifetime events of objects [WPF]"
ms.assetid: face6fc7-465b-4502-bfe5-e88d2e729a78
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Object Lifetime Events
This topic describes the specific [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] events that signify stages in an object lifetime of creation, use, and destruction.  
  

  
<a name="prerequisites"></a>   
## Prerequisites  
 This topic assumes that you understand dependency properties from the perspective of a consumer of existing dependency properties on [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] classes, and have read the [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md) topic. In order to follow the examples in this topic, you should also understand [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] (see [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)) and know how to write [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications.  
  
<a name="intro"></a>   
## Object Lifetime Events  
 All objects in [!INCLUDE[TLA#tla_netframewk](../../../../includes/tlasharptla-netframewk-md.md)] managed code go through a similar set of stages of life, creation, use, and destruction. Many objects also have a finalization stage of life that occurs as part of the destruction phase. [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] objects, more specifically the visual objects that [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] identifies as elements, also have a set of common stages of object life. The [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] programming and application models expose these stages as a series of events. There are four main types of objects in [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] with respect to lifetime events; elements in general, window elements, navigation hosts, and application objects. Windows and navigation hosts are also within the larger grouping of visual objects (elements). This topic describes the lifetime events that are common to all elements and then introduces the more specific ones that apply to application definitions, windows or navigation hosts.  
  
<a name="common_events"></a>   
## Common Lifetime Events for Elements  
 Any WPF framework-level element (those objects deriving from either <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement>) has three common lifetime events: <xref:System.Windows.FrameworkElement.Initialized>, <xref:System.Windows.FrameworkElement.Loaded>, and <xref:System.Windows.FrameworkElement.Unloaded>.  
  
### Initialized  
 <xref:System.Windows.FrameworkElement.Initialized> is raised first, and roughly corresponds to the initialization of the object by the call to its constructor. Because the event happens in response to initialization, you are guaranteed that all properties of the object are set. (An exception is expression usages such as dynamic resources or binding; these will be unevaluated expressions.) As a consequence of the requirement that all properties are set, the sequence of <xref:System.Windows.FrameworkElement.Initialized> being raised by nested elements that are defined in markup appears to occur in order of deepest elements in the element tree first, then parent elements toward the root. This order is because the parent-child relationships and containment are properties, and therefore the parent cannot report initialization until the child elements that fill the property are also completely initialized.  
  
 When you are writing handlers in response to the <xref:System.Windows.FrameworkElement.Initialized> event, you must consider that there is no guarantee that all other elements in the element tree (either logical tree or visual tree) around where the handler is attached have been created, particularly parent elements. Member variables may be null, or data sources might not yet be populated by the underlying binding (even at the expression level).  
  
### Loaded  
 <xref:System.Windows.FrameworkElement.Loaded> is raised next. The <xref:System.Windows.FrameworkElement.Loaded> event is raised before the final rendering, but after the layout system has calculated all necessary values for rendering. <xref:System.Windows.FrameworkElement.Loaded> entails that the logical tree that an element is contained within is complete, and connects to a presentation source that provides the HWND and the rendering surface. Standard data binding (binding to local sources, such as other properties or directly defined data sources) will have occurred prior to <xref:System.Windows.FrameworkElement.Loaded>. Asynchronous data binding (external or dynamic sources) might have occurred, but by definition of its asynchronous nature cannot be guaranteed to have occurred.  
  
 The mechanism by which the <xref:System.Windows.FrameworkElement.Loaded> event is raised is different than <xref:System.Windows.FrameworkElement.Initialized>. The <xref:System.Windows.FrameworkElement.Initialized> event is raised element by element, without a direct coordination by a completed element tree. By contrast, the <xref:System.Windows.FrameworkElement.Loaded> event is raised as a coordinated effort throughout the entire element tree (specifically, the logical tree). When all elements in the tree are in a state where they are considered loaded, the <xref:System.Windows.FrameworkElement.Loaded> event is first raised on the root element. The <xref:System.Windows.FrameworkElement.Loaded> event is then raised successively on each child element.  
  
> [!NOTE]
>  This behavior might superficially resemble tunneling for a routed event. However, no information is carried from event to event. Each element always has the opportunity to handle its <xref:System.Windows.FrameworkElement.Loaded> event, and marking the event data as handled has no effect beyond that element.  
  
### Unloaded  
 <xref:System.Windows.FrameworkElement.Unloaded> is raised last and is initiated by either the presentation source or the visual parent being removed. When <xref:System.Windows.FrameworkElement.Unloaded> is raised and handled, the element that is the event source parent (as determined by <xref:System.Windows.FrameworkElement.Parent%2A> property) or any given element upwards in the logical or visual trees may have already been unset, meaning that data binding, resource references, and styles may not be set to their normal or last known run-time value.  
  
<a name="application_model_elements"></a>   
## Lifetime Events Application Model Elements  
 Building on the common lifetime events for elements are the following application model elements: <xref:System.Windows.Application>, <xref:System.Windows.Window>, <xref:System.Windows.Controls.Page>, <xref:System.Windows.Navigation.NavigationWindow>, and <xref:System.Windows.Controls.Frame>. These extend the common lifetime events with additional events that are relevant to their specific purpose. These are discussed in detail in the following locations:  
  
-   <xref:System.Windows.Application>: [Application Management Overview](../../../../docs/framework/wpf/app-development/application-management-overview.md).  
  
-   <xref:System.Windows.Window>: [WPF Windows Overview](../../../../docs/framework/wpf/app-development/wpf-windows-overview.md).  
  
-   <xref:System.Windows.Controls.Page>, <xref:System.Windows.Navigation.NavigationWindow>, and <xref:System.Windows.Controls.Frame>: [Navigation Overview](../../../../docs/framework/wpf/app-development/navigation-overview.md).  
  
## See Also  
 [Dependency Property Value Precedence](../../../../docs/framework/wpf/advanced/dependency-property-value-precedence.md)  
 [Routed Events Overview](../../../../docs/framework/wpf/advanced/routed-events-overview.md)
