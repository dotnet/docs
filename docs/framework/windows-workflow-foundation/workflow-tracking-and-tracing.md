---
title: "Workflow Tracking and Tracing"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "programming [WF], tracking and tracing"
ms.assetid: b965ded6-370a-483d-8790-f794f65b137e
caps.latest.revision: 16
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Workflow Tracking and Tracing
Windows Workflow tracking is a [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] feature designed to provide visibility into workflow execution. It provides a tracking infrastructure to track the execution of a workflow instance. The WF tracking infrastructure transparently instruments a workflow to emit records reflecting key events during the execution. This functionality is available by default for any [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] workflow. No changes are required to be made to a [!INCLUDE[netfx_current_long](../../../includes/netfx-current-long-md.md)] workflow for tracking to occur. It is just a matter of deciding how much tracking data you want to receive. When a workflow instance starts or completes, its processing tracking records are emitted. Tracking can also extract business-relevant data associated with the workflow variables. For example, if the workflow represents an order processing system, the order ID can be extracted along with the <xref:System.Activities.Tracking.TrackingRecord> object. In general, enabling WF tracking facilitates diagnostics or business analytics data to be accessed from a workflow execution.  
  
 These tracking components are equivalent to the tracking service in [!INCLUDE[vstecwinfx](../../../includes/vstecwinfx-md.md)]. In [!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)], the performance has been improved and the programming model simplified for the WF tracking feature. The tracking runtime instruments a workflow instance to emit events related to the workflow life cycle, workflow activities and custom events.  
  
 Windows Server App Fabric also provides the ability to monitor the execution of a WCF and workflow services. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Windows Server App Fabric Monitoring](http://go.microsoft.com/fwlink/?LinkId=201273) and [Monitoring Applications with Windows Server AppFabric](http://go.microsoft.com/fwlink/?LinkId=201287)  
  
 To troubleshoot the workflow runtime, you can turn on diagnostic workflow tracing. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Workflow Tracing](../../../docs/framework/windows-workflow-foundation/workflow-tracing.md).  
  
 To understand the programming model, the primary components of the tracking infrastructure are discussed in this topic:  
  
-   <xref:System.Activities.Tracking.TrackingRecord> objects emitted from the workflow runtime. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Tracking Records](../../../docs/framework/windows-workflow-foundation/tracking-records.md).  
  
-   <xref:System.Activities.Tracking.TrackingParticipant> objects subscribe to <xref:System.Activities.Tracking.TrackingRecord> objects. The tracking participants contain the logic to process the payload from the <xref:System.Activities.Tracking.TrackingRecord> objects (for example, they could choose to write to a file). [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Tracking Participants](../../../docs/framework/windows-workflow-foundation/tracking-participants.md).  
  
-   <xref:System.Activities.Tracking.TrackingProfile> objects filter tracking records emitted from a workflow instance. [!INCLUDE[crdefault](../../../includes/crdefault-md.md)] [Tracking Profiles](../../../docs/framework/windows-workflow-foundation/tracking-profiles.md).  
  
## Workflow Tracking Infrastructure  
 The workflow tracking infrastructure follows a publish-and-subscribe paradigm. The workflow instance is the publisher of tracking records, while subscribers of the tracking records are registered as extensions to the workflow. These extensions that subscribe to <xref:System.Activities.Tracking.TrackingRecord> objects are called tracking participants. Tracking participants are extensibility points that access <xref:System.Activities.Tracking.TrackingRecord> objects and process them in whatever manner they are written to do so. The tracking infrastructure allows the application of a filter on the outgoing tracking records to allow a participant to subscribe to a subset of the records. This filtering mechanism is accomplished through a tracking profile file.  
  
 A high level view of the tracking infrastructure is shown in the following illustration.  
  
 ![Workflow Tracking Infrastructure](../../../docs/framework/windows-workflow-foundation/media/wv.gif "WV")  
  
## In This Section  
 [Tracking Records](../../../docs/framework/windows-workflow-foundation/tracking-records.md)  
 Describes the tracking records that the workflow runtime emits.  
  
 [Tracking Profiles](../../../docs/framework/windows-workflow-foundation/tracking-profiles.md)  
 Discusses how tracking profiles are used.  
  
 [Tracking Participants](../../../docs/framework/windows-workflow-foundation/tracking-participants.md)  
 Describes how to use system-provided tracking participant or how to create custom tracking participants.  
  
 [Configuring Tracking for a Workflow](../../../docs/framework/windows-workflow-foundation/configuring-tracking-for-a-workflow.md)  
 Describes how to configure tracking for a workflow.  
  
 [Workflow Tracing](../../../docs/framework/windows-workflow-foundation/workflow-tracing.md)  
 Describes the two ways to enable debug tracing for a workflow.  
  
 [Determining Workflow Execution Duration Using Tracing](../../../docs/framework/windows-workflow-foundation/determining-workflow-execution-duration-using-tracing.md)  
 Describes how to use tracing messages to determine workflow execution duration.  
  
## See Also  
 [SQL Tracking](../../../docs/framework/windows-workflow-foundation/samples/sql-tracking.md)
