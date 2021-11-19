---
description: "Learn more about: 301 - UserDefinedErrorOccurred"
title: "301 - UserDefinedErrorOccurred"
ms.date: "03/30/2017"
ms.assetid: a0285d1c-550f-4c14-9c36-a96e97f1c4e4
---
# 301 - UserDefinedErrorOccurred

## Properties

| Property | Value |
| - | - |
|ID|301|  
|Keywords|Troubleshooting, HealthMonitoring, UserEvents, ServiceModel, EndToEndMonitoring|  
|Level|Error|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted from user code. Developers can emit this event when a custom-defined error occurs in their service. This can be done using the <xref:System.Diagnostics.Eventing> APIs. Additionally, there is a WCF sample that wraps that API and demonstrates how to properly emit this event.  
  
## Message  

 Name:'%1', Reference:'%2', Payload:%3  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Name|`xs:string`|The user-defined name of the event.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|Payload|`xs:string`|The user-defined payload of the event.|
