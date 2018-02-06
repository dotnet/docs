---
title: "Type Converters and Markup Extensions for XAML"
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
  - "XAML [XAML Services], type converter services"
  - "XAML [XAML Services], value converters"
  - "XAML [XAML Services], markup extension services"
  - "value converters for XAML [XAML Services]"
  - "XAML [XAML Services], service context"
ms.assetid: db07a952-05ce-4aa4-b6f9-aac7397d0326
caps.latest.revision: 13
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Type Converters and Markup Extensions for XAML
Type converters and markup extensions are two techniques that XAML type systems and XAML writers use to generate object graph components. Although they share some characteristics, type converters and markup extensions are represented differently in a XAML node stream. In this documentation set, type converters, markup extensions, and similar constructs are sometimes collectively referred to as value converters.  
  
<a name="value_converters"></a>   
## Value Converters  
 In XAML, value converters are used for various scenarios. The following list shows the different types of value converters in XAML:  
  
-   Type converter  
  
-   Markup extension  
  
-   Value serializer  
  
-   Related class or support class that provides the logic for a XAML text syntax  
  
<a name="type_converters"></a>   
## Type Converters  
 In the .NET Framework XAML Services definition, type converters are classes that derive from the CLR <xref:System.ComponentModel.TypeConverter> class. <xref:System.ComponentModel.TypeConverter> is a class that was in the [!INCLUDE[TLA#tla_netframewk](../../../includes/tlasharptla-netframewk-md.md)] before XAML existed. Its original purpose was to support property windows and similar text-based editing metaphors for [!INCLUDE[TLA2#tla_ide](../../../includes/tla2sharptla-ide-md.md)] properties. The introduction of XAML to .NET Framework uses <xref:System.ComponentModel.TypeConverter> to convert a text syntax (as found in an attribute value or a XAML value node) into an object. <xref:System.ComponentModel.TypeConverter> can also be used to serialize an object value to text syntax. <xref:System.ComponentModel.TypeConverter> was also used in previous framework-specific XAML implementations in [!INCLUDE[TLA#tla_wpf](../../../includes/tlasharptla-wpf-md.md)] and [!INCLUDE[vsindigo](../../../includes/vsindigo-md.md)]. For more information about the <xref:System.ComponentModel.TypeConverter> in XAML, see [Type Converters for XAML Overview](../../../docs/framework/xaml-services/type-converters-for-xaml-overview.md).  
  
<a name="markup_extensions"></a>   
## Markup Extensions  
 In the .NET Framework XAML Services implementation, markup extensions are classes that derive from the <xref:System.Windows.Markup.MarkupExtension> class. Markup extensions are a concept that in this form is originated by the XAML language. You can think of a markup extension as being something like an extensible escape sequence that calls into a service class to provide its logic. In terms of markup, XAML processors universally recognize a markup extension by a text sequence that starts with an opening brace ({) in a text string.  
  
 Markup extensions differ from type converters. Type converters are typically associated with types or members. They are invoked when an object graph creation or a serialization encounters text syntax that is associated with those entities.  
  
 Markup extensions are associated with a single supporting service class, but can be applied for any member value. (However, you can implement your markup extension to deliberately restrict its use to certain members or destination types, by using service context.) Markup extensions can override a type converter association. Or you can use them to specify an attribute value for members that would not otherwise support a text syntax.  
  
 For more information about the markup extension implementation pattern for XAML, see [Markup Extensions for XAML Overview](../../../docs/framework/xaml-services/markup-extensions-for-xaml-overview.md).  
  
> [!NOTE]
>  The <xref:System.Windows.Markup.MarkupExtension> and <xref:System.Windows.Markup.ValueSerializer> types are both in the <xref:System.Windows.Markup> namespace and not in the <xref:System.Xaml> namespace. This does not imply that these types are specific to either the WPF or [!INCLUDE[TLA2#tla_winforms](../../../includes/tla2sharptla-winforms-md.md)] technologies that otherwise populate CLR namespaces that contain the string `Windows`. <xref:System.Windows.Markup.MarkupExtension> and <xref:System.Windows.Markup.ValueSerializer> are in the System.Xaml assembly and have no specific framework dependency. These types existed in the CLR namespace for [!INCLUDE[net_v30_short](../../../includes/net-v30-short-md.md)] and remain in the CLR namespace in [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] to avoid breaking references in existing WPF projects. For more information, see [Types Migrated from WPF to System.Xaml](../../../docs/framework/xaml-services/types-migrated-from-wpf-to-system-xaml.md).  
  
<a name="value_serializers"></a>   
## Value Serializers  
 A <xref:System.Windows.Markup.ValueSerializer> is a specialized type converter that is optimized for converting an object to a string. A <xref:System.Windows.Markup.ValueSerializer> for XAML might not implement the `ConvertFrom` method at all. A <xref:System.Windows.Markup.ValueSerializer> implementation obtains services in a manner that is like a <xref:System.ComponentModel.TypeConverter> implementation. The virtual methods provide an input `context` parameter. The `context` parameter is of type <xref:System.Windows.Markup.IValueSerializerContext>, which inherits from the <xref:System.IServiceProvider> interface and has a <xref:System.IServiceProvider.GetService%2A> method.  
  
 In the XAML type system and for XAML writer implementations that use XAML node loop processing for serialization, a value converter that is associated with a type or member is reported by its own <xref:System.Xaml.XamlType.ValueSerializer%2A?displayProperty=nameWithType> property. The meaning to XAML writers that perform serialization is that if a <xref:System.Xaml.XamlType.TypeConverter%2A?displayProperty=nameWithType> and <xref:System.Xaml.XamlType.ValueSerializer%2A?displayProperty=nameWithType> exist, the type converter should be used for the load path and the value serializer should be used for the save path. If <xref:System.Xaml.XamlType.TypeConverter%2A?displayProperty=nameWithType> exists but <xref:System.Xaml.XamlType.ValueSerializer%2A?displayProperty=nameWithType> is `null`, the type converter is also used for the save path.  
  
<a name="other_value_converters"></a>   
## Other Value Converters  
 A value converter is extensible beyond the specific patterns of a type converter or a markup extension. However, this customization would also require the redefinition of the XAML type system as provided by .NET Framework XAML Services. The existing XAML type system has representations and reporting systems for type converters, markup extensions, and value serializers, but not for custom forms of value conversion. If you want to create custom value converters, use the <xref:System.Xaml.Schema.XamlValueConverter%601> type.  
  
<a name="type_converters_and_markup_extensions_in_combination"></a>   
## Type Converters and Markup Extensions in Combination  
 Markup extensions and type converters are used for different situations in XAML. Although context is available for markup extension usages, type conversion behavior of properties where a markup extension provides a value is generally is not checked in the markup extension implementations. In other words, even if a markup extension returns a text string as its `ProvideValue` output, type conversion behavior on that string as applied to a specific property or property value type is not invoked. Generally, the purpose of a markup extension is to process a string and return an object without any type converter involved.  
  
<a name="service_context_for_a_value_converter"></a>   
## Service Context for a Value Converter  
 When you implement a value converter, you often need access to a context in which the value converter is applied. This context is known as the service context. The service context might include information such as the active XAML schema context, access to the type mapping system that the XAML schema context and XAML object writer provide, and so on. For more information about the service contexts available for a value converter and how to access the services that a service context might provide, see [Service Contexts Available to Type Converters and Markup Extensions](../../../docs/framework/xaml-services/service-contexts-available-to-type-converters-and-markup-extensions.md).  
  
## See Also  
 <xref:System.Windows.Markup.MarkupExtension>  
 <xref:System.Xaml.XamlObjectWriter>  
 [Markup Extensions for XAML Overview](../../../docs/framework/xaml-services/markup-extensions-for-xaml-overview.md)  
 [Type Converters for XAML Overview](../../../docs/framework/xaml-services/type-converters-for-xaml-overview.md)  
 [Service Contexts Available to Type Converters and Markup Extensions](../../../docs/framework/xaml-services/service-contexts-available-to-type-converters-and-markup-extensions.md)
