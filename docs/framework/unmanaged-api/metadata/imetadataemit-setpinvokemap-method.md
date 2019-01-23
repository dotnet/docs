---
title: "IMetaDataEmit::SetPinvokeMap Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetPinvokeMap"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetPinvokeMap"
helpviewer_keywords: 
  - "IMetaDataEmit::SetPinvokeMap method [.NET Framework metadata]"
  - "SetPinvokeMap method [.NET Framework metadata]"
ms.assetid: c6bfd574-1da3-4ba7-82f2-46ca5efcbaba
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataEmit::SetPinvokeMap Method
Sets or changes features of a method's PInvoke signature, as defined by a prior call to [IMetaDataEmit::DefinePinvokeMap](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-definepinvokemap-method.md).  
  
## Syntax  
  
```  
HRESULT SetPinvokeMap (   
    [in]  mdToken      tk,   
    [in]  DWORD        dwMappingFlags,  
    [in]  LPCWSTR      szImportName,   
    [in]  mdModuleRef  mrImportDLL   
);  
```  
  
#### Parameters  
 `tk`  
 [in] The `mdToken` to which mapping information applies.  
  
 `dwMappingFlags`  
 [in] Flags used by PInvoke to do the mapping. This is a bitmask of `CorPinvokeMap` values.  
  
 `szImportName`  
 [in] The name of the target export in the native DLL.  
  
 `mrImportDLL`  
 [in] The `mdModuleRef` token for the target unmanaged DLL.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
