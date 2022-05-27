---
description: "Learn more about: 4211 - QueuingSqlRetry"
title: "4211 - QueuingSqlRetry"
ms.date: "03/30/2017"
ms.assetid: df569f88-c86b-4503-840d-1399b67f4df7
---
# 4211 - QueuingSqlRetry

## Properties

| Property | Value |
| - | - |
|ID|4211|  
|Keywords|WFInstanceStore|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates queuing SQL retry.  
  
## Message  

 Queuing SQL retry with delay %1 milliseconds.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Delay|xs:string|The delay between retries.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
