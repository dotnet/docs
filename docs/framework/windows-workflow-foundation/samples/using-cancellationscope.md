---
title: "Using CancellationScope"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 39c5c338-b316-43d6-b7fe-a543281dd1ec
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using CancellationScope
This sample demonstrates how to use the <xref:System.Activities.Statements.CancellationScope> activity to cancel work in an application.  
  
 Many middle tier components and services rely on the well-known programming construct of transactions to handle cancellation for them.  However, there are many situations in which work that cannot be done in a transaction must be canceled.  Using cancellation is more difficult than using transactions, because work that must be canceled must first be tracked. [!INCLUDE[netfx_current_short](../../../../includes/netfx-current-short-md.md)] helps you with this by providing a <xref:System.Activities.Statements.CancellationScope> activity.  
  
 Cancellation can be triggered either from within an activity or from the activity's parent.  Child activities are scheduled by their parent activity (such as a <xref:System.Activities.Statements.Sequence>, <xref:System.Activities.Statements.Parallel>, <xref:System.Activities.Statements.Flowchart>, or a custom composite activity).  The parent activity can cancel child activities for any reason.  For example, a <xref:System.Activities.Statements.Parallel> activity with three child branches will cancel the remaining child branches whenever it completes a branch and the <xref:System.Activities.Statements.Parallel.CompletionCondition%2A> expression evaluates to `true`. The workflow can also be canceled externally by the host application by calling <xref:System.Activities.WorkflowApplication.Cancel%2A>.  
  
 To use the <xref:System.Activities.Statements.CancellationScope> activity, put the work that needs to be canceled into the <xref:System.Activities.Statements.CancellationScope.Body%2A> property, and put the work that is performed after cancellation into the <xref:System.Activities.Statements.CancellationScope.CancellationHandler%2A> property.  
  
 This sample demonstrates cancelling an activity from within the activity itself.  
  
 The scenario that the sample uses to demonstrate the <xref:System.Activities.Statements.CancellationScope> activity is a client wanting to buy a ticket to Miami as soon as possible. There are two travel agencies that want the business. The sample uses two <xref:System.Activities.Statements.CancellationScope> within a <xref:System.Activities.Statements.Parallel> activity to model this business logic. The <xref:System.Activities.Statements.Parallel.CompletionCondition%2A> of the <xref:System.Activities.Statements.Parallel> activity is set to `true`; since the <xref:System.Activities.Statements.Parallel.CompletionCondition%2A> is checked after any branch completes, this will cause the remaining branch to be canceled after the first branch completes. The client application asks both agencies to buy the ticket, and when the first one confirms that the ticket has been bought, the application cancels the order at the other agency.  
  
## To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the CancelationScopeXAML.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Built-InActivities\CancellationScope`