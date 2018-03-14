---
title: "Persistence Best Practices"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6974c5a4-1af8-4732-ab53-7d694608a3a0
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Persistence Best Practices
This document covers best practices for workflow design and configuration related to workflow persistence.  
  
## Design and Implementation of Durable Workflows  
 In general, workflows perform work in short periods that are interleaved with times during which the workflow is idle because it is waiting for an event. This event can be such things as a message or an expiring timer. To be able to unload the workflow instance when it becomes idle, the service host must persist the workflow instance. This is possible only if the workflow instance is not in a no-persist zone (for example, waiting for a transaction to complete, or waiting for an asynchronous callback). To allow an idle workflow instance to unload, the workflow author should use transaction scopes and asynchronous activities for short-lived actions only. In particular, the author should keep delay activities within these no-persist zones as short as possible.  
  
 A workflow can only be persisted if all of the data types used by the workflow are serializable. In addition, custom types used in persisted workflows must be serializable with <xref:System.Runtime.Serialization.NetDataContractSerializer> in order to be persisted by <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore>.  
  
 A workflow instance cannot be recovered in case of a host or computer failure if it has not been persisted. In general, we recommend that you persist a workflow instance early in the workflow’s life cycle.  
  
 If your workflow is busy for a long time, we recommend that you persist the workflow instance regularly throughout its busy period. You can do this by adding <xref:System.Activities.Statements.Persist> activities throughout the sequence of activities that keep the workflow instance busy. In this manner, application domain recycling, host failures, or computer failures do not cause the system to be rolled back to the start of the busy period. Be aware that adding <xref:System.Activities.Statements.Persist> activities to your workflow could lead to a degradation of performance.  
  
 Windows Server App Fabric greatly simplifies the configuration and use of persistence. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Windows Server App Fabric Persistence](http://go.microsoft.com/fwlink/?LinkID=201200&clcid=0x409)  
  
## Configuration of Scalability Parameters  
 Scalability and performance requirements determine the settings of the following parameters:  
  
-   <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior.TimeToPersist%2A>  
  
-   <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior.TimeToUnload%2A>  
  
-   <xref:System.ServiceModel.Activities.Description.SqlWorkflowInstanceStoreBehavior.InstanceLockedExceptionAction%2A>  
  
 These parameters should be set as follows, according to the current scenario.  
  
### Scenario: A Small Number of Workflow Instances That Require Optimal Response Time  
 In this scenario, all workflow instances should remain loaded when they become idle. Set <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior.TimeToUnload%2A> to a large value. The use of this setting prevents a workflow instance from moving between computers. Use this setting only if one or more of the following are true:  
  
-   A workflow instance receives a single message throughout its lifetime.  
  
-   All workflow instances run on a single computer  
  
-   All messages that are received by a workflow instance are received by the same computer.  
  
 Use <xref:System.Activities.Statements.Persist> activities or set <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior.TimeToPersist%2A> to 0 to enable recovery of your workflow instance after service host or computer failures.  
  
### Scenario: Workflow Instances Are Idle for Long Periods of Time  
 In this scenario, set <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior.TimeToUnload%2A> to 0 to release resources as soon as possible.  
  
### Scenario: Workflow Instances Receive Multiple Messages in a Short Period of Time  
 In this scenario, set <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior.TimeToUnload%2A> to 60 seconds if these messages are received by the same computer. This prevents a rapid sequence of unloading and loading of a workflow instance. This also does not keep the instance in memory for too long.  
  
 Set <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior.TimeToUnload%2A> to 0, and set <xref:System.ServiceModel.Activities.Description.SqlWorkflowInstanceStoreBehavior.InstanceLockedExceptionAction%2A> to BasicRetry or AggressiveRetry if these messages may be received by different computers. This allows the workflow instance to be loaded by another computer.  
  
### Scenario: Workflow Uses Delay Activities with Short Durations  
 In this scenario, the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> regularly polls the persistence database for instances that should be loaded because of an expired <xref:System.Activities.Statements.Delay> activity. If the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> finds a timer that will expire in the next polling interval, the SQL Workflow Instance Store shortens the polling interval. The next poll will then occur right after the timer has expired. This way, the SQL Workflow Instance Store achieves a high accuracy of timers that run longer than the polling interval, which is set by <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.RunnableInstancesDetectionPeriod%2A>. To enable timely processing of shorter delays, the workflow instance must remain in memory for at least one polling interval.  
  
 Set <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior.TimeToPersist%2A> to 0 to write the expiration time to the persistence database.  
  
 Set <xref:System.ServiceModel.Activities.Description.WorkflowIdleBehavior.TimeToUnload%2A> to longer than or equal to <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.RunnableInstancesDetectionPeriod%2A> to keep the instance in memory for at least one polling interval.  
  
 We do not recommend reducing the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.RunnableInstancesDetectionPeriod%2A> because this leads to an increased load on the persistence database. Each service host that uses the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> polls the database one time per detection period. Setting <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.RunnableInstancesDetectionPeriod%2A> to too small a time interval may cause your system's performance to decrease if the number of service hosts is large.  
  
## Configuring the SQL Workflow Instance Store  
 The SQL Workflow Instance Store has the following configuration parameters:  
  
 <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.InstanceEncodingOption%2A>  
 This parameter instructs the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> to compress the workflow instance state. Compression reduces the amount of data that is stored in the persistence database and reduces network traffic in case the persistence database resides on a dedicated database server. If compression is used, it requires computational resources to compress and extract the instance state. In most cases, compression yields increased performance.  
  
 <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.InstanceCompletionAction%2A>  
 This parameter instructs the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> to either keep or delete completed instances. Keeping completed instances increases the persistence database storage requirements and leads to larger tables, which increases table lookup times. Unless completed instances are required for debugging or auditing, it is best to instruct the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> to delete completed instances. Deleted instances should be kept only if the user establishes a process for eventually removing them. Note that correlation keys cannot be reused as long as the completed workflow instance resides in the instance store.  
  
 <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.RunnableInstancesDetectionPeriod%2A>  
 This parameter defines the maximum interval with which the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> polls the persistence database for instances that should be loaded when a <xref:System.Activities.Statements.Delay> activity expires. If the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> finds a timer that will expire in the next polling interval, it shortens the polling interval so that the next poll will occur right after the timer has expired. This way, the SQL Workflow Instance Store achieves a high accuracy of timers that run longer than <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.RunnableInstancesDetectionPeriod%2A>.  
  
 We do not recommend reducing the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.RunnableInstancesDetectionPeriod%2A>, because this leads to an increased load on the persistence database. Each service host that uses the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> polls the database one time per detection period. Setting <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.RunnableInstancesDetectionPeriod%2A> to too small an interval may cause your system's performance to decrease if the number of service hosts is large.  
  
 <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.HostLockRenewalPeriod%2A>  
 This parameter defines the interval with which the host renews its lock in the persistence database. Shortening this interval will enable a quicker recovery of the workflow instances in case a host or computer fails. On the other hand, a short lock renewal period increases the load on the persistence database. Each service host that uses the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> will update its locks in the database one time per renewal period. If a computer runs many service hosts, make sure that the load caused by lock renewal does not decrease your system's performance. If it does, consider increasing the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.HostLockRenewalPeriod%2A>.  
  
 <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.InstanceLockedExceptionAction%2A>  
 If enabled, the <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore> retries to load a locked instance for the next 30 seconds. Set <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.InstanceLockedExceptionAction%2A> to BasicRetry or AggressiveRetry if the workflow receives multiple messages in a short time, and these messages are received by different computers.  
  
 Because the load retry mechanism does not introduce any performance overhead as long as load retries are not tried, <xref:System.Activities.DurableInstancing.SqlWorkflowInstanceStore.InstanceLockedExceptionAction%2A> should always be enabled.
