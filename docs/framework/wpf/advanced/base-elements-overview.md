---
title: "Base Elements Overview"
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
  - "base elements [WPF]"
ms.assetid: 2c997092-72c6-4767-bc84-74267f4eee72
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Base Elements Overview
A high percentage of classes in [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] are derived from four classes which are commonly referred to in the [!INCLUDE[TLA2#tla_sdk](../../../../includes/tla2sharptla-sdk-md.md)] documentation as the base element classes. These classes are <xref:System.Windows.UIElement>, <xref:System.Windows.FrameworkElement>, <xref:System.Windows.ContentElement>, and <xref:System.Windows.FrameworkContentElement>. The <xref:System.Windows.DependencyObject> class is also related, because it is a common base class of both <xref:System.Windows.UIElement> and <xref:System.Windows.ContentElement>  
 
  
<a name="base_apis"></a>   
## Base Element APIs in WPF Classes  
 Both <xref:System.Windows.UIElement> and <xref:System.Windows.ContentElement> are derived from <xref:System.Windows.DependencyObject>, through somewhat different pathways. The split at this level deals with how a <xref:System.Windows.UIElement> or <xref:System.Windows.ContentElement> are used in a user interface and what purpose they serve in an application. <xref:System.Windows.UIElement> also has <xref:System.Windows.Media.Visual> in its class hierarchy, which is a class that exposes the lower-level graphics support underlying the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)]. <xref:System.Windows.Media.Visual> provides a rendering framework by defining independent rectangular screen regions. In practice, <xref:System.Windows.UIElement> is for elements that will support a larger object model, are intended to render and layout into regions that can be described as rectangular screen regions, and where the content model is deliberately more open, to allow different combinations of elements. <xref:System.Windows.ContentElement> does not derive from <xref:System.Windows.Media.Visual>; its model is that a <xref:System.Windows.ContentElement> would be consumed by something else, such as a reader or viewer that would then interpret the elements and produce the complete <xref:System.Windows.Media.Visual> for [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] to consume. Certain <xref:System.Windows.UIElement> classes are intended to be content hosts: they provide the hosting and rendering for one or more <xref:System.Windows.ContentElement> classes (<xref:System.Windows.Controls.DocumentViewer> is an example of such a class). <xref:System.Windows.ContentElement> is used as base class for elements with somewhat smaller object models and that more address the text, information, or document content that might be hosted within a <xref:System.Windows.UIElement>.  
  
