---
title: "XAML 2009 Language Features"
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
  - "XAML 2009 [XAML Services]"
  - "XAML [XAML Services], XAML 2009"
ms.assetid: f6bb18d8-c86a-4549-8862-323e6b32a8dd
caps.latest.revision: 11
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XAML 2009 Language Features
XAML 2009 is the shorthand term for new XAML language features that extend the existing XAML language specification. XAML 2009 introduces several new directives and constructs. These include the[x:Arguments Directive](../../../docs/framework/xaml-services/x-arguments-directive.md); the [x:FactoryMethod Directive](../../../docs/framework/xaml-services/x-factorymethod-directive.md); the [x:Reference Markup Extension](../../../docs/framework/xaml-services/x-reference-markup-extension.md); the [x:TypeArguments Directive](../../../docs/framework/xaml-services/x-typearguments-directive.md); and built-in types for common language primitives (for example `x:Char`).  
  
<a name="xaml_2009_support_in_wpf_and_visual_studio"></a>   
## XAML 2009 Support in WPF and Visual Studio  
 In WPF, you can use XAML 2009 features, but only for XAML that is not WPF markup-compiled. Markup-compiled XAML and the BAML form of XAML do not currently support the XAML 2009 language keywords and features.  
  
 Note that existing techniques for loading loose XAML in WPF also have possible security and access restrictions to CLR types and the type system that are more restrictive than for markup-compiled XAML. For more information, see [Security (WPF)](../../../docs/framework/wpf/security-wpf.md) or [WPF Security Strategy - Platform Security](../../../docs/framework/wpf/wpf-security-strategy-platform-security.md).  
  
 XAML 2009 also introduces additional features that either modify the previous XAML 2006 constructs or that modify the basic markup forms.  
  
### x:Key as an Object Element  
 XAML 2009 can support `x:Key` as an object (a property element that has object element value); however, XAML 2006 only supported `x:Key` as an attribute. See the "XAML 2009" section of [x:Key Directive](../../../docs/framework/xaml-services/x-key-directive.md).  
  
### xmlns on Property Elements  
 XAML 2009 can support XAML namespace (xmlns) definitions on property elements; however, XAML 2006 only supports xmlns definitions on object elements.  
  
### Event Attributes  
 For attributes that are backed by events, XAML 2006 presumes that markup compilation is involved and submits the events to markup compilation. XAML 2009 supports a markup form that resembles a markup extension, which defers the event wiring until run-time parsing and loading of the XAML. However, WPF applications and XAML scenarios for WPF UI generally do not use this capability. WPF and its XAML 2006 implementation uses the combination of event handler wiring for routed events defined at the <xref:System.Windows.UIElement> level and its markup compiler step for much of its event attribute processing. The markup compiler also preprocesses any event attributes found in XAML where the build actions declare that the markup compiler is used.  
  
## See Also  
 [XAML Overview (WPF)](../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)
