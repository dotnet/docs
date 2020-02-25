---
title: "IMetaDataEmit::SetPermissionSetProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataEmit.SetPermissionSetProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::SetPermissionSetProps"
helpviewer_keywords: 
  - "SetPermissionSetProps method [.NET Framework metadata]"
  - "IMetaDataEmit::SetPermissionSetProps method [.NET Framework metadata]"
ms.assetid: 8eaee971-40bf-45e2-a3d8-6e57674213b6
topic_type: 
  - "apiref"
---
# IMetaDataEmit::SetPermissionSetProps Method
Sets or updates features of the metadata signature of a permission set defined by a prior call to [IMetaDataEmit::DefinePermissionSet](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-definepermissionset-method.md).  
  
## Syntax  
  
```cpp  
HRESULT SetPermissionSetProps (   
    [in]  mdToken         tk,   
    [in]  DWORD           dwAction,   
    [in]  void const      *pvPermission,   
    [in]  ULONG           cbPermission,   
    [out] mdPermission    *ppm   
);  
```  
  
## Parameters  
 `tk`  
 [in] A metadata token that represents the object to be decorated.  
  
 `dwAction`  
 [in] A [CorDeclSecurity](../../../../docs/framework/unmanaged-api/metadata/cordeclsecurity-enumeration.md) value that specifies the type of declarative security to be used.  
  
 `pvPermission`  
 [in] The permission BLOB.  
  
 `cbPermission`  
 [in] The size, in bytes, of `pvPermission`.  
  
 `ppm`  
 [out] An `mdPermission` metadata token that represents the updated permissions.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
