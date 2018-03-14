---
title: "Service Versioning"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 37575ead-d820-4a67-8059-da11a2ab48e2
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Service Versioning
After initial deployment, and potentially several times during their lifetime, services (and the endpoints they expose) may need to be changed for a variety of reasons, such as changing business needs, information technology requirements, or to address other issues. Each change introduces a new version of the service. This topic explains how to consider versioning in [!INCLUDE[indigo1](../../../includes/indigo1-md.md)].  
  
## Four Categories of Service Changes  
 The changes to services that may be required can be classified into four categories:  
  
-   Contract changes: For example, an operation might be added, or a data element in a message might be added or changed.  
  
-   Address changes: For example, a service moves to a different location where endpoints have new addresses.  
  
-   Binding changes: For example, a security mechanism changes or its settings change.  
  
-   Implementation changes: For example, when an internal method implementation changes.  
  
 Some of these changes are called "breaking" and others are "nonbreaking." A change is *nonbreaking* if all messages that would have been processed successfully in the previous version are processed successfully in the new version. Any change that does not meet that criterion is a *breaking* change.  
  
## Service Orientation and Versioning  
 One of the tenets of service orientation is that services and clients are autonomous (or independent). Among other things, this implies that service developers cannot assume that they control or even know about all service clients. This eliminates the option of rebuilding and redeploying all clients when a service changes versions. This topic assumes the service adheres to this tenet and therefore must be changed or "versioned" independent of its clients.  
  
 In cases where a breaking change is unexpected and cannot be avoided, an application may choose to ignore this tenet and require that clients be rebuilt and redeployed with a new version of the service.  
  
## Contract Versioning  
 Contracts used by a client do not need to be the same as the contract used by the service; they need only to be compatible.  
  
 For service contracts, compatibility means new operations exposed by the service can be added but existing operations cannot be removed or changed semantically.  
  
 For data contracts, compatibility means new schema type definitions can be added but existing schema type definitions cannot be changed in breaking ways. Breaking changes might include removing data members or changing their data type incompatibly. This feature allows the service some latitude in changing the version of its contracts without breaking clients. The next two sections explain nonbreaking and breaking changes that can be made to [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] data and service contracts.  
  
## Data Contract Versioning  
 This section deals with data versioning when using the <xref:System.Runtime.Serialization.DataContractSerializer> and <xref:System.Runtime.Serialization.DataContractAttribute> classes.  
  
### Strict Versioning  
 In many scenarios when changing versions is an issue, the service developer does not have control over the clients and therefore cannot make assumptions about how they would react to changes in the message XML or schema. In these cases, you must guarantee that the new messages will validate against the old schema, for two reasons:  
  
-   The old clients were developed with the assumption that the schema will not change. They may fail to process messages that they were never designed for.  
  
-   The old clients may perform actual schema validation against the old schema before even attempting to process the messages.  
  
 The recommended approach in such scenarios is to treat existing data contracts as immutable and create new ones with unique XML qualified names. The service developer would then either add new methods to an existing service contract or create a new service contract with methods that use the new data contract.  
  
 It will often be the case that a service developer needs to write some business logic that should run within all versions of a data contract plus version-specific business code for each version of the data contract. The appendix at the end of this topic explains how interfaces can be used to satisfy this need.  
  
### Lax Versioning  
 In many other scenarios, the service developer can make the assumption that adding a new, optional member to the data contract will not break existing clients. This requires the service developer to investigate whether existing clients are not performing schema validation and that they ignore unknown data members. In these scenarios, it is possible to take advantage of data contract features for adding new members in a nonbreaking way. The service developer can make this assumption with confidence if the data contract features for versioning were already used for the first version of the service.  
  
 [!INCLUDE[indigo2](../../../includes/indigo2-md.md)], ASP.NET Web Services, and many other Web service stacks support *lax versioning*: that is, they do not throw exceptions for new unknown data members in received data.  
  
 It is easy to mistakenly believe that adding a new member will not break existing clients. If you are unsure that all clients can handle lax versioning, the recommendation is to use the strict versioning guidelines and treat data contracts as immutable.  
  
 For detailed guidelines for both lax and strict versioning of data contracts, see [Best Practices: Data Contract Versioning](../../../docs/framework/wcf/best-practices-data-contract-versioning.md).  
  
### Distinguishing Between Data Contract and .NET Types  
 A .NET class or structure can be projected as a data contract by applying the <xref:System.Runtime.Serialization.DataContractAttribute> attribute to the class. The .NET type and its data contract projections are two distinct matters. It is possible to have multiple .NET types with the same data contract projection. This distinction is especially useful in allowing you to change the .NET type while maintaining the projected data contract, thereby maintaining compatibility with existing clients even in the strict sense of the word. There are two things you should always do to maintain this distinction between .NET type and data contract:  
  
