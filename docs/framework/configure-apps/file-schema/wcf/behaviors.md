---
title: "&lt;behaviors&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0e5da4e6-1aa5-466c-924e-f10efee57f0b
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;behaviors&gt;
This element defines two child collections named `endpointBehaviors` and `serviceBehaviors`.  Each collection defines behavior elements consumed by endpoints and services respectively. Each behavior element is identified by its unique `name` attribute. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).  
  
 \<system.ServiceModel>  
  
## Syntax  
  
```xml  
<behaviors>  
   <serviceBehaviors>  
   </serviceBehaviors>  
   <endpointBehaviors>  
   </endpointBehaviors>  
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<endpointBehaviors>](../../../../../docs/framework/configure-apps/file-schema/wcf/endpointbehaviors.md)|This configuration section represents all the behaviors defined for a specific endpoint.|  
|[\<serviceBehaviors>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicebehaviors.md)|This configuration section represents all the behaviors defined for a specific service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<system.serviceModel>](../../../../../docs/framework/configure-apps/file-schema/wcf/system-servicemodel.md)|The root element of all Windows Communication Foundation (WCF) configuration elements.|  
  
## Remarks  
 You can use the `<remove>` element to remove a particular behavior from the collection. To do so, simply supply the name of the behavior to remove in the `name` attribute of the `<remove>` element.  You can also use the `<clear>` element to insure that a behavior collection starts empty by clearing out all the content of the collection.  
  
## See Also  
 <xref:System.ServiceModel.Configuration.BehaviorsSection>  
 <xref:System.ServiceModel.Configuration.EndpointBehaviorElementCollection>  
 <xref:System.ServiceModel.Configuration.EndpointBehaviorElement>  
 <xref:System.ServiceModel.Configuration.ServiceBehaviorElementCollection>  
 <xref:System.ServiceModel.Configuration.ServiceBehaviorElement>  
 [Configuring and Extending the Runtime with Behaviors](../../../../../docs/framework/wcf/extending/configuring-and-extending-the-runtime-with-behaviors.md)  
 [Configuring Client Behaviors](../../../../../docs/framework/wcf/configuring-client-behaviors.md)  
 [Specifying Client Run-Time Behavior](../../../../../docs/framework/wcf/specifying-client-run-time-behavior.md)  
 [Specifying Service Run-Time Behavior](../../../../../docs/framework/wcf/specifying-service-run-time-behavior.md)  
 [Security Behaviors](../../../../../docs/framework/wcf/feature-details/security-behaviors-in-wcf.md)
