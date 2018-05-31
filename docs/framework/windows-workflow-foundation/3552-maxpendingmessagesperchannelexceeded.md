---
title: "3552 - MaxPendingMessagesPerChannelExceeded"
ms.date: "03/30/2017"
ms.assetid: fc8309d9-eb3a-4636-a6f0-dd0018c1361d
---
# 3552 - MaxPendingMessagesPerChannelExceeded
## Properties  
  
|||  
|-|-|  
|ID|3552|  
|Keywords|Quota, WFServices|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 Indicates the throttle 'MaxPendingMessagesPerChannel' limit was hit.  
  
## Message  
 The throttle 'MaxPendingMessagesPerChannel' limit of  '%1' was hit. To increase this limit, adjust the MaxPendingMessagesPerChannel property on BufferedReceiveServiceBehavior.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Limit|xs:string|The limit of the MaxPendingMessagesPerChannel throttle.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
