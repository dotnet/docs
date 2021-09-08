---
description: "Learn more about: 1030 - StartFaultWorkItem"
title: "1030 - StartFaultWorkItem"
ms.date: "03/30/2017"
ms.assetid: e1601fb9-0bc6-4dbe-816f-f24914063d34
---
# 1030 - StartFaultWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1030|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a FaultWorkItem is starting execution.  
  
## Message  

 Starting execution of a FaultWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  The exception was propagated from Activity '%4', DisplayName: '%5', InstanceId: '%6'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|FaultActivity|xs:string|The type name of the fault activity.|  
|FaultActivityDisplayName|xs:string|The display name of the fault activity.|  
|FaultActivityInstanceId|xs:string|The instance id of the fault activity.|  
|ExceptionActivity|xs:string|The type name of the activity that threw the exception.|  
|ExceptionActivityDisplayName|xs:string|The display name of the activity that threw the exception.|  
|ExceptionActivityInstanceId|xs:string|The instance id of the activity that threw the exception.|  
|Exception|xs:string|The exception details for the exception|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
