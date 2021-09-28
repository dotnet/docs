---
description: "Learn more about: <parameter>"
title: "<parameter>"
ms.date: "03/30/2017"
ms.assetid: 0fb41e2d-64f7-44ab-993e-05892eac6d82
---
# \<parameter>

Specifies the generic parameter when a declared type is a generic type.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.runtime.serialization>**](system-runtime-serialization.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<dataContractSerializer>**](datacontractserializer.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<declaredTypes>**](declaredtypes.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<add>**](add-of-declaredtypes-element.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<knownType>**](knowntype.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<parameter>**  
  
## Syntax  
  
```xml  
<parameter index="Integer"
           type="String" />
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|index|When the declared type is a generic type, specifies the generic parameter that will return the known type.|  
|type|A string that describes the known type used for serialization and deserialization.|  
  
## index Attribute  
  
|Value|Description|  
|-----------|-----------------|  
|"0"|The first parameter in the generic type. For example, a <xref:System.Collections.Generic.List%601> has only one parameter. If it is used as the declared type, the index would be set to "0".|  
|"1"|The second parameter in a generic type. For example, a <xref:System.Collections.Generic.Dictionary%602> has two parameters. If the known type is returned by the second parameter, set the index attribute to "1".|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<knownType>](knowntype.md)|Specifies a known type that can be returned by a field or property of the declared type.|  
  
## Remarks  

 For more information about known types, see [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md) and <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
 See the [\<dataContractSerializer>](datacontractserializer-element.md) for an example of using this element.  
  
 This configuration element cannot have both attributes at the same time. If both attributes are set, a <xref:System.Configuration.ConfigurationErrorsException> occurs.  
  
## See also

- <xref:System.Runtime.Serialization.DataContractSerializer>
- [Data Contract Known Types](../../../wcf/feature-details/data-contract-known-types.md)
- [\<dataContractSerializer>](datacontractserializer-element.md)
- [\<add>](add-of-declaredtypes-element.md)
