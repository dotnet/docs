---
title: "441- StopSignpostEvent1"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fc9850a5-0dc3-4b84-a09a-744301c7c18e
caps.latest.revision: 4
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 441- StopSignpostEvent1
## Properties  
  
|||  
|-|-|  
|ID|441|  
|Keywords|Troubleshooting|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 In activity tracing, indicates a message has completed crossing an activity boundary in send or receive.  
  
## Message  
 Activity boundary.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Extended Data|`xs:string`|The name of the activity.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
