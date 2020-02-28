---
title: "IMetaDataEmit::DefineMemberRef Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.DefineMemberRef"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefineMemberRef"
helpviewer_keywords: 
  - "DefineMemberRef method [.NET Framework metadata]"
  - "IMetaDataEmit::DefineMemberRef method [.NET Framework metadata]"
ms.assetid: 21b5bcb8-ea75-4962-8acc-ad17584061e5
topic_type: 
  - "apiref"
---
# IMetaDataEmit::DefineMemberRef Method
Defines a reference to a member of a module outside the current scope, and gets a token to that reference definition.  
  
## Syntax  
  
```cpp  
HRESULT DefineMemberRef (   
    [in]  mdToken           tkImport,   
    [in]  LPCWSTR           szName,   
    [in]  PCCOR_SIGNATURE   pvSigBlob,   
    [in]  ULONG             cbSigBlob,   
    [out] mdMemberRef       *pmr   
);  
```  
  
## Parameters  
 `tkImport`  
 [in] Token for the target member's class or interface, if the member is not global; if the member is global, the `mdModuleRef` token for that other file.  
  
 `szName`  
 [in] The name of the target member.  
  
 `pvSigBlob`  
 [in] The signature of the target member.  
  
 `cbSigBlob`  
 [in] The count of bytes in `pvSigBlob`.  
  
 `pmr`  
 [out] The `mdMemberRef` token assigned.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
