---
title: "Advanced Policy"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 75a22c88-5e54-4ae8-84cb-fbb22a612f0a
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Advanced Policy
This sample extends the Simple Policy sample. In addition to the residential discount and business discount rules from the Simple Policy example, several new rules have been added.  
  
 A high-value rule is added, which provides a bigger discount for high-value orders. It is given a priority value less than the previous two rules so that it will overwrite the discount field and take precedence over both the residential and business discount rules.  
  
 A calculate total rule is also added, which computes the total based on the discount level. It shows how to reference a method defined on the workflow activity, as well as how to use else actions. This rule also demonstrates chaining behavior since it will be evaluated anytime the discount field changes. Furthermore, method attributing is shown with the RuleWriteAttribute on the CalculateTotal method. This causes impacted rules (ErrorTotalRule) to be re-evaluated whenever the method gets executed.  
  
 The last rule added is one that detects errors (in this case, Total less than 0). If this occurs, the policy execution is halted.  
  
 Finally, `Console.Writeline` calls are added as actions to each rule to provide more visibility into rule execution, while also showing that it is possible to access static methods on referenced types. You could also use tracking to get visibility into the rules that are executed.  
  
 The rules used in this sample are:  
  
 **ResidentialDiscountRule:**  
  
 IF OrderValue > 500 AND CustomerType = Residential  
  
 THEN Discount = 5%  
  
 **BusinessDiscountRule:**  
  
 IF OrderValue > 10000 AND CustomerType = Business  
  
 THEN Discount = 10%  
  
 **HighValueDiscountRule:**  
  
 IF OrderValue > 20000  
  
 THEN Discount = 15%  
  
 **TotalRule:**  
  
 IF Discount > 0  
  
 THEN CalculateTotal(OrderValue, Discount)  
  
 ELSE Total = OrderValue  
  
 **ErrorTotalRule:**  
  
 IF Total \< 0  
  
 THEN Error = "Fired ErrorTotalRule"; Halt  
  
 Rule evaluation and execution can also be seen through tracing and tracking.  
  
### To build the sample  
  
1.  Open the solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Build the solution by pressing CTRL+SHIFT+B.  
  
3.  Run the solution without debugging by pressing CTRL+F5.  
  
### To run the sample  
  
-   In the SDK Command Prompt window, run the .exe file in the AdvancedPolicy\bin\debug folder (or the AdvancedPolicy \bin folder for the Visual Basic version of the sample), which is located below the main folder for the sample.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing:  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory:  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Rules\Policy\AdvancedPolicy`  
  
## See Also  
 <xref:System.Workflow.Activities.Rules.RuleSet>  
 <xref:System.Workflow.Activities.PolicyActivity>  
 [Simple Policy](../../../../docs/framework/windows-workflow-foundation/samples/simple-policy.md)
