---
description: "Learn more about: IMetaDataImport::EnumUserStrings Method"
title: "IMetaDataImport::EnumUserStrings Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.EnumUserStrings"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumUserStrings"
helpviewer_keywords: 
  - "IMetaDataImport::EnumUserStrings method [.NET Framework metadata]"
  - "EnumUserStrings method [.NET Framework metadata]"
ms.assetid: 2b1f1418-4be8-4cdb-b418-b3abccc527a7
topic_type: 
  - "apiref"
---
# IMetaDataImport::EnumUserStrings Method

Enumerates String tokens representing hard-coded strings in the current metadata scope.  
  
## Syntax  
  
```cpp  
HRESULT EnumUserStrings (  
   [in, out]  HCORENUM    *phEnum,  
   [out]  mdString        rStrings[],  
   [in]   ULONG           cMax,  
   [out]  ULONG           *pcStrings  
);  
```  
  
## Parameters  

 `phEnum`  
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.  
  
 `rStrings`  
 [out] The array used to store the String tokens.  
  
 `cMax`  
 [in] The maximum size of the `rStrings` array.  
  
 `pcStrings`  
 [out] The number of String tokens returned in `rStrings`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumUserStrings` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcStrings` is zero.|  
  
## Remarks  

 The String tokens are created by the [IMetaDataEmit::DefineUserString](imetadataemit-defineuserstring-method.md) method. This method is designed to be used by a metadata browser rather than by a compiler.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
