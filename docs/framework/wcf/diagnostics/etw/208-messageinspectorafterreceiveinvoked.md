---
title: "208 - MessageInspectorAfterReceiveInvoked"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: dfb5f7b0-4346-4949-8104-351726b1f502
caps.latest.revision: 5
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 208 - MessageInspectorAfterReceiveInvoked
## Properties  
  
|||  
|-|-|  
|ID|208|  
|Keywords|Troubleshooting, ServiceModel|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted after the Service Model has invoked the `AfterReceive` method on a message inspector.  
  
## Message  
 The Dispatcher invoked 'AfterReceiveReply' on a MessageInspector of type '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TypeName|`xs:string`|The CLR FullName of the type of the invoked `MessageInspector`.|  
|HostReference|`xs:string`|For Web-hosted services, this field uniquely identifies the service in the Web hierarchy. Its format is defined as 'Web Site Name Application Virtual Path&#124;Service Virtual Path&#124;ServiceName'. Example: 'Default Web Site/CalculatorApplication&#124;/CalculatorService.svc&#124;CalculatorService'.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
