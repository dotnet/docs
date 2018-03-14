---
title: "XAML Namespaces and Namespace Mapping for WPF XAML"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "custom classes [WPF], mapping namespaces to"
  - "XAML [WPF], namespaces"
  - "namespace mapping [WPF]"
  - "assemblies [WPF], mapping namespaces to"
  - "mapping namespaces [WPF]"
  - "XAML [WPF], namespace mapping"
  - "classes [WPF], mapping namespaces to"
  - "namespaces [WPF]"
ms.assetid: 5c0854e3-7470-435d-9fe2-93eec9d3634e
caps.latest.revision: 23
author: dotnet-bot
ms.author: dotnetcontent
manager: "wpickett"
ms.workload: 
  - dotnet
---
# XAML Namespaces and Namespace Mapping for WPF XAML
This topic further explains the presence and purpose of the two XAML namespace mappings as often found in the root tag of a WPF XAML file. It also describes how to produce similar mappings for using elements that are defined in your own code, and/or within separate assemblies.  
  
  
## What is a XAML Namespace?  
 A XAML namespace is really an extension of the concept of an XML namespace. The techniques of specifying a XAML namespace rely on the XML namespace syntax, the convention of using URIs as namespace identifiers, using prefixes to provide a means to reference multiple namespaces from the same markup source, and so on. The primary concept that is added to the XAML definition of the XML namespace is that a XAML namespace implies both a scope of uniqueness for the markup usages, and also influences how markup entities are potentially backed by specific CLR namespaces and referenced assemblies. This latter consideration is also influenced by the concept of a XAML schema context. But for purposes of how WPF works with XAML namespaces, you can generally think of XAML namespaces in terms of a default XAML namespace, the XAML language namespace, and any further XAML namespaces as mapped by your XAML markup directly to specific backing CLR namespaces and referenced assemblies.  
  
