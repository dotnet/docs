---
description: "Learn more about: dataContractSerializer"
title: "dataContractSerializer"
ms.date: "03/30/2017"
ms.assetid: a47513a4-a96c-4350-8586-daacb05dee71
---
# dataContractSerializer

Contains configuration data for the <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<endpointBehaviors>**](endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-endpointbehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<dataContractSerializer>**  
  
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
|[\<behavior>](behavior-of-endpointbehaviors.md)|Specifies an endpoint behavior.|  
  
## Remarks  

 See the <xref:System.Runtime.Serialization.DataContractSerializer> documentation for more information about known types.  
  
> [!CAUTION]
> The `<dataContractSerializer>` behavior element (if present) should always appear before the `<enableWebScript>` behavior element in the configuration file. Otherwise, the resulting behavior is undefined.  
  
## See also

- <xref:System.Runtime.Serialization.DataContractSerializer>
- <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior>
- <xref:System.ServiceModel.Configuration.DataContractSerializerElement>
- [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md)
- [Data Transfer and Serialization](../../../wcf/feature-details/data-transfer-and-serialization.md)
