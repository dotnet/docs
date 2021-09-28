---
description: "Learn more about: 1102 - WorkflowActivityStop"
title: "1102 - WorkflowActivityStop"
ms.date: "03/30/2017"
ms.assetid: 285e5cb8-e90d-4914-ac06-e9b176ffefa2
---
# 1102 - WorkflowActivityStop

## Properties

| Property | Value |
| - | - |
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
