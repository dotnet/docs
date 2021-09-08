---
description: "Learn more about: <states>"
title: "<states>"
ms.date: "03/30/2017"
ms.assetid: ebea5e7c-ad58-43c5-8f2d-cca25ae1b721
---
# \<states>

Represents a collection of subscribed states from the tracked workflow instance when the tracking records are created.  
  
 For more information on tracking profile queries, see [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.ServiceModel>**](system-servicemodel-of-workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<tracking>**](tracking.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<trackingProfile>**](trackingprofile.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<workflow>**](workflow.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<workflowInstanceQueries>**](workflowinstancequeries.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<workflowInstanceQuery>**](workflowinstancequery.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<states>**  
  
## Syntax  
  
```xml  
<tracking>
  <trackingProfile name="Name">
    <workflow>
      <workflowInstanceQueries>
        <workflowInstanceQuery>
          <states>
            <state name="Name"/>
          </states>
        </workflowInstanceQuery>
      </workflowInstanceQueries>
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
|[\<state>](states.md)|A subscribed state from the tracked workflow instance when the tracking record is created.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<workflowInstanceQuery>](workflowinstancequery.md)|A query that tracks workflow instance life cycle changes such as a started or completed event.|  
  
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
        <state name="Started"/>  
      </states>  
    </workflowInstanceQuery>  
</workflowInstanceQueries>  
```  
  
## See also

- <xref:System.ServiceModel.Activities.Tracking.Configuration.WorkflowInstanceQueryElement?displayProperty=nameWithType>
- <xref:System.ServiceModel.Activities.Tracking.Configuration.StateElementCollection?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.WorkflowInstanceQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)
