---
description: "Learn more about: 219 - ServiceException"
title: "219 - ServiceException"
ms.date: "03/30/2017"
ms.assetid: 81e2efac-39aa-4ed2-85a9-97eb8793b844
---
# 219 - ServiceException

## Properties

| Property | Value |
| - | - |
|ID|219|  
|Keywords|EndToEndMonitoring, HealthMonitoring, Troubleshooting, ServiceModel|  
|Level|Error|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted when a WCF service encounters an unhandled exception. This includes unhandled exceptions during activation, during message processing, and in user code.  
  
## Message  

 There was an unhandled exception of type '%2' during message processing. Full Exception ToString: %1.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ExceptionToString|`xs:string`|The result of calling `ToString`() on the CLR exception.|  
|ExceptionTypeName|`xs:string`|The CLR FullName of the exception's type.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
