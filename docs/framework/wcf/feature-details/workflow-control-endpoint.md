---
title: "Workflow Control Endpoint"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1b883334-1590-4fbb-b0d6-65197efe0700
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Control Endpoint
The workflow control endpoint allows developers to call control operations to remotely control workflow instances hosted using <xref:System.ServiceModel.Activities.WorkflowServiceHost>. This feature can be used to programmatically perform control operations like suspend, resume, and terminate.  
  
> [!WARNING]
>  If using the workflow control endpoint within a transaction and the workflow being controlled contains a <xref:System.Activities.Statements.Persist> activity, the workflow instance will hang until the transaction times out.  
  
## Workflow Instance Management  
 [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] defines a new contract called <xref:System.ServiceModel.Activities.IWorkflowInstanceManagement>. This contract defines a series of control operations that allow you remotely control workflow instances hosted by <xref:System.ServiceModel.Activities.WorkflowServiceHost>. <xref:System.ServiceModel.Activities.WorkflowControlEndpoint> is a standard endpoint that provides an implementation of the <xref:System.ServiceModel.Activities.IWorkflowInstanceManagement> contract. <xref:System.ServiceModel.Activities.WorkflowControlClient> is a class that is used to send the control operations to the <xref:System.ServiceModel.Activities.WorkflowControlEndpoint>.  
  
 Workflow instances can be in one of the following states:  
  
 Active  
 The state of a workflow instance before it reaches the completed state and when it is not in the suspended state. While in this state, the workflow instance runs and processes application messages.  
  
 Suspended  
 While in this state, the workflow instance does not run even if there are activities that have not started running or have partially run.  
  
 Completed  
 The final state of a workflow instance. The workflow instance cannot run after reaching the completed state.  
  
## IWorkflowInstanceManagement  
 The <xref:System.ServiceModel.Activities.IWorkflowInstanceManagement> interface defines a set of control operations with synchronous and asynchronous versions. The transacted versions require use of a transaction-aware binding. The following table lists the control operations supported.  
  
|Control Operation|Description|  
|-----------------------|-----------------|  
|Abort|Forcefully stops the execution of the workflow instance.|  
|Cancel|Transitions a workflow instance from the active or suspended state to the completed state.|  
|Run|Provides a workflow instance the opportunity to execute.|  
|Suspend|Transitions a workflow instance from the active state to the suspended state.|  
|Terminate|Transitions a workflow instance from the active or suspended state to the completed state.|  
|Unsuspend|Transitions a workflow instance from the suspended state to the active state.|  
|TransactedCancel|Performs the Cancel operation under a transaction (flowed in from the client or created locally). If the system maintains the durable state of the workflow instance, the workflow instance must be persisted during execution of this operation.|  
|TransactedRun|Performs the Run operation under a transaction (flowed in from the client or created locally). If the system maintains the durable state of the workflow instance, the workflow instance must be persisted during execution of this operation.|  
|TransactedSuspend|Performs the Suspend operation under a transaction (flowed in from the client or created locally). If the system maintains the durable state of the workflow instance, the workflow instance must be persisted during execution of this operation.|  
|TransactedTerminate|Performs the Terminate operation under a transaction (flowed in from the client or created locally). If the system maintains the durable state of the workflow instance, the workflow instance must be persisted during execution of this operation.|  
|TransactedUnsuspend|Performs the Unsuspend operation under a transaction (flowed in from the client or created locally). If the system maintains the durable state of the workflow instance, the workflow instance must be persisted during execution of this operation.|  
  
 The <xref:System.ServiceModel.Activities.IWorkflowInstanceManagement> contract does not provide a means to create a new workflow instance, only to manage existing workflow instances. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] remotely creating a new workflow instance, see [Workflow Service Host Extensibility](../../../../docs/framework/wcf/feature-details/workflow-service-host-extensibility.md).  
  
## WorkflowControlEndpoint  
 <xref:System.ServiceModel.Activities.WorkflowControlEndpoint> is a standard endpoint with a fixed contract, <xref:System.ServiceModel.Activities.IWorkflowInstanceManagement>. When added to a <xref:System.ServiceModel.Activities.WorkflowServiceHost> instance, this endpoint can then be used to send command operations to any workflow instance hosted by the host instance. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] standard endpoints, see [Standard Endpoints](../../../../docs/framework/wcf/feature-details/standard-endpoints.md).  
  
## WorkflowControlClient  
 <xref:System.ServiceModel.Activities.WorkflowControlClient> is a class that allows you to send control messages to a <xref:System.ServiceModel.Activities.WorkflowControlEndpoint> on a <xref:System.ServiceModel.Activities.WorkflowServiceHost>. It contains a method for each of the operations supported by the <xref:System.ServiceModel.Activities.IWorkflowInstanceManagement> contract except for the transacted operations. <xref:System.ServiceModel.Activities.WorkflowControlClient> uses the ambient transaction to determine whether a transacted operation should be used.
