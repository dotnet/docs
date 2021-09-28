---
description: "Learn more about: <workflowRuntime>"
title: "<workflowRuntime>"
ms.date: "03/30/2017"
ms.assetid: 304c70fa-78d1-4d0f-b89f-0ca23d734c6f
---
# \<workflowRuntime>

Specifies settings for an instance of <xref:System.Workflow.Runtime.WorkflowRuntime> for hosting workflow-based Windows Communication Foundation (WCF) services.  
  
[**\<configuration>**](../configuration-element.md)\
&nbsp;&nbsp;[**\<system.serviceModel>**](system-servicemodel.md)\
&nbsp;&nbsp;&nbsp;&nbsp;[**\<behaviors>**](behaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<serviceBehaviors>**](servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;[**\<behavior>**](behavior-of-servicebehaviors.md)\
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;**\<workflowRuntime>**  
  
## Syntax  
  
```xml  
<workflowRuntime cachedInstanceExpiration="TimeSpan"
                 enablePerformanceCounters="Boolean"
                 name="String"
                 validateOnCreate="Boolean">
  <commonParameters>
    <add name="String"
         value="String" />
  </commonParameters>
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
|cachedInstanceExpiration|An optional <xref:System.TimeSpan> value that specifies the maximum duration a workflow instance can stay in-memory in idle state before it is forcefully unloaded or aborted. If the workflowruntime has `PersistenceService` which performs unloadOnIdle, this attribute is ignored.|  
|enablePerformanceCounters|An optional Boolean value that specifies whether performance counters are enabled. Performance counters provide information on various workflow-related statistics, but they cause a performance penalty when the workflow runtime engine starts, and when workflow instances are running. The default value is `true`.|  
|name|A string containing the name of the workflow runtime engine. The name is used in output to distinguish this runtime from other runtimes that may be running on the system, for example, in performance counters.<br /><br /> The default is an empty string.|  
|validateOnCreate|An optional Boolean value that specifies whether validation of workflow definition will occur when the WorkflowServiceHost is opened.  When this attribute is set to `true`, the workflow validation is executed every time `WorkflowServiceHost.Open` is called. If validation errors are found, a <xref:System.Workflow.ComponentModel.Compiler.WorkflowValidationFailedException> error is thrown.<br /><br /> When this property is set to `false`, no Workflow definition validation will happen.<br /><br /> The default value for this property is `true`.|  
  
### Child Elements  
  
|Element|Description|  
|-------------|-----------------|  
|commonParameters|A collection of common parameters used by services. This collection will typically include the database connection string that might be shared by durable services.|  
|services|A collection of services that will be added to the <xref:System.Workflow.Runtime.WorkflowRuntime> engine. The elements are of type <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement>.  The services specified in the collection will be initialized by the workflow runtime engine and added to its services when the appropriate <xref:System.Workflow.Runtime.WorkflowRuntime> constructor is called. Therefore, the services specified in the collection must follow certain rules about the signatures of their constructors. See <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement> for more information.|  
  
### Parent Elements  
  
|Element|Description|  
|-------------|-----------------|  
|[\<behavior>](behavior-of-endpointbehaviors.md)|Specifies a behavior element.|  
  
## Remarks  

 For more information on using a configuration file to control the behavior of a <xref:System.Workflow.Runtime.WorkflowRuntime> object of a Windows Workflow Foundation host application, see [Workflow Configuration Files](/previous-versions/dotnet/netframework-3.5/ms732240(v=vs.90)).  
  
## Example  
  
```xml  
<serviceBehaviors>
   <behavior name="ServiceBehavior">
      <workflowRuntime name="WorkflowServiceHostRuntime"
                       validateOnCreate="true"
                       enablePerformanceCounters="true">
         <commonParameters>
            <add name="ConnectionString" value="Initial Catalog=WorkflowStore;Data Source=localhost;Integrated Security=SSPI;" />
            <add name="EnableRetries" value="True" />
         </commonParameters>
         <services>
             <add type="NetFx.Checkin.Scenario.WorkflowServices.WorkflowBasedServices.Common.TestPersistenceService.FilePersistenceService, NetFx.Checkin.Scenario.WorkflowServices.WorkflowBasedServices.Common"/>
         </services>
      </workflowRuntime>
   </behavior>
</serviceBehaviors>
```  
  
## See also

- <xref:System.ServiceModel.Configuration.WorkflowRuntimeElement>
- <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement>
- <xref:System.Workflow.Runtime.WorkflowRuntime>
- [Workflow Configuration Files](/previous-versions/dotnet/netframework-3.5/ms732240(v=vs.90))
