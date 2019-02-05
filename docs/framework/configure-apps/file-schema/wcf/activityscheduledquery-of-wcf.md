---
title: "<activityScheduledQuery> of WCF"
ms.date: "03/30/2017"
ms.assetid: 25f6eee1-3d98-4c39-b517-c0813f03f106
---
# \<activityScheduledQuery> of WCF

Represents a collection of queries that are used to track an activity scheduled for execution by a parent activity. The query is necessary for a tracking participant to subscribe to activity scheduled records.  
  
For more information on tracking profile queries, see [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)  
  
\<system.serviceModel>  
\<tracking>  
\<profiles>  
\<trackingProfile>  
\<workflow>  
\<activityScheduledQueries>  
\<activityScheduledQuery>  
  
## Syntax  
  
```xml  
<tracking>
  <profiles>
    <trackingProfile name="Name">
      <workflow>
        <activityScheduledQueries>
          <activityScheduledQuery activityName="String"
                                  childActivityName="String" />
        </activityScheduledQueries>
      </workflow>
    </trackingProfile>
  </profiles>
</tracking>
```  
  
## Attributes and elements  

The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|`activityName`|A string that specifies the name of the activity that is requesting the cancellation.|  
|`childActivityName`|A string that specifies the name of the child activity for which cancellation was requested.|  
  
### Child elements

None.
  
### Parent elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<activityScheduledQueries>](activityscheduledqueries-of-wcf.md)|A collection of queries that are used to track an activity scheduled for execution by a parent activity.|  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.ActivityScheduledQueryElement>
- <xref:System.Activities.Tracking.ActivityScheduledQuery>
- [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)
