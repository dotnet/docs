---
title: "1005 - WorkflowApplicationIdled"
ms.date: "03/30/2017"
ms.assetid: 74d77dfa-f20d-4fe9-a6ae-e6d1b5fe4182
---
# 1005 - WorkflowApplicationIdled
## Properties  
  
|||  
|-|-|  
|ID|1005|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a workflow application has idled.  
  
## Message  
 WorkflowApplication Id: '%1' went idle.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowInstanceId|`xs:string`|The workflow application id|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
