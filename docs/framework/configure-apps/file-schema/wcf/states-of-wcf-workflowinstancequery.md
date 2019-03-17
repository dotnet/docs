---
title: "<states> of WCF, <workflowInstanceQuery>"
ms.date: "03/30/2017"
ms.assetid: d17f7525-8035-4e9e-85a0-4cddae59f85d
---
# \<states> of WCF, \<workflowInstanceQuery>

Represents a collection of subscribed states from the tracked workflow instance when the tracking records are created.  
  
For more information on tracking profile queries, see [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)  
  
\<system.serviceModel>
\<tracking>  
\<profiles>  
\<trackingProfile>  
\<workflow>  
\<workflowInstanceQueries>  
\<workflowInstanceQuery>  
\<states>  
  
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
|[\<states>](state-of-wcf-workflowinstancequery.md)|A subscribed state from the tracked workflow instance when the tracking record is created.|  
  
### Parent elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<workflowInstanceQuery>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/workflowinstancequery.md)|A query that tracks workflow instance life cycle changes such as a started or completed event.|  
  
## Remarks

The returned records are filtered by the states in this collection.  
  
Possible state values are described in the following table.  
  
|State|Description|  
|-----------|-----------------|  
|Aborted|The workflow instance is aborted.|  
|Completed|The workflow instance is completed.|  
|Deleted|The workflow instance is deleted.|  
|Idle|The workflow instance is idle.|  
|Persisted|The workflow instance is persisted.|  
|Resumed|The workflow instance is resumed.|  
|Started|The workflow instance is started.|  
|UnhandledException|The workflow instance encountered an unhandled exception.|  
|Unloaded|The workflow instance is unloaded.|  
|Canceled|The workflow instance is canceled.|  
|Suspended|The workflow instance is suspended.|  
|Terminated|The workflow instance is terminated.|  
|Unsuspended|The workflow instance is unsuspended.|  
  
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
- <xref:System.ServiceModel.Activities.Tracking.Configuration.StateElementCollection?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.WorkflowInstanceQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)
