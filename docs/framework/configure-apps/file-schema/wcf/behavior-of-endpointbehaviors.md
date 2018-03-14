---
title: "&lt;behavior&gt; of &lt;endpointBehaviors&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b90ca3bc-3c22-4174-b903-e3a39898bd27
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;behavior&gt; of &lt;endpointBehaviors&gt;
The `behavior` element contains a collection of settings for the behavior of an endpoint. Each behavior is indexed by its `name`. Endpoints can link to each behavior through this name. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../../../docs/framework/wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../../../docs/framework/wcf/samples/simplified-configuration-for-wcf-services.md).  
  
 \<system.ServiceModel>  
\<behaviors>  
\<endpointBehaviors>  
\<behavior>  
  
## Syntax  
  
```xml  
<system.ServiceModel>  
  <behaviors>  
    <endpointBehaviors>  
       <behavior name="String" />  
    </endpointBehaviors>  
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
|[\<clientCredentials>](../../../../../docs/framework/configure-apps/file-schema/wcf/clientcredentials.md)|Specifies the credentials used to authenticate the client to a service.|  
|[\<callbackDebug>](../../../../../docs/framework/configure-apps/file-schema/wcf/callbackdebug.md)|Specifies service debugging for a [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] callback object.|  
|[\<callbackTimeouts>](../../../../../docs/framework/configure-apps/file-schema/wcf/callbacktimeouts.md)|Specifies the timeout for the client callback.|  
|[\<clientVia>](../../../../../docs/framework/configure-apps/file-schema/wcf/clientvia.md)|Specifies the route a message should take.|  
|[\<dataContractSerializer>](../../../../../docs/framework/configure-apps/file-schema/wcf/datacontractserializer.md)|Contains configuration data for the DataContractSerializer.|  
|[\<dispatcherSynchronization>](../../../../../docs/framework/configure-apps/file-schema/wcf/dispatchersynchronization.md)|Specifies an endpoint behavior that enables a service to send replies asynchronously.|  
|[\<enableWebScript>](../../../../../docs/framework/configure-apps/file-schema/wcf/enablewebscript.md)|Enables the endpoint behavior that makes it possible to consume the service from ASP.NET AJAX web pages. The behavior should only be used in conjunction with either the \<webHttpBinding> standard binding, or the \<webMessageEncoding> binding element.|  
|[\<endpointDiscovery>](../../../../../docs/framework/configure-apps/file-schema/wcf/endpointdiscovery.md)|Specifies the various discovery settings for an endpoint, such as its discoverability, scopes, and any custom extensions to its metadata.|  
|[\<soapProcessing>](../../../../../docs/framework/configure-apps/file-schema/wcf/soapprocessing.md)|Defines the client endpoint behavior used to marshal messages between different binding types and message versions.|  
|[\<synchronousReceive>](../../../../../docs/framework/configure-apps/file-schema/wcf/synchronousreceive-element.md)|Specifies run-time behavior for receiving messages in either a service or client application. It does not have any attributes or child elements.|  
|[\<transactedBatching>](../../../../../docs/framework/configure-apps/file-schema/wcf/transactedbatching.md)|Specifies whether transaction batching is supported for receive operations.|  
|[\<webHttp>](../../../../../docs/framework/configure-apps/file-schema/wcf/webhttp.md)|Specifies the WebHttpBehavior on an endpoint through configuration. This behavior, when used in conjunction with the \<webHttpBinding> standard binding, enables the Web programming model for a [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<endpointBehaviors>](../../../../../docs/framework/configure-apps/file-schema/wcf/endpointbehaviors.md)|A collection of endpoint behavior elements.|
