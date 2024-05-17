---
description: "Learn more about: 1037 - RuntimeTransactionComplete"
title: "1037 - RuntimeTransactionComplete"
ms.date: "03/30/2017"
ms.assetid: 2c8c31e0-42a9-4f46-865b-2da9ab16a0ba
---
# 1037 - RuntimeTransactionComplete

## Properties

| Property | Value |
| - | - |
|ID|1037|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates the runtime transaction has completed.  
  
## Message  

 The runtime transaction has completed with the state '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|State|xs:string|The state of the transaction.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
