---
title: "&lt;parameter&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0fb41e2d-64f7-44ab-993e-05892eac6d82
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;parameter&gt;
Specifies the generic parameter when a declared type is a generic type.  
  
 \<system.runtime.serialization>  
\<dataContractSerializer>  
\<declaredTypes> Element  
\<add> element for \<declaredTypes>  
\<knownType> Element  
\<parameter> Element  
  
## Syntax  
  
```xml  
<parameter index="integer"  
                      type=String" />  
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
|[\<knownType>](../../../../../docs/framework/configure-apps/file-schema/wcf/knowntype.md)|Specifies a known type that can be returned by a field or property of the declared type.|  
  
## Remarks  
 [!INCLUDE[crabout](../../../../../includes/crabout-md.md)] known types, see [Data Contract Known Types](../../../../../docs/framework/wcf/feature-details/data-contract-known-types.md) and <xref:System.Runtime.Serialization.DataContractSerializer>.  
  
 See the [\<dataContractSerializer>](../../../../../docs/framework/configure-apps/file-schema/wcf/datacontractserializer-element.md) for an example of using this element.  
  
 This configuration element cannot have both attributes at the same time. If both attributes are set, a <xref:System.Configuration.ConfigurationErrorsException> occurs.  
  
## See Also  
 <xref:System.Runtime.Serialization.DataContractSerializer>  
 [Data Contract Known Types](../../../../../docs/framework/wcf/feature-details/data-contract-known-types.md)  
 [\<dataContractSerializer>](../../../../../docs/framework/configure-apps/file-schema/wcf/datacontractserializer-element.md)  
 [\<add>](../../../../../docs/framework/configure-apps/file-schema/wcf/add-of-declaredtypes-element.md)
