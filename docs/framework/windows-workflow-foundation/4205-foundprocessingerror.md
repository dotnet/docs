---
description: "Learn more about: 4205 - FoundProcessingError"
title: "4205 - FoundProcessingError"
ms.date: "03/30/2017"
ms.assetid: f2235a15-dd87-439e-8cb9-8b1b89a3dacf
---
# 4205 - FoundProcessingError

## Properties

| Property | Value |
| - | - |
|ID|4205|  
|Keywords|WFInstanceStore|  
|Level|Error|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates SQL provider command has failed.  
  
## Message  

 Command failed: %1  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ExceptionMessage|xs:string|The message from the SQL exception.|  
|Exception|xs:string|The exception details for the exception|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
