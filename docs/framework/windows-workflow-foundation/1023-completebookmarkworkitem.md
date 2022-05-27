---
description: "Learn more about: 1023 - CompleteBookmarkWorkItem"
title: "1023 - CompleteBookmarkWorkItem"
ms.date: "03/30/2017"
ms.assetid: fc5dac57-b3eb-4826-b505-c6d269e4774d
---
# 1023 - CompleteBookmarkWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1023|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a BookmarkWorkItem has completed.  
  
## Message  

 A BookmarkWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'. BookmarkName: %4, BookmarkScope: %5.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|BookmarkName|xs:string|The name of the bookmark.|  
|BookmarkScope|xs:string|The scope of the bookmark.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
