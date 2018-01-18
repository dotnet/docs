---
title: "Default XAML Schema Context and WPF XAML Schema Context"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 04e06a15-09b3-4210-9bdf-9a64c2eccb83
caps.latest.revision: 7
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Default XAML Schema Context and WPF XAML Schema Context
A XAML schema context is a conceptual entity that qualifies how a XAML production that uses a particular XAML vocabulary interacts with the object writing behavior, including how type mapping resolves, how assemblies are loaded, how certain reader and writer settings are interpreted. This topic describes the features of the .NET Framework XAML Services and the associated default XAML schema context, which is based on the CLR type system. This topic also describes the XAML schema context that is used for WPF.  
  
## Default XAML Schema Context  
 .NET Framework XAML Services both implements and uses a default XAML schema context. The default XAML schema context behavior is not always fully visible in the API of the <xref:System.Xaml.XamlSchemaContext> class. However, in many cases the behavior that the default XAML schema context influences is observable through common API of the XAML type system, such as members of <xref:System.Xaml.XamlMember> or <xref:System.Xaml.XamlType>, or through APIs exposed on XAML readers and XAML writers that are using the default XAML schema context.  
  
 You can create a <xref:System.Xaml.XamlSchemaContext> that encapsulates the default behavior by calling the <xref:System.Xaml.XamlSchemaContext> constructor. This explicitly creates the default XAML schema context. The same default XAML schema context is created implicitly, if you initialize a XAML reader or XAML writer using APIs that do not explicitly take a <xref:System.Xaml.XamlSchemaContext> input parameter.  
  
 The default XAML schema context relies on CLR reflection for its type mapping behavior. This includes examining the defining CLR <xref:System.Type>, and related <xref:System.Reflection.PropertyInfo> or <xref:System.Reflection.MethodInfo>. Also, CLR attribution on types or members is used in order to fill in the specifics for XAML type or XAML member information that uses the CLR backing type. The default XAML schema context does not require type system extension techniques such as the `Invoker` pattern, because the necessary information is available from the CLR type system.  
  
 For assembly loading logic, the default XAML schema context relies mainly on any assembly values provided in XAML namespace mappings. Also, <xref:System.Xaml.XamlReaderSettings.LocalAssembly%2A> can hint an assembly to load, for scenarios such as loading internal types.  
  
## WPF XAML Schema Context  
 The WPF XAML schema context is described in this topic because the WPF implementation provides an interesting illustration of the kinds of features that can be introduced by implementing a non-default XAML schema context. Also, the XAML schema context concept is not discussed very much in the WPF documentation that addresses WPF XAML; the behavior that the XAML schema context enables might only be fully understandable if integrated with a discussion of how the default XAML schema context works. The WPF XAML schema context implements the following behavior.  
  
 **Lookup overrides:** WPF has a few content  models for XAML where there are XAML content properties that function without being <xref:System.Windows.Markup.ContentPropertyAttribute> attributed. <xref:System.Xaml.XamlType.LookupContentProperty%2A> overrides for WPF implement this behavior.  
  
 **Deferral for WPF expressions:** WPF features several expression classes that defer a value until a runtime context is available. Also, template expansion is a runtime behavior that relies on deferral techniques.  
  
 **Type system lookup optimizations:** WPF has an extensive XAML vocabulary and object model, including base class member definitions that inherit to literally hundreds of WPF-defined classes. Also, WPF itself is spread across several assemblies. WPF optimizes its type lookup using lookup tables and other techniques. This provides performance improvements over the default XAML schema context and its CLR-based type lookup. In cases where types do not exist in a lookup table, the behavior uses XAML schema context techniques that are similar to the default XAML schema context.  
  
 **XamlType and XamlMember extension:** WPF extends property concepts with dependency properties, and event concepts with routed events. To give these concepts greater visibility for XAML processing operations, WPF extends <xref:System.Xaml.XamlType> and <xref:System.Xaml.XamlMember>, and adds internal properties that report dependency property and routed event characteristics.  
  
