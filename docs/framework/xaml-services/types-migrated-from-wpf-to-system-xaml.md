---
title: "Types Migrated from WPF to System.Xaml"
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
  - "WPF XAML [XAML Services], migration to System.Xaml"
  - "XAML [XAML Services], System.Xaml and WPF"
  - "System.Xaml [XAML Services], types migrated from WPF"
ms.assetid: d79dabf5-a2ec-4e8d-a37a-67c4ba8a2b91
caps.latest.revision: 14
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Types Migrated from WPF to System.Xaml
In [!INCLUDE[net_v35_long](../../../includes/net-v35-long-md.md)] and [!INCLUDE[net_v30_long](../../../includes/net-v30-long-md.md)], both [!INCLUDE[TLA#tla_winclient](../../../includes/tlasharptla-winclient-md.md)] and [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)] included a XAML language implementation. Many of the public types that provided extensibility for the WPF XAML implementation existed in the WindowsBase, PresentationCore, and PresentationFramework assemblies. Likewise, public types that provided extensibility for [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)] XAML existed in the System.Workflow.ComponentModel assembly. In the [!INCLUDE[net_v40_long](../../../includes/net-v40-long-md.md)], some of the XAML-related types are migrated to the System.Xaml assembly. A common .NET Framework implementation of XAML language services enables many XAML extensibility scenarios that were originally defined by a specific framework's XAML implementation but are now part of overall [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] XAML language support. This topic lists the types that are migrated and discusses issues related to the migration.  
  
<a name="assemblies_and_namespaces"></a>   
## Assemblies and Namespaces  
 In [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] and [!INCLUDE[net_v30_short](../../../includes/net-v30-short-md.md)], the types that WPF implemented to support XAML were generally in the <xref:System.Windows.Markup> namespace. Most of these types were in the WindowsBase assembly.  
  
 In [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], there is a new <xref:System.Xaml> namespace and a new System.Xaml assembly. Many of the types that were originally implemented for WPF XAML are now provided as extensibility points or services for any implementation of XAML. As part of making them available for more general scenarios, the types are type-forwarded from their original WPF assembly to the System.Xaml assembly. This enables XAML extensibility scenarios without having to include the assemblies of other frameworks (such as WPF and [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)]).  
  
 For migrated types, most of the types remain in the <xref:System.Windows.Markup> namespace. This was partially to avoid breaking CLR namespace mappings in existing implementations on a per-file basis. As a result, the <xref:System.Windows.Markup> namespace in [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] contains a mixture of general XAML language support types (from the System.Xaml assembly) and types that are specific to the WPF XAML implementation (from WindowsBase and other WPF assemblies). Any type that was migrated to System.Xaml, but existed previously in a WPF assembly, has type-forwarding support in version 4 of the WPF assembly.  
  
### Workflow XAML Support Types  
 [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)] also provided XAML support types, and in many cases these had identical short names to a WPF equivalent. The following is a list of [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)] XAML support types:  
  
-   <xref:System.Workflow.ComponentModel.Serialization.ContentPropertyAttribute>  
  
-   <xref:System.Workflow.ComponentModel.Serialization.RuntimeNamePropertyAttribute>  
  
-   <xref:System.Workflow.ComponentModel.Serialization.XmlnsPrefixAttribute>  
  
 These support types still exist in the [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)] assemblies for [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] and can still be used for specific [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)] applications; however, they should not be referenced by applications or frameworks that do not use [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)].  
  
<a name="markupextension"></a>   
## MarkupExtension  
 In the [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] and [!INCLUDE[net_v30_short](../../../includes/net-v30-short-md.md)], the <xref:System.Windows.Markup.MarkupExtension> class for WPF was in the WindowsBase assembly. A parallel class for [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)], <xref:System.Workflow.ComponentModel.Serialization.MarkupExtension>, existed in the System.Workflow.ComponentModel assembly. In the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the <xref:System.Windows.Markup.MarkupExtension> class is migrated to the System.Xaml assembly. In the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], <xref:System.Windows.Markup.MarkupExtension> is intended for any XAML extensibility scenario that uses .NET Framework XAML Services, not just for those that build on specific frameworks. When possible, specific frameworks or user code in the framework should also build on the <xref:System.Windows.Markup.MarkupExtension> class for XAML extension.  
  
