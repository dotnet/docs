---
description: "Learn more about: 1041 - WorkflowApplicationPersistableIdle"
title: "1041 - WorkflowApplicationPersistableIdle"
ms.date: "03/30/2017"
ms.assetid: 966adf2f-e21d-44df-a3ec-a8e285e0a316
---
# 1041 - WorkflowApplicationPersistableIdle

## Properties

| Property | Value |
| - | - |
|ID|1041|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates that a workflow application is idle and persistable. The workflow application will be idled or persisted.  
  
## Message  

 WorkflowApplication Id: '%1' is idle and persistable.  The following action will be taken: %2.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|WorkflowApplicationId|xs:string|The workflow application id|  
|ActionTaken|xs:string|The action that will be taken on the workflow application.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
