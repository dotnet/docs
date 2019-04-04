---
title: "1125 - InvokeMethodIsNotStatic"
ms.date: "03/30/2017"
ms.assetid: ea2b3827-63da-497b-b2c3-d5cebefe57a1
---
# 1125 - InvokeMethodIsNotStatic
## Properties  
  
|||  
|-|-|  
|ID|1125|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 During CacheMetadata step, InvokeMethod activity indicates the method to be invoked is not static.  
  
## Message  
 InvokeMethod '%1' - method is not Static.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InvokeMethod|xs:string|The display name of the InvokeMethod activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
