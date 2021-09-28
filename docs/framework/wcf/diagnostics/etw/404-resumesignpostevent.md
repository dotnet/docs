---
description: "Learn more about: 404 - ResumeSignpostEvent"
title: "404 - ResumeSignpostEvent"
ms.date: "03/30/2017"
ms.assetid: 395cc7ca-f35f-4295-be97-39a077f99c97
---
# 404 - ResumeSignpostEvent

## Properties

| Property | Value |
| - | - |
|ID|404|  
|Keywords|Troubleshooting|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event marks the resumption of an end-to-end activity. It contains the name of the activity.  
  
## Message  

 Activity boundary.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Extended Data|`xs:string`|The name of the activity.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
