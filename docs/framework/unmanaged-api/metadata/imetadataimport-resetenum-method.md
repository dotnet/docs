---
title: "IMetaDataImport::ResetEnum Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.ResetEnum"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::ResetEnum"
helpviewer_keywords: 
  - "ResetEnum method [.NET Framework metadata]"
  - "IMetaDataImport::ResetEnum method [.NET Framework metadata]"
ms.assetid: dda867b5-1050-49ba-b01c-fcc83b7a5617
topic_type: 
  - "apiref"
---
# IMetaDataImport::ResetEnum Method
Resets the specified enumerator to the specified position.  
  
## Syntax  
  
```cpp  
HRESULT ResetEnum (  
   [in] HCORENUM    hEnum,   
   [in] ULONG       ulPos  
);  
```  
  
## Parameters  
 `hEnum`  
 [in] The enumerator to reset.  
  
 `ulPos`  
 [in] The new position at which to place the enumerator.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
