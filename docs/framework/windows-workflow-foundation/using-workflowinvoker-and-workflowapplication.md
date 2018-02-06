---
title: "Using WorkflowInvoker and WorkflowApplication"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: cd0e583c-a3f9-4fa2-b247-c7b3368c48a7
caps.latest.revision: 19
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using WorkflowInvoker and WorkflowApplication
[!INCLUDE[wf](../../../includes/wf-md.md)] provides several methods of hosting workflows. <xref:System.Activities.WorkflowInvoker> provides a simple way for invoking a workflow as if it were a method call and can be used only for workflows that do not use persistence. <xref:System.Activities.WorkflowApplication> provides a richer model for executing workflows that includes notification of lifecycle events, execution control, bookmark resumption, and persistence. <xref:System.ServiceModel.Activities.WorkflowServiceHost> provides support for messaging activities and is primarily used with workflow services. This topic introduces you to workflow hosting with <xref:System.Activities.WorkflowInvoker> and <xref:System.Activities.WorkflowApplication>. [!INCLUDE[crabout](../../../includes/crabout-md.md)] hosting workflows with <xref:System.ServiceModel.Activities.WorkflowServiceHost>, see [Workflow Services](../../../docs/framework/wcf/feature-details/workflow-services.md) and [Hosting Workflow Services Overview](../../../docs/framework/wcf/feature-details/hosting-workflow-services-overview.md).  
  
