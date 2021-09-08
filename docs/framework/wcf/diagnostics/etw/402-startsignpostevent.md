---
description: "Learn more about: 402 - StartSignpostEvent"
title: "402 - StartSignpostEvent"
ms.date: "03/30/2017"
ms.assetid: 5e5be126-765d-4ac9-88e7-008e9ef4f0e5
---
# 402 - StartSignpostEvent

## Properties

| Property | Value |
| - | - |
|ID|402|  
|Keywords|Troubleshooting|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event marks the beginning of an end-to-end activity. It contains the name of the activity.  
  
## Message  

 Activity boundary.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Extended Data|`xs:string`|The name of the activity.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
