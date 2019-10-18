---
title: "_CorImageUnloading Function"
ms.date: "03/30/2017"
api_name: 
  - "_CorImageUnloading"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "_CorImageUnloading"
helpviewer_keywords: 
  - "_CorImageUnloading function [.NET Framework hosting]"
ms.assetid: b4367214-6dac-4280-aa11-fd487ff30bc4
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# _CorImageUnloading Function
Notifies the loader when the managed module images are unloaded.  
  
 This function is not implemented. If called, it returns E_NOTIMPL.  
  
## Syntax  
  
```cpp  
STDAPI (VOID) _CorImageUnloading(   
   [in] PVOID* ImageBase  
);  
```  
  
## Parameters  
 `ImageBase`  
 [in] A pointer to the starting location of the image to unload.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Global Static Functions](../../../../docs/framework/unmanaged-api/metadata/metadata-global-static-functions.md)
