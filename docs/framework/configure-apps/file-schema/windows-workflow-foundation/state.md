---
title: "&lt;state&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: 619414f2-61c2-4427-9977-d05009e343db
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;state&gt;
Represents a collection of subscribed states from the tracked workflow instance when the tracking records are created.  
  
 For more information on tracking profile queries, see [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)  
  
\<system.serviceModel>  
\<tracking>  
\<trackingProfile>  
\<workflow>  
\<workflowInstanceQueries>  
\<workflowInstanceQuery>  
\<states>  
\<state>  
  
## Syntax  
  
```xml  
<tracking>
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
</tracking>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|name|A string that specifies a subscribed state from the tracked workflow instance when the tracking record is created.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<states>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/states.md)|A collection of subscribed states from the tracked workflow instance when the tracking records are created.|  
  
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
  
## See Also  
 <xref:System.ServiceModel.Activities.Tracking.Configuration.WorkflowInstanceQueryElement?displayProperty=nameWithType>       
 <xref:System.ServiceModel.Activities.Tracking.Configuration.StateElement?displayProperty=nameWithType>       
 <xref:System.Activities.Tracking.WorkflowInstanceQuery?displayProperty=nameWithType>      
 [Workflow Tracking and Tracing](../../../../../docs/framework/windows-workflow-foundation/workflow-tracking-and-tracing.md)  
 [Tracking Profiles](../../../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)
