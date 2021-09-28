---
description: "Learn more about: 1021 - ScheduleBookmarkWorkItem"
title: "1021 - ScheduleBookmarkWorkItem"
ms.date: "03/30/2017"
ms.assetid: 2e0da311-b219-4637-9460-90cdafcc4ecd
---
# 1021 - ScheduleBookmarkWorkItem

## Properties

| Property | Value |
| - | - |
|ID|1021|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a BookmarkWorkItem has been scheduled.  
  
## Message  

 A BookmarkWorkItem has been scheduled for Activity '%1', DisplayName: '%2', InstanceId: '%3'.  BookmarkName: %4, BookmarkScope: %5.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|BookmarkName|xs:string|The name of the bookmark.|  
|BookmarkScope|xs:string|The scope of the bookmark.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
