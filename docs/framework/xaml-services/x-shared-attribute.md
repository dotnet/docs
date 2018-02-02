---
title: "x:Shared Attribute"
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
  - "XAML [XAML Services], x:Shared attribute"
  - "x:Shared attribute [XAML Services]"
  - "Shared attribute in XAML [XAML Services]"
ms.assetid: c8cff434-2785-405f-9f95-16deb34c9e64
caps.latest.revision: 16
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Shared Attribute
When set to `false`, modifies WPF resource-retrieval behavior so that requests for the attributed resource create a new instance for each request instead of sharing the same instance for all requests.  
  
## XAML Attribute Usage  
  
```xaml  
<ResourceDictionary>  
  <object x:Shared="false".../>  
</ResourceDictionary>  
```  
  
## Remarks  
 `x:Shared` is mapped to the XAML language XAML namespace and is recognized as a valid XAML language element by .NET Framework XAML Services and its XAML readers. However, the stated capabilities of `x:Shared` are only relevant for WPF applications and for the WPF XAML parser. In WPF, `x:Shared` is only useful as an attribute when it is applied to an object that exists within a WPF <xref:System.Windows.ResourceDictionary>. Other usages do not throw parse exceptions or other errors, but they have no effect.  
  
 The meaning of `x:Shared` is not specified in the XAML language specification. Other XAML implementations, such as those that build on .NET Framework XAML Services, do not necessarily provide resource-sharing support. Such XAML implementations could provide similar behavior in the supporting framework that also used `x:Shared` values.  
  
 In WPF, the default `x:Shared` condition for resources is `true`. This condition means that any given resource request always returns the same instance.  
  
 Modifying an object that is returned through a resource API, such as <xref:System.Windows.FrameworkElement.FindResource%2A>, or modifying an object directly within a <xref:System.Windows.ResourceDictionary>, changes the original resource. If references to that resource were dynamic resource references, the consumers of that resource get the changed resource.  
  
 If references to the resource were static resource references, changes to the resource after [!INCLUDE[TLA2#tla_xaml](../../../includes/tla2sharptla-xaml-md.md)] processing time are irrelevant. For more information about static versus dynamic resource references, see [XAML Resources](../../../docs/framework/wpf/advanced/xaml-resources.md).  
  
 Explicitly specifying `x:Shared="true"` is rarely done, because that is already the default. There is no direct code equivalent for `x:Shared` in the WPF object model; it can only be specified in a XAML usage and must be processed either by the default WPF behavior or in an intermediate XAML node stream on the load path if processed using .NET Framework XAML Services and its XAML readers.  
  
 A scenario for `x:Shared="false"` is if you define a <xref:System.Windows.FrameworkElement> or <xref:System.Windows.FrameworkContentElement> derived class as a resource and then you introduce the element resource into a content model. `x:Shared="false"` enables an element resource to be introduced multiple times in the same collection (such as a <xref:System.Windows.Controls.UIElementCollection>). Without `x:Shared="false"` this is invalid because the collection enforces uniqueness of its contents. However, the `x:Shared="false"` behavior creates another identical instance of the resource instead of returning the same instance.  
  
 Another scenario for `x:Shared="false"` is if you use a <xref:System.Windows.Freezable> resource for animation values but want to modify the resource on a per animation basis.  
  
 The string handling of `false` is not case sensitive.  
  
 In WPF, `x:Shared` is only valid under the following conditions:  
  
-   The <xref:System.Windows.ResourceDictionary> that contains the items with `x:Shared` must be compiled. The <xref:System.Windows.ResourceDictionary> cannot be within loose XAML or used for themes.  
  
-   The <xref:System.Windows.ResourceDictionary> that contains the items must not be nested within another <xref:System.Windows.ResourceDictionary>. For example, you cannot use `x:Shared` for items in a <xref:System.Windows.ResourceDictionary> that is within a <xref:System.Windows.Style> that is already a <xref:System.Windows.ResourceDictionary> item.  
  
## See Also  
 <xref:System.Windows.ResourceDictionary>  
 [XAML Resources](../../../docs/framework/wpf/advanced/xaml-resources.md)  
 [Base Elements](../../../docs/framework/wpf/advanced/base-elements.md)
