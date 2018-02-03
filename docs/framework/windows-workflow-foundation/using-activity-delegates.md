---
title: "Using Activity Delegates"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e33cf876-8979-440b-9b23-4a12d1139960
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Activity Delegates
Activity delegates enable activity authors to expose callbacks with specific signatures, for which users of the activity can provide activity-based handlers. Two types of activity delegates are available: <xref:System.Activities.ActivityAction%601> is used to define activity delegates that do not have a return value, and <xref:System.Activities.ActivityFunc%601> is used to define activity delegates that do have a return value.  
  
 Activity delegates are useful in scenarios where a child activity must be constrained to having a certain signature. For example, a <xref:System.Activities.Statements.While> activity can contain any type of child activity with no constraints, but the body of a <xref:System.Activities.Statements.ForEach%601> activity is an <xref:System.Activities.ActivityAction%601>, and the child activity that is ultimately executed by <xref:System.Activities.Statements.ForEach%601> must have an <xref:System.Activities.InArgument%601> that is the same type of the members of the collection that the <xref:System.Activities.Statements.ForEach%601> enumerates.  
  
## Using ActivityAction  
 Several [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] activities use activity actions, such as the <xref:System.Activities.Statements.Catch> activity and the <xref:System.Activities.Statements.ForEach%601> activity. In each case, the activity action represents a location where the workflow author specifies an activity to provide the desired behavior when composing a workflow using one of these activities. In the following example, a <xref:System.Activities.Statements.ForEach%601> activity is used to display text to the console window. The body of the <xref:System.Activities.Statements.ForEach%601> is specified by using an <xref:System.Activities.ActivityAction%601> that matches the type of the <xref:System.Activities.Statements.ForEach%601> which is string. The <xref:System.Activities.Statements.WriteLine> activity specified in the <xref:System.Activities.ActivityDelegate.Handler%2A> has its <xref:System.Activities.Statements.WriteLine.Text%2A> argument bound to the string values in the collection that the <xref:System.Activities.Statements.ForEach%601> activity iterates.  
  
 [!code-csharp[CFX_ActivityExample#6](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#6)]  
  
 The actionArgument is used to flow the individual items in the collection to the WriteLine. When the workflow is invoked, the following output is displayed to the console.  
 ``` 
 HelloWorld.
 ```  
The examples in this topic use object initialization syntax. Object initialization syntax can be a useful way to create workflow definitions in code because it provides a hierarchical view of the activities in the workflow and shows the relationship between the activities. There is no requirement to use object initialization syntax when you programmatically create workflows. The following example is functionally equivalent to the previous example.  
  
 [!code-csharp[CFX_ActivityExample#7](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#7)]  
  
 [!INCLUDE[crabout](../../../includes/crabout-md.md)] object initializers, see [How to: Initialize Objects without Calling a Constructor (C# Programming Guide)](http://go.microsoft.com/fwlink/?LinkId=161015) and [How to: Declare an Object by Using an Object Initializer](http://go.microsoft.com/fwlink/?LinkId=161016).  
  
 In the following example, a <xref:System.Activities.Statements.TryCatch> activity is used in a workflow. An <xref:System.ApplicationException> is thrown by the workflow, and is handled by a <xref:System.Activities.Statements.Catch%601> activity. The handler for the <xref:System.Activities.Statements.Catch%601> activity's activity action is a <xref:System.Activities.Statements.WriteLine> activity, and the exception detail is flowed through to it using the `ex` <xref:System.Activities.DelegateInArgument%601>.  
  
 [!code-csharp[CFX_WorkflowApplicationExample#33](../../../samples/snippets/csharp/VS_Snippets_CFX/cfx_workflowapplicationexample/cs/program.cs#33)]  
  
 When creating a custom activity that defines an <xref:System.Activities.ActivityAction%601>, use an <xref:System.Activities.Statements.InvokeAction%601> to model the invocation of that <xref:System.Activities.ActivityAction%601>. In this example, a custom `WriteLineWithNotification` activity is defined. This activity is composed of a <xref:System.Activities.Statements.Sequence> that contains a <xref:System.Activities.Statements.WriteLine> activity followed by an <xref:System.Activities.Statements.InvokeAction%601> that invokes an <xref:System.Activities.ActivityAction%601> that takes one string argument.  
  
 [!code-csharp[CFX_ActivityExample#1](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#1)]  
  
 When a workflow is created by using the `WriteLineWithNotification` activity, the workflow author specifies the desired custom logic in the activity action’s <xref:System.Activities.ActivityDelegate.Handler%2A>. In this example, a workflow is created that use the `WriteLineWithNotification` activity, and a <xref:System.Activities.Statements.WriteLine> activity is used as the <xref:System.Activities.ActivityDelegate.Handler%2A>.  
  
 [!code-csharp[CFX_ActivityExample#2](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#2)]  
  
 There are multiple generic versions of <xref:System.Activities.Statements.InvokeAction%601> and <xref:System.Activities.ActivityAction%601> provided for passing one or more arguments.  
  
## Using ActivityFunc  
 <xref:System.Activities.ActivityAction%601> is useful when there is no result value from the activity, and <xref:System.Activities.ActivityFunc%601> is used when a result value is returned. When creating a custom activity that defines an <xref:System.Activities.ActivityFunc%601>, use an <xref:System.Activities.Expressions.InvokeFunc%601> to model the invocation of that <xref:System.Activities.ActivityFunc%601>. In the following example, a `WriteFillerText` activity is defined. To supply the filler text, an <xref:System.Activities.Expressions.InvokeFunc%601> is specified that takes an integer argument and has a string result. Once the filler text is retrieved, it is displayed to the console using a <xref:System.Activities.Statements.WriteLine> activity.  
  
 [!code-csharp[CFX_ActivityExample#3](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#3)]  
  
 To supply the text, an activity must be used that takes one `int` argument and has a string result. This example shows a `TextGenerator` activity that meets these requirements.  
  
 [!code-csharp[CFX_ActivityExample#4](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#4)]  
  
 To use the `TextGenerator` activity with the `WriteRandomText` activity, specify it as the <xref:System.Activities.ActivityDelegate.Handler%2A>.  
  
 [!code-csharp[CFX_ActivityExample#5](../../../samples/snippets/csharp/VS_Snippets_CFX/CFX_ActivityExample/cs/Program.cs#5)]  
  
## See Also  
 [Exposing and Invoking ActivityActions](../../../docs/framework/windows-workflow-foundation/samples/exposing-and-invoking-activityactions.md)
