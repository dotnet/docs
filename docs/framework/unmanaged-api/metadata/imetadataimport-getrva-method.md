---
title: "IMetaDataImport::GetRVA Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetRVA"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetRVA"
helpviewer_keywords: 
  - "GetRVA method [.NET Framework metadata]"
  - "IMetaDataImport::GetRVA method [.NET Framework metadata]"
ms.assetid: ea422217-988b-4acd-b2db-c55357938275
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataImport::GetRVA Method
Gets the relative virtual address (RVA) and the implementation flags of the method or field represented by the specified token.  
  
## Syntax  
  
```cpp  
HRESULT GetRVA (  
   [in]  mdToken     tk,   
   [out] ULONG       *pulCodeRVA,   
   [out]  DWORD      *pdwImplFlags  
);  
```  
  
## Parameters  
 `tk`  
 [in] A MethodDef or FieldDef metadata token that represents the code object to return the RVA for. If the token is a FieldDef, the field must be a global variable.  
  
 `pulCodeRVA`  
 [out] A pointer to the relative virtual address of the code object represented by the token.  
  
 `pdwImplFlags`  
 [out] A pointer to the implementation flags for the method. This value is a bitmask from the [CorMethodImpl](../../../../docs/framework/unmanaged-api/metadata/cormethodimpl-enumeration.md) enumeration. The value of `pdwImplFlags` is valid only if `tk` is a MethodDef token.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
