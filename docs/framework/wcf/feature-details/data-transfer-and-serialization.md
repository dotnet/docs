---
title: "Data Transfer and Serialization"
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
  - "data serialization [WCF]"
  - "data transfer [WCF]"
ms.assetid: 0f03c635-f3e7-4c5c-9463-3cb0135e221e
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Data Transfer and Serialization
In a connected system, services and clients depend on the exchange of data to accomplish any task. As a developer of a service or client, you must also understand how [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] handles data and data serialization in order to create applications that are efficient and easy to maintain.  
  
## In This Section  
 [Specifying Data Transfer in Service Contracts](../../../../docs/framework/wcf/feature-details/specifying-data-transfer-in-service-contracts.md)  
 Describes the basic concepts of data transfer in services.  
  
 [Using Data Contracts](../../../../docs/framework/wcf/feature-details/using-data-contracts.md)  
 Describes what data contracts are and how to create and use them.  
  
 [Data Contract Serializer](../../../../docs/framework/wcf/feature-details/data-contract-serializer.md)  
 Describes how to accomplish serialization of data with the <xref:System.Runtime.Serialization.DataContractSerializer> class or any extension of the <xref:System.Runtime.Serialization.XmlObjectSerializer> class.  
  
 [Using the XmlSerializer Class](../../../../docs/framework/wcf/feature-details/using-the-xmlserializer-class.md)  
 Describes how and why to use the <xref:System.Xml.Serialization.XmlSerializer> class, an alternative to the <xref:System.Runtime.Serialization.DataContractSerializer> class.  
  
 [Using Message Contracts](../../../../docs/framework/wcf/feature-details/using-message-contracts.md)  
 Describes how message contracts allow fine control over SOAP messages.  
  
 [Using the Message Class](../../../../docs/framework/wcf/feature-details/using-the-message-class.md)  
 Describes how to use Message class features.  
  
 [Filtering](../../../../docs/framework/wcf/feature-details/filtering.md)  
 Describes filtering, which enables pre-processing of a message based on various criteria.  
  
 [Large Data and Streaming](../../../../docs/framework/wcf/feature-details/large-data-and-streaming.md)  
 Describes how to send a large block of data, such as a binary file.  
  
 [Security Considerations for Data](../../../../docs/framework/wcf/feature-details/security-considerations-for-data.md)  
 Describes items to be aware of when programming data transfer and serialization.  
  
 [Data Transfer Architectural Overview](../../../../docs/framework/wcf/feature-details/data-transfer-architectural-overview.md)  
 Describes a view of the overall design of data transfer in [!INCLUDE[indigo2](../../../../includes/indigo2-md.md)].  
  
## Reference  
 <xref:System.ServiceModel>  
  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
  
 <xref:System.Xml.Serialization.XmlSerializer>  
  
 <xref:System.Runtime.Serialization>  
  
 <xref:System.Xml.Serialization>  
  
## Related Sections  
 [Extending Encoders and Serializers](../../../../docs/framework/wcf/extending/extending-encoders-and-serializers.md)  
  
## See Also  
 [Best Practices: Data Contract Versioning](../../../../docs/framework/wcf/best-practices-data-contract-versioning.md)  
 [Service Versioning](../../../../docs/framework/wcf/service-versioning.md)
