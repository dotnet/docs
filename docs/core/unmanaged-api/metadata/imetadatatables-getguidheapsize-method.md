---
description: "Learn more about: IMetaDataTables::GetGuidHeapSize Method"
title: "IMetaDataTables::GetGuidHeapSize Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetGuidHeapSize"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetGuidHeapSize"
helpviewer_keywords:
  - "GetGuidHeapSize method [.NET Framework metadata]"
  - "IMetaDataTables::GetGuidHeapSize method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetGuidHeapSize Method

Gets the size, in bytes, of the GUID heap.

## Syntax

```cpp
HRESULT GetGuidHeapSize (
    [out] ULONG   *pcbGuids
);
```

## Parameters

 `pcbGuids`
 [out] A pointer to the size, in bytes, of the GUID heap.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
