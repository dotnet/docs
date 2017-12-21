---
title: "39457 - TrackingRecordRaised"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5a2731d1-c731-4b79-bb69-016cb69ef481
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 39457 - TrackingRecordRaised
## Properties  
  
|||  
|-|-|  
|ID|39457|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a TrackingRecord has been raised to a TrackingParticipant.  
  
## Message  
 Tracking Record %1 raised to %2.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|RecordNumber|xs:string|The tracking record number.|  
|ParticipantId|xs:string|The tracking participant.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
