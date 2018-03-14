---
title: "Using Tracking to Troubleshoot Applications"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8851adde-c3c2-4391-9523-d8eb831490af
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Using Tracking to Troubleshoot Applications
[!INCLUDE[wf](../../../includes/wf-md.md)] enables you to track workflow-related information to give details into the execution of a [!INCLUDE[wf2](../../../includes/wf2-md.md)] application or service. [!INCLUDE[wf2](../../../includes/wf2-md.md)] hosts are able to capture workflow events during the execution of a workflow instance. If your workflow generates faults or exceptions, you can use the [!INCLUDE[wf2](../../../includes/wf2-md.md)] tracking details to troubleshooting its processing.  
  
## Troubleshooting a WF using WF Tracking  
 To detect faults within the processing of a [!INCLUDE[wf2](../../../includes/wf2-md.md)] activity, you can enable tracking with a tracking profile that queries for an <xref:System.Activities.Tracking.ActivityStateRecord> with the state of Faulted. The corresponding query is specified in the following code.  
  
```xml  
<activityStateQueries>  
              <activityStateQuery activityName="*">  
                <states>  
                  <state name="Faulted" />  
                </states>  
              </activityStateQuery>  
 </activityStateQueries>  
```  
  
 If a fault is propagated and handled within a fault handler (such as a <xref:System.Activities.Statements.TryCatch> activity) this can be detected using a <xref:System.Activities.Tracking.FaultPropagationRecord>. The <xref:System.Activities.Tracking.FaultPropagationRecord> indicates the source activity of the fault and the name of the fault handler. The <xref:System.Activities.Tracking.FaultPropagationRecord> contains fault details in form of the exception stack for the fault.The query to subscribe for a <xref:System.Activities.Tracking.FaultPropagationRecord> is shown in the following example.  
  
```xml  
<faultPropagationQueries>  
              <faultPropagationQuery faultSourceActivityName ="*" faultHandlerActivityName="*"/>  
 </faultPropagationQueries>  
```  
  
 If a fault is not handled within the workflow it results in an unhandled exception at the workflow instance and the workflow instance is aborted. To understand the details of the unhandled exception, the tracking profile must query the workflow instance record with `state name="UnhandledException"` as specified in the following example.  
  
```xml  
<workflowInstanceQueries>  
              <workflowInstanceQuery>  
                <states>  
                  <state name="UnhandledException" />  
                </states>  
              </workflowInstanceQuery>  
</workflowInstanceQueries>  
```  
  
 When a workflow instance encounters an unhandled exception, a <xref:System.Activities.Tracking.WorkflowInstanceUnhandledExceptionRecord> object is emitted if [!INCLUDE[wf2](../../../includes/wf2-md.md)] tracking has been enabled.  
  
 This tracking record contains the fault details in the form of the exception stack. It has details of the source of the fault (for example, the activity) that faulted and resulted in the unhandled exception.To subscribe to fault events from a [!INCLUDE[wf2](../../../includes/wf2-md.md)], enable tracking by adding a tracking participant. Configure this participant with a tracking profile that queries for `ActivityStateQuery (state="Faulted")`, <xref:System.Activities.Tracking.FaultPropagationRecord>, and `WorkflowInstanceQuery (state="UnhandledException")`.  
  
 If tracking is enabled using the ETW tracking participant, the fault events are emitted to an ETW session. The events can be viewed using the Event Viewer event viewer. This can be found under the node **Event Viewer->Applications and Services Logs->Microsoft->Windows->Application Server-Applications** in the analytic channel.  
  
## See Also  
 [Windows Server App Fabric Monitoring](http://go.microsoft.com/fwlink/?LinkId=201273)  
 [Monitoring Applications with App Fabric](http://go.microsoft.com/fwlink/?LinkId=201275)
