---
title: "Service Contexts Available to Type Converters and Markup Extensions"
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
  - "XAML [XAML Services], type converter services how-to"
ms.assetid: b4dad00f-03da-4579-a4e9-d8d72d2ccbce
caps.latest.revision: 13
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service Contexts Available to Type Converters and Markup Extensions
Authors of the types that support type converter and markup extension usages must often have contextual information about where a usage is located in the markup, or in surrounding object graph structure. Information might be needed so that the provided object is instantiated correctly or so that object references to existing objects in the object graph can be made. When using .NET Framework XAML Services, the context that might be required is exposed as a series of service interfaces. Type converter or markup extension support code can query for a service by using a service provider context that is available and passed through from <xref:System.Xaml.XamlObjectWriter> or related types. The XAML schema context is directly available through one such service. This topic describes how to access service contexts from a value converter implementation, and lists typically available services and their roles.  
  
<a name="obtaining_services"></a>   
## Obtaining Services  
 As an implementer of a value converter, you often need access to some type of context in which the value converter is applied. This context might include information such as the active XAML schema context, access to the type mapping system that the XAML schema context and XAML object writer provide, and so on. The services available for a markup extension or type converter implementation are communicated through the context parameters that are part of the signature of each virtual method. In every case, you have <xref:System.IServiceProvider> implemented in the context, and can call <xref:System.IServiceProvider.GetService%2A?displayProperty=nameWithType> to request a service.  
  
<a name="services_for_a_markup_extension"></a>   
## Services for a Markup Extension  
 <xref:System.Windows.Markup.MarkupExtension> has only one virtual method, <xref:System.Windows.Markup.MarkupExtension.ProvideValue%2A>. The input `serviceProvider` parameter is how the services are communicated to implementations when the markup extension is called by a XAML processor. The following pseudocode illustrates how a markup extension implementation might query for services in its <xref:System.Windows.Markup.MarkupExtension.ProvideValue%2A>:  
  
```  
public override object ProvideValue(IServiceProvider serviceProvider)  
{  
...  
    // Get the IXamlTypeResolver from the service provider  
    if (serviceProvider == null)  
    {  
        throw new ArgumentNullException("serviceProvider");  
    }  
    IXamlTypeResolver xamlTypeResolver = serviceProvider.GetService(typeof(IXamlTypeResolver)) as IXamlTypeResolver;  
    if (xamlTypeResolver == null)  
   {  
        throw new ArgumentException("IXamlTypeResolver"));  
    }  
...  
}  
```  
  
<a name="services_for_a_type_converter"></a>   
## Services for a Type Converter  
 <xref:System.ComponentModel.TypeConverter> has four virtual methods that use a service context and that support XAML usages. Each of these methods passes an input `context` parameter. This parameter is of type <xref:System.ComponentModel.ITypeDescriptorContext>, but that interface inherits <xref:System.IServiceProvider>, and therefore, there is a <xref:System.IServiceProvider.GetService%2A> method available to type converter implementations.  
  
 The following pseudocode illustrates how a type converter implementation for XAML usages might query for services in one of its overrides, in this case <xref:System.ComponentModel.TypeConverter.ConvertFrom%2A>:  
  
```  
public override object ConvertFrom(ITypeDescriptorContext typeDescriptorContext,  
  CultureInfo cultureInfo,  
  object source)  
{  
    IRootObjectProvider rootProvider = typeDescriptorContext.GetService(typeof(IRootObjectProvider)) as IRootObjectProvider;  
    if (rootProvider != null && source is String)  
    {  
        //return something, else ...  
    }  
    throw GetConvertFromException(source);  
}  
```  
  
<a name="services_for_a_value_serializer"></a>   
## Services for a Value Serializer  
 For value serializer context, you use a service provider type that is specific to the <xref:System.Windows.Markup.ValueSerializer> class, <xref:System.Windows.Markup.IValueSerializerContext>. That context is passed to overrides of the four <xref:System.Windows.Markup.ValueSerializer> virtual methods. Call <xref:System.IServiceProvider.GetService%2A> from the context to obtain services.  
  
<a name="using_the_xaml_service_provider_contexts"></a>   
## Using the XAML Service Provider Contexts  
 The service provider for <xref:System.IServiceProvider.GetService%2A> access to XAML services available to markup extensions or type converters is implemented as an internal class, with exposure only through the interface and how it is passed into the relevant context . Whenever a XAML processing operation in the default .NET Framework XAML Services implementations of load path or save path invokes the relevant markup extension or type converter methods that require a service context, this internal object is passed. Depending on the circumstance, the system service context provides either `MarkupExtensionContext` or `TextSyntaxContext`, but the specifics of both of these classes are internal. Your interaction with these classes is limited to requesting services from them, through <xref:System.IServiceProvider.GetService%2A>.  
  
