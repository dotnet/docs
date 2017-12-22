---
title: "Tracking Records"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 51adbda3-bd8b-4892-a8ea-d343186472d2
caps.latest.revision: 20
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Tracking Records
The workflow runtime is instrumented to emit tracking records to follow the execution of a workflow instance.  
  
## Tracking Records  
 The following table details the tracking records that the workflow runtime emits.  
  
|Tracking record|Description|  
|---------------------|-----------------|  
|Workflow life cycle records|Emitted during various stages of the life cycle of the workflow instance. For example, a record is emitted when the workflow starts or completes.|  
|Activity life cycle records|Details activity execution. These records indicate the state of a workflow activity such as when an activity is scheduled, when the activity completes, or when a fault occurs.|  
|Bookmark resumption records|Emitted whenever a bookmark within a workflow instance is resumed.|  
|Custom tracking records|A workflow author can create custom tracking records and emit them within a custom activity.|  
  
 All tracking-related records emitted from the WF runtime derive from the base class <xref:System.Activities.Tracking.TrackingRecord>, which contains the common set of data. Tracking records show the life cycle for a simple workflow. Each tracking record contains details about the associated tracking event, such as the <xref:System.Activities.Tracking.TrackingRecord.InstanceId%2A>, <xref:System.Activities.Tracking.TrackingRecord.RecordNumber%2A>, and additional information specific to the type of tracking record.  
  
 The following types of <xref:System.Activities.Tracking.TrackingRecord> objects are emitted by the workflow runtime:  
  
-   **WorkflowInstanceRecord** - This <xref:System.Activities.Tracking.TrackingRecord> describes the life cycle of the workflow instance. For example, a record is emitted when the workflow starts or completes, and contains the state of the workflow instance. The details of this record can be found at <xref:System.Activities.Tracking.WorkflowInstanceRecord>.  
  
-   **WorkflowInstanceAbortedRecord** - This <xref:System.Activities.Tracking.TrackingRecord> is emitted when a workflow instance aborts. The record contains the reason for the workflow instance being aborted. The details of this record can be found at <xref:System.Activities.Tracking.WorkflowInstanceAbortedRecord>.  
  
-   **WorkflowInstanceUnhandledExceptionRecord** - This <xref:System.Activities.Tracking.TrackingRecord> is emitted if an exception occurs in the workflow instance and is not handled by any activity. The record contains the exception details. The details of this record can be found at <xref:System.Activities.Tracking.WorkflowInstanceUnhandledExceptionRecord>.  
  
-   **WorkflowInstanceSuspendedRecord** - This <xref:System.Activities.Tracking.TrackingRecord> is emitted whenever a workflow instance is suspended. The record contains the reason for the workflow instance being suspended. The details of this record can be found at <xref:System.Activities.Tracking.WorkflowInstanceSuspendedRecord>.  
  
-   **WorkflowInstanceTerminatedRecord** - This <xref:System.Activities.Tracking.TrackingRecord> is emitted whenever a workflow instance is terminated. The record contains the reason for the workflow instance being terminated. The details of this record can be found at <xref:System.Activities.Tracking.WorkflowInstanceTerminatedRecord>.  
  
-   **ActivityStateRecord** - This <xref:System.Activities.Tracking.TrackingRecord> is emitted when an activity within a workflow executes. These records indicate the state of the activity within the workflow instance. The details of this record can be found at <xref:System.Activities.Tracking.ActivityStateRecord>.  
  
-   **ActivityScheduledRecord** - This <xref:System.Activities.Tracking.TrackingRecord> is emitted when an activity schedules a child activity. This record contains details for both the parent activity (scheduling activity) and the scheduled child activity. The details of this record can be found at <xref:System.Activities.Tracking.ActivityScheduledRecord>.  
  
-   **FaultPropagationRecord** - This <xref:System.Activities.Tracking.TrackingRecord> is emitted for each handler that looks at the record until it is handled. It is used to denote the path a fault took within the workflow instance. The details of this record can be found at <xref:System.Activities.Tracking.FaultPropagationRecord>.  
  
-   **CancelRequestedRecord** - This <xref:System.Activities.Tracking.TrackingRecord> is emitted whenever an activity tries to cancel a child activity. This record contains details for both the parent activity and the child activity that is being canceled. The details of this record can be found at <xref:System.Activities.Tracking.CancelRequestedRecord>.  
  
-   **BookmarkResumptionRecord** - This <xref:System.Activities.Tracking.TrackingRecord> tracks any bookmark that is successfully resumed. The details of this record can be found at <xref:System.Activities.Tracking.BookmarkResumptionRecord>.  
  
-   **CustomTrackingRecord** - This <xref:System.Activities.Tracking.TrackingRecord> is created and emitted by a workflow author within a custom workflow activity. Custom tracking records can be populated with data to be emitted along with the records. The details of this record can be found at <xref:System.Activities.Tracking.CustomTrackingRecord>.  
  
 For example, there could be a simple <xref:System.Activities.Statements.Sequence> activity that contains a <xref:System.Activities.Statements.WriteLine> operation with tracking records emitted in the following order:  
  
1.  <xref:System.Activities.Tracking.WorkflowInstanceRecord> indicates that the workflow is starting.  
  
2.  <xref:System.Activities.Tracking.ActivityScheduledRecord> indicates that an activity has been scheduled. In this case it is a <xref:System.Activities.Statements.Sequence> activity.  
  
3.  <xref:System.Activities.Tracking.ActivityScheduledRecord> represents the <xref:System.Activities.Statements.WriteLine> activity.  
  
4.  There are two <xref:System.Activities.Tracking.ActivityStateRecord> records that represent the two activities completing.  
  
5.  <xref:System.Activities.Tracking.WorkflowInstanceRecord> indicates that the workflow is completing.  
  
## See Also  
 [Windows Server App Fabric Monitoring](http://go.microsoft.com/fwlink/?LinkId=201273)  
 [Monitoring Applications with App Fabric](http://go.microsoft.com/fwlink/?LinkId=201275)
