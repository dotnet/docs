---
description: "Learn more about: 1011 - ScheduleExecuteActivityWorkItem"
title: "1011 - ScheduleExecuteActivityWorkItem"
ms.date: "03/30/2017"
ms.assetid: e503ae46-ad6b-4fcb-8c0e-146d59a8eff1
---
# 1011 - ScheduleExecuteActivityWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1011|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates an ExecuteActivityWorkItem has been scheduled.  
  
## Message  

 An ExecuteActivityWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
