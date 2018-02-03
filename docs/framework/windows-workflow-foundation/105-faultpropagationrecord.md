---
title: "105 - FaultPropagationRecord"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 168473b1-b1e5-4e9f-8a2a-35bbdb2ef531
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 105 - FaultPropagationRecord
## Properties  
  
|||  
|-|-|  
|Id|105|  
|Keywords|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted by the ETW tracking participant when a activity with the workflow instance emits FaultPropagationRecord.  
  
## Message  
 TrackRecord = FaultPropagationRecord, InstanceID=%1, RecordNumber=%2, EventTime=%3, FaultSourceActivityName=%4, FaultSourceActivityId=%5, FaultSourceActivityInstanceId=%6, FaultSourceActivityTypeName=%7, FaultHandlerActivityName=%8,  FaultHandlerActivityId = %9, FaultHandlerActivityInstanceId =%10, FaultHandlerActivityTypeName=%11, Fault=%12, IsFaultSource=%13, Annotations=%14, ProfileName = %15  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InstanceId|xs:GUID|The instance id for the workflow|  
|RecordNumber|xs:long|The sequence number of the emitted record|  
|EventTime|xs:dateTime|The time in UTC when the event was emitted|  
|FaultSourceActivityName|xs:string|The name of activity that emitted the fault|  
|FaultSourceActivityId|xs:string|The id of the activity that emitted the fault|  
|FaultSourceActivityInstanceId|xs:string|The instance id of the activity that emitted the fault|  
|FaultSourceActivityTypeName|xs:string|The type of the activity that emitted the fault|  
|FaultHandlerActivityName|xs:string|The display name of the fault handler activity|  
|FaultHandlerActivityId|xs:string|The id of the fault handler activity|  
|FaultHandlerActivityInstanceId|xs:string|The instance id of the fault handler activity|  
|FaultHandlerActivityTypeName|xs:string|The type of the fault handler activity|  
|Fault|xs:string|The fault details|  
|IsFaultSource|xs:unsignedByte|Indicates if the event was emitted from the fault source|  
|Annotations|xs:string|The annotations that were added to this event.  The values are stored in an xml element in the format \<items>\< item  name = "annotationName" type="System.String">annotationValue\</item>\</items>.  If no annotations are specified then the string contains \<items/>. The ETW event size is limited by the ETW buffer size or the max payload for an ETW event. If the size of the event exceeds the ETW limits, then the event is truncated by dropping the annotations and replacing the annotation value with \<items>...\</items>.|  
|ProfileName|xs:string|The name or the tracking profile that resulted in this event being emitted|  
|HostReference|xs:string|For web hosted services, this field uniquely identifies the service in the web hierarchy.  Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName' Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
