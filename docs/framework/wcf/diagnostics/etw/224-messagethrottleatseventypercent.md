---
title: "224 - MessageThrottleAtSeventyPercent"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 82bbbfd7-10d2-41fd-805d-2443b0c1b96b
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 224 - MessageThrottleAtSeventyPercent
## Properties  
  
|||  
|-|-|  
|ID|224|  
|Keywords|EndToEndMonitoring, HealthMonitoring, Troubleshooting, ServiceModel|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 When one of the main service throttles has been exceeded, the `MessageThrottleExceeded` event is emitted. When the spike of activity slows and the current value of the throttle is at 70 percent of the current limit then this event is emitted. Note that this event is only emitted once as the activity is slowing. If the current value hovers at the 70 percent mark, (for example, 70,69,70,71,70,69), only the first occurrence of 70 percent results in an event. After this event is emitted, future occurrences of exceeding the throttle's limit result in a `MessageThrottleExceeded` event.  
  
## Message  
 The '%1' throttle limit of '%2' is at 70%%.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Throttle Name|`xs:string`|The name of the throttle that has been exceeded. Either `MaxConcurrentCalls`, `MaxConcurrentInstances`, or `MaxConcurrentSessions`,|  
|Limit|`xs:long`|The currently configured limit of the throttle.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
