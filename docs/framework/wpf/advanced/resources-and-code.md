---
title: "Resources and Code"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "keys [WPF], using objects as"
  - "resources [WPF], accessing from procedural code"
  - "procedural code [WPF], creating resources with"
  - "procedural code [WPF], accessing resources from"
  - "resources [WPF], creating with procedural code"
ms.assetid: c1cfcddb-e39c-41c8-a7f3-60984914dfae
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Resources and Code
This overview concentrates on how [!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] resources can be accessed or created using  code rather than [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] syntax. For more information on general resource usage and resources from a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] syntax perspective, see [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md).  
  
  
  
<a name="accessing"></a>   
## Accessing Resources from Code  
 The keys that identify resources if they are defined through [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] are also used to retrieve specific resources if you request the resource in code. The simplest way to retrieve a resource from code is to call either the <xref:System.Windows.FrameworkElement.FindResource%2A> or the <xref:System.Windows.FrameworkElement.TryFindResource%2A> method from framework-level objects in your application. The behavioral difference between these methods is what happens if the requested key is not found. <xref:System.Windows.FrameworkElement.FindResource%2A> raises an exception; <xref:System.Windows.FrameworkElement.TryFindResource%2A> will not raise an exception but returns `null`. Each method takes the resource key as an input parameter, and returns a loosely typed object. Typically, a resource key is a string, but there are occasional nonstring usages; see the [Using Objects as Keys](#objectaskey) section for details. Typically you would cast the returned object to the type required by the property that you are setting when requesting the resource. The lookup logic for code resource resolution is the same as the dynamic resource reference [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] case. The search for resources starts from the calling element, then continues to successive parent elements in the logical tree. The lookup continues onwards into application resources, themes, and system resources if necessary. A code request for a resource will properly account for runtime changes in resource dictionaries that might have been made subsequent to that resource dictionary being loaded from [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], and also for realtime system resource changes.  
  
 The following is a brief code example that finds a resource by key and uses the returned value to set a property, implemented as a <xref:System.Windows.Controls.Primitives.ButtonBase.Click> event handler.  
  
 [!code-csharp[PropertiesOvwSupport#ResourceProceduralGet](../../../../samples/snippets/csharp/VS_Snippets_Wpf/PropertiesOvwSupport/CSharp/page3.xaml.cs#resourceproceduralget)]
 [!code-vb[PropertiesOvwSupport#ResourceProceduralGet](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/PropertiesOvwSupport/visualbasic/page3.xaml.vb#resourceproceduralget)]  
  
 An alternative method for assigning a resource reference is <xref:System.Windows.FrameworkElement.SetResourceReference%2A>. This method takes two parameters: the key of the resource, and the identifier for a particular dependency property that is present on the element instance to which the resource value should be assigned. Functionally, this method is the same and has the advantage of not requiring any casting of return values.  
  
 Still another way to access resources programmatically is to access the contents of the <xref:System.Windows.FrameworkElement.Resources%2A> property as a dictionary. Accessing the dictionary contained by this property is also how you can add new resources to existing collections, check to see if a given key name is already taken in the collection, and other dictionary/collection operations. If you are writing a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application entirely in code, you can also create the entire collection in code, assign keys to it, and then assign the finished collection to the <xref:System.Windows.FrameworkElement.Resources%2A> property of an established element. This will be described in the next section.  
  
 You can index within any given <xref:System.Windows.FrameworkElement.Resources%2A> collection, using a specific key as the index, but you should be aware that accessing the resource in this way does not follow the normal runtime rules of resource resolution. You are only accessing that particular collection. Resource lookup will not be traversing the scope to the root or the application if no valid object was found at the requested key. However, this approach may have performance advantages in some cases precisely because the scope of the search for the key is more constrained. See the <xref:System.Windows.ResourceDictionary> class for more details on how to work with the resource dictionary directly.  
  
<a name="creating"></a>   
## Creating Resources with Code  
 If you want to create an entire [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application in code, you might also want to create any resources in that application in code. To achieve this, create a new <xref:System.Windows.ResourceDictionary> instance, and then add all the resources to the dictionary using successive calls to <xref:System.Windows.ResourceDictionary.Add%2A?displayProperty=nameWithType>. Then, use the <xref:System.Windows.ResourceDictionary> thus created to set the <xref:System.Windows.FrameworkElement.Resources%2A> property on an element that is present in a page scope, or the <xref:System.Windows.Application.Resources%2A?displayProperty=nameWithType>. You could also maintain the <xref:System.Windows.ResourceDictionary> as a standalone object without adding it to an element. However, if you do this, you must access the resources within it by item key, as if it were a generic dictionary. A <xref:System.Windows.ResourceDictionary> that is not attached to an element `Resources` property would not  exist as part of the element tree and has no scope in a lookup sequence that can be used by <xref:System.Windows.FrameworkElement.FindResource%2A> and related methods.  
  
<a name="objectaskey"></a>   
## Using Objects as Keys  
 Most resource usages will set the key of the resource to be a string. However, various [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] features deliberately do not use a string type to specify keys, instead this parameter is an object. The capability of having the resource be keyed by an object is used by the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] style and theming support. The styles in themes which become the default style for an otherwise non-styled control are each keyed by the <xref:System.Type> of the control that they should apply to. Being keyed by type provides a reliable lookup mechanism that works on default instances of each control type, and type can be detected by reflection and used for styling derived classes even though the derived type otherwise has no default style. You can specify a <xref:System.Type> key for a resource defined in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] by using the [x:Type Markup Extension](../../../../docs/framework/xaml-services/x-type-markup-extension.md). Similar extensions exist for other nonstring key usages that support [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] features, such as [ComponentResourceKey Markup Extension](../../../../docs/framework/wpf/advanced/componentresourcekey-markup-extension.md).  
  
## See Also  
 [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md)  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)
