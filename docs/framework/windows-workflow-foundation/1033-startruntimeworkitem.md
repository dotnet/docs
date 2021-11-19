---
description: "Learn more about: 1033 - StartRuntimeWorkItem"
title: "1033 - StartRuntimeWorkItem"
ms.date: "03/30/2017"
ms.assetid: 172b5346-9f3b-46ae-bc06-39872022376a
---
# 1033 - StartRuntimeWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1033|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a RuntimeWorkItem is starting execution.  
  
## Message  

 Starting execution of a runtime work item for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
