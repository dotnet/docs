---
title: "IMetaDataImport::GetFieldMarshal Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetFieldMarshal"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetFieldMarshal"
helpviewer_keywords: 
  - "GetFieldMarshal method [.NET Framework metadata]"
  - "IMetaDataImport::GetFieldMarshal method [.NET Framework metadata]"
ms.assetid: 4e2d88c6-8a3a-4fbe-900b-b4f4c06bf6bf
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataImport::GetFieldMarshal Method
Gets a pointer to the native, unmanaged type of the field represented by the specified field metadata token.  
  
## Syntax  
  
```  
HRESULT GetFieldMarshal (  
   [in]  mdToken             tk,   
   [out] PCCOR_SIGNATURE     *ppvNativeType,  
   [out] ULONG               *pcbNativeType   
);  
```  
  
## Parameters  
 `tk`  
 [in] The metadata token that represents the field to get interop marshaling information for.  
  
 `ppvNativeType`  
 [out] A pointer to the metadata signature of the field's native type.  
  
 `pcbNativeType`  
 [out] The size in bytes of `ppvNativeType`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
