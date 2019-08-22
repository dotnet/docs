---
title: "<bookmarkResumptionQueries> of WCF"
ms.date: "03/30/2017"
ms.assetid: ed086712-1dc7-4932-a592-d1116a0155f3
---
# \<bookmarkResumptionQueries> of WCF
  
Represents a collection of queries that are used to track resumption of a bookmark within a workflow instance. The query is necessary for a tracking participant to subscribe to bookmark resumption records.  
  
For more information on tracking profile queries, see [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md).
  
\<system.serviceModel>  
\<tracking>  
\<profiles>  
\<trackingProfile>  
\<workflow>  
\<bookmarkResumptionQueries>  
\<bookmarkResumptionQuery>  
  
## Syntax  
  
```xml  
<tracking>
  <profiles>
    <trackingProfile name="Name">
      <workflow>
        <bookmarkResumptionQueries>
          <bookmarkResumptionQuery name="String" />
        </bookmarkResumptionQueries>
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
|[\<bookmarkResumptionQuery>](bookmarkresumptionquery-of-wcf.md)|A query that is used to track resumption of a bookmark within a workflow instance. The query is necessary for a tracking participant to subscribe to bookmark resumption records.|  
  
### Parent elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<workflow>](../windows-workflow-foundation/workflow.md)|A configuration element that contains all queries for a specific workflow identified by the `activityDefinitionId` property.|  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.BookmarkResumptionQueryElementCollection?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.BookmarkResumptionQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)
