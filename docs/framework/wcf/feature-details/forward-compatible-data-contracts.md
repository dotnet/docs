---
title: "Forward-Compatible Data Contracts"
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
  - "data contracts [WCF], forward compatibility"
ms.assetid: 413c9044-26f8-4ecb-968c-18495ea52cd9
caps.latest.revision: 21
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Forward-Compatible Data Contracts
A feature of the [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] data contract system is that contracts can evolve over time in nonbreaking ways. That is, a client with an older version of a data contract can communicate with a service with a newer version of the same data contract, or a client with a newer version of a data contract can communicate with an older version of the same data contract. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Best Practices: Data Contract Versioning](../../../../docs/framework/wcf/best-practices-data-contract-versioning.md).  
  
 You can apply most of the versioning features on an as-needed basis when new versions of an existing data contract are created. However, one versioning feature, *round-tripping*, must be built into the type from the first version in order to work properly.  
  
## Round-Tripping  
 Round-tripping occurs when data passes from a new version to an old version and back to the new version of a data contract. Round-tripping guarantees that no data is lost. Enabling round-tripping makes the type forward-compatible with any future changes supported by the data contract versioning model.  
  
 To enable round-tripping for a particular type, the type must implement the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface. The interface contains one property, <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData%2A> (returning the <xref:System.Runtime.Serialization.ExtensionDataObject> type). The property stores any data from future versions of the data contract that is unknown to the current version.  
  
### Example  
 The following data contract is not forward-compatible with future changes.  
  
 [!code-csharp[C_DataContract#7](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontract/cs/source.cs#7)]
 [!code-vb[C_DataContract#7](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontract/vb/source.vb#7)]  
  
 To make the type compatible with future changes (such as adding a new data member named "phoneNumber"), implement the <xref:System.Runtime.Serialization.IExtensibleDataObject> interface.  
  
 [!code-csharp[C_DataContract#8](../../../../samples/snippets/csharp/VS_Snippets_CFX/c_datacontract/cs/source.cs#8)]
 [!code-vb[C_DataContract#8](../../../../samples/snippets/visualbasic/VS_Snippets_CFX/c_datacontract/vb/source.vb#8)]  
  
 When the [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)] infrastructure encounters data that is not part of the original data contract, the data is stored in the property and preserved. It is not processed in any other way except for temporary storage. If the object is returned back to where it originated, the original (unknown) data is also returned. Therefore, the data has made a round trip to and from the originating endpoint without loss. Note, however, that if the originating endpoint required the data to be processed, that expectation is unmet, and the endpoint must somehow detect and accommodate the change.  
  
 The <xref:System.Runtime.Serialization.ExtensionDataObject> type contains no public methods or properties. Thus, it is impossible to get direct access to the data stored inside the <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData%2A> property.  
  
 The round-tripping feature may be turned off, either by setting `ignoreExtensionDataObject` to `true` in the <xref:System.Runtime.Serialization.DataContractSerializer> constructor or by setting the <xref:System.ServiceModel.ServiceBehaviorAttribute.IgnoreExtensionDataObject%2A> property to `true` on the <xref:System.ServiceModel.ServiceBehaviorAttribute>. When this feature is off, the deserializer will not populate the <xref:System.Runtime.Serialization.IExtensibleDataObject.ExtensionData%2A> property, and the serializer will not emit the contents of the property.  
  
## See Also  
 <xref:System.Runtime.Serialization.IExtensibleDataObject>  
 <xref:System.Runtime.Serialization.ExtensionDataObject>  
 [Data Contract Versioning](../../../../docs/framework/wcf/feature-details/data-contract-versioning.md)  
 [Best Practices: Data Contract Versioning](../../../../docs/framework/wcf/best-practices-data-contract-versioning.md)
