---
title: "XAML-Related CLR Attributes for Custom Types and Libraries"
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
  - "CLR attributes for custom types [XAML Services]"
ms.assetid: 5dfb299a-b6e2-41b8-8694-e6ac987547f1
caps.latest.revision: 8
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XAML-Related CLR Attributes for Custom Types and Libraries
This topic describes the common language runtime (CLR) attributes that are defined by .NET Framework XAML Services. It also describes other CLR attributes that are defined in the .NET Framework that have a XAML-related scenario for application to assemblies or types. Attributing assemblies, types, or members with these CLR attributes provides XAML type system information related to your types. Information is provided to any XAML consumer that uses .NET Framework XAML Services for processing the XAML node stream directly or through the dedicated XAML readers and XAML writers.  
  
## XAML-Related CLR Attributes for Custom Types and Custom Members  
 Using CLR attributes entails that you are using the overall CLR to define your types, otherwise such attributes are not available. If you use the CLR to define type backing, then the default XAML schema context used by .NET  Framework XAML Services XAML writers can read CLR attribution through reflection against backing assemblies.  
  
 The following sections describe the XAML-related attributes that you can apply to custom types or custom members. Each CLR attribute communicates information that is relevant to a XAML type system. In the load path, the attributed information either helps the XAML reader form a valid XAML node stream, or it helps the XAML writer produce a valid object graph. In the save path, the attributed information either helps the XAML reader form a valid XAML node stream that reconstitutes XAML type system information; or it declares serialization hints or requirements for the XAML writer or other XAML consumers.  
  
### AmbientAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.AmbientAttribute>  
  
 **Applies to:** Class, property, or `get` accessor members that support attachable properties.  
  
 **Arguments:** None  
  
 <xref:System.Windows.Markup.AmbientAttribute> indicates that the property, or all properties that take the attributed type, should be interpreted under the ambient property concept in XAML. The ambient concept relates to how XAML processors determine type owners of members. An ambient property is a property where the value is expected to be available in the parser context when creating an object graph, but where typical type-member lookup is suspended for the immediate XAML node set being created.  
  
 The ambient concept can be applied to attachable members, which are not represented as properties in terms of how CLR attribution defines <xref:System.AttributeTargets>. The method attribution usage should be applied only in the case of a `get` accessor that supports attachable usage for XAML.  
  
### ConstructorArgumentAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.ConstructorArgumentAttribute>  
  
 **Applies to:** Class  
  
 **Arguments:** A string that specifies the name of the property that matches a single constructor argument.  
  
 <xref:System.Windows.Markup.ConstructorArgumentAttribute> specifies that an object can be initialized by using a non-default constructor syntax, and that a property of the specified name supplies construction information. This information is primarily for XAML serialization. For more information, see <xref:System.Windows.Markup.ConstructorArgumentAttribute>.  
  
### ContentPropertyAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.ContentPropertyAttribute>  
  
 **Applies to:** Class  
  
 **Arguments:** A string that specifies the name of a member of the attributed type.  
  
 <xref:System.Windows.Markup.ContentPropertyAttribute> indicates that the property as named by the argument should serve as the XAML content property for that type. The XAML content property definition inherits to all derived types that are assignable to the defining type. You can override the definition on a specific derived type by applying <xref:System.Windows.Markup.ContentPropertyAttribute> on the specific derived type.  
  
 For the property that serves as the XAML content property, property element tagging for the property can be omitted in the XAML usage. Typically, you designate XAML content properties that promote a streamlined XAML markup for your content and containment models. Because only one member can be designated as the XAML content property, you sometimes have design choices to make regarding which of several container properties of a type should be designated as the XAML content property. The other container properties must be used with explicit property elements.  
  
 In the XAML node stream, XAML content properties still produce `StartMember` and `EndMember` nodes, using the name of the property for the <xref:System.Xaml.XamlMember>. To determine whether a member is the XAML content property, examine the <xref:System.Xaml.XamlType> value from the `StartObject` position and obtain the value of <xref:System.Xaml.XamlType.ContentProperty%2A>.  
  
### ContentWrapperAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.ContentWrapperAttribute>  
  
 **Applies to:** Class, specifically collection types.  
  
 **Arguments:** A <xref:System.Type> that specifies the type to use as the content wrapper type for foreign content.  
  
 <xref:System.Windows.Markup.ContentWrapperAttribute> specifies one or more types on the associated collection type that will be used to wrap foreign content. Foreign content refers to cases where the type system constraints on the type of the content property do not capture all of the possible content cases that XAML usage for the owning type would support. For example, XAML support for content of a particular type might support strings in a strongly typed generic <xref:System.Collections.ObjectModel.Collection%601>. Content wrappers are useful for migrating preexisting markup conventions into XAML's conception of assignable values for collections, such as migrating text-related content models.  
  
 To specify more than one content wrapper type, apply the attribute multiple times.  
  
### DependsOnAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.DependsOnAttribute>  
  
 **Applies to:** Property  
  
 **Arguments:** A string that specifies the name of another member of the attributed type.  
  
 <xref:System.Windows.Markup.DependsOnAttribute> indicates that the attributed property depends on the value of another property. Applying this attribute to a property definition ensures that the dependent properties are processed first in XAML object writing. Usages of <xref:System.Windows.Markup.DependsOnAttribute> specify the exceptional cases of properties on types where a specific order of parsing must be followed for valid object creation.  
  
 You can apply multiple <xref:System.Windows.Markup.DependsOnAttribute> cases to a property definition.  
  
### MarkupExtensionReturnTypeAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.MarkupExtensionReturnTypeAttribute>  
  
 **Applies to:** Class, which is expected to be a <xref:System.Windows.Markup.MarkupExtension> derived type.  
  
 **Arguments:** A <xref:System.Type> that specifies the most precise type to expect as the `ProvideValue` result of the attributed <xref:System.Windows.Markup.MarkupExtension>.  
  
 For more information, see [Markup Extensions for XAML Overview](../../../docs/framework/xaml-services/markup-extensions-for-xaml-overview.md).  
  
### NameScopePropertyAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.NameScopePropertyAttribute>  
  
 **Applies to:** Class  
  
 **Arguments:** Supports two forms of attribution:  
  
-   A string that specifies the name of a property on the attributed type.  
  
-   A string that specifies the name of a property, and a <xref:System.Type> for the type that defines the named property. This form is for specifying an attachable member as the XAML namescope property.  
  
 <xref:System.Windows.Markup.NameScopePropertyAttribute> specifies a property that provides the XAML namescope value for the attributed class. The XAML namescope property is expected to reference an object that implements <xref:System.Windows.Markup.INameScope> and holds the actual XAML namescope, its store, and its behavior.  
  
### RuntimeNamePropertyAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.RuntimeNamePropertyAttribute>  
  
 **Applies to:** Class  
  
 **Arguments:** A string that specifies the name of the run-time name property on the attributed type.  
  
 <xref:System.Windows.Markup.RuntimeNamePropertyAttribute> reports a property of the attributed type that maps to the XAML [x:Name Directive](../../../docs/framework/xaml-services/x-name-directive.md). The property must be of type <xref:System.String> and must be read/write.  
  
 The definition inherits to all derived types that are assignable to the defining type. You can override the definition on a specific derived type by applying <xref:System.Windows.Markup.RuntimeNamePropertyAttribute> on the specific derived type.  
  
### TrimSurroundingWhitespaceAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.TrimSurroundingWhitespaceAttribute>  
  
 **Applies to:** Types  
  
 **Arguments:** None.  
  
 <xref:System.Windows.Markup.TrimSurroundingWhitespaceAttribute> is applied to specific types that might appear as child elements within whitespace significant content (content held by a collection that has <xref:System.Windows.Markup.WhitespaceSignificantCollectionAttribute>). <xref:System.Windows.Markup.TrimSurroundingWhitespaceAttribute> is mainly relevant to the save path, but is available in the XAML type system in the load path by examining <xref:System.Xaml.XamlType.TrimSurroundingWhitespace%2A?displayProperty=nameWithType>. For more information, see [Whitespace Processing in XAML](../../../docs/framework/xaml-services/whitespace-processing-in-xaml.md).  
  
### TypeConverterAttribute  
 **Reference Documentation:**  <xref:System.ComponentModel.TypeConverterAttribute>  
  
 **Applies to:** Class, property, method (the only XAML-valid method case is a `get` accessor that supports an attachable member).  
  
 **Arguments:** The <xref:System.Type> of the <xref:System.ComponentModel.TypeConverter>.  
  
 <xref:System.ComponentModel.TypeConverterAttribute> in a XAML context references a custom <xref:System.ComponentModel.TypeConverter>. This <xref:System.ComponentModel.TypeConverter> provides type conversion behavior for custom types, or members of that type.  
  
 You apply the <xref:System.ComponentModel.TypeConverterAttribute> attribute to your type, referencing your type converter implementation. You can define type converters for XAML on classes, structures, or interfaces. You do not need to provide type conversion for enumerations, that conversion is enabled natively.  
  
 Your type converter should be able to convert from a string that is used for attributes or initialization text in markup, into your intended destination type. For more information, see [TypeConverters and XAML](../../../docs/framework/wpf/advanced/typeconverters-and-xaml.md).  
  
 Rather than applying to all values of a type, a type converter behavior for XAML can also be established on a specific property. In this case, you apply <xref:System.ComponentModel.TypeConverterAttribute> to the property definition (the outer definition, not the specific `get` and `set` definitions).  
  
 A type converter behavior for XAML usage of a custom attachable member can be assigned by applying <xref:System.ComponentModel.TypeConverterAttribute> to the `get` method accessor that supports the XAML usage.  
  
 Similar to <xref:System.ComponentModel.TypeConverter>, <xref:System.ComponentModel.TypeConverterAttribute> existed in the .NET Framework prior to the existence of XAML, and the type converter model served other purposes. In order to reference and use <xref:System.ComponentModel.TypeConverterAttribute>, you must fully qualify it or provide a `using` statement for <xref:System.ComponentModel>. You must also include the System assembly in your project.  
  
### UidPropertyAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.UidPropertyAttribute>  
  
 **Applies to:** Class  
  
 **Arguments:** A string that references the relevant property by name.  
  
 Indicates the CLR property of a class that aliases the [x:Uid Directive](../../../docs/framework/xaml-services/x-uid-directive.md).  
  
### UsableDuringInitializationAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.UsableDuringInitializationAttribute>  
  
 **Applies to:** Class  
  
 **Arguments:** A Boolean. If used for the attribute's intended purpose, this should always be specified as `true`.  
  
 Indicates whether this type is built top-down during XAML object graph creation. This is an advanced concept, which is probably closely related to the definition of your programming model. For more information, see <xref:System.Windows.Markup.UsableDuringInitializationAttribute>.  
  
### ValueSerializerAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.ValueSerializerAttribute>  
  
 **Applies to:** Class, property, method (the only XAML-valid method case is a `get` accessor that supports an attachable member).  
  
 **Arguments:** A <xref:System.Type> that specifies the value serializer support class to use when serializing all properties of the attributed type, or the specific attributed property.  
  
 <xref:System.Windows.Markup.ValueSerializer> specifies a value serialization class that requires more state and context than a <xref:System.ComponentModel.TypeConverter> does. <xref:System.Windows.Markup.ValueSerializer> can be associated with an attachable member by applying the <xref:System.Windows.Markup.ValueSerializerAttribute> attribute on the static `get` accessor method for the attachable member. Value serialization is also applicable for enumerations, interfaces and structures, but not for delegates.  
  
### WhitespaceSignificantCollectionAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.WhitespaceSignificantCollectionAttribute>  
  
 **Applies to:** Class, specifically collection types that are expected to host mixed content, where white space around object elements might be significant for UI representation.  
  
 **Arguments:** None.  
  
 <xref:System.Windows.Markup.WhitespaceSignificantCollectionAttribute> indicates that a collection type should be processed as whitespace significant by a XAML processor, which influences the construction of the XAML node stream's value nodes within the collection. For more information, see [Whitespace Processing in XAML](../../../docs/framework/xaml-services/whitespace-processing-in-xaml.md).  
  
### XamlDeferLoadAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.XamlDeferLoadAttribute>  
  
 **Applies to:** Class, property.  
  
 **Arguments:** Supports two attribution forms types as strings, or types as <xref:System.Type>. See <xref:System.Windows.Markup.XamlDeferLoadAttribute>.  
  
 Indicates that a class or property has a deferred load usage for XAML (such as a template behavior), and reports the class that enables the deferring behavior and its destination/content type.  
  
### XamlSetMarkupExtensionAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.XamlSetMarkupExtensionAttribute>  
  
 **Applies to:** Class  
  
 **Arguments:** Names the callback.  
  
 Indicates that a class can use a markup extension to provide a value for one or more of its properties, and references a handler that a XAML writer should call before performing a markup extension set operation on any property of the class.  
  
### XamlSetTypeConverterAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.XamlSetTypeConverterAttribute>  
  
 **Applies to:** Class  
  
 **Arguments:** Names the callback.  
  
 Indicates that a class can use a type converter to provide a value for one or more of its properties, and references a handler that a XAML writer should call before performing a type converter set operation on any property of the class.  
  
### XmlLangPropertyAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.XmlLangPropertyAttribute>  
  
 **Applies to:** Class  
  
 **Arguments:** A string that specifies the name of the property to alias to `xml:lang` on the attributed type.  
  
 <xref:System.Windows.Markup.XmlLangPropertyAttribute> reports a property of the attributed type that maps to the XML `lang` directive. The property is not necessarily of type <xref:System.String>, but must be assignable from a string (this could be accomplished by associating a type converter with the property's type, or with the specific property). The property must be read/write.  
  
 The scenario for mapping `xml:lang` is so that a runtime object model has access to XML-specified language information without specifically processing with an XMLDOM.  
  
 The definition inherits to all derived types that are assignable to the defining type. You can override the definition on a specific derived type by applying <xref:System.Windows.Markup.XmlLangPropertyAttribute> on the specific derived type, although that is an uncommon scenario.  
  
## XAML-Related CLR Attributes at the Assembly Level  
 The following sections describe the XAML-related attributes that are not applied to types or member definitions, but are instead applied to assemblies. These attributes are pertinent to the overall goal of defining a library that contains custom types to use in XAML. Some of the attributes do not necessarily influence the XAML node stream directly, but are passed on in the node stream for other consumers to use. Consumers for the information include design environments or serialization processes that need XAML namespace information and associated prefix information. A XAML schema context (including the .NET Framework XAML Services default) also uses this information.  
  
### XmlnsCompatibleWithAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.XmlnsCompatibleWithAttribute>  
  
 **Arguments:**  
  
-   A string that specifies the identifier of the XAML namespace to subsume.  
  
-   A string that specifies the identifier of the XAML namespace that can subsume the XAML namespace from the previous argument.  
  
 <xref:System.Windows.Markup.XmlnsCompatibleWithAttribute> specifies that a XAML namespace can be subsumed by another XAML namespace. Typically, the subsuming XAML namespace is indicated in a previously defined <xref:System.Windows.Markup.XmlnsDefinitionAttribute>. This technique can be used for versioning a XAML vocabulary in a library and to make it compatible with previously defined markup against the earlier versioned vocabulary.  
  
### XmlnsDefinitionAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.XmlnsDefinitionAttribute>  
  
 **Arguments:**  
  
-   A string that specifies the identifier of the XAML namespace to define.  
  
-   A string that names a CLR namespace. The CLR namespace should define public types in your assembly, and at least one of the CLR namespace types should be intended for XAML usage.  
  
 <xref:System.Windows.Markup.XmlnsDefinitionAttribute> specifies a mapping on a per-assembly basis between a XAML namespace and a CLR namespace, which is then used for type resolution by a XAML object writer or XAML schema context.  
  
 More than one <xref:System.Windows.Markup.XmlnsDefinitionAttribute> can be applied to an assembly. This might be done for any combination of the following reasons:  
  
-   The library design contains multiple CLR namespaces for logical organization of run-time API access; however, you want all types in those namespaces to be XAML-usable by referencing the same XAML namespace. In this case, you apply several <xref:System.Windows.Markup.XmlnsDefinitionAttribute> attributes using the same <xref:System.Windows.Markup.XmlnsDefinitionAttribute.XmlNamespace%2A> value but different <xref:System.Windows.Markup.XmlnsDefinitionAttribute.ClrNamespace%2A> values. This is especially useful if you are defining mappings for the XAML namespace that your framework or application intends to be the default XAML namespace in common usage.  
  
-   The library design contains multiple CLR namespaces, and you want a deliberate XAML namespace separation between the usages of types in those CLR namespaces.  
  
-   You define a CLR namespace in the assembly, and you want it to be accessible through more than one XAML namespace. This scenario occurs when you are supporting multiple vocabularies with the same codebase.  
  
-   You define XAML language support in one or more CLR namespaces. For these, the <xref:System.Windows.Markup.XmlnsDefinitionAttribute.XmlNamespace%2A> value should be `http://schemas.microsoft.com/winfx/2006/xaml`.  
  
### XmlnsPrefixAttribute  
 **Reference Documentation:**  <xref:System.Windows.Markup.XmlnsPrefixAttribute>  
  
 **Arguments:**  
  
-   A string that specifies the identifier of a XAML namespace.  
  
-   A string that specifies a recommended prefix.  
  
 <xref:System.Windows.Markup.XmlnsDefinitionAttribute> specifies a recommended prefix to use for a XAML namespace. The prefix is useful when writing elements and attributes in a XAML file that is serialized by the .NET Framework XAML Services <xref:System.Xaml.XamlXmlWriter>, or when a XAML-implementing library interacts with a design environment that has XAML editing features.  
  
 More than one <xref:System.Windows.Markup.XmlnsPrefixAttribute> can be applied to an assembly. This might be done for any combination of the following reasons:  
  
-   Your assembly defines types for more than one XAML namespace. In this case you should define different prefix values for each XAML namespace.  
  
-   You are supporting multiple vocabularies, and you use different prefixes for each vocabulary and XAML namespace.  
  
-   You define XAML language support in the assembly and have a <xref:System.Windows.Markup.XmlnsDefinitionAttribute> for `http://schemas.microsoft.com/winfx/2006/xaml`. In this case, you typically should promote the prefix `x`.  
  
> [!NOTE]
>  .NET Framework XAML Services also defines the XAML-related attribute <xref:System.Windows.Markup.RootNamespaceAttribute>. This attribute is an assembly-level attribute for project system support, and it is not relevant for XAML custom types.  
  
## See Also  
 <xref:System.Attribute>  
 [Defining Custom Types for Use with .NET Framework XAML Services](../../../docs/framework/xaml-services/defining-custom-types-for-use-with-net-framework-xaml-services.md)
