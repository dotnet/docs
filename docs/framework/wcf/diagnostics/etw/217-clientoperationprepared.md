---
title: "217 - ClientOperationPrepared"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ad207f04-b038-4f33-95e9-27a361df8ecd
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 217 - ClientOperationPrepared
## Properties  
  
|||  
|-|-|  
|ID|217|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted by clients just before an operation is sent to the service.  
  
## Message  
 The Client is executing Action '%1' associated with the '%2' contract. The message will be sent to '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Action|`xs:string`|The SOAP action header of the outgoing message.|  
|Contract Name|`xs:string`|The name of the contract. Example: ICalculator.|  
|Destination|`xs:string`|The address of the service endpoint that the message is sent to.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
