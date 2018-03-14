---
title: "3507 - ServiceEndpointAdded"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: c068fc0e-07ee-4551-9824-ea7216e1fe37
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 3507 - ServiceEndpointAdded
## Properties  
  
|||  
|-|-|  
|ID|3507|  
|Keywords|WFServices|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Analytic|  
  
## Description  
 Indicates a service endpoint has been added.  
  
## Message  
 A service endpoint has been added for address '%1', binding '%2', and contract '%3'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Address|xs:string|The address of the endpoint.|  
|Binding|xs:string|The binding of the endpoint.|  
|Contract|xs:string|The contract of the endpoint.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
