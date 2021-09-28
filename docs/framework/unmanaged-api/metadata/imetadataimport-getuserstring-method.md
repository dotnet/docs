---
description: "Learn more about: IMetaDataImport::GetUserString Method"
title: "IMetaDataImport::GetUserString Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetUserString"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetUserString"
helpviewer_keywords: 
  - "IMetaDataImport::GetUserString method [.NET Framework metadata]"
  - "GetUserString method, IMetaDataImport interface [.NET Framework metadata]"
ms.assetid: 0fd3bb47-58b5-4083-b241-b9719df7a285
topic_type: 
  - "apiref"
---
# IMetaDataImport::GetUserString Method

Gets the literal string represented by the specified metadata token.  
  
## Syntax  
  
```cpp  
HRESULT GetUserString (  
   [in]   mdString    stk,  
   [out]  LPWSTR      szString,  
   [in]   ULONG       cchString,  
   [out]  ULONG       *pchString  
);  
```  
  
## Parameters  

 `stk`  
 [in] The String token to return the associated string for.  
  
 `szString`  
 [out] A copy of the requested string.  
  
 `cchString`  
 [in] The maximum size in wide characters of the requested `szString`.  
  
 `pchString`  
 [out] The size in wide characters of the returned `szString`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
