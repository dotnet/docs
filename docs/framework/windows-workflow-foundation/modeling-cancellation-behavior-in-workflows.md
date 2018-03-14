---
title: "Modeling Cancellation Behavior in Workflows"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d48f6cf3-cdde-4dd3-8265-a665acf32a03
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Modeling Cancellation Behavior in Workflows
Activities can be canceled inside a workflow, for example by a <xref:System.Activities.Statements.Parallel> activity canceling incomplete branches when its <xref:System.Activities.Statements.Parallel.CompletionCondition%2A> evaluates to `true`, or from outside the workflow, if the host calls <xref:System.Activities.WorkflowApplication.Cancel%2A>. To provide cancellation handling, workflow authors can use the <xref:System.Activities.Statements.CancellationScope> activity, the <xref:System.Activities.Statements.CompensableActivity> activity, or create custom activities that provide cancellation logic. This topic provides an overview of cancellation in workflows.  
  
## Cancellation, Compensation, and Transactions  
 Transactions give your application the ability to abort (roll back) all changes executed within the transaction if any errors occur during any part of the transaction process. However, not all work that may need to be canceled or undone is appropriate for transactions, such as long-running work or work that does not involve transactional resources. Compensation provides a model for undoing previously completed non-transactional work if there is a subsequent failure in the workflow. Cancellation provides a model for workflow and activity authors to handle non-transactional work that was not completed. If an activity has not completed its execution and it is canceled, its cancellation logic will be invoked if it is available.  
  
> [!NOTE]
>  [!INCLUDE[crabout](../../../includes/crabout-md.md)] transactions and compensation, see [Transactions](../../../docs/framework/windows-workflow-foundation/workflow-transactions.md) and [Compensation](../../../docs/framework/windows-workflow-foundation/compensation.md).  
  
## Using CancellationScope  
 The <xref:System.Activities.Statements.CancellationScope> activity has two sections that can contain child activities: <xref:System.Activities.Statements.CancellationScope.Body%2A> and <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A>. The <xref:System.Activities.Statements.CancellationScope.Body%2A> is where the activities that make up the logic of the activity are placed, and the <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A> is where the activities that provide cancellation logic for the activity are placed. An activity can be canceled only if it has not completed. In the case of the <xref:System.Activities.Statements.CancellationScope> activity, completion refers to the completion of the activities in the <xref:System.Activities.Statements.CancellationScope.Body%2A>. If a cancellation request is scheduled and the activities in the <xref:System.Activities.Statements.CancellationScope.Body%2A> have not completed, then the <xref:System.Activities.Statements.CancellationScope> will be marked as <xref:System.Activities.ActivityInstanceState.Canceled> and the <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A> activities will be executed.  
  
### Canceling a Workflow from the Host  
 A host can cancel a workflow by calling the <xref:System.Activities.WorkflowApplication.Cancel%2A> method of the <xref:System.Activities.WorkflowApplication> instance that is hosting the workflow. In the following example a workflow is created that has a <xref:System.Activities.Statements.CancellationScope>. The workflow is invoked, and then the host makes a call to <xref:System.Activities.WorkflowApplication.Cancel%2A>. The main execution of the workflow is stopped, the <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A> of the <xref:System.Activities.Statements.CancellationScope> is invoked, and then the workflow completes with a status of <xref:System.Activities.ActivityInstanceState.Canceled>.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#35](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#35)]  
  
 When this workflow is invoked, the following output is displayed to the console.  
  
 **Starting the workflow.**  
**CancellationHandler invoked.**   
**Workflow b30ebb30-df46-4d90-a211-e31c38d8db3c Canceled.**    
> [!NOTE]
>  When a <xref:System.Activities.Statements.CancellationScope> activity is canceled and the <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A> invoked, it is the responsibility of the workflow author to determine the progress that the canceled activity made before it was canceled in order to provide the appropriate cancellation logic. The <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A> does not provide any information about the progress of the canceled activity.  
  
 A workflow can also be canceled from the host if an unhandled exception bubbles up past the root of the workflow and the <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A> handler returns <xref:System.Activities.UnhandledExceptionAction.Cancel>. In this example the workflow starts and then throws an <xref:System.ApplicationException>. This exception is unhandled by the workflow and so the <xref:System.Activities.WorkflowApplication.OnUnhandledException%2A> handler is invoked. The handler instructs the runtime to cancel the workflow, and the <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A> of the currently executing <xref:System.Activities.Statements.CancellationScope> activity is invoked.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#36](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#36)]  
  
 When this workflow is invoked, the following output is displayed to the console.  
  
 **Starting the workflow.**  
