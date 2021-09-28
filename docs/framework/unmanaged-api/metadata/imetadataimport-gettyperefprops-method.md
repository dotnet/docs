---
description: "Learn more about: IMetaDataImport::GetTypeRefProps Method"
title: "IMetaDataImport::GetTypeRefProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetTypeRefProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetTypeRefProps"
helpviewer_keywords: 
  - "IMetaDataImport::GetTypeRefProps method [.NET Framework metadata]"
  - "GetTypeRefProps method [.NET Framework metadata]"
ms.assetid: 01837955-ce1e-4068-b338-fd473bd77d1d
topic_type: 
  - "apiref"
---
# IMetaDataImport::GetTypeRefProps Method

Gets the metadata associated with the <xref:System.Type> referenced by the specified TypeRef token.  
  
## Syntax  
  
```cpp  
HRESULT GetTypeRefProps (  
   [in]  mdTypeRef   tr,  
   [out] mdToken     *ptkResolutionScope,  
   [out] LPWSTR      szName,  
   [in]  ULONG       cchName,  
   [out] ULONG       *pchName  
);  
```  
  
## Parameters  

 `tr`  
 [in] The TypeRef token that represents the type to return metadata for.  
  
 `ptkResolutionScope`  
 [out] A pointer to the scope in which the reference is made. This value is an AssemblyRef or ModuleRef token.  
  
 `szName`  
 [out] A buffer containing the type name.  
  
 `cchName`  
 [in] The requested size in wide characters of `szName`.  
  
 `pchName`  
 [out] The returned size in wide characters of `szName`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
