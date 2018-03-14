---
title: "Custom Composite using Native Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ef9e739c-8a8a-4d11-9e25-cb42c62e3c76
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Custom Composite using Native Activity
This sample demonstrates how to write a <xref:System.Activities.NativeActivity> that schedules other <xref:System.Activities.Activity> objects to control the flow of a workflow’s execution. This sample uses two common control flows, Sequence and While, to demonstrate how to do this.  
  
## Sample Details  
 Starting with `MySequence`, the first thing to notice is that it derives from <xref:System.Activities.NativeActivity>. <xref:System.Activities.NativeActivity> is the <xref:System.Activities.Activity> object that exposes the full breadth of the workflow runtime through the <xref:System.Activities.NativeActivityContext> passed to the `Execute` method.  
  
 `MySequence` exposes a public collection of <xref:System.Activities.Activity> objects that gets populated by the workflow author. Before the workflow is executed, the workflow runtime calls the <xref:System.Activities.Activity.CacheMetadata%2A> method on each activity in a workflow. During this process, the runtime establishes parent-child relationships for data scoping and lifetime management. The default implementation of the <xref:System.Activities.Activity.CacheMetadata%2A> method uses the <xref:System.ComponentModel.TypeDescriptor> instance class for the `MySequence` activity to add any public property of type <xref:System.Activities.Activity> or <xref:System.Collections.IEnumerable>\<<xref:System.Activities.Activity>> as children of the `MySequence` activity.  
  
 Whenever an activity exposes a public collection of child activities, it is likely those child activities share state. It is a best practice for the parent activity, in this case `MySequence`, to also expose a collection of variables through which the child activities can accomplish this. Like child activities, the <xref:System.Activities.Activity.CacheMetadata%2A> method adds public properties of type <xref:System.Activities.Variable> or <xref:System.Collections.IEnumerable>\<<xref:System.Activities.Variable>> as variables associated with the `MySequence` activity.  
  
 Besides the public variables, which are manipulated by the children of `MySequence`, `MySequence` must also keep track of where it is in the execution of its children. It uses a private variable, `currentIndex`, to accomplish this. This variable is registered as part of the `MySequence` environment by adding a call to the <xref:System.Activities.NativeActivityMetadata.AddImplementationVariable%2A> method within the `MySequence` activity’s <xref:System.Activities.Activity.CacheMetadata%2A> method. The <xref:System.Activities.Activity> objects added to the `MySequence` `Activities` collection cannot access variables added this way.  
  
 When `MySequence` is executed by the runtime, the runtime calls its <xref:System.Activities.NativeActivity.Execute%2A> method, passing in an <xref:System.Activities.NativeActivityContext>. The <xref:System.Activities.NativeActivityContext> is the activity’s proxy back into the runtime for dereferencing arguments and variables as well as scheduling other <xref:System.Activities.Activity> objects, or `ActivityDelegates`. `MySequence` uses an `InternalExecute` method to encapsulate the logic of scheduling the first child and all subsequent children in a single method. It starts by dereferencing the `currentIndex`. If it is equal to the count in the `Activities` collection, then the sequence is finished, the activity returns without scheduling any work and the runtime moves it into the <xref:System.Activities.ActivityInstanceState.Closed> state. If the `currentIndex` is less than the count of activities, the next child is obtained from the `Activities` collection and `MySequence` calls <xref:System.Activities.NativeActivityContext.ScheduleActivity%2A>, passing in the child to be scheduled and a <xref:System.Activities.CompletionCallback> that points at the `InternalExecute` method. Finally, the `currentIndex` is incremented and control is yielded back to the runtime. As long as an instance of `MySequence` has a child <xref:System.Activities.Activity> object scheduled, the runtime considers it to be in the Executing state.  
  
 When the child activity completes, the <xref:System.Activities.CompletionCallback> is executed. The loop continues from the top. Like `Execute`, a <xref:System.Activities.CompletionCallback> takes an <xref:System.Activities.NativeActivityContext>, giving the implementer access to the runtime.  
  
 `MyWhile` differs from `MySequence` in that it schedules a single <xref:System.Activities.Activity> object repeatedly, and in that it uses a <xref:System.Activities.Activity%601><bool\> named `Condition` to determine whether this scheduling should occur. Like `MySequence`, `MyWhile` uses an `InternalExecute` method to centralize its scheduling logic. It schedules the `Condition`<xref:System.Activities.Activity><bool\> with a <xref:System.Activities.CompletionCallback%601>\<bool> named `OnEvaluationCompleted`. When the execution of `Condition` is completed, its result becomes available through this <xref:System.Activities.CompletionCallback> in a strongly-typed parameter named `result`. If `true`, `MyWhile` calls  <xref:System.Activities.NativeActivityContext.ScheduleActivity%2A>, passing in the `Body`<xref:System.Activities.Activity> object and `InternalExecute` as the <xref:System.Activities.CompletionCallback>. When the execution of `Body` completes, `Condition` gets scheduled again in `InternalExecute`, starting the loop over again. When the `Condition` returns `false`, an instance of `MyWhile` gives control back to the runtime without scheduling the `Body` and the runtime moves it to the <xref:System.Activities.ActivityInstanceState.Closed> state.  
  
#### To set up, build, and run the sample  
  
1.  Open the Composite.sln sample solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Build and run the solution.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\CustomActivities\Code-Bodied\CustomCompositeNativeActivity`