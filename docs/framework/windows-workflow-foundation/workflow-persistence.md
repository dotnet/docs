---
title: "Workflow Persistence"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "programming [WF], persistence"
ms.assetid: 39e69d1f-b771-4c16-9e18-696fa43b65b2
caps.latest.revision: 26
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Persistence
Workflow persistence is the durable capture of a workflow instance's state, independent of process or computer information. This is done to provide a well-known point of recovery for the workflow instance in the event of system failure, or to preserve memory by unloading workflow instances that are not actively doing work, or to move the state of the workflow instance from one node to another node in a server farm.  
  
 Persistence enables process agility, scalability, recovery in the face of failure, and the ability to manage memory more efficiently. The persistence process includes the identification of a persistence point, the gathering of the data to be saved, and finally the delegation of the actual storage of the data to a persistence provider.  
  
 To enable persistence for a workflow, you need to associate an instance store with the **WorkflowApplication** or **WorkflowServiceHost** as mentioned in [How to: Enable Persistence for Workflows and Workflow Services](../../../docs/framework/windows-workflow-foundation/how-to-enable-persistence-for-workflows-and-workflow-services.md). The **WorkflowApplication** and **WorkflowServiceHost** use the instance store associated with them to enable persisting workflow instances into a persistence store and loading workflow instances into memory based on the workflow instance data stored in the persistence store.  
  
 The [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] ships with the **SqlWorkflowInstanceStore** class, which allows persistence of data and metadata about workflow instances into a SQL Server 2005 or SQL Server 2008 database. See [SQL Workflow Instance Store](../../../docs/framework/windows-workflow-foundation/sql-workflow-instance-store.md) for more details.  
  
 To store and load your application-specific data along with the workflow instance-related information, you can create persistence participants that extend the <xref:System.Activities.Persistence.PersistenceParticipant> class. A persistence participant participates in the persistence process to save custom serializable data into the persistence store, to load the data from the instance store into memory, and to perform any additional logic under a persistence transaction. For more information, see [Persistence Participants](../../../docs/framework/windows-workflow-foundation/persistence-participants.md).  
  
 Windows Server App Fabric simplifies the process of configuring persistence. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Persistence Concepts with Windows Server App Fabric](http://go.microsoft.com/fwlink/?LinkId=201200)  
  
## Implicit Persistence Points  
 The following list contains examples of the conditions upon which a workflow is persisted when an instance store is associated with a workflow.  
  
-   When a **TransactionScope** activity completes or a **TransactedReceiveScope** activity completes.  
  
-   When a workflow instance becomes idle and the **WorkflowIdleBehavior** is set on workflow host. This occurs, for example, when you use messaging activities or a **Delay** activity.  
  
-   When a WorkflowApplication becomes idle and the **PersistableIdle** property of the application is set to **PersistableIdleAction.Persist**.  
  
-   When a host application is instructed to persist or unload a workflow instance.  
  
-   When a workflow instance is terminated or finishes.  
  
-   When a **Persist** activity executes.  
  
-   When an instance of a workflow developed using a previous version of Windows Workflow Foundation encounters a persistence point during interoperable execution.  
  
## In This Section  
  
-   [SQL Workflow Instance Store](../../../docs/framework/windows-workflow-foundation/sql-workflow-instance-store.md)  
  
-   [Instance Stores](../../../docs/framework/windows-workflow-foundation/instance-stores.md)  
  
-   [Persistence Participants](../../../docs/framework/windows-workflow-foundation/persistence-participants.md)  
  
-   [Persistence Best Practices](../../../docs/framework/windows-workflow-foundation/persistence-best-practices.md)  
  
-   [Non-Persisted Workflow Instances](../../../docs/framework/windows-workflow-foundation/non-persisted-workflow-instances.md)  
  
-   [Pausing and Resuming a Workflow](../../../docs/framework/windows-workflow-foundation/pausing-and-resuming-a-workflow.md)
