---
description: "Learn more about: IMetaDataTables::GetNextBlob Method"
title: "IMetaDataTables::GetNextBlob Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetNextBlob"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetNextBlob"
helpviewer_keywords:
  - "IMetaDataTables::GetNextBlob method [.NET Framework metadata]"
  - "GetNextBlob method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetNextBlob Method

Gets the index of the next binary large object (BLOB) in the table.

## Syntax

```cpp
HRESULT GetNextBlob (
    [in]  ULONG   ixBlob,
    [out] ULONG   *pNext
);
```

## Parameters

 `ixBlob`
 [in] The index, as returned from a column of BLOBs.

 `pNext`
 [out] A pointer to the index of the next BLOB.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
