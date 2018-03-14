---
title: "Serialization and Deserialization"
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
ms.assetid: 3d71814c-bda7-424b-85b7-15084ff9377a
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Serialization and Deserialization
[!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] includes a new serialization engine, the <xref:System.Runtime.Serialization.DataContractSerializer>. The <xref:System.Runtime.Serialization.DataContractSerializer> translates between [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] objects and XML, in both directions. This topic explains how the serializer works.  
  
 When serializing [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] objects, the serializer understands a variety of serialization programming models, including the new *data contract* model. For a full list of supported types, see [Types Supported by the Data Contract Serializer](../../../../docs/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md). For an introduction to data contracts, see [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md).  
  
 When deserializing XML, the serializer uses the <xref:System.Xml.XmlReader> and <xref:System.Xml.XmlWriter> classes. It also supports the <xref:System.Xml.XmlDictionaryReader> and <xref:System.Xml.XmlDictionaryWriter> classes to enable it to produce optimized XML in some cases, such as when using the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] binary XML format.  
  
 [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] also includes a companion serializer, the <xref:System.Runtime.Serialization.NetDataContractSerializer>. The <xref:System.Runtime.Serialization.NetDataContractSerializer> is similar to the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> and <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter> serializers because it also emits [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type names as part of the serialized data. It is used when the same types are shared on the serializing and the deserializing ends. Both the <xref:System.Runtime.Serialization.DataContractSerializer> and the <xref:System.Runtime.Serialization.NetDataContractSerializer> derive from a common base class, the <xref:System.Runtime.Serialization.XmlObjectSerializer>.  
  
> [!WARNING]
>  The <xref:System.Runtime.Serialization.DataContractSerializer> serializes strings containing control characters with a hexadecimal value below 20 as XML entities. This may cause a problem with a non-WCF client when sending such data to a WCF service.  
  
## Creating a DataContractSerializer Instance  
 Constructing an instance of the <xref:System.Runtime.Serialization.DataContractSerializer> is an important step. After construction, you cannot change any of the settings.  
  
### Specifying the Root Type  
 The *root type* is the type of which instances are serialized or deserialized. The <xref:System.Runtime.Serialization.DataContractSerializer> has many constructor overloads, but, at a minimum, a root type must be supplied using the `type` parameter.  
  
 A serializer created for a certain root type cannot be used to serialize (or deserialize) another type, unless the type is derived from the root type. The following example shows two classes.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#1)]
 [!code-vb[c_StandaloneDataContractSerializer#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#1)]  
  
 This code constructs an instance of the `DataContractSerializer` that can be used only to serialize or deserialize instances of the `Person` class.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#2)]
 [!code-vb[c_StandaloneDataContractSerializer#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#2)]  
  
### Specifying Known Types  
 If polymorphism is involved in the types being serialized that is not already handled using the <xref:System.Runtime.Serialization.KnownTypeAttribute> attribute or some other mechanism, a list of possible known types must be passed to the serializer’s constructor using the `knownTypes` parameter. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] known types, see [Data Contract Known Types](../../../../docs/framework/wcf/feature-details/data-contract-known-types.md).  
  
 The following example shows a class, `LibraryPatron`, that includes a collection of a specific type, the `LibraryItem`. The second class defines the `LibraryItem` type. The third and four classes (`Book` and `Newspaper`) inherit from the `LibraryItem` class.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#3)]  
 [!code-vb[c_StandaloneDataContractSerializer#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#3)]  
  
 The following code constructs an instance of the serializer using the `knownTypes` parameter.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#4](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#4)]
 [!code-vb[c_StandaloneDataContractSerializer#4](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#4)]  
  
### Specifying the Default Root Name and Namespace  
 Normally, when an object is serialized, the default name and namespace of the outermost XML element are determined according to the data contract name and namespace. The names of all inner elements are determined from data member names, and their namespace is the data contract’s namespace. The following example sets `Name` and `Namespace` values in the constructors of the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> classes.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#5](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#5)]
 [!code-vb[c_StandaloneDataContractSerializer#5](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#5)]  
  
 Serializing an instance of the `Person` class produces XML similar to the following.  
  
```xml  
<PersonContract xmlns="http://schemas.contoso.com">  
  <AddressMember>  
    <StreetMember>123 Main Street</StreetMember>  
   </AddressMember>  
</PersonContract>  
```  
  
 However, you can customize the default name and namespace of the root element by passing the values of the `rootName` and `rootNamespace` parameters to the <xref:System.Runtime.Serialization.DataContractSerializer> constructor. Note that the `rootNamespace` does not affect the namespace of the contained elements that correspond to data members. It affects only the namespace of the outermost element.  
  
 These values can be passed as strings or instances of the <xref:System.Xml.XmlDictionaryString> class to allow for their optimization using the binary XML format.  
  
### Setting the Maximum Objects Quota  
 Some `DataContractSerializer` constructor overloads have a `maxItemsInObjectGraph` parameter. This parameter determines the maximum number of objects the serializer serializes or deserializes in a single <xref:System.Runtime.Serialization.XmlObjectSerializer.ReadObject%2A> method call. (The method always reads one root object, but this object may have other objects in its data members. Those objects may have other objects, and so on.) The default is 65536. Note that when serializing or deserializing arrays, every array entry counts as a separate object. Also, note that some objects may have a large memory representation, and so this quota alone may not be sufficient to prevent a denial of service attack. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Security Considerations for Data](../../../../docs/framework/wcf/feature-details/security-considerations-for-data.md). If you need to increase this quota beyond the default value, it is important to do so both on the sending (serializing) and receiving (deserializing) sides because it applies to both when reading and writing data.  
  
### Round Trips  
 A *round trip* occurs when an object is deserialized and re-serialized in one operation. Thus, it goes from XML to an object instance, and back again into an XML stream.  
  
 Some `DataContractSerializer` constructor overloads have an `ignoreExtensionDataObject` parameter, which is set to `false` by default. In this default mode, data can be sent on a round trip from a newer version of a data contract through an older version and back to the newer version without loss, as long as the data contract implements the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface. For example, suppose version 1 of the `Person` data contract contains the `Name` and `PhoneNumber` data members, and version 2 adds a `Nickname` member. If `IExtensibleDataObject` is implemented, when sending information from version 2 to version 1, the `Nickname` data is stored, and then re-emitted when the data is serialized again; therefore, no data is lost in the round trip. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Forward-Compatible Data Contracts](../../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md) and [Data Contract Versioning](../../../../docs/framework/wcf/feature-details/data-contract-versioning.md).  
  
#### Security and Schema Validity Concerns with Round Trips  
 Round trips may have security implications. For example, deserializing and storing large amounts of extraneous data may be a security risk. There may be security concerns about re-emitting this data that there is no way to verify, especially if digital signatures are involved. For example, in the previous scenario, the version 1 endpoint could be signing a `Nickname` value that contains malicious data. Finally, there may be schema validity concerns: an endpoint may want to always emit data that strictly adheres to its stated contract and not any extra values. In the previous example, the version 1 endpoint’s contract says that it emits only `Name` and `PhoneNumber`, and if schema validation is being used, emitting the extra `Nickname` value causes validation to fail.  
  
#### Enabling and Disabling Round Trips  
 To turn off round trips, do not implement the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface. If you have no control over the types, set the `ignoreExtensionDataObject` parameter to `true` to achieve the same effect.  
  
### Object Graph Preservation  
 Normally, the serializer does not care about object identity, as in the following code.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#6](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#6)]
 [!code-vb[c_StandaloneDataContractSerializer#6](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#6)]  
  
 The following code creates a purchase order.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#7)]
 [!code-vb[c_StandaloneDataContractSerializer#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#7)]  
  
 Notice that `billTo` and `shipTo` fields are set to the same object instance. However, the generated XML duplicates the information duplicated, and looks similar to the following XML.  
  
```xml  
<PurchaseOrder>  
  <billTo><street>123 Main St.</street></billTo>  
  <shipTo><street>123 Main St.</street></shipTo>  
</PurchaseOrder>  
```  
  
 However, this approach has the following characteristics, which may be undesirable:  
  
-   Performance. Replicating data is inefficient.  
  
-   Circular references. If objects refer to themselves, even through other objects, serializing by replication results in an infinite loop. (The serializer throws a <xref:System.Runtime.Serialization.SerializationException> if this happens.)  
  
-   Semantics. Sometimes it is important to preserve the fact that two references are to the same object, and not to two identical objects.  
  
 For these reasons, some `DataContractSerializer` constructor overloads have a `preserveObjectReferences` parameter (the default is `false`). When this parameter is set to `true`, a special method of encoding object references, which only [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] understands, is used. When set to `true`, the XML code example now resembles the following.  
  
```xml  
<PurchaseOrder ser:id="1">  
  <billTo ser:id="2"><street ser:id="3">123 Main St.</street></billTo>  
  <shipTo ser:ref="2"/>  
</PurchaseOrder>  
```  
  
 The "ser" namespace refers to the standard serialization namespace, http://schemas.microsoft.com/2003/10/Serialization/. Each piece of data is serialized only once and given an ID number, and subsequent uses result in a reference to the already serialized data.  
  
> [!IMPORTANT]
>  If both "id" and "ref" attributes are present in the data contract `XMLElement`, then the "ref" attribute is honored and the "id" attribute is ignored.  
  
 It is important to understand the limitations of this mode:  
  
-   The XML the `DataContractSerializer` produces with `preserveObjectReferences` set to `true` is not interoperable with any other technologies, and can be accessed only by another `DataContractSerializer` instance, also with `preserveObjectReferences` set to `true`.  
  
-   There is no metadata (schema) support for this feature. The schema that is produced is valid only for the case when `preserveObjectReferences` is set to `false`.  
  
-   This feature may cause the serialization and deserialization process to run slower. Although data does not have to be replicated, extra object comparisons must be performed in this mode.  
  
> [!CAUTION]
>  When the `preserveObjectReferences` mode is enabled, it is especially important to set the `maxItemsInObjectGraph` value to the correct quota. Due to the way arrays are handled in this mode, it is easy for an attacker to construct a small malicious message that results in large memory consumption limited only by the `maxItemsInObjectGraph` quota.  
  
### Specifying a Data Contract Surrogate  
 Some `DataContractSerializer` constructor overloads have a `dataContractSurrogate` parameter, which may be set to `null`. Otherwise, you can use it to specify a *data contract surrogate*, which is a type that implements the <xref:System.Runtime.Serialization.IDataContractSurrogate> interface. You can then use the interface to customize the serialization and deserialization process. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Data Contract Surrogates](../../../../docs/framework/wcf/extending/data-contract-surrogates.md).  
  
## Serialization  
 The following information applies to any class that inherits from the <xref:System.Runtime.Serialization.XmlObjectSerializer>, including the <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.NetDataContractSerializer> classes.  
  
### Simple Serialization  
 The most basic way to serialize an object is to pass it to the <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteObject%2A> method. There are three overloads, one each for writing to a <xref:System.IO.Stream>, an <xref:System.Xml.XmlWriter>, or an <xref:System.Xml.XmlDictionaryWriter>. With the <xref:System.IO.Stream> overload, the output is XML in the UTF-8 encoding. With the <xref:System.Xml.XmlDictionaryWriter> overload, the serializer optimizes its output for binary XML.  
  
 When using the <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteObject%2A> method, the serializer uses the default name and namespace for the wrapper element and writes it out along with the contents (see the previous "Specifying the Default Root Name and Namespace" section).  
  
 The following example demonstrates writing with an <xref:System.Xml.XmlDictionaryWriter>.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#8)]
 [!code-vb[c_StandaloneDataContractSerializer#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#8)]  
  
 This produces XML similar to the following.  
  
```xml  
<Person>  
  <Name>Jay Hamlin</Name>  
  <Address>123 Main St.</Address>  
</Person>  
```  
  
### Step-By-Step Serialization  
 Use the <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteStartObject%2A>, <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteObjectContent%2A>, and <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteEndObject%2A> methods to write the end element, write the object contents, and close the wrapper element, respectively.  
  
> [!NOTE]
>  There are no <xref:System.IO.Stream> overloads of these methods.  
  
 This step-by-step serialization has two common uses. One is to insert contents such as attributes or comments between `WriteStartObject` and `WriteObjectContent`,  as shown in the following example.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#9](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#9)]
 [!code-vb[c_StandaloneDataContractSerializer#9](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#9)]  
  
 This produces XML similar to the following.  
  
```xml  
<Person serializedBy="myCode">  
  <Name>Jay Hamlin</Name>  
  <Address>123 Main St.</Address>  
</Person>  
```  
  
 Another common use is to avoid using <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteStartObject%2A> and <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteEndObject%2A> entirely, and to write your own custom wrapper element (or even skip writing a wrapper altogether), as shown in the following code.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#10](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#10)]
 [!code-vb[c_StandaloneDataContractSerializer#10](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#10)]  
  
 This produces XML similar to the following.  
  
```xml  
<MyCustomWrapper>  
  <Name>Jay Hamlin</Name>  
  <Address>123 Main St.</Address>  
</MyCustomWrapper>  
```  
  
> [!NOTE]
>  Using step-by-step serialization may result in schema-invalid XML.  
  
## Deserialization  
 The following information applies to any class that inherits from the <xref:System.Runtime.Serialization.XmlObjectSerializer>, including the <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.NetDataContractSerializer> classes.  
  
 The most basic way to deserialize an object is to call one of the <xref:System.Runtime.Serialization.XmlObjectSerializer.ReadObject%2A> method overloads. There are three overloads, one each for reading with a <xref:System.Xml.XmlDictionaryReader>, an `XmlReader`, or a `Stream`. Note that the `Stream` overload creates a textual <xref:System.Xml.XmlDictionaryReader> that is not protected by any quotas, and should be used only to read trusted data.  
  
 Also note that the object the `ReadObject` method returns must be cast to the appropriate type.  
  
 The following code constructs an instance of the <xref:System.Runtime.Serialization.DataContractSerializer> and an <xref:System.Xml.XmlDictionaryReader>, then deserializes a `Person` instance.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#11](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#11)]
 [!code-vb[c_StandaloneDataContractSerializer#11](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#11)]  
  
 Before calling the <xref:System.Runtime.Serialization.XmlObjectSerializer.ReadObject%2A> method, position the XML reader on the wrapper element or on a non-content node that precedes the wrapper element. You can do this by calling the <xref:System.Xml.XmlReader.Read%2A> method of the <xref:System.Xml.XmlReader> or its derivation, and testing the <xref:System.Xml.XmlReader.NodeType%2A>, as shown in the following code.  
  
 [!code-csharp[c_StandaloneDataContractSerializer#12](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_standalonedatacontractserializer/cs/source.cs#12)]
 [!code-vb[c_StandaloneDataContractSerializer#12](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_standalonedatacontractserializer/vb/source.vb#12)]  
  
 Note that you can read attributes on this wrapper element before handing the reader to `ReadObject`.  
  
 When using one of the simple `ReadObject` overloads, the deserializer looks for the default name and namespace on the wrapper element (see the preceding section, "Specifying the Default Root Name and Namespace") and throws an exception if it finds an unknown element. In the preceding example, the `<Person>` wrapper element is expected. The <xref:System.Runtime.Serialization.XmlObjectSerializer.IsStartObject%2A> method is called to verify that the reader is positioned on an element that is named as expected.  
  
 There is a way to disable this wrapper element name check; some overloads of the `ReadObject` method take the Boolean parameter `verifyObjectName`, which is set to `true` by default. When set to `false`, the name and namespace of the wrapper element is ignored. This is useful for reading XML that was written using the step-by-step serialization mechanism described previously.  
  
## Using the NetDataContractSerializer  
 The primary difference between the `DataContractSerializer` and the <xref:System.Runtime.Serialization.NetDataContractSerializer> is that the `DataContractSerializer` uses data contract names, whereas the `NetDataContractSerializer` outputs full [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] assembly and type names in the serialized XML. This means that the exact same types must be shared between the serialization and deserialization endpoints. This means that the known types mechanism is not required with the `NetDataContractSerializer` because the exact types to be deserialized are always known.  
  
 However, several problems can occur:  
  
-   Security. Any type found in the XML being deserialized is loaded. This can be exploited to force the loading of malicious types. Using the `NetDataContractSerializer` with untrusted data should be done only if a *Serialization Binder* is used (using the <xref:System.Runtime.Serialization.NetDataContractSerializer.Binder%2A> property or constructor parameter). The binder permits only safe types to be loaded. The Binder mechanism is identical to the one that types in the <xref:System.Runtime.Serialization> namespace use.  
  
-   Versioning. Using full type and assembly names in the XML severely restricts how types can be versioned. The following cannot be changed: type names, namespaces, assembly names, and assembly versions. Setting the <xref:System.Runtime.Serialization.NetDataContractSerializer.AssemblyFormat%2A> property or constructor parameter to <xref:System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple> instead of the default value of <xref:System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Full> allows for assembly version changes, but not for generic parameter types.  
  
-   Interoperability. Because [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type and assembly names are included in the XML, platforms other than the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] cannot access the resulting data.  
  
-   Performance. Writing out the type and assembly names significantly increases the size of the resulting XML.  
  
 This mechanism is similar to binary or SOAP serialization used by [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] remoting (specifically, the <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> and the <xref:System.Runtime.Serialization.Formatters.Soap.SoapFormatter>).  
  
 Using the `NetDataContractSerializer` is similar to using the `DataContractSerializer`, with the following differences:  
  
-   The constructors do not require you to specify a root type. You can serialize any type with the same instance of the `NetDataContractSerializer`.  
  
-   The constructors do not accept a list of known types. The known types mechanism is unnecessary if type names are serialized into the XML.  
  
-   The constructors do not accept a data contract surrogate. Instead, they accept an <xref:System.Runtime.Serialization.ISurrogateSelector> parameter called `surrogateSelector` (which maps to the <xref:System.Runtime.Serialization.NetDataContractSerializer.SurrogateSelector%2A> property). This is a legacy surrogate mechanism.  
  
-   The constructors accept a parameter called `assemblyFormat` of the <xref:System.Runtime.Serialization.Formatters.FormatterAssemblyStyle> that maps to the <xref:System.Runtime.Serialization.NetDataContractSerializer.AssemblyFormat%2A> property. As discussed previously, this can be used to enhance the versioning capabilities of the serializer. This is identical to the <xref:System.Runtime.Serialization.Formatters.FormatterAssemblyStyle> mechanism in binary or SOAP serialization.  
  
-   The constructors accept a <xref:System.Runtime.Serialization.StreamingContext> parameter called `context` that maps to the <xref:System.Runtime.Serialization.NetDataContractSerializer.Context%2A> property. You can use this to pass information into types being serialized. This usage is identical to that of the <xref:System.Runtime.Serialization.StreamingContext> mechanism used in other <xref:System.Runtime.Serialization> classes.  
  
-   The <xref:System.Runtime.Serialization.NetDataContractSerializer.Serialize%2A> and <xref:System.Runtime.Serialization.NetDataContractSerializer.Deserialize%2A> methods are aliases for the <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteObject%2A> and <xref:System.Runtime.Serialization.XmlObjectSerializer.ReadObject%2A> methods. These exist to provide a more consistent programming model with binary or SOAP serialization.  
  
 [!INCLUDE[crabout](../../../../includes/crabout-md.md)] these features, see [Binary Serialization](../../../../docs/standard/serialization/binary-serialization.md).  
  
 The XML formats that the `NetDataContractSerializer` and the `DataContractSerializer` use are normally not compatible. That is, attempting to serialize with one of these serializers and deserialize with the other is not a supported scenario.  
  
 Also, note that the `NetDataContractSerializer` does not output the full [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] type and assembly name for each node in the object graph. It outputs that information only where it is ambiguous. That is, it outputs at the root object level and for any polymorphic cases.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Runtime.Serialization.NetDataContractSerializer>  
 <xref:System.Runtime.Serialization.XmlObjectSerializer>  
 [Binary Serialization](../../../../docs/standard/serialization/binary-serialization.md)  
 [Types Supported by the Data Contract Serializer](../../../../docs/framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md)
