---
description: "Learn more about: 4206 - UnlockInstanceException"
title: "4206 - UnlockInstanceException"
ms.date: "03/30/2017"
ms.assetid: 5a46dc5f-d517-4135-8905-25a42f01206b
---
# 4206 - UnlockInstanceException

## Properties

| Property | Value |
| - | - |
|ID|4206|  
|Keywords|WFInstanceStore|  
|Level|Error|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  

 Indicates an exception was encountered while trying to unlock an instance.  
  
## Message  

 Encountered exception %1 while attempting to unlock instance.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ExceptionMessage|xs:string|The message from the SQL exception.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
