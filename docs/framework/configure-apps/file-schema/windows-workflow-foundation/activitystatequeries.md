---
description: "Learn more about: <activityStateQueries>"
title: "<activityStateQueries>"
ms.date: "03/30/2017"
ms.assetid: bdd3c8ae-a13f-4df1-9b3c-a9d6c4bb1b5f
---
# \<activityStateQueries>

Represents a collection of queries that are used to track life cycle changes of the activities that make up a workflow instance. For example, you may want to keep track of every time the "Send E-Mail" activity completes within a workflow instance. This query is necessary for a tracking participant to subscribe to activity state record objects. The available states to subscribe to are specified in ActivityStates.  
  
 For more information on tracking profile queries, see [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md).  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.ServiceModel>**](system-servicemodel-of-workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<tracking>**](tracking.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<trackingProfile>**](trackingprofile.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<workflow>**](workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<activityStateQueries>**  
  
## Syntax  
  
```xml
<tracking>
  <trackingProfile name="Name">
    <workflow>
      <activityStateQueries>
        <activityStateQuery activityName="String" />
        <arguments>
          <argument name="String" />
        </arguments>
        <states>
          <state name="String" />
        </states>
        <variables>
         <variable name="String" />
        </variables>
      </activityStateQueries>
    </workflow>
  </trackingProfile>
</tracking>  
```  
  
## Attributes and Elements  

 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  

 None.  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<activityStateQuery>](activitystatequery.md)|A query that is used to track the handling of faults that occur within an activity.  This event occurs each time a FaultHandler processes a fault.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<workflow>](workflow.md)|A configuration element that contains all queries for a specific workflow identified by the **activityDefinitionId** property.|  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.ActivityStateQueryElementCollection?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.ActivityStateQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)
