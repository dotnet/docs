---
title: "1132 - InvokeMethodDoesNotUseAsyncPattern"
ms.date: "03/30/2017"
ms.assetid: 436b3767-4460-46b0-9ea3-fc2963260c11
---
# 1132 - InvokeMethodDoesNotUseAsyncPattern
## Properties  
  
|||  
|-|-|  
|ID|1132|  
|Keywords|WFRuntime|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 During CacheMetadata step, InvokeMethod activity indicates that it is not using the async pattern when invoking the method.  
  
## Message  
 InvokeMethod '%1' - method does not use asynchronous pattern.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InvokeMethod|xs:string|The display name of the InvokeMethod activity.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
