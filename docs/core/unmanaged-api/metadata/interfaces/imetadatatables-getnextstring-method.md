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
  - "GetNextString method [.NET metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
