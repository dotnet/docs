---
description: "Learn more about: 1010 - ActivityCompleted"
title: "1010 - ActivityCompleted"
ms.date: "03/30/2017"
ms.assetid: d256284e-3fd2-4c33-82f4-abb617575706
---
# 1010 - ActivityCompleted

## Properties

| Property | Value |
| - | - |
|ID|1010|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates an activity has completed execution.  
  
## Message  

 Activity '%1', DisplayName: '%2', InstanceId: '%3' has completed in the '%4' state.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|State|xs:string|The state of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