### Accessing the WPF XAML Schema Context  
 If you are using XAML techniques that are based on the WPF <xref:System.Windows.Markup.XamlReader?displayProperty=nameWithType> or <xref:System.Windows.Markup.XamlWriter?displayProperty=nameWithType>, the WPF XAML schema context is already in use on those XAML reader and XAML writer implementations.  
  
 If you are using other XAML reader or XAML writer implementations that do not initialize with the WPF XAML schema context, you may be able to get a working WPF XAML schema context from <xref:System.Windows.Markup.XamlReader.GetWpfSchemaContext%2A?displayProperty=nameWithType>. You can then use this value as initialization for other API that use a <xref:System.Xaml.XamlSchemaContext>. For example, you could call <xref:System.Xaml.XamlXmlReader.%23ctor%2A> for initialization and pass the WPF XAML schema context. Or you could use the WPF XAML schema context for XAML type system operations. This might include construction initialization of a <xref:System.Xaml.XamlType> or <xref:System.Xaml.XamlMember>, or calling <xref:System.Xaml.XamlSchemaContext.GetXamlType%2A?displayProperty=nameWithType>.  
  
 Note that if you access certain aspects of WPF XAML from a pure XAML node stream perspectives, some of the WPF framework capabilities may not have acted yet. For example, WPF templates for controls are not yet applied. Thus if you access a property that at run time might be populated with a full visual tree, you might only see a property value that references a template. The service context provided for WPF markup extensions might also not be accurate if provided from a non-runtime situation, and can result in exceptions when attempting to write an object graph.  
  
## XAML and Assembly Loading  
 Assembly loading for XAML and .NET Framework XAML Services integrates with the CLR-defined concept of <xref:System.AppDomain>. A XAML schema context interprets how to either load assemblies or find types at run time or design time, based on the use of <xref:System.AppDomain> and other factors. The logic is slightly different depending on whether the XAML is loose XAML for a XAML reader, is XAML compiled into a DLL by `XamlBuildTask`, or is BAML generated by WPF's `PresentationBuildTask`.  
  
 The XAML schema context for WPF integrates with the WPF application model, which in turn uses <xref:System.AppDomain> as well as other factors that are WPF implementation details.  
  
#### XAML reader input (loose XAML)  
  
1.  The XAML schema context iterates through the <xref:System.AppDomain> of the application, looking for an already-loaded assembly that matches all aspects of the name, starting from the most recently loaded assembly. If a match is found, that assembly is used for resolution.  
  
2.  Otherwise, one of the following techniques based on CLR <xref:System.Reflection.Assembly> API are used to load an assembly:  
  
    -   If the name is qualified in the mapping, call <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType> on the qualified name.  
  
    -   If the previous step fails, use the short name (and public key token if present) to call <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType>.  
  
    -   If the name is unqualified in the mapping, call <xref:System.Reflection.Assembly.LoadWithPartialName%2A?displayProperty=nameWithType>.  
  
#### XamlBuildTask  
 `XamlBuildTask` is used for [!INCLUDE[vsindigo](../../../includes/vsindigo-md.md)] and [!INCLUDE[TLA#tla_workflow](../../../includes/tlasharptla-workflow-md.md)].  
  
 Note that assembly references through `XamlBuildTask` are always fully qualified.  
  
1.  Call <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType> on the qualified name.  
  
2.  If the previous step fails, use the short name (and public key token if present) to call <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType>.  
  
#### BAML (PresentationBuildTask)  
 There are two aspects to assembly-loading for BAML: loading the initial assembly that contains the BAML as a component, and loading the type-backing assemblies for any types referenced by the BAML production.  
  
##### Assembly load for initial markup:  
 The reference to the assembly to load the markup from is always unqualified.  
  
1.  The WPF XAML schema context iterates through the <xref:System.AppDomain> of the WPF application, looking for an already-loaded assembly that matches all aspects of the name, starting from the most recently loaded assembly. If a match is found, that assembly is used for resolution.  
  
2.  If the previous step fails, use the short name (and public key token if present) to call <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType>.  
  
##### Assembly references by BAML types:  
 Assembly references for types used in the BAML production are always fully qualified, as an output of the build task.  
  
1.  The WPF XAML schema context iterates through the <xref:System.AppDomain> of the WPF application, looking for an already-loaded assembly that matches all aspects of the name, starting from the most recently loaded assembly. If a match is found, that assembly is used for resolution.  
  
2.  Otherwise, one of the following techniques is used to load an assembly:  
  
    -   Call <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType> on the qualified name.  
  
    -   If a short name + public key token combination match the assembly that the BAML was loaded from, use that assembly.  
  
    -   Use short name + public key token to call <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType>.  
  
## See Also  
 [Understanding XAML Node Stream Structures and Concepts](../../../docs/framework/xaml-services/understanding-xaml-node-stream-structures-and-concepts.md)
