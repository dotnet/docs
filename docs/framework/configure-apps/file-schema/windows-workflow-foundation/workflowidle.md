---
title: "&lt;workflowIdle&gt;"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "reference"
ms.assetid: b2ef703c-3e01-4213-9d2e-c14c7dba94d2
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# &lt;workflowIdle&gt;
A service behavior that controls when idle workflow instances are unloaded and persisted.  
  
\<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<workflowIdle>  
  
## Syntax  
  
```xml  
<behaviors>
  <serviceBehaviors>
    <behavior name="String">
      <workflowIdle timeToPersist="TimeSpan" 
                    timeToUnload="TimeSpan" />
    </behavior>
  </serviceBehaviors>
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|timeToPersist|A Timespan value that specifies the duration between the time the workflow becomes idle and is persisted. The default value is TimeSpan.MaxValue.<br /><br /> The duration begins to elapse when the workflow instance becomes idle. This attribute  is useful if you want to persist a workflow instance more aggressively while still keeping the instance in memory for as long as possible. This attribute  is only valid if its value is less than the **timeToUnload** attribute. If it is greater, it is ignored. If this attribute elapses before the value specified by the **timeToUnload** attribute, persistence must complete before the workflow is unloaded. This implies that the unload operation may be delayed until the workflow is persisted. The persistence layer is responsible for handling any retries for transient errors and only throws exceptions on non-recoverable errors. Therefore, any exceptions thrown during persistence are treated as fatal and the workflow instance is aborted.|  
|timeToUnload|A Timespan value that specifies the duration between the time the workflow becomes idle and is unloaded. The default value is 1 minute.<br /><br /> Unloading a workflow implies that it is also persisted. If this attribute is set to zero the workflow instance is persisted and unloaded immediately after the workflow becomes idle. Setting this attribute to TimeSpan.MaxValue effectively disables the unload operation. Idle workflow instances are never unloaded.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior> of \<serviceBehaviors>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/behavior-of-servicebehaviors-of-workflow.md)|Specifies a behavior element.|  
  
## See Also  
 <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior>  
 <xref:System.ServiceModel.Activities.Configuration.WorkflowIdleElement>
