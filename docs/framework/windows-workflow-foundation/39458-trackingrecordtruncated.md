---
title: "39458 - TrackingRecordTruncated"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5352f0eb-d571-454a-bab5-e2162888b218
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 39458 - TrackingRecordTruncated
## Properties  
  
|||  
|-|-|  
|ID|39458|  
|Keywords|WFTracking|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a tracking record has been truncated. Variables/annotations/user data have been removed.  
  
## Message  
 Truncated tracking record %1 written to ETW session with provider %2. Variables/annotations/user data have been removed  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|RecordNumber|xs:string|The tracking record number.|  
|ProviderId|xs:string|The ETW provider id.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
