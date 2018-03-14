---
title: "How to: Register an Attached Property"
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
  - "attached properties [WPF], registering"
  - "registering attached properties [WPF]"
ms.assetid: eb47bd94-0451-4f8d-8fb6-95f7812ac05b
caps.latest.revision: 12
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Register an Attached Property
This example shows how to register an attached property and provide public accessors so that you can use the property in both [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)] and code. Attached properties are a syntax concept defined by [!INCLUDE[TLA#tla_xaml](../../../../includes/tlasharptla-xaml-md.md)]. Most attached properties for [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] types are also implemented as dependency properties. You can use dependency properties on any <xref:System.Windows.DependencyObject> types.  
  
## Example  
 The following example shows how to register an attached property as a dependency property, by using the <xref:System.Windows.DependencyProperty.RegisterAttached%2A> method. The provider class has the option of providing default metadata for the property that is applicable when the property is used on another class, unless that class overrides the metadata. In this example, the default value of the `IsBubbleSource` property is set to `false`.  
  
 The provider class for an attached property (even if it is not registered as a dependency property) must provide static get and set accessors that follow the naming convention `Set`*[AttachedPropertyName]* and `Get`*[AttachedPropertyName]*. These accessors are required so that the acting [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] reader can recognize the property as an attribute in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] and resolve the appropriate types.  
  
 [!code-csharp[WPFAquariumSln#RegisterAttachedBubbler](../../../../samples/snippets/csharp/VS_Snippets_Wpf/WPFAquariumSln/CSharp/WPFAquariumObjects/Class1.cs#registerattachedbubbler)]
 [!code-vb[WPFAquariumSln#RegisterAttachedBubbler](../../../../samples/snippets/visualbasic/VS_Snippets_Wpf/WPFAquariumSln/visualbasic/wpfaquariumobjects/class1.vb#registerattachedbubbler)]  
  
## See Also  
 <xref:System.Windows.DependencyProperty>  
 [Dependency Properties Overview](../../../../docs/framework/wpf/advanced/dependency-properties-overview.md)  
 [Custom Dependency Properties](../../../../docs/framework/wpf/advanced/custom-dependency-properties.md)  
 [How-to Topics](../../../../docs/framework/wpf/advanced/properties-how-to-topics.md)
