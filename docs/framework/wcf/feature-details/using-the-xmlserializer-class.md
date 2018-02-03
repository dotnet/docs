---
title: "Using the XmlSerializer Class"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "XmlSerializer [WCF], using"
ms.assetid: c680602d-39d3-44f1-bf22-8e6654ad5069
caps.latest.revision: 26
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the XmlSerializer Class
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] can use two different serialization technologies to turn the data in your application into XML that is transmitted between clients and services, a process called serialization.  
  
## DataContractSerializer as the Default  
 By default [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses the <xref:System.Runtime.Serialization.DataContractSerializer> class to serialize data types. This serializer supports the following types:  
  
-   Primitive types (for example, integers, strings, and byte arrays), as well as some special types, such as <xref:System.Xml.XmlElement> and <xref:System.DateTime>, which are treated as primitives.  
  
-   Data contract types (types marked with the <xref:System.Runtime.Serialization.DataContractAttribute> attribute).  
  
-   Types marked with the <xref:System.SerializableAttribute> attribute, which include types that implement the <xref:System.Runtime.Serialization.ISerializable> interface.  
  
-   Types that implement the <xref:System.Xml.Serialization.IXmlSerializable> interface.  
  
-   Many common collection types, which include many generic collection types.  
  
 Many [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] types fall into the latter two categories and are thus serializable. Arrays of serializable types are also serializable. For a complete list, see [Specifying Data Transfer in Service Contracts](../../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md).  
  
 The <xref:System.Runtime.Serialization.DataContractSerializer>, used together with data contract types, is the recommended way to write new [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] services. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md).  
  
## When to Use the XmlSerializer Class  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also supports the <xref:System.Xml.Serialization.XmlSerializer> class. The <xref:System.Xml.Serialization.XmlSerializer> class is not unique to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]. It is the same serialization engine that [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web services use. The <xref:System.Xml.Serialization.XmlSerializer> class supports a much narrower set of types than the <xref:System.Runtime.Serialization.DataContractSerializer> class, but allows much more control over the resulting XML and supports much more of the XML Schema definition language (XSD) standard. It also does not require any declarative attributes on the serializable types. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the XML Serialization topic in the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] documentation. The <xref:System.Xml.Serialization.XmlSerializer> class does not support data contract types.  
  
 When using Svcutil.exe or the **Add Service Reference** feature in [!INCLUDE[vsprvs](../../../../includes/vsprvs-md.md)] to generate client code for a third-party service, or to access a third-party schema, an appropriate serializer is automatically selected for you. If the schema is not compatible with the <xref:System.Runtime.Serialization.DataContractSerializer>, the <xref:System.Xml.Serialization.XmlSerializer> is selected.  
  
## Manually Switching to the XmlSerializer  
 At times, you may have to manually switch to the <xref:System.Xml.Serialization.XmlSerializer>. This happens, for example, in the following cases:  
  
-   When migrating an application from [!INCLUDE[vstecasp](../../../../includes/vstecasp-md.md)] Web services to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)], you may want to reuse existing, <xref:System.Xml.Serialization.XmlSerializer>-compatible types instead of creating new data contract types.  
  
-   When precise control over the XML that appears in messages is important, but a Web Services Description Language (WSDL) document is not available, for example, when creating a service with types that have to comply to a certain standardized, published schema that is not compatible with the DataContractSerializer.  
  
