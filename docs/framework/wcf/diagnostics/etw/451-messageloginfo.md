---
description: "Learn more about: 451 - MessageLogInfo"
title: "451 - MessageLogInfo"
ms.date: "03/30/2017"
ms.assetid: 485b4b29-dc21-4a35-93f8-5f4726d6aa5a
---
# 451 - MessageLogInfo

## Properties

| Property | Value |
| - | - |
|ID|451|  
|Keywords|Troubleshooting, WCFMessageLogging|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  

 This event is emitted when the message log information is sent.  
  
## Message  

 %1  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|data1|`xs:string`||  
|AppDomain|`xs:string`|The string returned by AppDomain.CurrentDomain.FriendlyName.|
