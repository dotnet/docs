---
title: "IHostSecurityManager::OpenThreadToken Method"
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
  - "IHostSecurityManager.OpenThreadToken"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostSecurityManager::OpenThreadToken"
helpviewer_keywords: 
  - "IHostSecurityManager::OpenThreadToken method [.NET Framework hosting]"
  - "OpenThreadToken method [.NET Framework hosting]"
ms.assetid: d5999052-8bf0-4a9e-8621-da6284406b18
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IHostSecurityManager::OpenThreadToken Method
Opens the discretionary access token associated with the currently executing thread.  
  
## Syntax  
  
```  
HRESULT OpenThreadToken (  
    [in]  DWORD    dwDesiredAccess,   
    [in]  BOOL     bOpenAsSelf,   
    [out] HANDLE   *phThreadToken  
);  
```  
  
#### Parameters  
 `dwDesiredAccess`  
 [in] A mask of access values that specify the requested types of access to the thread token. These values are defined in the Win32 `OpenThreadToken` function. The requested access types are reconciled against the token's discretionary access control list (DACL) to determine which types of access to grant or deny.  
  
 `bOpenAsSelf`  
 [in] `true` to specify that the access check should be made using the security context of the process for the calling thread; `false` to specify that the access check should be performed using the security context for the calling thread itself. If the thread is impersonating a client, the security context can be that of a client process.  
  
 `phThreadToken`  
 [out] A pointer to the newly opened access token.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`OpenThreadToken` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 `IHostSecurityManager::OpenThreadToken` behaves similarly to the corresponding Win32 function of the same name, except that the Win32 function allows the caller to pass in a handle to an arbitrary thread, while `IHostSecurityManager::OpenThreadToken` opens only the token associated with the calling thread.  
  
 The `HANDLE` type is not COM-compliant, that is, its size is specific to the operating system, and it requires custom marshaling. Thus, this token is for use only within the process, between the CLR and the host.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IHostSecurityContext Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritycontext-interface.md)  
 [IHostSecurityManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostsecuritymanager-interface.md)
