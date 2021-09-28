---
description: "Learn more about: 1022 - StartBookmarkWorkItem"
title: "1022 - StartBookmarkWorkItem"
ms.date: "03/30/2017"
ms.assetid: 4415fbdb-0329-4019-803f-aea66e75f3da
---
# 1022 - StartBookmarkWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1022|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a BookmarkWorkItem is starting execution.  
  
## Message  

 Starting execution of a BookmarkWorkItem for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  BookmarkName: %4, BookmarkScope: %5.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|BookmarkName|xs:string|The name of the bookmark.|  
|BookmarkScope|xs:string|The scope of the bookmark.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
