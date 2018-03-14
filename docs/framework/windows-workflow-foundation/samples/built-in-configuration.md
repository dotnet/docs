---
title: "Built-in Configuration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 34e85c9b-088d-4347-816c-0f77cb73ef2f
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Built-in Configuration
This sample demonstrates the use and configuration of the SQL workflow instance store. The SQL workflow instance store is a SQL-based implementation of an instance store. It allows an instance to save and load its state to and from a SQL Server or SQL Server Express database.  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to (download page) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Persistence\BuiltInConfiguration`  
  
## Sample Details  
 This sample consists of a workflow that implements a counting service. Once the service's start method is invoked, the service counts from 0 to 59. The counter is incremented once every 2 seconds. After each count, the workflow persists.  
  
 The counting workflow is self-hosted by a workflow service host. The program's `Main` method creates an instance of the workflow service host that hosts the counting workflow. It defines the endpoints under which the counting workflow can be reached. After that, it defines a SQL workflow instance store behavior, which is used to configure the SQL workflow instance store. Next, the program creates a client that calls the start method of the counting workflow.  
  
 Once the program is started, the counter automatically starts counting. Note that it might take a few seconds to load the instance and configure the SQL workflow instance store. [!INCLUDE[crabout](../../../../includes/crabout-md.md)] the workflow instance store, see [SQL Workflow Instance Store](../../../../docs/framework/windows-workflow-foundation/sql-workflow-instance-store.md).  
  
 The sample consists of two parts:  
  
1.  InstanceStore1 shows how <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> is configured using C# code (see Program.cs).  
  
2.  InstanceStore2 shows how <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> is configured using XML (see App.config).  
  
 The following settings are available to configure the SQL Workflow Instance Store behavior:  
  
-   Set the `HostLockRenewalPeriod`. This time defines the interval with which the host renews the ownership lock of the instances it runs. The lock information is stored in the Instance Store. If the ownership is not renewed for two of the intervals defined in `HostLockRenewalPeriod`, the instance is considered abandoned. If another <xref:System.ServiceModel.Activities.WorkflowServiceHost> is running the same workflow and connected to the same instance store (either on the same computer or a different computer), it recovers that instance. (Instance Recovery is out of scope for this sample.)  
  
-   Set the `RunnableInstancesDetectionPeriod`. This period defines the interval in which the host polls for instances that have become runnable. Instances may become runnable if any of the following events occur:  
  
    -   A Durable Timer (<xref:System.Activities.Statements.Delay>) expires.  
  
    -   Another host misses its `HostLockRenewal` heartbeat (for example, due to a computer crash) and the instance is recovered.  
  
-   Set the `InstanceCompletionAction`. This property, if set to `DeleteNothing`, keeps completed instances in the Instance Store; if set to `DeleteAll`, instances are deleted from the store upon completion. Note that  
  
    > [!NOTE]
    >  Terminating the host by pressing ENTER before the counting has completed does not complete the workflow instance.  
  
-   Set the `InstanceLockedExceptionAction`. This setting defines what a host should do if it wants to load an instance that is locked by another host. The following options exist:  
  
    -   If set to `NoRetry`: Do not retry the load and return an `InstanceLockedException` to the host.  
  
    -   If set to `BasicRetry`: Keep retrying to load the instance. The retries are scheduled according to a simple linear algorithm (for example, retry every 5 seconds).  
  
    -   If set to `AggressiveRetry`: Keep retrying to load the instance. The retries are scheduled according to an aggressive exponential back-off algorithm.  
  
-   Set the Encoding option. This setting defines how the instance state is stored in the SQL Workflow Instance Store. The following options exist:  
  
    -   The instance state is compressed using the GZip compression algorithm.  
  
    -   The instance state is not compressed.  
  
#### To use this sample  
  
1.  Open a [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] command prompt as an Administrator if permissions are available.  
  
2.  Navigate to the sample directory (\WF\Basic\Persistence\BuiltInConfiguration\CS) and run CreateInstanceStore.cmd.  
  
3.  If Administrator privileges are not available, Create SQL Server login. Go to `Security`, **Logins**. Right-click **Logins** and create a new login.  
  
4.  Add your ACL user to SQL role. Open **Databases**, **InstanceStore**, **Security**. Right-click **Users** and select **New users**. Set the **Login name** to the user created in the previous step. Add the user to the Database role membership **System.Activities.DurableInstancing.InstanceStoreUsers** (and others). Note that the user might exist already (for example, user dbo).  
  
5.  Open the InstanceStore.sln file in [!INCLUDE[vs2010](../../../../includes/vs2010-md.md)] and build the solution by pressing CTRL+SHIFT+B.  
  
6.  In [!INCLUDE[fileExplorer](../../../../includes/fileexplorer-md.md)], navigate to the sample’s appropriate bin\debug directory (\WF\Basic\Persistence\BuiltInConfiguration\cs\InstanceStore(1 or 2)\bin\debug), right click InstanceStore.exe and select **Run as administrator**. This sample must be run with administrative privileges because it opens a channel listener.  
  
7.  If you created the instance store in a database other than a local installation of SQL Server Express you must update the database connection string (`const string ConnectionString` in Program.cs of the InstanceStore1 project, and the `connectionString` attribute in App.config of the InstanceStore2 project) in the sample and recompile the sample.  
  
#### To verify the sample is running correctly  
  
1.  While the sample is running, start SQL Server Management Studio.  
  
2.  In the **Object Explorer**, select **Databases**, **InstanceStore**, **Tables**, and then **System.Activities.DurableInstancing.InstanceTable**.  
  
3.  Right click **InstanceTable** and select **Select Top 1000 Rows**.  
  
4.  Observe that there is a new entry and that the **Lock Expiration** changes every 5 seconds, (click the taskbar’s **Execute** button to refresh the query). This is a consequence of setting the **Host Lock Renewal Period** to 5.  
  
5.  Observe after the counting completes, that the entry in the instance table is removed. This is a consequence of setting **Instance Completion Action** to **DeleteAll**.  
  
6.  Press ENTER to terminate the workflow host application and observe that the **LockOwnersTable** is deleted.  
  
#### To uninstall the sample  
  
1.  Run RemoveInstanceStore.cmd in the sample directory (\WF\Basic\Persistence\BuiltInConfiguration).  
  
> [!IMPORTANT]
>  The samples may already be installed on your computer. Check for the following (default) directory before continuing.  
>   
>  `<InstallDrive>:\WF_WCF_Samples`  
>   
>  If this directory does not exist, go to [Windows Communication Foundation (WCF) and Windows Workflow Foundation (WF) Samples for .NET Framework 4](http://go.microsoft.com/fwlink/?LinkId=150780) to download all [!INCLUDE[indigo1](../../../../includes/indigo1-md.md)] and [!INCLUDE[wf1](../../../../includes/wf1-md.md)] samples. This sample is located in the following directory.  
>   
>  `<InstallDrive>:\WF_WCF_Samples\WF\Basic\Persistence\BuiltInConfiguration`  
  
## See Also  
 [AppFabric Hosting and Persistence Samples](http://go.microsoft.com/fwlink/?LinkId=193961)
