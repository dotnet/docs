---
title: "Markup Extensions for XAML Overview"
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
  - "markup extensions [XAML Services], custom"
  - "XAML [XAML Services], markup extensions"
ms.assetid: 261b2b11-2dc0-462f-8c66-55b8c9c6e436
caps.latest.revision: 14
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Markup Extensions for XAML Overview
Markup extensions are a XAML technique for obtaining a value that is neither a primitive nor a specific XAML type. For attribute usage, markup extensions use the known character sequence of an opening curly brace `{` to enter the markup extension scope, and a closing curly brace `}` to exit. When using .NET Framework XAML Services, you can use some of the predefined XAML language markup extensions from the System.Xaml assembly. You can also subclass from the <xref:System.Windows.Markup.MarkupExtension> class, defined in System.Xaml, and define your own markup extensions. Or you can use markup extensions defined by a particular framework if you are already referencing that framework .  
  
 When a markup extension usage is accessed, the XAML object writer can provide services to a custom <xref:System.Windows.Markup.MarkupExtension> class through a service connection point in the <xref:System.Windows.Markup.MarkupExtension.ProvideValue%2A?displayProperty=nameWithType> override. The services can be used to obtain context about the usage, specific capabilities of the object writer, XAML schema context, and so on.  
  
<a name="XAML_Defined_Markup_Extensions"></a>   
## XAML-Defined Markup Extensions  
 Several markup extensions are implemented by .NET Framework XAML Services for XAML language support. These markup extensions correspond to parts of the specification of XAML as a language. These are typically identifiable by the `x:` prefix in the syntax as seen in common usage. The .NET Framework XAML Services implementations for these XAML language elements all derive from the  <xref:System.Windows.Markup.MarkupExtension> base class .  
  
> [!NOTE]
>  The `x:` prefix is used for the typical XAML namespace mapping of the XAML language namespace, in the root element of a XAML production. For example, the [!INCLUDE[vs_current_short](../../../includes/vs-current-short-md.md)] project and page templates for various specific frameworks initiate a XAML file using this `x:` mapping. You could choose a different prefix token in your own XAML namespace mapping, but this documentation will assume the default `x:` mapping as a means of identifying those entities that are a defined part of the XAML language XAML namespace, as opposed to a specific framework's default XAML namespace or other arbitrary CLR or XML namespaces.  
  
### x:Type  
 `x:Type` supplies the <xref:System.Type> object for the named type. This functionality is used most frequently in deferral mechanisms that use underlying CLR type and type derivation as a grouping moniker or identifier. WPF styles and templates, and their usage of `TargetType` properties, are a specific example. For more information, see [x:Type Markup Extension](../../../docs/framework/xaml-services/x-type-markup-extension.md).  
  
### x:Static  
 `x:Static` produces static values from value-type code entities that are not directly the type of a property's value, but can be evaluated to that type. This is useful for specifying values that already exist as well-known constants in a type definition. For more information, see [x:Static Markup Extension](../../../docs/framework/xaml-services/x-static-markup-extension.md).  
  
### x:Null  
 `x:Null` specifies `null` as a value for a XAML member. Depending on the design of specific types or on larger framework concepts, `null` is not always a default value for a property, or the implied value of an empty string attribute. For more information, see [x:Null Markup Extension](../../../docs/framework/xaml-services/x-null-markup-extension.md).  
  
### x:Array  
 `x:Array` supports creation of general arrays in XAML syntax in cases where the collection support that is provided by base elements and control models is deliberately not used. For more information, see [x:Array Markup Extension](../../../docs/framework/xaml-services/x-array-markup-extension.md). In XAML 2009 specifically, arrays are accessed as language primitives instead of as an extension. For more information, see [XAML 2009 Language Features](../../../docs/framework/xaml-services/xaml-2009-language-features.md).  
  
### x:Reference  
 `x:Reference` is part of XAML 2009, an extension of the original (2006) language set. `x:Reference` represents a reference to another existing object in an object graph. That object is identified by its `x:Name`. For more information, see [x:Reference Markup Extension](../../../docs/framework/xaml-services/x-reference-markup-extension.md).  
  
