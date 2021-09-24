---
description: "Learn more about: 209 - MessageInspectorBeforeSendInvoked"
title: "209 - MessageInspectorBeforeSendInvoked"
ms.date: "03/30/2017"
ms.assetid: 7d710875-fb77-4463-978b-bc86d59d84cd
---
# 209 - MessageInspectorBeforeSendInvoked

## Properties

| Property | Value |
| - | - |
|ID|209|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted after the Service Model has invoked the `BeforeSend` method on a message inspector.  
  
## Message  

 The Dispatcher invoked 'BeforeSendRequest' on a MessageInspector of type '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TypeName|`xs:string`|The CLR FullName of the type of the invoked `MessageInspector`.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
