---
title: "IMetaDataTables::GetColumn Method"
ms.date: "02/25/2019"
api_name: 
  - "IMetaDataTables.GetColumn"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataTables::GetColumn"
helpviewer_keywords: 
  - "IMetaDataTables::GetColumn method [.NET Framework metadata]"
  - "GetColumn method [.NET Framework metadata]"
ms.assetid: 1032055b-cabb-45c5-a50e-7e853201b175
topic_type: 
  - "apiref"
---
# IMetaDataTables::GetColumn Method
Gets a pointer to the value contained in the cell of the specified column and row in the given table.  
  
## Syntax  
  
```cpp  
HRESULT GetColumn (   
    [in]  ULONG   ixTbl,  
    [in]  ULONG   ixCol,  
    [in]  ULONG   rid,  
    [out] ULONG   *pVal  
);  
```  
  
## Parameters

 `ixTbl`  
 [in] The index of the table.  
  
 `ixCol`  
 [in] The index of the column in the table.  
  
 `rid`  
 [in] The index of the row in the table.  
  
 `pVal`  
 [out] A pointer to the value in the cell.  
 
## Remarks

The interpretion of the value returned through `pVal` depends on the column's type. The column type can be determined by calling [IMetaDataTables.GetColumnInfo](imetadatatables-getcolumninfo-method.md).

- The **GetColumn** method automatically converts columns of type **Rid** or **CodedToken** to full 32-bit `mdToken` values.
- It also automatically converts 8-bit or 16-bit values to full 32-bit values. 
- For *heap* type columns, the returned *pVal* will be an index into the corresponding heap.

| Column type              | pVal contains | Comment                          |
|--------------------------|---------------|-----------------------------------|
| `0`..`iRidMax`<br>(0..63)  | mdToken     | *pVal* will contain a full Token. The function automatically converts the Rid into a full token. |
| `iCodedToken`..`iCodedTokenMax`<br>(64..95) | mdToken | Upon return, *pVal* will contain a full Token. The function automatically decompresses the CodedToken into a full token. |
| `iSHORT` (96)            | Int16         | Automatically sign-extended to 32-bit.  |
| `iUSHORT` (97)           | UInt16        | Automatically sign-extended to 32-bit.  |
| `iLONG` (98)             | Int32         |                                        | 
| `iULONG` (99)            | UInt32        |                                        |
| `iBYTE` (100)            | Byte          | Automatically sign-extended to 32-bit.  |
| `iSTRING` (101)          | String heap index | *pVal* is an index into the String heap. Use [IMetadataTables::GetString](imetadatatables-getstring-method.md) to get the actual column String value. |
| `iGUID` (102)            | Guid heap index | *pVal* is an index into the Guid heap. Use [IMetadataTables::GetGuid](imetadatatables-getguid-method.md) to get the actual column Guid value. |
| `iBLOB` (103)            | Blob heap index | *pVal* is an index into the Blob heap. Use [IMetadataTables::GetBlob](imetadatatables-getblob-method.md) to get the actual column Blob value. |
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IMetaDataTables Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables-interface.md)
- [IMetaDataTables2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadatatables2-interface.md)
