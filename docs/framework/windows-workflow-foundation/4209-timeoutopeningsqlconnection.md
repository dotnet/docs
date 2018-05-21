---
title: "4209 - TimeoutOpeningSqlConnection"
ms.date: "03/30/2017"
ms.assetid: f0e56518-9758-41dc-a760-50d1a10fba6e
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
