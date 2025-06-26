---
description: "Learn more about: IHostMAlloc::Alloc Method"
title: "IHostMAlloc::Alloc Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostMAlloc.Alloc"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMAlloc::Alloc"
helpviewer_keywords: 
  - "Alloc method, IHostMAlloc interface [.NET Framework hosting]"
  - "IHostMAlloc::Alloc method [.NET Framework hosting]"
ms.assetid: a3007f5e-d75d-4b37-842b-704e9edced5e
topic_type: 
  - "apiref"
---
# IHostMAlloc::Alloc Method

Requests that the host allocate the specified amount of memory from the heap.  
  
## Syntax  
  
```cpp  
HRESULT Alloc (  
    [in] SIZE_T  cbSize,
    [in] EMemoryCriticalLevel dwCriticalLevel,
    [out] void** ppMem  
);  
```  
  
## Parameters  

 `cbSize`  
 [in] The size, in bytes, of the current memory allocation request.  
  
 `dwCriticalLevel`  
 [in] One of the [EMemoryCriticalLevel](ememorycriticallevel-enumeration.md) values, indicating the impact of an allocation failure.  
  
 `ppMem`  
 [out] A pointer to the allocated memory, or null if the request could not be completed.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|`Alloc` returned successfully.|  
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|  
|HOST_E_TIMEOUT|The call timed out.|  
|HOST_E_NOT_OWNER|The caller does not own the lock.|  
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|  
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|  
|E_OUTOFMEMORY|Not enough memory was available to complete the allocation request.|  
  
## Remarks  

 The CLR gets an interface pointer to an `IHostMalloc` instance by calling the [IHostMemoryManager::CreateMalloc](ihostmemorymanager-createmalloc-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostMemoryManager Interface](ihostmemorymanager-interface.md)
- [IHostMalloc Interface](ihostmalloc-interface.md)
