---
description: "Learn more about: 203 - ClientParameterInspectorAfterCallInvoked"
title: "203 - ClientParameterInspectorAfterCallInvoked"
ms.date: "03/30/2017"
ms.assetid: b9592212-07e2-43e0-8b00-affd195cf55a
---
# 203 - ClientParameterInspectorAfterCallInvoked

## Properties

| Property | Value |
| - | - |
|ID|203|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted after the Service Model has invoked the `AfterCall` method on a client parameter inspector.  
  
## Message  

 The Dispatcher invoked 'AfterCall' on a ClientParameterInspector of type '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TypeName|`xs:string`|The CLR FullName of the invoked inspector's type.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
