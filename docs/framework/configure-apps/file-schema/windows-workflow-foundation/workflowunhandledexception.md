---
title: "<workflowUnhandledException>"
ms.date: "03/30/2017"
ms.topic: "reference"
ms.assetid: 57adeab5-f06a-44b2-916b-0e177cf0f4a6
---
# \<workflowUnhandledException>
A service behavior that enables you to specify the action to take when an unhandled exception occurs within a workflow service.  
  
\<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<workflowUnhandledException>  
  
## Syntax  
  
```xml  
<behaviors>
  <serviceBehaviors>
    <behavior name="String">
      <workflowUnhandledException action="Abandon/AbandonAndSuspend/Cancel/Terminate" />
    </behavior>
  </serviceBehaviors>
</behaviors>  
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|action|A string that specifies the action to take when an unhandled exception occurs. This attribute is of type <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionAction>|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior> of \<serviceBehaviors>](../../../../../docs/framework/configure-apps/file-schema/windows-workflow-foundation/behavior-of-servicebehaviors-of-workflow.md)|Specifies a behavior element.|  
  
## See also

- <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior>
- <xref:System.ServiceModel.Activities.Configuration.WorkflowUnhandledExceptionElement>
