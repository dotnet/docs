---
title: "4209 - TimeoutOpeningSqlConnection"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: f0e56518-9758-41dc-a760-50d1a10fba6e
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 4209 - TimeoutOpeningSqlConnection
## Properties  
  
|||  
|-|-|  
|ID|4209|  
|Keywords|WFInstanceStore|  
|Level|Error|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a timeout was encountered when trying to open a SQL connection.  
  
## Message  
 Timeout trying to open a SQL connection. The operation did not complete within the allotted timeout of %1. The time allotted to this operation may have been a portion of a longer timeout.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Timeout|xs:string|The timeout value for opening the SQL connection.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
