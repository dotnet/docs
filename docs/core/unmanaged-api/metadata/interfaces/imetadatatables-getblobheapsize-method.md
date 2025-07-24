---
description: "Learn more about: IMetaDataTables::GetBlobHeapSize Method"
title: "IMetaDataTables::GetBlobHeapSize Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetBlobHeapSize"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetBlobHeapSize"
  - "IMetaDataTables::GetBlobHeapSize method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetBlobHeapSize Method

Gets the size, in bytes, of the binary large object (BLOB) heap.

## Syntax

```cpp
HRESULT GetBlobHeapSize (
    [out] ULONG     *pcbBlobs
);
```

## Parameters

 `pcbBlobs`
 [out] A pointer to the size, in bytes, of the BLOB heap.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
