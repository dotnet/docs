---
description: "Learn more about: 1025 - BookmarkScopeInitialized"
title: "1025 - BookmarkScopeInitialized"
ms.date: "03/30/2017"
ms.assetid: 63584434-e709-471d-9e96-97d3d99e70d6
---
# 1025 - BookmarkScopeInitialized

## Properties

| Property | Value |
| - | - |
|ID|1025|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a BookmarkScope has been initialized.  
  
## Message  

 The BookmarkScope that had TemporaryId: '%1' has been initialized with Id: '%2'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TemporaryId|xs:string|The temporary id of the bookmark.|  
|InitializedId|xs:string|The initialized id of the bookmark.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
