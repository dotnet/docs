---
title: "113 - WorkflowInstanceTerminatedRecord"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f53204ee-4ea2-45e1-8859-e86d07305efd
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 113 - WorkflowInstanceTerminatedRecord
## Properties  
  
|||  
|-|-|  
|Id|113|  
|Keywords|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|Level|Error|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted by the ETW tracking participant when a workflow instance emits WorkflowInstanceTerminatedRecord.  
  
## Message  
 TrackRecord = WorkflowInstanceTerminatedRecord, InstanceID = %1, RecordNumber = %2, EventTime = %3, ActivityDefinitionId = %4, Reason = %5, Annotations = %6, ProfileName = %7  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InstanceId|xs:GUID|The instance id for the workflow|  
|RecordNumber|xs:long|The sequence number of the emitted record|  
|EventTime|xs:dateTime|The time in UTC when the event was emitted|  
|ActivityDefinitionId|xs:string|The name of the root activity in the workflow|  
|Reason|xs:string|The reason the workflow was terminated|  
|Annotations|xs:string|The annotations that were added to this event.  The values are stored in an xml element in the format \<items>\< item  name = "annotationName" type="System.String">annotationValue\</item>\</items>.  If no annotations are specified then the string contains \<items/>. The ETW event size is limited by the ETW buffer size or the max payload for an ETW event. If the size of the event exceeds the ETW limits, then the event is truncated by dropping the annotations and replacing the annotation value with \<items>...\</items>.|  
|ProfileName|xs:string|The name or the tracking profile that resulted in this event being emitted|  
|HostReference|xs:string|For web hosted services, this field uniquely identifies the service in the web hierarchy.  Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName' Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
