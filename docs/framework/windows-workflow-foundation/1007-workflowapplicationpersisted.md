---
description: "Learn more about: 1007 - WorkflowApplicationPersisted"
title: "1007 - WorkflowApplicationPersisted"
ms.date: "03/30/2017"
ms.assetid: f4ea4452-28e3-4e66-93c6-eb12ee29bcb1
---
# 1007 - WorkflowApplicationPersisted

## Properties

| Property | Value |
| - | - |
|ID|1007|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a workflow application has persisted.  
  
## Message  

 WorkflowApplication Id: '%1' was Persisted.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowApplicationId|`xs:string`|The workflow application id|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
