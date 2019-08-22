---
title: "<behavior> of <endpointBehaviors>"
ms.date: "03/30/2017"
ms.assetid: b90ca3bc-3c22-4174-b903-e3a39898bd27
---
# \<behavior> of \<endpointBehaviors>
The `behavior` element contains a collection of settings for the behavior of an endpoint. Each behavior is indexed by its `name`. Endpoints can link to each behavior through this name. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../wcf/samples/simplified-configuration-for-wcf-services.md).  
  
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
|name|A unique string that contains the configuration name of the behavior. This value is a user-defined string that must be unique, since it acts as the identification string for the element. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../wcf/samples/simplified-configuration-for-wcf-services.md).|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<clientCredentials>](clientcredentials.md)|Specifies the credentials used to authenticate the client to a service.|  
|[\<callbackDebug>](callbackdebug.md)|Specifies service debugging for a Windows Communication Foundation (WCF) callback object.|  
|[\<callbackTimeouts>](callbacktimeouts.md)|Specifies the timeout for the client callback.|  
|[\<clientVia>](clientvia.md)|Specifies the route a message should take.|  
|[\<dataContractSerializer>](datacontractserializer.md)|Contains configuration data for the DataContractSerializer.|  
|[\<dispatcherSynchronization>](dispatchersynchronization.md)|Specifies an endpoint behavior that enables a service to send replies asynchronously.|  
|[\<enableWebScript>](enablewebscript.md)|Enables the endpoint behavior that makes it possible to consume the service from ASP.NET AJAX web pages. The behavior should only be used in conjunction with either the \<webHttpBinding> standard binding, or the \<webMessageEncoding> binding element.|  
|[\<endpointDiscovery>](endpointdiscovery.md)|Specifies the various discovery settings for an endpoint, such as its discoverability, scopes, and any custom extensions to its metadata.|  
|[\<soapProcessing>](soapprocessing.md)|Defines the client endpoint behavior used to marshal messages between different binding types and message versions.|  
|[\<synchronousReceive>](synchronousreceive-element.md)|Specifies run-time behavior for receiving messages in either a service or client application. It does not have any attributes or child elements.|  
|[\<transactedBatching>](transactedbatching.md)|Specifies whether transaction batching is supported for receive operations.|  
|[\<webHttp>](webhttp.md)|Specifies the WebHttpBehavior on an endpoint through configuration. This behavior, when used in conjunction with the \<webHttpBinding> standard binding, enables the Web programming model for a WCF service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<endpointBehaviors>](endpointbehaviors.md)|A collection of endpoint behavior elements.|
