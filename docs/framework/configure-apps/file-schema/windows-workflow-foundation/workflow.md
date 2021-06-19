---
description: "Learn more about: <workflow>"
title: "<workflow>"
ms.date: "03/30/2017"
ms.assetid: 560aa9b6-9cf3-460e-b798-f87d14b1d2de
---
# \<workflow>

A configuration element that contains all queries for a specific workflow identified by the <xref:System.ServiceModel.Activities.Tracking.Configuration.ProfileWorkflowElement.ActivityDefinitionId?displayProperty=nameWithType> property.  
  
 For more information in workflow tracking and its configuration, see [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md) and [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.ServiceModel>**](system-servicemodel-of-workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<tracking>**](tracking.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<trackingProfile>**](trackingprofile.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<workflow>**  
  
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
  
|Attribute|Description|  
|---------------|-----------------|  
|activityDefinitionId|A string that specifies the activity definition ID of the workflow being tracked.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<activityScheduledQueries>](activityscheduledqueries.md)|Represents a collection of queries that are used to track an activity scheduled for execution by a parent activity. The query is necessary for a tracking participant to subscribe to activity scheduled records.|  
|[\<activityStateQueries>](activitystatequeries.md)|Represents a collection of queries that are used to track life cycle changes of the activities that make up a workflow instance. For example, you may want to keep track of every time the "Send E-Mail" activity completes within a workflow instance. This query is necessary for a tracking participant to subscribe to activity state record objects. The available states to subscribe to are specified in ActivityStates.|  
|[\<bookmarkResumptionQueries>](bookmarkresumptionqueries.md)|Represents a collection of queries that are used to track resumption of a bookmark within a workflow instance. The query is necessary for a tracking participant to subscribe to bookmark resumption records.|  
|[\<cancelRequestedQueries>](cancelrequestedqueries.md)|Represents a collection of queries that are used to track requests to cancel a child activity by the parent activity. The query is necessary for a tracking participant to subscribe to cancel request record objects.|  
|[\<customTrackingQueries>](customtrackingqueries.md)|Represents a collection of queries that are used to track events that you define in your code activities. The query is necessary for a tracking participant to subscribe to custom tracking records.|  
|[\<faultPropagationQueries>](faultpropagationqueries.md)|Represents a collection of queries that are used to track the handling of faults that occur within an activity.  This event occurs each time a FaultHandler processes a fault. You should use such query to track the handling of faults that occur within an activity. The query is necessary for a  tracking participant to subscribe to fault propagation records.|  
|[\<workflowInstanceQueries>](workflowinstancequeries.md)|Represents a collection of configuration elements that track workflow instance life cycle changes such as a started or completed event.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<trackingProfile>](trackingprofile.md)|Represents a configuration section for creating a subscription to workflow tracking records in a tracking participant. A tracking profile contains tracking queries that permit a tracking participant to subscribe to workflow events that are emitted when the state of a workflow instance changes at runtime. The queries defined within the tracking profile section define the kinds of events that are returned by the subscription.|  
  
## Remarks  

 Tracking profiles contains tracking queries that permit a tracking participant to subscribe to workflow events that are emitted when the state of a particular workflow instance changes at runtime. The workflow instance being tracked is identified by this configuration element.  
  
 Depending on your monitoring requirements you may write a profile that is very coarse, which subscribes to a small set of high-level state changes on a workflow. Conversely, you may create a very specific profile whose resulting events are rich enough to reconstruct a detailed execution flow later.  
  
 Tracking profiles are structured as declarative subscriptions for tracking records that allow you to query the workflow runtime for specific tracking records. There are a handful of query types that allow you subscribe to different classes of tracking records. For a complete list of queries, see the child element list of this topic and [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md).  
  
 The following example shows a tracking profile in a configuration file that allows a tracking participant to subscribe to the `Started` and `Completed` workflow events.  
  
```xml  
<system.serviceModel>  
  <tracking>
    <trackingProfile name="Sample Tracking Profile">  
      <workflow activityDefinitionId="*">  
         <workflowInstanceQueries>  
            <workflowInstanceQuery>  
            <states>  
              <state name="Started"/>  
              <state name="Completed"/>  
            </states>  
          </workflowInstanceQuery>  
        </workflowInstanceQueries>  
      </workflow>  
    </trackingProfile>
   </profiles>  
  </tracking>  
</system.serviceModel>  
```  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.ProfileWorkflowElement>
- <xref:System.Activities.Tracking.TrackingProfile>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)
