---
title: "Instance Stores"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f2629668-0923-4987-b943-67477131c1e0
caps.latest.revision: 14
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Instance Stores
An instance store is a logical container of instances. It is the place where the instance data and metadata is stored. An instance store does not imply dedicated physical storage. An instance store could contain durable information in a SQL Server database or non-durable state information in a memory. The [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] ships with the SQL Workflow Instance Store, which is a concrete implementation of an instance store that allows workflows to persist instance data and metadata into a SQL Server 2005 or SQL Server 2008 database. In addition Windows Server App Fabric also provides a concrete implementation of an instance store. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Windows Server App Fabric Instance Store, Query, and Control Providers](http://go.microsoft.com/fwlink/?LinkID=201201&clcid=0x409).  
  
 The persistence API is the interface between a host and an instance store that allows the host to send command requests (for example, <xref:System.Activities.DurableInstancing.LoadWorkflowCommand> and <xref:System.Activities.DurableInstancing.SaveWorkflowCommand>) to the instance store. The concrete implementation of this API is called a persistence provider. The persistence provider receives requests from a host and modifies the instance store.  
  
 Hosts and instance stores are pluggable so that a host can be used with many instance stores, and an instance store can be used with many hosts. An instance store is typically optimized for the usage patterns of a particular host, although the instance store and host may evolve on independent life cycles. For example, the **WorkflowServiceHost** and the **SqlWorkflowInstanceStore** are designed to work well together. You can create your own instance store to persist data and metadata of workflow service instances and use that instance store with the **WorkflowServiceHost**. For example, you can create an OracleWorkflowInstanceStore that lets workflows persist information into an Oracle database instead of saving them into a SQL Server database.  
  
 It is common for hosts to be extended with additional functionality that modifies the persisted objects. For example, an instance persistence system may have a workflow host, an extension that supports the "Suspend" operation, and an SQL instance store.  The workflow host might send a standard command such as Save or Load to save or load a workflow from an instance store or to save a workflow into an instance store. The suspend extension might add additional semantics to the commands for saving and loading workflow instances so that a suspended workflow instance cannot be loaded. The persistence provider for the SQL instance store understands the commands for saving and loading workflow instances, and implements the commands by calling appropriate stored procedures that change the tables of persistent objects in an SQL Server database.  
  
 A host acts as an instance owner within an instance store. A host may act as more than one instance owner with more than one instance store at the same time. The host provides GUIDs for instance keys associated with the instances. An instance key is a unique alias that identifies an instance. The persistence system creates, updates, and deletes instance owner information as it executes commands requested by hosts.  
  
 The following list contains the important steps involved in the host’s interaction with the instance store:  
  
1.  Obtain an **InstanceStore** from a persistence provider.  

2.  Obtain the handle to an instance by calling the <xref:System.Runtime.DurableInstancing.InstanceStore.CreateInstanceHandle%2A> method on the **InstanceStore**.  
  
3.  Invoke commands against the instance handle by calling the <xref:System.Runtime.DurableInstancing.InstanceStore.Execute%2A> method on the **InstanceStore**.  
  
4.  Examine the <xref:System.Runtime.DurableInstancing.InstanceView> returned by **InstanceStore.Execute** to determine the results of the commands.
