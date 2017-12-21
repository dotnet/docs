---
title: "How to: Define and Reference a Resource"
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
  - "resources [WPF], defining"
  - "defining resources [WPF]"
  - "resources [WPF], referencing"
  - "referencing resources [WPF]"
ms.assetid: b86b876b-0a10-489b-9a5d-581ea9b32406
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Define and Reference a Resource
This example shows how to define a resource and reference it by using an attribute in [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)].  
  
## Example  
 The following example defines two types of resources: a <xref:System.Windows.Media.SolidColorBrush> resource, and several <xref:System.Windows.Style> resources. The <xref:System.Windows.Media.SolidColorBrush> resource `MyBrush` is used to provide the value of several properties that each take a <xref:System.Windows.Media.Brush> type value. The <xref:System.Windows.Style> resources `PageBackground`, `TitleText` and `Label` each target a particular control type. The styles set a variety of different properties on the targeted controls, when that style resource is referenced by resource key and is used to set the <xref:System.Windows.FrameworkElement.Style%2A> property of several specific control elements defined in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)].  
  
 Note that one of the properties within the setters of the `Label` style also references the `MyBrush` resource defined earlier. This is a common technique, but it is important to remember that resources are parsed and entered into a resource dictionary in the order that they are given. Resources are also requested by the order found within the dictionary if you use the [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md) to reference them from within another resource. Make sure that any resource that you reference is defined earlier within the resources collection than where that resource is then requested. If necessary, you can work around the strict creation order of resource refererences by using a [DynamicResource Markup Extension](../../../../docs/framework/wpf/advanced/dynamicresource-markup-extension.md) to reference the resource at runtime instead, but you should be aware that this DynamicResource technique has performance consequences. For details, see [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md).  
  
 [!code-xaml[FEResource#XAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/FEResource/CS/default.xaml#xaml)]  
  
## See Also  
 [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md)  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)
