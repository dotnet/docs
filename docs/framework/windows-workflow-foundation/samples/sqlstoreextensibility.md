---
title: "SQLStoreExtensibility"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5da1b5a3-f144-41ba-b9c4-02818b28b15d
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# SQLStoreExtensibility
This sample demonstrates the use and configuration of promoted properties in the SQL workflow instance store. The SQL workflow instance store is a SQL-based implementation of an instance store. It allows an instance to save its state and load its state to and from a SQL Server or SQL Server Express database. The store extensibility feature allows the user to define properties that are stored in the instance store. These properties are displayed in a promoted properties view that allows the user to query for them.  
  
 This sample consists of a workflow that implements a counting service. Once the service's start method is invoked, the service counts from 0 to 29. The counter is incremented once every 2 seconds. After each count, the workflow persists. The current counter value is stored in the instance store as a promoted property.  
  
 The Counting Workflow is self-hosted by a Workflow Service Host. The program's `Main` method performs the following actions:  
  
-   Creates an instance of the Workflow Service Host that hosts the Counting Workflow and defines the endpoints under which the Counting Workflow can be reached.  
  
-   Defines a SQL workflow instance store behavior, which is used to configure the SQL workflow instance store. The store is instructed to treat `CountStatus` as a promoted property.  
  
-   Creates a client that calls the start method of the counting workflow.  
  
 Once the program is started, the counter automatically starts counting. Note that it might take a few seconds to load the instance and configure the SQL workflow instance store.  
  
 To promote the counter value as a custom property, the following steps must be taken:  
  
1.  The class `CounterStatus` defines an instance extension of type <xref:System.Activities.Persistence.PersistenceParticipant>, which is used by activities to supply the state variables. `Count` is defined as a write-only value. When a workflow instance comes to a persistence point, the instance extension saves the `Count` property into the persistence data collection.  
  
2.  When creating the instance store, a new property, `CountStatus`, is defined through the `store.Promote()` method.  
  
3.  The workflow's `SaveCounter` activity assigns the current counter value to the `Count` status field.  
  
### To use this sample  
  
1.  Create the instance store database.  
  
    1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
    2.  Navigate to the sample directory (\WF\Basic\Persistence\SqlStoreExtensibility\CS) and run CreateInstanceStore.cmd in the [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt.  
  
        > [!WARNING]
        >  The CreateInstanceStore.cmd script attempts to create the database on the default instance of SQL Server 2008 Express. If you want to install the database on a different instance, modify the script to do so.  
  
2.  Open [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] and load the SqlStoreExtensibility.sln solution and build it by pressing CTRL+SHIFT+B.  
  
    > [!WARNING]
    >  If you installed the database on a non-default instance of SQL Server, update the connection string in the code prior to building the solution.  
  
3.  Run the sample with administrator privileges by navigating to the project’s bin directory (\WF\Basic\Persistence\SqlStoreExtensibility\bin\Debug) in [!INCLUDE[fileExplorer](../../../../includes/fileexplorer-md.md)], right-clicking SqlStoreExtensibility.exe and selecting **Run as Administrator**.  
  
### To verify the sample is working correctly  
  
1.  Use SQL Server Management Studio to view the contents of the instance table by selecting **Databases**, **InstanceStore**, and then **System.ServiceModel.Activities.DurableInstancing.InstanceTable** in the Object Explorer, right-click **System.ServiceModel.Activities.DurableInstancing.InstanceTable** and select **Select Top 1000 Rows**. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] SQL Server Management Studio, see [Introducing SQL Server Management Studio](http://go.microsoft.com/fwlink/?LinkId=165645)  
  
2.  Observe the workflow instances listed.  
  
3.  In a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt, run the QueryInstanceStore.cmd script located in the sample directory (\WF\Basic\Persistence\SqlStoreExtensibility).  
  
4.  Observe the counter value displayed under **CountStatus**.  
  
5.  Run the script a few times to see the **CountStats** value change.  
  
6.  Press ENTER to terminate the workflow application.  
  
### To uninstall the sample  
  
1.  Remove the instance store database by running the RemoveInstanceStore.cmd script located in the sample directory (\WF\Basic\Persistence\SqlStoreExtensibility).  
  
> [!IMPORTANT]
>  The samples may already be installed on your machine. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Persistence\SQLStoreExtensibility`  
  
## See Also  
 [Workflow Persistence](../../../../docs/framework/windows-workflow-foundation/workflow-persistence.md)  
 [Workflow Services](../../../../docs/framework/wcf/feature-details/workflow-services.md)  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
