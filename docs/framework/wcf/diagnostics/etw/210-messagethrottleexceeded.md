---
title: "210 - MessageThrottleExceeded"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 24ca08ea-c11c-4753-946e-98aa820f8711
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 210 - MessageThrottleExceeded
## Properties  
  
|||  
|-|-|  
|ID|210|  
|Keywords|EndToEndMonitoring, HealthMonitoring, Troubleshooting, ServiceModel|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted when one of the three main service throttles have been exceeded. Note that this event is only emitted when the throttle limit is initially exceeded. For example, if the throttle limit for concurrent calls is 10, the 11th concurrent call results in a `MessageThrottleExceeded` event. The 12th call does not result in another event. Additionally, to avoid a noisy event stream, activity that hovers around the limit does not result in another event. In this example, if a couple of calls complete then there are 9 concurrent calls. If subsequently two more calls come in, the current value is again 11. This does not result in another event. When the current value falls to 70 percent of the throttle limit a different event is emitted that indicates that the activity has slowed. Future activity that exceeds the limit results in another `MessageThrottleExceeded` event being emitted. In this example, if the amount of concurrent calls falls to 7 and then again reaches 11 and another `MessageThrottleExceeded` event is emitted.  
  
## Message  
 The '%1' throttle limit of '%2' was hit.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Throttle Name|`xs:string`|The name of the throttle that has been exceeded. Either `MaxConcurrentCalls`, `MaxConcurrentInstances`, or `MaxConcurrentSessions`,|  
|Limit|`xs:long`|The currently configured limit of the throttle.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