**OnUnhandledException in Workflow 6bb2d5d6-f49a-4c6d-a988-478afb86dbe9**   
**An ApplicationException was thrown.**   
**CancellationHandler invoked.**   
**Workflow 6bb2d5d6-f49a-4c6d-a988-478afb86dbe9 Canceled.**    
### Canceling an Activity from Inside a Workflow  
 An activity can also be canceled by its parent. For example, if a <xref:System.Activities.Statements.Parallel> activity has multiple executing branches and its <xref:System.Activities.Statements.Parallel.CompletionCondition%2A> evaluates to `true` then its incomplete branches will be canceled. In this example a <xref:System.Activities.Statements.Parallel> activity is created that has two branches. Its <xref:System.Activities.Statements.Parallel.CompletionCondition%2A> is set to `true` so the <xref:System.Activities.Statements.Parallel> completes as soon as any one of its branches is completed. In this example branch 2 completes, and so branch 1 is canceled.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#37](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#37)]  
  
 When this workflow is invoked, the following output is displayed to the console.  
  
 **Branch 1 starting.**  
**Branch 2 complete.**   
**Branch 1 canceled.**   
**Workflow e0685e24-18ef-4a47-acf3-5c638732f3be Completed.**  Activities are also canceled if an exception bubbles up past the root of the activity but is handled at a higher level in the workflow. In this example, the main logic of the workflow consists of a <xref:System.Activities.Statements.Sequence> activity. The <xref:System.Activities.Statements.Sequence> is specified as the <xref:System.Activities.Statements.CancellationScope.Body%2A> of a <xref:System.Activities.Statements.CancellationScope> activity which is contained by a <xref:System.Activities.Statements.TryCatch> activity. An exception is thrown from the body of the <xref:System.Activities.Statements.Sequence>, is handled by the parent <xref:System.Activities.Statements.TryCatch> activity, and the <xref:System.Activities.Statements.Sequence> is canceled.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#39](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#39)]  
  
 When this workflow is invoked, the following output is displayed to the console.  
  
 **Sequence starting.**  
**Sequence canceled.**   
**Exception caught.**   
**Workflow e3c18939-121e-4c43-af1c-ba1ce977ce55 Completed.**   
### Throwing Exceptions from a CancellationHandler  
 Any exceptions thrown from the <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A> of a <xref:System.Activities.Statements.CancellationScope> are fatal to the workflow. If there is a possibility of exceptions escaping from a <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A>, use a <xref:System.Activities.Statements.TryCatch> in the <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A> to catch and handle these exceptions.  
  
### Cancellation using CompensableActivity  
 Like the <xref:System.Activities.Statements.CancellationScope> activity, the <xref:System.Activities.Statements.CompensableActivity> has a <xref:System.Activities.Statements.CompensableActivity.CancellationHandler%2A>. If a <xref:System.Activities.Statements.CompensableActivity> is canceled, any activities in its <xref:System.Activities.Statements.CompensableActivity.CancellationHandler%2A> are invoked. This can be useful for undoing partially completed compensable work. For information about how to use <xref:System.Activities.Statements.CompensableActivity> for compensation and cancellation, see [Compensation](../../../docs/framework/windows-workflow-foundation/compensation.md).  
  
## Cancellation using Custom Activities  
 Custom activity authors can implement cancellation logic into their custom activities in several different ways. Custom activities that derive from <xref:System.Activities.Activity> can implement cancellation logic by placing a <xref:System.Activities.Statements.CancellationScope> or other custom activity that contains cancellation logic in the body of the activity. <xref:System.Activities.AsyncCodeActivity> and <xref:System.Activities.NativeActivity> derived activities can override their respective <xref:System.Activities.NativeActivity.Cancel%2A> method and provide cancellation logic there. <xref:System.Activities.CodeActivity> derived activities do not provide any provision for cancellation because all their work is performed in a single burst of execution when the runtime calls the <xref:System.Activities.CodeActivity.Execute%2A> method. If the execute method has not yet been called and a <xref:System.Activities.CodeActivity> based activity is canceled, the activity closes with a status of <xref:System.Activities.ActivityInstanceState.Canceled> and the <xref:System.Activities.CodeActivity.Execute%2A> method is not called.  
  
