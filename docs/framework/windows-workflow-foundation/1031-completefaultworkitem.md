---
title: "1031 - CompleteFaultWorkItem"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 95f4ccb0-6be4-41f3-9330-fae43165828f
caps.latest.revision: 3
author: "dotnet-bot"
ms.author: "dotnetcontent"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# 1031 - CompleteFaultWorkItem
## Properties  
  
|||  
|-|-|  
|ID|1031|  
|Keywords|WFRuntime|  
|Level|Verbose|  
|Channel|Microsoft-Windows-Application Server-Applications/Debug|  
  
## Description  
 Indicates a FaultWorkItem has completed.  
  
## Message  
 A FaultWorkItem has completed for Activity '%1', DisplayName: '%2', InstanceId: '%3'. The exception was propagated from Activity '%4', DisplayName: '%5', InstanceId: '%6'.  
  
## Details  
  
|Data Item Name|Data Item Type|Description|  
|--------------------|--------------------|-----------------|  
|FaultActivity|xs:string|The type name of the fault activity.|  
|FaultActivityDisplayName|xs:string|The display name of the fault activity.|  
|FaultActivityInstanceId|xs:string|The instance id of the fault activity.|  
|ExceptionActivity|xs:string|The type name of the activity that threw the exception.|  
|ExceptionActivityDisplayName|xs:string|The display name of the activity that threw the exception.|  
|ExceptionActivityInstanceId|xs:string|The instance id of the activity that threw the exception.|  
|Exception|xs:string|The exception details for the exception|  
|AppDomain|xs:string|The string returned by AppDomain.CurrentDomain.FriendlyName.|
