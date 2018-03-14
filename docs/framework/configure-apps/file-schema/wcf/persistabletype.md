---
title: "&lt;persistableType&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e5425fe6-523a-4076-aab4-2c2515b1d830
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;persistableType&gt;
Specifies all the persistable types.  
  
 \<system.ServiceModel>  
\<comContracts>  
\<comContract>  
  
## Syntax  
  
```xml  
<comContracts>  
  <comContract>  
      <persistableTypes>  
         <persistableType id="string"  
            name="string">  
         </persistableType>  
      </persistableTypes>  
  </comContract>  
</comContracts>  
```  
  
## Type  
 `Type`  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|id|A required attribute that contains a string that specifies a unique identifier for a persistable type.|  
|name|An optional attribute that contains a string that specifies the name of the persistable type.|  
  
### Child Elements  
 None  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<persistableTypes>](../../../../../docs/framework/configure-apps/file-schema/wcf/persistabletypes.md)|A collection of `persistableType` elements.|  
  
## See Also  
 <xref:System.ServiceModel.Configuration.ComPersistableTypeElementCollection>  
 <xref:System.ServiceModel.Configuration.ComPersistableTypeElement>  
 [\<comContracts>](../../../../../docs/framework/configure-apps/file-schema/wcf/comcontracts.md)  
 [Integrating with COM+ Applications](../../../../../docs/framework/wcf/feature-details/integrating-with-com-plus-applications.md)  
 [How to: Configure COM+ Service Settings](../../../../../docs/framework/wcf/feature-details/how-to-configure-com-service-settings.md)
