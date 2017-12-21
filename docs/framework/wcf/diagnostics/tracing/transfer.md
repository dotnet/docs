---
title: "Transfer"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: dfcfa36c-d3bb-44b4-aa15-1c922c6f73e6
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Transfer
This topic describes transfer in the [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] activity tracing model.  
  
## Transfer Definition  
 Transfers between activities represent causal relationships between events in the related activities within endpoints. Two activities are related with transfers when control flows between these activities, for example, a method call crossing activity boundaries. In [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)], when bytes are incoming on the service, the Listen At activity is transferred to the Receive Bytes activity where the message object is created. For a list of end-to-end tracing scenarios, and their respective activity and tracing design, see [End-To-End Tracing Scenarios](../../../../../docs/framework/wcf/diagnostics/tracing/end-to-end-tracing-scenarios.md).  
  
 To emit transfer traces, use the `ActivityTracing` setting on the trace source as demonstrated by the following configuration code.  
  
```xml  
<source name="System.ServiceModel" switchValue="Verbose,ActivityTracing">  
```  
  
## Using Transfer to Correlate Activities Within Endpoints  
 Activities and transfers permit the user to probabilistically locate the root cause of an error. For example, if we transfer back and forth between activities M and N respectively in components M and N, and a crash happens in N right after the transfer back to M, we can draw the conclusion that it is likely due to N’s passing data back to M.  
  
 A transfer trace is emitted from activity M to activity N when there is a flow of control between M and N. For example, N performs some work for M because of a method call crossing the activities’ boundaries. N may already exist or has been created. N is spawned by M when N is a new activity that performs some work for M.  
  
 A transfer from M to N may not be followed by a transfer back from N to M. This is because M can spawn some work in N and do not track when N completes that work. In fact, M can terminate before N completes its task. This happens in the "Open ServiceHost" activity (M) that spawns Listener activities (N) and then terminates. A transfer back from N to M means that N completed the work related to M.  
  
 N can continue performing other processing unrelated to M, for example, an existing authenticator activity (N) that keeps receiving login requests (M) from different login activities.  
  
 A nesting relationship does not necessarily exist between activities M and N. This can happen due to two reasons. First, when activity M does not monitor the actual processing performed in N although M initiated N. Second, when N already exists.  
  
## Example of Transfers  
 The following lists two transfer examples.  
  
-   When you create a service host, the constructor gains control from the calling code, or the calling code transfers to the constructor. When the constructor has finished executing, it returns control to the calling code, or the constructor transfers back to the calling code. This is the case of a nested relationship.  
  
-   When a listener starts processing transport data, it creates a new thread and hands to the Receive Bytes activity the appropriate context for processing, passing control and data. When that thread has finished processing the request, the Receive Bytes activity passes nothing back to the listener. In this case, we have a transfer in but no transfer out of the new thread activity. The two activities are related but not nested.  
  
## Activity Transfer Sequence  
 A well-formed activity transfer sequence includes the following steps.  
  
1.  Begin a new activity, which consists of selecting a new gAId.  
  
2.  Emit a transfer trace to that new gAId from the current activity ID  
  
3.  Set the new ID in TLS  
  
4.  Emit a start trace to indicate the beginning of the new activity by.  
  
5.  Return to the original activity consists of the following:  
  
6.  Emit a transfer trace to the original gAId  
  
7.  Emit a Stop trace to indicate the end of the new activity  
  
8.  Set TLS to the old gAId.  
  
 The following code example demonstrates how to do this. This sample assumes a blocking call is made when transferring to the new activity, and includes suspend/resume traces.  
  
```  
// 0. Create a trace source  
TraceSource ts = new TraceSource("myTS");  
// 1. remember existing ("ambient") activity for clean up  
Guid oldGuid = Trace.CorrelationManager.ActivityId;  
// this will be our new activity  
Guid newGuid = Guid.NewGuid();   
// 2. call transfer, indicating that we are switching to the new AID  
ts.TraceTransfer(667, "Transferring.", newGuid);  
// 3. Suspend the current activity.  
ts.TraceEvent(TraceEventType.Suspend, 667, "Suspend: Activity " + i-1);  
// 4. set the new AID in TLS  
Trace.CorrelationManager.ActivityId = newGuid;  
// 5. Emit the start trace  
ts.TraceEvent(TraceEventType.Start, 667, "Boundary: Activity " + i);  
// trace something  
ts.TraceEvent(TraceEventType.Information, 667, "Hello from activity " + i);  
// Perform Work  
// some work.  
// Return  
ts.TraceEvent(TraceEventType.Information, 667, "Work complete on activity " + i);   
// 6. Emit the transfer returning to the original activity  
ts.TraceTransfer(667, "Transferring Back.", oldGuid);  
// 7. Emit the End trace  
ts.TraceEvent(TraceEventType.Stop, 667, "Boundary: Activity " + i);  
// 8. Change the tls variable to the original AID  
Trace.CorrelationManager.ActivityId = oldGuid;    
// 9. Resume the old activity  
ts.TraceEvent(TraceEventType.Resume, 667, "Resume: Activity " + i-1);  
```  
  
## See Also  
 [Configuring Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md)  
 [Using Service Trace Viewer for Viewing Correlated Traces and Troubleshooting](../../../../../docs/framework/wcf/diagnostics/tracing/using-service-trace-viewer-for-viewing-correlated-traces-and-troubleshooting.md)  
 [End-To-End Tracing Scenarios](../../../../../docs/framework/wcf/diagnostics/tracing/end-to-end-tracing-scenarios.md)  
 [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md)