<a name="markupextension_supporting_service_classes"></a>   
## MarkupExtension Supporting Service Classes  
 [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] and [!INCLUDE[net_v30_short](../../../includes/net-v30-short-md.md)] for WPF provided several services that were available to <xref:System.Windows.Markup.MarkupExtension> implementers and <xref:System.ComponentModel.TypeConverter> implementations to support type/property usage in XAML. These services are the following:  
  
-   <xref:System.Windows.Markup.IProvideValueTarget>  
  
-   <xref:System.Windows.Markup.IUriContext>  
  
-   <xref:System.Windows.Markup.IXamlTypeResolver>  
  
> [!NOTE]
>  Another service from [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] that is related to markup extensions is the <xref:System.Windows.Markup.IReceiveMarkupExtension> interface. <xref:System.Windows.Markup.IReceiveMarkupExtension> was not migrated and is marked `[Obsolete]` for [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)]. Scenarios that previously used <xref:System.Windows.Markup.IReceiveMarkupExtension> should instead use <xref:System.Windows.Markup.XamlSetMarkupExtensionAttribute> attributed callbacks. <xref:System.Windows.Markup.AcceptedMarkupExtensionExpressionTypeAttribute> is also marked `[Obsolete]`.  
  
<a name="xaml_language_features"></a>   
## XAML Language Features  
 Several XAML language features and components for WPF previously existed in the PresentationFramework assembly. These were implemented as a <xref:System.Windows.Markup.MarkupExtension> subclass to expose markup extension usages in XAML markup. In [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], these exist in the System.Xaml assembly so that projects that do not include WPF assemblies can use these XAML language-level features. WPF uses these same implementations for [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)] applications. As with the other cases that are listed in this topic, the supporting types continue to exist in the <xref:System.Windows.Markup> namespace to avoid breaking previous references.  
  
 The following table contains a list of the XAML feature-support classes that are defined in System.Xaml.  
  
|XAML Language Feature|Usage|  
|---------------------------|-----------|  
|<xref:System.Windows.Markup.ArrayExtension>|`<x:Array ...>`|  
|<xref:System.Windows.Markup.NullExtension>|`{x:Null}`|  
|<xref:System.Windows.Markup.StaticExtension>|`{x:Static ...}`|  
|<xref:System.Windows.Markup.TypeExtension>|`{x:Type ...}`|  
  
 Although System.Xaml may not have specific support classes, the general logic for processing language features for the XAML language now resides in System.Xaml and its implemented XAML readers and XAML writers. For example, `x:TypeArguments` is an attribute that is processed by XAML readers and XAML writers from System.Xaml implementations; it can be noted in the XAML node stream, has handling in the default (CLR-based) XAML schema context, has a XAML type-system representation, and so on. As a result, the reference documentation for all XAML language-level features is a subtopic for [XAML Services](../../../docs/framework/xaml-services/index.md) and that general area of the .NET Framework documentation set, instead of being part of the WPF documentation set as a subtopic of [Advanced (Windows Presentation Foundation)](../../../docs/framework/wpf/advanced/index.md) (as is still the case in 3.5 documentation sets).  
  
<a name="valueserializer_and_supporting_classes"></a>   
## ValueSerializer and Supporting Classes  
 The <xref:System.Windows.Markup.ValueSerializer> class supports type conversion to a string, particularly for XAML serialization cases where serialization may require multiple modes or nodes in the output. In [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] and [!INCLUDE[net_v30_short](../../../includes/net-v30-short-md.md)], the <xref:System.Windows.Markup.ValueSerializer> for WPF was in the WindowsBase assembly. In the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)], the <xref:System.Windows.Markup.ValueSerializer> class is in System.Xaml and is intended for any XAML extensibility scenario, not just for those that build on WPF. <xref:System.Windows.Markup.IValueSerializerContext> (a supporting service) and <xref:System.Windows.Markup.DateTimeValueSerializer> (a specific subclass) are also migrated to System.Xaml.  
  
