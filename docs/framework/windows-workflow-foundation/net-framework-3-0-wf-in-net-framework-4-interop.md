---
title: "Using .NET Framework 3.0 WF Activities in .NET Framework 4 with the Interop Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 71f112ba-abb0-46f7-b05f-a5d2eb9d0c5c
caps.latest.revision: 15
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using .NET Framework 3.0 WF Activities in .NET Framework 4 with the Interop Activity
The <xref:System.Activities.Statements.Interop> activity is a [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] (WF 4.5) activity that wraps a [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] (WF 3.5) activity within a [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] workflow. The WF 3 activity can be a single leaf activity or an entire tree of activities. The execution (including cancellation and exception handling) and the persistence of the [!INCLUDE[netfx35_short](../../../includes/netfx35-short-md.md)] activity occur within the context of the [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] workflow instance that is executing.  
  
> [!NOTE]
>  The <xref:System.Activities.Statements.Interop> activity does not appear in the workflow designer toolbox unless the workflow's project has its **Target Framework** setting set to **.NET Framework 4.5**.  
  
## Criteria for Using a WF 3 Activity with an Interop Activity  
 For a WF 3 activity to successfully execute within an <xref:System.Activities.Statements.Interop> activity, the following criteria must be met:  
  
-   The WF 3 activity must derive from <xref:System.Workflow.ComponentModel.Activity?displayProperty=nameWithType>.  
  
-   The WF 3 activity must be declared as `public` and cannot be `abstract`.  
  
-   The WF 3 activity must have a public default constructor.  
  
-   Due to limitations in the interface types that the <xref:System.Activities.Statements.Interop> activity can support, <xref:System.Workflow.Activities.HandleExternalEventActivity> and <xref:System.Workflow.Activities.CallExternalMethodActivity> cannot be used directly, but derivative activities created using the Workflow Communication Activity tool (WCA.exe) can be used. See [Windows Workflow Foundation Tools](http://go.microsoft.com/fwlink/?LinkId=178889) for details.  
  
## Configuring a WF 3 Activity Within an Interop Activity  
 To configure and pass data into and out of a WF 3 activity, across the interoperation boundary, the WF 3 activity’s properties and metadata properties are exposed by the <xref:System.Activities.Statements.Interop> activity. The WF 3 activity’s metadata properties (such as <xref:System.Workflow.ComponentModel.Activity.Name%2A>) are exposed through the <xref:System.Activities.Statements.Interop.ActivityMetaProperties%2A> collection. This is a collection of name-value pairs used to define the values for the WF 3 activity’s metadata properties. A metadata property is a property backed by dependency property for which the <xref:System.Workflow.ComponentModel.DependencyPropertyOptions.Metadata> flag is set.  
  
 The WF 3 activity’s properties are exposed through the <xref:System.Activities.Statements.Interop.ActivityProperties%2A> collection. This is a set of name-value pairs, where each value is a <xref:System.Activities.Argument> object, used to define the arguments for the WF 3 activity’s properties. Because the direction of a WF 3 activity property cannot be inferred, every property is surfaced as an <xref:System.Activities.InArgument>/<xref:System.Activities.OutArgument> pair. Depending on the activity’s usage of the property, you may want to provide an <xref:System.Activities.InArgument> entry, an <xref:System.Activities.OutArgument> entry, or both. The expected name of the <xref:System.Activities.InArgument> entry in the collection is the name of the property as defined on the WF 3 activity. The expected name of the <xref:System.Activities.OutArgument> entry in the collection is a concatenation of the name of the property and the string "Out".  
  
## Limitations of Using a WF 3 Activity Within an Interop Activity  
 The WF 3 system-provided activities cannot be directly wrapped in an <xref:System.Activities.Statements.Interop> activity. For some WF 3 activities, such as <xref:System.Workflow.Activities.DelayActivity>, this is because there is an analogous WF 4.5 activity. For others, this is because the functionality of the activity is not supported. Many WF 3 system-provided activities can be used within workflows wrapped by the <xref:System.Activities.Statements.Interop> activity, subject to the following restrictions:  
  
1.  <xref:System.ServiceModel.Activities.Send> and <xref:System.ServiceModel.Activities.Receive> cannot be used in an <xref:System.Activities.Statements.Interop> activity.  
  
2.  <xref:System.Workflow.Activities.WebServiceInputActivity>, <xref:System.Workflow.Activities.WebServiceOutputActivity>, and <xref:System.Workflow.Activities.WebServiceFaultActivity> cannot be used within an <xref:System.Activities.Statements.Interop> activity.  
  
3.  <xref:System.Workflow.Activities.InvokeWorkflowActivity> cannot be used within an <xref:System.Activities.Statements.Interop> activity.  
  
4.  <xref:System.Workflow.ComponentModel.SuspendActivity> cannot be used within an <xref:System.Activities.Statements.Interop> activity.  
  
5.  Compensation-related activities cannot be used within an <xref:System.Activities.Statements.Interop> activity.  
  
 There are also some behavioral specifics to understand regarding the use of WF 3 activities within the <xref:System.Activities.Statements.Interop> activity:  
  
1.  WF 3 activities contained within an <xref:System.Activities.Statements.Interop> activity are initialized when the <xref:System.Activities.Statements.Interop> activity is executed. In WF 4.5 there is no initialization phase for a workflow instance prior to its execution.  
  
2.  The WF 4.5 runtime does not checkpoint workflow instance state when a transaction begins, regardless of where that transaction begins (within or outside of an <xref:System.Activities.Statements.Interop> activity).  
  
3.  WF 3 tracking records for activities within an <xref:System.Activities.Statements.Interop> activity are provided to WF 4.5 tracking participants as <xref:System.Activities.Tracking.InteropTrackingRecord> objects. <xref:System.Activities.Tracking.InteropTrackingRecord> is a derivative of <xref:System.Activities.Tracking.CustomTrackingRecord>.  
  
4.  A WF 3 custom activity can access data using workflow queues within the interoperation environment in exactly the same way as within the WF 3 workflow runtime. No custom activity code changes are required. On the host, data is enqueued to a WF 3 workflow queue by resuming a <xref:System.Activities.Bookmark>. The name of the bookmark is the string form of the <xref:System.IComparable> workflow queue name.  
  
## See Also  
 [Using a .NET Framework 3.0 or .NET Framework 3.5 Activity in a .NET Framework 4.5 Workflow](../../../docs/framework/windows-workflow-foundation/samples/using-a-net-3-0-or-net-3-5-activity-in-a-net-4-5-workflow.md)
