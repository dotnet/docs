---
title: "LPTHREAD_START_ROUTINE Function Pointer"
ms.date: "03/30/2017"
api_name: 
  - "LPTHREAD_START_ROUTINE"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "LPTHREAD_START_ROUTINE"
helpviewer_keywords: 
  - "LPTHREAD_START_ROUTINE function pointer [.NET Framework hosting]"
ms.assetid: 7b9b93b0-fe92-42ba-8693-701168a29dde
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# LPTHREAD_START_ROUTINE Function Pointer
Points to a function that notifies the host that a thread has started to execute.  
  
 This function pointer has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
typedef DWORD (__stdcall *LPTHREAD_START_ROUTINE) (  
    [in] LPVOID lpThreadParameter  
);  
```  
  
#### Parameters  
 `lpThreadParameter`  
 [in] A pointer to the code that has started executing.  
  
## Remarks  
 The function to which `LPTHREAD_START_ROUTINE` points is a callback function and must be implemented by the writer of the hosting application.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorWks.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
