---
title: "OperationScope"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 56206a21-1e63-422d-b92a-e5d8b713e707
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# OperationScope
This sample demonstrates how the messaging activities, <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply> can be used to expose an existing custom activity as an operation in a workflow service. This sample includes a new custom activity called an `OperationScope`. It is intended to ease the development of a workflow service by allowing users to author the body of their operations separately as custom activities and then easily exposing them as service operations using the `OperationScope` activity. For example, a custom `Add` activity that takes two `in` arguments and returns one `out` argument could be exposed as an `Add` operation on the workflow service by dropping it into an `OperationScope`.  
  
 The scope works by inspecting the activity provided as its body. Any unbound `in` arguments are assumed to be inputs from the incoming message. All `out` arguments, regardless of whether they are bound, are assumed to be outputs in the subsequent reply message. The exposed operation’s name is taken from the display name of the `OperationScope` activity. The end result is that the body activity is wrapped in a <xref:System.ServiceModel.Activities.Receive> and <xref:System.ServiceModel.Activities.SendReply> with the parameters from the messages bound to the arguments of the activity.  
  
 This sample exposes a workflow service using HTTP endpoints. To run, proper URL ACLs must be added. [!INCLUDE[crdefault](../../../../includes/crdefault-md.md)] [Configuring HTTP and HTTPS](http://go.microsoft.com/fwlink/?LinkId=70353). Executing the following command at an elevated prompt adds the appropriate ACLs (ensure that your Domain and Username are substituted for %DOMAIN%\\%UserName%).  
  
 **netsh http add urlacl url=http://+:8000/ user=%DOMAIN%\\%UserName%**  
  
### To run the sample  
  
1.  Open the OperationScope.sln solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Set multiple start-up projects by right-clicking the solution in Solution Explorer and selecting **Set Startup Projects**. Add Scenario and Scenario_Client (in that order) as multiple start-up projects.  
  
3.  Press CTRL+SHIFT+B to build the solution.  
  
    > [!WARNING]
    >  This step is required to view the BankService.xaml workflow due to the custom activity `OperationScope`.  
  
4.  Press CTRL+F5 to run the application. The Scenario_Client console prompts you for inputs and the corresponding output is seen in the Scenario console.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Scenario\Services\OperationScope`