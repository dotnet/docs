---
title: "Durable Delay"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 220ec240-b958-430c-81ff-b734a6aa97ae
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Durable Delay
This sample demonstrates how to use a durable delay, which is a delay that persists the workflow to a durable device during the delay. The sample workflow contains two messages to the console that are separated by a delay. When the delay is triggered, the workflow is unloaded and waits 5 seconds in the workflow instance store before being reloaded in memory.  
  
## Workflow Details  
 The workflow service host hosts the workflow and manages the workflow instances by loading and unloading them. To start an instance of the workflow definition, the sample sets a proxy that sends a message to the <xref:System.ServiceModel.Activities.Receive> activity in the workflow. The <xref:System.ServiceModel.Activities.Receive.CanCreateInstance%2A> property is set to `true`, enabling it to create a new instance of the workflow once it receives a message.  
  
 The following list details the set-up by the workflow service host during initialization.  
  
1.  Creates a service host with an address (http://localhost:8080/Client).  
  
2.  Creates an endpoint in the service host to enable communication with the <xref:System.ServiceModel.Activities.Receive> activity inside the workflow.  
  
3.  Sets up a SQL instance store.  
  
4.  Adds an unload instance behavior that specifies the conditions under which the workflow service host should unload a workflow instance to the SQL persistence store. For this sample, it unloads the instance immediately after the workflow goes idle (when the delay is triggered).  
  
5.  Creates the proxy that sends a message to the <xref:System.ServiceModel.Activities.Receive> activity in the workflow.  
  
#### To use this sample  
  
1.  Set up the persistence database.  
  
    1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
    2.  Navigate to the [!INCLUDE[dnprdnshort](../../../../includes/dnprdnshort-md.md)] directory (C:\Windows\Microsoft.NET\Framework\v4.X\\).  
  
    3.  Edit the WorkflowManagementService.exe.config file and add the following connection string inside the <`database`> element.  
  
        ```xml  
        <database connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=DefaultSampleStore;Integrated Security=True;Asynchronous Processing=True" />  
        ```  
  
    4.  Navigate to the DurableDelay\CS directory.  
  
    5.  Run Setup.cmd.  
  
2.  Run [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] using elevated permissions by right-clicking the [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] icon and selecting **Run as administrator**.  
  
3.  Open the Delay.sln solution file.  
  
4.  Press CTRL+SHIFT+B to build the solution.  
  
5.  Press CTRL+F5 to run the solution.  
  
#### To uninstall this sample  
  
1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
2.  Navigate to the DurableDelay\CS directory.  
  
3.  Run Cleanup.cmd.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Services\DurableDelay`