---
title: "Serialization1"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bebb27ac-9712-4196-9931-de19fc04dbac
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Serialization
Serialization is the process of converting an object into a format that can be readily persisted or transported. For example, you can serialize an object, transport it over the Internet using HTTP, and deserialized it at the destination machine.  
  
 The .NET Framework offers three main serialization technologies optimized for various serialization scenarios. The following table lists these technologies and the main Framework types related to these technologies.  
  
|**Technology Name**|**Main Types**|**Scenarios**|  
|-------------------------|--------------------|-------------------|  
|**Data Contract Serialization**|<xref:System.Runtime.Serialization.DataContractAttribute> <br /> <xref:System.Runtime.Serialization.DataMemberAttribute> <br /> <xref:System.Runtime.Serialization.DataContractSerializer> <br /> <xref:System.Runtime.Serialization.NetDataContractSerializer> <br /> <xref:System.Runtime.Serialization.Json.DataContractJsonSerializer> <br /> <xref:System.Runtime.Serialization.ISerializable>|General persistence<br />Web Services<br />JSON|  
|**XML Serialization**|<xref:System.Xml.Serialization.XmlSerializer>|XML format with full control over the shape of the XML|  
|**Runtime Serialization (Binary and SOAP)**|<xref:System.SerializableAttribute> <br /> <xref:System.Runtime.Serialization.ISerializable> <br /> <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> <br /> <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>|.NET Remoting|  
  
 **✓ DO** think about serialization when you design new types.  
  
## Choosing the Right Serialization Technology to Support  
 **✓ CONSIDER** supporting Data Contract Serialization if instances of your type might need to be persisted or used in Web Services.  
  
 **✓ CONSIDER** supporting the XML Serialization instead of or in addition to Data Contract Serialization if you need more control over the XML format that is produced when the type is serialized.  
  
 This may be necessary in some interoperability scenarios where you need to use an XML construct that is not supported by Data Contract Serialization, for example, to produce XML attributes.  
  
 **✓ CONSIDER** supporting the Runtime Serialization if instances of your type need to travel across .NET Remoting boundaries.  
  
 **X AVOID** supporting Runtime Serialization or XML Serialization just for general persistence reasons. Prefer Data Contract Serialization instead.  
  
## Supporting Data Contract Serialization  
 Types can support Data Contract Serialization by applying the <xref:System.Runtime.Serialization.DataContractAttribute> to the type and the <xref:System.Runtime.Serialization.DataMemberAttribute> to the members (fields and properties) of the type.  
  
 **✓ CONSIDER** marking data members of your type public if the type can be used in partial trust.  
  
 In full trust, Data Contract serializers can serialize and deserialize nonpublic types and members, but only public members can be serialized and deserialized in partial trust.  
  
 **✓ DO** implement a getter and setter on all properties that have <xref:System.Runtime.Serialization.DataMemberAttribute>. Data Contract serializers require both the getter and the setter for the type to be considered serializable. (In .NET Framework 3.5 SP1, some collection properties can be get-only.) If the type won’t be used in partial trust, one or both of the property accessors can be nonpublic.  
  
 **✓ CONSIDER** using the serialization callbacks for initialization of deserialized instances.  
  
 Constructors are not called when objects are deserialized. (There are exceptions to the rule. Constructors of collections marked with <xref:System.Runtime.Serialization.CollectionDataContractAttribute> are called during deserialization.) Therefore, any logic that executes during normal construction needs to be implemented as one of the serialization callbacks.  
  
 `OnDeserializedAttribute` is the most commonly used callback attribute. The other attributes in the family are <xref:System.Runtime.Serialization.OnDeserializingAttribute>,  <xref:System.Runtime.Serialization.OnSerializingAttribute>, and <xref:System.Runtime.Serialization.OnSerializedAttribute>. They can be used to mark callbacks that get executed before deserialization, before serialization, and finally, after serialization, respectively.  
  
 **✓ CONSIDER** using the <xref:System.Runtime.Serialization.KnownTypeAttribute> to indicate concrete types that should be used when deserializing a complex object graph.  
  
 **✓ DO** consider backward and forward compatibility when creating or changing serializable types.  
  
 Keep in mind that serialized streams of future versions of your type can be deserialized into the current version of the type, and vice versa.  
  
 Make sure you understand that data members, even private and internal, cannot change their names, types, or even their order in future versions of the type unless special care is taken to preserve the contract using explicit parameters to the data contract attributes.  
  
 Test compatibility of serialization when making changes to serializable types. Try deserializing the new version into an old version, and vice versa.  
  
 **✓ CONSIDER** implementing <xref:System.Runtime.Serialization.IExtensibleDataObject> to allow round-tripping between different versions of the type.  
  
 The interface allows the serializer to ensure that no data is lost during round-tripping. The <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData%2A?displayProperty=nameWithType> property is used to store any data from the future version of the type that is unknown to the current version, and so it cannot store it in its data members. When the current version is subsequently serialized and deserialized into a future version, the additional data will be available in the serialized stream.  
  
