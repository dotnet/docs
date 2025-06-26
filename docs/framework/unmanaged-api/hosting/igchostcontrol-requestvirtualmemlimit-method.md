---
description: "Learn more about: IGCHostControl::RequestVirtualMemLimit Method"
title: "IGCHostControl::RequestVirtualMemLimit Method"
ms.date: "03/30/2017"
api_name: 
  - "IGCHostControl.RequestVirtualMemLimit"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "RequestVirtualMemLimit"
helpviewer_keywords: 
  - "IGCHostControl::RequestVirtualMemLimit method [.NET Framework hosting]"
  - "RequestVirtualMemLimit method [.NET Framework hosting]"
ms.assetid: f4984a8c-4c0e-4460-9aa1-d022b3621228
topic_type: 
  - "apiref"
---
# IGCHostControl::RequestVirtualMemLimit Method

Requests the host to change the limits of virtual memory.  
  
## Syntax  
  
```cpp  
HRESULT RequestVirtualMemLimit (  
    [in] SIZE_T       sztMaxVirtualMemMB,  
    [in, out] SIZE_T* psztNewMaxVirtualMemMB  
);  
```  
  
## Parameters  

 `sztMaxVirtualMemMB`  
 [in] The requested size of memory to be allocated.  
  
 `psztNewMaxVirtualMemMB`  
 [in, out] A pointer to the actual size of memory allocated.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IGCHostControl Interface](igchostcontrol-interface.md)
