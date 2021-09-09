---
description: "Learn more about: 220 - MessageSentToTransport"
title: "220 - MessageSentToTransport"
ms.date: "03/30/2017"
ms.assetid: aef4e781-240b-45bc-bff8-400053037e71
---
# 220 - MessageSentToTransport

## Properties

| Property | Value |
| - | - |
|Id|220|  
|Keywords|EndToEndMonitoring, Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted when the Service Model sends a message to the transport.  
  
> [!NOTE]
> This event will not be emitted for one-way transports.  
  
## Message  

 The Dispatcher sent a message to the transport. Correlation ID == '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Correlation ID|`xs:GUID`|The activity ID used to correlate a `MessageSentToTransport` event from a service or client to its corresponding `MessageReceivedFromTransport` on the other end.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
