---
title: "401- StopSignPostEvent | Microsoft Docs"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e033d03a-510d-4300-aa65-ef02cb4807f2
caps.latest.revision: 3
author: "Erikre"
ms.author: "erikre"
manager: "erikre"
---
# 401- StopSignPostEvent
## Properties  
  
|||  
|-|-|  
|ID|401|  
|Keywords|Troubleshooting|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 This event marks the end of an end-to-end activity. It contains the name of the activity.  
  
## Message  
 Activity boundary.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Extended Data|`xs:string`|The name of the activity.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|