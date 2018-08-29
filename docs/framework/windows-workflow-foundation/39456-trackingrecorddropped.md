---
title: "39456 - TrackingRecordDropped"
ms.date: "03/30/2017"
ms.assetid: da13d5bc-1736-47a4-b3fd-064ca8040326
---
# 39456 - TrackingRecordDropped
## Properties  
  
|||  
|-|-|  
|ID|39456|  
|Keywords|WFTracking|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a tracking record has been dropped because its size exceeds maximum allowed by the ETW session provider.  
  
## Message  
 Size of tracking record %1 exceeds maximum allowed by the ETW session for provider %2  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Exception|xs:string|The exception details for the exception|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
