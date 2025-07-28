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
  - "IMetaDataTables::GetGuidHeapSize method [.NET metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
