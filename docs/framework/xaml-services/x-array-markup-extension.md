---
title: "x:Array Markup Extension"
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
  - "x:Array"
  - "xArray"
helpviewer_keywords: 
  - "x:Array [XAML Services]"
  - "XAML [XAML Services], x:Array markup extension"
ms.assetid: c5358e14-d24c-44c7-b5eb-6062a4fd981c
caps.latest.revision: 20
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:Array Markup Extension
Provides general support for arrays of objects in XAML through a markup extension. This corresponds to the `x:ArrayExtension` XAML type in [MS-XAML].  
  
## XAML Object Element Usage  
  
```  
<x:Array Type="typeName">  
  arrayContents  
</x:Array>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`typeName`|The name of the type that your `x:Array` will contain. `typeName` may be (and often is) prefixed for a XAML namespace that contains the XAML type definitions.|  
|`arrayContents`|The items content that is assigned to the intrinsic `ArrayExtension.Items` property. Typically, these items are specified as one or more object elements contained within the `x:Array` opening and closing tags. Objects specified here are expected to be assignable to the XAML type specified in `typeName`.|  
  
## Remarks  
 `Type` is a required attribute for all `x:Array` object elements. A `Type` parameter value does not need to use an `x:Type` markup extension; the short name of the type is   a XAML type, which can be specified as a string.  
  
 In the .NET Framework XAML Services implementation, the relationship between the input XAML type and the output CLR <xref:System.Type> of the created array is influenced by service context for markup extensions. The output <xref:System.Type> is the <xref:System.Xaml.XamlType.UnderlyingType%2A> of the input XAML type, after looking up the necessary <xref:System.Xaml.XamlType> based on XAML schema context and the <xref:System.Windows.Markup.IXamlTypeResolver> service the context provides.  
  
 When processed, the array contents are assigned to the `ArrayExtension.Items` intrinsic property. In the <xref:System.Windows.Markup.ArrayExtension> implementation, this is represented by <xref:System.Windows.Markup.ArrayExtension.Items%2A?displayProperty=nameWithType>.  
  
 In the .NET Framework XAML Services implementation, the handling for this markup extension is defined by the <xref:System.Windows.Markup.ArrayExtension> class. <xref:System.Windows.Markup.ArrayExtension> is not sealed, and could be used as the basis for a markup extension implementation for a custom array type.  
  
 `x:Array` is more intended for general language extensibility in XAML. But `x:Array` can also be useful for specifying XAML values of certain properties that take XAML-supported collections as their structured property content. For example, you could specify the contents of an <xref:System.Collections.IEnumerable> property with an `x:Array` usage.  
  
 `x:Array` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties. `x:Array` is partially an exception to that rule because instead of providing alternative attribute value handling, `x:Array` provides alternative handling of its inner text content. This behavior enables types that might not be supported by an existing content model to be grouped into an array and referenced later in code-behind by accessing the named array; you can call <xref:System.Array> methods to get individual array items.  
  
 All markup extensions in XAML use the braces ({,}`)` in their attribute syntax, which is the convention by which a XAML processor recognizes that a markup extension must process the attribute value. For more information about markup extensions in general, see [Type Converters and Markup Extensions for XAML](../../../docs/framework/xaml-services/type-converters-and-markup-extensions-for-xaml.md).  
  
 In XAML 2009, `x:Array` is defined as a language primitive instead of a markup extension. For more information, see [Built-in Types for Common XAML Language Primitives](../../../docs/framework/xaml-services/built-in-types-for-common-xaml-language-primitives.md).  
  
## WPF Usage Notes  
 Typically, the object elements that populate an `x:Array` are not elements that exist in the [!INCLUDE[TLA2#tla_winclient](../../../includes/tla2sharptla-winclient-md.md)] XAML namespace, and require a prefix mapping to a non-default XAML namespace.  
  
 For example, the following is a simple array of two strings, with the `sys` prefix (and also `x`) defined at the level of the array.  
  
 [xaml]  
  
 `<x:Array Type="sys:String" xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`  
  
 `xmlns:sys="clr-namespace:System;assembly=mscorlib">`  
  
 `<sys:String>Hello</sys:String>`  
  
 `<sys:String>World</sys:String>`  
  
 `</x:Array>`  
  
 For custom types that are used as array elements, the class must also support the requirements for being instantiated in XAML as object elements. For more information, see [XAML and Custom Classes for WPF](../../../docs/framework/wpf/advanced/xaml-and-custom-classes-for-wpf.md).  
  
## See Also  
 [Markup Extensions and WPF XAML](../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)  
 [Types Migrated from WPF to System.Xaml](../../../docs/framework/xaml-services/types-migrated-from-wpf-to-system-xaml.md)
