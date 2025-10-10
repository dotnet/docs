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
  - "GetTableInfo method [.NET metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
