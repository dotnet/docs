---
title: "Basic Activity Composition"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c283a1a7-1245-4ecd-8072-206c1b4ca379
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Basic Activity Composition
This sample demonstrates how to compose custom activities and system-provided activities to build more custom activities.  
  
 The workflow using the Survey activity schedules the Survey with a list of questions, and then outputs the responses received.  
  
## Sample Details  
 This sample uses three custom activities. `ReadLine` is a simple <xref:System.Activities.NativeActivity>\<string> that creates a <xref:System.Activities.Bookmark> when scheduled, and then sets the `Return`<xref:System.Activities.OutArgument%601> to the value with which the <xref:System.Activities.Bookmark> is resumed. `Prompt` is an <xref:System.Activities.Activity%601>\<string> that takes an <xref:System.Activities.InArgument%601><string\> named `Text` and returns the users response in the `Result`<xref:System.Activities.OutArgument%601>\<string>. The `Prompt` activity uses the <xref:System.Activities.Statements.Sequence> and <xref:System.Activities.Statements.WriteLine> activities that ship as part of the .NET Framework, and also incorporates the custom `ReadLine` activity for getting user input. The last custom activity is the `Survey` activity. It is an <xref:System.Activities.Activity><ICollection\<string>>.  This activity takes an <xref:System.Activities.InArgument%601><IEnumerable<string\>> named `Questions` and populates the `Result` out argument with the responses. The `Survey` activity uses <xref:System.Activities.Statements.ForEach%601>, <xref:System.Activities.Statements.Sequence> and <xref:System.Activities.Statements.AddToCollection%601> from the .NET Framework and employs the `Prompt` activity for asking the survey questions and getting responses.  
  
#### To set up, build, and run the sample  
  
1.  Open the **BasicActivityComposition.sln** sample solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Build and run the solution.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\CustomActivities\Composite\ActivityComposition`