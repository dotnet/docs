---
title: "4212 - LockRetryTimeout"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: d4ad415a-9871-49fc-85b8-8ee2ea149b1d
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 4212 - LockRetryTimeout
## Properties  
  
|||  
|-|-|  
|ID|4212|  
|Keywords|WFInstanceStore|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 SQL provider encountered a timeout trying to acquire the instance lock.  
  
## Message  
 Timeout trying to acquire the instance lock.  The operation did not complete within the allotted timeout of %1. The time allotted to this operation may have been a portion of a longer timeout.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Delay|xs:string|The delay between retries.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
