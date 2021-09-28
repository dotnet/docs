---
description: "Learn more about: 1017 - ScheduleCancelActivityWorkItem"
title: "1017 - ScheduleCancelActivityWorkItem"
ms.date: "03/30/2017"
ms.assetid: 864546ab-d65c-4989-8fcb-537ba03a3cdd
---
# 1017 - ScheduleCancelActivityWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1017|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a CancelActivityWorkItem has been scheduled.  
  
## Message  

 A CancelActivityWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
