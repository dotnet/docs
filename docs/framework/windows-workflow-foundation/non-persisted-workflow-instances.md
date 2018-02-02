---
title: "Non-Persisted Workflow Instances"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5e01af77-6b14-4964-91a5-7dfd143449c0
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Non-Persisted Workflow Instances
When a new instance of a workflow is created that persists its state in the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore>, the service host creates an entry for that service in the instance store. Subsequently, when the workflow instance is persisted for the first time, the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> stores the current instance state. If the workflow is hosted in the Windows Process Activation Service, the service deployment data is also written to the instance store when the instance is persisted for the first time.  
  
 As long as the workflow instance has not been persisted, it is in a **non-persisted** state. While in this state, the workflow instance cannot be recovered after an application domain recycle, host failure, or computer failure.  
  
## The Non-Persisted State  
 Durable workflow instances that have not been persisted remain in a non-persisted state in the following cases:  
  
-   The service host crashes before the workflow instance is persisted for the first time. The workflow instance remains in the instance store and is not recovered. If a correlated message arrives, the workflow instance becomes active again.  
  
-   The workflow instance experiences an exception before it is persisted for the first time. Depending on the <xref:System.Activities.UnhandledExceptionAction> returned, the following scenarios occur:  
  
    -   <xref:System.Activities.UnhandledExceptionAction> is set to <xref:System.Activities.UnhandledExceptionAction.Abort>: When an exception occurs, service deployment information is written to the instance store, and the workflow instance is unloaded from memory. The workflow instance remains in a non-persisted state and cannot be reloaded.  
  
    -   <xref:System.Activities.UnhandledExceptionAction> is set to <xref:System.Activities.UnhandledExceptionAction.Cancel> or <xref:System.Activities.UnhandledExceptionAction.Terminate>: When an exception occurs, service deployment information is written to the instance store, and the activity instance state is set to <xref:System.Activities.ActivityInstanceState.Closed>.  
  
 To minimize the risk of encountering unloaded non-persisted workflow instances, we recommend persisting the workflow early in its life cycle.  
  
## Detection and Removal of Non-Persisted Instances  
 The <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> does not remove any non-persisted workflow instances from the instance store. It also does not remove any expired lock owners that have non-persisted workflow instances associated with them.  
  
 We recommend that the administrator periodically checks the instance store for non-persisted instances. Administrators can remove those instances from the instance store as long as they know that this workflow will not receive correlated messages. For example, if the instance has been in the database for several months and it is known that the workflow typically has a lifetime of several days, it would be safe to assume that this was an initialized instance that had crashed.  
  
 To find non-persisted instances in the SQL Workflow Instance Store you can use the following SQL queries:  
  
-   This query finds all instances that have not been persisted, and returns the ID and creation time (stored in UTC time) for them.  
  
    ```sql  
    select InstanceId, CreationTime   
        from [System.Activities.DurableInstancing].[Instances]   
        where IsInitialized = 0  
    ```  
  
-   This query finds all instances that have not been persisted, and that are not loaded, and returns the ID and creation time (stored in UTC time) for them.  
  
    ```sql  
    select InstanceId, CreationTime   
        from [System.Activities.DurableInstancing].[Instances]   
        where IsInitialized = 0   
            and CurrentMachine is NULL  
    ```  
  
-   This query finds all suspended instances that have not been persisted, and returns the ID, creation time (stored in UTC time), suspension reason, and exception name for them.  
  
    ```sql  
    select InstanceId, CreationTime, SuspensionReason, SuspensionExceptionName   
        from [System.Activities.DurableInstancing].[Instances]   
        where IsInitialized = 0   
            and IsSuspended = 1  
    ```  
  
 Use care when you are deleting non-persisted instances. In general, it is safe to remove non-persisted instances created by <xref:System.ServiceModel.Activities.WorkflowServiceHost> that are suspended or are not loaded. Those specific instances can be deleted from the store by deleting them from the `[System.Activities.DurableInstancing].[Instances]` view by using the following SQL command, substituting the correct instance ID.  
  
```sql  
delete [System.Activities.DurableInstancing].[Instances]   
    where InstanceId=’078a9bc4-ada5-4f9e-8cce-b0eb0009995f’  
```  
  
> [!WARNING]
>  We do not recommend removing all non-persisted instances because this includes instances that have just been created and have not yet been persisted.
