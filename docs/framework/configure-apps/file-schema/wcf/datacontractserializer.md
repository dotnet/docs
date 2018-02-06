---
title: "dataContractSerializer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a47513a4-a96c-4350-8586-daacb05dee71
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# dataContractSerializer
Contains configuration data for the <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<dataContractSerializer>  
  
## Syntax  
  
```xml  
<dataContractSerializer ignoreExtensionDataObject="Boolean"  
      maxItemsInObjectGraph="Integer" />  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Element|Description|  
|-------------|-----------------|  
|ignoreExtensionDataObject|A Boolean value that specifies whether to ignore data supplied by the endpoint, when it is being serialized or deserialized.|  
|maxItemsInObjectGraph|An integer that specifies the maximum number of items to serialize or deserialize.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies an endpoint behavior.|  
  
## Remarks  
 See the <xref:System.Runtime.Serialization.DataContractSerializer> documentation for more information about known types.  
  
> [!CAUTION]
>  The `<dataContractSerializer>` behavior element (if present) should always appear before the `<enableWebScript>` behavior element in the configuration file. Otherwise, the resulting behavior is undefined.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior>  
 <xref:System.ServiceModel.Configuration.DataContractSerializerElement>  
 [Data Contract Known Types](../../../../../docs/framework/wcf/feature-details/data-contract-known-types.md)  
 [Data Transfer and Serialization](../../../../../docs/framework/wcf/feature-details/data-transfer-and-serialization.md)
