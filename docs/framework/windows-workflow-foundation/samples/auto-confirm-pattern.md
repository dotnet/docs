---
title: "Auto-Confirm Pattern"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 668aec65-78d3-4636-9c7b-deed643a18f9
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Auto-Confirm Pattern
This sample consists of three scenarios that run illustrating a custom `AutoConfirmScope` activity. The first sample shows the successful execution of a sequence of four compensable activities where the second and third are nested in an `AutoConfirmScope`. The second sample shows the same sequence with an exception occurring after the execution of the fourth <xref:System.Activities.Statements.CompensableActivity>. The third scenario shows the same sequence with an exception occurring in the `AutoConfirmScope` after the second <xref:System.Activities.Statements.CompensableActivity> completes.  
  
 The sample demonstrates the auto-confirm pattern where all child compensable activities are confirmed upon successful completion of the scope. This pattern defines the lifetime of all child compensable activities, as they can no longer be compensated or confirmed.  
  
 The scope consists of a <xref:System.Activities.Statements.TryCatch> where the <xref:System.Activities.Statements.TryCatch.Try%2A> is an internal <xref:System.Activities.Statements.CompensableActivity>. The user-specified body of the `AutoConfirmScope` is the body of the inner <xref:System.Activities.Statements.CompensableActivity>. When this internal <xref:System.Activities.Statements.CompensableActivity> completes, it produces a <xref:System.Activities.Statements.CompensationToken> as an out-argument. The `AutoConfirmScope` uses a <xref:System.Activities.Statements.TryCatch.Finally%2A> to check whether the token has been produced and if it has then it confirms the inner <xref:System.Activities.Statements.CompensableActivity>. The inner <xref:System.Activities.Statements.CompensableActivity> invokes the default compensation for any compensable activities that may exist in its body.  
  
 The first scenario shows successful execution of the workflow and demonstrates that the second and third compensable activities are already confirmed when the workflow completes and the first and fourth are confirmed. This produces a confirmation order of three, two, four, and one.  
  
 The second scenario shows an exception after the four compensable activities have completed. Because compensable activities two and three are already confirmed they are unaffected but one and four are compensated. This produces confirm three, confirm two, compensate four and compensate one.  
  
 The final scenario shows unsuccessful execution of the `AutoConfirmScope`. In this scenario, an exception occurs after the completion of the second <xref:System.Activities.Statements.CompensableActivity>. Because the third and fourth compensable activities have not executed, they are unaffected. Because the scope did not complete successfully, the second <xref:System.Activities.Statements.CompensableActivity> does not get confirmed. This produces and compensation order of two then one.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the AutoConfirmSample.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Compensation\AutoConfirm`