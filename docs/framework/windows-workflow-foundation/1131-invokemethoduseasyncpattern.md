---
title: "1131 - InvokeMethodUseAsyncPattern"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: eca50fa7-5276-4759-ad1c-e490b9bd1f82
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1131 - InvokeMethodUseAsyncPattern
## Properties  
  
|||  
|-|-|  
|ID|1131|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 During CacheMetadata step, InvokeMethod activity indicates that it is using the async pattern when invoking the method.  
  
## Message  
 InvokeMethod '%1' - method uses asynchronous pattern of '%2' and '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InvokeMethod|xs:string|The display name of the InvokeMethod activity.|  
|BeginMethod|xs:string|The name of the begin method.|  
|EndMethod|xs:string|The name of the end method.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