### Other x: Constructs  
 Other `x:` constructs to support XAML language features exist, but these are not implemented as markup extensions. For more information, see [XAML Namespace (x:) Language Features](../../../docs/framework/xaml-services/xaml-namespace-x-language-features.md).  
  
<a name="the_markupextension_base_class"></a>   
## The MarkupExtension Base Class  
 To define a custom markup extension that can interact with the default implementations of XAML readers and XAML writers in System.Xaml, you derive a class from the abstract <xref:System.Windows.Markup.MarkupExtension> class. That class has one method to override, which is <xref:System.Windows.Markup.MarkupExtension.ProvideValue%2A>. You might also need to define additional constructors to support arguments to the markup extension usage, and matching settable properties.  
  
 Through <xref:System.Windows.Markup.MarkupExtension.ProvideValue%2A>, a custom markup extension has access to a service context that reports the environment where the markup extension is actually invoked by a XAML processor. In the load path this is typically a <xref:System.Xaml.XamlObjectWriter>. In the save path this is typically a <xref:System.Xaml.XamlXmlWriter>. Each report the service context as an internal XAML service provider context class that implements a service provider pattern. For more information about the available services and what they represent, see [Type Converters and Markup Extensions for XAML](../../../docs/framework/xaml-services/type-converters-and-markup-extensions-for-xaml.md).  
  
 Your markup extension class must use a public access level; XAML processors must always be able to instantiate the markup extension's support class in order to use its services.  
  
<a name="naming_the_support_type"></a>   
## Defining the Support Type for a Custom Markup Extension  
 When you use .NET Framework XAML Services or frameworks that build on .NET Framework XAML Services, you have two choices for how to name the markup extension support type. The type name is relevant to how XAML object writers attempt to access and invoke a markup extension support type when they encounter a markup extension usage in XAML. Use one of the following naming strategies:  
  
-   Name the type name to be an exact match to the XAML markup usage token. For example, to support a `{Collate ...}` extension usage, name the support type `Collate`.  
  
-   Name the type name to be the usage string token plus the suffix `Extension`. For example, to support a `{Collate ...}` extension usage, name the support type `CollateExtension`.  
  
 The order of lookup is to look for the `Extension`-suffixed class name first and then look for the class name without the `Extension` suffix.  
  
 From the markup usage perspective, including the `Extension` suffix as part of the usage is valid. However, this behaves as if `Extension` is truly part of the class name, and XAML object writers would fail to resolve a markup extension support class for that usage if the support class did not have the `Extension` suffix.  
  
### The Default Constructor  
 For all markup extension support types, you should expose a public default constructor. A default constructor is required for any case where a XAML object writer instantiates the markup extension from an object element usage. Supporting object element usage is a fair expectation for a markup extension, particularly for serialization. However, you can implement a markup extension without a public constructor if you only intend to support attribute usages of the markup extension.  
  
 If your markup extension usage has no arguments, the default constructor is required to support usage.  
  
<a name="constructor_patterns_and_positional_arguments_for_a_custom_markup_extension"></a>   
## Constructor Patterns and Positional Arguments for a Custom Markup Extension  
 For a markup extension with intended argument usage, the public constructors must correspond to the modes of the intended usage. In other words, if your markup extension is designed to require one positional argument as a valid usage, you should support a public constructor with one input parameter that takes the positional argument.  
  
 For example, suppose the `Collate` markup extension is intended to support only a mode where there is one positional argument that represents its mode, specified as a `CollationMode` enumeration constant. In this case, there should be a constructor with the following form:  
  
```  
public Collate(CollationMode collationMode) {...}  
```  
  
 At a basic level, the arguments passed to a markup extension are a string because they are being forwarded from the markup's attribute values. You can make all of your arguments strings and work with input at that level. However, you do have access to certain processing that occurs before the markup extension arguments are passed to the support class.  
  
 The processing works conceptually as if the markup extension is an object to be created, and then its member values are set. Each specified property to set is evaluated similar to how a specified member can be set on a created object when XAML is parsed. There are two important differences:  
  