## Using WorkflowInvoker  
 <xref:System.Activities.WorkflowInvoker> provides a model for executing a workflow as if it were a method call. To invoke a workflow using <xref:System.Activities.WorkflowInvoker>, call the <xref:System.Activities.WorkflowInvoker.Invoke%2A> method and pass in the workflow definition of the workflow to invoke. In this example, a <xref:System.Activities.Statements.WriteLine> activity is invoked using <xref:System.Activities.WorkflowInvoker>.  
  
 [!code-csharp[CFX_WorkflowInvokerExample#1](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowinvokerexample/cs/program.cs#1)]  
  
 When a workflow is invoked using <xref:System.Activities.WorkflowInvoker>, the workflow executes on the calling thread and the <xref:System.Activities.WorkflowInvoker.Invoke%2A> method blocks until the workflow is complete, including any idle time. To configure a time-out interval in which the workflow must complete, use one of the <xref:System.Activities.WorkflowInvoker.Invoke%2A> overloads that takes a <xref:System.TimeSpan> parameter. In this example, a workflow is invoked twice with two different time-out intervals. The first workflow complets, but the second does not.  
  
 [!code-csharp[CFX_WorkflowInvokerExample#50](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowinvokerexample/cs/program.cs#50)]  
  
> [!NOTE]
>  The <xref:System.TimeoutException> is only thrown if the time-out interval elapses and the workflow becomes idle during execution. A workflow that takes longer than the specified time-out interval to complete completes successfully if the workflow does not become idle.  
  
 <xref:System.Activities.WorkflowInvoker> also provides asynchronous versions of the invoke method. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] <xref:System.Activities.WorkflowInvoker.InvokeAsync%2A> and <xref:System.Activities.WorkflowInvoker.BeginInvoke%2A>.  
  
### Setting Input Arguments of a Workflow  
 Data can be passed into a workflow using a dictionary of input parameters, keyed by argument name, that map to the input arguments of the workflow. In this example, a <xref:System.Activities.Statements.WriteLine> is invoked and the value for its <xref:System.Activities.Statements.WriteLine.Text%2A> argument is specified using the dictionary of input parameters.  
  
 [!code-csharp[CFX_WorkflowInvokerExample#3](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowinvokerexample/cs/program.cs#3)]  
  
### Retrieving Output Arguments of a Workflow  
 The output parameters of a workflow can be obtained using the outputs dictionary that is returned from the call to <xref:System.Activities.WorkflowInvoker.Invoke%2A>. The following example invokes a workflow consisting of a single `Divide` activity that has two input arguments and two output arguments. When the workflow is invoked, the `arguments` dictionary is passed which contains the values for each input argument, keyed by argument name. When the call to `Invoke` returns, each output argument is returned in the `outputs` dictionary, also keyed by argument name.  
  
 [!code-csharp[CFX_WorkflowInvokerExample#120](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowinvokerexample/cs/program.cs#120)]  
  
 [!code-csharp[CFX_WorkflowInvokerExample#20](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowinvokerexample/cs/program.cs#20)]  
  
 If the workflow derives from <xref:System.Activities.ActivityWithResult>, such as `CodeActivity<TResult>` or `Activity<TResult>`, and there are output arguments in addition to the well-defined <xref:System.Activities.Activity%601.Result%2A> output argument, a non-generic overload of `Invoke` must be used in order to retrieve the additional arguments. To do this, the workflow definition passed into `Invoke` must be of type <xref:System.Activities.Activity>. In this example the `Divide` activity derives from `CodeActivity<int>`, but is declared as <xref:System.Activities.Activity> so that a non-generic overload of `Invoke` is used which returns a dictionary of arguments instead of a single return value.  
  
 [!code-csharp[CFX_WorkflowInvokerExample#121](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowinvokerexample/cs/program.cs#121)]  
  
 [!code-csharp[CFX_WorkflowInvokerExample#21](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowinvokerexample/cs/program.cs#21)]  
  
## Using WorkflowApplication  
 <xref:System.Activities.WorkflowApplication> provides a rich set of features for workflow instance management. <xref:System.Activities.WorkflowApplication> acts as a thread safe proxy to the actual  <xref:System.Activities.Hosting.WorkflowInstance>, which encapsulates the runtime, and provides methods for creating and loading workflow instances, pausing and resuming, terminating, and notification of lifecycle events. To run a workflow using <xref:System.Activities.WorkflowApplication> you create the <xref:System.Activities.WorkflowApplication>, subscribe to any desired lifecycle events, start the workflow, and then wait for it to finish. In this example, a workflow definition that consists of a <xref:System.Activities.Statements.WriteLine> activity is created and a <xref:System.Activities.WorkflowApplication> is created using the specified workflow definition. <xref:System.Activities.WorkflowApplication.Completed%2A> is handled so the host is notified when the workflow completes, the workflow is started with a call to <xref:System.Activities.WorkflowApplication.Run%2A>, and then the host waits for the workflow to complete. When the workflow completes, the <xref:System.Threading.AutoResetEvent> is set and the host application can resume execution, as shown in the following example.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#31](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#31)]  
  
### WorkflowApplication Lifecycle Events  
 In addition to <xref:System.Activities.WorkflowApplication.Completed%2A>, host authors can be notified when a workflow is unloaded (<xref:System.Activities.WorkflowApplication.Unloaded%2A>), aborted (<xref:System.Activities.WorkflowApplication.Aborted%2A>), becomes idle (<xref:System.Activities.WorkflowApplication.Idle%2A> and <xref:System.Activities.WorkflowApplication.PersistableIdle%2A>), or an unhandled exception occurs (<xref:System.Activities.WorkflowApplication.OnUnhandledException%2A>). Workflow application developers can handle these notifications and take appropriate action, as shown in the following example.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#32](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#32)]  
  
### Setting Input Arguments of a Workflow  
 Data can be passed into a workflow as it is started using a dictionary of parameters, similar to the way data is passed in when using <xref:System.Activities.WorkflowInvoker>. Each item in the dictionary maps to an input argument of the specified workflow. In this example, a workflow that consists of a <xref:System.Activities.Statements.WriteLine> activity is invoked and its <xref:System.Activities.Statements.WriteLine.Text%2A> argument is specified using the dictionary of input parameters.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#30](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#30)]  
  
### Retrieving Output Arguments of a Workflow  
 When a workflow completes, any output arguments can be retrieved in the <xref:System.Activities.WorkflowApplication.Completed%2A> handler by accessing the <xref:System.Activities.WorkflowApplicationCompletedEventArgs.Outputs%2A?displayProperty=nameWithType> dictionary. The following example hosts a workflow using <xref:System.Activities.WorkflowApplication>. A <xref:System.Activities.WorkflowApplication> instance is constructed using using a workflow definition consisting of a single `DiceRoll` activity. The `DiceRoll` activity has two output arguments that represent the results of the dice roll operation. When the workflow completes, the outputs are retrieved in the <xref:System.Activities.WorkflowApplication.Completed%2A> handler.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#130](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#130)]  
  
 [!code-csharp[CFX_WorkflowApplicationExample#21](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#21)]  
  
> [!NOTE]
>  <xref:System.Activities.WorkflowApplication> and <xref:System.Activities.WorkflowInvoker> take a dictionary of input arguments and return a dictionary of `out` arguments. These dictionary parameters, properties, and return values are of type `IDictionary<string, object>`. The actual instance of the dictionary class that is passed in can be any class that implements `IDictionary<string, object>`. In these examples, `Dictionary<string, object>` is used. [!INCLUDE[crabout](../../../includes/crabout-md.md)] dictionaries, see <xref:System.Collections.Generic.IDictionary%602> and <xref:System.Collections.Generic.Dictionary%602>.  
  
### Passing Data into a Running Workflow Using Bookmarks  
 Bookmarks are the mechanism by which an activity can passively wait to be resumed and are a mechanism for passing data into a running workflow instance. If an activity is waiting for data, it can create a <xref:System.Activities.Bookmark> and register a callback method to be called when the <xref:System.Activities.Bookmark> is resumed, as shown in the following example.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#15](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#15)]  
  
 When executed, the `ReadLine` activity creates a <xref:System.Activities.Bookmark>, registers a callback, and then waits for the <xref:System.Activities.Bookmark> to be resumed. When it is resumed, the `ReadLine` activity assigns the data that was passed with the <xref:System.Activities.Bookmark> to its <xref:System.Activities.Activity%601.Result%2A> argument. In this example, a workflow is created that uses the `ReadLine` activity to gather the user’s name and display it to the console window.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#22](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#22)]  
  
 When the `ReadLine` activity is executed, it creates a <xref:System.Activities.Bookmark> named `UserName` and then waits for the bookmark to be resumed. The host collects the desired data and then resumes the <xref:System.Activities.Bookmark>. The workflow resumes, displays the name, and then completes.  
  
 The host application can inspect the workflow to determine if there are any active bookmarks. It can do this by calling the <xref:System.Activities.WorkflowApplication.GetBookmarks%2A> method of a <xref:System.Activities.WorkflowApplication> instance, or by inspecting the <xref:System.Activities.WorkflowApplicationIdleEventArgs> in the <xref:System.Activities.WorkflowApplication.Idle%2A> handler.  
  
 The following code example is like the previous example except that the active bookmarks are enumerated before the bookmark is resumed. The workflow is started, and once the <xref:System.Activities.Bookmark> is created and the workflow goes idle, <xref:System.Activities.WorkflowApplication.GetBookmarks%2A> is called. When the workflow is completed, the following output is displayed to the console.  
  
 **What is your name?**  
**BookmarkName: UserName - OwnerDisplayName: ReadLine**   
**Steve**   
**Hello, Steve**

[!code-csharp[CFX_WorkflowApplicationExample#14](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#14)]  
  
 The following code example inspects the <xref:System.Activities.WorkflowApplicationIdleEventArgs> passed into the <xref:System.Activities.WorkflowApplication.Idle%2A> handler of a <xref:System.Activities.WorkflowApplication> instance. In this example the workflow going idle has one <xref:System.Activities.Bookmark> with a name of `EnterGuess`, owned by an activity named `ReadInt`. This code example is based off of [How to: Run a Workflow](../../../docs/framework/windows-workflow-foundation/how-to-run-a-workflow.md), which is part of the [Getting Started Tutorial](../../../docs/framework/windows-workflow-foundation/getting-started-tutorial.md). If the <xref:System.Activities.WorkflowApplication.Idle%2A> handler in that step is modified to contain the code from this example, the following output is displayed.  
  
 **BookmarkName: EnterGuess - OwnerDisplayName: ReadInt**
 
 [!code-csharp[CFX_WorkflowApplicationExample#2](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#2)]  
  
## Summary  
 <xref:System.Activities.WorkflowInvoker> provides a lightweight way to invoke workflows, and although it provides methods for passing data in at the start of a workflow and extracting data from a completed workflow, it does not provide for more complex scenarios which is where <xref:System.Activities.WorkflowApplication> can be used.
