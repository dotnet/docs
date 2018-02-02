---
title: "225 - TraceCorrelationKeys"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d9083aaf-3816-4c1c-bae0-2d7f49628345
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 225 - TraceCorrelationKeys
## Properties  
  
|||  
|-|-|  
|ID|225|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted when content-based correlation is used for a workflow service. It contains the correlation keys that are applied to correlate a message to an instance.  
  
## Message  
 Calculated correlation key '%1' using values '%2' in parent scope '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Instance Key|`xs:GUID`|The key that was generated from the correlation values.|  
|Values|`xs:string`|The values that were used to compute the correlation instance key.|  
|Parent Scope|`xs:string`||  
|HostReference|`xs:string`|For Web hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