-   As noted previously, a markup extension support type does not need to have a default constructor in order to be instantiated in XAML. Its object construction is deferred until its possible arguments in the text syntax are tokenized and evaluated as either positional or named arguments, and the appropriate constructor is called at that time.  
  
-   Markup extensions usages can be nested. The innermost markup extension is evaluated first. Therefore, you can assume such a usage and declare one of the construction parameters to be a type that requires a value converter (such as a markup extension) to produce.  
  
 A reliance on such processing was shown in the previous example. The .NET Framework XAML Services XAML object writer processes enumeration constant names into enumerated values at a native level.  
  
 Processing text syntax of a markup extension positional parameter can also rely on a type converter that is associated with the type that is in the construction argument.  
  
 The arguments are called positional arguments because the order in which the tokens in the usage is encountered corresponds to the positional order of the constructor parameter to which they are assigned. For example, consider the following constructor signature:  
  
```  
public Collate(CollationMode collationMode, object collateThis) {...}  
```  
  
 A XAML processor expects two positional arguments for this markup extension. If there was a usage `{Collate AlphaUp,{x:Reference circularFile}}`, the `AlphaUp` token is sent to the first parameter and evaluated as a `CollationMode` enumeration named constant. The result of the inner `x:Reference` is sent to the second parameter and evaluated as an object.  
  
 In the XAML specified rules for markup extension syntax and processing, the comma is the delimiter between arguments, whether those arguments are positional arguments or named arguments.  
  
### Duplicate Arity of Positional Arguments  
 If a XAML object writer encounters a markup extension usage with positional arguments, and there are multiple constructor arguments that take that number of arguments (a duplicate arity), that is not necessarily an error. The behavior depends on a customizable XAML schema context setting, <xref:System.Xaml.XamlSchemaContextSettings.SupportMarkupExtensionsWithDuplicateArity%2A>. If <xref:System.Xaml.XamlSchemaContextSettings.SupportMarkupExtensionsWithDuplicateArity%2A> is `true`, a XAML object writer should not throw an exception only for reasons of duplicate arity. Behavior beyond that point is not strictly defined. The basic design assumption is that the schema context has type information available for the specific parameters and can attempt explicit casts that match the duplicate candidates to see which signature might be the best match. An exception might still be thrown if no signatures can pass the tests that are imposed by that particular schema context that is running on a XAML object writer.  
  
 By default, <xref:System.Xaml.XamlSchemaContextSettings.SupportMarkupExtensionsWithDuplicateArity%2A> is `false` in the CLR-based <xref:System.Xaml.XamlSchemaContext> for .NET Framework XAML Services. Thus, the default <xref:System.Xaml.XamlObjectWriter> throws exceptions if it encounters a markup extension usage where there is duplicate arity in the backing type's constructors.  
  
<a name="named_arguments_for_a_custom_markup_extension"></a>   
## Named Arguments for a Custom Markup Extension  
 Markup extensions as specified by XAML can also use a named arguments form for usage. At the first level of tokenization, the text syntax is divided into arguments. The presence of an equals sign (=) within any argument identifies an argument as a named argument. Such an argument is also tokenized into a name/value pair. The name in this case names a public settable property of the markup extension's support type. If you intend to support named argument usage, you should provide these public settable properties. The properties can be inherited properties as long as they remain public.  
  
<a name="accessing_service_provider_context_from_a_markup_extension_implementation"></a>   
## Accessing Service Provider Context from a Markup Extension Implementation  
 The services available are the same for any value converter. The difference is in how each value converter receives the service context. Accessing services and the services available are documented in the topic [Type Converters and Markup Extensions for XAML](../../../docs/framework/xaml-services/type-converters-and-markup-extensions-for-xaml.md).  
  
<a name="property_element_usage_of_a_markup_extension"></a>   
## Property Element Usage of a Markup Extension  
 The scenarios for markup extension usages are often designed around using the markup extension in attribute usage. However, it is also potentially possible to define the backing class to support property element usage.  
  
 To support property element usage of your markup extension, define a public default constructor. This should be an instance constructor not a static constructor. This is required because a XAML processor must generally invoke the default constructor on any object element it processes from markup, and this includes markup extension classes as object elements. For advanced scenarios, you can define non-default construction paths for classes. (For more information, see [x:FactoryMethod Directive](../../../docs/framework/xaml-services/x-factorymethod-directive.md).) However, you should not use these patterns for markup extension purposes because this makes discovery of the usage pattern much more difficult, both for designers and for users of raw markup.  
  
