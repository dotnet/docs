---
title: "1013 - CompleteExecuteActivityWorkItem"
ms.date: "03/30/2017"
ms.assetid: 31fc57b3-ef2f-48f0-a5de-b4e2c5c9ded7
---
# 1013 - CompleteExecuteActivityWorkItem
## Properties  
  
|||  
|-|-|  
|ID|1013|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates an ExecuteActivityWorkItem has completed  
  
## Message  
 An ExecuteActivityWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
