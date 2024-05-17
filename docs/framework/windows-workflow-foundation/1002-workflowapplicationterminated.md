---
description: "Learn more about: 1002 - WorkflowApplicationTerminated"
title: "1002 - WorkflowApplicationTerminated"
ms.date: "03/30/2017"
ms.assetid: 4e8b111f-79dc-4898-bb4a-e9b36f69420f
---
# 1002 - WorkflowApplicationTerminated

## Properties

| Property | Value |
| - | - |
|ID|1002|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a workflow application has terminated in the Faulted state with an exception.  
  
## Message  

 WorkflowApplication Id: '%1' was terminated. It has completed in the Faulted state with an exception.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowApplicationId|`xs:string`|The workflow application id|  
|Exception|`xs:string`|The exception details for the exception|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
