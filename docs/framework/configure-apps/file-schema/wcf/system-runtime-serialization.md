---
title: "<system.runtime.serialization>"
ms.date: "03/30/2017"
ms.assetid: a8cebf4c-06d2-4667-8f5b-c3e1fc90df6f
---
# \<system.runtime.serialization>
Represents the root element for the <xref:System.Runtime.Serialization> namespace section and contains elements for setting options of the <xref:System.Runtime.Serialization.DataContractSerializer>.  

[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;**\<system.runtime.serialization>**  
  
## Syntax  
  
```xml  
<configuration>
  <system.runtime.serialization>
    <dataContractSerializer ignoreExtensionDataObject="Boolean"
                            maxItemsInObjectGraph="Integer">
      <declaredTypes>
        <add type="String">
          <knownType type="String">
            <parameter index="Integer" />
          </knownType>
        </add>
      </declaredTypes>
    <dataContractSerializer>
  </system.runtime.serialization>
</configuration>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<dataContractSerializer>](datacontractserializer-of-system-runtime-serialization.md)|Enables addition of known types to be used when deserialization.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<configuration> Element](../configuration-element.md)|The top level element for configuration.|  
  
## See also

- <xref:System.Runtime.Serialization>
- [Using Data Contracts](../../../wcf/feature-details/using-data-contracts.md)
- [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md)
 