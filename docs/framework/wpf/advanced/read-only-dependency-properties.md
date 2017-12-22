---
title: "Read-Only Dependency Properties"
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
  - "dependency properties [WPF], read-only"
  - "read-only dependency properties [WPF]"
ms.assetid: f23d6ec9-3780-4c09-a2ff-b2f0a2deddf1
caps.latest.revision: 8
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Read-Only Dependency Properties
This topic describes read-only dependency properties, including existing read-only dependency properties and the scenarios and techniques for creating a custom read-only dependency property.  
  

  
<a name="prerequisites"></a>   
## Prerequisites  
 This topic assumes that you understand the basic scenarios of implementing a dependency property, and how metadata is applied to a custom dependency property. See [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md) and [Dependency Property Metadata](../../../../docs/framework/wpf/advanced/dependency-property-metadata.md) for context.  
  
<a name="existing"></a>   
## Existing Read-Only Dependency Properties  
 Some of the dependency properties defined in the [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] framework are read-only. The typical reason for specifying a read-only dependency property is that these are properties that should be used for state determination, but where that state is influenced by a multitude of factors, but just setting the property to that state isn't desirable from a user interface design perspective. For example, the property <xref:System.Windows.UIElement.IsMouseOver%2A> is really just surfacing state as determined from the mouse input. Any attempt to set this value programmatically by circumventing the true mouse input would be unpredictable and would cause inconsistency.  
  
 By virtue of not being settable, read-only dependency properties aren't appropriate for many of the scenarios for which dependency properties normally offer a solution (namely: data binding, directly stylable to a value, validation, animation, inheritance). Despite not being settable, read-only dependency properties still have some of the additional capabilities supported by dependency properties in the property system. The most important remaining capability is that the read-only dependency property can still be used as a property trigger in a style. You can't enable triggers with a normal [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] property; it needs to be a dependency property. The aforementioned <xref:System.Windows.UIElement.IsMouseOver%2A> property is a perfect example of a scenario where it might be quite useful to define a style for a control, where some visible property such as a background, foreground, or similar properties of composited elements within the control will change when the user places a mouse over some defined region of your control. Changes in a read-only dependency property can also be detected and reported by the property system's inherent invalidation processes, and this in fact supports the property trigger functionality internally.  
  
<a name="new"></a>   
## Creating Custom Read-Only Dependency Properties  
 Make sure to read the section above regarding why read-only dependency properties won't work for many typical dependency-property scenarios. But if you have an appropriate scenario, you may wish to create your own read-only dependency property.  
  
 Much of the process of creating a read-only dependency property is the same as is described in the [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md) and [Implement a Dependency Property](../../../../docs/framework/wpf/advanced/how-to-implement-a-dependency-property.md) topics. There are three important differences:  
  
-   When registering your property, call the <xref:System.Windows.DependencyProperty.RegisterReadOnly%2A> method instead of the normal <xref:System.Windows.DependencyProperty.Register%2A> method for property registration.  
  
-   When implementing the [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] "wrapper" property, make sure that the wrapper too doesn't have a set implementation, so that there is no inconsistency in read-only state for the public wrapper you expose.  
  
-   The object returned by the read-only registration is <xref:System.Windows.DependencyPropertyKey> rather than <xref:System.Windows.DependencyProperty>. You should still store this field as a member but typically you would not make it a public member of the type.  
  
 Whatever private field or value you have backing your read-only dependency property can of course be fully writable using whatever logic you decide. However, the most straightforward way to set the property either initially or as part of runtime logic is to use the property system's [!INCLUDE[TLA2#tla_api#plural](../../../../includes/tla2sharptla-apisharpplural-md.md)], rather than circumventing the property system and setting the private backing field directly. In particular, there is a signature of <xref:System.Windows.DependencyObject.SetValue%2A> that accepts a parameter of type <xref:System.Windows.DependencyPropertyKey>. How and where you set this value programmatically within your application logic will affect how you may wish to set access on the <xref:System.Windows.DependencyPropertyKey> created when you first registered the dependency property. If you handle this logic all within the class you could make it private, or if you require it to be set from other portions of the assembly you might set it internal. One approach is to call <xref:System.Windows.DependencyObject.SetValue%2A> within a class event handler of a relevant event that informs a class instance that the stored property value needs to be changed. Another approach is to tie dependency properties together by using paired <xref:System.Windows.PropertyChangedCallback> and <xref:System.Windows.CoerceValueCallback> callbacks as part of those properties' metadata during registration.  
  
 Because the <xref:System.Windows.DependencyPropertyKey> is private, and is not propagated by the property system outside of your code, a read-only dependency property does have better setting security than a read-write dependency property. For a read-write dependency property, the identifying field is explicitly or implicitly public and thus the property is widely settable. For more specifics, see [Dependency Property Security](../../../../docs/framework/wpf/advanced/dependency-property-security.md).  
  
## See Also  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)
