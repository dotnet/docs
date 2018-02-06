---
title: "x:Static Markup Extension"
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
  - "StaticExtension"
  - "xStatic"
  - "x:Static"
helpviewer_keywords: 
  - "x:Static markup extension [XAML Services]"
  - "Static markup extension in XAML [XAML Services]"
  - "XAML [XAML Services], x:Static markup extension"
ms.assetid: 056aee79-7cdd-434f-8174-dfc856cad343
caps.latest.revision: 25
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Static Markup Extension
References any static by-value code entity that is defined in a [!INCLUDE[TLA#tla_cls](../../../includes/tlasharptla-cls-md.md)]–compliant way. The static property that is referenced can be used to provide the value of a property in XAML.  
  
## XAML Attribute Usage  
  
```xaml  
<object property="{x:Static prefix:typeName.staticMemberName}" .../>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`prefix`|Optional. A prefix that refers to a mapped, non-default XAML namespace. `prefix` is shown explicitly in the usage because you rarely reference static properties that come from a default XAML namespace. See Remarks.|  
|`typeName`|Required. The name of the type that defines the desired static member.|  
|`staticMemberName`|Required. The name of the desired static value member (a constant, a static property, a field, or an enumeration value).|  
  
## Remarks  
 The code entity that is referenced must be one of the following:  
  
-   A constant  
  
-   A static property  
  
-   A field  
  
-   An enumeration value  
  
 Specifying any other code entity, such as a nonstatic property, causes a compile-time error if the XAML is markup compiled, or a XAML load-time parse exception.  
  
 You can make `x:Static` references to static fields or properties that are not in the default XAML namespace for the current XAML document; however, this requires a prefix mapping. XAML namespaces are almost always defined on the root element of the XAML document.  
  
 The lookup operations for static properties can be performed by .NET Framework XAML Services and its XAML readers and XAML writers, when they are running with the default XAML schema context. This XAML schema context can use CLR reflection to provide the necessary static values for object graph construction. The `typeName` you specify is actually a XAML type name, not a CLR type name, although these are essentially the same name when using the default XAML schema context or when using all existing CLR-based XAML-implementing frameworks.  
  
 Use caution when you make `x:Static` references that are not directly the type of a property's value. In the XAML processing sequence, provided values from a markup extension do not invoke additional value conversion. This is true even if your `x:Static` reference creates a text string, and a value conversion for attribute values based on text string typically occurs either for that specific member or for any member values of the return type.  
  
 Attribute syntax is the most common syntax used with this markup extension. The string token provided after the `x:Static` identifier string is assigned as the <xref:System.Windows.Markup.StaticExtension.Member%2A> value of the underlying <xref:System.Windows.Markup.StaticExtension> extension class.  
  
 There are two other XAML usages that are technically possible. However, these usages are less common because they are unnecessarily verbose:  
  
 **Object element syntax:** `<x:Static Member="` `prefix` `:` `typeName` `.` `staticMemberName` `" .../>`  
  
 **Attribute syntax with explicit Member property for initialization string:** `<` `object` `` `property` `="{x:Static Member=` `prefix` `:` `typeName` `.` `staticMemberName` `}" .../>`  
  
 In the .NET Framework XAML Services implementation, the handling for this markup extension is defined by the <xref:System.Windows.Markup.StaticExtension> class.  
  
 `x:Static` is a markup extension. All markup extensions in XAML use the `{` and `}` characters in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must provide a value. For more information about markup extensions, see [Markup Extensions for XAML Overview](../../../docs/framework/xaml-services/markup-extensions-for-xaml-overview.md).  
  
## WPF Usage Notes  
 The default XAML namespace you use for WPF programming does not contain many useful static properties, and most of the useful static properties have support such as type converters that facilitate the usage without requiring `{x:Static}` . For static properties, you must map a prefix for a XAML namespace if one of the following is true:  
  
-   You are referencing a type that exists in WPF but is not part of the default XAML namespace for WPF ([!INCLUDE[TLA#tla_wpfxmlnsv1](../../../includes/tlasharptla-wpfxmlnsv1-md.md)]). This is a fairly common scenario for using `x:Static`. For example, you might use an `x:Static` reference with a XAML namespace mapping to the <xref:System> CLR namespace and mscorlib assembly in order to reference the static properties of the <xref:System.Environment> class.  
  
-   You are referencing a type from a custom assembly.  
  
-   You are referencing a type that exists in a WPF assembly, but that type is within a CLR namespace that was not mapped to be part of the WPF default XAML namespace. The mapping of CLR namespaces into the default XAML namespace for WPF is performed by definitions in the various WPF assemblies (for more information about this concept, see [XAML Namespaces and Namespace Mapping for WPF XAML](../../../docs/framework/wpf/advanced/xaml-namespaces-and-namespace-mapping-for-wpf-xaml.md)). Non-mapped CLR namespaces can exist if that CLR namespace is composed mostly of class definitions that are not typically intended for XAML, such as <xref:System.Windows.Threading>.  
  
 For more information on how to use prefixes and XAML namespaces for WPF, see [XAML Namespaces and Namespace Mapping for WPF XAML](../../../docs/framework/wpf/advanced/xaml-namespaces-and-namespace-mapping-for-wpf-xaml.md).  
  
## See Also  
 [x:Type Markup Extension](../../../docs/framework/xaml-services/x-type-markup-extension.md)  
 [Types Migrated from WPF to System.Xaml](../../../docs/framework/xaml-services/types-migrated-from-wpf-to-system-xaml.md)
