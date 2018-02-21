---
title: "Merged Resource Dictionaries"
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
  - "merged resource dictionaries [WPF]"
  - "dictionaries [WPF], merged resources"
ms.assetid: d159531f-05d4-49fd-b951-c332de51e5bc
caps.latest.revision: 13
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# Merged Resource Dictionaries
[!INCLUDE[TLA#tla_winclient](../../../../includes/tlasharptla-winclient-md.md)] resources support a merged resource dictionary feature. This feature provides a way to define the resources portion of a [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] application outside of the compiled [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] application. Resources can then be shared across applications and are also more conveniently isolated for localization.  
  
## Introducing a Merged Resource Dictionary  
 In markup, you use the following syntax to introduce a merged resource dictionary into a page:  
  
 [!code-xaml[ResourceMergeDictionary#MergedXAML](../../../../samples/snippets/csharp/VS_Snippets_Wpf/ResourceMergeDictionary/CS/default.xaml#mergedxaml)]  
  
 Note that the <xref:System.Windows.ResourceDictionary> element does not have an [x:Key Directive](../../../../docs/framework/xaml-services/x-key-directive.md), which is generally required for all items in a resource collection. But another <xref:System.Windows.ResourceDictionary> reference within the <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection is a special case, reserved for this merged resource dictionary scenario. The <xref:System.Windows.ResourceDictionary> that introduces a merged resource dictionary cannot have an [x:Key Directive](../../../../docs/framework/xaml-services/x-key-directive.md). Typically, each <xref:System.Windows.ResourceDictionary> within the <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection specifies a <xref:System.Windows.ResourceDictionary.Source%2A> attribute. The value of <xref:System.Windows.ResourceDictionary.Source%2A> should be a [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)] that resolves to the location of the resources file to be merged. The destination of that [!INCLUDE[TLA2#tla_uri](../../../../includes/tla2sharptla-uri-md.md)] must be another [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] file, with <xref:System.Windows.ResourceDictionary> as its root element.  
  
> [!NOTE]
>  It is legal to define resources within a <xref:System.Windows.ResourceDictionary> that is specified as a merged dictionary, either as an alternative to specifying <xref:System.Windows.ResourceDictionary.Source%2A>, or in addition to whatever resources are included from the specified source. However, this is not a common scenario; the main scenario for merged dictionaries is to merge resources from external file locations. If you want to specify resources within the markup for a page, you should typically define these in the main <xref:System.Windows.ResourceDictionary> and not in the merged dictionaries.  
  
## Merged Dictionary Behavior  
 Resources in a merged dictionary occupy a location in the resource lookup scope that is just after the scope of the main resource dictionary they are merged into. Although a resource key must be unique within any individual dictionary, a key can exist multiple times in a set of merged dictionaries. In this case, the resource that is returned will come from the last dictionary found sequentially in the <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection. If the <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection was defined in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], then the order of the merged dictionaries in the collection is the order of the elements as provided in the markup. If a key is defined in the primary dictionary and also in a dictionary that was merged, then the resource that is returned will come from the primary dictionary. These scoping rules apply equally for both static resource references and dynamic resource references.  
  
### Merged Dictionaries and Code  
 Merged dictionaries can be added to a `Resources` dictionary through code. The default, initially empty <xref:System.Windows.ResourceDictionary> that exists for any `Resources` property also has a default, initially empty <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> collection property. To add a merged dictionary through code, you obtain a reference to the desired primary <xref:System.Windows.ResourceDictionary>, get its <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A> property value, and call `Add` on the generic `Collection` that is contained in <xref:System.Windows.ResourceDictionary.MergedDictionaries%2A>. The object you add must be a new <xref:System.Windows.ResourceDictionary>. In code, you do not set the <xref:System.Windows.ResourceDictionary.Source%2A> property. Instead, you must obtain a <xref:System.Windows.ResourceDictionary> object by either creating one or loading one. One way to load an existing <xref:System.Windows.ResourceDictionary> to call <xref:System.Windows.Markup.XamlReader.Load%2A?displayProperty=nameWithType> on an existing [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] file stream that has a <xref:System.Windows.ResourceDictionary> root, then casting the <xref:System.Windows.Markup.XamlReader.Load%2A?displayProperty=nameWithType> return value to <xref:System.Windows.ResourceDictionary>.  
  
### Merged Resource Dictionary URIs  
 There are several techniques for how to include a merged resource dictionary, which are indicated by the [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)] format that you will use. Broadly speaking, these techniques can be divided into two categories: resources that are compiled as part of the project, and resources that are not compiled as part of the project.  
  
 For resources that are compiled as part of the project, you can use a relative path that refers to the resource location. The relative path is evaluated during compilation. Your resource must be defined as part of the project as a Resource build action. If you include a resource .xaml file in the project as Resource, you do not need to copy the resource file to the output directory, the resource is already included within the compiled application. You can also use Content build action, but you must then copy the files to the output directory and also deploy the resource files in the same path relationship to the executable.  
  
> [!NOTE]
>  Do not use the Embedded Resource build action. The build action itself is supported for [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] applications, but the resolution of <xref:System.Windows.ResourceDictionary.Source%2A> does not incorporate <xref:System.Resources.ResourceManager>, and thus cannot separate the individual resource out of the stream. You could still use Embedded Resource for other purposes so long as you also used <xref:System.Resources.ResourceManager> to access the resources.  
  
 A related technique is to use a Pack URI to a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] file, and refer to it as Source. Pack URI enables references to components of referenced assemblies and other techniques. For more information on Pack URIs, see [WPF Application Resource, Content, and Data Files](../../../../docs/framework/wpf/app-development/wpf-application-resource-content-and-data-files.md).  
  
 For resources that are not compiled as part of the project, the URI is evaluated at run time. You can use a common URI transport such as file: or http: to refer to the resource file. The disadvantage of using the noncompiled resource approach is that file: access requires additional deployment steps, and http: access implies the Internet security zone.  
  
### Reusing Merged Dictionaries  
 You can reuse or share merged resource dictionaries between applications, because the resource dictionary to merge can be referenced through any valid [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)]. Exactly how you do this will depend on your application deployment strategy and which application model you follow. The aforementioned Pack URI strategy provides a way to commonly source a merged resource across multiple projects during development by sharing an assembly reference. In this scenario the resources are still distributed by the client, and at least one of the applications must deploy the referenced assembly. It is also possible to reference merged resources through a distributed URI that uses the http protocol.  
  
 Writing merged dictionaries as local application files or to local shared storage is another possible merged dictionary / application deployment scenario.  
  
### Localization  
 If resources that need to be localized are isolated to dictionaries that are merged into primary dictionaries, and kept as loose [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)], these files can be localized separately. This technique is a lightweight alternative to localizing  the satellite resource assemblies. For details, see [WPF Globalization and Localization Overview](../../../../docs/framework/wpf/advanced/wpf-globalization-and-localization-overview.md).  
  
## See Also  
 <xref:System.Windows.ResourceDictionary>  
 [XAML Resources](../../../../docs/framework/wpf/advanced/xaml-resources.md)  
 [Resources and Code](../../../../docs/framework/wpf/advanced/resources-and-code.md)  
 [WPF Application Resource, Content, and Data Files](../../../../docs/framework/wpf/app-development/wpf-application-resource-content-and-data-files.md)
