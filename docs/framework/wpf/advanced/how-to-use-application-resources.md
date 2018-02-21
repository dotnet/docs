---
title: "How to: Use Application Resources"
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
  - "application resources [WPF]"
  - "resources [WPF], application resources"
ms.assetid: 507ea937-5191-406b-8797-0a3d9f94156d
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# How to: Use Application Resources
This example shows how to use application resources.  
  
## Example  
 The following example shows an application definition file. The application definition file defines a resource section (a value for the <xref:System.Windows.Application.Resources%2A> property). Resources defined at the application level can be accessed by all other pages that are part of the application. In this case, the resource is a declared style. Because a complete style that includes a control template can be lengthy, this example omits the control template that is defined within the <xref:System.Windows.Controls.ContentControl.ContentTemplate%2A> property setter of the style.  
  
 [!code-xaml[ResourcesApplication#PreTemplateResource](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ResourcesApplication/CS/app.xaml#pretemplateresource)]  
[!code-xaml[ResourcesApplication#PostTemplateResource](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ResourcesApplication/CS/app.xaml#posttemplateresource)]  
  
 The following example shows a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] page that references the application-level resource that the previous example defined. The resource is referenced by using a     [StaticResource Markup Extension](../../../../docs/framework/wpf/advanced/staticresource-markup-extension.md) that specifies the unique resource key for the requested resource. No resource with key of "GelButton" is found in the current page, so the resource lookup scope for the requested resource continues beyond the current page and into the defined application-level resources.  
  
 [!code-xaml[ResourcesApplication#ConsumingPage](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ResourcesApplication/CS/page1.xaml#consumingpage)]  
  
## See Also  
 [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md)  
 [Application Management Overview](../../../../docs/framework/wpf/app-development/application-management-overview.md)  
 [How-to Topics](../../../../docs/framework/wpf/advanced/resources-how-to-topics.md)
