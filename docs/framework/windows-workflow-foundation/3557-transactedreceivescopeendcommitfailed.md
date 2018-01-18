---
title: "3557 - TransactedReceiveScopeEndCommitFailed"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 079f0188-8146-49ee-b6ae-a08f4e4d2b9b
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 3557 - TransactedReceiveScopeEndCommitFailed
## Properties  
  
|||  
|-|-|  
|ID|3557|  
|Keywords|WFServices|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 Indicates the call to EndCommit on a CommittableTransaction threw a TransactionException.  
  
## Message  
 The call to EndCommit on the CommittableTransaction with id = '%1' threw a TransactionException with the following message: '%2'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|TransactionId|xs:string|The id of the CommittableTransaction.|  
|Exception|xs:string|The exception details for the exception|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
