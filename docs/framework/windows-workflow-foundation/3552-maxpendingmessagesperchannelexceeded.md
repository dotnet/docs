---
title: "3552 - MaxPendingMessagesPerChannelExceeded"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: fc8309d9-eb3a-4636-a6f0-dd0018c1361d
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 3552 - MaxPendingMessagesPerChannelExceeded
## Properties  
  
|||  
|-|-|  
|ID|3552|  
|Keywords|Quota, WFServices|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 Indicates the throttle 'MaxPendingMessagesPerChannel' limit was hit.  
  
## Message  
 The throttle 'MaxPendingMessagesPerChannel' limit of  '%1' was hit. To increase this limit, adjust the MaxPendingMessagesPerChannel property on BufferedReceiveServiceBehavior.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Limit|xs:string|The limit of the MaxPendingMessagesPerChannel throttle.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
