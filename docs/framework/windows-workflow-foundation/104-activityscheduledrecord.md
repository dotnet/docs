---
title: "104 - ActivityScheduledRecord"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ae202178-8fb1-4646-a3aa-18beeda8ff93
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 104 - ActivityScheduledRecord
## Properties  
  
|||  
|-|-|  
|Id|104|  
|Keywords|EndToEndMonitoring, Troubleshooting, HealthMonitoring, WFTracking|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted by the ETW tracking participant when an activity within a workflow instance emits ActivityScheduledRecord  
  
## Message  
 TrackRecord = ActivityScheduledRecord, InstanceID = %1,  RecordNumber = %2, EventTime = %3, Name = %4, ActivityId = %5, ActivityInstanceId = %6, ActivityTypeName = %7, ChildActivityName = %8, ChildActivityId = %9, ChildActivityInstanceId = %10, ChildActivityTypeName =%11, Annotations=%12, ProfileName = %13  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InstanceId|xs:GUID|The instance id for the workflow|  
|RecordNumber|xs:long|The sequence number of the emitted record|  
|EventTime|xs:dateTime|The time in UTC when the event was emitted|  
|Name|xs:string|The name of the activity that scheduled the child activity|  
|ActivityId|xs:string|The id of the activity that scheduled the child activity|  
|ActivityInstanceId|xs:string|The instance id of the activity that scheduled the child activity|  
|ActivityTypeName|xs:string|The type of the activity that requested the cancel operation|  
|ChildActivityName|xs:string|The name of the scheduled activity|  
|ChildActivityId|xs:string|The id of the scheduled activity|  
|ChildActivityInstanceId|xs:string|The instance id of the scheduled activity|  
|ChildActivityTypeName|xs:string|The type of the scheduled activity|  
|Annotations|xs:string|The annotations that were added to this event.  The values are stored in an xml element in the format \<items>\< item  name = "annotationName" type="System.String">annotationValue\</item>\</items>.  If no annotations are specified then the string contains \<items/>. The ETW event size is limited by the ETW buffer size or the max payload for an ETW event. If the size of the event exceeds the ETW limits, then the event is truncated by dropping the annotations and replacing the annotation value with \<items>...\</items>.|  
|ProfileName|xs:string|The name or the tracking profile that resulted in this event being emitted|  
|HostReference|xs:string|For web hosted services, this field uniquely identifies the service in the web hierarchy.  Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName' Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
