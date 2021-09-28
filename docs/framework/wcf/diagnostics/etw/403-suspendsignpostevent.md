---
description: "Learn more about: 403 - SuspendSignpostEvent"
title: "403 - SuspendSignpostEvent"
ms.date: "03/30/2017"
ms.assetid: fb2e6f29-e556-47b4-b4c1-acd6b8879702
---
# 403 - SuspendSignpostEvent

## Properties

| Property | Value |
| - | - |
|ID|403|  
|Keywords|Troubleshooting|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event marks the suspension of an end-to-end activity. It contains the name of the activity.  
  
## Message  

 Activity boundary.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Extended Data|`xs:string`|The name of the activity.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
