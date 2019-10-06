---
title: "IMetaDataTables::GetString Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetString"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetString"
helpviewer_keywords: 
  - "IMetaDataTables::GetString method [.NET Framework metadata]"
  - "GetString method, IMetaDataTables interface [.NET Framework metadata]"
ms.assetid: 895c35cf-b95d-4e3b-93b5-cfc1cf9044fc
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# IMetaDataTables::GetString Method
Gets the string at the specified index from the table column in the current reference scope.  
  
## Syntax  
  
```cpp  
HRESULT GetString (   
    [in]  ULONG       ixString,  
    [out] const char  **ppString  
);  
```  
  
## Parameters  
 `ixString`  
 [in] The index at which to start to search for the next value.  
  
 `ppString`  
 [out] A pointer to a pointer to the returned string value.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)
- [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
