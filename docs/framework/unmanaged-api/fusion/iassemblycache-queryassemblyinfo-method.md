---
description: "Learn more about: IAssemblyCache::QueryAssemblyInfo Method"
title: "IAssemblyCache::QueryAssemblyInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "IAssemblyCache.QueryAssemblyInfo"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IAssemblyCache::QueryAssemblyInfo"
helpviewer_keywords: 
  - "IAssemblyCache::QueryAssemblyInfo method [.NET Framework fusion]"
  - "QueryAssemblyInfo method [.NET Framework fusion]"
ms.assetid: 09313cb5-06f6-43bd-94f4-1055c6b0c99a
topic_type: 
  - "apiref"
---
# IAssemblyCache::QueryAssemblyInfo Method

Gets the requested data about the specified assembly.  
  
## Syntax  
  
```cpp  
HRESULT QueryAssemblyInfo (  
    [in] DWORD dwFlags,  
    [in] LPCWSTR pszAssemblyName,  
    [in, out] ASSEMBLY_INFO *pAsmInfo  
);  
```  
  
## Parameters  

 `dwFlags`  
 [in] Flags defined in Fusion.idl. The following values are supported:  
  
- QUERYASMINFO_FLAG_VALIDATE (0x00000001)  
  
- QUERYASMINFO_FLAG_GETSIZE (0x00000002)  
  
 `pszAssemblyName`  
 [in] The name of the assembly for which data will be retrieved.  
  
 `pAsmInfo`  
 [in, out] An [ASSEMBLY_INFO](assembly-info-structure.md) structure that contains data about the assembly.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyCache Interface](iassemblycache-interface.md)
