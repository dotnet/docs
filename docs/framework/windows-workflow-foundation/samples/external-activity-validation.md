---
title: "External Activity Validation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 49619f59-9819-484a-bcd8-5596308e8551
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# External Activity Validation
This sample shows how to add validation logic to a built-in activity that you are not the author of. The validation logic consists of enforcing that all <xref:System.Activities.Statements.If> activities present in the workflow either have their <xref:System.Activities.Statements.If.Then%2A> property set or their <xref:System.Activities.Statements.If.Else%2A> property set. Also, the validation logic includes checking that all <xref:System.Activities.Statements.Pick> activities present in the workflow have more than one branch, and if that is not the case, a warning is generated.  
  
## Sample details  
 This sample creates a workflow with an instance of each activity to validate: the <xref:System.Activities.Statements.If> activity and the <xref:System.Activities.Statements.Pick> activity. A <xref:System.Activities.Validation.Constraint> is created for each validation behavior. The constraints created in this sample are `ConstraintError_IfShouldHaveThenOrElse` and `ConstraintWarning_PickHasOneBranch`. Next, these constraints are added to the `AdditionalConstraints` collection of a <xref:System.Activities.Validation.ValidationSettings> instance. Finally, the `static`<xref:System.Activities.Validation.ActivityValidationServices.Validate%2A> method of <xref:System.Activities.Validation.ActivityValidationServices> is called to validate the activities in the workflow and the validation results are printed out to the console.  
  
> [!NOTE]
>  You can add policy constraints to any activity. For example, you can add a policy constraint to a <xref:System.Activities.Statements.Sequence> or <xref:System.Activities.Statements.Parallel> activity.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the ExternalActivityValidation.sln file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press Ctrl+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Validation\ExternalActivityValidation`