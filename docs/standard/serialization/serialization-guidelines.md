---
title: "Serialization guidelines"
ms.date: "03/30/2017"
ms.prod: ".net"
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "serialization, guidelines"
  - "binary serialization, guidelines"
ms.assetid: ebbeddff-179d-443f-bf08-9c373199a73a
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Serialization guidelines
This document lists the guidelines to consider when designing an API to be serialized.  

[!INCLUDE [binary-serialization-warning](../../../includes/binary-serialization-warning.md)]
  
 .NET offers three main serialization technologies that are optimized for various serialization scenarios. The following table lists these technologies and the main .NET types related to these technologies.  
  
|Technology|Relevant Classes|Notes|  
|----------------|----------------------|-----------|  
|Data Contract Serialization|<xref:System.Runtime.Serialization.DataContractAttribute><br /><br /> <xref:System.Runtime.Serialization.DataMemberAttribute><br /><br /> <xref:System.Runtime.Serialization.DataContractSerializer><br /><br /> <xref:System.Runtime.Serialization.NetDataContractSerializer><br /><br /> <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer><br /><br /> <xref:System.Runtime.Serialization.ISerializable>|General persistence<br /><br /> Web Services<br /><br /> JSON|  
|XML Serialization|<xref:System.Xml.Serialization.XmlSerializer>|XML format <br />with full control|  
|Runtime -Serialization (Binary and SOAP)|<xref:System.SerializableAttribute><br /><br /> <xref:System.Runtime.Serialization.ISerializable><br /><br /> <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter><br /><br /> <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>|.NET Remoting|  
  
 When you design new types, you should decide which, if any, of these technologies those types need to support. The following guidelines describe how to make that choice and how to provide such support. These guidelines are not meant to help you choose which serialization technology you should use in the implementation of your application or library. Such guidelines are not directly related to API design and thus are not within the scope of this topic.  
  
## Guidelines  
  
-   DO think about serialization when you design new types.  
  
     Serialization is an important design consideration for any type, because programs might need to persist or transmit instances of the type.  
  
### Choosing the right serialization technology to support  
 Any given type can support none, one, or more of the serialization technologies.  
  
-   CONSIDER supporting *data contract serialization* if instances of your type might need to be persisted or used in Web Services.  
  
-   CONSIDER supporting the *XML serialization* instead of or in addition to data contract serialization if you need more control over the XML format that is produced when the type is serialized.  
  
     This may be necessary in some interoperability scenarios where you need to use an XML construct that is not supported by data contract serialization, for example, to produce XML attributes.  
  
-   CONSIDER supporting *runtime serialization* if instances of your type need to travel across .NET Remoting boundaries.  
  
-   AVOID supporting runtime serialization or XML serialization just for general persistence reasons. Prefer data contract serialization instead  
  
