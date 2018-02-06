---
title: "FExecuteInAppDomainCallback Function Pointer"
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
  - "FExecuteInAppDomainCallback"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FExecuteInAppDomainCallback"
helpviewer_keywords: 
  - "FExecuteInAppDomainCallback function pointer [.NET Framework hosting]"
ms.assetid: 2709f18f-3eee-497f-bc33-3ab7a485599b
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# FExecuteInAppDomainCallback Function Pointer
Points to a function that is called by the common language runtime (CLR) to execute managed code.  
  
 This function pointer has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
typedef HRESULT (__stdcall *FExecuteInAppDomainCallback) (  
    [in] void  *cookie  
);  
```  
  
#### Parameters  
 `cookie`  
 [in] A pointer to opaque caller-allocated memory that contains the managed code to be executed.  
  
 The allocation and lifetime of this memory are controlled by the caller (that is, the CLR). This is not CLR managed-heap memory.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorWks.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
