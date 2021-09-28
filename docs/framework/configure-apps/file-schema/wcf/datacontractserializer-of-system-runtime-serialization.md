---
description: "Learn more about: <dataContractSerializer> of <system.runtime.serialization>"
title: "<dataContractSerializer> of <system.runtime.serialization>"
ms.date: "03/30/2017"
ms.assetid: d9b3d625-be3f-4768-8e0d-1b7e6929f6a8
---
# \<dataContractSerializer> of \<system.runtime.serialization>

Contains configuration data for the <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.runtime.serialization>**](system-runtime-serialization.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<dataContractSerializer>**  
  
## Syntax  
  
```xml  
<configuration>
  <system.runtime.serialization>
    <dataContractSerializer ignoreExtensionDataObject="Boolean"
                            maxItemsInObjectGraph="Integer">
      <declaredTypes>
        <add type="String">
          <knownType type="String">
            <parameter index="Integer"
                       type="String" />
          </knownType>
        </add>
      </declaredTypes>
    <dataContractSerializer>
  </system.runtime.serialization>
</configuration>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Element|Description|  
|-------------|-----------------|  
|ignoreExtensionDataObject|A Boolean value that specifies whether to ignore data supplied by the endpoint when it is being serialized or deserialized. This attribute is settable only on the `<dataContractSerializer>` under the `<behavior>` element.|  
|maxItemsInObjectGraph|An integer that specifies the maximum number of items to serialize or deserialize. This attribute is 65536.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<declaredTypes>](declaredtypes.md)|Contains the known types that the <xref:System.Runtime.Serialization.DataContractSerializer> uses when deserializing.<br /><br /> For more information about data contracts and known types, see [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md).|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.runtime.serialization>](system-runtime-serialization.md)|Represents the root element for the <xref:System.Runtime.Serialization> namespace section and contains elements for setting options of the <xref:System.Runtime.Serialization.DataContractSerializer>.|  
  
## Remarks  

 For more information about known types, see <xref:System.Runtime.Serialization.DataContractSerializer> and [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md).  
  
## See also

- <xref:System.Runtime.Serialization.DataContractSerializer>
- <xref:System.ServiceModel.Description.DataContractSerializerOperationBehavior>
- [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md)
