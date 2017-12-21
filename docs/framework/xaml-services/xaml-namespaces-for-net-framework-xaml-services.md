---
title: "XAML Namespaces for .NET Framework XAML Services"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-wpf"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e4f15f13-c420-4c1e-aeab-9b6f50212047
caps.latest.revision: 3
author: "wadepickett"
ms.author: "wpickett"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XAML Namespaces for .NET Framework XAML Services
A XAML namespace is a concept that expands on the definition of an XML namespace. Similar to an XML namespace, you can define a XAML namespace using an `xmlns` attribute in markup. XAML namespaces are also represented in the XAML node stream and other XAML Services APIs. This topic defines the XAML namespace concept, and describes how XAML namespaces can be defined and are used by XAML schema contexts and other aspects of .NET Framework XAML Services.  
  
## XML Namespace and XAML Namespace  
 A XAML namespace is a specialized XML namespace, just as XAML is a specialized form of XML and uses the basic XML form for its markup. In markup, you declare a XAML namespace and its mapping through an `xmlns` attribute applied to an element. The `xmlns` declaration can be made to the same element that the XAML namespace is declared in. A XAML namespace declaration made to an element is valid for that element, all attributes of that element, and all children of that element. Attributes can use a XAML namespaces that is not the same as the element that contains the attribute, so long as the attribute name itself references the prefix as part of its attribute name in markup.  
  
 The distinction of a XAML namespace versus an XML namespace is that an XML namespace might be used to reference a schema, or might be used to simply differentiate entities. For XAML, the types and members as used in XAML must ultimately be resolved to backing types, and XML schema concepts do not apply well to this capability. The XAML namespace contains information that the XAML schema context must have available in order to perform this type mapping.  
  
