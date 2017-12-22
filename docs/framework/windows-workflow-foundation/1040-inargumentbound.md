---
title: "1040 - InArgumentBound"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 7dfaad1b-36c0-4575-84c1-31d63b0eaf5d
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1040 - InArgumentBound
## Properties  
  
|||  
|-|-|  
|ID|1040|  
|Keywords|WFActivities|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates an In argument has been bound.  
  
## Message  
 In argument '%1' on Activity '%2', DisplayName: '%3', InstanceId: '%4' has been bound with value: %5.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|InArgument|xs:string|The name of the InArgument.|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|Value|xs:string|The value bound to the InArgument.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
