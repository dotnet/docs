---
title: "1148 - FlowchartSwitchCaseNotFound"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9ee7fcee-e040-4306-968e-ed840a1cb00c
caps.latest.revision: 2
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1148 - FlowchartSwitchCaseNotFound
## Properties  
  
|||  
|-|-|  
|ID|1148|  
|Keywords|WFActivities|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates that neither a matching case or a default case in a Flowchart switch could be found. Flowchart execution will end.  
  
## Message  
 Flowchart '%1'/FlowSwitch - could find neither a Case activity nor a Default Case matching the Expression result. Flowchart execution will end.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|FlowChart|xs:string|The display name of the FlowChart.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