<a name="available_systemxaml_services"></a>   
## Available Services from the .NET Framework XAML Service Context  
 .NET Framework XAML Services defines services for markup extensions, type converters, value serializers, and potentially other usages. The following sections describe each of these services and provide guidance about how the service might be used in an implementation.  
  
### IServiceProvider  
 **Reference documentation**: <xref:System.IServiceProvider>  
  
 **Relevant to:** Basic operation of a service-based infrastructure in the .NET Framework so that you can call <xref:System.IServiceProvider.GetService%2A?displayProperty=nameWithType>.  
  
### ITypeDescriptorContext  
 **Reference documentation**: <xref:System.ComponentModel.ITypeDescriptorContext>  
  
 Derives from <xref:System.IServiceProvider>. This class represents context in the standard <xref:System.ComponentModel.TypeConverter> signatures; <xref:System.ComponentModel.TypeConverter> is a class that has existed since .NET Framework 1.0. It predates XAML and the XAML <xref:System.ComponentModel.TypeConverter> scenario for string-value type conversion. In the .NET Framework XAML Services context, methods of <xref:System.ComponentModel.TypeConverter> are implemented explicitly. The explicit implementation's behavior indicates to callers that the <xref:System.ComponentModel.ITypeDescriptorContext> API is not relevant for XAML type systems, or for reading or writing objects from XAML. <xref:System.ComponentModel.ITypeDescriptorContext.Container%2A>, <xref:System.ComponentModel.ITypeDescriptorContext.Instance%2A>, and <xref:System.ComponentModel.ITypeDescriptorContext.PropertyDescriptor%2A> generally return `null` from .NET Framework XAML Services contexts.  
  
### IValueSerializerContext  
 **Reference documentation**: <xref:System.Windows.Markup.IValueSerializerContext>  
  
 Derives from <xref:System.ComponentModel.ITypeDescriptorContext> and also relies on explicit implementations to suppress false implications about the XAML type system. Supports the static lookup helper methods on <xref:System.Windows.Markup.ValueSerializer>.  
  
### IXamlTypeResolver  
 **Reference documentation**: <xref:System.Windows.Markup.IXamlTypeResolver>  
  
 **Defined by:**  <xref:System.Windows.Markup> namespace, System.Xaml assembly  
  
 **Relevant to:** Load path scenarios, and interaction with XAML schema context  
  
 **Service API:**  <xref:System.Windows.Markup.IXamlTypeResolver.Resolve%2A>  
  
 Can influence the XAML-to-CLR type mapping that is necessary when the XAML writer constructs a CLR object in an object graph. <xref:System.Windows.Markup.IXamlTypeResolver.Resolve%2A> processes a potentially prefix-qualified string that corresponds to a XAML type name (<xref:System.Xaml.XamlType.Name%2A?displayProperty=nameWithType>), and returns a CLR <xref:System.Type>. Resolving types is typically heavily dependent on XAML schema context. Only the XAML schema context is aware of considerations such as which assemblies are loaded, and which of these assemblies can or should be accessed for type resolution.  
  
### IUriContext  
 **Reference documentation**: <xref:System.Windows.Markup.IUriContext>  
  
 **Defined by:**  <xref:System.Windows.Markup> namespace, System.Xaml assembly  
  
 **Relevant to:** Load path and save path handling of member values that are URIs or `x:Uri` values.  
  
 **Service API:**  <xref:System.Windows.Markup.IUriContext.BaseUri%2A>  
  
 This service reports a globally available URI root, if any. The URI root can be used to resolve relative URIs to absolute URIs or vice versa. This scenario is mainly relevant to application services that are exposed by a particular framework, or capabilities of a frequently used root element class in a framework. The base URI can be established as a XAML reader setting, which is then passed through to the XAML object writer and reported by this service.  
  
### IAmbientProvider  
 **Reference documentation**: <xref:System.Xaml.IAmbientProvider>  
  
 **Defined by:**  <xref:System.Xaml> namespace, System.Xaml assembly  
  
 **Relevant to:** Load path handling and type lookup deferrals or optimizations.  
  
 **Service APIs:**  <xref:System.Xaml.IAmbientProvider.GetAllAmbientValues%2A>, 3 others.  
  
 The ambience concept in XAML is a technique for marking a particular member of a type as ambient. Alternatively, a type can be ambient so that all property values that hold an instance of the type should be considered ambient properties. Markup extensions or type converters that are further along the XAML node stream and that are descendants in the object graph can access the ambient property or type instance at load time; or they can use knowledge of the ambient structure at save time. This can affect the degree of qualification that is needed to resolve types for other services, such as for <xref:System.Windows.Markup.IXamlTypeResolver> or for `x:Type`. See also <xref:System.Xaml.AmbientPropertyValue>.  
  
