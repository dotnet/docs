---
title: System.Runtime.Serialization.DataContractAttribute class
description: Learn about the System.Runtime.Serialization.DataContractAttribute class.
ms.date: 12/31/2023
ms.topic: article
---
# System.Runtime.Serialization.DataContractAttribute class

[!INCLUDE [context](includes/context.md)]

Apply the <xref:System.Runtime.Serialization.DataContractAttribute> attribute to types (classes, structures, or enumerations) that are used in serialization and deserialization operations by the <xref:System.Runtime.Serialization.DataContractSerializer>. If you send or receive messages by using the Windows Communication Foundation (WCF) infrastructure, you should also apply the <xref:System.Runtime.Serialization.DataContractAttribute> to any classes that hold and manipulate data sent in messages. For more information about data contracts, see [Using Data Contracts](../../framework/wcf/feature-details/using-data-contracts.md).

You must also apply the <xref:System.Runtime.Serialization.DataMemberAttribute> to any field, property, or event that holds values you want to serialize. By applying the <xref:System.Runtime.Serialization.DataContractAttribute>, you explicitly enable the <xref:System.Runtime.Serialization.DataContractSerializer> to serialize and deserialize the data.

> [!CAUTION]
> You can apply the <xref:System.Runtime.Serialization.DataMemberAttribute> to private fields. Be aware that the data returned by the field (even if it is private) is serialized and deserialized, and thus can be viewed or intercepted by a malicious user or process.

For more information about data contracts, see the topics listed in [Using Data Contracts](../../framework/wcf/feature-details/using-data-contracts.md).

## Data contracts

A *data contract* is an abstract description of a set of fields with a name and data type for each field. The data contract exists outside of any single implementation to allow services on different platforms to interoperate. As long as the data passed between the services conforms to the same contract, all the services can process the data. This processing is also known as a *loosely coupled system*. A data contract is also similar to an interface in that the contract specifies how data must be delivered so that it can be processed by an application. For example, the data contract may call for a data type named "Person" that has two text fields, named "FirstName" and "LastName". To create a data contract, apply the <xref:System.Runtime.Serialization.DataContractAttribute> to the class and apply the <xref:System.Runtime.Serialization.DataMemberAttribute> to any fields or properties that must be serialized. When serialized, the data conforms to the data contract that is implicitly built into the type.

> [!NOTE]
> A data contract differs significantly from an actual interface in its inheritance behavior. Interfaces are inherited by any derived types. When you apply the <xref:System.Runtime.Serialization.DataContractAttribute> to a base class, the derived types do not inherit the attribute or the behavior. However, if a derived type has a data contract, the data members of the base class are serialized. However, you must apply the <xref:System.Runtime.Serialization.DataMemberAttribute> to new members in a derived class to make them serializable.

## XML schema documents and the SvcUtil tool

If you are exchanging data with other services, you must describe the data contract. For the current version of the <xref:System.Runtime.Serialization.DataContractSerializer>, an XML schema can be used to define data contracts. (Other forms of metadata/description could be used for the same purpose.) To create an XML schema from your application, use the [ServiceModel Metadata Utility Tool (Svcutil.exe)](../../framework/wcf/servicemodel-metadata-utility-tool-svcutil-exe.md) with the **/dconly** command line option. When the input to the tool is an assembly, by default, the tool generates a set of XML schemas that define all the data contract types found in that assembly. Conversely, you can also use the Svcutil.exe tool to create Visual Basic or C# class definitions that conform to the requirements of XML schemas that use constructs that can be expressed by data contracts. In this case, the **/dconly** command line option is not required.

If the input to the Svcutil.exe tool is an XML schema, by default, the tool creates a set of classes. If you examine those classes, you find that the <xref:System.Runtime.Serialization.DataContractAttribute> has been applied. You can use those classes to create a new application to process data that must be exchanged with other services.

You can also run the tool against an endpoint that returns a Web Services Description Language (WSDL) document to automatically generate the code and configuration to create an Windows Communication Foundation (WCF) client. The generated code includes types that are marked with the <xref:System.Runtime.Serialization.DataContractAttribute>.

## Reuse existing types

A data contract has two basic requirements: a stable name and a list of members. The stable name consists of the namespace uniform resource identifier (URI) and the local name of the contract. By default, when you apply the <xref:System.Runtime.Serialization.DataContractAttribute> to a class, it uses the class name as the local name and the class's namespace (prefixed with `"http://schemas.datacontract.org/2004/07/"`) as the namespace URI. You can override the defaults by setting the <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A> and <xref:System.Runtime.Serialization.DataContractAttribute.Namespace%2A> properties. You can also change the namespace by applying the <xref:System.Runtime.Serialization.ContractNamespaceAttribute> to the namespace. Use this capability when you have an existing type that processes data exactly as you require but has a different namespace and class name from the data contract. By overriding the default values, you can reuse your existing type and have the serialized data conform to the data contract.

> [!NOTE]
> In any code, you can use the word `DataContract` instead of the longer <xref:System.Runtime.Serialization.DataContractAttribute>.

## Versioning

A data contract can also accommodate later versions of itself. That is, when a later version of the contract includes extra data, that data is stored and returned to a sender untouched. To do this, implement the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface.

For more information about versioning, see [Data Contract Versioning](../../framework/wcf/feature-details/data-contract-versioning.md).
