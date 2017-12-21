---
title: "Basic TransactionScope"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1e22b76a-76de-43b4-9be7-7a86ed3d5a44
caps.latest.revision: 13
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Basic TransactionScope
This sample consists of four scenarios that run showing how to nest <xref:System.Activities.Statements.TransactionScope> instances. The first scenario shows nesting a 3rd party activity of which the author has no knowledge of the construction. The second and third scenarios show how time-outs are respected and the final scenario shows the <xref:System.Activities.Statements.TransactionScope.AbortInstanceOnTransactionFailure%2A> setting.  
  
## Nesting of TransactionScopeActivity  
 The workflow for the first scenario consists of a sequence of two <xref:System.Activities.Statements.WriteLine> activities and a <xref:System.Activities.Statements.TransactionScope>. The body of the <xref:System.Activities.Statements.TransactionScope> is a sequence of two more <xref:System.Activities.Statements.WriteLine> activities, a custom activity that prints the local identifier of the transaction and a third party activity. The third party activity `TransactionScopeTest` contains a <xref:System.Activities.Statements.TransactionScope> although the workflow author has no way of knowing. This scenario shows that <xref:System.Activities.Statements.TransactionScope> activities can be nested.  
  
## Time-Outs  
 The workflow for the second scenario is nearly identical to the first. The `TransactionScopeTest` has been replaced with a <xref:System.Activities.Statements.TransactionScope>. The body of the <xref:System.Activities.Statements.TransactionScope> is a five-second delay and the time-out for the transaction is set to two seconds. The time-out for the outer <xref:System.Activities.Statements.TransactionScope> is set to 10 seconds. Note that the smallest time-out in scope is respected and the transaction times out.  
  
 The workflow for the third scenario is nearly identical to scenario two. The delay activity has been moved from the body of the inner <xref:System.Activities.Statements.TransactionScope> to immediately after it in the sequence that is the body of the outer <xref:System.Activities.Statements.TransactionScope>. The transaction still times out but because the two second time-out of the inner <xref:System.Activities.Statements.TransactionScope> no longer applies. The transaction times out at 10 seconds when the outer <xref:System.Activities.Statements.TransactionScope> time-out is exceeded.  
  
## Aborting on Transaction Failure  
 This workflow is similar to scenario three except the time-outs have been replaced by the <xref:System.Activities.Statements.TransactionScope.AbortInstanceOnTransactionFailure%2A> property. Note that the flags of all inner children, if set, must match the outer <xref:System.Activities.Statements.TransactionScope>. In this scenario, they do not and an exception is thrown when the workflow opens.  
  
#### To run the sample  
  
1.  Open the BasicTransactionScopeSample.sln solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  To build the solution, press CTRL+SHIFT+B or select **Build Solution** from the **Build** menu.  
  
3.  Once the build has succeeded, press F5 or select **Start Debugging** from the **Debug** menu. Alternatively you can press CTRL+F5 or select **Start Without Debugging** from the **Debug** menu to run without debugging.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Transactions\BasicTransactionScope`