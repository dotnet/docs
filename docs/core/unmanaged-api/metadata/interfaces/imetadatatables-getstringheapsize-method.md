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
  - "GetStringHeapSize method [.NET metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
