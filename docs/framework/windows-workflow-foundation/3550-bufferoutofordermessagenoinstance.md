---
title: "3550 - BufferOutOfOrderMessageNoInstance"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 1299d294-99b8-430e-98b1-55f5f17002f3
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 3550 - BufferOutOfOrderMessageNoInstance
## Properties  
  
|||  
|-|-|  
|ID|3550|  
|Keywords|WFServices|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 Indicates a buffered receive has failed. The operation will be attempted again when the service instance is ready to process this particular operation.  
  
## Message  
 Operation '%1' cannot be performed at this time. Another attempt will be made when the service instance is ready to process this particular operation.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|OperationName|xs:string|The name of the operation.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
