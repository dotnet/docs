---
description: "Learn more about: IMetaDataTables::GetStringHeapSize Method"
title: "IMetaDataTables::GetStringHeapSize Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetStringHeapSize"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetStringHeapSize"
  - "GetStringHeapSize method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetStringHeapSize Method

Gets the size, in bytes, of the string heap.

## Syntax

```cpp
HRESULT GetStringHeapSize (
    [out] ULONG   *pcbStrings
);
```

## Parameters

 `pcbStrings`
 [out] A pointer to the size, in bytes, of the string heap.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
