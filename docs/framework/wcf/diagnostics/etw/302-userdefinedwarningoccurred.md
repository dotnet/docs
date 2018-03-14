---
title: "302 - UserDefinedWarningOccurred"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8d1f0bf1-0151-45e6-be92-573d397b54de
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 302 - UserDefinedWarningOccurred
## Properties  
  
|||  
|-|-|  
|ID|302|  
|Keywords|Troubleshooting, HealthMonitoring, UserEvents, ServiceModel, EndToEndMonitoring|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted from user code. Developers can emit this event when a custom-defined warning event occurs in their service. This can be done using the <xref:System.Diagnostics.Eventing> APIs. Additionally, there is a WCF sample that wraps that API and demonstrates how to properly emit this event.  
  
## Message  
 Name:'%1', Reference:'%2', Payload:%3  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Name|`xs:string`|The user-defined name of the event.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|Payload|`xs:string`|The user-defined payload of the event.|