<a name="The_WPF_and_XAML_Namespace_Declarations"></a>   
## The WPF and XAML Namespace Declarations  
 Within the namespace declarations in the root tag of many XAML files, you will see that there are typically two XML namespace declarations. The first declaration maps the overall WPF client / framework XAML namespace as the default:  
  
 `xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"`  
  
 The second declaration maps a separate XAML namespace, mapping it (typically) to the `x:` prefix.  
  
 `xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"`  
  
 The relationship between these declarations is that the `x:` prefix mapping supports the intrinsics that are part of the XAML language definition, and [!INCLUDE[TLA2#tla_winclient](../../../../includes/tla2sharptla-winclient-md.md)] is one implementation that uses XAML as a language and defines a vocabulary of its objects for XAML. Because the WPF vocabulary's usages will be far more common than the XAML intrinsics usages, the WPF vocabulary is mapped as the default.  
  
 The `x:` prefix convention for mapping the XAML language intrinsics support is followed by project templates, sample code, and the documentation of language features within this [!INCLUDE[TLA2#tla_sdk](../../../../includes/tla2sharptla-sdk-md.md)]. The XAML namespace defines many commonly-used features that are necessary even for basic WPF  applications. For instance, in order to join any code-behind to a XAML file through a partial class, you must name that class as the `x:Class` attribute in the root element of the relevant XAML file. Or, any element as defined in a XAML page that you wish to access as a keyed resource should have the `x:Key` attribute set on the element in question. For more information on these and other aspects of XAML see [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md) or [XAML Syntax In Detail](../../../../docs/framework/wpf/advanced/xaml-syntax-in-detail.md).  
  
<a name="Mapping_To_Custom_Classes_and_Assemblies"></a>   
## Mapping to Custom Classes and Assemblies  
 You can map XML namespaces to assemblies using a series of tokens within an `xmlns` prefix declaration, similar to how the standard WPF and XAML-intrinsics XAML namespaces are mapped to prefixes.  
  
 The syntax takes the following possible named tokens and following values:  
  
 `clr-namespace:` The CLR namespace declared within the assembly that contains the public types to expose as elements.  
  
 `assembly=` The assembly that contains some or all of the referenced [!INCLUDE[TLA2#tla_clr](../../../../includes/tla2sharptla-clr-md.md)] namespace. This value is typically just the name of the assembly, not the path, and does not include the extension (such as .dll or .exe). The path to that assembly must be established as a project reference in the project file that contains the XAML you are trying to map. In order to incorporate versioning and strong-name signing, the `assembly` value can be a string as defined by <xref:System.Reflection.AssemblyName>, rather than the simple string name.  
  
 Note that the character separating the `clr-namespace` token from its value is a colon (:) whereas the character separating the `assembly` token from its value is an equals sign (=). The character to use between these two tokens is a semicolon. Also, do not include any whitespace anywhere in the declaration.  
  
### A Basic Custom Mapping Example  
 The following code defines an example custom class:  
  
```csharp  
namespace SDKSample {  
    public class ExampleClass : ContentControl {  
        public ExampleClass() {  
        ...  
        }  
    }  
}  
```  
  
```vb  
Namespace SDKSample  
    Public Class ExampleClass  
        Inherits ContentControl  
         ...  
        Public Sub New()  
        End Sub  
    End Class  
End Namespace  
```  
  
 This custom class is then compiled into a library, which per the project settings (not shown) is named `SDKSampleLibrary`.  
  
 In order to reference this custom class, you also need to include it as a reference for your current project, which you would typically do using the Solution Explorer UI in Visual Studio.  
  
 Now that you have a library containing a class, and a reference to it in project settings, you can add the following prefix mapping as part of your root element in XAML:  
  
 `xmlns:custom="clr-namespace:SDKSample;assembly=SDKSampleLibrary"`  
  
 To put it all together, the following is XAML that includes the custom mapping along with the typical default and x: mappings in the root tag, then uses a prefixed reference to instantiate `ExampleClass` in that UI:  
  
```xaml  
<Page x:Class="WPFApplication1.MainPage"  
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"   
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"  
    xmlns:custom="clr-namespace:SDKSample;assembly=SDKSampleLibrary">  
  ...  
  <custom:ExampleClass/>  
...  
</Page>  
```  
  
### Mapping to Current Assemblies  
 `assembly` can be omitted if the `clr-namespace` referenced is being defined within the same assembly as the application code that is referencing the custom classes. Or, an equivalent syntax for this case is to specify `assembly=`, with no string token following the equals sign.  
  
 Custom classes cannot be used as the root element of a page if defined in the same assembly. Partial classes do not need to be mapped; only classes that are not the partial class of a page in your application need to be mapped if you intend to reference them as elements in XAML.  
  
<a name="Mapping_CLR_Namespaces_to_XML_Namespaces_in_an"></a>   
## Mapping CLR Namespaces to XML Namespaces in an Assembly  
 WPF defines a CLR attribute that is consumed by XAML processors in order to map multiple CLR namespaces to a single XAML namespace. This attribute, <xref:System.Windows.Markup.XmlnsDefinitionAttribute>, is placed at the assembly level in the source code that produces the assembly. The WPF assembly source code uses this attribute to map the various common namespaces, such as <xref:System.Windows> and <xref:System.Windows.Controls>, to the [!INCLUDE[TLA#tla_wpfxmlnsv1](../../../../includes/tlasharptla-wpfxmlnsv1-md.md)] namespace.  
  
 The <xref:System.Windows.Markup.XmlnsDefinitionAttribute> takes two parameters: the XML/XAML namespace name, and the CLR namespace name. More than one <xref:System.Windows.Markup.XmlnsDefinitionAttribute> can exist to map multiple CLR namespaces to the same XML namespace. Once mapped, members of those namespaces can also be referenced without full qualification if desired by providing the appropriate `using` statement in the partial-class code-behind page. For more details, see <xref:System.Windows.Markup.XmlnsDefinitionAttribute>.  
  
## Designer Namespaces and Other Prefixes From XAML Templates  
 If you are working with development environments and/or design tools for WPF XAML, you may notice that there are other defined XAML namespaces / prefixes within the XAML markup.  
  
 [!INCLUDE[wpfdesigner_current_long](../../../../includes/wpfdesigner-current-long-md.md)] uses a designer namespace that is typically mapped to the prefix `d:`. More recent project templates for WPF might pre-map this XAML namespace to support interchange of the XAML between [!INCLUDE[wpfdesigner_current_long](../../../../includes/wpfdesigner-current-long-md.md)] and other design environments. This design XAML namespace is used to perpetuate design state while roundtripping XAML-based UI in the designer. It is also used for features such as `d:IsDataSource`, which enable runtime data sources in a designer.  
  
 Another prefix you might see mapped is `mc:`. `mc:` is for markup compatibility, and is leveraging a markup compatibility pattern that is not necessarily XAML-specific. To some extent, the markup compatibility features can be used to exchange XAML between frameworks or across other boundaries of backing implementation, work between XAML schema contexts, provide compatibility for limited modes in designers, and so on. For more information on markup compatibility concepts and how they relate to WPF, see  [Markup Compatibility (mc:) Language Features](../../../../docs/framework/wpf/advanced/markup-compatibility-mc-language-features.md).  
  
## WPF and Assembly Loading  
 The XAML schema context for WPF integrates with the WPF application model, which in turn uses the CLR-defined concept of <xref:System.AppDomain>. The following sequence describes how XAML schema context interprets how to either load assemblies or find types at run time or design time, based on the WPF use of <xref:System.AppDomain> and other factors.  
  
1.  Iterate through the <xref:System.AppDomain>, looking for an already-loaded assembly that matches all aspects of the name, starting from the most recently loaded assembly.  
  
2.  If the name is qualified, call <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType> on the qualified name.  
  
3.  If the short name + public key token of a qualified name matches the assembly that the markup was loaded from, return that assembly.  
  
4.  Use the short name + public key token to call <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType>.  
  
5.  If the name is unqualified, call <xref:System.Reflection.Assembly.LoadWithPartialName%2A?displayProperty=nameWithType>.  
  
 Loose XAML does not use Step 3; there is no loaded-from assembly.  
  
 Compiled XAML for WPF (generated via XamlBuildTask) does not use the already-loaded assemblies from <xref:System.AppDomain> (Step 1). Also, the name should never be unqualified from XamlBuildTask output, so Step 5 does not apply.  
  
 Compiled BAML (generated via PresentationBuildTask) uses all steps, although BAML also should not contain unqualified assembly names.  
  
## See Also  
 [Understanding XML Namespaces](http://go.microsoft.com/fwlink/?LinkId=98069)  
 [XAML Overview (WPF)](../../../../docs/framework/wpf/advanced/xaml-overview-wpf.md)
