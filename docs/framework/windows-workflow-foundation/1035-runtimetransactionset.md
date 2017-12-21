---
title: "1035 - RuntimeTransactionSet"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 03b37de9-778c-4beb-b0e3-de73ece6088e
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1035 - RuntimeTransactionSet
## Properties  
  
|||  
|-|-|  
|ID|1035|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates an activity has set the runtime transaction.  
  
## Message  
 The runtime transaction has been set by Activity '%1', DisplayName: '%2', InstanceId: '%3'.  Execution isolated to Activity '%4', DisplayName: '%5', InstanceId: '%6'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|Activity|xs:string|The type name of the activity.|  
|DisplayName|xs:string|The display name of the activity.|  
|InstanceId|xs:string|The instance id of the activity.|  
|IsolatedActivity|xs:string|The type name of the activity that the transaction is isolated to.|  
|IsolatedActivityDisplayName|xs:string|The display name of the activity that the transaction is isolated to.|  
|IsolatedActivityInstanceId|xs:string|The instance id of the activity that the transaction is isolated to.|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
