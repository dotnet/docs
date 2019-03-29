---
title: "<workflowInstanceQuery> of WCF"
ms.date: "03/30/2017"
ms.assetid: 35c73f9d-474e-42eb-874d-ddc04b1987f3
---
# \<workflowInstanceQuery> of WCF

Represents a query that tracks workflow instance life cycle changes such as a started or completed event.  
  
For more information on tracking profile queries, see [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)  
  
\<system.serviceModel>  
\<tracking>  
\<profiles>  
\<trackingProfile>  
\<workflow>  
\<workflowInstanceQueries>  
\<workflowInstanceQuery>  
  
## Syntax  
  
```xml  
<tracking>
  <profiles>
    <trackingProfile name="Name">
      <workflow>
        <workflowInstanceQueries>
          <workflowInstanceQuery>
            <states>
              <state name="Name" />
            </states>
          </workflowInstanceQuery>
        </workflowInstanceQueries>
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
|[\<states>](states-of-wcf-workflowinstancequery.md)|A collection of subscribed states from the tracked workflow instance when the tracking records are created.|  
  
### Parent elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<workflowInstanceQueries>](workflowinstancequeries-of-wcf.md)|Represents a collection of configuration elements that track workflow instance life cycle changes such as a started or completed event.|  
  
## Remarks  

The <xref:System.Activities.Tracking.WorkflowInstanceQuery> is used to subscribe to the following <xref:System.Activities.Tracking.TrackingRecord> objects:  
  
- <xref:System.Activities.Tracking.WorkflowInstanceRecord>  
  
- <xref:System.Activities.Tracking.WorkflowInstanceAbortedRecord>  
  
- <xref:System.Activities.Tracking.WorkflowInstanceUnhandledExceptionRecord>  
  
- <xref:System.Activities.Tracking.WorkflowInstanceTerminatedRecord>  
  
- <xref:System.Activities.Tracking.WorkflowInstanceSuspendedRecord>  
  
## Example  

The following configuration subscribes to workflow instance-level tracking records for the `Started` instance state using this query.  
  
```xml  
<workflowInstanceQueries>
  <workflowInstanceQuery>
    <states>
      <state name="Started" />
    </states>
  </workflowInstanceQuery>
</workflowInstanceQueries>
```  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.WorkflowInstanceQueryElement?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.WorkflowInstanceQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)
