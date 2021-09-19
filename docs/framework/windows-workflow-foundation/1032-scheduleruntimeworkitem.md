---
description: "Learn more about: 1032 - ScheduleRuntimeWorkItem"
title: "1032 - ScheduleRuntimeWorkItem"
ms.date: "03/30/2017"
ms.assetid: 54688101-becf-42f3-80ca-f53a7b527620
---
# 1032 - ScheduleRuntimeWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1032|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a RuntimeWorkItem has been scheduled.  
  
## Message  

 A runtime work item has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
