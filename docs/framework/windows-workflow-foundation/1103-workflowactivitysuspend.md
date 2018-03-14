---
title: "1103 - WorkflowActivitySuspend"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: b64e15c2-cb2c-4314-9074-ce2c6717232e
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1103 - WorkflowActivitySuspend
## Properties  
  
|||  
|-|-|  
|ID|1103|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a workflow activity has been suspended.  
  
## Message  
 WorkflowInstance Id: '%1' E2E Activity  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowInstanceId|xs:string|The workflow instance id.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