### Cancellation using NativeActivity  
 <xref:System.Activities.NativeActivity> derived activities can override the <xref:System.Activities.NativeActivity.Cancel%2A> method to provide custom cancellation logic. If this method is not overridden, then the default workflow cancellation logic is applied. Default cancellation is the process that occurs for a <xref:System.Activities.NativeActivity> that does not override the <xref:System.Activities.NativeActivity.Cancel%2A> method or whose <xref:System.Activities.NativeActivity.Cancel%2A> method calls the base <xref:System.Activities.NativeActivity> <xref:System.Activities.NativeActivity.Cancel%2A> method. When an activity is canceled, the runtime flags the activity for cancellation and automatically handles certain cleanup. If the activity only has outstanding bookmarks, the bookmarks will be removed and the activity will be marked as <xref:System.Activities.ActivityInstanceState.Canceled>. Any outstanding child activities of the canceled activity will in turn be canceled. Any attempt to schedule additional child activities will result in the attempt being ignored and the activity will be marked as <xref:System.Activities.ActivityInstanceState.Canceled>. If any outstanding child activity completes in the <xref:System.Activities.ActivityInstanceState.Canceled> or <xref:System.Activities.ActivityInstanceState.Faulted> state, then the activity will be marked as <xref:System.Activities.ActivityInstanceState.Canceled>. Note that a cancellation request can be ignored. If an activity does not have any outstanding bookmarks or executing child activities and does not schedule any additional work items after being flagged for cancellation, it will complete successfully. This default cancellation suffices for many scenarios, but if additional cancellation logic is needed, then the built-in cancellation activities or custom activities can be used.  
  
 In the following example, the <xref:System.Activities.NativeActivity.Cancel%2A> override of a <xref:System.Activities.NativeActivity> based custom `ParallelForEach` activity is defined. When the activity is canceled, this override handles the cancellation logic for the activity. This example is part of the [Non-Generic ParallelForEach](../../../docs/framework/windows-workflow-foundation/samples/non-generic-parallelforeach.md) sample.  
  
```csharp  
protected override void Cancel(NativeActivityContext context)  
{  
    // If we do not have a completion condition then we can just  
    // use default logic.  
    if (this.CompletionCondition == null)  
    {  
        base.Cancel(context);  
    }  
    else  
    {  
        context.CancelChildren();  
    }  
}  
```  
  
 <xref:System.Activities.NativeActivity> derived activities can determine if cancellation has been requested by inspecting the <xref:System.Activities.NativeActivityContext.IsCancellationRequested%2A> property, and mark themselves as canceled by calling the <xref:System.Activities.NativeActivityContext.MarkCanceled%2A> method. Calling <xref:System.Activities.NativeActivityContext.MarkCanceled%2A> does not immediately complete the activity. As usual, the runtime will complete the activity when it has no more outstanding work, but if <xref:System.Activities.NativeActivityContext.MarkCanceled%2A> is called the final state will be <xref:System.Activities.ActivityInstanceState.Canceled> instead of <xref:System.Activities.ActivityInstanceState.Closed>.  
  
### Cancellation using AsyncCodeActivity  
 <xref:System.Activities.AsyncCodeActivity> based activities can also provide custom cancellation logic by overriding the <xref:System.Activities.AsyncCodeActivity.Cancel%2A> method. If this method is not overridden, then no cancellation handling is performed if the activity is canceled. In the following example, the <xref:System.Activities.AsyncCodeActivity.Cancel%2A> override of an <xref:System.Activities.AsyncCodeActivity> based custom `ExecutePowerShell` activity is defined. When the activity is canceled, it performs the desired cancellation behavior. This example is part of the [Using the InvokePowerShell Activity](../../../docs/framework/windows-workflow-foundation/samples/using-the-invokepowershell-activity.md) sample.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#1020](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#1020)]  
  
 <xref:System.Activities.AsyncCodeActivity> derived activities can determine if cancellation has been requested by inspecting the <xref:System.Activities.AsyncCodeActivityContext.IsCancellationRequested%2A> property, and mark themselves as canceled by calling the <xref:System.Activities.AsyncCodeActivityContext.MarkCanceled%2A> method.