-   Specify a <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A> and <xref:System.Runtime.Serialization.DataContractAttribute.Namespace%2A>. You should always specify the name and namespace of your data contract to prevent your .NET type’s name and namespace from being exposed in the contract. This way, if you decide later to change the .NET namespace or type name, your data contract remains the same.  
  
-   Specify <xref:System.Runtime.Serialization.DataMemberAttribute.Name%2A>. You should always specify the name of your data members to prevent your .NET member name from being exposed in the contract. This way, if you decide later to change the .NET name of the member, your data contract remains the same.  
  
### Changing or Removing Members  
 Changing the name or data type of a member, or removing data members is a breaking change even if lax versioning is allowed. If this is necessary, create a new data contract.  
  
 If service compatibility is of high importance, you might consider ignoring unused data members in your code and leave them in place. If you are splitting up a data member into multiple members, you might consider leaving the existing member in place as a property that can perform the required splitting and re-aggregation for down-level clients (clients that are not upgraded to the latest version).  
  
 Similarly, changes to the data contract’s name or namespace are breaking changes.  
  
### Round-Trips of Unknown Data  
 In some scenarios, there is a need to "round-trip" unknown data that comes from members added in a new version. For example, a "versionNew" service sends data with some newly added members to a "versionOld" client. The client ignores the newly added members when processing the message, but it resends that same data, including the newly added members, back to the versionNew service. The typical scenario for this is data updates where data is retrieved from the service, changed, and returned.  
  
 To enable round-tripping for a particular type, the type must implement the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface. The interface contains one property, <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData%2A> that returns the <xref:System.Runtime.Serialization.ExtensionDataObject> type. The property is used to store any data from future versions of the data contract that is unknown to the current version. This data is opaque to the client, but when the instance is serialized, the content of the <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData%2A> property is written with the rest of the data contract members' data.  
  
 It is recommended that all your types implement this interface to accommodate new and unknown future members.  
  
### Data Contract Libraries  
 There may be libraries of data contracts where a contract is published to a central repository, and service and type implementers implement and expose data contracts from that repository. In that case, when you publish a data contract to the repository, you have no control over who creates types that implement it. Thus, you cannot modify the contract once it is published, rendering it effectively immutable.  
  
### When Using the XmlSerializer  
 The same versioning principles apply when using the <xref:System.Xml.Serialization.XmlSerializer> class. When strict versioning is required, treat data contracts as immutable and create new data contracts with unique, qualified names for the new versions. When you are sure that lax versioning can be used, you can add new serializable members in new versions but not change or remove existing members.  
  
> [!NOTE]
>  The <xref:System.Xml.Serialization.XmlSerializer> uses the <xref:System.Xml.Serialization.XmlAnyElementAttribute> and <xref:System.Xml.Serialization.XmlAnyAttributeAttribute> attributes to support round-tripping of unknown data.  
  
## Message Contract Versioning  
 The guidelines for message contract versioning are very similar to versioning data contracts. If strict versioning is required, you should not change your message body but instead create a new message contract with a unique qualified name. If you know that you can use lax versioning, you can add new message body parts but not change or remove existing ones. This guidance applies both to bare and wrapped message contracts.  
  
 Message headers can always be added, even if strict versioning is in use. The MustUnderstand flag may affect versioning. In general, the versioning model for headers in [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] is as described in the SOAP specification.  
  
## Service Contract Versioning  
 Similar to data contract versioning, service contract versioning also involves adding, changing, and removing operations.  
  
### Specifying Name, Namespace, and Action  
 By default, the name of a service contract is the name of the interface. Its default namespace is "http://tempuri.org", and each operation’s action is "http://tempuri.org/contractname/methodname". It is recommended that you explicitly specify a name and namespace for the service contract, and an action for each operation to avoid using "http://tempuri.org" and to prevent interface and method names from being exposed in the service’s contract.  
  
### Adding Parameters and Operations  
 Adding service operations exposed by the service is a nonbreaking change because existing clients need not be concerned about those new operations.  
  
> [!NOTE]
>  Adding operations to a duplex callback contract is a breaking change.  
  
### Changing Operation Parameter or Return Types  
 Changing parameter or return types generally is a breaking change unless the new type implements the same data contract implemented by the old type. To make such a change, add a new operation to the service contract or define a new service contract.  
  
### Removing Operations  
 Removing operations is also a breaking change. To make such a change, define a new service contract and expose it on a new endpoint.  
  
### Fault Contracts  
 The <xref:System.ServiceModel.FaultContractAttribute> attribute enables a service contract developer to specify information about faults that can be returned from the contract's operations.  
  
 The list of faults described in a service's contract is not considered exhaustive. At any time, an operation may return faults that are not described in its contract. Therefore changing the set of faults described in the contract is not considered breaking. For example, adding a new fault to the contract using the <xref:System.ServiceModel.FaultContractAttribute> or removing an existing fault from the contract.  
  
