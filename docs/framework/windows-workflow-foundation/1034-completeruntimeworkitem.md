---
description: "Learn more about: 1034 - CompleteRuntimeWorkItem"
title: "1034 - CompleteRuntimeWorkItem"
ms.date: "03/30/2017"
ms.assetid: 45620011-8b04-4f87-ab5a-65b24145e17d
---
# 1034 - CompleteRuntimeWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1034|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a RuntimeWorkItem has completed.  
  
## Message  

 A runtime work item has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
