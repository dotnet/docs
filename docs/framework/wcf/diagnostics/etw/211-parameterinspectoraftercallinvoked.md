---
description: "Learn more about: 211 - ParameterInspectorAfterCallInvoked"
title: "211 - ParameterInspectorAfterCallInvoked"
ms.date: "03/30/2017"
ms.assetid: c0e21297-10b8-4456-a0e1-e019145cd5ac
---
# 211 - ParameterInspectorAfterCallInvoked

## Properties

| Property | Value |
| - | - |
|ID|211|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted after the Service Model has invoked the `AfterCall` method on a `ParameterInspector`.  
  
## Message  

 The Dispatcher invoked 'AfterCall' on a ParameterInspector of type '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Type Name|`xs:string`|The CLR FullName of the type of the invoked `ParameterInspector`.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
