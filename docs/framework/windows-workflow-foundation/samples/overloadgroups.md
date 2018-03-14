---
title: "OverloadGroups"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d1d547d2-f5fb-4de3-a959-ee6139a4f1ad
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# OverloadGroups
This sample consists of an activity (`CreateLocation`), which has two interesting characteristics:  
  
1.  It has some required arguments and some optional ones.  
  
2.  It allows the user to choose to provide one of two different sets of arguments.  
  
 These behaviors are accomplished by using these two features:  
  
-   `[isRequired]` validates that a property of a specific activity is assign, and if not, it throws an exception.  
  
-   `[OverloadGroup]` puts together a set of arguments, so that the user of the activity can choose between using one set or another. The user cannot use arguments from different Overload Groups in the same instance.  
  
 After setting up different workflows, call <xref:System.Activities.Validation.ActivityValidationServices.Validate%2A> which returns a <xref:System.Activities.Validation.ValidationResults> collection of <xref:System.Activities.Validation.Constraint>. Print the <xref:System.Activities.Validation.Constraint> objects to the console.  
  
### To set up, build, and run the sample  
  
1.  Open the **OverloadGroups.sln** sample solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Build and run the solution.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Validation\OverloadGroups`