### Framework-Level and Core-Level  
 <xref:System.Windows.UIElement> serves as the base class for <xref:System.Windows.FrameworkElement>, and <xref:System.Windows.ContentElement> serves as the base class for <xref:System.Windows.FrameworkContentElement>. The reason for this next level of classes is to support a WPF core level that is separate from a WPF framework level, with this division also existing in how the [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] are divided between the PresentationCore and PresentationFramework assemblies. The WPF framework level presents a more complete solution for basic application needs, including the implementation of the layout manager for presentation. The WPF core level provides a way to use much of [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] without taking the overhead of the additional assembly. The distinction between these levels very rarely matters for most typical application development scenarios, and in general you should think of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)] as a whole and not concern yourself with the difference between WPF framework level and WPF core level. You might need to know about the level distinctions if your application design chooses to replace substantial quantities of WPF framework level functionality, for instance if your overall solution already has its own implementations of [!INCLUDE[TLA#tla_ui](../../../../includes/tlasharptla-ui-md.md)] composition and layout.  
  
<a name="subclassing_elements"></a>   
## Choosing Which Element to Derive From  
 The most practical way to create a custom class that extends [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is by deriving from one of the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] classes where you get as much as possible of your desired functionality through the existing class hierarchy. This section lists the functionality that comes with three of the most important element classes to help you decide which class to inherit from.  
  
 If you are implementing a control, which is really one of the more common reasons for deriving from a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] class, you probably want to derive from a class that is a practical control, a control family base class, or at least from the <xref:System.Windows.Controls.Control> base class. For some guidance and practical examples, see [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md).  
  
 If you are not creating a control and need to derive from a class that is higher in the hierarchy, the following sections are intended as a guide for what characteristics are defined in each base element class.  
  
 If you create a class that derives from <xref:System.Windows.DependencyObject>, you inherit the following functionality:  
  
-   <xref:System.Windows.DependencyObject.GetValue%2A> and <xref:System.Windows.DependencyObject.SetValue%2A> support, and general property system support.  
  
-   Ability to use dependency properties and attached properties that are implemented as dependency properties.  
  
 If you create a class that derives from <xref:System.Windows.UIElement>, you inherit the following functionality in addition to that provided by <xref:System.Windows.DependencyObject>:  
  
-   Basic support for animated property values. For more information, see [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
-   Basic input event support, and commanding support. For more information, see [Input Overview](../../../../docs/framework/wpf/advanced/input-overview.md) and [Commanding Overview](../../../../docs/framework/wpf/advanced/commanding-overview.md).  
  
-   Virtual methods that can be overridden to provide information to a layout system.  
  
 If you create a class that derives from <xref:System.Windows.FrameworkElement>, you inherit the following functionality in addition to that provided by <xref:System.Windows.UIElement>:  
  
-   Support for styling and storyboards. For more information, see <xref:System.Windows.Style> and [Storyboards Overview](../../../../docs/framework/wpf/graphics-multimedia/storyboards-overview.md).  
  
-   Support for data binding. For more information, see [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
-   Support for dynamic resource references. For more information, see [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md).  
  
-   Property value inheritance support, and other flags in the metadata that help report conditions about properties to framework services such as data binding, styles, or the framework implementation of layout. For more information, see [Framework Property Metadata](../../../../docs/framework/wpf/advanced/framework-property-metadata.md).  
  
-   The concept of the logical tree. For more information, see [Trees in WPF](../../../../docs/framework/wpf/advanced/trees-in-wpf.md).  
  
-   Support for the practical WPF framework-level implementation of the layout system, including an <xref:System.Windows.FrameworkElement.OnPropertyChanged%2A> override that can detect changes to properties that influence layout.  
  
 If you create a class that derives from <xref:System.Windows.ContentElement>, you inherit the following functionality in addition to that provided by <xref:System.Windows.DependencyObject>:  
  
-   Support for animations. For more information, see [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
-   Basic input event support, and commanding support. For more information, see [Input Overview](../../../../docs/framework/wpf/advanced/input-overview.md) and [Commanding Overview](../../../../docs/framework/wpf/advanced/commanding-overview.md).  
  
 If you create a class that derives from <xref:System.Windows.FrameworkContentElement>, you get the following functionality in addition to that provided by <xref:System.Windows.ContentElement>:  
  
-   Support for styling and storyboards. For more information, see <xref:System.Windows.Style> and [Animation Overview](../../../../docs/framework/wpf/graphics-multimedia/animation-overview.md).  
  
-   Support for data binding. For more information, see [Data Binding Overview](../../../../docs/framework/wpf/data/data-binding-overview.md).  
  
-   Support for dynamic resource references. For more information, see [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md).  
  
-   Property value inheritance support, and other flags in the metadata that help report conditions about properties to framework services like data binding, styles, or the framework implementation of layout. For more information, see [Framework Property Metadata](../../../../docs/framework/wpf/advanced/framework-property-metadata.md).  
  
-   You do not inherit access to layout system modifications (such as <xref:System.Windows.FrameworkElement.ArrangeOverride%2A>). Layout system implementations are only available on <xref:System.Windows.FrameworkElement>. However, you inherit an <xref:System.Windows.FrameworkElement.OnPropertyChanged%2A> override that can detect changes to properties that influence layout and report these to any content hosts.  
  
 Content models are documented for a variety of classes. The content model for a class is one possible factor you should consider if you want to find an appropriate class to derive from. For more information, see [WPF Content Model](../../../../docs/framework/wpf/controls/wpf-content-model.md).  
  
<a name="other_base_classes"></a>   
## Other Base Classes  
  
### DispatcherObject  
 <xref:System.Windows.Threading.DispatcherObject> provides support for the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] threading model and enables all objects created for [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications to be associated with a <xref:System.Windows.Threading.Dispatcher>. Even if you do not derive from <xref:System.Windows.UIElement>, <xref:System.Windows.DependencyObject>, or <xref:System.Windows.Media.Visual>, you should consider deriving from <xref:System.Windows.Threading.DispatcherObject> in order to get this threading model support. For more information, see [Threading Model](../../../../docs/framework/wpf/advanced/threading-model.md).  
  
### Visual  
 <xref:System.Windows.Media.Visual> implements the concept of a 2D object that generally requires visual presentation in a roughly rectangular region. The actual rendering of a <xref:System.Windows.Media.Visual> happens in other classes (it is not self-contained), but the <xref:System.Windows.Media.Visual> class provides a known type that is used by rendering processes at various levels. <xref:System.Windows.Media.Visual> implements hit testing, but it does not expose events that report hit-testing positives (these are in <xref:System.Windows.UIElement>). For more information, see [Visual Layer Programming](../../../../docs/framework/wpf/graphics-multimedia/visual-layer-programming.md).  
  
### Freezable  
 <xref:System.Windows.Freezable> simulates immutability in a mutable object by providing the means to generate copies of the object when an immutable object is required or desired for performance reasons. The <xref:System.Windows.Freezable> type provides a common basis for certain graphics elements such as geometries and brushes, as well as animations. Notably, a <xref:System.Windows.Freezable> is not a <xref:System.Windows.Media.Visual>; it can hold properties that become subproperties when the <xref:System.Windows.Freezable> is applied to fill a property value of another object, and those subproperties might affect rendering. For more information, see [Freezable Objects Overview](../../../../docs/framework/wpf/advanced/freezable-objects-overview.md).  
  
 <xref:System.Windows.Media.Animation.Animatable>  
  
 <xref:System.Windows.Media.Animation.Animatable> is a <xref:System.Windows.Freezable> derived class that specifically adds the animation control layer and some utility members so that currently animated properties can be distinguished from nonanimated properties.  
  
### Control  
 <xref:System.Windows.Controls.Control> is the intended base class for the type of object that is variously termed a control or component, depending on the technology. In general, [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] control classes are classes that either directly represent a UI control or participate closely in control composition. The primary functionality that <xref:System.Windows.Controls.Control> enables is control templating.  
  
## See Also  
 <xref:System.Windows.Controls.Control>  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md)  
 [WPF Architecture](../../../../docs/framework/wpf/advanced/wpf-architecture.md)
