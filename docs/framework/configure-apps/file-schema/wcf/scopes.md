---
title: "&lt;scopes&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9a0dd3ce-e383-4ac3-b7be-7d604388304a
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;scopes&gt;
Contains a collection of configuration elements that specify custom scope Uris that can be used to filter service endpoints during query.  
  
\<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<endpointDiscovery>  
\<scopes>  
  
## Syntax  
  
```xml  
<behaviors>
  <endpointBehaviors>
    <behavior name="String">
      <endpointDiscovery enable="Boolean">
        <scopes>
          <add scope="URI" />
        </scopes>
      </endpointDiscovery>
    </behavior>
  </endpointBehaviors>
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Attribute|Description|  
|---------------|-----------------|  
|[\<add>](../../../../../docs/framework/configure-apps/file-schema/wcf/add-of-scopes.md)|Adds the scope information for the endpoint that can be used in matching criteria for finding services.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<endpointDiscovery>](../../../../../docs/framework/configure-apps/file-schema/wcf/endpointdiscovery.md)|Specifies the various discovery settings for an endpoint, such as its discoverability, scopes, and any custom extensions to its metadata.|  
  
## See Also  
 <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior>
