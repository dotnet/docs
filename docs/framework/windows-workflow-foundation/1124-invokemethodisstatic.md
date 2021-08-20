---
description: "Learn more about: 1124 - InvokeMethodIsStatic"
title: "1124 - InvokeMethodIsStatic"
ms.date: "03/30/2017"
ms.assetid: b9643641-fb52-4fa8-b354-4dd6617d68f6
---
# 1124 - InvokeMethodIsStatic

## Properties

| Property | Value |
| - | - |
|ID|1124|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 During CacheMetadata step, InvokeMethod activity indicates the method to be invoked is static.  
  
## Message  

 InvokeMethod '%1' - method is Static.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InvokeMethod|xs:string|The display name of the InvokeMethod activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
