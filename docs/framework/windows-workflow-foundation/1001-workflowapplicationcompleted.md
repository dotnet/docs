---
description: "Learn more about: 1001 - WorkflowApplicationCompleted"
title: "1001 - WorkflowApplicationCompleted"
ms.date: "03/30/2017"
ms.assetid: 7a2ab59a-cf66-437a-b01e-f8f7268a3f7a
---
# 1001 - WorkflowApplicationCompleted

## Properties  
  
|Property|Value|
|-|-|  
|ID|1001|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a workflow application has completed in the Closed state.  
  
## Message  

 WorkflowInstance Id: '%1' has completed in the Closed state.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowInstanceId|`xs:string`|The instance id for the workflow|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
