---
title: "&lt;services&gt; of &lt;workflowRuntime&gt;"
ms.date: "03/30/2017"
ms.assetid: 219a05b1-f573-45c9-849b-e86bc373b62f
---
# &lt;services&gt; of &lt;workflowRuntime&gt;
Represents a collection of services that will be added to the <xref:System.Workflow.Runtime.WorkflowRuntime> engine. The elements are of type <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement>.  The services specified in the collection will be initialized by the workflow runtime engine and added to its services when the appropriate <xref:System.Workflow.Runtime.WorkflowRuntime> constructor is called. Therefore, the services specified in the collection must follow certain rules about the signatures of their constructors. See <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement> for more information.  
  
## See also
 <xref:System.Workflow.Runtime.WorkflowRuntime>  
 <xref:System.Workflow.Runtime.Configuration.WorkflowRuntimeServiceElement>  
 <xref:System.Workflow.Runtime.WorkflowRuntime>  
 [Workflow Configuration Files](https://docs.microsoft.com/previous-versions/dotnet/netframework-3.5/ms732240(v=vs.90))
