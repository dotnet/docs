---
title: "Activity"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 70471705-f55f-4da1-919f-4b580f172665
caps.latest.revision: 10
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Activity
This topic describes activity traces in the [!INCLUDE[indigo1](../../../../../includes/indigo1-md.md)] tracing model. Activities are processing units that help the user narrow down the scope of a failure. Errors that occur in the same activity are directly related. For example, an operation fails because message decryption has failed. The traces for both the operation and message decryption failure appear in the same activity, showing direct correlation between the decryption error and the request error.  
  
## Configuring Activity Tracing  
 [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] provides pre-defined activities for processing applications (see [Activity List](../../../../../docs/framework/wcf/diagnostics/tracing/activity-list.md)). You can also define activities programmatically to group user traces. For more information, see [Emitting User-Code Traces](../../../../../docs/framework/wcf/diagnostics/tracing/emitting-user-code-traces.md).  
  
 To emit activity traces at run time, use the `ActivityTracing` setting for the `System.ServiceModel` trace source, or other [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] or custom trace sources, as demonstrated by the following configuration code.  
  
```xml  
<source name="System.ServiceModel" switchValue="Verbose,ActivityTracing">  
```  
  
 To understand more about the configuration element and attributes being used, see the [Configuring Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md) topic.  
  
## Viewing Activities  
 You can view the activities and their utility in the [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md). When ActivityTracing is enabled, this tool takes the traces and sorts them based on activity. You can also see trace transfers. A trace transfer indicates how different activities are related to each other. You can see that a particular activity caused another to start. For example, a message request started a security handshake to get a Secure Conversation Token.  
  
### Correlating Activities in Service Trace Viewer  
 The Service Trace Viewer tool provides two views of activities:  
  
-   **List** view, where the activity ID is used to directly correlate traces across processes. Traces from different processes, for example, client and service, but with the same activity ID are grouped in the same activity. Therefore, an error occurring on the service which then causes an error on the client will both show up in the same activity view in the tool.  
  
-   **Graph** view, where activities are grouped by processes. In this view, a client and service with the same activity ID have their traces in different activities. To correlate activities with the same activity ID in different processes, the tool shows message flows across the related activities.  
  
 For more information, and to see a graphical view of the Service Trace Viewer tool, see [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md) and [Using Service Trace Viewer for Viewing Correlated Traces and Troubleshooting](../../../../../docs/framework/wcf/diagnostics/tracing/using-service-trace-viewer-for-viewing-correlated-traces-and-troubleshooting.md).  
  
## Defining the Scope of an Activity  
 An activity is defined at design time and denotes a logical unit of work. Emitted traces with the same activity identifier are directly related, they are part of the same activity. Because an activity can cross endpoint boundaries (a request), two scopes for an activity are defined.  
  
-   `Global` scope, per application. In this scope, the activity is identified by its 128-bit globally unique activity identifier, the gAId. The gAid is what is propagated across endpoints.  
  
-   `Local` scope, per endpoint. In this scope, the activity is identified by its gAId, along with the trace source name emitting the activity traces and the process Id. This triplet constitutes the local activity id, lAId. The lAId is used to define the (local) boundaries of an activity.  
  
## Trace Schema  
 Traces can be emitted using any schema, and across Microsoft platforms. "e2e" (for "End to End") is a commonly used schema. This schema includes a 128 bit identifier (gAId), the trace source name, and process ID. In managed code, <xref:System.Diagnostics.XmlWriterTraceListener> emits traces in the E2E schema.  
  
 Developers can set the AID that is emitted with a trace by setting the <xref:System.Diagnostics.CorrelationManager.ActivityId%2A> property with a Guid on Thread Local Storage (TLS). The following example demonstrates this.  
  
```  
// set the current Activity ID to a new GUID.  
CorrelationManager.ActivityId = Guid.NewGuid();  
```  
  
 Setting the gAId in TLS will be evident when traces are emitted using a trace source, as shown by the following example.  
  
```  
TraceSource traceSource = new TraceSource("myTraceSource");  
traceSource.TraceEvent(TraceEventType.Warning, eventId, "Information");  
```  
  
 The trace emitted will contain the gAId currently in TLS, the trace source name passed as a parameter to the trace source’s constructor, and the current process’s ID.  
  