### IXamlSchemaContextProvider  
 **Reference documentation**: <xref:System.Xaml.IXamlSchemaContextProvider>  
  
 **Defined by:**  <xref:System.Xaml> namespace, System.Xaml assembly  
  
 **Relevant to:** Load path, and any operation that must resolve a XAML type to a backing type.  
  
 **Service API:**  <xref:System.Xaml.IXamlSchemaContextProvider.SchemaContext%2A>  
  
 XAML schema context is necessary for any defer load operations, because the same schema context must act on the deferred area in order to integrate the deferred content. For more information about the role of the XAML schema context, see [XAML Services](../../../docs/framework/xaml-services/index.md).  
  
### IRootObjectProvider  
 **Reference documentation**: <xref:System.Xaml.IRootObjectProvider>  
  
 **Defined by:**  <xref:System.Xaml> namespace, System.Xaml assembly  
  
 **Relevant to:** Load path.  
  
 **Service API:**  <xref:System.Xaml.IRootObjectProvider.RootObject%2A>  
  
 The service is relevant to application services that are exposed by a particular framework or by capabilities of a frequently used root element class in a framework. One scenario for obtaining the root object is connecting code-behind and event wiring. For example, the WPF implementation of `x:Class` is used for markup compile and wiring of any event handler attribute that is found at any other position in the XAML markup. The connection point of markup and code-behind defined partial classes for markup compile is at the root element.  
  
### IXamlNamespaceResolver  
 **Reference documentation**: <xref:System.Xaml.IXamlNamespaceResolver>  
  
 **Defined by:**  <xref:System.Xaml> namespace, System.Xaml assembly  
  
 **Relevant to:** Load path, save path.  
  
 **Service API:** <xref:System.Xaml.IXamlNamespaceResolver.GetNamespace%2A> for load path, <xref:System.Xaml.IXamlNamespaceResolver.GetNamespacePrefixes%2A> for save path.  
  
 <xref:System.Xaml.IXamlNamespaceResolver> is a service that can return a XAML namespace identifier / URI based on its prefix as mapped in the originating XAML markup.  
  
### IProvideValueTarget  
 **Reference documentation**: <xref:System.Windows.Markup.IProvideValueTarget>  
  
 **Defined by:**  <xref:System.Windows.Markup> namespace, System.Xaml assembly  
  
 **Relevant to:** Load path and save path.  
  
 **Service APIs:**  <xref:System.Windows.Markup.IProvideValueTarget.TargetObject%2A>, <xref:System.Windows.Markup.IProvideValueTarget.TargetProperty%2A>.  
  
 <xref:System.Windows.Markup.IProvideValueTarget> enables a type converter or markup extension to obtain context about where it is acting at load time. Implementations might use this context to invalidate a usage. For example, WPF has logic inside some of its markup extensions such as <xref:System.Windows.DynamicResourceExtension>. The logic checks the <xref:System.Windows.Markup.IProvideValueTarget.TargetProperty%2A> to make sure that the extension is only used to set dependency properties (or a short list of other non-dependency properties).  
  
### IXamlNameResolver  
 **Reference documentation**: <xref:System.Xaml.IXamlNameResolver>  
  
 **Defined by:**  <xref:System.Xaml> namespace, System.Xaml assembly  
  
 **Relevant to:** Load path object graph definition, resolving objects identified by `x:Name`, `x:Reference`, or framework-specific techniques.  
  
 **Service APIs:**  <xref:System.Xaml.IXamlNameResolver.Resolve%2A>; other APIs for more advanced scenarios such as dealing with forward references.  
  
 The .NET Framework XAML Services implementation of `x:Reference` handling relies on this service. Specific frameworks or tools that support the framework use this service for `x:Name` handling or equivalent (<xref:System.Windows.Markup.RuntimeNamePropertyAttribute> attributed) property handling.  
  
### IDestinationTypeProvider  
 **Reference documentation**: <xref:System.Xaml.IDestinationTypeProvider>  
  
 **Defined by:**  <xref:System.Xaml> namespace, System.Xaml assembly  
  
 **Relevant to:** Load path resolution of indirect CLR type information.  
  
 **Service API:** <xref:System.Xaml.IDestinationTypeProvider.GetDestinationType%2A>  
  
 For more information, see <xref:System.Xaml.IDestinationTypeProvider>.  
  
## See Also  
 <xref:System.Windows.Markup.MarkupExtension>  
 <xref:System.Xaml.XamlObjectWriter>  
 [Markup Extensions for XAML Overview](../../../docs/framework/xaml-services/markup-extensions-for-xaml-overview.md)  
 [Type Converters for XAML Overview](../../../docs/framework/xaml-services/type-converters-for-xaml-overview.md)
