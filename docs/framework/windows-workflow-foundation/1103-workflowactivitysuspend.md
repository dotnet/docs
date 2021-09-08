---
description: "Learn more about: 1103 - WorkflowActivitySuspend"
title: "1103 - WorkflowActivitySuspend"
ms.date: "03/30/2017"
ms.assetid: b64e15c2-cb2c-4314-9074-ce2c6717232e
---
# 1103 - WorkflowActivitySuspend

## Properties

| Property | Value |
| - | - |
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
