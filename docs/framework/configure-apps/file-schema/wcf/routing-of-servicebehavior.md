---
title: "&lt;routing&gt; of &lt;serviceBehavior&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d8f9c844-4629-4a45-9599-856dc8f01794
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;routing&gt; of &lt;serviceBehavior&gt;
Provides run-time access to the routing service to allow dynamic modification of the routing configuration.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<routing>  
  
## Syntax  
  
```xml  
<behaviors>
  <serviceBehaviors>
    <behavior name="String">
      <routing filterTable="String" 
               routeOnHeadersOnly="Boolean" 
               SoapProcessingEnabled="Boolean" />
    </behavior>
  </serviceBehaviors>
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|filterTable|A string that specifies the name of the routing table that contains filters to be evaluated by the routing service. This value must match the `name` attribute of a [\<filterTable>](../../../../../docs/framework/configure-apps/file-schema/wcf/filtertable.md) element in the [\<filterTables>](../../../../../docs/framework/configure-apps/file-schema/wcf/filtertables.md) section.|  
|routeOnHeaderOnly|A Boolean value that specifies whether the filter will examine both the message body and the header, or the header only. The default is `true`.|  
|soapProcessingEnabled|A Boolean value that specifies whether SOAP processing should occur.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](../../../../../docs/framework/configure-apps/file-schema/wcf/behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## Remarks  
 When added to the service’s behavior configuration, this configuration element enables routing for the service. You can specify the actual routing table to be used by the service in this element.  
  
 Using this configuration section, you can change your routing settings on the fly when your deployment pattern changes. At runtime, you can register your own routing extension with new routing settings and the routing service will begin using the updated configuration information for new messages and sessions, while leaving in-flight messages/sessions using whatever rules were in place when they started.  This gives you the ability to do session-safe, recycle-less reconfiguration of the Routing Service during runtime.  
  
