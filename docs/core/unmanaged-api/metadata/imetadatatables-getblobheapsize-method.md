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
helpviewer_keywords:
  - "GetBlobHeapSize method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
