---
title: "&lt;faultPropagationQueries&gt; of WCF"
ms.date: "03/30/2017"
ms.assetid: d85f66a7-e7b0-4dbb-83cc-89fa06fc9161
---
# &lt;faultPropagationQueries&gt; of WCF

Represents a collection of queries that are used to track the handling of faults that occur within an activity.  This event occurs each time a FaultHandler processes a fault. You should use such query to track the handling of faults that occur within an activity. The query is necessary for a  tracking participant to subscribe to fault propagation records.  
  
For more information on tracking profile queries, see [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md).  
  
\<system.serviceModel>  
\<tracking>  
\<profiles>  
\<trackingProfile>  
\<workflow>  
\<faultPropagationQueries>  
  
## Syntax  
  
```xml  
<tracking>
  <profiles>
    <trackingProfile name="Name">
      <workflow>
        <faultPropagationQueries>
          <faultPropagationQuery faultSourceActivityName="String"
                                 faultHandlerActivityName="String"/>
        </faultPropagationQueries>
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
|[\<faultPropagationQuery>](faultpropagationquery-of-wcf.md)|A query that is used to track the handling of faults that occur within an activity.  This event occurs each time a FaultHandler processes a fault.|  
  
### Parent elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<workflow>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/workflow.md)|A configuration element that contains all queries for a specific workflow identified by the `activityDefinitionId` property.|  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.FaultPropagationQueryElementCollection?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.FaultPropagationQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)
