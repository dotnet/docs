---
title: "<extensions> section"
ms.date: "03/30/2017"
ms.assetid: 53a59fb6-dede-47ec-9384-b3c2e8f0c1fa
---
# \<extensions> section
This configuration section contains a collection of extensions, which enable the user to create user-defined bindings, behaviors, and other aspects of extensions.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;\<extensions>  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <extensions>
    <bindingExtensions>
    </bindingExtensions>
    <behaviorExtensions>
    </behaviorExtensions>
    <bindingElementExtensions>
    </bindingElementExtensions>
    <endpointExtensions>
    </endpointExtensions>
  </extensions>
</system.serviceModel>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behaviorExtensions>](behaviorextensions.md)|This section contains child elements that specify behavior extensions, which enable the user to customize service or endpoint behaviors.|  
|[\<bindingElementExtensions>](bindingelementextensions.md)|This section enables the use of a custom binding element from a machine or application configuration file.|  
|[\<bindingExtensions>](bindingextensions.md)|This section contains child elements that specify binding extensions, which enable the user to customize bindings.|  
|[\<endpointExtensions>](endpointextensions.md)|This section contains child elements that registers standard endpoints.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|system.ServiceModel|The root element of all WCF configuration elements.|
