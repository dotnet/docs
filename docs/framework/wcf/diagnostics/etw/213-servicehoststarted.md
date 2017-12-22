---
title: "213 - ServiceHostStarted"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a6f7facc-342f-46bb-9d52-a470178ba6bb
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 213 - ServiceHostStarted
## Properties  
  
|||  
|-|-|  
|ID|213|  
|Keywords|EndToEndMonitoring, HealthMonitoring, Troubleshooting, ServiceHost|  
|Level|LogAlways|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted when a Web-hosted service host is started. This typically happens when the service is activated by a message. It may also happen if the service is configured to be automatically started.  
  
## Message  
 ServiceHost started: '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Service Type Name|`xs:string`|The CLR FullName of the type of the service implementation.|  
|HostReference|`xs:string`|For Web hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
