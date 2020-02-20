---
title: "IMetaDataTables::GetColumnInfo Method"
ms.date: "10/10/2019"
api_name: 
  - "IMetaDataTables.GetColumnInfo"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetColumnInfo"
helpviewer_keywords: 
  - "IMetaDataTables::GetColumnInfo method [.NET Framework metadata]"
  - "GetColumnInfo method [.NET Framework metadata]"
ms.assetid: 68c160ea-ae7d-4750-985d-a038b2c8e7d9
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetColumnInfo Method
Gets data about the specified column in the specified table.  
  
## Syntax  
  
```cpp  
HRESULT GetColumnInfo (   
    [in]  ULONG        ixTbl,  
    [in]  ULONG        ixCol,  
    [out] ULONG        *poCol,  
    [out] ULONG        *pcbCol,  
    [out] ULONG        *pType,  
    [out] const char   **ppName  
);  
```  
  
## Parameters
=======

 `ixTbl`  
 [in] The index of the desired table.  
  
 `ixCol`  
 [in] The index of the desired column.  
  
 `poCol`  
 [out] A pointer to the offset of the column in the row.  
  
 `pcbCol`  
 [out] A pointer to the size, in bytes, of the column.  
  
 `pType`  
 [out] A pointer to the type of the values in the column.  
  
 `ppName`  
 [out] A pointer to a pointer to the column name.  
 
## Remarks

The returned column type falls within a range of values:

| pType                    | Description   | Helper function                   |
|--------------------------|---------------|-----------------------------------|
| `0`..`iRidMax`<br>(0..63)   | Rid           | **IsRidType**<br>**IsRidOrToken** |
| `iCodedToken`..`iCodedTokenMax`<br>(64..95) | Coded token | **IsCodedTokenType** <br>**IsRidOrToken** |
| `iSHORT` (96)            | Int16         | **IsFixedType**                   |
| `iUSHORT` (97)           | UInt16        | **IsFixedType**                   |
| `iLONG` (98)             | Int32         | **IsFixedType**                   |
| `iULONG` (99)            | UInt32        | **IsFixedType**                   |
| `iBYTE` (100)            | Byte          | **IsFixedType**                   |
| `iSTRING` (101)          | String        | **IsHeapType**                    |
| `iGUID` (102)            | Guid          | **IsHeapType**                    |
| `iBLOB` (103)            | Blob          | **IsHeapType**                    |

Values that are stored in the *heap* (that is, `IsHeapType == true`) can be read using:

- `iSTRING`: **IMetadataTables.GetString**
- `iGUID`: **IMetadataTables.GetGUID**
- `iBLOB`: **IMetadataTables.GetBlob**

> [!IMPORTANT]
> To use the constants defined in the table above, include the directive `#define _DEFINE_META_DATA_META_CONSTANTS` provided by the *cor.h* header file.

## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)
- [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
