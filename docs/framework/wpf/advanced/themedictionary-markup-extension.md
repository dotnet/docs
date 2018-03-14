---
title: "ThemeDictionary Markup Extension"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "ThemeDictionaryExtension"
  - "ThemeDictionary"
helpviewer_keywords: 
  - "ThemeDictionary markup extension [WPF]"
  - "XAML [WPF], ThemeDictionary markup extension"
ms.assetid: aa75e10b-13dd-4989-972d-51bab63a05e2
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ThemeDictionary Markup Extension
Provides a way for custom control authors or applications that integrate third-party controls to load theme-specific resource dictionaries to use in styling the control.  
  
## XAML Attribute Usage  
  
```xml  
<object property="{ThemeDictionary assemblyUri}" .../>  
```  
  
## XAML Object Element Usage  
  
```xml  
<object>  
  <object.property>  
    <ThemeDictionary AssemblyName="assemblyUri"/>  
  <object.property>  
<object>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`assemblyUri`|The [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)] of the assembly that contains theme information. Typically, this is a pack URI that references an assembly in the larger package. Assembly resources and pack URIs simplify deployment issues. For more information see [Pack URIs in WPF](../../../../docs/framework/wpf/app-development/pack-uris-in-wpf.md).|  
  
## Remarks  
 This extension is intended to fill only one specific property value: a value for <xref:System.Windows.ResourceDictionary.Source%2A?displayProperty=nameWithType>.  
  
 By using this extension, you can specify a single resources-only assembly that contains some styles to use only when the [!INCLUDE[TLA#tla_aero](../../../../includes/tlasharptla-aero-md.md)] theme is applied to the user's system, other styles when Luna theme is active, and so on. By using this extension, the contents of a control-specific resource dictionary can be automatically invalidated and reloaded to be specific for another theme when required.  
  
 The `assemblyUri` string (<xref:System.Windows.ThemeDictionaryExtension.AssemblyName%2A> property value) forms the basis of a naming convention that identifies which dictionary applies for a particular theme. The <xref:System.Windows.Markup.MarkupExtension.ProvideValue%2A> logic for `ThemeDictionary` completes the convention by generating a [!INCLUDE[TLA#tla_uri](../../../../includes/tlasharptla-uri-md.md)] that points to a particular theme dictionary variant, as contained within a precompiled resource assembly. Describing this convention, or theme interactions with general control styling and page/application level styling as a concept, is not covered fully here. The basic scenario for using `ThemeDictionary` is to specify the <xref:System.Windows.ResourceDictionary.Source%2A> property of a `ResourceDictionary` declared at the application level. When you provide a [!INCLUDE[TLA2#tla_uri](../../../../includes/tla2sharptla-uri-md.md)] for the assembly through a `ThemeDictionary` extension rather than as a direct [!INCLUDE[TLA2#tla_uri](../../../../includes/tla2sharptla-uri-md.md)], the extension logic will provide invalidation logic that applies whenever the system theme changes.  
  
 Attribute syntax is the most common syntax used with this markup extension. The string token provided after the `ThemeDictionary` identifier string is assigned as the <xref:System.Windows.ThemeDictionaryExtension.AssemblyName%2A> value of the underlying <xref:System.Windows.ThemeDictionaryExtension> extension class.  
  
 `ThemeDictionary` may also be used in object element syntax. In this case, specifying the value of the <xref:System.Windows.ThemeDictionaryExtension.AssemblyName%2A> property is required.  
  
 `ThemeDictionary` can also be used in a verbose attribute usage that specifies the <xref:System.Windows.Markup.StaticExtension.Member%2A> property as a property=value pair:  
  
```xml  
<object property="{ThemeDictionary AssemblyName=assemblyUri}" .../>  
```  
  
 The verbose usage is often useful for extensions that have more than one settable property, or if some properties are optional. Because `ThemeDictionary` has only one settable property, which is required, this verbose usage is not typical.  
  
 In the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor implementation, the handling for this markup extension is defined by the <xref:System.Windows.ThemeDictionaryExtension> class.  
  
 `ThemeDictionary` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties. All markup extensions in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] use the { and } characters in their attribute syntax, which is the convention by which a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor recognizes that a markup extension must process the attribute. For more information, see [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
## See Also  
 [Styling and Templating](../../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)  
 [WPF Application Resource, Content, and Data Files](../../../../docs/framework/wpf/app-development/wpf-application-resource-content-and-data-files.md)
