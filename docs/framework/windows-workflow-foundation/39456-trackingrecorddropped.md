---
title: "39456 - TrackingRecordDropped"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: da13d5bc-1736-47a4-b3fd-064ca8040326
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 39456 - TrackingRecordDropped
## Properties  
  
|||  
|-|-|  
|ID|39456|  
|Keywords|WFTracking|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a tracking record has been dropped because its size exceeds maximum allowed by the ETW session provider.  
  
## Message  
 Size of tracking record %1 exceeds maximum allowed by the ETW session for provider %2  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Exception|xs:string|The exception details for the exception|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
