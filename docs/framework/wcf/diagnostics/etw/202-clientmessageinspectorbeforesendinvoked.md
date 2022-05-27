---
description: "Learn more about: 202 - ClientMessageInspectorBeforeSendInvoked"
title: "202 - ClientMessageInspectorBeforeSendInvoked"
ms.date: "03/30/2017"
ms.assetid: 0b02ca82-8a55-45e3-b2e2-ddfe28a7269c
---
# 202 - ClientMessageInspectorBeforeSendInvoked

## Properties

| Property | Value |
| - | - |
|ID|202|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted after the Service Model has invoked the `BeforeSendRequest` method on a client message inspector.  
  
## Message  

 The Dispatcher invoked 'BeforeSendRequest' on a ClientMessageInspector of type  '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TypeName|`xs:string`|The CLR FullName of the invoked inspector's type.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
