---
title: "3501 - InferredContractDescription"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 21a70849-4fc0-41d2-b9a4-db5aa2acdf1a
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 3501 - InferredContractDescription
## Properties  
  
|||  
|-|-|  
|ID|3501|  
|Keywords|WFServices|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 Indicates a ContractDescription has been inferred from WorkflowService.  
  
## Message  
 ContractDescription with Name='%1' and Namespace='%2' has been inferred from WorkflowService.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Name|xs:string|The name of the ContractDescription.|  
|Namespace|xs:string|The namespace of the ContractDescription.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
