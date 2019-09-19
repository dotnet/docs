---
title: "<behavior> of <serviceBehaviors>"
ms.date: "03/30/2017"
ms.assetid: 78fc0a08-55de-416a-ac12-a5e6ffc9a987
---
# \<behavior> of \<serviceBehaviors>
The `behavior` element contains a collection of settings for the behavior of a service. Each behavior is indexed by its `name`. Services can link to each behavior through this name using the `behaviorConfiguration` attribute of the [\<endpoint>](endpoint-element.md) element. This allows endpoints to share common behavior configurations without redefining the settings. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../wcf/samples/simplified-configuration-for-wcf-services.md).  
  
> [!NOTE]
> Behavior elements specific to Windows Workflow activities, such as the [\<sendMessageChannelCache>](../windows-workflow-foundation/sendmessagechannelcache.md) element, are documented in the [\<behavior> of \<serviceBehaviors>](../windows-workflow-foundation/behavior-of-servicebehaviors-of-workflow.md) page.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<behavior>**  
  
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
|name|A unique string that contains the configuration name of the behavior. This value is a user-defined string that must be unique, since it acts as the identification string for the element. Starting with [!INCLUDE[netfx40_short](../../../../../includes/netfx40-short-md.md)], bindings and behaviors are not required to have a name. For more information about default configuration and nameless bindings and behaviors, see [Simplified Configuration](../../../wcf/simplified-configuration.md) and [Simplified Configuration for WCF Services](../../../wcf/samples/simplified-configuration-for-wcf-services.md).|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<dataContractSerializer>](datacontractserializer-element.md)|Contains configuration data for the DataContractSerializer.|  
|[\<persistenceProvider>](persistenceprovider.md)|Specifies the type of the persistence provider implementation to use, as well as the time-out to use for persistence operations.|  
|[\<routing>](routing-of-servicebehavior.md)|Provides run-time access to the routing service to allow dynamic modification of the routing configuration.|  
|[\<serviceAuthenticationManager>](serviceauthenticationmanager.md)|Provides a workflow configuration element that establishes at the service level the validity of a transmission, message, or originator..|  
|[\<serviceAuthorization>](serviceauthorization-element.md)|Specifies settings that authorize access to service operations.|  
|[\<serviceCredentials>](servicecredentials.md)|Specifies the credential to be used in authenticating the service and the client credential validation-related settings.|  
|[\<serviceDebug>](servicedebug.md)|Specifies debugging and help information features for a Windows Communication Foundation (WCF) service.|  
|[\<serviceDiscovery>](servicediscovery.md)|Specifies the discoverability of service endpoints.|  
|[\<serviceMetadata>](servicemetadata.md)|Specifies the publication of service metadata and associated information.|  
|[\<serviceSecurityAudit>](servicesecurityaudit.md)|Specifies settings that enable auditing of security events during service operations.|  
|[\<serviceThrottling>](servicethrottling.md)|Specifies the throttling mechanism of a WCF service.|  
|[\<serviceTimeouts>](servicetimeouts.md)|Specifies the timeout for a service.|  
|[\<workflowRuntime>](workflowruntime.md)|Specifies settings for an instance of WorkflowRuntime for hosting workflow-based WCF services.|  
|[\<useRequestHeadersForMetadataAddress>](userequestheadersformetadataaddress.md)|Enables the retrieval of metadata address information from the request message headers.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceBehaviors>](servicebehaviors.md)|A collection of service behavior elements.|
