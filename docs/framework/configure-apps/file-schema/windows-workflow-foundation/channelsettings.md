---
title: "&lt;channelSettings&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 94a4457f-f43f-458d-a47e-2d11103ee75e
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;channelSettings&gt;
Specifies the settings of the channel cache.  
  
\<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<sendMessageChannelCache>  
\<channelSettings>  
  
## Syntax  
  
```xml  
<behaviors>
  <serviceBehaviors>
    <behavior name="String">
      <sendMessageChannelCache allowUnsafeCaching="Boolean">
        <channelSettings idleTimeout="TimeSpan" 
                         leaseTimeout="TimeSpan" 
                         maxItemsInCache="Integer" />
      </sendMessageChannelCache>
    </behavior>
  </serviceBehaviors>
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|idleTimeout|A TimeSpan value that specifies the maximum interval of time for which the object can remain idle in the cache before being disposed.|  
|leaseTimeout|A TimeSpan value that specifies  the interval of time after which an object is removed from the cache.|  
|maxItemsInCache|An integer that specifies the maximum number of objects that can be in the cache.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<sendMessageChannelCache>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/sendmessagechannelcache.md)|A service behavior that enables the customization of the cache sharing levels, the settings of the channel factory cache, and the settings of the channel cache for workflows that send messages to service endpoints using Send messaging activities.|  
  
## Remarks  
 This service behavior is intended for workflows that send messages to service endpoints. These workflows are typically client workflows but could also be workflow services that are hosted in a <xref:System.ServiceModel.WorkflowServiceHost>.  
  
 By default, in a workflow hosted by a <xref:System.ServiceModel.WorkflowServiceHost>, the cache used by <xref:System.ServiceModel.Activities.Send> messaging activities is shared across all workflow instances in the <xref:System.ServiceModel.WorkflowServiceHost> (host-level caching). For a client workflow that is not hosted by a <xref:System.ServiceModel.WorkflowServiceHost>, the cache is available only to the workflow instance (instance-level caching). Caching is disabled by default for any send activity in your workflow that has endpoints defined in configuration.  
  
 [!INCLUDE[crabout](../../../../../includes/crabout-md.md)] how to change the default cache sharing levels and cache settings for the channel factory and channel cache, see [Changing the Cache Sharing Levels for Send Activities](../../../../../docs/framework/wcf/feature-details/changing-the-cache-sharing-levels-for-send-activities.md).  
  
## Example  
 In a hosted workflow service, you can specify the factory cache and channel cache settings in the application configuration file. To do so, add a service behavior that contains the cache settings for the factory and channel cache and add this service behavior to your service. The following example shows the contents of a configuration file that contains the **MyChannelCacheBehavior**  service behavior with the custom factory cache and channel cache settings. This service behavior is added to the service through the **behaviorConfiguarion** attribute.  
  
```xml  
<configuration>    
  <system.serviceModel>  
    <!-- List of other config sections here -->   
    <behaviors>  
      <serviceBehaviors>  
        <behavior name="MyChannelCacheBehavior">  
          <sendMessageChannelCache allowUnsafeCaching ="false" >  
            <!-- Control only the host level settings -->   
            <factorySettings maxItemsInCache = "8" idleTimeout = "00:05:00" leaseTimeout="10:00:00" />  
            <channelSettings maxItemsInCache = "32" idleTimeout = "00:05:00" leaseTimeout="00:06:00" />  
          </sendMessageChannelCache>  
        </behavior>  
      </serviceBehaviors>  
    </behaviors>  
    <services>  
      <service name="MyService" behaviorConfiguration="MyChannelCacheBehavior" />  
    </services>  
  </system.serviceModel>  
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.Activities.SendMessageChannelCache>  
 <xref:System.ServiceModel.Activities.Configuration.SendMessageChannelCacheElement>  
 <xref:System.ServiceModel.Activities.Send>  
 <xref:System.ServiceModel.Activities.ChannelCacheSettings>  
 [Changing the Cache Sharing Levels for Send Activities](../../../../../docs/framework/wcf/feature-details/changing-the-cache-sharing-levels-for-send-activities.md)
