---
description: "Learn more about: 1020 - CreateBookmark"
title: "1020 - CreateBookmark"
ms.date: "03/30/2017"
ms.assetid: 4bee948d-816f-4803-85cc-3883b5e23d10
---
# 1020 - CreateBookmark

## Properties

| Property | Value |
| - | - |
|ID|1020|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a bookmark has been created for an activity.  
  
## Message  

 A Bookmark has been created for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  BookmarkName: %4, BookmarkScope: %5.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|BookmarkName|xs:string|The name of the bookmark.|  
|BookmarkScope|xs:string|The scope of the bookmark.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
