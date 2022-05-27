---
description: "Learn more about: 499 - TransferEmitted"
title: "499 - TransferEmitted"
ms.date: "03/30/2017"
ms.assetid: 07a26434-a7a0-40fc-b5d0-3520a04328ae
---
# 499 - TransferEmitted

## Properties

| Property | Value |
| - | - |
|ID|499|  
|Keywords|Troubleshooting, UserEvents, EndToEndMonitoring, ServiceModel, WFTracking, ServiceHost, WCFMessageLogging|  
|Level|LogAlways|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted when the transfer event takes place.  
  
## Message  

 Transfer event emitted.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
