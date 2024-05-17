---
description: "Learn more about: 1019 - CompleteCancelActivityWorkItem"
title: "1019 - CompleteCancelActivityWorkItem"
ms.date: "03/30/2017"
ms.assetid: 75a4a1ab-e5a3-4f4e-88e4-d19806e671d7
---
# 1019 - CompleteCancelActivityWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1019|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a CancelActivityWorkItem has completed.  
  
## Message  

 A CancelActivityWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
