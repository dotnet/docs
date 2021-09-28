---
description: "Learn more about: IMetaDataImport::EnumModuleRefs Method"
title: "IMetaDataImport::EnumModuleRefs Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumModuleRefs"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumModuleRefs"
helpviewer_keywords: 
  - "EnumModuleRefs method [.NET Framework metadata]"
  - "IMetaDataImport::EnumModuleRefs method [.NET Framework metadata]"
ms.assetid: 53441f3a-68d2-477c-906e-37c55dfcfb4d
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumModuleRefs Method

Enumerates ModuleRef tokens that represent imported modules.  
  
## Syntax  
  
```cpp  
HRESULT EnumModuleRefs (  
   [in, out] HCORENUM     *phEnum,  
   [out]     mdModuleRef  rModuleRefs[],  
   [in]      ULONG        cMax,  
   [out]     ULONG        *pcModuleRefs  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `rModuleRefs`  
 [out] The array used to store the ModuleRef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rModuleRefs` array.  
  
 `pcModuleRefs`  
 [out] The number of ModuleRef tokens returned in `rModuleRefs`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumModuleRefs` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcModuleRefs` is zero.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
