---
description: "Learn more about: 440 - StartSignpostEvent1"
title: "440 - StartSignpostEvent1"
ms.date: "03/30/2017"
ms.assetid: 27b551b5-ae76-49f8-bab8-6300009eb4c1
---
# 440 - StartSignpostEvent1

## Properties

| Property | Value |
| - | - |
|ID|440|  
|Keywords|Troubleshooting|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 In activity tracing, indicates a message has started crossing an activity boundary in send or receive.  
  
## Message  

 Activity boundary.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ExtendedData|`xs:string`|The name of the activity.|  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
