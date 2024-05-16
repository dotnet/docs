---
description: "Learn more about: 1101 - WorkflowActivityStart"
title: "1101 - WorkflowActivityStart"
ms.date: "03/30/2017"
ms.assetid: 831cd386-b9b5-47a9-9690-aff6292ff348
---
# 1101 - WorkflowActivityStart

## Properties

| Property | Value |
| - | - |
|ID|1101|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a workflow activity has started.  
  
## Message  

 WorkflowInstance Id: '%1' E2E Activity  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowInstanceId|xs:string|The workflow instance id.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
