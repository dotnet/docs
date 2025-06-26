---
description: "Learn more about: IMetaDataTables::GetNextString Method"
title: "IMetaDataTables::GetNextString Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetNextString"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetNextString"
helpviewer_keywords: 
  - "IMetaDataTables::GetNextString method [.NET Framework metadata]"
  - "GetNextString method [.NET Framework metadata]"
ms.assetid: d9720428-c353-4f07-a7e8-899e106a1b37
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetNextString Method

Gets the index of the next string in the current table column.  
  
## Syntax  
  
```cpp  
HRESULT GetNextString (
    [in]  ULONG   ixString,  
    [out] ULONG   *pNext  
);  
```  
  
## Parameters  

 `ixString`  
 [in] The index value from a string table column.  
  
 `pNext`  
 [out] A pointer to the index of the next string in the column.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
