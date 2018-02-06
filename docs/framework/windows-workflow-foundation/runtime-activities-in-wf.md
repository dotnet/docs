---
title: "Runtime Activities in WF"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: e5ae8c31-19bc-4655-88b3-6b75cd6a1bd5
caps.latest.revision: 11
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Runtime Activities in WF
[!INCLUDE[netfx_current_short](../../../includes/netfx-current-short-md.md)] provides several system-provided activities for accessing the features of the workflow runtime, such as persistence and termination.  
  
|Activity|Description|  
|--------------|-----------------|  
|<xref:System.Activities.Statements.Persist>|Explicitly requests that the workflow persist its state.|  
|<xref:System.Activities.Statements.TerminateWorkflow>|Terminates the running workflow instance.|  
|<xref:System.Activities.Statements.NoPersistScope>|A container activity that prevents child activities from persisting.|