### Service Contract Libraries  
 Organizations may have libraries of contracts where a contract is published to a central repository and service implementers implement contracts from that repository. In this case, when you publish a service contract to the repository you have no control over who creates services that implement it. Therefore, you cannot modify the service contract once published, rendering it effectively immutable. [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] supports contract inheritance, which can be used to create a new contract that extends existing contracts. To use this feature, define a new service contract interface that inherits from the old service contract interface, then add methods to the new interface. You then change the service that implements the old contract to implement the new contract and change the "versionOld" endpoint definition to use the new contract. To "versionOld" clients, the endpoint will continue to appear as exposing the "versionOld" contract; to "versionNew" clients, the endpoint will appear to expose the "versionNew" contract.  
  
## Address and Binding Versioning  
 Changes to endpoint address and binding are breaking changes unless clients are capable of dynamically discovering the new endpoint address or binding. One mechanism for implementing this capability is by using a Universal Discovery Description and Integration (UDDI) registry and the UDDI Invocation Pattern where a client attempts to communicate with an endpoint and, upon failure, queries a well-known UDDI registry for the current endpoint metadata. The client then uses the address and binding from this metadata to communicate with the endpoint. If this communication succeeds, the client caches the address and binding information for future use.  
  
## Routing Service and Versioning  
 If the changes made to a service are breaking changes and you need to have two or more different versions of a service running simultaneously you can use the WCF Routing Service to route messages to the appropriate service instance. The WCF Routing Service uses content-based routing, in other words, it uses information within the message to determine where to route the message. [!INCLUDE[crabout](../../../includes/crabout-md.md)] the WCF Routing Service see [Routing Service](../../../docs/framework/wcf/feature-details/routing-service.md). For an example of how to use the WCF Routing Service for service versioning see [How To: Service Versioning](../../../docs/framework/wcf/feature-details/how-to-service-versioning.md).  
  
## Appendix  
 The general data contract versioning guidance when strict versioning is needed is to treat data contracts as immutable and create new ones when changes are required. A new class needs to be created for each new data contract, so a mechanism is needed to avoid having to take existing code that was written in terms of the old data contract class and rewrite it in terms of the new data contract class.  
  
 One such mechanism is to use interfaces to define the members of each data contract and write internal implementation code in terms of the interfaces rather than the data contract classes that implement the interfaces. The following code for version 1 of a service shows an `IPurchaseOrderV1` interface and a `PurchaseOrderV1`:  
  
```  
public interface IPurchaseOrderV1  
{  
    string OrderId { get; set; }  
    string CustomerId { get; set; }  
}  
  
[DataContract(  
Name = "PurchaseOrder",  
Namespace = "http://examples.microsoft.com/WCF/2005/10/PurchaseOrder")]  
public class PurchaseOrderV1 : IPurchaseOrderV1  
{  
    [DataMember(...)]  
    public string OrderId {...}  
    [DataMember(...)]  
    public string CustomerId {...}  
}  
```  
  
 While the service contract’s operations would be written in terms of `PurchaseOrderV1`, the actual business logic would be in terms of `IPurchaseOrderV1`. Then, in version 2, there would be a new `IPurchaseOrderV2` interface and a new `PurchaseOrderV2` class as shown in the following code:  
  
```  
public interface IPurchaseOrderV2  
{  
    DateTime OrderDate { get; set; }  
}

[DataContract(   
Name = "PurchaseOrder",  
Namespace = "http://examples.microsoft.com/WCF/2006/02/PurchaseOrder")]  
public class PurchaseOrderV2 : IPurchaseOrderV1, IPurchaseOrderV2  
{  
    [DataMember(...)]  
    public string OrderId {...}  
    [DataMember(...)]  
    public string CustomerId {...}  
    [DataMember(...)]  
    public DateTime OrderDate { ... }  
}  
```  
  
 The service contract would be updated to include new operations that are written in terms of `PurchaseOrderV2`. Existing business logic written in terms of `IPurchaseOrderV1` would continue to work for `PurchaseOrderV2` and new business logic that needs the `OrderDate` property would be written in terms of `IPurchaseOrderV2`.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.Runtime.Serialization.DataContractAttribute>  
 <xref:System.Runtime.Serialization.DataContractAttribute.Name%2A>  
 <xref:System.Runtime.Serialization.DataContractAttribute.Namespace%2A>  
 <xref:System.Runtime.Serialization.DataMemberAttribute.Order%2A>  
 <xref:System.Runtime.Serialization.DataMemberAttribute.IsRequired%2A>  
 <xref:System.Runtime.Serialization.IExtensibleDataObject>  
 <xref:System.Runtime.Serialization.ExtensionDataObject>  
 <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData%2A>  
 <xref:System.Xml.Serialization.XmlSerializer>  
 [Data Contract Equivalence](../../../docs/framework/wcf/feature-details/data-contract-equivalence.md)  
 [Version-Tolerant Serialization Callbacks](../../../docs/framework/wcf/feature-details/version-tolerant-serialization-callbacks.md)
