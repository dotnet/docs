---
description: "Learn more about: 1027 - StartTransactionContextWorkItem"
title: "1027 - StartTransactionContextWorkItem"
ms.date: "03/30/2017"
ms.assetid: 116ae5ec-b9d5-4231-824e-270d00eea7b8
---
# 1027 - StartTransactionContextWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1027|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a TransactionContextWorkItem is starting execution.  
  
## Message  

 Starting execution of a TransactionContextWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
