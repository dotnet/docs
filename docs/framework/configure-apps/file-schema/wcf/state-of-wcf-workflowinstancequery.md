---
title: "<state> of WCF, <workflowInstanceQuery>"
ms.date: "03/30/2017"
ms.assetid: 40f21055-766c-4be9-86c4-d1d899007098
---
# \<state> of WCF, \<workflowInstanceQuery>
Represents a collection of subscribed states from the tracked workflow instance when the tracking records are created.  
  
 For more information on tracking profile queries, see [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<tracking>**](tracking-of-wcf.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<profiles>**\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<trackingProfile>**](trackingprofile-of-wcf.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<workflow>**](workflow-of-wcf.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<workflowInstanceQueries>**](workflowinstancequeries-of-wcf.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<workflowInstanceQuery>**](workflowinstancequery-of-wcf.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<states>**](states-of-wcf.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<state>**  
  
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

|Attribute|Description|  
|---------------|-----------------|  
|`name`|A string that specifies a subscribed state from the tracked workflow instance when the tracking record is created.|  
  
### Child elements

None.

### Parent elements

|Element|Description|  
|-------------|-----------------|  
|[\<states>](states-of-wcf-workflowinstancequery.md)|A collection of subscribed states from the tracked workflow instance when the tracking records are created.|  
  
## Remarks  

The returned records are filtered by the states in this collection.  
  
Possible state values are described in the following table:
  
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
- <xref:System.ServiceModel.Activities.Tracking.Configuration.StateElement?displayProperty=nameWithType>
- <xref:System.Activities.Tracking.WorkflowInstanceQuery?displayProperty=nameWithType>
- [Workflow Tracking and Tracing](../../../windows-workflow-foundation/workflow-tracking-and-tracing.md)
- [Tracking Profiles](../../../windows-workflow-foundation/tracking-profiles.md)
