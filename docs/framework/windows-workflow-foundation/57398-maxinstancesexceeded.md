---
title: "57398 - MaxInstancesExceeded"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f943d209-dfeb-43e5-b572-c9a06217936e
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 57398 - MaxInstancesExceeded
## Properties  
  
|||  
|-|-|  
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