## XAML Namespace Components  
 The XAML namespace definition has two components: a prefix, and an identifier. Each of these components are present when a XAML namespace is declared in markup, or defined in the XAML type system.  
  
 The prefix can be any string as allowed by the [W3C Namespaces in XML 1.0 specification](http://go.microsoft.com/fwlink/?LinkID=161735) . By convention, the prefixes are typically very short strings, because the prefix is repeated many times in a typical markup file. Certain XAML namespaces that are intended to be used in multiple XAML implementations use particular conventional prefixes. For example, the XAML language XAML namespace is typically mapped using the prefix `x`. You can define a default XAML namespace, where the prefix is not given in the definition but is represented as an empty string if defined or queried by.NET Framework XAML Services API. Typically, the default XAML namespace is deliberately chosen in order to promote a maximized amount of prefix-omitting markup by a XAML-implementing technology and its scenarios and vocabularies.  
  
 The identifier can be any string as allowed by the [W3C Namespaces in XML 1.0 specification](http://go.microsoft.com/fwlink/?LinkID=161735). By convention, identifiers for either XML namespaces or XAML namespaces are often given in URI form, typically as a protocol-qualified absolute URI. Often, version information that defines a particular XAML vocabulary is implied as part of the path string. XAML namespaces add an additional identifier convention beyond the XML URI convention. For XAML namespaces, the identifier communicates information that is needed by a XAML schema context in order to resolve the types that are specified as elements under that XAML namespace, or to resolve attributes to members.  
  
 For purposes of communicating information to a XAML schema context, the identifier for a XAML namespace might still be in URI form. However, in this case the URI is also declared as a matching identifier in a particular assembly or list of assemblies. This is done in assemblies by attributing the assembly with <xref:System.Windows.Markup.XmlnsDefinitionAttribute>. This method of identifying the XAML namespace and supporting a CLR-based type resolution behavior in the attributed assembly is supported by the default XAML schema context in .NET Framework XAML Services. More generally, this convention can be used for cases where the XAML schema context incorporates the CLR or is based on the default XAML schema context, which is necessary in order to read CLR attributes from CLR assemblies.  
  
 XAML namespaces also can be identified by a convention that communicates a CLR namespace and a type-defining assembly. This convention is used in cases where no <xref:System.Windows.Markup.XmlnsDefinitionAttribute> attribution exists in the assemblies that contain types. This convention is potentially more complex than the URI convention, and also has the potential for ambiguity and duplication, because there are multiple ways of referring to an assembly.  
  
 The most basic form of an identifier that uses the CLR namespace and assembly convention is as follows:  
  
 `clr-namespace:` *clrnsName* `; assembly=` *assemblyShortName*  
  
 `clr-namespace:` and `; assembly=` are literal components of the syntax.  
  
 *clrnsName* is the string name that identifies a CLR namespace. This string name includes any internal dot characters (.) that provide hints about the CLR namespace and its relation to other CLR namespaces.  
  
 *assemblyShortName* is the string name of an assembly that defines types that are useful in XAML. The types to be accessed through the declared XAML namespace are expected to be defined by the assembly and to be specifically declared within the CLR namespace specified by *clrnsName*. This string name typically parallels the information as reported by <xref:System.Reflection.AssemblyName.Name%2A?displayProperty=nameWithType>.  
  
 A more complete definition of the CLR namespace and assembly convention is as follows:  
  
 `clr-namespace:` *clrnsName* `; assembly=` *assemblyName*  
  
 *assemblyName* represents any string that is legal as an <xref:System.Reflection.Assembly.Load%28System.String%29?displayProperty=nameWithType> input. This string can include culture, public key, or version information (definitions of these concepts are defined in the reference topic for <xref:System.Reflection.Assembly>). COFF format and evidence (as used by other overloads of <xref:System.Reflection.Assembly.Load%2A>) are not relevant for XAML assembly loading purposes; all load information must be presented as a string.  
  
 Specifying a public key for the assembly is a useful technique for XAML security, or for removing possible ambiguity that can exist if assemblies are loaded by simple name, or pre-exist in a cache or application domain. For more information, see [XAML Security Considerations](../../../docs/framework/xaml-services/xaml-security-considerations.md).  
  
## XAML Namespace Declarations in the XAML Services API  
 In the XAML Services API, a XAML namespace declaration is represented by a <xref:System.Xaml.NamespaceDeclaration> object. If you are declaring a XAML namespace in code, you call the <xref:System.Xaml.NamespaceDeclaration.%23ctor%28System.String%2CSystem.String%29> constructor. The `ns` and `prefix` parameters are specified as strings, and the input to provide for these parameters corresponds to the definition of XAML namespace identifier and XAML namespace prefix as provided previously in this topic.  
  
 If you are examining XAML namespace information as part of a XAML node stream or through other access to the XAML type system, <xref:System.Xaml.NamespaceDeclaration.Namespace%2A?displayProperty=nameWithType> reports the XAML namespace identifier, and <xref:System.Xaml.NamespaceDeclaration.Prefix%2A?displayProperty=nameWithType> reports the XAML namespace prefix.  
  
 In a XAML node stream, the XAML namespace information can appear as a XAML node that precedes the entity to which it applies. This includes cases where the XAML namespace information precedes the `StartObject` of the XAML root element. For more information, see [Understanding XAML Node Stream Structures and Concepts](../../../docs/framework/xaml-services/understanding-xaml-node-stream-structures-and-concepts.md).  
  
 For many scenarios that use .NET Framework XAML Services API, at least one XAML namespace declaration is expected to exist, and the declaration must either contain or refer to information that is required by a XAML schema context. The XAML namespaces must either specify assemblies to be loaded, or assist in resolving specific types within namespaces and assemblies that are already loaded or known by the XAML schema context.  
  
 In order to generate a XAML node stream, XAML type information must be available, through the XAML schema context. The XAML type information cannot be determined without first determining the relevant XAML namespace for each node to create. At this point, no instances of types are created yet, but the XAML schema context may need to look up information from the defining assembly and backing type. For example, in order to process the markup `<Party><PartyFavor/></Party>`, the XAML schema context must be able to determine the name and type of the `ContentProperty` of `Party`, and thus also must know the XAML namespace information for `Party` and `PartyFavor`. In the case of the default XAML schema context, static reflection reports much of the XAML type system information that is needed to generate XAML type nodes in the node stream.  
  
 In order to generate an object graph from a XAML node stream, XAML namespace declarations must exist for each XAML prefix used in the original markup and recorded in the XAML node stream. At this point, instances are being created, and true type-mapping behavior occurs.  
  
 If you need to prepopulate XAML namespace information, in cases where the XAML namespace you intend the XAML schema context to use is not defined in the markup, one technique you can use is to declare XML namespace declarations in the <xref:System.Xml.XmlParserContext> for an <xref:System.Xml.XmlReader>. Then use that <xref:System.Xml.XmlReader> as input for a XAML reader constructor, or <xref:System.Xaml.XamlServices.Load%28System.Xml.XmlReader%29?displayProperty=nameWithType>.  
  
 Two other API that are relevant for XAML namespace handling in .NET Framework XAML Services are the attributes <xref:System.Windows.Markup.XmlnsDefinitionAttribute> and <xref:System.Windows.Markup.XmlnsPrefixAttribute>. These attributes apply to assemblies. <xref:System.Windows.Markup.XmlnsDefinitionAttribute> is used by a XAML schema context to interpret any XAML namespace declaration that includes a URI. <xref:System.Windows.Markup.XmlnsPrefixAttribute> is used by tools that emit XAML so that a particular XAML namespace can be serialized with a predictable prefix. For more information, see [XAML-Related CLR Attributes for Custom Types and Libraries](../../../docs/framework/xaml-services/xaml-related-clr-attributes-for-custom-types-and-libraries.md).  
  
## See Also  
 [Understanding XAML Node Stream Structures and Concepts](../../../docs/framework/xaml-services/understanding-xaml-node-stream-structures-and-concepts.md)
