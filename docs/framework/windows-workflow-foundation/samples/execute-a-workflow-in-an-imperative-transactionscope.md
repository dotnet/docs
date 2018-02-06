---
title: "Execute a Workflow in an Imperative TransactionScope"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bd0e8686-c1d0-4400-a541-da94ed03afc7
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Execute a Workflow in an Imperative TransactionScope
This sample shows how to execute a workflow using <xref:System.Activities.WorkflowInvoker> under a <xref:System.Transactions.Transaction> from imperative C# code.  
  
## Sample Details  
 In imperative C# code, the <xref:System.Transactions.TransactionScope> is used to encapsulate a set of work that executes under the same transaction. The <xref:System.Transactions.TransactionScope> works by creating an ambient transaction and initializing the <xref:System.Transactions.Transaction.Current%2A> property, which can then be accessed by any work being executed on that thread.  
  
 To get equivalent behavior in workflow, the runtime has to do the extra work of initializing <xref:System.Transactions.Transaction.Current%2A> before executing each activity because a workflow does not maintain thread affinity between activities. With this runtime support, the resulting behavior is that when executing a workflow with <xref:System.Activities.WorkflowInvoker> inside a <xref:System.Transactions.TransactionScope>, all activities are guaranteed to run under the context of the ambient transaction created by the <xref:System.Transactions.TransactionScope>.  
  
 A workflow can have only a single ambient transaction for each workflow instance; nested transactions are not available. Even if the workflow contains a <xref:System.Activities.Statements.TransactionScope> activity, this does not create a new inner transaction. Instead, this reuses the ambient transaction that was created outside the workflow.  
  
 The sample begins a new <xref:System.Transactions.TransactionScope>, prints the transaction ID and begins a workflow using <xref:System.Activities.WorkflowInvoker>. The workflow prints the transaction ID again, showing that it is the same transaction, then runs a <xref:System.Activities.Statements.TransactionScope>, then completes. The <xref:System.Activities.WorkflowInvoker.Invoke%2A> call on <xref:System.Activities.WorkflowInvoker> is synchronous so the original thread blocks until the workflow completes. Once the workflow is complete, the transaction is completed and resources disposed.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the ImperativeTransactionSample.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Transactions\ImperativeTransaction`