---
description: "Learn more about: IMetaDataTables::GetBlob Method"
title: "IMetaDataTables::GetBlob Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetBlob"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetBlob"
helpviewer_keywords: 
  - "GetBlob method [.NET Framework metadata]"
  - "IMetaDataTables::GetBlob method [.NET Framework metadata]"
ms.assetid: 94667c1c-6d58-4aa7-b74e-530b11e2a276
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetBlob Method

Gets a pointer to the binary large object (BLOB) at the specified column index.  
  
## Syntax  
  
```cpp  
HRESULT GetBlob (  
    [in]  ULONG          ixBlob,  
    [out] ULONG          *pcbData,  
    [out] const void     **ppData  
);  
```  
  
## Parameters  

 `ixBlob`  
 [in] The memory address from which to get `ppData`.  
  
 `pcbData`  
 [out] A pointer to the size, in bytes, of `ppData`.  
  
 `ppData`  
 [out] A pointer to a pointer to the binary data retrieved.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
