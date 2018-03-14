---
title: "216 - MessageSentByTransport"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 150c3167-4154-4225-8d94-57cc94341233
caps.latest.revision: 6
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 216 - MessageSentByTransport
## Properties  
  
|||  
|-|-|  
|ID|216|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event occurs when a TCP-based transport sends a message. Note that at the transport level multiple messages can be exchanged between clients and services for a single operation. This may be due to infrastructure behavior, security being a good example. Therefore, the number of **MessageSentByTransport** events that are emitted vary based on your service's binding and its configuration.  
  
## Message  
 The transport sent a message to '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|DestinationAddress|`xs:string`|The address that the request message was sent to.|  
|HostReference|xs:string|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
