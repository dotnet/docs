---
description: "Learn more about: 1008 - WorkflowApplicationUnloaded"
title: "1008 - WorkflowApplicationUnloaded"
ms.date: "03/30/2017"
ms.assetid: a605b780-4a7e-43ab-92e7-0a3b01d053b0
---
# 1008 - WorkflowApplicationUnloaded

## Properties

| Property | Value |
| - | - |
|ID|1008|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a workflow application has unloaded.  
  
## Message  

 WorkflowInstance Id: '%1' was Unloaded.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowInstanceId|`xs:string`|The instance id for the workflow|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
