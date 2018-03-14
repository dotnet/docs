---
title: "1150 - CompensationState"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: eb015842-cc5a-47be-bce5-6af39e567723
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1150 - CompensationState
## Properties  
  
|||  
|-|-|  
|ID|1150|  
|Keywords|WFActivities|  
|Level|Information|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a change of state in a CompensableActivity.  
  
## Message  
 CompensableActivity '%1' is in the '%2' state.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|DisplayName|xs:string|The display name of the activity.|  
|State|xs:string|The compensation state.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
