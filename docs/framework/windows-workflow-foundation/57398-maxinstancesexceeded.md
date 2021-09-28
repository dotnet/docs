---
description: "Learn more about: 57398 - MaxInstancesExceeded"
title: "57398 - MaxInstancesExceeded"
ms.date: "03/30/2017"
ms.assetid: f943d209-dfeb-43e5-b572-c9a06217936e
---
# 57398 - MaxInstancesExceeded

## Properties

| Property | Value |
| - | - |
|ID|57398|  
|Keywords|WFServices|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 Indicates the system hit the limit set for throttle 'MaxConcurrentInstances'.  
  
## Message  

 The system hit the limit set for throttle 'MaxConcurrentInstances'. Limit for this throttle was set to %1. Throttle value can be changed by modifying attribute 'maxConcurrentInstances' in serviceThrottle element or by modifying 'MaxConcurrentInstances' property on behavior ServiceThrottlingBehavior.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Name|xs:string|The name of the item.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
