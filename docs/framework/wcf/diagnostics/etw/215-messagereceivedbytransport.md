---
title: "215 - MessageReceivedByTransport"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: bb32aa60-5207-4711-9f08-110e8ac327e5
caps.latest.revision: 7
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 215 - MessageReceivedByTransport
## Properties  
  
|||  
|-|-|  
|ID|215|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event occurs when a TCP-based transport receives a message. Note that at the transport level, multiple messages can be exchanged between clients and services for a single operation. This can be due to infrastructure behavior, security is a good example. Therefore, the number of `MessageReceivedByTransport` events that are emitted vary based on your service's binding and its configuration.  
  
> [!NOTE]
>  This event is not emitted for one-way transports.  
  
## Message  
 The transport received a message from '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Listen Address|`xs:string`|The address that received the message.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
