---
title: "<persistableType>"
ms.date: "03/30/2017"
ms.assetid: e5425fe6-523a-4076-aab4-2c2515b1d830
---
# \<persistableType>
Specifies all the persistable types.  
  
 \<system.ServiceModel>  
\<comContracts>  
\<comContract>  
  
## Syntax  
  
```xml  
<comContracts>
  <comContract>
    <persistableTypes>
      <persistableType id="String"
                       name="String">
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
|[\<persistableTypes>](persistabletypes.md)|A collection of `persistableType` elements.|  
  
## See also

- <xref:System.ServiceModel.Configuration.ComPersistableTypeElementCollection>
- <xref:System.ServiceModel.Configuration.ComPersistableTypeElement>
- [\<comContracts>](comcontracts.md)
- [Integrating with COM+ Applications](../../feature-details/integrating-with-com-plus-applications.md)
- [How to: Configure COM+ Service Settings](../../feature-details/how-to-configure-com-service-settings.md)