## Supporting XML Serialization  
 Data Contract Serialization is the main (default) serialization technology in the .NET Framework, but there are serialization scenarios that Data Contract Serialization does not support. For example, it does not give you full control over the shape of XML produced or consumed by the serializer. If such fine control is required, XML Serialization has to be used, and you need to design your types to support this serialization technology.  
  
 **X AVOID** designing your types specifically for XML Serialization, unless you have a very strong reason to control the shape of the XML produced. This serialization technology has been superseded by the Data Contract Serialization discussed in the previous section.  
  
 **✓ CONSIDER** implementing the <xref:System.Xml.Serialization.IXmlSerializable> interface if you want even more control over the shape of the serialized XML than what’s offered by applying the XML Serialization attributes. Two methods of the interface, <xref:System.Xml.Serialization.IXmlSerializable.ReadXml%2A> and <xref:System.Xml.Serialization.IXmlSerializable.WriteXml%2A>, allow you to fully control the serialized XML stream. You can also control the XML schema that gets generated for the type by applying the `XmlSchemaProviderAttribute`.  
  
## Supporting Runtime Serialization  
 Runtime Serialization is a technology used by .NET Remoting. If you think your types will be transported using .NET Remoting, you need to make sure they support Runtime Serialization.  
  
 The basic support for Runtime Serialization can be provided by applying the <xref:System.SerializableAttribute>, and more advanced scenarios involve implementing a simple Runtime Serializable Pattern (implement <xref:System.Runtime.Serialization.ISerializable> and provide serialization constructor).  
  
 **✓ CONSIDER** supporting Runtime Serialization if your types will be used with .NET Remoting. For example, the <xref:System.AddIn?displayProperty=nameWithType> namespace uses .NET Remoting, and so all types exchanged between `System.AddIn` add-ins need to support Runtime Serialization.  
  
 **✓ CONSIDER** implementing the Runtime Serializable Pattern if you want complete control over the serialization process. For example, if you want to transform data as it gets serialized or deserialized.  
  
 The pattern is very simple. All you need to do is implement the <xref:System.Runtime.Serialization.ISerializable> interface and provide a special constructor that is used when the object is deserialized.  
  
 **✓ DO** make the serialization constructor protected and provide two parameters typed and named exactly as shown in the sample here.  
  
```  
[Serializable]  
public class Person : ISerializable {  
    protected Person(SerializationInfo info, StreamingContext context) {  
        ...  
    }  
}  
```  
  
 **✓ DO** implement the `ISerializable` members explicitly.  
  
 **✓ DO** apply a link demand to <xref:System.Runtime.Serialization.ISerializable.GetObjectData%2A?displayProperty=nameWithType> implementation. This ensures that only fully trusted core and the Runtime Serializer have access to the member.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Usage Guidelines](../../../docs/standard/design-guidelines/usage-guidelines.md)
