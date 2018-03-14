---
title: "Fundamental Windows Workflow Concepts"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 0e930e80-5060-45d2-8a7a-95c0690105d4
caps.latest.revision: 27
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Fundamental Windows Workflow Concepts
Workflow development in the [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] uses concepts that may be new to some developers. This topic describes some of the concepts and how they are implemented.  
  
## Workflows and Activities  
 A workflow is a structured collection of actions that models a process. Each action in the workflow is modeled as an activity. A host interacts with a workflow by using <xref:System.Activities.WorkflowInvoker> for invoking a workflow as if it were a method,  <xref:System.Activities.WorkflowApplication> for explicit control over the execution of a single workflow instance, and <xref:System.ServiceModel.WorkflowServiceHost> for message-based interactions in multi-instance scenarios. Because steps of the workflow are defined as a hierarchy of activities, the topmost activity in the hierarchy can be said to define the workflow itself. This hierarchy model takes the place of the explicit `SequentialWorkflow` and `StateMachineWorkflow` classes from previous versions. Activities themselves are developed as collections of other activities (using the <xref:System.Activities.Activity> class as a base, usually defined by using XAML) or are custom created by using the <xref:System.Activities.CodeActivity> class, which can use the runtime for data access, or by using the <xref:System.Activities.NativeActivity> class, which exposes the breadth of the workflow runtime to the activity author. Activities developed by using <xref:System.Activities.CodeActivity> and <xref:System.Activities.NativeActivity> are created by using CLR-compliant languages such as C#.  
  
## Activity Data Model  
 Activities store and share data by using the types shown in the following table.  
  
|||  
|-|-|  
|Variable|Stores data in an activity.|  
|Argument|Moves data into and out of an activity.|  
|Expression|An activity with an elevated return value used in argument bindings.|  
  
## Workflow Runtime  
 The workflow runtime is the environment in which workflows execute. <xref:System.Activities.WorkflowInvoker> is the simplest way to execute a workflow. The host uses <xref:System.Activities.WorkflowInvoker> for the following:  
  
-   To synchronously invoke a workflow.  
  
-   To provide input to, or retrieve output from a workflow.  
  
-   To add extensions to be used by activities.  
  
 <xref:System.Activities.ActivityInstance> is the thread-safe proxy that hosts can use to interact with the runtime. The host uses <xref:System.Activities.ActivityInstance> for the following:  
  
-   To acquire an instance by creating it or loading it from an instance store.  
  
-   To be notified of instance life-cycle events.  
  
-   To control workflow execution.  
  
-   To provide input to, or retrieve output from a workflow.  
  
-   To signal a workflow continuation and pass values into the workflow.  
  
-   To persist workflow data.  
  
-   To add extensions to be used by activities.  
  
 Activities gain access to the workflow runtime environment by using the appropriate <xref:System.Activities.ActivityContext> derived class, such as <xref:System.Activities.NativeActivityContext> or <xref:System.Activities.CodeActivityContext>. They use this for resolving arguments and variables, for scheduling child activities, and for many other purposes.  
  
## Services  
 Workflows provide a natural way to implement and access loosely-coupled services, using messaging activities. Messaging activities are built on [!INCLUDE[indigo2](../../../includes/indigo2-md.md)] and are the primary mechanism used to get data into and out of a workflow. You can compose messaging activities together to model any kind of message exchange pattern you wish. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] see [Messaging Activities](../../../docs/framework/wcf/feature-details/messaging-activities.md). Workflow services are hosted using the <xref:System.ServiceModel.Activities.WorkflowServiceHost> class. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Hosting Workflow Services Overview](../../../docs/framework/wcf/feature-details/hosting-workflow-services-overview.md). [!INCLUDE[crabout](../../../includes/crabout-md.md)] workflow services see [Workflow Services](../../../docs/framework/wcf/feature-details/workflow-services.md)  
  
## Persistence, Unloading, and Long-Running Workflows  
 Windows Workflow simplifies the authoring of long-running reactive programs by providing:  
  
-   Activities that access external input.  
  
-   The ability to create <xref:System.Activities.Bookmark> objects that can be resumed by a host listener.  
  
-   The ability to persist a workflow’s data and unload the workflow, and then reload and reactivate the workflow in response to the resumption of <xref:System.Activities.Bookmark> objects in a particular workflow.  
  
 A workflow continuously executes activities until there are no more activities to execute or until all currently executing activities are waiting for input. In this latter state, the workflow is idle. It is common for a host to unload workflows that have gone idle and to reload them to continue execution when a message arrives. <xref:System.ServiceModel.Activities.WorkflowServiceHost> provides functionality for this feature and provides an extensible unload policy. For blocks of execution that use volatile state data or other data that cannot be persisted, an activity can indicate to a host that it should not be persisted by using the <xref:System.Activities.NoPersistHandle>. A workflow can also explicitly persist its data to a durable storage medium by using the <xref:System.Activities.Statements.Persist> activity.
