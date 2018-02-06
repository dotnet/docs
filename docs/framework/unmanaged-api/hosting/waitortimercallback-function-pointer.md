---
title: "WAITORTIMERCALLBACK Function Pointer"
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
  - "WAITORTIMERCALLBACK"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "WAITORTIMERCALLBACK"
helpviewer_keywords: 
  - "WAITORTIMERCALLBACK function pointer [.NET Framework hosting]"
ms.assetid: 1fec4aef-0a06-4df0-bae7-d31a9ef9603d
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# WAITORTIMERCALLBACK Function Pointer
Points to a function that notifies the host that a wait handle (<xref:System.Threading.WaitHandle>) has either been signaled or timed out.  
  
 This function pointer has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
typedef VOID (__stdcall *WAITORTIMERCALLBACK) (  
    [in] PVOID lpParameter,  
    [in] BOOL  TimerOrWaitFired  
);  
```  
  
#### Parameters  
 `lpParameter`  
 [in] A pointer to an object that contains information defined by the host.  
  
 `TimerOrWaitFired`  
 [in] `true` if the wait handle timed out, or `false` if it was signaled.  
  
## Remarks  
 The function to which `WAITORTIMERCALLBACK` points is a callback function and must be implemented by the writer of the hosting application.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorWks.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
