---
description: "Learn more about: 221 - MessageReceivedFromTransport"
title: "221 - MessageReceivedFromTransport"
ms.date: "03/30/2017"
ms.assetid: 4995f0d5-c182-4d97-981f-6951da6df1fb
---
# 221 - MessageReceivedFromTransport

## Properties

| Property | Value |
| - | - |
|ID|221|  
|Keywords|EndToEndMonitoring, Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted when the Service Model receives a message from the transport.  
  
## Message  

 The Dispatcher received a message from the transport. Correlation ID == '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Correlation ID|`xs:GUID`|The activity ID used to correlate a `MessageSentToTransport` event from a service or client to its corresponding `MessageReceivedFromTransport` on the other end.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
