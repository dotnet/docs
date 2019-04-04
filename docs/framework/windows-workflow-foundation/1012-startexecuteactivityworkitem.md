---
title: "1012 - StartExecuteActivityWorkItem"
ms.date: "03/30/2017"
ms.assetid: 29e9b1c6-c5d7-4b58-b59d-a06a923d3c80
---
# 1012 - StartExecuteActivityWorkItem
## Properties  
  
|||  
|-|-|  
|ID|1012|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates an ExecuteActivityWorkItem is starting execution.  
  
## Message  
 Starting execution of an ExecuteActivityWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
