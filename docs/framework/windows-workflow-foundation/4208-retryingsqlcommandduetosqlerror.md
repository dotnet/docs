---
title: "4208 - RetryingSqlCommandDueToSqlError"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: a8e6483a-a6e4-4bbf-82ec-cd8b6e711aad
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 4208 - RetryingSqlCommandDueToSqlError
## Properties  
  
|||  
|-|-|  
|ID|4208|  
|Keywords|WFInstanceStore|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates the SQL provider is retrying a SQL command due to a SQL error.  
  
## Message  
 Retrying a SQL command due to SQL error number %1.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|ErrorNumber|xs:string|The SQL error number.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
