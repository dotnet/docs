---
title: "1022 - StartBookmarkWorkItem"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4415fbdb-0329-4019-803f-aea66e75f3da
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1022 - StartBookmarkWorkItem
## Properties  
  
|||  
|-|-|  
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
