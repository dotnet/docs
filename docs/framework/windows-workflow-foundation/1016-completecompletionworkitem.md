---
description: "Learn more about: 1016 - CompleteCompletionWorkItem"
title: "1016 - CompleteCompletionWorkItem"
ms.date: "03/30/2017"
ms.assetid: 246929fb-6f14-440a-814b-cd8349350644
---
# 1016 - CompleteCompletionWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1016|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a CompletionWorkItem has completed.  
  
## Message  

 A CompletionWorkItem has completed for parent Activity '%1', DisplayName: '%2', InstanceId: '%3'. Completed Activity '%4', DisplayName: '%5', InstanceId: '%6'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ParentActivity|xs:string|The type name of the parent activity.|  
|ParentDisplayName|xs:string|The display name of the parent activity.|  
|ParentInstanceId|xs:string|The instance id of the parent activity.|  
|CompletedActivity|xs:string|The type name of the completed activity.|  
|CompletedActivityDisplayName|xs:string|The display name of the completed activity.|  
|CompletedActivityInstanceId|xs:string|The instance id of the completed activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
