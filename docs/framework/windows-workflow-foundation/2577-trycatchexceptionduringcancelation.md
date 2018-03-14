---
title: "2577 - TryCatchExceptionDuringCancelation"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 35ee9f55-227f-4566-bcb4-4c7c75dea85b
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 2577 - TryCatchExceptionDuringCancelation
## Properties  
  
|||  
|-|-|  
|ID|2577|  
|Keywords|WFActivities|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a child activity of the TryCatch activity has thrown an exception during cancelation.  
  
## Message  
 A child activity of the TryCatch activity '%1' has thrown an exception during cancelation.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|DisplayName|xs:string|The display name of the activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
