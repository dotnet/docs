---
title: "1018 - StartCancelActivityWorkItem"
ms.date: "03/30/2017"
ms.assetid: 68b4fa1d-eee6-4a2a-8c16-7e9d89f08ab9
---
# 1018 - StartCancelActivityWorkItem
## Properties  
  
|||  
|-|-|  
|ID|1018|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a CancelActivityWorkItem is starting execution.  
  
## Message  
 Starting execution of a CancelActivityWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
