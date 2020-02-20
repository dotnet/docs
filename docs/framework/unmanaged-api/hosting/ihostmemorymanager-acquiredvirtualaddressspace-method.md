---
title: "IHostMemoryManager::AcquiredVirtualAddressSpace Method"
ms.date: "03/30/2017"
api_name: 
  - "IHostMemoryManager.AcquiredVirtualAddressSpace"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IHostMemoryManager::AcquiredVirtualAddressSpace"
helpviewer_keywords: 
  - "IHostMemoryManager::AcquiredVirtualAddressSpace method [.NET Framework hosting]"
  - "AcquiredVirtualAddressSpace method [.NET Framework hosting]"
ms.assetid: ef2f83c2-127e-4c38-8385-306c03cd2167
topic_type: 
  - "apiref"
---
# IHostMemoryManager::AcquiredVirtualAddressSpace Method
Notifies the host that the common language runtime (CLR) has acquired the specified memory from the operating system.  
  
## Syntax  
  
```cpp  
HRESULT AcquiredVirtualAddressSpace(  
    [in] LPVOID  startAddress,  
    [in] SIZE_T  size  
);  
```  
  
## Parameters  
 `startAddress`  
 [in] The starting address of the memory.  
  
 `size`  
 [in] The size, in bytes, of the memory.  
  
## Remarks  
 The `AcquiredVirtualAddressSpace` method is a callback method and must be implemented by the writer of the hosting application. It is called by the CLR.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IHostMemoryManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostmemorymanager-interface.md)
