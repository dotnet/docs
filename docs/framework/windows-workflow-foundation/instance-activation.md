---
title: "Instance Activation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 134c3f70-5d4e-46d0-9d49-469a6643edd8
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Instance Activation
The SQL Workflow Instance Store runs an internal task that periodically wakes up and detects runnable or activatable workflow instances in the persistence database. If it finds a runnable workflow instance, it notifies the workflow host that is capable of activating the instance. If the instance store finds an activatable workflow instance, it notifies a generic host that activates a workflow host, which in turn runs the workflow instance. The following sections in this topic explain the instance activation process in detail.  
  
##  <a name="RunnableSection"></a> Detecting and Activating Runnable Workflow Instances  
 The SQL Workflow Instance Store considers a workflow instance *runnable* if the instance is not in the suspended state or the completed state and satisfies the following conditions:  
  
-   The instance is unlocked and has a pending timer that has expired.  
  
-   The instance has an expired lock on it.  
  
-   The instance is unlocked and its status is **Executing**.  
  
 The SQL Workflow Instance Store raises the <xref:System.Activities.DurableInstancing.HasRunnableWorkflowEvent> when it finds a runnable instance. After this, the SqlWorkflowInstanceStore stops monitoring until the <xref:System.Activities.DurableInstancing.TryLoadRunnableWorkflowCommand> is called once on the store.  
  
 A workflow host that has subscribed for the <xref:System.Activities.DurableInstancing.HasRunnableWorkflowEvent> and capable of loading the instance executes the <xref:System.Activities.DurableInstancing.TryLoadRunnableWorkflowCommand> against the instance store to load the instance into memory. A workflow host is considered capable of loading a workflow instance if the host and the instance have metadata property **WorkflowServiceType** set to the same value.  
  
## Detecting and Activating Activatable Workflow Instances  
 A workflow instance is considered *activatable* if the instance is runnable and there is no workflow host that is capable of loading the instance is running on the computer. See Detecting and Activating Runnable Workflow Instances above for the definition of a runnable workflow instance.  
  
 The SQL Workflow Instance Store raises the <xref:System.Activities.DurableInstancing.HasActivatableWorkflowEvent> when it finds an activatable workflow instance in the database. After this, the SqlWorkflowInstanceStore stops monitoring until the <xref:System.Activities.DurableInstancing.QueryActivatableWorkflowsCommand> is called once on the store.  
  
 When a generic host that has subscribed for the <xref:System.Activities.DurableInstancing.HasActivatableWorkflowEvent> receives the event, it executes the <xref:System.Activities.DurableInstancing.QueryActivatableWorkflowsCommand> against the instance store to obtain activation parameters required to create a workflow host. The generic host uses these activation parameters to create a workflow host, which in turn loads and runs the runnable service instance.  
  
## Generic Hosts  
 A generic host is a host with the value of the metadata property **WorkflowServiceType** for generic hosts is set to **WorkflowServiceType.Any** to indicate that it can handle any workflow type. A generic host has an XName parameter named **ActivationType**.  
  
 Currently, the SQL Workflow Instance Store supports generic hosts with value of the ActivationType parameter set to **WAS**. If the ActivationType is not set to WAS, the SQL Workflow Instance Store throws an <xref:System.Runtime.DurableInstancing.InstancePersistenceException>. The Workflow Management Service that ships with the [!INCLUDE[dublin](../../../includes/dublin-md.md)] is a generic host that has the activation type set to **WAS**.  
  
 For WAS activation, a generic host requires a set of activation parameters to derive the endpoint address at which new hosts can be activated. The activation parameters for WAS activation are name of the site, path to the application relative to the site, and path to the service relative to the application. The SQL Workflow Instance Store stores these activation parameters during the execution of the <xref:System.Activities.DurableInstancing.SaveWorkflowCommand>.  
  
## Runnable Instances Detection Period  
 The **Runnable Instances Detection Period** property of the SQL Workflow Instance Store specifies the time period after which the SQL Workflow Instance Store runs a detection task to detect any runnable or activatable workflow instances in the persistence database after the previous detection cycle. See [Runnable Instances Detection Period](../../../docs/framework/windows-workflow-foundation/runnable-instances-detection-period.md) for more details on this property.
