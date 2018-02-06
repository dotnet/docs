---
title: "Best Practices: Data Contract Versioning"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "data contracts"
  - "service contracts"
  - "best practices [WCF], data contract versioning"
  - "Windows Communication Foundation, data contracts"
ms.assetid: bf0ab338-4d36-4e12-8002-8ebfdeb346cb
caps.latest.revision: 24
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Best Practices: Data Contract Versioning
This topic lists the best practices for creating data contracts that can evolve easily over time. [!INCLUDE[crabout](../../../includes/crabout-md.md)] data contracts, see the topics in [Using Data Contracts](../../../docs/framework/wcf/feature-details/using-data-contracts.md).  
  
## Note on Schema Validation  
 In discussing data contract versioning, it is important to note that the data contract schema exported by [!INCLUDE[indigo1](../../../includes/indigo1-md.md)] does not have any versioning support, other than the fact that elements are marked as optional by default.  
  
 This means that even the most common versioning scenario, such as adding a new data member, cannot be implemented in a way that is seamless with regard to a given schema. The newer versions of a data contract (with a new data member, for example) do not validate using the old schema.  
  
 However, there are many scenarios in which strict schema compliance is not required. Many Web services platforms, including [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] and XML Web services created using ASP.NET, do not perform schema validation by default and therefore tolerate extra elements that are not described by the schema. When working with such platforms, many versioning scenarios are easier to implement.  
  
 Thus, there are two sets of data contract versioning guidelines: one set for scenarios where strict schema validity is important, and another set for scenarios when it is not.  
  
## Versioning When Schema Validation Is Required  
 If strict schema validity is required in all directions (new-to-old and old-to-new), data contracts should be considered immutable. If versioning is required, a new data contract should be created, with a different name or namespace, and the service contract using the data type should be versioned accordingly.  
  
 For example, a purchase order processing service contract named `PoProcessing` with a `PostPurchaseOrder` operation takes a parameter that conforms to a `PurchaseOrder` data contract. If the `PurchaseOrder` contract has to change, you must create a new data contract, that is, `PurchaseOrder2`, which includes the changes. You must then handle the versioning at the service contract level. For example, by creating a `PostPurchaseOrder2` operation that takes the `PurchaseOrder2` parameter, or by creating a `PoProcessing2` service contract where the `PostPurchaseOrder` operation takes a `PurchaseOrder2` data contract.  
  
 Note that changes in data contracts that are referenced by other data contracts also extend to the service model layer. For example, in the previous scenario the `PurchaseOrder` data contract does not need to change. However, it contains a data member of a `Customer` data contract, which in turn contained a data member of the `Address` data contract, which does need to be changed. In that case, you would need to create an `Address2` data contract with the required changes, a `Customer2` data contract that contains the `Address2` data member, and a `PurchaseOrder2` data contract that contains a `Customer2` data member. As in the previous case, the service contract would have to be versioned as well.  
  
 Although in these examples names are changed (by appending a "2"), the recommendation is to change namespaces instead of names by appending new namespaces with a version number or a date. For example, the `http://schemas.contoso.com/2005/05/21/PurchaseOrder` data contract would change to the `http://schemas.contoso.com/2005/10/14/PurchaseOrder` data contract.  
  
 [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] Best Practices: [Service Versioning](../../../docs/framework/wcf/service-versioning.md).  
  
 Occasionally, you must guarantee strict schema compliance for messages sent by your application, but cannot rely on the incoming messages to be strictly schema-compliant. In this case, there is a danger that an incoming message might contain extraneous data. The extraneous values are stored and returned by [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] and thus results in schema-invalid messages being sent. To avoid this problem, the round-tripping feature should be turned off. There are two ways to do this.  
  
-   Do not implement the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface on any of your types.  
  
-   Apply a <xref:System.ServiceModel.ServiceBehaviorAttribute> attribute to your service contract with the <xref:System.ServiceModel.ServiceBehaviorAttribute.IgnoreExtensionDataObject%2A> property set to `true`.  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] round-tripping, see [Forward-Compatible Data Contracts](../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md).  
  
## Versioning When Schema Validation Is Not Required  
 Strict schema compliance is rarely required. Many platforms tolerate extra elements not described by a schema. As long as this is tolerated, the full set of features described in [Data Contract Versioning](../../../docs/framework/wcf/feature-details/data-contract-versioning.md) and [Forward-Compatible Data Contracts](../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md) can be used. The following guidelines are recommended.  
  
 Some of the guidelines must be followed exactly in order to send new versions of a type where an older one is expected or send an old one where the new one is expected. Other guidelines are not strictly required, but are listed here because they may be affected by the future of schema versioning.  
  
1.  Do not attempt to version data contracts by type inheritance. To create later versions, either change the data contract on an existing type or create a new unrelated type.  
  
2.  The use of inheritance together with data contracts is allowed, provided that inheritance is not used as a versioning mechanism and that certain rules are followed. If a type derives from a certain base type, do not make it derive from a different base type in a future version (unless it has the same data contract). There is one exception to this: you can insert a type into the hierarchy between a data contract type and its base type, but only if it does not contain data members with the same names as other members in any possible versions of the other types in the hierarchy. In general, using data members with the same names at different levels of the same inheritance hierarchy can lead to serious versioning problems and should be avoided.  
  
3.  Starting with the first version of a data contract, always implement <xref:System.Runtime.Serialization.IExtensibleDataObject> to enable round-tripping. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Forward-Compatible Data Contracts](../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md). If you have released one or more versions of a type without implementing this interface, implement it in the next version of the type.  
  
