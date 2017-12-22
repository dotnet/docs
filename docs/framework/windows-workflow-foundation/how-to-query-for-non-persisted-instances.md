---
title: "How to: Query for Non-persisted Instances"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 294019b1-c1a7-4b81-a14f-b47c106cd723
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# How to: Query for Non-persisted Instances
When a new instance of a service is created and the service has the SQL Workflow Instance Store behavior defined, the service host creates a initial entry for that service instance in the instance store. Subsequently when the service instance persists for the first time, the SQL Workflow Instance Store behavior stores the current instance state together with additional data that is required for activation, recovery, and control.  
  
 If an instance is not persisted after the initial entry for the instance is created, the service instance is said to be in the non-persisted state. All the persisted service instances can be queried and controlled. Non-persisted service instances can neither be queried nor controlled. If a non-persisted instance is suspended due to an unhandled exception it can be queried but not controlled.  
  
 Durable service instances that are not yet persisted remain in a non-persisted state in the following scenarios:  
  
-   The service host crashes before the instance persisted for the first time. The initial entry for the instance remains in the instance store. The instance is not recoverable. If a correlated message arrives, the instance becomes active again.  
  
-   The instance experiences an unhandled exception before it persisted for the first time. The following scenarios arise  
  
    -   If the value of the **UnhandledExceptionAction** property is set to **Abandon**, the service deployment information is written to the instance store and the instance is unloaded from memory. The instance remains in non-persisted state in the persistence database.  
  
    -   If the value of the **UnhandledExceptionAction** property is set to **AbandonAndSuspsend**, the service deployment information is written to the persistence database and the instance state is set to **Suspended**. The instance cannot be resumed, canceled, or terminated. The service host cannot load the instance because the instance hasn't persisted yet and, hence the database entry for the instance is not complete.  
  
    -   If the value of the **UnhandledExceptionAction** property is set to **Cancel** or **Terminate**, the service deployment information is written to the instance store and the instance state is set to **Completed**.  
  
 The following sections provide sample queries to find non-persisted instances in the SQL persistence database and to delete these instances from the database.  
  
## To find all instances not persisted yet  
 The following SQL query returns the ID and creation time for all instances that are not persisted in to the persistence database yet.  
  
```  
select InstanceId, CreationTime from [System.Activities.DurableInstancing].[Instances] where IsInitialized = 0;  
```  
  
## To find all instances not persisted yet and also not loaded  
 The following SQL query returns ID and creation time for all instances that are not persisted and also are not loaded.  
  
```  
select InstanceId, CreationTime from [System.Activities.DurableInstancing].[Instances] where IsInitialized = 0 and CurrentMachine is NULL;  
```  
  
## To find all suspended instances not persisted yet  
 The following SQL query returns ID, creation time, suspension reason, and suspension exception name for all instances that are not persisted and also in a suspended state.  
  
```  
select InstanceId, CreationTime, SuspensionReason, SuspensionExceptionName from [System.Activities.DurableInstancing].[Instances] where IsInitialized = 0 and IsSuspended = 1;  
```  
  
## To delete non-persisted instances from the persistence database  
 You should periodically check the instance store for non-persisted instances and remove instances from the instance store if you are sure that the instance will not receive a correlated message. For example, if the instance has been in the database for several months and you know that the workflow typically has a lifetime of a few days, it would be safe to assume that this is an uninitialized instance that had crashed.  
  
 In general, it is safe to delete non-persisted instances that are not suspended or not loaded. You should not delete **all** the non-persisted instances because this instance set includes instances that are just created but are not persisted yet. You should only delete non-persisted instances that are left over because the workflow service host that had the instance loaded caused an exception or the instance itself caused an exception.  
  
> [!WARNING]
>  Deleting non-persisted instances from the instance store decreases the size of the store and may improve the performance of store operations.
