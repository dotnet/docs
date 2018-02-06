---
title: "Workflow Management Endpoint Sample"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 3ac6e08f-c43d-4bb7-83c3-e3890a4dac03
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Management Endpoint Sample
This sample shows how a workflow control endpoint can be used to create and run workflows both locally and remotely. The sample demonstrates how to host a control endpoint and write clients that call the control endpoint to create and run the instance of a workflow. The workflow is not a service.  
  
 On the service side of the sample a workflow is hosted with WorkflowServiceHost and a WorkflowControlEndpoint is added so that clients can perform control operations (Suspend, Start, etc). A user-defined CreationEndpoint is also added to allow the workflow to be created. The service then uses these endpoints to start the workflow in a suspended state and then resume the workflow. The client performs the same operations but from the client code. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] these interfaces see, [Workflow Control Endpoint](../../../../docs/framework/wcf/feature-details/workflow-control-endpoint.md) and [How to: Host a non-service workflow in IIS](../../../../docs/framework/wcf/feature-details/how-to-host-a-non-service-workflow-in-iis.md)  
  
#### To run the sample  
  
1.  Run [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] with administrator privileges.  
  
2.  Open the ManagementEndpoint.sln solution in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
3.  To build the solution, press CTRL+SHIFT+B or select **Build Solution** from the **Build** menu.  
  
4.  Start the ManagementEndpoint.exe application.  
  
5.  Start the Client.exe application.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Execution\ManagementEndpoint`