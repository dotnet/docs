---
title: "Expressions2"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 43a85905-77b5-4893-bb38-1cb9b293d69d
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Expressions
This sample demonstrates how to use basic expressions in a workflow. It consists of a workflow that calculates basic salary statistics for two employees of a fictitious company. Two classes, `Employee` and `SalaryStats`, are defined in Employee.cs and SalaryStats.cs. These classes are used in a workflow that shows how to perform simple arithmetic and string operations on properties of variables of complex types.  
  
 The salary calculation workflow is defined both in XAML and in C# to demonstrate the two authoring styles. The XAML version is contained in SalaryCalculation.xaml and can be viewed and edited in the workflow designer. The C# version resides in Program.cs. The expressions used in XAML conform to Visual Basic syntax, and use <xref:Microsoft.VisualBasic.Activities.VisualBasicValue%601> and <xref:Microsoft.VisualBasic.Activities.VisualBasicReference%601> expression activities to execute. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] Visual Basic expressions see, [Visual Basic Expressions](http://go.microsoft.com/fwlink/?LinkId=165912). On the other hand, expressions in C# are written as lambda expressions and use <xref:System.Activities.Expressions.LambdaValue%601> and <xref:System.Activities.Expressions.LambdaReference%601> expression activities. Writing expressions as lambda expressions allows the C# compiler to provide syntax highlighting and static verification. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] lambda expressions in C#, see [Lambda Expressions (C# Programming Guide)](http://go.microsoft.com/fwlink/?LinkId=182082). If a workflow is authored in code using Visual Basic, then Visual Basic lambda expressions are used. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] lambda expressions in Visual Basic, see [Lambda Expressions (Visual Basic)](http://go.microsoft.com/fwlink/?LinkId=152437). [!INCLUDE[crabout](../../../../includes/crabout-md.md)] about authoring workflows using code, see [Authoring Workflows, Activities, and Expressions Using Imperative Code](../../../../docs/framework/windows-workflow-foundation/authoring-workflows-activities-and-expressions-using-imperative-code.md).  
  
#### To run the sample  
  
1.  Open the Expressions.sln solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Press CTRL+SHIFT+B to build the solution or select **Build Solution** from the **Build** menu.  
  
    > [!NOTE]
    >  To open SalaryCalculation.xaml in the Visual Studio designer, you must first compile your project to ensure that `Employee` and `SalaryStats` classes are available to the designer.  
  
3.  Once the build has succeeded, press F5 or select **Start Debugging** from the **Debug** menu. Alternatively you can press Ctrl+F5 or select **Start Without Debugging** from the **Debug** menu to run without debugging.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Expressions`