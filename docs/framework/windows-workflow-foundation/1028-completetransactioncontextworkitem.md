---
description: "Learn more about: 1028 - CompleteTransactionContextWorkItem"
title: "1028 - CompleteTransactionContextWorkItem"
ms.date: "03/30/2017"
ms.assetid: 95423f9d-d29a-460e-bcd8-096e80af5bd0
---
# 1028 - CompleteTransactionContextWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1028|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a TransactionContextWorkItem has completed.  
  
## Message  

 A TransactionContextWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
