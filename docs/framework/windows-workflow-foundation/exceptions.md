---
title: "Exceptions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 065205cc-52dd-4f30-9578-b17d8d113136
caps.latest.revision: 26
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Exceptions
Workflows can use the <xref:System.Activities.Statements.TryCatch> activity to handle exceptions that are raised during the execution of a workflow. These exceptions can be handled or they can be re-thrown using the <xref:System.Activities.Statements.Rethrow> activity. Activities in the <xref:System.Activities.Statements.TryCatch.Finally%2A> section are executed when either the <xref:System.Activities.Statements.TryCatch.Try%2A> section or the <xref:System.Activities.Statements.TryCatch.Catches%2A> section completes. Workflows hosted by a <xref:System.Activities.WorkflowApplication> instance can also use the <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A> event handler to handle exceptions that are not handled by a <xref:System.Activities.Statements.TryCatch> activity.  
  
## Causes of Exceptions  
 In a workflow, exceptions can be generated in the following ways:  
  
-   A time-out of transactions in <xref:System.Activities.Statements.TransactionScope>.  
  
-   An explicit exception thrown by the workflow using the <xref:System.Activities.Statements.Throw> activity.  
  
-   A [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] exception thrown from an activity.  
  
-   An exception thrown from external code, such as libraries, components, or services that are used in the workflow.  
  
## Handling Exceptions  
 If an exception is thrown by an activity and is unhandled, the default behavior is to terminate the workflow instance. If a custom <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A> handler is present, it can override this default behavior. This handler gives the workflow host author an opportunity to provide the appropriate handling, such as custom logging, aborting the workflow, canceling the workflow, or terminating the workflow.  If a workflow raises an exception that is not handled, the <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A> handler is invoked. There are three possible actions returned from <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A> which determine the final outcome of the workflow.  
  
-   **Cancel** - A cancelled workflow instance is a graceful exit of a branch execution. You can model cancelation behavior (for example, by using a CancellationScope activity). The Completed handler is invoked when the cancellation process completes. A cancelled workflow is in the Cancelled state.  
  
-   **Terminate** - A terminated workflow instance cannot be resumed or restarted.  This triggers the Completed event in which you can provide an exception as the reason it was terminated. The Terminated handler is invoked when the termination process completes. A terminated workflow is in the Faulted state.  
  
-   **Abort** - An aborted workflow instances can be resumed only if it has been configured to be persistent.  Without persistence, a workflow cannot be resumed.  At the point a workflow is aborted, any work done (in memory) since the last persistence point will be lost. For an aborted workflow, the Aborted handler is invoked using the exception as the reason when the abort process completes. However, unlike Cancelled and Terminated, the Completed handler is not invoked. An aborted workflow is in an Aborted state.  
  
 The following example invokes a workflow that throws an exception. The exception is unhandled by the workflow and the <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A> handler is invoked. The <xref:System.Activities.WorkflowApplicationUnhandledExceptionEventArgs> are inspected to provide information about the exception, and the workflow is terminated.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#1](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#1)]  
  
### Handling Exceptions with the TryCatch Activity  
 Handling exceptions inside a workflow is performed with the <xref:System.Activities.Statements.TryCatch> activity. The <xref:System.Activities.Statements.TryCatch> activity has a <xref:System.Activities.Statements.TryCatch.Catches%2A> collection of <xref:System.Activities.Statements.Catch> activities that are each associated with a specific <xref:System.Exception> type. If the exception thrown by an activity that is contained in the <xref:System.Activities.Statements.TryCatch.Try%2A> section of a <xref:System.Activities.Statements.TryCatch> activity matches the exception of a <xref:System.Activities.Statements.Catch%601> activity in the <xref:System.Activities.Statements.TryCatch.Catches%2A> collection, then the exception is handled. If the exception is explicitly re-thrown or a new exception is thrown then this exception passes up to the parent activity. The following code example shows a <xref:System.Activities.Statements.TryCatch> activity that handles an <xref:System.ApplicationException> that is thrown in the <xref:System.Activities.Statements.TryCatch.Try%2A> section by a <xref:System.Activities.Statements.Throw> activity. The exception's message is written to the console by the <xref:System.Activities.Statements.Catch%601> activity, and then a message is written to the console in the <xref:System.Activities.Statements.TryCatch.Finally%2A> section.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#33](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#33)]  
  
 The activities in the <xref:System.Activities.Statements.TryCatch.Finally%2A> section are executed when either the <xref:System.Activities.Statements.TryCatch.Try%2A> section or the <xref:System.Activities.Statements.TryCatch.Catches%2A> section successfully completes. The <xref:System.Activities.Statements.TryCatch.Try%2A> section successfully completes if no exceptions are thrown from it, and the <xref:System.Activities.Statements.TryCatch.Catches%2A> section successfully completes if no exceptions are thrown or rethrown from it. If an exception is thrown in the <xref:System.Activities.Statements.TryCatch.Try%2A> section of a <xref:System.Activities.Statements.TryCatch> and is either not handled by a <xref:System.Activities.Statements.Catch%601> in the <xref:System.Activities.Statements.TryCatch.Catches%2A> section, or is rethrown from the <xref:System.Activities.Statements.TryCatch.Catches%2A>, the activities in the <xref:System.Activities.Statements.TryCatch.Finally%2A> will not be executed unless the one of the following occurs.  
  
-   The exception is caught by a higher level <xref:System.Activities.Statements.TryCatch> activity in the workflow, regardless of whether it is rethrown from that higher level <xref:System.Activities.Statements.TryCatch>.  
  
-   The exception is not handled by a higher level <xref:System.Activities.Statements.TryCatch>, escapes the root of the workflow, and the workflow is configured to cancel instead of terminate or abort. Workflows hosted using <xref:System.Activities.WorkflowApplication> can configure this by handling <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A> and returning <xref:System.Activities.UnhandledExceptionAction.Cancel>. An example of handling <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A> is provided previously in this topic. Workflow services can configure this by using <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior> and specifying <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionAction.Cancel>. For an example of configuring <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior>, see [Workflow Service Host Extensibility](../../../docs/framework/wcf/feature-details/workflow-service-host-extensibility.md).  
  
## Exception Handling versus Compensation  
 The difference between exception handling and compensation is that exception handling occurs during the execution of an activity. Compensation occurs after an activity has successfully completed. Exception handling provides an opportunity to clean up after the activity raises the exception, whereas compensation provides a mechanism by which the successfully completed work of a previously completed activity can be undone. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Compensation](../../../docs/framework/windows-workflow-foundation/compensation.md).  
  
## See Also  
 <xref:System.Activities.Statements.TryCatch>  
 <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A>  
 <xref:System.Activities.Statements.CompensableActivity>
