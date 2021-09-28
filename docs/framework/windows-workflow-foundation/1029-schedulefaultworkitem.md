---
description: "Learn more about: 1029 - ScheduleFaultWorkItem"
title: "1029 - ScheduleFaultWorkItem"
ms.date: "03/30/2017"
ms.assetid: 3a56b29e-f740-459d-8576-d81e58bf5a03
---
# 1029 - ScheduleFaultWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1029|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a FaultWorkItem has been scheduled.  
  
## Message  

 A FaultWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  The exception was propagated from Activity '%4', DisplayName: '%5', InstanceId: '%6'.  
  
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
