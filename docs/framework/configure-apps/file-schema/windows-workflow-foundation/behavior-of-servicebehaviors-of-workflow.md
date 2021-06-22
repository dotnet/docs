---
description: "Learn more about: <behavior> of <serviceBehaviors> of workflow"
title: "<behavior> of <serviceBehaviors> of workflow"
ms.date: "03/30/2017"
ms.assetid: 6a4b718a-1b40-4957-935a-f6122819ab3c
---
# \<behavior> of \<serviceBehaviors> of workflow

The **behavior** element contains a collection of settings for the behavior of a service. Each behavior is indexed by its **name**. Services can link to each behavior through this name using the **behaviorConfiguration** attribute of the [\<endpoint>](../wcf/endpoint-element.md) element. This allows endpoints to share common behavior configurations without redefining the settings.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.ServiceModel>**](system-servicemodel-of-workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors-of-workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors-of-workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<behavior>**  
  
## Syntax  
  
```xml  
<system.ServiceModel>  
  <behaviors>  
    <serviceBehaviors>  
      <behavior name="String">
        <bufferReceive maxPendingMessagesPerChannel="Integer" />
        <etwTracking profileName="String" />
        <sendMessageChannelCache allowUnsafeCaching="Boolean">
          <channelSettings idleTimeout="TimeSpan"
                           leaseTimeout="TimeSpan"
                           maxItemsInCache="Integer" />
          <factorySettings idleTimeout="TimeSpan"
                           leaseTimeout="TimeSpan"
                           maxItemsInCache="Integer" />
        </sendMessageChannelCache>
        <sqlWorkflowInstanceStore connectionStringName="String"
                                  hostLockRenewalPeriod="TimeSpan"
                                  instanceCompletionAction="DeleteNothing/DeleteAll"
                                  instanceEncodingAction="None/GZip"
                                  instanceLockedExceptionAction="NoRetry/BasicRetry/AggressiveRetry"
                                  runnableInstancesDetectionPeriod="TimeSpan" />
        <workflowIdle timeToPersist="TimeSpan"
                      timeToUnload="TimeSpan" />
        <workflowUnhandledException action="Abandon/AbandonAndSuspend/Cancel/Terminate" />
      </behavior>
    </serviceBehaviors>  
  </behaviors>  
</system.ServiceModel>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|name|A unique string that contains the configuration name of the behavior. This value is a user-defined string that must be unique, since it acts as the identification string for the element.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<bufferReceive>](bufferreceive.md)|A service behavior that enables a service to use buffered receive processing, which enables a workflow service to process out-of-order messages.|  
|[\<routing>](../wcf/routing-of-servicebehavior.md)|A service behavior that allows a service to utilize ETW tracking using an <xref:System.Activities.Tracking.EtwTrackingParticipant>.|  
|[\<sendMessageChannelCache>](sendmessagechannelcache.md)|A service behavior that enables the customization of the cache sharing levels, the settings of the channel factory cache, and the settings of the channel cache for workflows that send messages to service endpoints using Send messaging activities.|  
|[\<sqlWorkflowInstanceStore>](sqlworkflowinstancestore.md)|A service behavior that allows you to configure the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> feature, which supports persisting state information for workflow service instances into an SQL Server 2005 or SQL Server 2008 database.|  
|[\<workflowIdle>](workflowidle.md)|A service behavior that controls when idle workflow instances are unloaded and persisted.|  
|[\<workflowInstanceManagement>](workflowinstancemanagement.md)|A service behavior that enables you to specify settings that control how workflow instances are run, including persistence, unhandled Exception behavior and idle behavior.|  
|[\<workflowUnhandledException>](workflowunhandledexception.md)|A service behavior that enables you to specify the action to take when an unhandled exception occurs within a workflow service.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<serviceBehaviors>](servicebehaviors-of-workflow.md)|A collection of service behavior elements.|
