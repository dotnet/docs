---
title: "451 - MessageLogInfo"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 485b4b29-dc21-4a35-93f8-5f4726d6aa5a
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 451 - MessageLogInfo
## Properties  
  
|||  
|-|-|  
|ID|451|  
|Keywords|Troubleshooting, WCFMessageLogging|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event is emitted when the message log information is sent.  
  
## Message  
 %1  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|data1|`xs:string`||  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
