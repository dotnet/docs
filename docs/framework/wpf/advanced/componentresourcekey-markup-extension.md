---
title: "ComponentResourceKey Markup Extension"
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
  - "ComponentResourceKey"
  - "ComponentResourceKeyExtension"
helpviewer_keywords: 
  - "ComponentResourceKey markup extension [WPF]"
  - "XAML [WPF], ComponentResourceKey markup extension"
ms.assetid: d6bcdbe6-61b3-40a7-b381-4e02185b5a85
caps.latest.revision: 14
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# ComponentResourceKey Markup Extension
Defines and references keys for resources that are loaded from external assemblies. This enables a resource lookup to specify a target type in an assembly, rather than an explicit resource dictionary in an assembly or on a class.  
  
## XAML Attribute Usage (setting key, compact)  
  
```xml  
<object x:Key="{ComponentResourceKey {x:Type targetTypeName}, targetID}" .../>  
```  
  
## XAML Attribute Usage (setting key, verbose)  
  
```xml  
<object x:Key="{ComponentResourceKey TypeInTargetAssembly={x:Type targetTypeName}, ResourceID=targetID}" .../>  
```  
  
## XAML Attribute Usage (requesting resource, compact)  
  
```xml  
<object property="{DynamicResource {ComponentResourceKey {x:Type targetTypeName}, targetID}}" .../>  
```  
  
## XAML Attribute Usage (requesting resource, verbose)  
  
```xml  
<object property="{DynamicResource {ComponentResourceKey TypeInTargetAssembly={x:Type targetTypeName}, ResourceID=targetID}}" .../>  
```  
  
## XAML Values  
  
|||  
|-|-|  
|`targetTypeName`|The name of the public [!INCLUDE[TLA#tla_clr](../../../../includes/tlasharptla-clr-md.md)] type that is defined in the resource assembly.|  
|`targetID`|The key for the resource. When resources are looked up, `targetID` will be analogous to the [x:Key Directive](../../../../docs/framework/xaml-services/x-key-directive.md) of the resource.|  
  
## Remarks  
 As seen in the usages above, a {`ComponentResourceKey`} markup extension usage is found in two places:  
  
-   The definition of a key within a theme resource dictionary, as provided by a control author.  
  
-   Accessing a theme resource from the assembly, when you are retemplating the control but want to use property values that come from resources provided by the control's themes.  
  
 For referencing component resources that come from themes, it is generally recommended that you use `{DynamicResource}` rather than `{StaticResource}`. This is shown in the usages. `{DynamicResource}` is recommended because the theme itself can be changed by the user. If you want the component resource that most closely matches the control author's intent for supporting a theme, you should enable your component resource reference to be dynamic also.  
  
 The <xref:System.Windows.ComponentResourceKey.TypeInTargetAssembly%2A> identifies a type that exists in the target assembly where the resource is actually defined. A `ComponentResourceKey` can be defined and used independently of knowing exactly where the <xref:System.Windows.ComponentResourceKey.TypeInTargetAssembly%2A> is defined, but eventually must resolve the type through referenced assemblies.  
  
 A common usage for <xref:System.Windows.ComponentResourceKey> is to define keys that are then exposed as members of a class. For this usage, you use the <xref:System.Windows.ComponentResourceKey> class constructor, not the markup extension. For more information, see <xref:System.Windows.ComponentResourceKey>, or the "Defining and Referencing Keys for Theme Resources" section of the topic [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md).  
  
 For both establishing keys and referencing keyed resources, attribute syntax is commonly used for the `ComponentResourceKey` markup extension.  
  
 The compact syntax shown relies on the <xref:System.Windows.ComponentResourceKey.%23ctor%2A?displayProperty=nameWithType> constructor signature and positional parameter usage of a markup extension. The order in which the `targetTypeName` and `targetID` are given is important. The verbose syntax relies on the <xref:System.Windows.ComponentResourceKey.%23ctor%2A?displayProperty=nameWithType> default constructor, and then sets the <xref:System.Windows.ComponentResourceKey.TypeInTargetAssembly%2A> and <xref:System.Windows.ComponentResourceKey.ResourceId%2A> in a way that is analogous to a true attribute syntax on an object element. In the verbose syntax, the order in which the properties are set is not important. The relationship and mechanisms of these two alternatives (compact and verbose) is described in more detail in the topic [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
 Technically, the value for `targetID` can be any object, it does not have to be a string. However, the most common usage in WPF is to align the `targetID` value with forms that are strings, and where such strings are valid in the [XamlName Grammar](../../../../docs/framework/xaml-services/xamlname-grammar.md).  
  
 `ComponentResourceKey` can be used in object element syntax. In this case, specifying the value of both the <xref:System.Windows.ComponentResourceKey.TypeInTargetAssembly%2A> and <xref:System.Windows.ComponentResourceKey.ResourceId%2A> properties is required to properly initialize the extension.  
  
 In the [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] reader implementation, the handling for this markup extension is defined by the <xref:System.Windows.ComponentResourceKey> class.  
  
 `ComponentResourceKey` is a markup extension. Markup extensions are typically implemented when there is a requirement to escape attribute values to be other than literal values or handler names, and the requirement is more global than just putting type converters on certain types or properties. All markup extensions in [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] use the { and } characters in their attribute syntax, which is the convention by which a [!INCLUDE[TLA2#tla_xaml](../../../../includes/tla2sharptla-xaml-md.md)] processor recognizes that a markup extension must process the attribute. For more information, see [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md).  
  
## See Also  
 <xref:System.Windows.ComponentResourceKey>  
 <xref:System.Windows.Controls.ControlTemplate>  
 [Control Authoring Overview](../../../../docs/framework/wpf/controls/control-authoring-overview.md)  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)  
 [Markup Extensions and WPF XAML](../../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)
