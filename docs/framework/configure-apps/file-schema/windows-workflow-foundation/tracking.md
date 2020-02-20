---
title: "<tracking>"
ms.date: "03/30/2017"
ms.topic: "reference"
ms.assetid: fd9b50ed-98a1-4518-836d-e4e02c670822
---
# \<tracking>
Represents a configuration section for defining tracking settings for a workflow service.  
  
 For more information in workflow tracking and its configuration, see [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md) and [Configuring Tracking for a Workflow](../../../windows-workflow-foundation/configuring-tracking-for-a-workflow.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.ServiceModel>**](system-servicemodel-of-workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;**\<tracking>**  
  
## Syntax  
  
```xml  
<system.serviceModel>
  <tracking>
    <profiles>
      <participants>
        <add name="String" 
             profileName="String" 
             type="String" />
      </participants>
      <trackingProfile name="String">
        <workflow activityDefinitionId="String">
          <activityScheduledQueries>
            <activityScheduledQuery activityName="String" 
                                    childActivityName="String"/>
          </activityScheduledQueries>
          <activityStateQueries>
            <activityStateQuery activityName="String" />
            <arguments>
              <argument name="String" />
            </arguments>
            <states>
              <state name="String"  />
            </states>
            <variables>
              <variable name="String" />
            </variables>
          </activityStateQueries>
          <bookmarkResumptionQueries>
            <bookmarkResumptionQuery name="String" />
          </bookmarkResumptionQueries>
          <cancelRequestQueries>
            <cancelRequestQuery activityName="String" 
                                childActivityName="String"/>
          </cancelRequestQueries>
          <customTrackingQueries>
            <customTrackingQuery activityName="String" 
                                 name="String"/>
          </customTrackingQueries>
          <faultPropagationQueries>
            <faultPropagationQuery activityName="String" 
                                   faultHandlerActivityName="String" />
          </faultPropagationQueries>
          <workflowInstanceQueries>
            <workflowInstanceQuery>
              <states>
                <state name="String" />
              </states>
            </workflowInstanceQuery>
          </workflowInstanceQueries>
        </workflow>
      </trackingProfile>
    </profiles>
  </tracking>
</system.serviceModel>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<participants>](participants.md)|A collection of configuration elements defining participants that subscribe to tracking records. The tracking participants contain the logic to process the payload from the tracking records (for example, they could choose to write to a file).|  
|[\<trackingProfile>](trackingprofile.md)|A tracking profile to filter tracking records emitted from a workflow instance.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|system.ServiceModel|The root element of all workflow configuration elements.|  
  
## Remarks  
 Tracking provides you with the ability to examine the execution of a workflow. The workflow tracking infrastructure instruments a workflow to emit records reflecting key events during the execution. For example, when a workflow instance starts or completes tracking records are emitted. Tracking can also extract business relevant data associated with the workflow variables. For example, if the workflow represents an order processing system the order id can be extracted along with the tracking record. In general, enabling WF tracking facilitates diagnostics or business analytics over a workflow execution.  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.TrackingSection?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
