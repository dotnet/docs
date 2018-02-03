---
title: "&lt;etwTracking&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: cb45c82e-6ea1-4c4d-924c-118a25ae1f35
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;etwTracking&gt;
A service behavior that allows a service to utilize ETW tracking using an <xref:System.Activities.Tracking.EtwTrackingParticipant>.  
  
\<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<etwTracking>  
  
## Syntax  
  
```xml  
<behaviors>
  <serviceBehaviors>
    <behavior name="String">
      <etwTracking profileName="String" />
    </behavior>
  </serviceBehaviors>
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|profileName|A string that specifies the name of the tracking profile associated with this behavior.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior> of \<serviceBehaviors>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/behavior-of-servicebehaviors-of-workflow.md)|Specifies a behavior element.|  
  
## Remarks  
 When added to the service’s behavior configuration, this configuration element configures a tracking participant on a workflow service.  
  
 Tracking participants are used to get the tracking data emitted from the workflow and store it into different mediums. Likewise, any post processing on the tracking Records can also be done within the tracking participant.  
  
## Example  
 The following configuration example shows the standard ETW tracking participant being configured in the Web.config file.  
  
 The Provider Id that the ETW Tracking Participant uses for writing the Tracking Records to ETW is defined in the **\<diagnostics>** section. The tracking participant has a profile associated with it to specify the tracking records it has subscribed to. This is defined by the **profileName** attribute of the **\<add>** element. Once these are defined, the Tracking Participant is added to the **\<etwTracking>** service behavior. This will add the selected Tracking Participants to the Workflow instance’s extensions, so that they begin to receive the Tracking Records.  
  
```xml  
<configuration>   
  <system.web>   
    <compilation targetFrameworkMoniker=".NETFramework,Version=v4.0"/>   
  </system.web>   
  <system.serviceModel>   
    <diagnostics etwProviderId="52A3165D-4AD9-405C-B1E8-7D9A257EAC9F" />                
    <tracking>   
      <participants>   
        <add name="EtwTrackingParticipant"   
             type="System.Activities.Tracking.EtwTrackingParticipant, System.Activities, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"   
             profileName="HealthMonitoring_Tracking_Profile"/>   
      </participants>   
    </tracking>   
    <behaviors>   
      <serviceBehaviors>   
        <behavior>   
          <etwTracking profileName="Sample Tracking Profile"/>  
        </behavior>   
      </serviceBehaviors>   
    </behaviors>   
  </system.serviceModel>   
</configuration>  
```  
  
## See Also  
 <xref:System.ServiceModel.Activities.Description.EtwTrackingBehavior>  
 <xref:System.ServiceModel.Activities.Configuration.EtwTrackingBehaviorElement>  
 [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)  
 [Tracking Participants](../../../../../docs/framework/windows-workflow-foundation/tracking-participants.md)
