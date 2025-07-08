---
title: System.Runtime.Serialization.DataContractSerializer class
description: Learn about the System.Runtime.Serialization.DataContractSerializer class.
ms.date: 12/31/2023
---
# System.Runtime.Serialization.DataContractSerializer class

[!INCLUDE [context](includes/context.md)]

Use the <xref:System.Runtime.Serialization.DataContractSerializer> class to serialize and deserialize instances of a type into an XML stream or document. For example, you can create a type named `Person` with properties that contain essential data, such as a name and address. You can then create and manipulate an instance of the `Person` class and write all of its property values in an XML document for later retrieval, or in an XML stream for immediate transport. Most important, the <xref:System.Runtime.Serialization.DataContractSerializer> is used to serialize and deserialize data sent in Windows Communication Foundation (WCF) messages. Apply the <xref:System.Runtime.Serialization.DataContractAttribute> attribute to classes, and the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute to class members to specify properties and fields that are serialized.

For a list of types that can be serialized, see [Types Supported by the Data Contract Serializer](../../framework/wcf/feature-details/types-supported-by-the-data-contract-serializer.md).

To use the <xref:System.Runtime.Serialization.DataContractSerializer>, first create an instance of a class and an object appropriate to writing or reading the format; for example, an instance of the <xref:System.Xml.XmlDictionaryWriter>. Then call the <xref:System.Runtime.Serialization.XmlObjectSerializer.WriteObject%2A> method to persist the data. To retrieve data, create an object appropriate to reading the data format (such as an <xref:System.Xml.XmlDictionaryReader> for an XML document) and call the <xref:System.Runtime.Serialization.DataContractSerializer.ReadObject%2A> method.

For more information about using the <xref:System.Runtime.Serialization.DataContractSerializer>, see [Serialization and Deserialization](../../framework/wcf/feature-details/serialization-and-deserialization.md).

You can set the type of a data contract serializer using the [&lt;dataContractSerializer&gt;](../../framework/configure-apps/file-schema/wcf/datacontractserializer-element.md) element in a client application configuration file.

## Prepare classes for serialization or deserialization

The <xref:System.Runtime.Serialization.DataContractSerializer> is used in combination with the <xref:System.Runtime.Serialization.DataContractAttribute> and <xref:System.Runtime.Serialization.DataMemberAttribute> classes. To prepare a class for serialization, apply the <xref:System.Runtime.Serialization.DataContractAttribute> to the class. For each member of the class that returns data that you want to serialize, apply the <xref:System.Runtime.Serialization.DataMemberAttribute>. You can serialize fields and properties, regardless of accessibility: private, protected, internal, protected internal, or public.

For example, your schema specifies a `Customer` with an `ID` property, but you already have an existing application that uses a type named `Person` with a `Name` property. To create a type that conforms to the contract, first apply the <xref:System.Runtime.Serialization.DataContractAttribute> to the class. Then apply the <xref:System.Runtime.Serialization.DataMemberAttribute> to every field or property that you want to serialize.

> [!NOTE]
> You can apply the <xref:System.Runtime.Serialization.DataMemberAttribute> to both private and public members.

The final format of the XML need not be text. Instead, the <xref:System.Runtime.Serialization.DataContractSerializer> writes the data as an XML infoset, which allows you to write the data to any format recognized by the <xref:System.Xml.XmlReader> and <xref:System.Xml.XmlWriter>. It is recommended that you use the <xref:System.Xml.XmlDictionaryReader> and <xref:System.Xml.XmlDictionaryWriter> classes to read and write, because both are optimized to work with the <xref:System.Runtime.Serialization.DataContractSerializer>.

If you are creating a class that has fields or properties that must be populated before the serialization or deserialization occurs, use callback attributes, as described in [Version-Tolerant Serialization Callbacks](../../framework/wcf/feature-details/version-tolerant-serialization-callbacks.md).

## Add to the collection of known types

When serializing or deserializing an object, it is required that the type is "known" to the <xref:System.Runtime.Serialization.DataContractSerializer>. Begin by creating an instance of a class that implements <xref:System.Collections.Generic.IEnumerable%601> (such as <xref:System.Collections.Generic.List%601>) and adding the known types to the collection. Then create an instance of the <xref:System.Runtime.Serialization.DataContractSerializer> using one of the overloads that takes the <xref:System.Collections.Generic.IEnumerable%601> (for example, <xref:System.Runtime.Serialization.DataContractSerializer.%23ctor%28System.Type%2CSystem.Collections.Generic.IEnumerable%7BSystem.Type%7D%29>).

> [!NOTE]
> Unlike other primitive types, the <xref:System.DateTimeOffset> structure is not a known type by default, so it must be manually added to the list of known types (see [Data Contract Known Types](../../framework/wcf/feature-details/data-contract-known-types.md)).

## Forward compatibility

The <xref:System.Runtime.Serialization.DataContractSerializer> understands data contracts that have been designed to be compatible with future versions of the contract. Such types implement the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface. The interface features the <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData> property that returns an <xref:System.Runtime.Serialization.ExtensionDataObject> object. For more information, see [Forward-Compatible Data Contracts](../../framework/wcf/feature-details/forward-compatible-data-contracts.md).

## Run under partial trust

When instantiating the target object during deserialization, the <xref:System.Runtime.Serialization.DataContractSerializer> does not call the constructor of the target object. If you author a *[DataContract]* type that is accessible from partial trust (that is, it is public and in an assembly that has the `AllowPartiallyTrustedCallers` attribute applied) and that performs some security-related actions, you must be aware that the constructor is not called. In particular, the following techniques do not work:

- If you try to restrict partial trust access by making the constructor internal or private, or by adding a `LinkDemand` to the constructor -- neither of these have any effect during deserialization under partial trust.
- If you code the class that assumes the constructor has run, the class may get into an invalid internal state that is exploitable.
