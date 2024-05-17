---
description: "Learn more about: 4210 - SqlExceptionCaught"
title: "4210 - SqlExceptionCaught"
ms.date: "03/30/2017"
ms.assetid: f0ce8af3-eb4c-48c8-b3d9-dd2f94b5574b
---
# 4210 - SqlExceptionCaught

## Properties

| Property | Value |
| - | - |
|ID|4210|  
|Keywords|WFInstanceStore|  
|Level|Warning|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates a SQL exception was caught.  
  
## Message  

 Caught SQL Exception number %1 message %2.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ErrorNumber|xs:string|The SQL error number.|  
|ExceptionMessage|xs:string|The message from the SQL exception.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
