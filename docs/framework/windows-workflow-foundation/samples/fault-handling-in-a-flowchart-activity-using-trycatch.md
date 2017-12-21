---
title: "Fault Handling in a Flowchart Activity Using TryCatch"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 50922964-bfe0-4ba8-9422-0e7220d514fd
caps.latest.revision: 12
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Fault Handling in a Flowchart Activity Using TryCatch
This sample shows how the <xref:System.Activities.Statements.TryCatch> activity can be used within a complex control flow activity.  
  
 In this sample, a promotion code and number of children are passed as variables to a <xref:System.Activities.Statements.Flowchart> activity that calculates a discount based on formulae that correspond to the promotion code. The sample includes imperative code and workflow designer versions of the sample.  
  
 The following table details the variables for the `CreateFlowchartWithFaults` activity.  
  
|Parameters|Description|  
|----------------|-----------------|  
|promoCode|The promotion code. Type: String<br /><br /> The possible values with description in parentheses:<br /><br /> -   Single (Single)<br />-   MNK (Married with no kids.)<br />-   MWK (Married with kids.)|  
|numKids|The number of children. Type: int|  
  
 The `CreateFlowchartWithFaults` activity uses a <xref:System.Activities.Statements.FlowSwitch%601> activity that switches on the `promoCode` argument and calculates the discount using the following formula.  
  
|Value of `promoCode`|Discount (%)|  
|--------------------------|--------------------|  
|Single|10|  
|MNK|15|  
|MWK|15 + (1 – 1/`numberOfKids`)\*10 **Note:**  Potentially, this calculation can throw a <xref:System.DivideByZeroException>. So, the discount calculation is wrapped in a <xref:System.Activities.Statements.TryCatch> activity that catches the <xref:System.DivideByZeroException> exception and sets the discount to zero.|  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the FlowchartWithFaultHandling.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Built-InActivities\FlowChartWithFaultHandling`  
  
## See Also  
 [Flowchart Workflows](../../../../docs/framework/windows-workflow-foundation/flowchart-workflows.md)  
 [Exceptions](../../../../docs/framework/windows-workflow-foundation/exceptions.md)