<a name="xamlrelated_attributes"></a>   
## XAML-Related Attributes  
 WPF XAML included several attributes that can be applied to CLR types to indicate something about their XAML behavior. The following is a list of the attributes that existed in WPF assemblies in [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] and [!INCLUDE[net_v30_short](../../../includes/net-v30-short-md.md)]. These attributes are migrated to System.Xaml in [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)].  
  
-   <xref:System.Windows.Markup.AmbientAttribute>  
  
-   <xref:System.Windows.Markup.ContentPropertyAttribute>  
  
-   <xref:System.Windows.Markup.ContentWrapperAttribute>  
  
-   <xref:System.Windows.Markup.DependsOnAttribute>  
  
-   <xref:System.Windows.Markup.MarkupExtensionReturnTypeAttribute>  
  
-   <xref:System.Windows.Markup.NameScopePropertyAttribute>  
  
-   <xref:System.Windows.Markup.RootNamespaceAttribute>  
  
-   <xref:System.Windows.Markup.RuntimeNamePropertyAttribute>  
  
-   <xref:System.Windows.Markup.TrimSurroundingWhitespaceAttribute>  
  
-   <xref:System.Windows.Markup.ValueSerializerAttribute>  
  
-   <xref:System.Windows.Markup.WhitespaceSignificantCollectionAttribute>  
  
-   <xref:System.Windows.Markup.XmlLangPropertyAttribute>  
  
-   <xref:System.Windows.Markup.XmlnsCompatibleWithAttribute>  
  
-   <xref:System.Windows.Markup.XmlnsDefinitionAttribute>  
  
-   <xref:System.Windows.Markup.XmlnsPrefixAttribute>  
  
<a name="miscellaneous_classes"></a>   
## Miscellaneous Classes  
 The <xref:System.Windows.Markup.IComponentConnector> interface existed in WindowsBase in the [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] and [!INCLUDE[net_v30_short](../../../includes/net-v30-short-md.md)], but exists in System.Xaml in [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)]. <xref:System.Windows.Markup.IComponentConnector> is primarily intended for tooling support and XAML markup compilers.  
  
 The <xref:System.Windows.Markup.INameScope> interface existed in WindowsBase in the [!INCLUDE[net_v35_short](../../../includes/net-v35-short-md.md)] and [!INCLUDE[net_v30_short](../../../includes/net-v30-short-md.md)], but exists in System.Xaml in [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)]. <xref:System.Windows.Markup.INameScope> defines basic operations for a XAML namescope.  
  
<a name="xamlrelated_classes_with_shared_names_that_exist_in_wpf_and_systemxaml"></a>   
## XAML-related Classes with Shared Names that Exist in WPF and System.Xaml  
 The following classes exist in both the WPF assemblies and the System.Xaml assembly in the [!INCLUDE[net_v40_short](../../../includes/net-v40-short-md.md)]:  
  
 `XamlReader`  
  
 `XamlWriter`  
  
 `XamlParseException`  
  
 The WPF implementation is found in the <xref:System.Windows.Markup> namespace, and PresentationFramework assembly. The System.Xaml implementation is found in the <xref:System.Xaml> namespace. If you are using WPF types or are deriving from WPF types, you should typically use the WPF implementations of <xref:System.Windows.Markup.XamlReader> and <xref:System.Windows.Markup.XamlWriter> instead of the System.Xaml implementations. For more information, see Remarks in <xref:System.Windows.Markup.XamlReader?displayProperty=nameWithType> and <xref:System.Windows.Markup.XamlWriter?displayProperty=nameWithType>.  
  
 If you are including references to both WPF assemblies and System.Xaml, and you also are using `include` statements for both the <xref:System.Windows.Markup> and <xref:System.Xaml> namespaces, you may need to fully qualify the calls to these APIs in order to resolve the types without ambiguity.  
  
## See Also  
 [XAML Services](../../../docs/framework/xaml-services/index.md)
