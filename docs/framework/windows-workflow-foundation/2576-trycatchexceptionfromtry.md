---
title: "2576 - TryCatchExceptionFromTry"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 47e48973-b17c-4a16-8338-c84b54aa0a6e
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 2576 - TryCatchExceptionFromTry
## Properties  
  
|||  
|-|-|  
|ID|2576|  
|Keywords|WFActivities|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates the TryCatch activity has caught an exception.  
  
## Message  
 The TryCatch activity '%1' has caught an exception of type '%2'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|DisplayName|xs:string|The display name of the activity.|  
|Exception|xs:string|The type name of the exception.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