4.  In later versions, do not change the data contract name or namespace. If changing the name or namespace of the type underlying the data contract, be sure to preserve the data contract name and namespace by using the appropriate mechanisms, such as the <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A> property of the <xref:System.Runtime.Serialization.DataContractAttribute>. [!INCLUDE[crabout](../../../includes/crabout-md.md)] naming, see [Data Contract Names](../../../docs/framework/wcf/feature-details/data-contract-names.md).  
  
5.  In later versions, do not change the names of any data members. If changing the name of the field, property, or event underlying the data member, use the `Name` property of the <xref:System.Runtime.Serialization.DataMemberAttribute> to preserve the existing data member name.  
  
6.  In later versions, do not change the type of any field, property, or event underlying a data member such that the resulting data contract for that data member changes. Keep in mind that interface types are equivalent to <xref:System.Object> for the purposes of determining the expected data contract.  
  
7.  In later versions, do not change the order of the existing data members by adjusting the <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A> property of the <xref:System.Runtime.Serialization.DataMemberAttribute> attribute.  
  
8.  In later versions, new data members can be added. They should always follow these rules:  
  
    1.  The <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> property should always be left at its default value of `false`.  
  
    2.  If a default value of `null` or zero for the member is unacceptable, a callback method should be provided using the <xref:System.Runtime.Serialization.OnDeserializingAttribute> to provide a reasonable default in case the member is not present in the incoming stream. [!INCLUDE[crabout](../../../includes/crabout-md.md)] the callback, see [Version-Tolerant Serialization Callbacks](../../../docs/framework/wcf/feature-details/version-tolerant-serialization-callbacks.md).  
  
    3.  The `Order` property on the `DataMemberAttribute` should be used to make sure that all of the newly added data members appear after the existing data members. The recommended way of doing this is as follows: None of the data members in the first version of the data contract should have their `Order` property set. All of the data members added in version 2 of the data contract should have their `Order` property set to 2. All of the data members added in version 3 of the data contract should have their `Order` set to 3, and so on. It is permissible to have more than one data member set to the same `Order` number.  
  
9. Do not remove data members in later versions, even if the <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A> property was left at its default property of `false` in prior versions.  
  
10. Do not change the `IsRequired` property on any existing data members from version to version.  
  
11. For required data members (where `IsRequired` is `true`), do not change the `EmitDefaultValue` property from version to version.  
  
12. Do not attempt to create branched versioning hierarchies. That is, there should always be a path in at least one direction from any version to any other version using only the changes permitted by these guidelines.  
  
     For example, if version 1 of a Person data contract contains only the Name data member, you should not create version 2a of the contract adding only the Age member and version 2b adding only the Address member. Going from 2a to 2b would involve removing Age and adding Address; going in the other direction would entail removing Address and adding Age. Removing members is not permitted by these guidelines.  
  
13. You should generally not create new subtypes of existing data contract types in a new version of your application. Likewise, you should not create new data contracts that are used in place of data members declared as Object or as interface types. Creating these new classes is allowed only when you know that you can add the new types to the known types list of all instances of your old application. For example, in version 1 of your application, you may have the LibraryItem data contract type with the Book and Newspaper data contract subtypes. LibraryItem would then have a known types list that contains Book and Newspaper. Suppose you now add a Magazine type in version 2 which is a subtype of LibraryItem. If you send a Magazine instance from version 2 to version 1, the Magazine data contract is not found in the list of known types and an exception is thrown.  
  
14. You should not add or remove enumeration members between versions. You should also not rename enumeration members, unless you use the Name property on the `EnumMemberAttribute` attribute to keep their names in the data contract model the same.  
  
15. Collections are interchangeable in the data contract model as described in [Collection Types in Data Contracts](../../../docs/framework/wcf/feature-details/collection-types-in-data-contracts.md). This allows for a great degree of flexibility. However, make sure that you do not inadvertently change a collection type in a non-interchangeable way from version to version. For example, do not change from a non-customized collection (that is, without the `CollectionDataContractAttribute` attribute) to a customized one or a customized collection to a non-customized one. Also, do not change the properties on the `CollectionDataContractAttribute` from version to version. The only allowed change is adding a Name or Namespace property if the underlying collection type's name or namespace has changed and you need to make its data contract name and namespace the same as in a previous version.  
  
 Some of the guidelines listed here can be safely ignored when special circumstances apply. Make sure you fully understand the serialization, deserialization, and schema mechanisms involved before deviating from the guidelines.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A>  
 <xref:System.Runtime.Serialization.DataContractAttribute>  
 <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A>  
 <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A>  
 <xref:System.Runtime.Serialization.IExtensibleDataObject>  
 <xref:System.ServiceModel.ServiceBehaviorAttribute>  
 <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData%2A>  
 <xref:System.Runtime.Serialization.ExtensionDataObject>  
 <xref:System.Runtime.Serialization.OnDeserializingAttribute>  
 [Using Data Contracts](../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
 [Data Contract Versioning](../../../docs/framework/wcf/feature-details/data-contract-versioning.md)  
 [Data Contract Names](../../../docs/framework/wcf/feature-details/data-contract-names.md)  
 [Forward-Compatible Data Contracts](../../../docs/framework/wcf/feature-details/forward-compatible-data-contracts.md)  
 [Version-Tolerant Serialization Callbacks](../../../docs/framework/wcf/feature-details/version-tolerant-serialization-callbacks.md)
