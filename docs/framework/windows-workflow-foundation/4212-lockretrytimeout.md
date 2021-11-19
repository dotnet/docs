---
description: "Learn more about: 4212 - LockRetryTimeout"
title: "4212 - LockRetryTimeout"
ms.date: "03/30/2017"
ms.assetid: d4ad415a-9871-49fc-85b8-8ee2ea149b1d
---
# 4212 - LockRetryTimeout

## Properties

| Property | Value |
| - | - |
|ID|4212|  
|Keywords|WFInstanceStore|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 SQL provider encountered a timeout trying to acquire the instance lock.  
  
## Message  

 Timeout trying to acquire the instance lock.  The operation did not complete within the allotted timeout of %1. The time allotted to this operation may have been a portion of a longer timeout.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Delay|xs:string|The delay between retries.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
