---
title: "x:Type Markup Extension"
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
  - "x:TypeExtension"
  - "Type"
  - "x:Type"
  - "xType"
  - "TypeExtension"
helpviewer_keywords: 
  - "x:Type markup extension [XAML Services]"
  - "XAML [XAML Services], x:Type markup extension"
  - "XAML [XAML Services], TargetType attribute"
  - "TargetType attribute [XAML Services]"
  - "Type markup extension in XAML [XAML Services]"
ms.assetid: e0e0ce6f-e873-49c7-8ad7-8b840eb353ec
caps.latest.revision: 27
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Type Markup Extension
Supplies the CLR <xref:System.Type> object that is the underlying type for a specified XAML type.  
  
## XAML Attribute Usage  
  
```xaml  
<object property="{x:Type prefix:typeNameValue}" .../>  
```  
  
## XAML Object Element Usage  
  
```xaml  
<x:Type TypeName="prefix:typeNameValue"/>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`prefix`|Optional. A prefix that maps a non-default XAML namespace. Specifying a prefix is frequently not necessary. See Remarks.|  
|`typeNameValue`|Required. A type name resolvable to the current default XAML namespace; or the specified mapped prefix if `prefix` is supplied.|  
  
## Remarks  
 The `x:Type` markup extension has a similar function to the `typeof()` operator in [!INCLUDE[TLA#tla_cshrp](../../../includes/tlasharptla-cshrp-md.md)] or the `GetType` operator in [!INCLUDE[TLA#tla_visualb](../../../includes/tlasharptla-visualb-md.md)].  
  
 The `x:Type` markup extension supplies a from-string conversion behavior for properties that take the type <xref:System.Type>. The input is a XAML type. The relationship between the input XAML type and the output CLR <xref:System.Type> is that the output <xref:System.Type> is the <xref:System.Xaml.XamlType.UnderlyingType%2A> of the input <xref:System.Xaml.XamlType>, after looking up the necessary <xref:System.Xaml.XamlType> based on XAML schema context and the <xref:System.Windows.Markup.IXamlTypeResolver> service the context provides.  
  
 In .NET Framework XAML Services, the handling for this markup extension is defined by the <xref:System.Windows.Markup.TypeExtension> class.  
  
 In specific framework implementations, some properties that take <xref:System.Type> as a value can accept the name of the type directly (the string value of the type `Name`). However, implementing this behavior is a complex scenario. For examples, see the "WPF Usage Notes" section that follows.  
  
 Attribute syntax is the most common syntax used with this markup extension. The string token provided after the `x:Type` identifier string is assigned as the <xref:System.Windows.Markup.TypeExtension.TypeName%2A> value of the underlying <xref:System.Windows.Markup.TypeExtension> extension class. Under the default XAML schema context for .NET Framework XAML Services, which is based on CLR types, the value of this attribute is either the <xref:System.Reflection.MemberInfo.Name%2A> of the desired type, or contains that <xref:System.Reflection.MemberInfo.Name%2A> preceded by a prefix for a non-default XAML namespace mapping.  
  
 The `x:Type` markup extension can be used in object element syntax. In this case, specifying the value of the <xref:System.Windows.Markup.TypeExtension.TypeName%2A> property is required to properly initialize the extension.  
  
 The `x:Type` markup extension can also be used as a verbose attribute; however this use is not typical: `<``object` `property``="{x:Type TypeName=``typeNameValue``}" .../>`  
  
## WPF Usage Notes  
  
### Default XAML Namespace and Type Mapping  
 The default XAML namespace for WPF programming contains most of the XAML types you need for typical XAML scenarios; therefore, you can often avoid prefixes when referencing XAML type values. You might need to map a prefix if you are referencing a type from a custom assembly or for types that exist in a WPF assembly but are from a CLR namespace that was not mapped to the default XAML namespace. For more information about prefixes, XAML namespaces, and mapping CLR namespaces, see [XAML Namespaces and Namespace Mapping for WPF XAML](../../../docs/framework/wpf/advanced/xaml-namespaces-and-namespace-mapping-for-wpf-xaml.md).  
  
### Type Properties That Support Typename-as-String  
 WPF supports techniques that enable specifying the value of some properties of type <xref:System.Type> without requiring an `x:Type` markup extension usage. Instead, you can specify the value as a string that names the type. Examples of this are <xref:System.Windows.Controls.ControlTemplate.TargetType%2A?displayProperty=nameWithType> and <xref:System.Windows.Style.TargetType%2A?displayProperty=nameWithType>. Support for this behavior is not provided through either type converters or markup extensions. Instead, this is a deferral behavior implemented through <xref:System.Windows.FrameworkElementFactory>.  
  
 Silverlight supports a similar convention. In fact, Silverlight does not currently support `{x:Type}` in its XAML language support, and does not accept `{x:Type}` usages outside of a few circumstances that are intended to support WPF-Silverlight XAML migration. Therefore, the typename-as-string behavior is built-in to all Silverlight native property evaluation where a <xref:System.Type> is the value.  
  
## XAML 2009  
 XAML 2009 provides additional support for generic types and modifies the feature behavior of `x:TypeArguments` and `x:Type` to provide this support.  
  
-   `x:TypeArguments` and the associated object element for a generic object instantiation can be on elements other than the root. For more information, see the "XAML 2009" section of [x:TypeArguments Directive](../../../docs/framework/xaml-services/x-typearguments-directive.md).  
  
-   XAML 2009 supports a syntax for specifying a generic type's constraint in markup. This can be used by `x:TypeArguments`, by `x:Type`, or by the two features in combination.  
  
-   WPF XAML implementation when processing XAML 2009 for load also adds this capability to the implicit type conversion behavior for certain framework properties that use type <xref:System.Type>.  
  
 In WPF, you can use XAML 2009 features but only for loose XAML (XAML that is not markup-compiled). Markup-compiled XAML for WPF and the BAML form of XAML do not currently support the XAML 2009 keywords and features.  
  
## See Also  
 <xref:System.Windows.Style>  
 [Styling and Templating](../../../docs/framework/wpf/controls/styling-and-templating.md)  
 [XAML Overview (WPF)](../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Markup Extensions and WPF XAML](../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)
