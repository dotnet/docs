---
title: "IObjectHandle::Unwrap Method"
ms.date: "03/30/2017"
api_name: 
  - "IObjectHandle.Unwrap"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "Unwrap"
helpviewer_keywords: 
  - "Unwrap method [.NET Framework hosting]"
  - "IObjectHandle::Unwrap method [.NET Framework hosting]"
ms.assetid: 794c6f8e-ed58-416b-b756-e864f2c958f7
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# IObjectHandle::Unwrap Method
Unwraps a marshal-by-value object from indirection.  
  
## Syntax  
  
```  
HRESULT Unwrap (  
    [out, retval] VARIANT *ppv  
);  
```  
  
#### Parameters  
 `ppv`  
 [out] A pointer to the object to be unwrapped.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

