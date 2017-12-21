---
title: "Confirmation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8637aeaf-ac9e-49b8-93f4-da15dee45277
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Confirmation
This sample shows four common scenarios surrounding the use of <xref:System.Activities.Statements.CompensableActivity> and confirmation. The sample runs four workflows to show confirmation. This sample is available in declarative and imperative versions.  
  
## Confirm a Compensable Activity  
 The first workflow demonstrates how to confirm a compensable activity and consists of a sequence of two <xref:System.Activities.Statements.CompensableActivity> instances. After the completion of the second <xref:System.Activities.Statements.CompensableActivity> a confirm activity confirms the first activity. When the workflow successfully completes, all <xref:System.Activities.Statements.CompensableActivity> instances that have not been confirmed or compensated are automatically confirmed using the default order. Without the confirm, the second <xref:System.Activities.Statements.CompensableActivity> would have been confirmed first.  
  
## Explicit Compensation  
 The second scenario shows the affect on default confirmation when a <xref:System.Activities.Statements.CompensableActivity> is explicitly compensated. The workflow consists of a sequence of two <xref:System.Activities.Statements.CompensableActivity> activities, after the second completes the first is explicitly compensated. As a result when the workflow, completes only the second <xref:System.Activities.Statements.CompensableActivity> is confirmed.  
  
## Controlling the Order of Confirmation for Nested CompensableActivity Activities  
 The third scenario shows how to control the order of confirmation for nested <xref:System.Activities.Statements.CompensableActivity>. The scenario consists of a <xref:System.Activities.Statements.CompensableActivity> as the root of the workflow. The body of the root <xref:System.Activities.Statements.CompensableActivity> is a sequence of three <xref:System.Activities.Statements.CompensableActivity>. The <xref:System.Activities.Statements.CompensableActivity.ConfirmationHandler%2A> for the root <xref:System.Activities.Statements.CompensableActivity> is a sequence that specifies to confirm the first then the second nested <xref:System.Activities.Statements.CompensableActivity>. When the workflow completes it confirms the root <xref:System.Activities.Statements.CompensableActivity>, which then confirms the first, second and third nested <xref:System.Activities.Statements.CompensableActivity>, in that order. As a result, the default confirmation order is essentially reversed. Because the third <xref:System.Activities.Statements.CompensableActivity> was not explicitly confirmed as part of the root <xref:System.Activities.Statements.CompensableActivity> by the <xref:System.Activities.Statements.CompensableActivity.ConfirmationHandler%2A>, it is confirmed according to the default order. However, because it is the only unconfirmed <xref:System.Activities.Statements.CompensableActivity> this just means it is confirmed.  
  
## Scoping of Variables  
 The fourth scenario shows how the lifetime of variables defined for a <xref:System.Activities.Statements.CompensableActivity> or one of their parents are still in scope when the <xref:System.Activities.Statements.CompensableActivity.CompensationHandler%2A>, <xref:System.Activities.Statements.CompensableActivity.ConfirmationHandler%2A> or <xref:System.Activities.Statements.CompensableActivity.CancellationHandler%2A> handlers are executed even if the activity has completed or the workflow has completed. The workflow consists of a sequence of two <xref:System.Activities.Statements.CompensableActivity>. In the body of the first, the variable `mySum` is set to the sum of 5 and 10 and the result printed. In the body of the second <xref:System.Activities.Statements.CompensableActivity>, the sum is set to the sum of the existing sum and 7 and the result printed. A custom confirmation handler is defined for the first <xref:System.Activities.Statements.CompensableActivity>, which prints the sum, subtracts 7 and prints the sum again. It is clear by inspecting the printed sums that the variable is in scope not only for the bodies of both <xref:System.Activities.Statements.CompensableActivity> but the <xref:System.Activities.Statements.CompensableActivity.ConfirmationHandler%2A> as well.  
  
#### To run the sample  
  
1.  Load the solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Run the ConfirmationSample.exe application.  
  
3.  Observe the following output:  
  
 **Explicit confirmation:Start of workflowCompensableActivity1: BodyCompensableActivity2: BodyCompensableActivity1: Confirmation HandlerEnd of workflowCompensableActivity2: Confirmation HandlerExplicit compensation:Start of workflowCompensableActivity1: BodyCompensableActivity2: BodyCompensableActivity1: Compensation HandlerEnd of workflowCompensableActivity2: Confirmation HandlerCustom confirmation handler:Start of workflowCompensableActivity1: BodyCompensableActivity2: BodyCompensableActivity3: BodyEnd of workflowCompensableActivity1: Confirmation HandlerCompensableActivity2: Confirmation HandlerCompensableActivity3: Confirmation HandlerVariable access in a confirmation handler:Start of workflowCompensableActivity1: BodyCompensableActivity1: The sum is: 15CompensableActivity2: BodyCompensableActivity2: Adding 7 to the sumCompensableActivity2: The sum is now: 22End of workflowCompensableActivity2: Confirmation HandlerCompensableActivity1: Confirmation HandlerCompensableActivity2: The sum is: 22CompensableActivity2: After subtracting 12 the sum is now: 10Press ENTER to exit.**  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Compensation\Confirmation`