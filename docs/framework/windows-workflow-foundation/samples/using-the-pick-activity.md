---
title: "Using the Pick Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b89be812-a247-4025-b0e3-ffb20db027a6
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using the Pick Activity
This sample demonstrates how to use the <xref:System.Activities.Statements.Pick> activity.  
  
 The <xref:System.Activities.Statements.Pick> activity provides event-based control modeling. It behaves similar to the C# `switch` statement, which executes only one of the branches in the `switch` statement. Unlike the `switch` statement in which a branch is executed based upon on a value, the <xref:System.Activities.Statements.Pick> activity executes a branch based upon how an activity completes.  
  
 This sample prompts a user to type in their name on the console within a given time period. The <xref:System.Activities.Statements.Pick> activity in the sample has two branches that are executed based upon whether the user types in their name within 5 seconds or not. If the user types in their name within 5 seconds, the first branch is executed, which contains a custom `ReadLine` activity; otherwise the other branch is executed, which contains a <xref:System.Activities.Statements.Delay> activity. Once a user’s name is typed in on the console, the user’s name is printed on the console. If an input is not entered within 5 seconds, the operation is timed out.  
  
## Demonstrates  
 <xref:System.Activities.Statements.Pick> activity.  
  
## Discussion  
 The sample includes a Designer workflow and coded workflow.  
  
 Designer Workflow  
 The Designer version of the sample demonstrates how to create a workflow in the designer. The following files are included:  
  
-   Program.cs : Includes the `Main` function that executes the sample workflow.  
  
-   ReadString.cs: A custom activity that reads some input from the console.  
  
-   Sequence1.xaml: A workflow created using the designer that uses Pick.  
  
 Coded Workflow  
 The coded version of the sample demonstrates how to create a workflow in the designer. The following files are included:  
  
-   Program.cs : Includes the `Main` function that executes the sample workflow.  
  
-   ReadString.cs: A custom activity that reads some input from the console.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the Pick.sln solution file.  
  
2.  To build the solution, press CTRL+SHIFT+B.  
  
3.  To run the solution, press F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Built-InActivities\Pick`