---
title: "&lt;behavior&gt; of &lt;serviceBehaviors&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 78fc0a08-55de-416a-ac12-a5e6ffc9a987
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;behavior&gt; of &lt;serviceBehaviors&gt;
The `behavior` element contains a collection of settings for the behavior of a service. Each behavior is indexed by its `name`. Services can link to each behavior through this name using the `behaviorConfiguration` attribute of the [\<endpoint>](../../../../../docs/framework/configure-apps/file-schema/wcf/endpoint-element.md) element. This allows endpoints to share common behavior configurations without redefining the settings. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).  
  
> [!NOTE]
>  Behavior elements specific to Windows Workflow activities, such as the [\<sendMessageChannelCache>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/sendmessagechannelcache.md) element, are documented in the [\<behavior> of \<serviceBehaviors>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/behavior-of-servicebehaviors-of-workflow.md) page.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
  
## Syntax  
  
```xml  
<system.ServiceModel>  
  <behaviors>  
    <serviceBehaviors>  
       <behavior name="String" />  
    </serviceBehaviors>  
  </behaviors>  
</system.ServiceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|name|A unique string that contains the configuration name of the behavior. This value is a user-defined string that must be unique, since it acts as the identification string for the element. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<dataContractSerializer>](../../../../../docs/framework/configure-apps/file-schema/wcf/datacontractserializer-element.md)|Contains configuration data for the DataContractSerializer.|  
|[\<persistenceProvider>](../../../../../docs/framework/configure-apps/file-schema/wcf/persistenceprovider.md)|Specifies the type of the persistence provider implementation to use, as well as the time-out to use for persistence operations.|  
|[\<routing>](../../../../../docs/framework/configure-apps/file-schema/wcf/routing-of-servicebehavior.md)|Provides run-time access to the routing service to allow dynamic modification of the routing configuration.|  
|[\<serviceAuthenticationManager>](../../../../../docs/framework/configure-apps/file-schema/wcf/serviceauthenticationmanager.md)|Provides a workflow configuration element that establishes at the service level the validity of a transmission, message, or originator..|  
|[\<serviceAuthorization>](../../../../../docs/framework/configure-apps/file-schema/wcf/serviceauthorization-element.md)|Specifies settings that authorize access to service operations.|  
|[\<serviceCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicecredentials.md)|Specifies the credential to be used in authenticating the service and the client credential validation-related settings.|  
|[\<serviceDebug>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicedebug.md)|Specifies debugging and help information features for a [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] service.|  
|[\<serviceDiscovery>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicediscovery.md)|Specifies the discoverability of service endpoints.|  
|[\<serviceMetadata>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicemetadata.md)|Specifies the publication of service metadata and associated information.|  
|[\<serviceSecurityAudit>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicesecurityaudit.md)|Specifies settings that enable auditing of security events during service operations.|  
|[\<serviceThrottling>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicethrottling.md)|Specifies the throttling mechanism of a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] service.|  
|[\<serviceTimeouts>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicetimeouts.md)|Specifies the timeout for a service.|  
|[\<workflowRuntime>](../../../../../docs/framework/configure-apps/file-schema/wcf/workflowruntime.md)|Specifies settings for an instance of WorkflowRuntime for hosting workflow-based [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] services.|  
|[\<useRequestHeadersForMetadataAddress>](../../../../../docs/framework/configure-apps/file-schema/wcf/userequestheadersformetadataaddress.md)|Enables the retrieval of metadata address information from the request message headers.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceBehaviors>](../../../../../docs/framework/configure-apps/file-schema/wcf/servicebehaviors.md)|A collection of service behavior elements.|
