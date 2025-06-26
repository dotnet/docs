---
description: "Learn more about: IMetaDataTables::GetTableInfo Method"
title: "IMetaDataTables::GetTableInfo Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataTables.GetTableInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetTableInfo"
helpviewer_keywords: 
  - "IMetaDataTables::GetTableInfo method [.NET Framework metadata]"
  - "GetTableInfo method [.NET Framework metadata]"
ms.assetid: 50cbe557-2322-41aa-8e0d-f967602eaa0f
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetTableInfo Method

Gets the name, row size, number of rows, number of columns, and key column index of the specified table.  
  
## Syntax  
  
```cpp  
HRESULT GetTableInfo (  
    [in]  ULONG       ixTbl,  
    [out] ULONG       *pcbRow,  
    [out] ULONG       *pcRows,  
    [out] ULONG       *pcCols,  
    [out] ULONG       *piKey,  
    [out] const char  **ppName  
);  
```  
  
## Parameters  

 `ixTbl`  
 [in] The identifier of the table whose properties to return.  
  
 `pcbRow`  
 [out] A pointer to the size, in bytes, of a table row.  
  
 `pcRows`  
 [out] A pointer to the number of rows in the table.  
  
 `pcCols`  
 [out] A pointer to the number of columns in the table.  
  
 `piKey`  
 [out] A pointer to the index of the key column, or -1 if the table has no key column.  
  
 `ppName`  
 [out] A pointer to a pointer to the table name.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
