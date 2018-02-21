---
title: "214 - OperationCompleted"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a6287eef-023f-4816-813c-1802c82366df
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 214 - OperationCompleted
## Properties  
  
|||  
|-|-|  
|ID|214|  
|Keywords|HealthMonitoring, EndToEndMonitoring, Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted when the Service Model's default `OperationInvoker` has completed a call to a method without that method throwing an exception.  
  
## Message  
 An OperationInvoker completed the call to the '%1' method. The method call duration was '%2' ms.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Method Name|`xs:string`|The CLR name of the method that was invoked by the `OperationInvoker`.|  
|Duration|`xs:long`|The time, in milliseconds, that it took the `OperationInvoker` to invoke the method.|  
|HostReference|`xs:string`|For web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
