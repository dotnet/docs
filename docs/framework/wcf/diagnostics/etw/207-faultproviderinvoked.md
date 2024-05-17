---
description: "Learn more about: 207 - FaultProviderInvoked"
title: "207 - FaultProviderInvoked"
ms.date: "03/30/2017"
ms.assetid: b730d903-01c2-4deb-85a4-da12f8a21fe4
---
# 207 - FaultProviderInvoked

## Properties

| Property | Value |
| - | - |
|ID|207|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted after a `FaultProvider` has been invoked.  
  
## Message  

 The Dispatcher invoked a FaultProvider of type '%1' with an exception of type '%2'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TypeName|`xs:string`|The CLR FullName of the type of the invoked `FaultProvider`.|  
|ExceptionTypeName|`xs:string`|The CLR FullName of the exception that the `FaultProvider` has operated on.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
