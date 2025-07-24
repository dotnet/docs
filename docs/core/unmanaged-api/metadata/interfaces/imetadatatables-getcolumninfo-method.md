---
description: "Learn more about: IMetaDataTables::GetColumnInfo Method"
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
  - "GetColumnInfo method [.NET Framework metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
