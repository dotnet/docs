---
title: "x:TypeArguments Directive"
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
  - "x:TypeArguments"
  - "xTypeArguments"
  - "TypeArguments"
helpviewer_keywords: 
  - "x:TypeArguments attribute [XAML Services]"
  - "TypeArguments attribute in XAML [XAML Services]"
  - "XAML [XAML Services], x:TypeArguments attribute"
ms.assetid: 86561058-d393-4a44-b5c3-993a4513ea74
caps.latest.revision: 18
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# x:TypeArguments Directive
Passes constraining type arguments of a generic to the constructor of the generic type.  
  
## XAML Attribute Usage  
  
```xaml  
<object x:TypeArguments="typeString" .../>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`object`|An object element declaration of a XAML type, which is backed by a CLR generic type. If `object` refers to a XAML type that is not from the default XAML namespace, `object` requires a prefix to indicate the XAML namespace where `object` exists.|  
|`typeString`|A string that declares one or more XAML type names as strings, which supplies the type arguments for the CLR generic type. See Remarks for additional syntax notes.|  
  
## Remarks  
 In most cases, the XAML types that are used as an information item in a `typeString` string are prefixed. Typical types of CLR generic constraints (for example, <xref:System.Int32> and <xref:System.String>) come from CLR base class libraries. Those libraries are not mapped to typical framework-specific default XAML namespaces, and therefore, require a prefix mapping for XAML usage.  
  
 You can specify more than one XAML type name by using a comma delimiter.  
  
 If the generic constraints themselves use generic types, the nested constraint type arguments can be contained by parentheses ().  
  
 Note that this definition of `x:TypeArguments` is specific to .NET Framework XAML Services and using CLR backing. A language-level definition can be found in [\[MS-XAML\] Section 5.3.11](http://go.microsoft.com/fwlink/?LinkId=114525).  
  
## Usage Examples  
 For these examples, assume that the following XAML namespace definitions are declared:  
  
```  
xmlns:sys="clr-namespace:System;assembly=mscorlib"  
xmlns:scg="clr-namespace:System.Collections.Generic;assembly=mscorlib"  
```  
  
### List\<String>  
 `<scg:List x:TypeArguments="sys:String" ...>` instantiates a new <xref:System.Collections.Generic.List%601> with a <xref:System.String> type argument.  
  
### Dictionary\<String,String>  
 `<scg:Dictionary x:TypeArguments="sys:String,sys:String" ...>` instantiates a new <xref:System.Collections.Generic.Dictionary%602> with two <xref:System.String> type arguments.  
  
### Queue<KeyValuePair\<String,String>>  
 `<scg:Queue x:TypeArguments="scg:KeyValuePair(sys:String,sys:String)" ...>` instantiates a new <xref:System.Collections.Generic.Queue%601> that has a constraint of <xref:System.Collections.Generic.KeyValuePair%602> with the inner constraint type arguments <xref:System.String> and <xref:System.String>.  
  
## XAML 2006 and WPF Generic XAML Usages  
 For XAML 2006 usage, and XAML that is used for WPF applications, the following restrictions exist for `x:TypeArguments` and generic type usages from XAML in general:  
  
-   Only the root element of a XAML file can support a generic XAML usage that references a generic type.  
  
-   The root element must map to a generic type with at least one type argument. An example is <xref:System.Windows.Navigation.PageFunction%601>. The page functions are the primary scenario for XAML generic usage support in WPF.  
  
-   The root element XAML object element for the generic must also declare a partial class using `x:Class`. This is true even if defining a WPF build action.  
  
-   `x:TypeArguments` cannot reference nested generic constraints.  
  
## XAML 2009 or XAML 2006 with No WPF 3.0 or WPF 3.5 Dependency  
 In .NET Framework XAML Services for either XAML 2006 or XAML 2009, the WPF-related restrictions on generic XAML usage are relaxed. You can instantiate a generic object element at any position in XAML markup that the backing type system and object model can support.  
  
 If you use XAML 2009 instead of mapping the CLR base types to obtain XAML types for common language primitives, you can use [Built-in Types for Common XAML Language Primitives](../../../docs/framework/xaml-services/built-in-types-for-common-xaml-language-primitives.md) as information items in a `typeString`. For example, you could declare the following (prefix mappings not shown, but x is the XAML language XAML namespace for XAML 2009):  
  
```xaml  
<my:BusinessObject x:TypeArguments="x:String,x:Int32"/>  
```  
  
 In WPF and when targeting [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], you can use XAML 2009 features together with `x:TypeArguments` but only for loose XAML (XAML that is not markup-compiled). Markup-compiled XAML for WPF and the BAML form of XAML do not currently support the XAML 2009 keywords and features. If you need to markup compile the XAML, you must operate under the restrictions noted in the "XAML 2006 and WPF Generic XAML Usages" section.  
  
## See Also  
 [x:Class Directive](../../../docs/framework/xaml-services/x-class-directive.md)  
 [x:Type Markup Extension](../../../docs/framework/xaml-services/x-type-markup-extension.md)  
 [Built-in Types for Common XAML Language Primitives](../../../docs/framework/xaml-services/built-in-types-for-common-xaml-language-primitives.md)  
 [Generics in XAML](../../../docs/framework/xaml-services/generics-in-xaml.md)
