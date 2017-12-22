---
title: "Using Variables with a .NET Framework 3.5 Ruleset"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 27b56249-22fe-4252-840f-74c0d6c7a6b3
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Variables with a .NET Framework 3.5 Ruleset
This sample demonstrates how to create a workflow that uses the <xref:System.Activities.Statements.Interop> activity to integrate a custom activity written in [!INCLUDE[netfx35_short](../../../../includes/netfx35-short-md.md)] that uses policy and rules. The workflow passes data to the custom activity by binding variables to the dependency properties exposed by the custom activity.  
  
## Sample walkthrough  
  
#### To examine TravelRuleLibrary  
  
1.  Using [!INCLUDE[vs_current_short](../../../../includes/vs-current-short-md.md)], open the InteropWith35RuleSet.sln solution file.  
  
2.  Open the TravelRuleSet.cs in the workflow designer.  
  
     A custom sequential activity that contains a <xref:System.Workflow.Activities.PolicyActivity> is displayed.  
  
3.  Double-click the DiscountPolicy policy activity to examine the rules.  
  
     The Rules editor pops up to show the rules.  
  
4.  Right click the `DiscountPolicy` and select the **View Code** option to examine the code beside C# code for the activity.  
  
     Observe the dependency property setting for `DiscountLevel`. This is equivalent to arguments in [!INCLUDE[netfx_current_short](../../../../includes/netfx-current-short-md.md)]. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] arguments, see [Variables and Arguments](../../../../docs/framework/windows-workflow-foundation/variables-and-arguments.md).  
  
## InteropWith35RuleSet  
 This is a sequential workflow project that uses the <xref:System.Activities.Statements.Interop> activity to integrate with the custom Rule set created in the `TravelRuleLibrary` project. Variables are created on the top level <xref:System.Activities.Statements.Sequence> activity. The <xref:System.Activities.Statements.Interop> activity is used to integrate with the `TravelRuleSet` activity. The variables that are declared on the <xref:System.Activities.Statements.Sequence> are used to bind to the dependency properties.  
  
## To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the InteropWith35RuleSet.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press CTRL+F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Built-InActivities\InteropWith35RuleSet`