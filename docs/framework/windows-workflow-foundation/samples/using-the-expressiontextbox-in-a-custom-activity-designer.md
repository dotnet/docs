---
title: "Using the ExpressionTextBox in a Custom Activity Designer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f82e73e7-a256-4a4d-82b7-c0d62f4ab5e7
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the ExpressionTextBox in a Custom Activity Designer
This sample shows how to use the <xref:System.Activities.Presentation.View.ExpressionTextBox> in a custom activity designer. The custom activity, `MultiAssign`, assigns two string values to two string variables. Some <xref:System.Activities.Presentation.View.ExpressionTextBox> controls bind to <xref:System.Activities.InArgument>s and some bind to <xref:System.Activities.OutArgument>s.  
  
## Sample details  
 The `ArgumentToExpressionConverter` is the type converter used when binding expressions to arguments. The `ConverterParameter` must be set to `In` or `Out` as appropriate. `InOut` is not supported.  
  
 The `UseLocationExpression` attribute is used on `OutArgument`s to specify that the expression should be an L-value ("left value" or "location value") expression. In most cases, an L-value expression is a valid Visual Basic identifier used to indicate that the `OutArgument` being returned is a variable or argument name.  
  
 The `MaxLines` attribute is set to one in this example and `MinLines` is not set. This indicates that the <xref:System.Activities.Presentation.View.ExpressionTextBox> is a fixed size of one line regardless of the amount of text typed by the user. To allow the <xref:System.Activities.Presentation.View.ExpressionTextBox> to grow to fit user input, set `MaxLines` greater than `MinLines`.  
  
 An ExpressionTextBox can only be bound to arguments, and cannot be bound to CLR properties.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the ExpressionTextBoxSample.sln file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
#### To run this sample  
  
1.  Add a new Workflow Console Application to the solution.  
  
2.  Add a reference to the **ExpressionTextBoxSample** project from the new Workflow Console Application project.  
  
3.  Build the solution.  
  
4.  Drag the **MultiAssign** activity from the toolbox and drop it into the workflow.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\CustomActivities\CustomActivityDesigners\ExpressionTextBox`  
  
## See Also  
 <xref:System.Activities.Presentation.View.ExpressionTextBox>  
 [Developing Applications with the Workflow Designer](/visualstudio/workflow-designer/developing-applications-with-the-workflow-designer)
