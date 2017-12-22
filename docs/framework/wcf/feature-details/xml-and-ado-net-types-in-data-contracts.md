---
title: "XML and ADO.NET Types in Data Contracts"
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
ms.assetid: c2ce8461-3c15-4c41-8c81-1cb78f5b59a6
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# XML and ADO.NET Types in Data Contracts
The [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] data contract model supports certain types that represent XML directly. When these types are serialized to XML, the serializer writes out the XML contents of these types without any further processing. Supported types are <xref:System.Xml.XmlElement>, arrays of <xref:System.Xml.XmlNode> (but not the `XmlNode` type itself), as well as types that implement <xref:System.Xml.Serialization.IXmlSerializable>. The <xref:System.Data.DataSet> and <xref:System.Data.DataTable> type, as well as typed datasets, are commonly used in database programming. These types implement the `IXmlSerializable` interface and are therefore serializable in the data contract model. Some special considerations for these types are listed at the end of this topic.  
  
## XML Types  
  
### Xml Element  
 The `XmlElement` type is serialized using its XML contents. For example, using the following type.  
  
 [!code-csharp[DataContractAttribute#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/datacontractattribute/cs/overview.cs#4)]
 [!code-vb[DataContractAttribute#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/datacontractattribute/vb/overview.vb#4)]  
  
 This is serialized to XML as follows:  
  
```xml  
<MyDataContract xmlns="http://schemas.contoso.com">  
    <myDataMember>  
        <myElement xmlns="" myAttribute="myValue">  
            myContents  
        </myElement>  
    </myDataMember>  
</MyDataContract>  
```  
  
 Notice that a wrapper data member element `<myDataMember>` is still present. There is no way of removing this element in the data contract model. The serializers that handle this model (the <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.NetDataContractSerializer>) may emit special attributes into this wrapper element. These attributes include the standard XML Schema Instance "nil" attribute (allowing the `XmlElement` to be `null`) and the "type" attribute (allowing `XmlElement` to be used polymorphically). Also, the following XML attributes are specific to [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]: "Id", "Ref", "Type" and "Assembly". These attributes may be emitted to support using the `XmlElement` with the object graph preservation mode enabled, or with the <xref:System.Runtime.Serialization.NetDataContractSerializer>. ([!INCLUDE[crabout](../../../../includes/crabout-md.md)] the object graph preservation mode, see [Serialization and Deserialization](../../../../docs/framework/wcf/feature-details/serialization-and-deserialization.md).)  
  
 Arrays or collections of `XmlElement` are allowed and are handled as any other array or collection. That is, there is a wrapper element for the entire collection, and a separate wrapper element (similar to `<myDataMember>` in the preceding example) for each `XmlElement` in the array.  
  
 On deserialization, an `XmlElement` is created by the deserializer from the incoming XML. A valid parent <xref:System.Xml.XmlDocument> is provided by the deserializer.  
  
 Make sure that the XML fragment that is deserialized to an `XmlElement` defines all prefixes that it uses and does not rely on any prefix definitions from ancestor elements. This is a concern only when using the `DataContractSerializer` to access XML from a different (non-`DataContractSerializer`) source.  
  
 When used with the `DataContractSerializer`, the `XmlElement` may be assigned polymorphically, but only to a data member of type <xref:System.Object>. Even though it implements <xref:System.Collections.IEnumerable>, an `XmlElement` cannot be used as a collection type and cannot be assigned to an <xref:System.Collections.IEnumerable> data member. As with all polymorphic assignments, the `DataContractSerializer` emits the data contract name in the resulting XML – in this case, it is "XmlElement" in the "http://schemas.datacontract.org/2004/07/System.Xml" namespace.  
  
 With the `NetDataContractSerializer`, any valid polymorphic assignment of `XmlElement` (to `Object` or `IEnumerable`) is supported.  
  
 Do not attempt to use either of the serializers with types derived from `XmlElement`, whether they are assigned polymorphically or not.  
  
### Array of XmlNode  
 Using arrays of <xref:System.Xml.XmlNode> is very similar to using `XmlElement`. Using arrays of `XmlNode` gives you more flexibility than using `XmlElement`. You can write multiple elements inside the data member wrapping element. You can also inject content other than elements inside of the data member wrapping element, such as XML comments. Finally, you can put attributes into the wrapping data member element. All this can be achieved by populating the array of `XmlNode` with specific derived classes of `XmlNode` such as <xref:System.Xml.XmlAttribute>, `XmlElement` or <xref:System.Xml.XmlComment>. For example, using the following type.  
  
 [!code-csharp[DataContractAttribute#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/datacontractattribute/cs/overview.cs#5)]
 [!code-vb[DataContractAttribute#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/datacontractattribute/vb/overview.vb#5)]  
  
 When serialized, the resulting XML is similar to the following code.  
  
```xml  
<MyDataContract xmlns="http://schemas.contoso.com">  
  <myDataMember myAttribute="myValue">  
     <!--myComment-->  
     <myElement xmlns="" myAttribute="myValue">  
 myContents  
     </myElement>  
     <myElement xmlns="" myAttribute="myValue">  
       myContents  
     </myElement>  
  </myDataMember>  
</MyDataContract>  
```  
  
 Note that the data member wrapper element `<myDataMember>` contains an attribute, a comment, and two elements. These are the four `XmlNode` instances that were serialized.  
  
 An array of `XmlNode` that results in invalid XML cannot be serialized. For example, an array of two `XmlNode` instances where the first one is an `XmlElement` and the second one is an <xref:System.Xml.XmlAttribute> is invalid, because this sequence does not correspond to any valid XML instance (there is no place to attach the attribute to).  
  
 On deserialization of an array of `XmlNode`, nodes are created and populated with information from the incoming XML. A valid parent <xref:System.Xml.XmlDocument> is provided by the deserializer. All nodes are deserialized, including any attributes on the wrapper data member element, but excluding the attributes placed there by the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] serializers (such as the attributes used to indicate polymorphic assignment). The caveat about defining all namespace prefixes in the XML fragment applies to the deserialization of arrays of `XmlNode` just like it does to deserializing `XmlElement`.  
  
 When using the serializers with object graph preservation turned on, object equality is only preserved on the level of `XmlNode` arrays, not individual `XmlNode` instances.  
  
 Do not attempt to serialize an array of `XmlNode` where one or more of the nodes is set to `null`. It is permitted for the entire array member to be `null`, but not for any individual `XmlNode` contained in the array. If the entire array member is null, the wrapper data member element contains a special attribute that indicates that it is null. On deserialization, the entire array member also becomes null.  
  
 Only regular arrays of `XmlNode` are treated specially by the serializer. Data members declared as other collection types that contain `XmlNode`, or data members declared as arrays of types derived from `XmlNode`, are not treated specially. Thus, they are normally not serializable unless they also meet one of the other criteria for serializing.  
  
 Arrays or collections of arrays of `XmlNode` are allowed. There is a wrapper element for the entire collection, and a separate wrapper element (similar to `<myDataMember>` in the preceding example) for each array of `XmlNode` in the outer array or collection.  
  
 Populating a data member of type <xref:System.Array> of `Object` or `Array` of `IEnumerable` with `XmlNode` instances does not result in the data member being treated as an `Array` of `XmlNode` instances. Each array member is serialized separately.  
  
 When used with the `DataContractSerializer`, arrays of `XmlNode` can be assigned polymorphically, but only to a data member of type `Object`. Even though it implements `IEnumerable`, an array of `XmlNode` cannot be used as a collection type and be assigned to an `IEnumerable` data member. As with all polymorphic assignments, the `DataContractSerializer` emits the data contract name in the resulting XML – in this case, it is "ArrayOfXmlNode" in the "http://schemas.datacontract.org/2004/07/System.Xml" namespace. When used with the `NetDataContractSerializer`, any valid assignment of an `XmlNode` array is supported.  
  
### Schema Considerations  
 For details about the schema mapping of XML types, see [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md). This section provides a summary of the important points.  
  
 A data member of type `XmlElement` is mapped to an element defined using the following anonymous type.  
  
```xml  
<xsd:complexType>  
   <xsd:sequence>  
      <xsd:any minOccurs="0" processContents="lax" />  
   </xsd:sequence>  
</xsd:complexType>  
```  
  
 A data member of type Array of `XmlNode` is mapped to an element defined using the following anonymous type.  
  
```xml  
<xsd:complexType mixed="true">  
   <xsd:sequence>  
      <xsd:any minOccurs="0" maxOccurs="unbounded" processContents="lax" />  
   </xsd:sequence>  
   <xsd:anyAttribute/>  
</xsd:complexType>  
```  
  
## Types Implementing the IXmlSerializable Interface  
 Types that implement the `IXmlSerializable` interface are fully supported by the `DataContractSerializer`. The <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> attribute should always be applied to these types to control their schema.  
  
 There are three varieties of types that implement `IXmlSerializable`: types that represent arbitrary content, types that represent a single element, and legacy <xref:System.Data.DataSet> types.  
  
-   Content types use a schema provider method specified by the `XmlSchemaProviderAttribute` attribute. The method does not return `null`, and the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute.IsAny%2A> property on the attribute is left at its default value of `false`. This is the most common usage of `IXmlSerializable` types.  
  
-   Element types are used when an `IXmlSerializable` type must control its own root element name. To mark a type as an element type, either set the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute.IsAny%2A> property on the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> attribute to `true` or return null from the schema provider method. Having a schema provider method is optional for element types – you may specify null instead of the method name in the `XmlSchemaProviderAttribute`. However, if `IsAny` is `true` and a schema provider method is specified, the method must return null.  
  
-   Legacy <xref:System.Data.DataSet> types are `IXmlSerializable` types that are not marked with the `XmlSchemaProviderAttribute` attribute. Instead, they rely on the <xref:System.Xml.Serialization.IXmlSerializable.GetSchema%2A> method for schema generation. This pattern is used for the `DataSet` type and its typed dataset derives a class in earlier versions of the .NET Framework, but is now obsolete and is supported only for legacy reasons. Do not rely on this pattern and always apply the `XmlSchemaProviderAttribute` to your `IXmlSerializable` types.  
  
### IXmlSerializable Content Types  
 When serializing a data member of a type that implements `IXmlSerializable` and is a content type as defined previously, the serializer writes the wrapper element for the data member and pass control to the <xref:System.Xml.Serialization.IXmlSerializable.WriteXml%2A> method. The <xref:System.Xml.Serialization.IXmlSerializable.WriteXml%2A> implementation can write any XML, including adding attributes to the wrapper element. After `WriteXml` is done, the serializer closes the element.  
  
 When deserializing a data member of a type that implements `IXmlSerializable` and is a content type as defined previously, the deserializer positions the XML reader on the wrapper element for the data member and pass control to the <xref:System.Xml.Serialization.IXmlSerializable.ReadXml%2A> method. The method must read the entire element, including the start and end tags. Make sure your `ReadXml` code handles the case where the element is empty. Additionally, your `ReadXml` implementation should not rely on the wrapper element being named a particular way. The name is chosen by the serializer can vary.  
  
 It is permitted to assign `IXmlSerializable` content types polymorphically, for example, to data members of type <xref:System.Object>. It is also permitted for the type instances to be null. Finally, it is possible to use `IXmlSerializable` types with object graph preservation enabled and with the <xref:System.Runtime.Serialization.NetDataContractSerializer>. All these features require the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] serializer to attach certain attributes into the wrapper element ("nil" and "type" in the XML Schema Instance namespace and "Id", "Ref", "Type" and "Assembly" in a [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)]-specific namespace).  
  
#### Attributes to Ignore when Implementing ReadXml  
 Before passing control to your `ReadXml` code, the deserializer examines the XML element, detects these special XML attributes, and acts on them. For example, if "nil" is `true`, a null value is deserialized and `ReadXml` is not called. If polymorphism is detected, the contents of the element are deserialized as if it was a different type. The polymorphically assigned type’s implementation of `ReadXml` is called. In any case, a `ReadXml` implementation should ignore these special attributes because they are handled by the deserializer.  
  
### Schema Considerations for IXmlSerializable Content Types  
 When exporting schema an `IXmlSerializable` content type, the schema provider method is called. An <xref:System.Xml.Schema.XmlSchemaSet> is passed to the schema provider method. The method can add any valid schema to the schema set. The schema set contains the schema that is already known at the time when schema export occurs. When the schema provider method must add an item to the schema set, it must determine if an <xref:System.Xml.Schema.XmlSchema> with the appropriate namespace already exists in the set. If it does, the schema provider method must add the new item to the existing `XmlSchema`. Otherwise, it must create a new `XmlSchema` instance. This is important if arrays of `IXmlSerializable` types are being used. For example, if you have an `IXmlSerializable` type that gets exported as type "A" in namespace "B", it is possible that by the time the schema provider method is called the schema set already contains the schema for "B" to hold the "ArrayOfA" type.  
  
 In addition to adding types to the <xref:System.Xml.Schema.XmlSchemaSet>, the schema provider method for content types must return a non-null value. It can return an <xref:System.Xml.XmlQualifiedName> that specifies the name of the schema type to use for the given `IXmlSerializable` type. This qualified name also serves as the data contract name and namespace for the type. It is permitted to return a type that does not exist in the schema set immediately when the schema provider method returns. However, it is expected that by the time all related types are exported (the <xref:System.Runtime.Serialization.XsdDataContractExporter.Export%2A> method is called for all relevant types on the <xref:System.Runtime.Serialization.XsdDataContractExporter> and the <xref:System.Runtime.Serialization.XsdDataContractExporter.Schemas%2A> property is accessed), the type exists in the schema set. Accessing the `Schemas` property before all relevant `Export` calls have been made can result in an <xref:System.Xml.Schema.XmlSchemaException>. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the export process, see [Exporting Schemas from Classes](../../../../docs/framework/wcf/feature-details/exporting-schemas-from-classes.md).  
  
 The schema provider method can also return the <xref:System.Xml.Schema.XmlSchemaType> to use. The type may or may not be anonymous. If it is anonymous, the schema for the `IXmlSerializable` type is exported as an anonymous type every time the `IXmlSerializable` type is used as a data member. The `IXmlSerializable` type still has a data contract name and namespace. (This is determined as described in [Data Contract Names](../../../../docs/framework/wcf/feature-details/data-contract-names.md) except that the <xref:System.Runtime.Serialization.DataContractAttribute> attribute cannot be used to customize the name.) If it is not anonymous, it must be one of the types in the `XmlSchemaSet`. This case is equivalent to returning the `XmlQualifiedName` of the type.  
  
 Additionally, a global element declaration is exported for the type. If the type does not have the <xref:System.Xml.Serialization.XmlRootAttribute> attribute applied to it, the element has the same name and namespace as the data contract, and its "nillable" property is true. The only exception to this is the schema namespace ("http://www.w3.org/2001/XMLSchema") – if the type’s data contract is in this namespace, the corresponding global element is in the blank namespace because it is forbidden to add new elements to the schema namespace. If the type has the `XmlRootAttribute` attribute applied to it, the global element declaration is exported using the following: <xref:System.Xml.Serialization.XmlRootAttribute.ElementName%2A>, <xref:System.Xml.Serialization.XmlRootAttribute.Namespace%2A> and <xref:System.Xml.Serialization.XmlRootAttribute.IsNullable%2A> properties. The defaults with `XmlRootAttribute` applied are the data contract name, a blank namespace and "nillable" being true.  
  
 The same global element declaration rules apply to legacy dataset types. Note that the `XmlRootAttribute` cannot override global element declarations added through custom code, either added to the `XmlSchemaSet` using the schema provider method or through `GetSchema` for legacy dataset types.  
  
### IXmlSerializable Element Types  
 `IXmlSerializable` element types have either the `IsAny` property set to `true` or have their schema provider method return `null`.  
  
 Serializing and deserializing an element type is very similar to serializing and deserializing a content type. However, there are some important differences:  
  
-   The `WriteXml` implementation is expected to write exactly one element (which could of course contain multiple child elements). It should not be writing attributes outside of this single element, multiple sibling elements or mixed content. The element may be empty.  
  
-   The `ReadXml` implementation should not read the wrapper element. It is expected to read the one element that `WriteXml` produces.  
  
-   When serializing an element type regularly (for example, as a data member in a data contract), the serializer outputs a wrapper element before calling `WriteXml`, as with content types. However, when serializing an element type at the top level, the serializer does not normally output a wrapper element at all around the element that `WriteXml` writes, unless a root name and namespace were explicitly specified when constructing the serializer in the `DataContractSerializer` or `NetDataContractSerializer` constructors. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Serialization and Deserialization](../../../../docs/framework/wcf/feature-details/serialization-and-deserialization.md).  
  
-   When serializing an element type at the top level without specifying the root name and namespace at construction time, <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteStartObject%2A> and <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteEndObject%2A> essentially does nothing and <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteObjectContent%2A> calls `WriteXml`. In this mode, the object being serialized cannot be null and cannot be polymorphically assigned. Also, object graph preservation cannot enabled and the `NetDataContractSerializer` cannot be used.  
  
-   When deserializing an element type at the top level without specifying the root name and namespace at construction time, <xref:System.Runtime.Serialization.XmlObjectSerializer.IsStartObject%2A> returns `true` if it can find the start of any element. <xref:System.Runtime.Serialization.XmlObjectSerializer.ReadObject%2A> with the `verifyObjectName` parameter set to `true` behaves in the same way as `IsStartObject` before actually reading the object. `ReadObject` then passes control to `ReadXml` method.  
  
 The schema exported for element types is the same as for the `XmlElement` type as described in an earlier section, except that the schema provider method can add any additional schema to the <xref:System.Xml.Schema.XmlSchemaSet> as with content types. Using the `XmlRootAttribute` attribute with element types is not allowed, and global element declarations are never emitted for these types.  
  
### Differences from the XmlSerializer  
 The `IXmlSerializable` interface and the `XmlSchemaProviderAttribute` and `XmlRootAttribute` attributes are also understood by the <xref:System.Xml.Serialization.XmlSerializer> . However, there are some differences in how these are treated in the data contract model. The important differences are summarized in the following:  
  
-   The schema provider method must be public to be usable in the `XmlSerializer`, but does not have to be public to be usable in the data contract model.  
  
-   The schema provider method is called when `IsAny` is true in the data contract model but not with the `XmlSerializer`.  
  
-   When the `XmlRootAttribute` attribute is not present for content or legacy dataset types, the `XmlSerializer` exports a global element declaration in the blank namespace. In the data contract model, the namespace used is normally the data contract namespace as described earlier.  
  
 Be aware of these differences when creating types that are used with both serialization technologies.  
  
### Importing IXmlSerializable Schema  
 When importing a schema generated from `IXmlSerializable` types, there are a few possibilities:  
  
-   The generated schema may be a valid data contract schema as described in [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md). In this case, schema can be imported as usual and regular data contract types are generated.  
  
-   The generated schema may not be a valid data contract schema. For example, your schema provider method may generate schema that involves XML attributes which are not supported in the data contract model. In this case, you can import the schema as `IXmlSerializable` types. This import mode is not on by default but can easily be enabled – for example, with the `/importXmlTypes` command-line switch to the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../../../docs/framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md). This is described in detail in the [Importing Schema to Generate Classes](../../../../docs/framework/wcf/feature-details/importing-schema-to-generate-classes.md). Note that you must work directly with the XML for your type instances. You may also consider using a different serialization technology that supports a wider range of schema – see the topic on using the `XmlSerializer`.  
  
-   You may want to reuse your existing `IXmlSerializable` types in the proxy instead of generating new ones. In this case, the referenced types feature described in the Importing Schema to Generate Types topic can be used to indicate the type to reuse. This corresponds to using the `/reference` switch on svcutil.exe, which specifies the assembly that contains the types to reuse.  
  
## Representing Arbitrary XML in Data Contracts  
 The `XmlElement`, Array of `XmlNode` and `IXmlSerializable` types allow you to inject arbitrary XML into the data contract model. The `DataContractSerializer` and `NetDataContractSerializer` pass this XML content on to the XML writer in use, without interfering in the process. However, the XML writers may enforce certain restrictions on the XML that they write. Specifically, here are some important examples:  
  
-   The XML writers do not typically allow an XML document declaration (for example, \<?xml version=’1.0’ ?>) in the middle of writing another document. You cannot take a full XML document and serialize it as an `Array` of `XmlNode` data member. To do this, you have to either strip out the document declaration or use your own encoding scheme to represent it.  
  
-   All of the XML writers supplied with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] reject XML processing instructions (\<? … ?>) and document type definitions (\<! … >), because they are not allowed in SOAP messages. Again, you can use your own encoding mechanism to get around this restriction. If you must include these in your resultant XML, you can write a custom encoder that uses XML writers that support them.  
  
-   When implementing `WriteXml`, avoid calling <xref:System.Xml.XmlWriter.WriteRaw%2A> method on the XML writer. [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] uses a variety of XML encodings (including binary), it is very difficult or impossible to use `WriteRaw` such that the result is usable in any encoding.  
  
-   When implementing `WriteXml`, avoid using the <xref:System.Xml.XmlWriter.WriteEntityRef%2A> and <xref:System.Xml.XmlWriter.WriteNmToken%2A> methods that are unsupported on the XML writers supplied with [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## Using DataSet, Typed DataSet and DataTable  
 Using these types is fully supported in the data contract model. When using these types, consider the following points:  
  
-   The schema for these types (especially <xref:System.Data.DataSet> and its typed derived classes) may not be interoperable with some non-[!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] platforms, or may result in poor usability when used with these platforms. Additionally, using the `DataSet` type may have performance implications. Finally, it may make it more difficult for you to version your application in the future. Consider using explicitly defined data contract types instead of `DataSet` types in your contracts.  
  
-   When importing `DataSet` or `DataTable` schema, it is important to reference these types. With the Svcutil.exe command-line tool, this can be accomplished by passing the System.Data.dll assembly name to the `/reference` switch. If importing typed dataset schema, you must reference the typed dataset’s type. With Svcutil.exe, pass the location of the typed dataset’s assembly to the `/reference` switch. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] referencing types, see the [Importing Schema to Generate Classes](../../../../docs/framework/wcf/feature-details/importing-schema-to-generate-classes.md).  
  
 Support for typed DataSets in the data contract model is limited. Typed DataSets can be serialized and deserialized and can export their schema. However, the Data Contract schema import is unable to generate new typed DataSet types from the schema, as it can only reuse existing ones. You can point to an existing typed DataSet by using the `/r` switch on Svcutil.exe. If you attempt to use a Svcutil.exe without the `/r` switch on a service that uses a typed dataset, an alternative serializer (XmlSerializer) is automatically selected. If you must use the DataContractSerializer and must generate DataSets from schema, you can use the following procedure: generate the typed DataSet types (by using the Xsd.exe tool with the `/d` switch on the service), compile the types, and then point to them using the `/r` switch on Svcutil.exe.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Xml.Serialization.IXmlSerializable>  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
 [Types Supported by the Data Contract Serializer](../../../../docs/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md)
