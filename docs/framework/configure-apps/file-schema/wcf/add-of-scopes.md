---
title: "&lt;add&gt; of &lt;scopes&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0563a7d8-fc84-4c85-9066-af32665857c2
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;add&gt; of &lt;scopes&gt;
Adds a custom scope Uri that can be used to filter service endpoints during query.  
  
\<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
\<endpointDiscovery>  
\<scopes>  
\<add>  
  
## Syntax  
  
```xml  
<behaviors>
  <endpointBehaviors>
    <behavior name="String">
      <endpointDiscovery enable="Boolean">
        <scopes>
          <add scope="URI"/>
        </scopes>
      </endpointDiscovery>
    </behavior>
  </endpointBehaviors>
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|scope|A URI that contains scope information for the endpoint that can be used in matching criteria for finding services.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<scopes>](../../../../../docs/framework/configure-apps/file-schema/wcf/scopes.md)|Contains a collection of configuration elements that specify custom scope Uris that can be used to filter service endpoints during query.|  
  
## See Also  
 <xref:System.ServiceModel.Discovery.EndpointDiscoveryBehavior>