#### Supporting data contract serialization  
 Types can support data contract serialization by applying the <xref:System.Runtime.Serialization.DataContractAttribute> to the type and the <xref:System.Runtime.Serialization.DataMemberAttribute> to the members (fields and properties) of the type.  
  
 [!code-csharp[SerializationGuidelines#1](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#1)]
 [!code-vb[SerializationGuidelines#1](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#1)]  
  
1.  CONSIDER marking data members of your type public if the type can be used in partial trust. In full trust, data contract serializers can serialize and deserialize nonpublic types and members, but only public members can be serialized and deserialized in partial trust.  
  
2.  DO implement a getter and setter on all properties that have Data-MemberAttribute. Data contract serializers require both the getter and the setter for the type to be considered serializable. If the type won’t be used in partial trust, one or both of the property accessors can be nonpublic.  
  
     [!code-csharp[SerializationGuidelines#2](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#2)]
     [!code-vb[SerializationGuidelines#2](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#2)]  
  
3.  CONSIDER using the serialization callbacks for initialization of deserialized instances.  
  
     Constructors are not called when objects are deserialized. Therefore, any logic that executes during normal construction needs to be implemented as one of the *serialization callbacks*.  
  
     [!code-csharp[SerializationGuidelines#3](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#3)]
     [!code-vb[SerializationGuidelines#3](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#3)]  
  
     The <xref:System.Runtime.Serialization.OnDeserializedAttribute> attribute is the most commonly used callback attribute. The other attributes in the family are <xref:System.Runtime.Serialization.OnDeserializingAttribute>,    
    <xref:System.Runtime.Serialization.OnSerializingAttribute>, and <xref:System.Runtime.Serialization.OnSerializedAttribute>. They can be used to mark callbacks that get executed before deserialization, before serialization, and finally, after serialization, respectively.  
  
4.  CONSIDER using the <xref:System.Runtime.Serialization.KnownTypeAttribute> to indicate concrete types that should be used when deserializing a complex object graph.  
  
     For example, if a type of a deserialized data member is represented by an abstract class, the serializer will need the *known type* information to decide what concrete type to instantiate and assign to the member. If the known type is not specified using the attribute, it will need to be passed to the serializer explicitly (you can do it by passing known types to the serializer constructor) or it will need to be specified in the configuration file.  
  
     [!code-csharp[SerializationGuidelines#4](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#4)]
     [!code-vb[SerializationGuidelines#4](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#4)]  
  
     In cases where the list of known types is not known statically (when the **Person** class is compiled), the **KnownTypeAttribute** can also point to a method that returns a list of known types at runtime.  
  
5.  DO consider backward and forward compatibility when creating or changing serializable types.  
  
     Keep in mind that serialized streams of future versions of your type can be deserialized into the current version of the type, and vice versa. Make sure you understand that data members, even private and internal, cannot change their names, types, or even their order in future versions of the type unless special care is taken to preserve the contract using explicit parameters to the data contract attributes.Test compatibility of serialization when making changes to serializable types. Try deserializing the new version into an old version, and vice versa.  
  
6.  CONSIDER implementing <xref:System.Runtime.Serialization.IExtensibleDataObject> interface to allow round-tripping between different versions of the type.  
  
     The interface allows the serializer to ensure that no data is lost during round-tripping. The <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData%2A> property stores any data from the future version of the type that is unknown to the current version. When the current version is subsequently serialized and deserialized into a future version, the additional data will be available in the serialized stream through the **ExtensionData** property value.  
  
     [!code-csharp[SerializationGuidelines#5](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#5)]
     [!code-vb[SerializationGuidelines#5](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#5)]  
  
     For more information, see [Forward-Compatible Data Contracts](../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md).  
  
#### Supporting XML serialization  
 Data contract serialization is the main (default) serialization technology in the .NET Framework, but there are serialization scenarios that data contract serialization does not support. For example, it does not give you full control over the shape of XML produced or consumed by the serializer. If such fine control is required, *XML serialization* has to be used, and you need to design your types to support this serialization technology.  
  
1.  AVOID designing your types specifically for XML Serialization, unless you have a very strong reason to control the shape of the XML produced. This serialization technology has been superseded by the Data Contract Serialization discussed in the previous section.  
  
     In other words, don’t apply attributes from the <xref:System.Runtime.Serialization> namespace to new types, unless you know that the type will be used with XML Serialization. The following example shows how **System.Xml.Serialization** can be used to control the shape of the XML -produced.  
  
     [!code-csharp[SerializationGuidelines#6](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#6)]
     [!code-vb[SerializationGuidelines#6](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#6)]  
  
2.  CONSIDER implementing the <xref:System.Xml.Serialization.IXmlSerializable> interface if you want even more control over the shape of the serialized XML than what’s offered by applying the XML Serialization attributes. Two methods of the interface, <xref:System.Xml.Serialization.IXmlSerializable.ReadXml%2A> and <xref:System.Xml.Serialization.IXmlSerializable.WriteXml%2A>, allow you to fully control the serialized XML stream. You can also control the XML schema that gets generated for the type by applying the <xref:System.Xml.Serialization.XmlSchemaProviderAttribute> attribute.  
  
#### Supporting runtime serialization  
 *Runtime serialization* is a technology used by .NET Remoting. If you think your types will be transported using .NET Remoting, you need to make sure they support runtime serialization.  
  
 The basic support for *runtime serialization* can be provided by applying the <xref:System.SerializableAttribute> attribute, and more advanced scenarios involve implementing a simple *runtime serializable pattern* (implement -<xref:System.Runtime.Serialization.ISerializable> and provide a serialization constructor).  
  
1.  CONSIDER supporting runtime serialization if your types will be used with .NET Remoting. For example, the <xref:System.AddIn> namespace uses .NET Remoting, and so all types exchanged between **System.AddIn** add-ins need to support runtime serialization.  
  
     [!code-csharp[SerializationGuidelines#7](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#7)]
     [!code-vb[SerializationGuidelines#7](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#7)]  
  
2.  CONSIDER implementing the *runtime serializable pattern* if you want complete control over the serialization process. For example, if you want to transform data as it gets serialized or deserialized.  
  
     The pattern is very simple. All you need to do is implement the <xref:System.Runtime.Serialization.ISerializable> interface and provide a special constructor that is used when the object is deserialized.  
  
     [!code-csharp[SerializationGuidelines#8](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#8)]
     [!code-vb[SerializationGuidelines#8](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#8)]  
  
3.  DO make the serialization constructor protected and provide two parameters typed and named exactly as shown in the sample here.  
  
     [!code-csharp[SerializationGuidelines#9](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#9)]
     [!code-vb[SerializationGuidelines#9](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#9)]  
  
4.  DO implement the ISerializable members explicitly.  
  
     [!code-csharp[SerializationGuidelines#10](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#10)]
     [!code-vb[SerializationGuidelines#10](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#10)]  
  
5.  DO apply a link demand to **ISerializable.GetObjectData** implementation. This ensures that only fully trusted core and the runtime serializer have access to the member.  
  
     [!code-csharp[SerializationGuidelines#11](../../../samples/snippets/csharp/VS_Snippets_CFX/serializationguidelines/cs/source.cs#11)]
     [!code-vb[SerializationGuidelines#11](../../../samples/snippets/visualbasic/VS_Snippets_CFX/serializationguidelines/vb/source.vb#11)]  
  
## See also  
 [Using Data Contracts](../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
 [Data Contract Serializer](../../../docs/framework/wcf/feature-details/data-contract-serializer.md)  
 [Types Supported by the Data Contract Serializer](../../../docs/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md)  
 [Binary Serialization](binary-serialization.md)  
 [Remote Objects](https://msdn.microsoft.com/library/515686e6-0a8d-42f7-8188-73abede57c58)  
 [XML and SOAP Serialization](xml-and-soap-serialization.md)  
 [Security and Serialization](../../../docs/framework/misc/security-and-serialization.md)
