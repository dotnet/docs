---
title: "223 - OperationFaulted"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2f7d89d7-3a6a-40fe-9610-5424eb6bbf61
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 223 - OperationFaulted
## Properties  
  
|||  
|-|-|  
|ID|223|  
|Keywords|EndToEndMonitoring, HealthMonitoring, Troubleshooting, ServiceModel|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted when the Service Model's default `OperationInvoker` has encountered an exception deriving from `FaultException` while invoking its method.  
  
## Message  
 The '%1' method threw a FaultException when invoked by the OperationInvoker. The method call duration was '%2' ms.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|MethodName|`xs:string`|The CLR name of the method that was invoked by the `OperationInvoker`.|  
|Duration|`xs:long`|The time, in milliseconds, that it took the `OperationInvoker` to invoke the method.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
