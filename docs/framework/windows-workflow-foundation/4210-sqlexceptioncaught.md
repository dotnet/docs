---
title: "4210 - SqlExceptionCaught"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f0ce8af3-eb4c-48c8-b3d9-dd2f94b5574b
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 4210 - SqlExceptionCaught
## Properties  
  
|||  
|-|-|  
|ID|4210|  
|Keywords|WFInstanceStore|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a SQL exception was caught.  
  
## Message  
 Caught SQL Exception number %1 message %2.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ErrorNumber|xs:string|The SQL error number.|  
|ExceptionMessage|xs:string|The message from the SQL exception.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
