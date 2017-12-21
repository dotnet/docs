---
title: "Basic Usage of SendParameters and ReceiveParameters Activities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1b6b1681-3d41-403f-bfe2-3f600f24aa8c
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Basic Usage of SendParameters and ReceiveParameters Activities
This sample shows the use of <xref:System.ServiceModel.Activities.SendParametersContent> and <xref:System.ServiceModel.Activities.ReceiveParametersContent> activities. The service exposes one operation that takes a string argument and echoes the input back to the client. The sample shows how to set up the parameters for these messaging activities.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\SendReceiveParameters`  
  
#### Using this sample  
  
1.  Load the project solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] and build the project.  
  
2.  First run the EchoWorkflowService application generated in [solution base directory]\EchoWorkflowService\bin\debug.  
  
3.  Second, run the EchoWorkflowClient application generated in [solution base directory]\EchoWorkflowClient\bin\debug.  
  
4.  The client calls Echo operation on the service and prints the results. When complete, press ENTER to exit the client and then the service.