---
description: "Learn more about: 1003 - WorkflowInstanceCanceled"
title: "1003 - WorkflowInstanceCanceled"
ms.date: "03/30/2017"
ms.assetid: 64754dc2-c160-4bf3-869a-13d56694e2dc
---
# 1003 - WorkflowInstanceCanceled

## Properties

| Property | Value |
| - | - |
|ID|1003|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a workflow instance has completed in the Canceled state.  
  
## Message  

 WorkflowInstance Id: '%1' has completed in the Canceled state.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowInstanceId|`xs:string`|The instance id for the workflow|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
