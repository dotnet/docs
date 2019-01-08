---
title: "&lt;activityStateQueries&gt; of WCF"
ms.date: "10/08/2018"
ms.assetid: 9e45db49-ed85-4fdf-bd65-0d5477e31823
---
# &lt;activityStateQueries&gt; of WCF

Represents a collection of queries that are used to track life cycle changes of the activities that make up a workflow instance. For example, you may want to keep track of every time the "Send E-Mail" activity completes within a workflow instance. This query is necessary for a tracking participant to subscribe to activity state record objects. The available states to subscribe to are specified in ActivityStates.

For more information on tracking profile queries, see [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md).

\<system.serviceModel>  
\<tracking>  
\<profiles>  
\<trackingProfile>  
\<workflow>  
\<activityStateQueries>  

## Syntax  
  
```xml  
<tracking>
  <profiles>
    <trackingProfile name="Name">
      <workflow>
        <activityStateQueries>
          <activityStateQuery activityName="String">
            <arguments>
              <argument name="String" />
            </arguments>
            <states>
              <state name="String" />
            </states>
            <variables>
              <variable name="String" />
            </variables>
          </activityStateQuery>
        </activityStateQueries>
      </workflow>
    </trackingProfile>
  </profiles>
</tracking>
```  

## Attributes and elements

The following sections describe attributes, child elements, and parent elements.
  
### Attributes  

None.  

### Child elements

|Element|Description|
|-------------|-----------------|
|[\<activityStateQuery>](activitystatequery-of-wcf.md)|A query that is used to track the handling of faults that occur within an activity.  This event occurs each time a FaultHandler processes a fault.|

### Parent elements

|Element|Description|
|-------------|-----------------|
|[\<workflow>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/workflow.md)|A configuration element that contains all queries for a specific workflow identified by the `activityDefinitionId` property.|

## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.ActivityStateQueryElementCollection>    
- <xref:System.Activities.Tracking.ActivityStateQuery>    
- [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)  
- [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)
