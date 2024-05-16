---
description: "Learn more about: 1014 - ScheduleCompletionWorkItem"
title: "1014 - ScheduleCompletionWorkItem"
ms.date: "03/30/2017"
ms.assetid: 84203735-478d-42d8-a320-c175dbddcb38
---
# 1014 - ScheduleCompletionWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1014|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a CompletionWorkItem has been scheduled.  
  
## Message  

 A CompletionWorkItem has been scheduled for parent Activity '%1', DisplayName: '%2', InstanceId: '%3'.  Completed Activity '%4', DisplayName: '%5', InstanceId: '%6'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ParentActivity|xs:string|The type name of the parent activity.|  
|ParentDisplayName|xs:string|The display name of the parent activity.|  
|ParentInstanceId|xs:string|The instance id of the parent activity.|  
|CompletedActivity|xs:string|The type name of the completed activity.|  
|CompletedActivityDisplayName|xs:string|The display name of the completed activity.|  
|CompletedActivityInstanceId|xs:string|The instance id of the completed activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