-   When creating services that follow the legacy SOAP Encoding standard.  
  
 In these and other cases, you can manually switch to the <xref:System.Xml.Serialization.XmlSerializer> class by applying the `XmlSerializerFormatAttribute` attribute to your service, as shown in the following code.  
  
 [!code-csharp[c_XmlSerializer#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_xmlserializer/cs/source.cs#1)]
 [!code-vb[c_XmlSerializer#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_xmlserializer/vb/source.vb#1)]  
  
## Security Considerations  
  
> [!NOTE]
>  It is important to be careful when switching serialization engines. The same type can serialize to XML differently depending on the serializer being used. If you accidentally use the wrong serializer, you might be disclosing information from the type that you did not intend to disclose.  
  
 For example, the <xref:System.Runtime.Serialization.DataContractSerializer> class only serializes members marked with the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute when serializing data contract types. The <xref:System.Xml.Serialization.XmlSerializer> class serializes any public member. See the type in the following code.  
  
 [!code-csharp[c_XmlSerializer#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_xmlserializer/cs/source.cs#2)]
 [!code-vb[c_XmlSerializer#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_xmlserializer/vb/source.vb#2)]  
  
 If the type is inadvertently used in a service contract where the <xref:System.Xml.Serialization.XmlSerializer> class is selected, the `creditCardNumber` member is serialized, which is probably not intended.  
  
 Even though the <xref:System.Runtime.Serialization.DataContractSerializer> class is the default, you can explicitly select it for your service (although doing this should never be required) by applying the <xref:System.ServiceModel.DataContractFormatAttribute> attribute to the service contract type.  
  
 The serializer used for the service is an integral part of the contract and cannot be changed by selecting a different binding or by changing other configuration settings.  
  
 Other important security considerations apply to the <xref:System.Xml.Serialization.XmlSerializer> class. First, it is strongly recommended that any [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] application that uses the <xref:System.Xml.Serialization.XmlSerializer> class is signed with a key that is safeguarded from disclosure. This recommendation applies both when a manual switch to the <xref:System.Xml.Serialization.XmlSerializer> is performed and when an automatic switch is performed (by Svcutil.exe, Add Service Reference, or a similar tool). This is because the <xref:System.Xml.Serialization.XmlSerializer> serialization engine supports the loading of *pre-generated serialization assemblies* as long as they are signed with the same key as the application. An unsigned application is completely unprotected from the possibility of a malicious assembly matching the expected name of the pre-generated serialization assembly being placed in the application folder or the global assembly cache. Of course, an attacker must first gain write access to one of these two locations to attempt this action.  
  
 Another threat that exists whenever you use <xref:System.Xml.Serialization.XmlSerializer> is related to write access to the system temporary folder. The <xref:System.Xml.Serialization.XmlSerializer> serialization engine creates and uses temporary *serialization assemblies* in this folder. You should be aware that any process with write access to the temporary folder may overwrite these serialization assemblies with malicious code.  
  
## Rules for XmlSerializer support  
 You cannot directly apply <xref:System.Xml.Serialization.XmlSerializer>-compatible attributes to contract operation parameters or return values. However, they can be applied to typed messages (message contract body parts), as shown in the following code.  
  
 [!code-csharp[c_XmlSerializer#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_xmlserializer/cs/source.cs#3)]
 [!code-vb[c_XmlSerializer#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_xmlserializer/vb/source.vb#3)]  
  
 When applied to typed message members, these attributes override properties that conflict on the typed message attributes. For example, in the following code, `ElementName` overrides `Name`.  
  
 [!code-csharp[c_XmlSerializer#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_xmlserializer/cs/source.cs#4)]
 [!code-vb[c_XmlSerializer#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_xmlserializer/vb/source.vb#4)]  
  
 The <xref:System.ServiceModel.MessageHeaderArrayAttribute> attribute is not supported when using the <xref:System.Xml.Serialization.XmlSerializer>.  
  
> [!NOTE]
>  In this case, the <xref:System.Xml.Serialization.XmlSerializer> throws the following exception, which is released prior to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]: "An element declared at the top level of a schema cannot have `maxOccurs` > 1. Provide a wrapper element for 'more' by using `XmlArray` or `XmlArrayItem` instead of `XmlElementAttribute`, or by using the Wrapped parameter style."  
>   
>  If you receive such an exception, investigate whether this situation applies.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] does not support the <xref:System.Xml.Serialization.SoapIncludeAttribute> and <xref:System.Xml.Serialization.XmlIncludeAttribute> attributes in message contracts and operation contracts; use the <xref:System.Runtime.Serialization.KnownTypeAttribute> attribute instead.  
  
## Types that Implement the IXmlSerializable Interface  
 Types that implement the `IXmlSerializable` interface are fully supported by the `DataContractSerializer`. The <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> attribute should always be applied to these types to control their schema.  
  
> [!WARNING]
>  If you are serializing polymorphic types you must apply the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> to the type to ensure the correct type is serialized.  
  
 There are three varieties of types that implement `IXmlSerializable`: types that represent arbitrary content, types that represent a single element, and legacy <xref:System.Data.DataSet> types.  
  
-   Content types use a schema provider method specified by the `XmlSchemaProviderAttribute` attribute. The method does not return `null` and the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute.IsAny%2A> property on the attribute is left at its default value of `false`. This is the most common usage of `IXmlSerializable` types.  
  
-   Element types are used when an `IXmlSerializable` type must control its own root element name. To mark a type as an element type, either set the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute.IsAny%2A> property on the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> attribute to `true` or return `null` from the schema provider method. Having a schema provider method is optional for element types – you may specify `null` instead of the method name in the `XmlSchemaProviderAttribute`. However, if `IsAny` is `true` and a schema provider method is specified, the method must return `null`.  
  
-   Legacy <xref:System.Data.DataSet> types are `IXmlSerializable` types that are not marked with the `XmlSchemaProviderAttribute` attribute. Instead, they rely on the <xref:System.Xml.Serialization.IXmlSerializable.GetSchema%2A> method for schema generation. This pattern is used for the `DataSet` type and its typed dataset derives a class in earlier versions of the .NET Framework, but is now obsolete and is supported only for legacy reasons. Do not rely on this pattern and always apply the `XmlSchemaProviderAttribute` to your `IXmlSerializable` types.  
  
### IXmlSerializable Content Types  
 When serializing a data member of a type that implements `IXmlSerializable` and is a content type as defined previously, the serializer writes the wrapper element for the data member and passes control to the <xref:System.Xml.Serialization.IXmlSerializable.WriteXml%2A> method. The <xref:System.Xml.Serialization.IXmlSerializable.WriteXml%2A> implementation can write any XML, which includes adding attributes to the wrapper element. After `WriteXml` is done, the serializer closes the element.  
  
 When deserializing a data member of a type that implements `IXmlSerializable` and is a content type as defined previously, the deserializer positions the XML reader on the wrapper element for the data member and passes control to the <xref:System.Xml.Serialization.IXmlSerializable.ReadXml%2A> method. The method must read the entire element, including the start and end tags. Make sure your `ReadXml` code handles the case where the element is empty. Additionally, your `ReadXml` implementation should not rely on the wrapper element being named a particular way. The name is chosen by the serializer can vary.  
  
 It is permitted to assign `IXmlSerializable` content types polymorphically, for example, to data members of type <xref:System.Object>. It is also permitted for the type instances to be null. Finally, it is possible to use `IXmlSerializable` types with object graph preservation enabled and with the <xref:System.Runtime.Serialization.NetDataContractSerializer>. All these features require the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] serializer to attach certain attributes into the wrapper element ("nil" and "type" in the XML Schema Instance namespace and "Id", "Ref", "Type" and "Assembly" in a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]-specific namespace).  
  
#### Attributes to Ignore when Implementing ReadXml  
 Before passing control to your `ReadXml` code, the deserializer examines the XML element, detects these special XML attributes, and acts on them. For example, if "nil" is `true`, a null value is deserialized and `ReadXml` is not called. If polymorphism is detected, the contents of the element are deserialized as if it was a different type. The polymorphically-assigned type’s implementation of `ReadXml` is called. In any case, a `ReadXml` implementation should ignore these special attributes because they are handled by the deserializer.  
  
### Schema Considerations for IXmlSerializable Content Types  
 When exporting schema and an `IXmlSerializable` content type, the schema provider method is called. An <xref:System.Xml.Schema.XmlSchemaSet> is passed to the schema provider method. The method can add any valid schema to the schema set. The schema set contains the schema that is already known at the time when schema export occurs. When the schema provider method must add an item to the schema set, it must determine whether an <xref:System.Xml.Schema.XmlSchema> with the appropriate namespace already exists in the set. If it does, the schema provider method must add the new item to the existing `XmlSchema`. Otherwise, it must create a new `XmlSchema` instance. This is important if arrays of `IXmlSerializable` types are being used. For example, if you have an `IXmlSerializable` type that gets exported as type "A" in namespace "B", it is possible that by the time the schema provider method is called the schema set already contains the schema for "B" to hold the "ArrayOfA" type.  
  
 In addition to adding types to the <xref:System.Xml.Schema.XmlSchemaSet>, the schema provider method for content types must return a non-null value. It can return an <xref:System.Xml.XmlQualifiedName> that specifies the name of the schema type to use for the given `IXmlSerializable` type. This qualified name also serves as the data contract name and namespace for the type. It is permitted to return a type that does not exist in the schema set immediately when the schema provider method returns. However, it is expected that by the time all related types are exported (the <xref:System.Runtime.Serialization.XsdDataContractExporter.Export%2A> method is called for all relevant types on the <xref:System.Runtime.Serialization.XsdDataContractExporter> and the <xref:System.Runtime.Serialization.XsdDataContractExporter.Schemas%2A> property is accessed), the type exists in the schema set. Accessing the `Schemas` property before all relevant `Export` calls have been made can result in an <xref:System.Xml.Schema.XmlSchemaException>. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the export process, see [Exporting Schemas from Classes](../../../../docs/framework/wcf/feature-details/exporting-schemas-from-classes.md).  
  
 The schema provider method can also return the <xref:System.Xml.Schema.XmlSchemaType> to use. The type may or may not be anonymous. If it is anonymous, the schema for the `IXmlSerializable` type is exported as an anonymous type every time the `IXmlSerializable` type is used as a data member. The `IXmlSerializable` type still has a data contract name and namespace. (This is determined as described in [Data Contract Names](../../../../docs/framework/wcf/feature-details/data-contract-names.md) except that the <xref:System.Runtime.Serialization.DataContractAttribute> attribute cannot be used to customize the name.) If it is not anonymous, it must be one of the types in the `XmlSchemaSet`. This case is equivalent to returning the `XmlQualifiedName` of the type.  
  
 Additionally, a global element declaration is exported for the type. If the type does not have the <xref:System.Xml.Serialization.XmlRootAttribute> attribute applied to it, the element has the same name and namespace as the data contract, and its "nillable" property is `true`. The only exception to this is the schema namespace ("http://www.w3.org/2001/XMLSchema") – if the type’s data contract is in this namespace, the corresponding global element is in the blank namespace because it is forbidden to add new elements to the schema namespace. If the type has the `XmlRootAttribute` attribute applied to it, the global element declaration is exported using the following: <xref:System.Xml.Serialization.XmlRootAttribute.ElementName%2A>, <xref:System.Xml.Serialization.XmlRootAttribute.Namespace%2A> and <xref:System.Xml.Serialization.XmlRootAttribute.IsNullable%2A> properties. The defaults with `XmlRootAttribute` applied are the data contract name, a blank namespace and "nillable" being `true`.  
  
 The same global element declaration rules apply to legacy dataset types. Note that the `XmlRootAttribute` cannot override global element declarations added through custom code, either added to the `XmlSchemaSet` using the schema provider method or through `GetSchema` for legacy dataset types.  
  
### IXmlSerializable Element Types  
 `IXmlSerializable` element types have either the `IsAny` property set to `true` or have their schema provider method return `null`.  
  
 Serializing and deserializing an element type is very similar to serializing and deserializing a content type. However, there are some important differences:  
  
-   The `WriteXml` implementation is expected to write exactly one element (which could of course contain multiple child elements). It should not be writing attributes outside of this single element, multiple sibling elements or mixed content. The element may be empty.  
  
-   The `ReadXml` implementation should not read the wrapper element. It is expected to read the one element that `WriteXml` produces.  
  
-   When serializing an element type regularly (for example, as a data member in a data contract), the serializer outputs a wrapper element before calling `WriteXml`, as with content types. However, when serializing an element type at the top level, the serializer does not normally output a wrapper element at all around the element that `WriteXml` writes, unless a root name and namespace are explicitly specified when constructing the serializer in the `DataContractSerializer` or `NetDataContractSerializer` constructors. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Serialization and Deserialization](../../../../docs/framework/wcf/feature-details/serialization-and-deserialization.md).  
  
-   When serializing an element type at the top level without specifying the root name and namespace at construction time, <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteStartObject%2A> and <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteEndObject%2A> essentially do nothing and <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteObjectContent%2A> calls `WriteXml`. In this mode, the object being serialized cannot be `null` and cannot be polymorphically assigned. Also, object graph preservation cannot enabled and the `NetDataContractSerializer` cannot be used.  
  
-   When deserializing an element type at the top level without specifying the root name and namespace at construction time, <xref:System.Runtime.Serialization.XmlObjectSerializer.IsStartObject%2A> returns `true` if it can find the start of any element. <xref:System.Runtime.Serialization.XmlObjectSerializer.ReadObject%2A> with the `verifyObjectName` parameter set to `true` behaves in the same way as `IsStartObject` before actually reading the object. `ReadObject` then passes control to `ReadXml` method.  
  
 The schema exported for element types is the same as for the `XmlElement` type as described in an earlier section, except that the schema provider method can add any additional schema to the <xref:System.Xml.Schema.XmlSchemaSet> as with content types. Using the `XmlRootAttribute` attribute with element types is not allowed, and global element declarations are never emitted for these types.  
  
### Differences from the XmlSerializer  
 The `IXmlSerializable` interface and the `XmlSchemaProviderAttribute` and `XmlRootAttribute` attributes are also understood by the <xref:System.Xml.Serialization.XmlSerializer> . However, there are some differences in how these are treated in the data contract model. The important differences are summarized in the following list:  
  
-   The schema provider method must be public to be used in the `XmlSerializer`, but does not have to be public to be used in the data contract model.  
  
-   The schema provider method is called when `IsAny` is `true` in the data contract model but not with the `XmlSerializer`.  
  
-   When the `XmlRootAttribute` attribute is not present for content or legacy dataset types, the `XmlSerializer` exports a global element declaration in the blank namespace. In the data contract model, the namespace used is normally the data contract namespace as described earlier.  
  
 Be aware of these differences when creating types that are used with both serialization technologies.  
  
### Importing IXmlSerializable Schema  
 When importing a schema generated from `IXmlSerializable` types, there are a few possibilities:  
  
-   The generated schema may be a valid data contract schema as described in [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md). In this case, schema can be imported as usual and regular data contract types are generated.  
  
-   The generated schema may not be a valid data contract schema. For example, your schema provider method may generate schema that involves XML attributes that are not supported in the data contract model. In this case, you can import the schema as `IXmlSerializable` types. This import mode is not on by default but can easily be enabled – for example, with the `/importXmlTypes` command-line switch to the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). This is described in detail in the [Importing Schema to Generate Classes](../../../../docs/framework/wcf/feature-details/importing-schema-to-generate-classes.md). Note that you must work directly with the XML for your type instances. You may also consider using a different serialization technology that supports a wider range of schema – see the topic on using the `XmlSerializer`.  
  
-   You may want to reuse your existing `IXmlSerializable` types in the proxy instead of generating new ones. In this case, the referenced types feature described in the Importing Schema to Generate Types topic can be used to indicate the type to reuse. This corresponds to using the `/reference` switch on svcutil.exe, which specifies the assembly that contains the types to reuse.  
  
### XmlSerializer Legacy Behavior  
 In the .NET Framework 4.0 and earlier, the XmlSerializer generated temporary serialization assemblies by writing C# code to a file. The file was then compiled into an assembly.  This behavior had some undesirable consequences like slowing the startup time for the serializer. In .NET Framework 4.5, this behavior was changed to generate the assemblies without requiring use of the compiler. Some developers may wish to see the generated C# code. You can specify to use this legacy behavior by the following configuration:  
  
```xml  
<?xml version="1.0" encoding="utf-8" ?>  
<configuration>  
  <system.xml.serialization>  
    <xmlSerializer tempFilesLocation='e:\temp\XmlSerializerBug' useLegacySerializerGeneration="true" />  
  </system.xml.serialization>  
  <system.diagnostics>  
    <switches>  
      <add name="XmlSerialization.Compilation" value="1" />  
    </switches>  
  </system.diagnostics>  
</configuration>  
```  
  
 If you run into compatibility issues,  such as the `XmlSerializer` failing to serialize a derived class with a non-public new override, you can switch back to the  `XMLSerializer` legacy behavior by using the following configuration:  
  
```xml  
<configuration>  
<appSettings>   
<add key="System:Xml:Serialization:UseLegacySerializerGeneration" value="true" />  
               </appSettings>  
</configuration>  
```  
  
 As an alternative to the above configuration, you can use the following configuration on a machine running .NET Framework 4.5 or later version:  
  
```xml  
<configuration>  
<system.xml.serialization>  
<xmlSerializer useLegacySerializerGeneration="true"/>  
</system.xml.serialization>  
</configuration>  
```  
  
> [!NOTE]
>  The `<xmlSerializer useLegacySerializerGeneration="true"/>` switch only works on a machine running .NET Framework 4.5 or later version. The above `appSettings` approach works on all .NET Framework versions.  
  
## See Also  
 <xref:System.ServiceModel.DataContractFormatAttribute>  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Xml.Serialization.XmlSerializer>  
 <xref:System.ServiceModel.MessageHeaderArrayAttribute>  
 [Specifying Data Transfer in Service Contracts](../../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md)  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
 [How to: Improve the Startup Time of WCF Client Applications using the XmlSerializer](../../../../docs/framework/wcf/feature-details/startup-time-of-wcf-client-applications-using-the-xmlserializer.md)
