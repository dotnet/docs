---
title: "CoEEShutDownCOM Function"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "CoEEShutDownCOM"
api_location: 
  - "mscoree.dll"
  - "clr.dll"
  - "mscorwks.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CoEEShutDownCOM"
helpviewer_keywords: 
  - "CoEEShutDownCOM function [.NET Framework hosting]"
ms.assetid: b634cae2-632f-4737-9be4-92d0652844d7
topic_type: 
  - "apiref"
caps.latest.revision: 18
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CoEEShutDownCOM Function
Forces the common language runtime (CLR) to release all interface pointers it holds inside runtime callable wrappers (RCW). This has the effect of releasing all RCW caches. This global function is deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)]. Instead, use the entry point for a specific runtime.  
  
## Syntax  
  
```  
void CoEEShutDownCOM ();  
```  
  
## Remarks  
 The `CoEEShutDownCOM` function first releases all the RCWs in all contexts and in all caches, and then removes any tear-down notification existing in setup. No DLL unloading occurs.  
  
> [!CAUTION]
>  This function affects all runtimes that are loaded into the process.  
  
 Beginning with the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)], call the entry point for this function on the specific runtime you want to affect. To get the entry point, call the [ICLRRuntimeInfo::GetProcAddress](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-getprocaddress-method.md) method and specify "CoEEShutDownCOM".  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)
