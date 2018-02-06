---
title: "FLockClrVersionCallback Function Pointer"
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
  - "FLockClrVersionCallback"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "FLockClrVersionCallback"
helpviewer_keywords: 
  - "FLockClrVersionCallback function pointer [.NET Framework hosting]"
ms.assetid: 98a4762d-9ad2-45bd-9d03-39064a028b44
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# FLockClrVersionCallback Function Pointer
Points to a function that the common language runtime (CLR) calls to indicate that initialization has either started or completed.  
  
 This function pointer has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
typedef HRESULT (__stdcall *FLockClrVersionCallback) ( );  
```  
  
## Remarks  
 This function is implemented by the host.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorWks.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [LockClrVersion Function](../../../../docs/framework/unmanaged-api/hosting/lockclrversion-function.md)  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
