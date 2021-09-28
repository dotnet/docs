---
description: "Learn more about: CreateAssemblyCache Function"
title: "CreateAssemblyCache Function"
ms.date: "03/30/2017"
api_name: 
  - "CreateAssemblyCache"
api_location: 
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateAssemblyCache"
helpviewer_keywords: 
  - "CreateAssemblyCache function [.NET Framework fusion]"
ms.assetid: 348c7c8c-8578-46ae-97cf-480d6015c3c6
topic_type: 
  - "apiref"
---
# CreateAssemblyCache Function

Gets a pointer to a new [IAssemblyCache](iassemblycache-interface.md) instance that represents the global assembly cache.  
  
## Syntax  
  
```cpp  
HRESULT CreateAssemblyCache (  
    [out] IAssemblyCache  **ppAsmCache,  
    [in]  DWORD           dwReserved  
 );  
```  
  
## Parameters  

 `ppAsmCache`  
 [out] The returned `IAssemblyCache` pointer.  
  
 `dwReserved`  
 [in] Reserved for future extensibility. `dwReserved` must be 0 (zero).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyCache Interface](iassemblycache-interface.md)
- [Fusion Global Static Functions](fusion-global-static-functions.md)
- [Global Assembly Cache](../../app-domains/gac.md)
