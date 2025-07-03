---
description: "Learn more about: IMetaDataTables::GetUserStringHeapSize Method"
title: "IMetaDataTables::GetUserStringHeapSize Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetUserStringHeapSize"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetUserStringHeapSize"
helpviewer_keywords:
  - "IMetaDataTables::GetUserStringHeapSize method [.NET Framework metadata]"
  - "GetUserStringHeapSize method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetUserStringHeapSize Method

Gets the size, in bytes, of the user string heap.

## Syntax

```cpp
HRESULT GetUserStringHeapSize (
    [out] ULONG   *pcbBlobs
);
```

## Parameters

 `pcbBlobs`
 [out] A pointer to the size, in bytes, of the user string heap.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
