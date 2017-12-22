---
title: "What&#39;s New in Windows Workflow Foundation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "Windows Workflow Foundation [WF], what's new"
  - "WF [WF], what's new"
ms.assetid: 11f96014-001e-41a0-bcc2-d0684a52fa43
caps.latest.revision: 29
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# What&#39;s New in Windows Workflow Foundation
[!INCLUDE[wf](../../../includes/wf-md.md)] in [!INCLUDE[netfx40_long](../../../includes/netfx40-long-md.md)] changes several development paradigms from previous versions. Workflows are now easier to create, execute, and maintain, and implement a host of new functionality. [!INCLUDE[crabout](../../../includes/crabout-md.md)] migrating .NET 3.0 and .NET 3.5 workflow applications to use the latest version, see [Migration Guidance](../../../docs/framework/windows-workflow-foundation/migration-guidance.md).  
  
## Workflow Activity Model  
 The activity is now the base unit of creating a workflow, rather than using the <xref:System.Workflow.Activities.SequentialWorkflowActivity> or <xref:System.Workflow.Activities.StateMachineWorkflowActivity> classes. The <xref:System.Activities.Activity> class provides the base abstraction of workflow behavior. Activity authors can then implement either <xref:System.Activities.CodeActivity> for basic custom activity functionality, or <xref:System.Activities.NativeActivity> for custom activity functionality that uses the breadth of the runtime. <xref:System.Activities.Activity> is a class used by activity authors to express new behaviors declaratively in terms of other <xref:System.Activities.NativeActivity>, <xref:System.Activities.CodeActivity>, <xref:System.Activities.AsyncCodeActivity>, or <xref:System.Activities.DynamicActivity> objects, whether they are custom-developed or included in the [Built-In Activity Library](../../../docs/framework/windows-workflow-foundation/net-framework-4-5-built-in-activity-library.md).  
  
## Rich Composite Activity Options  
 <xref:System.Activities.Statements.Flowchart> is a powerful new control flow activity that allows authors to model arbitrary loops and conditional branching. <xref:System.Activities.Statements.Flowchart> provides an event-driven programming model that was previously only able to be implemented with <xref:System.Workflow.Activities.StateMachineWorkflowActivity>. Procedural workflows benefit from new flow-control activities that model traditional flow-control structures, such as <xref:System.Activities.Statements.TryCatch> and <xref:System.Activities.Statements.Switch%601>.  
  
## Expanded Built-In Activity Library  
 New features of the activity library include:  
  
-   New flow control activities, such as, <xref:System.Activities.Statements.DoWhile>, <xref:System.Activities.Statements.Pick>, <xref:System.Activities.Statements.TryCatch>, <xref:System.Activities.Statements.ForEach%601>, <xref:System.Activities.Statements.Switch%601>, and <xref:System.Activities.Statements.ParallelForEach%601>.  
  
-   Activities for manipulating member data, such as <xref:System.Activities.Statements.Assign> and collection activities such as <xref:System.Activities.Statements.AddToCollection%601>.  
  
-   Activities for controlling transactions, such as <xref:System.Activities.Statements.TransactionScope> and <xref:System.Activities.Statements.Compensate>.  
  
-   New messaging activities such as <xref:System.ServiceModel.Activities.SendContent> and <xref:System.ServiceModel.Activities.ReceiveReply>.  
  
## Explicit Activity Data Model  
 [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)] includes new options for storing or moving data. Data can be stored in an activity using <xref:System.Activities.Variable>. When moving data in and out of an activity, specialized argument types are used to determine which direction data is moving. These types are <xref:System.Activities.InArgument>, <xref:System.Activities.InOutArgument>, and <xref:System.Activities.OutArgument>. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Windows Workflow Foundation Data Model](../../../docs/framework/windows-workflow-foundation/data-model.md).  
  
## Enhanced Hosting, Persistence, and Tracking Options  
 [!INCLUDE[netfx40_short](../../../includes/netfx40-short-md.md)] contains persistence enhancements such as the following:  
  
-   There are more options for running workflows, including <xref:System.ServiceModel.Activities.WorkflowServiceHost>, <xref:System.Activities.WorkflowApplication>, and <xref:System.Activities.WorkflowInvoker>.  
  
-   Workflow state data can be explicitly persisted using the <xref:System.Activities.Statements.Persist> activity.  
  
-   A host can persist an <xref:System.Activities.ActivityInstance> without unloading it.  
  
-   A workflow can specify no-persist zones while working with data that cannot be persisted, so that persistence is postponed until the no-persist zone exits.  
  
-   Transactions can be flowed into a workflow using <xref:System.Activities.Statements.TransactionScope>.  
  
-   Tracking is more easily accomplished using <xref:System.Activities.Tracking.TrackingParticipant>.  
  
-   Tracking to the system event log is provided using <xref:System.Activities.Tracking.EtwTrackingParticipant>.  
  
-   Resuming a pending workflow is now managed using a <xref:System.Activities.Bookmark> object.  
  
## Easier Ability to Extend WF Designer Experience  
 The new WF Designer is built on [!INCLUDE[avalon1](../../../includes/avalon1-md.md)] and provides an easier model to use when rehosting the WF Designer outside of Visual Studio and also provides easier mechanisms for creating custom activity designers. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Customizing the Workflow Design Experience](../../../docs/framework/windows-workflow-foundation/customizing-the-workflow-design-experience.md).
