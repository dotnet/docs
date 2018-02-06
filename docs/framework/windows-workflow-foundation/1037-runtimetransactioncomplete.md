---
title: "1037 - RuntimeTransactionComplete"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 2c8c31e0-42a9-4f46-865b-2da9ab16a0ba
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1037 - RuntimeTransactionComplete
## Properties  
  
|||  
|-|-|  
|ID|1037|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates the runtime transaction has completed.  
  
## Message  
 The runtime transaction has completed with the state '%1'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|State|xs:string|The state of the transaction.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
