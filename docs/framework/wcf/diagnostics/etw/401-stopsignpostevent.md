---
description: "Learn more about: 401- StopSignPostEvent"
title: "401- StopSignPostEvent"
ms.date: "03/30/2017"
ms.assetid: e033d03a-510d-4300-aa65-ef02cb4807f2
---
# 401- StopSignPostEvent

## Properties

| Property | Value |
| - | - |
|ID|401|  
|Keywords|Troubleshooting|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event marks the end of an end-to-end activity. It contains the name of the activity.  
  
## Message  

 Activity boundary.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Extended Data|`xs:string`|The name of the activity.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
