---
description: "Learn more about: 1015 - StartCompletionWorkItem"
title: "1015 - StartCompletionWorkItem"
ms.date: "03/30/2017"
ms.assetid: 96fd1d4e-c5d0-46ad-8a71-4b4b49ac7262
---
# 1015 - StartCompletionWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1015|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a CompletionWorkItem is starting execution.  
  
## Message  

 Starting execution of a CompletionWorkItem for parent Activity '%1', DisplayName: '%2', InstanceId: '%3'. Completed Activity '%4', DisplayName: '%5', InstanceId: '%6'.  
  
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
