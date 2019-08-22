---
title: "<cancelRequestedQuery> of WCF"
ms.date: "03/30/2017"
ms.assetid: b690d870-02eb-4c56-8bc3-e5ca99d7097b
---
# \<cancelRequestedQuery> of WCF

Represents a query that is used to track requests to cancel a child activity by the parent activity. The query is necessary for a tracking participant to subscribe to cancel request record objects.  
  
For more information on tracking profile queries, see [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md).
  
\<system.serviceModel>  
\<tracking>  
\<profiles>  
\<trackingProfile>  
\<workflow>  
\<cancelRequestedQueries>  
\<cancelRequestedQuery>  
  
## Syntax  
  
```xml  
<tracking>
  <profiles>
    <trackingProfile name="Name">
      <workflow>
        <cancelRequestedQueries>
          <cancelRequestedQuery activityName="String"
                                childActivityName="String" />
        </cancelRequestedQueries>
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
|[\<cancelRequestedQueries>](cancelrequestedqueries-of-wcf.md)|Represents a collection of queries that are used to track requests to cancel a child activity by the parent activity.|  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.CancelRequestedQueryElement?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.CancelRequestedQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)
