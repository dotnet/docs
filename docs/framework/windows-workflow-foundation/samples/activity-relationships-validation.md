---
title: "Activity Relationships Validation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6f11a34e-ed67-4bce-88ce-7e96bbb4d052
caps.latest.revision: 8
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Activity Relationships Validation
This sample consists of three activities, `CreateCity`, `CreateState`, and `CreateCountry`. `CreateCity` must be inside a `CreateState` activity, and `CreateState` must be inside a `CreateCountry` activity. For the purpose of this sample, the validation logic is in code for the `CreateState` activity, and in XAML for the `CreateCity` activity. Both constraints have the same behavior.  
  
 The [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)] provides the following three helper activities that allow the developer to validate relationships between activities:  
  
 <xref:System.Activities.Validation.GetParentChain>  
 Provides the collection of all activities that belong to the parent of the current node  
  
 <xref:System.Activities.Validation.GetChildSubtree>  
 Provides the collection of all activities that belong to the sub-tree of the current node, excluding the current node  
  
 <xref:System.Activities.Validation.GetWorkflowTree>  
 Provides the collection of all activities in the same tree as the current node  
  
 In the sample, a <xref:System.Activities.Statements.ForEach%601> activity is used to walk through the collection returned by <xref:System.Activities.Validation.GetParentChain>. For every element in the collection, its type is compared to `CreateCountry` (or `CreateState` if `CreateCity` is being validated), and when a match is found the result flag is set to `true`. Finally, an <xref:System.Activities.Validation.AssertValidation> is used to generate a validation error if the result flag is set to `false`.  
  
### To use this sample  
  
1.  Open the ContainmentValidation.sln sample solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Build the solution.  
  
3.  Press CTRL + F5 to launch the program.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing:  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory:  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Validation\ActivityRelationships`
