---
title: "For Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2ea751b4-36f0-48aa-a115-70a2ab89f6d8
caps.latest.revision: 9
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# For Activity
The For sample demonstrates how to build a custom activity that inherits from <xref:System.Activities.NativeActivity>, and use it in a workflow to execute a real world example. The custom activity included in this sample functions like the C# `for` statement. T  
  
 The `For` custom activity has properties named `InitAction`, `IterationAction`, `Condition`, and `Body` that correspond to the initialization statement, iterative statement, continuation condition, and body statement respectively found in the standard C# `For` statement.  
  
 The following table describes the key files in the sample.  
  
|File|Description|  
|----------|-----------------|  
|For.cs|Class definition for the `For` custom activity, which extends the <xref:System.Activities.NativeActivity> class to provide the functionality of the C# `For` statement.|  
|Program.cs|A client application that performs basic iterative work on a collection using the custom `For` activity.|  
  
> [!NOTE]
>  When using the `For` custom activity, ensure that the `Condition` property is set; otherwise an infinite loop could occur.  
  
## Demonstrates  
 Create a custom activity that inherits from <xref:System.Activities.NativeActivity>.  
  
## Discussion  
 The following table describes the properties of the activity included in this sample.  
  
 InitAction  
 Initialization statement  
  
 IterationAction  
 Iterative statement  
  
 Condition  
 Continuation statement  
  
 Body  
 Body statement  
  
 The activity inherits from <xref:System.Activities.NativeActivity> to gain access to runtime features such as scheduling additional activities to run, using one of the `ScheduleActivity` methods of <xref:System.Activities.NativeActivityContext>.  
  
#### To use this sample  
  
1.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the For.sln solution file.  
  
2.  Build the solution, by pressing CTRL+SHIFT+B.  
  
3.  Run the solution, by pressing F5.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\ActivityLibrary\For`