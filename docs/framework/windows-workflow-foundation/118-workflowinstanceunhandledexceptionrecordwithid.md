---
title: "118 - WorkflowInstanceUnhandledExceptionRecordWithId"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2ce4b193-e141-4cc4-86a3-2e8c984c110d
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 118 - WorkflowInstanceUnhandledExceptionRecordWithId
## Properties  
  
|||  
|-|-|  
|ID|118|  
|Keywords|HealthMonitoring, WFTracking|  
|Level|Error|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted by the ETW tracking participant when a workflow instance emits WorkflowInstanceUnhandledExceptionRecord.  
  
## Message  
 TrackRecord = WorkflowInstanceUnhandledExceptionRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, SourceName = %5, SourceId = %6, SourceInstanceId = %7, SourceTypeName=%8, Exception=%9,  Annotations= %10, ProfileName = %11, WorkflowDefinitionIdentity = %12  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InstanceId|xs:GUID|The instance id for the workflow|  
|RecordNumber|xs:long|The sequence number of the emitted record|  
|EventTime|xs:dateTime|The time in UTC when the event was emitted|  
|ActivityDefinitionId|xs:string|The name of the root activity in the workflow|  
|SourceName|xs:string|The source activity name that faulted resulting in the unhandledException|  
|SourceId|xs:string|The activity id of the fault source activity|  
|SourceInstanceId|xs:string|The activity instance id of the fault source activity|  
|SourceTypeName|xs:string|The source activity type name that faulted resulting in the unhandledException|  
|Exception|xs:string|The exception details for the unhandled exception|  
|State|xs:string|The current state of the Workflow.|  
|Annotations|xs:string|The annotations that were added to this event. The values are stored in an xml element in the format \<items>\< item name = "annotationName" type="System.String">annotationValue\</item>\</items>. If no annotations are specified then the string contains \<items/>. The ETW event size is limited by the ETW buffer size or the max payload for an ETW event. If the size of the event exceeds the ETW limits, then the event is truncated by dropping the annotations and replacing the annotation value with \<items>...\</items>.|  
|ProfileName|xs:string|The name or the tracking profile that resulted in this event being emitted|  
|WorkflowDefinitionIdentity|xs:string|The workflow definition id|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
