---
title: "1102 - WorkflowActivityStop"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 285e5cb8-e90d-4914-ac06-e9b176ffefa2
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1102 - WorkflowActivityStop
## Properties  
  
|||  
|-|-|  
|ID|1102|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a workflow activity has stopped.  
  
## Message  
 WorkflowInstance Id: '%1' E2E Activity  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowInstanceId|xs:string|The workflow instance id.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
