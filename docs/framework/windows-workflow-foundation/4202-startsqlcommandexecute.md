---
title: "4202 - StartSqlCommandExecute"
ms.date: "03/30/2017"
ms.assetid: 4559f64f-c824-4075-9e7e-4710bf30f805
---
# 4202 - StartSqlCommandExecute
## Properties  
  
|||  
|-|-|  
|ID|4202|  
|Keywords|WFInstanceStore|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a SQL command is being executed.  
  
## Message  
 Starting SQL command execution: %1  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|SqlCommand|xs:string|The SQL command that was executed.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
