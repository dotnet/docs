---
title: "IMetaDataImport::GetScopeProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetScopeProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetScopeProps"
helpviewer_keywords: 
  - "IMetaDataImport::GetScopeProps method [.NET Framework metadata]"
  - "GetScopeProps method [.NET Framework metadata]"
ms.assetid: c8ba42d2-d9fa-43cb-bbc0-f33e1e592cb6
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataImport::GetScopeProps Method
Gets the name and optionally the version identifier of the assembly or module in the current metadata scope.  
  
## Syntax  
  
```  
HRESULT GetScopeProps (  
   [out] LPWSTR           szName,  
   [in]  ULONG            cchName,  
   [out] ULONG            *pchName,  
   [out, optional] GUID   *pmvid  
);  
```  
  
#### Parameters  
 `szName`  
 [out] A buffer for the assembly or module name.  
  
 `cchName`  
 [in] The size in wide characters of `szName`.  
  
 `pchName`  
 [out] The number of wide characters returned in `szName`.  
  
 `pmvid`  
 [out, optional] A pointer to a GUID that uniquely identifies the version of the assembly or module.  
  
## Remarks  
 The [IMetaDataEmit::SetModuleProps](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-setmoduleprops-method.md) method is used to set these properties.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also
- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
