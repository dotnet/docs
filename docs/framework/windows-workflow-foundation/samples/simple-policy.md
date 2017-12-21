---
title: "Simple Policy"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6a94c834-2e32-4bed-9f47-ae5845eef6ff
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Simple Policy
This sample shows how to use a <xref:System.Workflow.Activities.PolicyActivity> activity in a workflow.  
  
 The sequential workflow in this sample is created by using a <xref:System.Workflow.Activities.PolicyActivity> activity. The workflow defines `orderValue`, `customerType`, and `discount` fields that are used to define a product discount workflow. The rules defined in the rules file set a discount value that is based on the `orderValue` and `customerType`. The `orderValue` and `customerType` are set in the `SimplePolicyWorkflow` class definition and can be changed to alter the behavior. The resulting discount is written to the console in the <xref:System.Workflow.Runtime.WorkflowRuntime.WorkflowCompleted> event handler that is defined in the `SimplePolicyWorkflow` class.  
  
### To build the sample  
  
1.  Open the solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Build the solution by pressing CTRL+SHIFT+B.  
  
3.  Run the solution without debugging by pressing CTRL+F5.  
  
### To run the sample  
  
-   In the SDK Command Prompt window, run the .exe file in the SimplePolicy\bin\debug folder (or the SimplePolicy\bin folder for the Visual Basic version of the sample), which is located below the main folder for the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing:  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory:  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Rules\Policy\SimplePolicy`  
  
## See Also  
 <xref:System.Workflow.Activities.Rules.RuleSet>  
 <xref:System.Workflow.Activities.PolicyActivity>  
 [Advanced Policy](../../../../docs/framework/windows-workflow-foundation/samples/advanced-policy.md)
