---
description: "Learn more about: IMetaDataEmit::DefineTypeRefByName Method"
title: "IMetaDataEmit::DefineTypeRefByName Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DefineTypeRefByName"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineTypeRefByName"
helpviewer_keywords: 
  - "DefineTypeRefByName method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineTypeRefByName method [.NET Framework metadata]"
ms.assetid: c30a4ce3-2d3e-411a-98df-e62ac4a5dd50
topic_type: 
  - "apiref"
---
# IMetaDataEmit::DefineTypeRefByName Method

Gets a metadata token for a type that is defined in the specified scope, which is outside the current scope.  
  
## Syntax  
  
```cpp  
HRESULT DefineTypeRefByName (
    [in]  mdToken     tkResolutionScope,
    [in]  LPCWSTR     szName,
    [out] mdTypeRef   *ptr
);  
```  
  
## Parameters  

 `tkResolutionScope`  
 [in] The token specifying the resolution scope. The following token types are valid:  
  
- `mdModuleRef`, if the type is defined in the same assembly in which the caller is defined.  
  
- `mdAssemblyRef`, if the type is defined in an assembly other than the one in which the caller is defined.  
  
- `mdTypeRef`, if the type is a nested type.  
  
- `mdModule`, if the type is defined in the same module in which the caller is defined.  
  
- Null, if the type is defined globally.  
  
 `szName`  
 [in] The name of the target type in Unicode.  
  
 `ptr`  
 [out] A pointer to the `mdTypeRef` token that is assigned to the type.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
