---
title: "Constraint Types"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b6b246e6-1130-4698-9625-c5c42abcbfed
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Constraint Types
This sample shows two different ways to apply constraints to a workflow, one is from inside the activity (build) and one is from outside of it (policy). In this scenario, an activity author (from a 3rth-party software company) wants to validate the relationship between two arguments. In this case, the cost should be smaller than or equal to the price. This is a general validation build constraint.  
  
 Then a shop owner wants to add some validation to this generic activity. In his case, he wants the majority of its products to be $9.99 or less. So, he uses a policy constraint that is on top of the `CreateProduct` activity.  
  
 In the sample:  
  
 The activity author (build) must:  
  
-   Create a constraint (`PriceGreaterThanCost`). This is where all the validation logic resides.  
  
-   Override `System.Activities.CodeActivity.OnGetConstraints()` and add the constraint (`PriceGreaterThanCost`) to the constraints <xref:System.Collections.IList>.  
  
 The workflow author (policy) must:  
  
-   Create a workflow with an instance of the activity to validate (`CreateProduct`).  
  
-   Create a constraint (`MaxPrice`).  
  
-   Create a <xref:System.Activities.Validation.ValidationSettings> instance (`validationSettings`) and add the constraint (`MaxPrice`) to the collection `AdditionalConstraints`. Here the workflow author can add policy constraints to any activity, such as a sequence or parallel.  
  
-   Call <xref:System.Activities.Validation.ActivityValidationServices.Validate%2A>, which returns a <xref:System.Activities.Validation.ValidationResults> collection of <xref:System.Activities.Validation.ValidationError> objects.  
  
-   (Optional) Print the <xref:System.Activities.Validation.ValidationError> objects.  
  
### To set up, build, and run the sample  
  
1.  Open the ConstraintTypes.sln sample solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Build and run the solution.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Validation\ConstraintLibrary`