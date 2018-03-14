---
title: "Channel Caching with Send"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e69a2502-25cb-43bf-b8d2-95fbdecb41cb
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Channel Caching with Send
The <xref:System.ServiceModel.Activities.SendMessageChannelCache> enables users to have different levels of channel caching with <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.SendParametersContent> activities. Instance-level caching is enabled by default and this sample demonstrates the following features:  
  
1.  Share a <xref:System.ServiceModel.Activities.SendMessageChannelCache> across an application domain.  
  
2.  Disable channel caching.  
  
3.  Share a <xref:System.ServiceModel.Activities.SendMessageChannelCache> among workflow instances in a <xref:System.ServiceModel.Activities.WorkflowServiceHost>.  
  
## Demonstrates  
 <xref:System.ServiceModel.Activities.SendMessageChannelCache> extension, <xref:System.ServiceModel.Activities.Send>, <xref:System.ServiceModel.Activities.Receive>, <xref:System.ServiceModel.Activities.ReceiveContent> and <xref:System.ServiceModel.Activities.SendReply> activities.  
  
#### To set up, build, and run the sample  
  
1.  Load the project solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] and build the project.  
  
2.  Run the EchoWorkflowService application generated in \EchoWorkflowService\bin\debug.  
  
3.  Run the EchoWorkflowClient application generated in .\EchoWorkflowClient\bin\debug.  
  
4.  The client calls the Echo operation on the service and prints the results. When the results have been printed, press ENTER to exit the client and the service.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\ChannelCache`
