---
title: "Windows Workflow Architecture"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1d4c6495-d64a-46d0-896a-3a01fac90aa9
caps.latest.revision: 20
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Windows Workflow Architecture
[!INCLUDE[wf](../../../includes/wf-md.md)] raises the abstraction level for developing interactive long-running applications. Units of work are encapsulated as activities. Activities run in an environment that provides facilities for flow control, exception handling, fault propagation, persistence of state data, loading and unloading of in-progress workflows from memory, tracking, and transaction flow.  
  
## Activity Architecture  
 Activities are developed as CLR types that derive from either <xref:System.Activities.Activity>, <xref:System.Activities.CodeActivity>, <xref:System.Activities.AsyncCodeActivity>, or <xref:System.Activities.NativeActivity>, or their variants that return a value, <xref:System.Activities.Activity%601>, <xref:System.Activities.CodeActivity%601>, <xref:System.Activities.AsyncCodeActivity%601>, or <xref:System.Activities.NativeActivity%601>. Developing activities that derive from <xref:System.Activities.Activity> allows the user to assemble pre-existing activities to quickly create units of work that execute in the workflow environment. <xref:System.Activities.CodeActivity>, on the other hand, enables execution logic to be authored in managed code using <xref:System.Activities.CodeActivityContext> primarily for access to activity arguments. <xref:System.Activities.AsyncCodeActivity> is similar to <xref:System.Activities.CodeActivity> except that it can be used to implement asynchronous tasks. Developing activities that derive from <xref:System.Activities.NativeActivity> allows users to access the runtime through the <xref:System.Activities.NativeActivityContext> for functionality like scheduling children, creating bookmarks, invoking asynchronous work, registering transactions, and more.  
  
 Authoring activities that derive from <xref:System.Activities.Activity> is declarative and these activities can be authored in XAML. In the following example, an activity called `Prompt` is created using other activities for the execution body.  
  
```xml  
<Activity x:Class='Prompt'  
  xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'  
    xmlns:z='http://schemas.microsoft.com/netfx/2008/xaml/schema'  
xmlns:my='clr-namespace:XAMLActivityDefinition;assembly=XAMLActivityDefinition'  
xmlns:s="clr-namespace:System;assembly=mscorlib"  
xmlns="http://schemas.microsoft.com/2009/workflow">  
<z:SchemaType.Members>  
    <z:SchemaType.SchemaProperty Name='Text' Type=' InArgument(s:String)' />  
  <z:SchemaType.SchemaProperty Name='Response' Type='OutArgument(s:String)' />  
</z:SchemaType.Members>  
  <Sequence>  
    <my:WriteLine Text='[Text]' />  
    <my:ReadLine BookmarkName='r1' Result='[Response]' />  
  </Sequence>  
</Activity>  
```  
  
## Activity Context  
 The <xref:System.Activities.ActivityContext> is the activity author's interface to the workflow runtime and provides access to the runtime's wealth of features. In the following example, an activity is defined that uses the execution context to create a bookmark (the mechanism that allows an activity to register a continuation point in its execution that can be resumed by a host passing data into the activity).  
  
 [!code-csharp[CFX_WorkflowApplicationExample#15](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#15)]  
  
## Activity Life Cycle  
 An instance of an activity starts out in the <xref:System.Activities.ActivityInstanceState.Executing> state. Unless exceptions are encountered, it remains in this state until all child activities are finished executing and any other pending work (<xref:System.Activities.Bookmark> objects, for instance) is completed, at which point it transitions to the <xref:System.Activities.ActivityInstanceState.Closed> state. The parent of an activity instance can request a child to cancel; if the child is able to be canceled it completes in the <xref:System.Activities.ActivityInstanceState.Canceled> state. If an exception is thrown during execution, the runtime puts the activity into the <xref:System.Activities.ActivityInstanceState.Faulted> state and propagates the exception up the parent chain of activities. Following are the three completion states of an activity:  
  
-   **Closed:** The activity has completed its work and exited.  
  
-   **Canceled:** The activity has gracefully abandoned its work and exited. Work is not explicitly rolled back when this state is entered.  
  
-   **Faulted:** The activity has encountered an error and has exited without completing its work.  
  
 Activities remain in the <xref:System.Activities.ActivityInstanceState.Executing> state when they are persisted or unloaded.
