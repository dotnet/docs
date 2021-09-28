---
description: "Learn more about: <dataContractSerializer>"
title: "<dataContractSerializer>"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "dataContractSerializer element"
  - "<dataContractSerializer> element"
  - "DataContractSerializer"
  - "KnownTypes"
ms.assetid: f41fb4d5-24e7-4059-8010-286a30bfea93
---
# \<dataContractSerializer>

Contains configuration data for the <xref:System.Runtime.Serialization.DataContractSerializer>. This element occurs in two different hierarchies. One is listed the following Schema Hierarchy section and the other is listed in the Remarks section.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-servicebehaviors.md)\
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
|ignoreExtensionDataObject|A Boolean value that specifies whether to ignore data supplied by the endpoint when it is being serialized or deserialized. This attribute is settable only on the `<dataContractSerializer>` under the `<behavior>` element.|  
|maxItemsInObjectGraph|An integer that specifies the maximum number of items to serialize or deserialize. This attribute is 65536.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](behavior-of-servicebehaviors.md)|A collection of settings for the behavior of a service.|  
|[\<system.runtime.serialization>](system-runtime-serialization.md)|Represents the root element for the <xref:System.Runtime.Serialization> namespace section and contains elements for setting options of the <xref:System.Runtime.Serialization.DataContractSerializer>.|  
  
## Remarks  

 As stated in the Introduction of this topic, this is the second hierarchy in which the \<X509Extension> element occurs.  
  
 [\<system.runtime.serialization>](system-runtime-serialization.md)  
  
 [\<dataContractSerializer>](datacontractserializer-element.md)  
  
 For more information about known types, see <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
## See also

- <xref:System.Runtime.Serialization.DataContractSerializer>
- <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior>
- <xref:System.ServiceModel.Configuration.DataContractSerializerElement>
- [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md)
- [Data Transfer and Serialization](../../../wcf/feature-details/data-transfer-and-serialization.md)
