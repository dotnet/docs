---
description: "Learn more about: CreateAssemblyNameObject Function"
title: "CreateAssemblyNameObject Function"
ms.date: "03/30/2017"
api_name: 
  - "CreateAssemblyNameObject"
api_location: 
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateAssemblyNameObject"
helpviewer_keywords: 
  - "CreateAssemblyNameObject function [.NET Framework fusion]"
ms.assetid: 55c8b41e-fbe4-4ae0-aa29-68fbb2311691
topic_type: 
  - "apiref"
---
# CreateAssemblyNameObject Function

Gets an interface pointer to an [IAssemblyName](iassemblyname-interface.md) instance that represents the unique identity of the assembly with the specified name.  
  
## Syntax  
  
```cpp  
HRESULT CreateAssemblyNameObject (  
    [out] LPASSEMBLYNAME  *ppAssemblyNameObj,  
    [in]  LPCWSTR         szAssemblyName,  
    [in]  DWORD           dwFlags,  
    [in]  LPVOID          pvReserved  
 );  
```  
  
## Parameters  

 `ppAssemblyNameObj`  
 [out] The returned `IAssemblyName`.  
  
 `szAssemblyName`  
 [in] The name of the assembly for which to create the new `IAssemblyName` instance.  
  
 `dwFlags`  
 [in] Flags to pass to the object constructor.  
  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyName Interface](iassemblyname-interface.md)
- [Fusion Global Static Functions](fusion-global-static-functions.md)
