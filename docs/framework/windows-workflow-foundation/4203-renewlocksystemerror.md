---
title: "4203 - RenewLockSystemError"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 6ec9ec6f-4ae2-45cf-b99b-02cdb9dc9ec9
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 4203 - RenewLockSystemError
## Properties  
  
|||  
|-|-|  
|ID|4203|  
|Keywords|WFInstanceStore|  
|Level|Error|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates SQL provider has failed to extend lock expiration due to either lock expiration already passed or the lock owner was deleted. The SqlWorkflowInstanceStore will be aborted.  
  
## Message  
 Failed to extend lock expiration, lock expiration already passed or the lock owner was deleted. Aborting SqlWorkflowInstanceStore.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
