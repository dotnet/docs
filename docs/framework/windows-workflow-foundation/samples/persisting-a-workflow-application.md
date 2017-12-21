---
title: "Persisting a Workflow Application"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: abcff14c-f047-4195-ba26-d27f4a82c24e
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Persisting a Workflow Application
This sample demonstrates how to run a <xref:System.Activities.WorkflowApplication>, unload it when it goes idle, and then reload it to continue its execution.  
  
## Sample Details  
 <xref:System.Activities.WorkflowApplication> is a host for a single workflow instance that provides a simple interface and enables several of the more common hosting scenarios. One such scenario is long running workflows facilitated by persistence. Host control of persistence is performed either by calling a persistence operation on the <xref:System.Activities.WorkflowApplication>, or by handling a <xref:System.Activities.WorkflowApplication> event and indicating that the <xref:System.Activities.WorkflowApplication> should persist.  
  
 The sample workflow is a <xref:System.Activities.Statements.WriteLine> activity prompting the user for their name, a `ReadLine` activity for receiving the name as input through the resumption of a <xref:System.Activities.Bookmark>, and another <xref:System.Activities.Statements.WriteLine> for echoing a greeting back to the user. When a workflow is waiting for input, this provides a natural point for persistence. This is often referred to as an <xref:System.Workflow.Runtime.Tracking.TrackingWorkflowEvent.Idle> point. <xref:System.Activities.WorkflowApplication> raises the <xref:System.Workflow.Runtime.Tracking.TrackingWorkflowEvent.Idle> event whenever the workflow program can be persisted, is waiting on a bookmark resumption, and no other work is being performed. In this sample’s workflow, that point comes immediately after the `ReadLine` activity begins executing.  
  
 A <xref:System.Activities.WorkflowApplication> is set up to perform persistence with an <!--zz <xref:System.Runtime.Persistence.InstanceStore> --> `System.Runtime.Persistence.InstanceStore`. This sample uses the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore>. The <!--zz <xref:System.Runtime.Persistence.InstanceStore> --> `System.Runtime.Persistence.InstanceStore` must be assigned to the <xref:System.Activities.WorkflowApplication.InstanceStore%2A> property before the <xref:System.Activities.WorkflowApplication> is run.  
  
 The sample adds a handler to the <xref:System.Activities.WorkflowApplication.PersistableIdle%2A> event. The handler for this event indicates what the <xref:System.Activities.WorkflowApplication> should do by returning a <xref:System.Activities.PersistableIdleAction>. When <xref:System.Activities.PersistableIdleAction.Unload> is returned, the <xref:System.Activities.WorkflowApplication> is unloaded.  
  
 The sample then accepts input from the user and loads the persisted workflow into a new <xref:System.Activities.WorkflowApplication>. It does so by creating a new <xref:System.Activities.WorkflowApplication>, recreating the <!--zz <xref:System.Runtime.Persistence.InstanceStore> --> `System.Runtime.Persistence.InstanceStore`, and associating the completed and unloaded events to the instance, and then calling <xref:System.Activities.WorkflowApplication.Load%2A> with the identifier of the target workflow instance. Once the instance is acquired, the `ReadLine` activity’s bookmark is resumed. The workflow carries on execution from within the `ReadLine` activity and runs to completion. When the workflow completes and unloads, the <!--zz <xref:System.Runtime.Persistence.InstanceStore> --> `System.Runtime.Persistence.InstanceStore` is called one last time to delete the workflow.  
  
#### To use this sample  
  
1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
     This sample requires SQL Server Express, which is installed by default with [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)].  
  
2.  Navigate to the sample directory (\WF\Basic\Persistence\InstancePersistence\CS) and run CreateInstanceStore.cmd.  
  
    > [!CAUTION]
    >  The CreateInstanceStore.cmd script attempts to create the database on the default instance of SQL Server 2008 Express. If you want to install the database on a different instance, modify the script to do so.  
  
3.  Using [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)], open the Persistence.sln solution file and press CTRL+SHIFT+B to build it.  
  
    > [!CAUTION]
    >  If you installed the database on a non-default instance of SQL Server, update the connection string in the code prior to building the solution.  
  
4.  Run the sample with administrator privileges by navigating to the project’s bin directory (\WF\Basic\Persistence\InstancePersistence\bin\Debug) in [!INCLUDE[fileExplorer](../../../../includes/fileexplorer-md.md)], right-clicking Workflow.exe and selecting **Run as Administrator**.  
  
#### To remove the instance store database  
  
1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
2.  Navigate to the sample directory and run RemoveInstanceStore.cmd.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Persistence\InstancePersistence`  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
