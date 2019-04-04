---
title: "1036 - RuntimeTransactionCompletionRequested"
ms.date: "03/30/2017"
ms.assetid: d36b9f44-7c0f-4083-9d3a-9034dd2b98de
---
# 1036 - RuntimeTransactionCompletionRequested
## Properties  
  
|||  
|-|-|  
|ID|1036|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates an activity has scheduled the completion of the runtime transaction.  
  
## Message  
 Activity '%1', DisplayName: '%2', InstanceId: '%3' has scheduled completion of the runtime transaction.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
