---
title: "Creating Asynchronous Activities in WF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 497e81ed-5eef-460c-ba55-fae73c05824f
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Creating Asynchronous Activities in WF
<xref:System.Activities.AsyncCodeActivity> provides activity authors a base class to use that enables derived activities to implement asynchronous execution logic. This is useful for custom activities that must perform asynchronous work without holding the workflow scheduler thread and blocking any activities that may be able to run in parallel. This topic provides an overview of how to create custom asynchronous activities using <xref:System.Activities.AsyncCodeActivity>.  
  
## Using AsyncCodeActivity  
 <xref:System.Activities?displayProperty=nameWithType> provides custom activity authors with different base classes for different activity authoring requirements. Each one carries a particular semantic and provides a workflow author (and the activity runtime) a corresponding contract. An <xref:System.Activities.AsyncCodeActivity> based activity is an activity that performs work asynchronously relative to the scheduler thread and whose execution logic is expressed in managed code. As a result of going asynchronous, an <xref:System.Activities.AsyncCodeActivity> may induce an idle point during execution. Due to the volatile nature of asynchronous work, an <xref:System.Activities.AsyncCodeActivity> always creates a no persist block for the duration of the activity’s execution. This prevents the workflow runtime from persisting the workflow instance in the middle of the asynchronous work, and also prevents the workflow instance from unloading while the asynchronous code is executing.  
  
### AsyncCodeActivity Methods  
 Activities that derive from <xref:System.Activities.AsyncCodeActivity> can create asynchronous execution logic by overriding the <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A> and <xref:System.Activities.AsyncCodeActivity.EndExecute%2A> methods with custom code. When called by the runtime, these methods are passed an <xref:System.Activities.AsyncCodeActivityContext>. <xref:System.Activities.AsyncCodeActivityContext> allows the activity author to provide shared state across <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A>/ <xref:System.Activities.AsyncCodeActivity.EndExecute%2A> in the context’s <xref:System.Activities.AsyncCodeActivityContext.UserState%2A> property. In the following example, a `GenerateRandom` activity generates a random number asynchronously.  
  
 [!code-csharp[CFX_ActivityExample#8](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#8)]  
  
 The previous example activity derives from <xref:System.Activities.AsyncCodeActivity%601>, and has an elevated `OutArgument<int>` named `Result`. The value returned by the `GetRandom` method is extracted and returned by the <xref:System.Activities.AsyncCodeActivity%601.EndExecute%2A> override, and this value is set as the `Result` value. Asynchronous activities that do not return a result should derive from <xref:System.Activities.AsyncCodeActivity>. In the following example, a `DisplayRandom` activity is defined which derives from <xref:System.Activities.AsyncCodeActivity>. This activity is like the `GetRandom` activity but instead of returning a result it displays a message to the console.  
  
 [!code-csharp[CFX_ActivityExample#11](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#11)]  
  
 Note that because there is no return value, `DisplayRandom` uses an <xref:System.Action> instead of a <xref:System.Func%602> to invoke its delegate, and the delegate returns no value.  
  
 <xref:System.Activities.AsyncCodeActivity> also provides a <xref:System.Activities.AsyncCodeActivity.Cancel%2A> override. While <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A> and <xref:System.Activities.AsyncCodeActivity.EndExecute%2A> are required overrides, <xref:System.Activities.AsyncCodeActivity.Cancel%2A> is optional, and can be overridden so the activity can clean up its outstanding asynchronous state when it is being canceled or aborted. If clean up is possible and `AsyncCodeActivity.ExecutingActivityInstance.IsCancellationRequested` is `true`, the activity should call <xref:System.Activities.AsyncCodeActivityContext.MarkCanceled%2A>. Any exceptions thrown from this method are fatal to the workflow instance.  
  
 [!code-csharp[CFX_ActivityExample#10](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#10)]  
  
### Invoking Asynchronous Methods on a Class  
 Many of the classes in the [!INCLUDE[dnprdnshort](../../../includes/dnprdnshort-md.md)] provide asynchronous functionality, and this functionality can be asynchronously invoked by using an <xref:System.Activities.AsyncCodeActivity> based activity. In the following example from the [Using AsyncOperationContext in an Activity](../../../docs/framework/windows-workflow-foundation/samples/using-asyncoperationcontext-in-an-activity-sample.md), an activity is created that asynchronously creates a file by using the <xref:System.IO.FileStream> class.  
  
 [!code-csharp[CFX_ActivityExample#12](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#12)]  
  
### Sharing State Between the BeginExecute and EndExecute Methods  
 In the previous example, the <xref:System.IO.FileStream> object that was created in <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A> was accessed in the <xref:System.Activities.AsyncCodeActivity.EndExecute%2A>. This is possible because the `file` variable was passed in the <xref:System.Activities.AsyncCodeActivityContext.UserState%2A?displayProperty=nameWithType> property in <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A>. This is the correct method for sharing state between <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A> and <xref:System.Activities.AsyncCodeActivity.EndExecute%2A>. It is incorrect to use a member variable in the derived class (`FileWriter` in this case) to share state between <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A> and <xref:System.Activities.AsyncCodeActivity.EndExecute%2A> because the activity object may be referenced by multiple activity instances. Attempting to use a member variable to share state can result in values from one <xref:System.Activities.ActivityInstance> overwriting or consuming values from another <xref:System.Activities.ActivityInstance>.  
  
### Accessing Argument Values  
 The environment of an <xref:System.Activities.AsyncCodeActivity> consists of the arguments defined on the activity. These arguments can be accessed from the <xref:System.Activities.AsyncCodeActivity.BeginExecute%2A>/<xref:System.Activities.AsyncCodeActivity.EndExecute%2A> overrides using the <xref:System.Activities.AsyncCodeActivityContext> parameter. The arguments cannot be accessed in the delegate, but the argument values or any other desired data can be passed in to the delegate using its parameters. In the following example, a random number-generating activity is defined that obtains the inclusive upper bound from its `Max` argument. The value of the argument is passed in to the asynchronous code when the delegate is invoked.  
  
 [!code-csharp[CFX_ActivityExample#9](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#9)]  
  
### Scheduling Actions or Child Activities Using AsyncCodeActivity  
 <xref:System.Activities.AsyncCodeActivity> derived custom activities  provide a method for performing work asynchronously with regard to the workflow thread, but do not provide the ability to schedule child activities or actions. However, asynchronous behavior can be incorporated with scheduling of child activities through composition. An asynchronous activity can be created, and then composed with an <xref:System.Activities.Activity> or <xref:System.Activities.NativeActivity> derived activity to provide asynchronous behavior and scheduling of child activities or actions. For example, an activity could be created that derives from <xref:System.Activities.Activity>, and has as its implementation a <xref:System.Activities.Statements.Sequence> containing the asynchronous activity as well the other activities that implement the logic of the activity. For more examples of composing activities using <xref:System.Activities.Activity> and <xref:System.Activities.NativeActivity>, see [How to: Create an Activity](../../../docs/framework/windows-workflow-foundation/how-to-create-an-activity.md), [Activity Authoring Options](../../../docs/framework/windows-workflow-foundation/activity-authoring-options-in-wf.md), and the [Composite](../../../docs/framework/windows-workflow-foundation/samples/composite.md) activity samples.  
  
## See Also  
 <xref:System.Action>  
 <xref:System.Func%602>  
 [Using AsyncOperationContext in an Activity](../../../docs/framework/windows-workflow-foundation/samples/using-asyncoperationcontext-in-an-activity-sample.md)
