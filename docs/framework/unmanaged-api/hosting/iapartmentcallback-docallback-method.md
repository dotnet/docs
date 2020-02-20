---
title: "IApartmentCallback::DoCallback Method"
ms.date: "03/30/2017"
api_name: 
  - "IApartmentCallback.DoCallback"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "DoCallback"
helpviewer_keywords: 
  - "IApartmentCallback::DoCallback method [.NET Framework hosting]"
  - "DoCallback method [.NET Framework hosting]"
ms.assetid: 8edad30c-30ff-4bee-813c-75525a82fc93
topic_type: 
  - "apiref"
---
# IApartmentCallback::DoCallback Method
Executes the specified function within an apartment.  
  
## Syntax  
  
```cpp  
HRESULT _stdcall DoCallback(  
    [in] SIZE_T pFunc,  
    [in] SIZE_T pData  
);  
```  
  
## Parameters  
 `pFunc`  
 [in] A pointer to the function to be executed within the apartment.  
  
 `pData`  
 [in] A pointer to the function's argument.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IApartmentCallback Interface](../../../../docs/framework/unmanaged-api/hosting/iapartmentcallback-interface.md)
