---
title: "1026 - ScheduleTransactionContextWorkItem"
ms.date: "03/30/2017"
ms.assetid: 0d5f86ba-ec21-4129-a726-5432e425384c
---
# 1026 - ScheduleTransactionContextWorkItem
## Properties  
  
|||  
|-|-|  
|ID|1026|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a TransactionContextWorkItem has been scheduled.  
  
## Message  
 A TransactionContextWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