<a name="attributing_for_a_custom_markup_extension"></a>   
## Attributing for a Custom Markup Extension  
 To support both design environments and certain XAML object writer scenarios, you should attribute a markup extension support type with several CLR attributes. These attributes report the intended markup extension usage.  
  
 <xref:System.Windows.Markup.MarkupExtensionReturnTypeAttribute> reports the <xref:System.Type> information for the object type that <xref:System.Windows.Markup.ArrayExtension.ProvideValue%2A> returns. By its pure signature, <xref:System.Windows.Markup.ArrayExtension.ProvideValue%2A> returns <xref:System.Object>. But various consumers might want more precise return type information. This includes:  
  
-   Designers and IDEs, who might be able to provide type-aware support for markup extension usages.  
  
-   Advanced implementations of `SetMarkupExtension` handlers on target classes, which might rely on reflection to determine a markup extension's return type instead of branching on specific known <xref:System.Windows.Markup.MarkupExtension> implementations by name.  
  
<a name="serialization_of_markup_extension_usages"></a>   
## Serialization of Markup Extension Usages  
 When a XAML object writer processes a markup extension usage and calls <xref:System.Windows.Markup.MarkupExtension.ProvideValue%2A>, the context for it previously being a markup extension usage persists in the XAML node stream but not in the object graph. In the object graph, only the value is preserved. If you have design scenarios or other reasons for persisting the original markup extension usage into the serialized output, you must design your own infrastructure for tracking the markup extension usages from the load path XAML node stream. You can implement behavior to recreate the elements of the node stream from the load path and play them back to XAML writers for serialization in the save path, substituting for the value in the appropriate position of the node stream.  
  
<a name="markup_extensions_in_the_xaml_node_stream"></a>   
## Markup Extensions in the XAML Node Stream  
 If you are working with a XAML node stream on the load path, a markup extension usage appears in the node stream as an object.  
  
 If the markup extension usage uses positional arguments, it is represented as a start object with an initialization value. As a rough text representation, the node stream resembles the following:  
  
 `StartObject` (<xref:System.Xaml.XamlType> is the markup extension's definition type, not its return type)  
  
 `StartMember` (name of the <xref:System.Xaml.XamlMember> is `_InitializationText`)  
  
 `Value` (value is the positional arguments as a string including the intervening delimiters)  
  
 `EndMember`  
  
 `EndObject`  
  
 A markup extension usage with named arguments is represented as an object with members of the relevant names, each set with text string values.  
  
 Actually invoking the `ProvideValue` implementation of a markup extension requires the XAML schema context because that requires type-mapping and creating a markup extension support type instance. This is one reason why markup extension usages are preserved this way in the default .NET Framework XAML Services node streams -  the reader part of a load path often does not have the necessary XAML schema context available.  
  
 If you are working with a XAML node stream on the save path, there generally is nothing present in an object graph representation that can inform you that the object to serialize was originally provided by a markup extension usage and a `ProvideValue` result. Scenarios that need to persist markup extension usages for round-tripping while also capturing other changes in the object graph must devise their own techniques for preserving the knowledge of a markup extension usage from the original XAML input. For example, to restore the markup extension usages, you may need to work with the node stream on the save path in order to restore markup extension usages, or perform some type of merge between the original XAML and the round-tripped XAML. Some XAML-implementing frameworks such as WPF use intermediate types (expressions) to help represent cases where markup extension usages provided the values.  
  
## See Also  
 <xref:System.Windows.Markup.MarkupExtension>  
 [Type Converters and Markup Extensions for XAML](../../../docs/framework/xaml-services/type-converters-and-markup-extensions-for-xaml.md)  
 [Markup Extensions and WPF XAML](../../../docs/framework/wpf/advanced/markup-extensions-and-wpf-xaml.md)
