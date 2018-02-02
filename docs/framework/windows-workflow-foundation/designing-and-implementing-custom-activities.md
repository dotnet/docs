---
title: "Designing and Implementing Custom Activities"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4e30e63d-6e33-4842-a7a4-ce807cef1fad
caps.latest.revision: 22
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Designing and Implementing Custom Activities
Custom activities in [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] are created by either assembling system-provided activities into composite activities or by creating new types that derive from <xref:System.Activities.CodeActivity>, <xref:System.Activities.AsyncCodeActivity>, or <xref:System.Activities.NativeActivity>. This section describes how to create custom activities with either method.  
  
> [!IMPORTANT]
>  Custom activities by default display within the workflow designer as a simple rectangle with the activity’s name. To provide a custom visual representation of your activity in the workflow designer you must also create a custom designer. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Using Custom Activity Designers and Templates](../../../docs/framework/windows-workflow-foundation/using-custom-activity-designers-and-templates.md).  
  
## In This Section  
 [Activity Authoring Options](../../../docs/framework/windows-workflow-foundation/activity-authoring-options-in-wf.md)  
 Discusses the authoring styles available in [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)].  
  
 [Using a custom activity](../../../docs/framework/windows-workflow-foundation/using-a-custom-activity.md)  
 Describes how to add a custom activity to a workflow project.  
  
  [Creating Asynchronous Activities](../../../docs/framework/windows-workflow-foundation/creating-asynchronous-activities-in-wf.md)  
 Describes how to create asynchronous activities.  
  
 [Configuring Activity Validation](../../../docs/framework/windows-workflow-foundation/configuring-activity-validation.md)  
 Describes how activity validation can be used to identify and report errors in an activity’s configuration prior to its execution.  
  
 [Creating an Activity at Runtime](../../../docs/framework/windows-workflow-foundation/creating-an-activity-at-runtime-with-dynamicactivity.md)  
 Discusses how to create activities at runtime using <xref:System.Activities.DynamicActivity>.  
  
 [Workflow Execution Properties](../../../docs/framework/windows-workflow-foundation/workflow-execution-properties.md)  
 Describes how to use workflow execution properties to add context specific properties to an activity’s environment  
  
 [Using Activity Delegates](../../../docs/framework/windows-workflow-foundation/using-activity-delegates.md)  
 Discusses how to author and use activities that contain activity delegates.  
  
 [Activity Localization](../../../docs/framework/windows-workflow-foundation/activity-localization.md)  
 Describes how to use localization of string resources in activities.  
  
 [Using Activity Extensions](../../../docs/framework/windows-workflow-foundation/using-activity-extensions.md)  
 Describes how to author and use activity extensions.  
  
 [Consuming OData Feeds from a Workflow](../../../docs/framework/windows-workflow-foundation/consuming-odata-feeds-from-a-workflow.md)  
 Describes several methods for calling a WCF Data Service from a workflow.  
  
 [Activity Definition Scoping and Visibility](../../../docs/framework/windows-workflow-foundation/activity-definition-scoping-and-visibility.md)  
 Describes the options and rules for defining data scoping and member visibility for activities.
