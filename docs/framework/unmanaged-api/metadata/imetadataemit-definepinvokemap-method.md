---
title: "IMetaDataEmit::DefinePinvokeMap Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DefinePinvokeMap"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefinePinvokeMap"
helpviewer_keywords: 
  - "DefinePinvokeMap method [.NET Framework metadata]"
  - "IMetaDataEmit::DefinePinvokeMap method [.NET Framework metadata]"
ms.assetid: 03abf921-5154-4070-88fa-10b7092901fb
topic_type: 
  - "apiref"
---
# IMetaDataEmit::DefinePinvokeMap Method
Sets features of the PInvoke signature of the method referenced by the specified token.  
  
## Syntax  
  
```cpp  
HRESULT DefinePinvokeMap (   
    [in]  mdToken            tk,   
    [in]  DWORD              dwMappingFlags,   
    [in]  LPCWSTR            szImportName,   
    [in]  mdModuleRef        mrImportDLL   
);  
```  
  
## Parameters  
 `tk`  
 [in] The token for the target method.  
  
 `dwMappingFlags`  
 [in] Flags used by PInvoke to do the mapping.  
  
 `szImportName`  
 [in] The name of the target export method in an unmanaged DLL.  
  
 `mrImportDLL`  
 [in] The token for the target native DLL.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
