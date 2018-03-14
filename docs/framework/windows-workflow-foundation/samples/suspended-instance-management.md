---
title: "Suspended Instance Management"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f5ca3faa-ba1f-4857-b92c-d927e4b29598
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Suspended Instance Management
This sample demonstrates how to manage workflow instances that have been suspended.  The default action for <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior> is `AbandonAndSuspend`. This means that by default, unhandled exceptions thrown from a workflow instance hosted in the <xref:System.ServiceModel.WorkflowServiceHost> will cause the instance to be disposed from memory (abandoned) and the durable/persisted version of the instance to be marked as suspended. A suspended workflow instance will not be able to run until it has been unsuspended.  
  
 The sample shows how a command-line utility can be implemented to query for suspended instances, and how to give the user the option to resume or terminate the instance. In this sample, a workflow service intentionally throws an exception, causing it to become suspended. The command-line utility can then be used to query for the instance and subsequently resume or terminate the instance.  
  
## Demonstrates  
 <xref:System.ServiceModel.WorkflowServiceHost> with <xref:System.ServiceModel.Activities.Description.WorkflowUnhandledExceptionBehavior> and <xref:System.ServiceModel.Activities.WorkflowControlEndpoint> in [!INCLUDE[wf](../../../../includes/wf-md.md)].  
  
## Discussion  
 The command-line utility implemented in this sample is specific to the SQL instance store implementation that ships in [!INCLUDE[netfx_current_long](../../../../includes/netfx-current-long-md.md)]. If you have a custom implementation of the instance store, then you can adapt this utility by replacing the `WorkflowInstanceCommand` implementations in the sample with implementations that are specific to your instance store.  
  
 The provided implementation runs SQL commands against the SQL instance store directly to list suspended instances, and it relies on a <xref:System.ServiceModel.Activities.WorkflowControlEndpoint> added to the <xref:System.ServiceModel.WorkflowServiceHost> in order to resume or terminate the instances.  
  
#### To set up, build, and run the sample  
  
1.  This sample requires that the following Windows components are enabled:  
  
    1.  Microsoft Message Queues (MSMQ) Server  
  
    2.  SQL Server Express  
  
2.  Set up the SQL Server database.  
  
    1.  From a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt, run "setup.cmd" from the SuspendedInstanceManagement sample directory, which does the following:  
  
        1.  Creates a persistence database using SQL Server Express. If the persistence database already exists, then it is dropped and re-created  
  
        2.  Sets up the database for persistence.  
  
        3.  Adds IIS APPPOOL\DefaultAppPool and NT AUTHORITY\Network Service to the InstanceStoreUsers role that was defined when setting up the database for persistence.  
  
3.  Set up the service queue.  
  
    1.  In [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], right-click the **SampleWorkflowApp** project and click **Set as Startup Project**.  
  
    2.  Compile and run the SampleWorkflowApp by pressing **F5**. This will create the required queue.  
  
    3.  Press **Enter** to stop the SampleWorkflowApp.  
  
    4.  Open the Computer Management console by running Compmgmt.msc from a command prompt.  
  
    5.  Expand **Service and Applications**, **Message Queuing**, **Private Queues**.  
  
    6.  Right click the **ReceiveTx** queue and select **Properties**.  
  
    7.  Select the **Security** tab and allow **Everyone** to have permissions to **Receive Message**, **Peek Message**, and **Send Message**.  
  
4.  Now, run the sample.  
  
    1.  In [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], run the SampleWorkflowApp project again without debugging by pressing **Ctrl+F5**. Two endpoint addresses will be printed in the console window: one for the application endpoint and then other from the <xref:System.ServiceModel.Activities.WorkflowControlEndpoint>. A workflow instance is then created, and tracking records for that instance will appear in the console window. The workflow instance will throw an exception causing the instance to be suspended and aborted.  
  
    2.  The command-line utility can then be used to take further action on any of these instances. The syntax for command line arguments is as follows::  
  
         `SuspendedInstanceManagement -Command:[CommandName] -Server:[ServerName] -Database:[DatabaseName] -InstanceId:[InstanceId]`  
  
         The supported commands are: `Query`, `Resume`, and `Terminate`.  The InstanceId switch is only required for `Resume` and `Terminate` operations.  
  
#### To cleanup (Optional)  
  
1.  Open the Computer Management console by running Compmgmt.msc from a `vs2010` command prompt.  
  
2.  Expand **Service and Applications**, **Message Queuing**, **Private Queues**.  
  
3.  Delete the **ReceiveTx** queue.  
  
4.  To remove the persistence database, run cleanup.cmd.  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Application\SuspendedInstanceManagement`
