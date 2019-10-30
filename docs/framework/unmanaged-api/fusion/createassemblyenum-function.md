---
title: "CreateAssemblyEnum Function"
ms.date: "03/30/2017"
api_name: 
  - "CreateAssemblyEnum"
api_location: 
  - "fusion.dll"
  - "clr.dll"
  - "mscorwks.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CreateAssemblyEnum"
helpviewer_keywords: 
  - "CreateAssemblyEnum function [.NET Framework fusion]"
ms.assetid: 3506df38-6cea-42f6-946e-4287863bcfb3
topic_type: 
  - "apiref"
---
# CreateAssemblyEnum Function
Gets a pointer to an [IAssemblyEnum](iassemblyenum-interface.md) instance that can enumerate the objects in the assembly with the specified [IAssemblyName](iassemblyname-interface.md).  
  
## Syntax  
  
```cpp  
HRESULT CreateAssemblyEnum (  
    [out] IAssemblyEnum  **pEnum,  
    [in]  IUnknown       *pUnkReserved,  
    [in]  IAssemblyName  *pName,  
    [in]  DWORD          dwFlags,  
    [in]  LPVOID         pvReserved  
 );  
```  
  
## Parameters  
 `pEnum`  
 [out] Pointer to a memory location that contains the requested `IAssemblyEnum` pointer.  
  
 `pUnkReserved`  
 [in] Reserved for future extensibility. `pUnkReserved` must be a null reference.  
  
 `pName`  
 [in] The `IAssemblyName` of the requested assembly. This name is used to filter the enumeration. It can be null to enumerate all assemblies in the global assembly cache.  
  
 `dwFlags`  
 [in] Flags for modifying the enumerator's behavior. This parameter contains exactly one bit from the [ASM_CACHE_FLAGS](asm-cache-flags-enumeration.md) enumeration.  
  
 `pvReserved`  
 [in] Reserved for future extensibility. `pvReserved` must be a null reference.  
  
## Remarks  
 The `dwFlags` parameter contains exactly one bit from the `ASM_CACHE_FLAGS` enumeration.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyEnum Interface](iassemblyenum-interface.md)
- [IAssemblyName Interface](iassemblyname-interface.md)
- [Fusion Global Static Functions](fusion-global-static-functions.md)
