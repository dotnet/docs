---
title: "ICLRProbingAssemblyEnum::Get Method"
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
  - "ICLRProbingAssemblyEnum.Get"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRProbingAssemblyEnum::Get"
helpviewer_keywords: 
  - "Get method, ICLRProbingAssemblyEnum interface [.NET Framework hosting]"
  - "ICLRProbingAssemblyEnum::Get method [.NET Framework hosting]"
ms.assetid: fdb67a77-782f-44cf-a8a1-b75999b0f3c8
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRProbingAssemblyEnum::Get Method
Gets the assembly identity at the specified index.  
  
## Syntax  
  
```  
HRESULT Get (  
    [in] DWORD dwIndex,  
    [out, size_is(*pcchBufferSize)] LPWSTR pwzBuffer,  
    [in, out] DWORD *pcchBufferSize  
);  
```  
  
#### Parameters  
 `dwIndex`  
 [in] The zero-based index of the assembly identity to return.  
  
 `pwzBuffer`  
 [out] A buffer containing the assembly identity data.  
  
 `pcchBufferSize`  
 [in, out] The size of the `pwzBuffer` buffer.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Get` returned successfully.|  
|ERROR_INSUFFICIENT_BUFFER|`pwzBuffer` is too small.|  
|ERROR_NO_MORE_ITEMS|The enumeration contains no more items.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to any hosting methods return HOST_E_CLRNOTAVAILABLE.|  
  
## Remarks  
 The identity at index 0 is the identity specific to the processor architecture. The identity at index 1 is the architecture-neutral assembly for Microsoft intermediate language (MSIL). The identity at index 2 contains no architecture information.  
  
 `Get` is typically called twice. The first call supplies a null value for `pwzBuffer`, and sets `pcchBufferSize` to the size appropriate for `pwzBuffer`. The second call supplies an appropriately sized `pwzBuffer`, and contains the canonical assembly identity data upon completion.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRProbingAssemblyEnum Interface](../../../../docs/framework/unmanaged-api/hosting/iclrprobingassemblyenum-interface.md)  
 [ICLRAssemblyIdentityManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyidentitymanager-interface.md)
