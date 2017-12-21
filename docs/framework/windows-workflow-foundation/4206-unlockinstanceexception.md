---
title: "4206 - UnlockInstanceException"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 5a46dc5f-d517-4135-8905-25a42f01206b
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 4206 - UnlockInstanceException
## Properties  
  
|||  
|-|-|  
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
