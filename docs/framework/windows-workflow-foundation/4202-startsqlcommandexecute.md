---
title: "4202 - StartSqlCommandExecute"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 4559f64f-c824-4075-9e7e-4710bf30f805
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
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
