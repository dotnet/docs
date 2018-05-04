---
title: "4201 - EndSqlCommandExecute"
ms.date: "03/30/2017"
ms.assetid: ae0dbc15-f98c-4096-a8d9-fbe4dc36f1cd
---
# 4201 - EndSqlCommandExecute
## Properties  
  
|||  
|-|-|  
|ID|4201|  
|Keywords|WFInstanceStore|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a SQL command has finished executing.  
  
## Message  
 End SQL command execution: %1  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|SqlCommand|xs:string|The SQL command that was executed.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
