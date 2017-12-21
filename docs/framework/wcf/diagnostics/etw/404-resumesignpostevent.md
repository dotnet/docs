---
title: "404 - ResumeSignpostEvent"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 395cc7ca-f35f-4295-be97-39a077f99c97
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 404 - ResumeSignpostEvent
## Properties  
  
|||  
|-|-|  
|ID|404|  
|Keywords|Troubleshooting|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event marks the resumption of an end-to-end activity. It contains the name of the activity.  
  
## Message  
 Activity boundary.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Extended Data|`xs:string`|The name of the activity.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
