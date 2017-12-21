---
title: "4201 - EndSqlCommandExecute"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: ae0dbc15-f98c-4096-a8d9-fbe4dc36f1cd
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
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
