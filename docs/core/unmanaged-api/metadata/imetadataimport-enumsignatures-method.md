---
description: "Learn more about: IMetaDataImport::EnumSignatures Method"
title: "IMetaDataImport::EnumSignatures Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumSignatures"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumSignatures"
helpviewer_keywords: 
  - "EnumSignatures method [.NET Framework metadata]"
  - "IMetaDataImport::EnumSignatures method [.NET Framework metadata]"
ms.assetid: d0d65060-6f90-42a2-95cf-6ffb04352996
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumSignatures Method

Enumerates Signature tokens representing stand-alone signatures in the current scope.  
  
## Syntax  
  
```cpp  
HRESULT EnumSignatures (  
   [in, out] HCORENUM     *phEnum,  
   [out]     mdSignature  rSignatures[],  
   [in]      ULONG        cMax,  
   [out]     ULONG        *pcSignatures  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `rSignatures`  
 [out] The array used to store the Signature tokens.  
  
 `cMax`  
 [in] The maximum size of the `rSignatures` array.  
  
 `pcSignatures`  
 [out] The number of Signature tokens returned in `rSignatures`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumSignatures` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcSignatures` is zero.|  
  
## Remarks  

 The Signature tokens are created by the [IMetaDataEmit::GetTokenFromSig](imetadataemit-gettokenfromsig-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
