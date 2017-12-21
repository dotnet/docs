---
title: "4211 - QueuingSqlRetry"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: df569f88-c86b-4503-840d-1399b67f4df7
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 4211 - QueuingSqlRetry
## Properties  
  
|||  
|-|-|  
|ID|4211|  
|Keywords|WFInstanceStore|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates queuing SQL retry.  
  
## Message  
 Queuing SQL retry with delay %1 milliseconds.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Delay|xs:string|The delay between retries.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
