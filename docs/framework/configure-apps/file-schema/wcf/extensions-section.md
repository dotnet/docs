---
title: "&lt;extensions&gt; section"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 53a59fb6-dede-47ec-9384-b3c2e8f0c1fa
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;extensions&gt; section
This configuration section contains a collection of extensions, which enable the user to create user-defined bindings, behaviors, and other aspects of extensions.  
  
\<system.ServiceModel>  
  
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
|[\<behaviorExtensions>](../../../../../docs/framework/configure-apps/file-schema/wcf/behaviorextensions.md)|This section contains child elements that specify behavior extensions, which enable the user to customize service or endpoint behaviors.|  
|[\<bindingElementExtensions>](../../../../../docs/framework/configure-apps/file-schema/wcf/bindingelementextensions.md)|This section enables the use of a custom binding element from a machine or application configuration file.|  
|[\<bindingExtensions>](../../../../../docs/framework/configure-apps/file-schema/wcf/bindingextensions.md)|This section contains child elements that specify binding extensions, which enable the user to customize bindings.|  
|[\<endpointExtensions>](../../../../../docs/framework/configure-apps/file-schema/wcf/endpointextensions.md)|This section contains child elements that registers standard endpoints.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|system.ServiceModel|The root element of all WCF configuration elements.|
