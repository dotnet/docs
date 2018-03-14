---
title: "Data Contract Versioning"
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
  - "versioning [WCF], data contracts"
  - "versioning [WCF]"
  - "data contracts [WCF], versioning"
ms.assetid: 4a0700cb-5f5f-4137-8705-3a3ecf06461f
caps.latest.revision: 35
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Contract Versioning
As applications evolve, you may also have to change the data contracts the services use. This topic explains how to version data contracts. This topic describes the data contract versioning mechanisms. For a complete overview and prescriptive versioning guidance, see [Best Practices: Data Contract Versioning](../../../../docs/framework/wcf/best-practices-data-contract-versioning.md).  
  
## Breaking vs. Nonbreaking Changes  
 Changes to a data contract can be breaking or nonbreaking. When a data contract is changed in a nonbreaking way, an application using the older version of the contract can communicate with an application using the newer version, and an application using the newer version of the contract can communicate with an application using the older version. On the other hand, a breaking change prevents communication in one or both directions.  
  
 Any changes to a type that do not affect how it is transmitted and received are nonbreaking. Such changes do not change the data contract, only the underlying type. For example, you can change the name of a field in a nonbreaking way if you then set the <xref:System.Runtime.Serialization.DataMemberAttribute.Name%2A> property of the <xref:System.Runtime.Serialization.DataMemberAttribute> to the older version name. The following code shows version 1 of a data contract.  
  
 [!code-csharp[C_DataContractVersioning#1](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractversioning/cs/source.cs#1)]
 [!code-vb[C_DataContractVersioning#1](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractversioning/vb/source.vb#1)]  
  
 The following code shows a nonbreaking change.  
  
 [!code-csharp[C_DataContractVersioning#2](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractversioning/cs/source.cs#2)]
 [!code-vb[C_DataContractVersioning#2](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractversioning/vb/source.vb#2)]  
  
 Some changes do modify the transmitted data, but may or may not be breaking. The following changes are always breaking:  
  
-   Changing the <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A> or <xref:System.Runtime.Serialization.DataContractAttribute.Namespace%2A> value of a data contract.  
  
-   Changing the order of data members by using the <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A> property of the <xref:System.Runtime.Serialization.DataMemberAttribute>.  
  
-   Renaming a data member.  
  
-   Changing the data contract of a data member. For example, changing the type of data member from an integer to a string, or from a type with a data contract named "Customer" to a type with a data contract named "Person".  
  
 The following changes are also possible.  
  
## Adding and Removing Data Members  
 In most cases, adding or removing a data member is not a breaking change, unless you require strict schema validity (new instances validating against the old schema).  
  
 When a type with an extra field is deserialized into a type with a missing field, the extra information is ignored. (It may also be stored for round-tripping purposes; for more information, see [Forward-Compatible Data Contracts](../../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md)).  
  
 When a type with a missing field is deserialized into a type with an extra field, the extra field is left at its default value, usually zero or `null`. (The default value may be changed; for more information, see [Version-Tolerant Serialization Callbacks](../../../../docs/framework/wcf/feature-details/version-tolerant-serialization-callbacks.md).)  
  
 For example, you can use the `CarV1` class on a client and the `CarV2` class on a service, or you can use the `CarV1` class on a service and the `CarV2` class on a client.  
  
 [!code-csharp[C_DataContractVersioning#3](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontractversioning/cs/source.cs#3)]
 [!code-vb[C_DataContractVersioning#3](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontractversioning/vb/source.vb#3)]  
  
 The version 2 endpoint can successfully send data to the version 1 endpoint. Serializing version 2 of the `Car` data contract yields XML similar to the following.  
  
```xml  
<Car>  
    <Model>Porsche</Model>  
    <HorsePower>300</HorsePower>  
</Car>  
```  
  
 The deserialization engine on V1 does not find a matching data member for the `HorsePower` field, and discards that data.  
  
 Also, the version 1 endpoint can send data to the version 2 endpoint. Serializing version 1 of the `Car` data contract yields XML similar to the following.  
  
```xml  
<Car>  
    <Model>Porsche</Model>  
</Car>  
```  
  
 The version 2 deserializer does not know what to set the `HorsePower` field to, because there is no matching data in the incoming XML. Instead, the field is set to the default value of 0.  
  
## Required Data Members  
 A data member may be marked as being required by setting the <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> property of the <xref:System.Runtime.Serialization.DataMemberAttribute> to `true`. If required data is missing while deserializing, an exception is thrown instead of setting the data member to its default value.  
  
 Adding a required data member is a breaking change. That is, the newer type can still be sent to endpoints with the older type, but not the other way around. Removing a data member that was marked as required in any prior version is also a breaking change.  
  
 Changing the <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> property value from `true` to `false` is not breaking, but changing it from `false` to `true` may be breaking if any prior versions of the type do not have the data member in question.  
  
> [!NOTE]
>  Although the <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> property is set to `true`, the incoming data may be null or zero, and a type must be prepared to handle this possibility. Do not use <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> as a security mechanism to protect against bad incoming data.  
  
## Omitted Default Values  
 It is possible (although not recommended) to set the `EmitDefaultValue` property on the DataMemberAttribute attribute to `false`, as described in [Data Member Default Values](../../../../docs/framework/wcf/feature-details/data-member-default-values.md). If this setting is `false`, the data member will not be emitted if it is set to its default value (usually null or zero). This is not compatible with required data members in different versions in two ways:  
  
-   A data contract with a data member that is required in one version cannot receive default (null or zero) data from a different version in which the data member has `EmitDefaultValue` set to `false`.  
  
-   A required data member that has `EmitDefaultValue` set to `false` cannot be used to serialize its default (null or zero) value, but can receive such a value on deserialization. This creates a round-tripping problem (data can be read in but the same data cannot then be written out). Therefore, if `IsRequired` is `true` and `EmitDefaultValue` is `false` in one version, the same combination should apply to all other versions such that no version of the data contract would be able to produce a value that does not result in a round trip.  
  
## Schema Considerations  
 For an explanation of what schema is produced for data contract types, see [Data Contract Schema Reference](../../../../docs/framework/wcf/feature-details/data-contract-schema-reference.md).  
  
 The schema [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] produces for data contract types makes no provisions for versioning. That is, the schema exported from a certain version of a type contains only those data members present in that version. Implementing the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface does not change the schema for a type.  
  
 Data members are exported to the schema as optional elements by default. That is, the `minOccurs` (XML attribute) value is set to 0. Required data members are exported with `minOccurs` set to 1.  
  
 Many of the changes considered to be nonbreaking are actually breaking if strict adherence to the schema is required. In the preceding example, a `CarV1` instance with just the `Model` element would validate against the `CarV2` schema (which has both `Model` and `Horsepower`, but both are optional). However, the reverse is not true: a `CarV2` instance would fail validation against the `CarV1` schema.  
  
 Round-tripping also entails some additional considerations. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] the "Schema Considerations" section in [Forward-Compatible Data Contracts](../../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md).  
  
### Other Permitted Changes  
 Implementing the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface is a nonbreaking change. However, round-tripping support does not exist for versions of the type prior to the version in which <xref:System.Runtime.Serialization.IExtensibleDataObject> was implemented. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Forward-Compatible Data Contracts](../../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md).  
  
## Enumerations  
 Adding or removing an enumeration member is a breaking change. Changing the name of an enumeration member is breaking, unless its contract name is kept the same as in the old version by using the `EnumMemberAtttribute` attribute. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Enumeration Types in Data Contracts](../../../../docs/framework/wcf/feature-details/enumeration-types-in-data-contracts.md).  
  
## Collections  
 Most collection changes are nonbreaking because most collection types are interchangeable with each other in the data contract model. However, making a noncustomized collection customized or vice versa is a breaking change. Also, changing the collection's customization settings is a breaking change; that is, changing its data contract name and namespace, repeating element name, key element name, and value element name. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] collection customization, see [Collection Types in Data Contracts](../../../../docs/framework/wcf/feature-details/collection-types-in-data-contracts.md).  
Naturally, changing the data contract of contents of a collection (for example, changing from a list of integers to a list of strings) is a breaking change.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataMemberAttribute.Name%2A>  
 <xref:System.Runtime.Serialization.DataMemberAttribute>  
 <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A>  
 <xref:System.Runtime.Serialization.DataContractAttribute.Namespace%2A>  
 <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A>  
 <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A>  
 <xref:System.Runtime.Serialization.SerializationException>  
 <xref:System.Runtime.Serialization.IExtensibleDataObject>  
 [Version-Tolerant Serialization Callbacks](../../../../docs/framework/wcf/feature-details/version-tolerant-serialization-callbacks.md)  
 [Best Practices: Data Contract Versioning](../../../../docs/framework/wcf/best-practices-data-contract-versioning.md)  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
 [Data Contract Equivalence](../../../../docs/framework/wcf/feature-details/data-contract-equivalence.md)  
 [Forward-Compatible Data Contracts](../../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md)
