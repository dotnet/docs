---
title: "222 - OperationFailed"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6b530ded-8f20-4d78-8bfe-1875276df6ba
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 222 - OperationFailed
## Properties  
  
|||  
|-|-|  
|ID|222|  
|Keywords|EndToEndMonitoring, HealthMonitoring, Troubleshooting, ServiceModel|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted when the Service Model's default `OperationInvoker` has encountered an exception while invoking its method. Note that exceptions that derive from `FaultException` cause this event to not be emitted.  
  
## Message  
 The '%1' method threw an unhandled exception when invoked by the OperationInvoker. The method call duration was '%2' ms.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Method Name|`xs:string`|The CLR name of the method that was invoked by the `OperationInvoker`.|  
|Duration|`xs:long`|The time, in milliseconds, that it took the `OperationInvoker` to invoke the method.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
