---
title: "IMetaDataImport::GetPermissionSetProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetPermissionSetProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetPermissionSetProps"
helpviewer_keywords: 
  - "GetPermissionSetProps method [.NET Framework metadata]"
  - "IMetaDataImport::GetPermissionSetProps method [.NET Framework metadata]"
ms.assetid: 9855f0e4-12c0-4d3d-ab5d-d6bc52d25eae
topic_type: 
  - "apiref"
---
# IMetaDataImport::GetPermissionSetProps Method
Gets the metadata associated with the <xref:System.Security.PermissionSet?displayProperty=nameWithType> represented by the specified Permission token.  
  
## Syntax  
  
```cpp  
HRESULT GetPermissionSetProps (  
   [in]  mdPermission      pm,  
   [out] DWORD             *pdwAction,   
   [out] void const        **ppvPermission,   
   [out] ULONG             *pcbPermission  
);  
```  
  
## Parameters  
 `pm`  
 [in] The Permission metadata token that represents the permission set to get the metadata properties for.  
  
 `pdwAction`  
 [out] A pointer to the permission set.  
  
 `ppvPermission`  
 [out] A pointer to the binary metadata signature of the permission set.  
  
 `pcbPermission`  
 [out] The size in bytes of `ppvPermission`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- <xref:System.Security.PermissionSet>
- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
