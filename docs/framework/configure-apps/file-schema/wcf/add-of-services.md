---
title: "<add> of <services>"
ms.date: "03/30/2017"
ms.assetid: 6bdc4590-aa9c-4ec8-9345-879d780cd141
---
# \<add> of \<services>
Specifies settings for an instance of <xref:System.Workflow.Runtime.WorkflowRuntime> for hosting workflow-based Windows Communication Foundation (WCF) services. This element is of type <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement>.  
  
 \<system.ServiceModel>  
\<behaviors>  
\<serviceBehaviors>  
\<behavior>  
\<services>  
\<add>  
  
## Syntax  
  
```xml  
<workflowRuntime>
  <services>
    <add type="String" />
  </services>
</workflowRuntime>
```  
  
## Attributes and Elements  
 The following sections describe attributes, child elements, and parent elements.  
  
### Attributes  
  
|Attribute|Description|  
|---------------|-----------------|  
|type|A string that specifies the assembly-qualified type name of the service to be initialized. The service specified must follow certain rules about the signatures of their constructors. See <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement> for more information.|  
  
### Child Elements  
 None.  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<services>](../../../../../docs/framework/configure-apps/file-schema/wcf/services-of-workflowruntime.md)|A collection of services that will be added to the <xref:System.Workflow.Runtime.WorkflowRuntime> engine. The elements are of type <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement>.  The services specified in the collection will be initialized by the workflow runtime engine and added to its services when the appropriate <xref:System.Workflow.Runtime.WorkflowRuntime> constructor is called. Therefore, the services specified in the collection must follow certain rules about the signatures of their constructors. See <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement> for more information.|  
  
## Remarks  
 The service specified in this element will be initialized by the workflow runtime engine and added to its services when the appropriate <xref:System.Workflow.Runtime.WorkflowRuntime> constructor is called. Therefore, the service specified must follow certain rules about the signatures of their constructors. See <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement> for more information.  
  
## Example  
  
```xml  
<serviceBehaviors>
  <behavior name="ServiceBehavior">
    <workflowRuntime name="WorkflowServiceHostRuntime"
                     validateOnCreate="true"
                     enablePerformanceCounters="true">
      <services>
        <add type="NetFx.Checkin.Scenario.WorkflowServices.WorkflowBasedServices.Common.TestPersistenceService.FilePersistenceService, NetFx.Checkin.Scenario.WorkflowServices.WorkflowBasedServices.Common" />
      </services>
    </workflowRuntime>
  </behavior>
</serviceBehaviors>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.WorkflowRuntimeElement>
- <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement>
- <xref:System.Workflow.Runtime.WorkflowRuntime>
- [Workflow Configuration Files](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms732240(v=vs.90))