## Activity Lifetime  
 In strictest terms, evidence of an activity starts the first time the activity ID is used in an emitted trace, and ends the last time it is used in an emitted trace. A predefined set of trace types are provided by <xref:System.Diagnostics>, including Start and Stop, to explicitly mark the activity lifetime boundaries.  
  
-   Start: Indicates the beginning of an activity. A "Start" trace provides a record of beginning a new processing milestone. It contains a new activity ID for a given trace source in a given process, except when the activity ID is propagated across endpoints, in which case we see one "Start" per endpoint. Examples of starting a new activity include creating a new thread for processing, or entering a new public method.  
  
-   Stop: Indicates the end of an activity. A "Stop" trace provides a record of ending an existing processing milestone. It contains an existing activity ID for a given trace source in a given process, except when the activity ID is propagated across endpoints, in which case we see one "Stop" per endpoint.  Examples of stopping an activity include terminating a processing thread, or exiting a method whose beginning was denoted with a "Start" trace.  
  
-   Suspend: Indicates suspension of processing of an activity. A "Suspend" trace contains an existing activity ID whose processing is expected to resume at a later time. No traces are emitted with this ID between the Suspend and Resume events from the current trace source. Examples include pausing an activity when calling into an external library function, or when waiting on a resource such as an I/O completion port.  
  
-   Resume: Indicates the resumption of processing of an activity. A "Resume" trace contains an existing activity id whose last emitted trace from the current trace source was a "Suspend" trace. Examples include returning from a call to an external library function, or when signaled to resume processing by a resource such as an I/O completion port.  
  
-   Transfer: Because some activities are caused by others, or relate to others, activities can be related to other activities through "Transfer" traces. A transfer records the directed relationship of one activity to another  
  
 Start and Stop traces are not critical for correlation. However, they can help in increasing performance, profiling, and activity scope validation.  
  
 Using these types, the tools can optimize navigating the trace logs to find the immediately related events of the same activity, or events in related activities if the tool follows transfer traces. For example, the tools will stop parsing the logs for a given activity when they see a Start/Stop trace.  
  
 These trace types can also be used for profiling. Resources consumed between the start and stop markers represent the activity’s inclusive time including contained logical activities. Subtracting the time intervals between the Suspend and Resume traces provides the actual activity time.  
  
 The Stop trace is also particularly useful for validating the scope of the implemented activities. If some processing traces appear after the Stop trace instead of inside a given activity, this can suggests code defect.  
  
## Guidelines for Using Activity Tracing  
 The following is a guideline of using ActivityTracing traces (Start, Stop, Suspend, Resume, and Transfer).  
  
-   Tracing is a directed cyclic graph, not a tree. You can return control to an activity which spawned an activity.  
  
-   An activity denotes a processing boundary which can be meaningful to the administrator of the system or for supportability.  
  
-   Each [!INCLUDE[indigo2](../../../../../includes/indigo2-md.md)] method, both on the client and server, is bounded by beginning a new activity, then (after work is done) ending the new activity and returning to the ambient activity.  
  
-   Long running (ongoing) activities such as listening for connections or waiting for messages are represented by corresponding start/stop markers.  
  
-   Activities triggered by the receipt or processing of a message are represented by trace boundaries.  
  
-   Activities represent activities, not necessarily objects. An activity should be interpreted as "this was happening when . . . (meaningful trace emission occurred)."  
  
## See Also  
 [Configuring Tracing](../../../../../docs/framework/wcf/diagnostics/tracing/configuring-tracing.md)  
 [Using Service Trace Viewer for Viewing Correlated Traces and Troubleshooting](../../../../../docs/framework/wcf/diagnostics/tracing/using-service-trace-viewer-for-viewing-correlated-traces-and-troubleshooting.md)  
 [End-To-End Tracing Scenarios](../../../../../docs/framework/wcf/diagnostics/tracing/end-to-end-tracing-scenarios.md)  
 [Service Trace Viewer Tool (SvcTraceViewer.exe)](../../../../../docs/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe.md)  
 [Emitting User-Code Traces](../../../../../docs/framework/wcf/diagnostics/tracing/emitting-user-code-traces.md)
