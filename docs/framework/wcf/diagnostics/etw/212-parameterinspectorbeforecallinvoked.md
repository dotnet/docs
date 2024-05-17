---
description: "Learn more about: 212 - ParameterInspectorBeforeCallInvoked"
title: "212 - ParameterInspectorBeforeCallInvoked"
ms.date: "03/30/2017"
ms.assetid: 063fc8d2-ceac-4c18-8368-de84f2c78035
---
# 212 - ParameterInspectorBeforeCallInvoked

## Properties

| Property | Value |
| - | - |
|ID|212|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted after the Service Model has invoked the `BeforeCall` method on a `ParameterInspector`.  
  
## Message  

 The Dispatcher invoked 'BeforeCall' on a ParameterInspector of type '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TypeName|`xs:string`|The CLR FullName of the invoked inspector's type.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
