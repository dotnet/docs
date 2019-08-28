---
title: "<activityScheduledQueries>"
ms.date: "03/30/2017"
ms.topic: "reference"
ms.assetid: ca6e82f1-54f2-48d6-899c-9873065b5547
---
# \<activityScheduledQueries>
Represents a collection of queries that are used to track an activity scheduled for execution by a parent activity. The query is necessary for a tracking participant to subscribe to activity scheduled records.  
  
 For more information on tracking profile queries, see [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)  
  
\<system.serviceModel>  
\<tracking>  
\<trackingProfile>  
\<workflow>  
\<activityScheduledQueries>  
  
## Syntax  
  
```xml  
<tracking>
  <trackingProfile name="Name">
    <workflow>
      <activityScheduledQueries>
        <activityScheduledQuery activityName="String" 
                                childActivityName="String" />
      </activityScheduledQueries>
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
|[\<activityScheduledQuery>](activityscheduledquery.md)|A query that is used to track an activity scheduled for execution by a parent activity.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<workflow>](workflow.md)|A configuration element that contains all queries for a specific workflow identified by the **activityDefinitionId** property.|  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.ActivityScheduledQueryElementCollection?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.ActivityScheduledQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)
