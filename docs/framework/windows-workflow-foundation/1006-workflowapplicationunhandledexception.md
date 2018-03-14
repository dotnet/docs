---
title: "1006 - WorkflowApplicationUnhandledException"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: dfe0f316-e03b-47fb-b6a3-622c56bfd753
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1006 - WorkflowApplicationUnhandledException
## Properties  
  
|||  
|-|-|  
|ID|1006|  
|Keywords|WFRuntime|  
|Level|Error|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a workflow application has encountered an unhandled exception.  
  
## Message  
 WorkflowInstance Id: '%1' has encountered an unhandled exception.  The exception originated from Activity '%2', DisplayName: '%3'.  The following action will be taken: %4.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowInstanceId|`xs:string`|The instance id for the workflow|  
|Exception|`xs:string`|The exception details for the exception|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
