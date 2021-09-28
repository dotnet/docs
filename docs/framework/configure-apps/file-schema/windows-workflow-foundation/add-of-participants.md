---
description: "Learn more about: <add> of <participants>"
title: "<add> of <participants>"
ms.date: "03/30/2017"
ms.assetid: 3c730850-6f8e-4102-acb8-8effb4e09463
---
# \<add> of \<participants>

Configure a tracking participant that listens to the tracking records being emitted from the runtime directly and process them in whatever way it was configured. This includes writing to a specific output (e.g., file, Console, ETW), processing/aggregating the records, or any other combination that might be required.  
  
 For more information in workflow tracking and tracking participants, see [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md) and [Tracking Participants](../../../windows-workflow-foundation/tracking-participants.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.ServiceModel>**](system-servicemodel-of-workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<tracking>**](tracking.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<participants>**](participants.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<add>**  
  
## Syntax  
  
```xml
<tracking>
  <participants>
    <add name="String" profileName="String" type="String" />
  </participants>
</tracking>
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Element|Description|  
|-------------|-----------------|  
|name|A string that specifies the name of a tracking participant.|  
|profileName|A string that specifies the name of the tracking profile which defines the tracking records the tracking participant has subscribed to.|  
|type|A string that specifies the type of a tracking participant.|  
  
### Child Elements  

 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<participants>](participants.md)|A list of tracking participants|  
  
## Remarks  

 Tracking participants are used to get the tracking data emitted from the workflow and store it into different mediums. Likewise, any post processing on the tracking Records can also be done within the tracking participant.  
  
 Multiple tracking participants can consume the tracking events simultaneously. Each tracking participant can be associated with a different tracking profile.  
  
 A standard tracking participant is provided which writes the tracking records to an ETW session. The participant is configured on a workflow service by adding a tracking-specific behavior in a configuration file. Enabling an ETW tracking participant allows tracking records to be viewed in the event viewer. If that does not meet your requirements, you can also write a custom tracking participant.  
  
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
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.TrackingSection>
- <xref:System.ServiceModel.Activities.Description.EtwTrackingBehavior>
- <xref:System.ServiceModel.Activities.Configuration.EtwTrackingBehaviorElement>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Participants](../../../windows-workflow-foundation/tracking-participants.md)
