---
description: "Learn more about: IMetaDataTables2::GetMetaDataStorage Method"
title: "IMetaDataTables2::GetMetaDataStorage Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables2.GetMetaDataStorage"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables2::GetMetaDataStorage"
  - "IMetaDataTables2::GetMetaDataStorage method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables2::GetMetaDataStorage Method

Gets the size and contents of the metadata stored in the specified section.

## Syntax

```cpp
HRESULT GetMetaDataStorage (
   [in, out] const void   **ppvMd,
   [out] ULONG   *pcbMd
);
```

## Parameters

 `ppvMd`
 [in, out] A pointer to a metadata section.

 `pcbMd`
 [out] The size of the metadata stream.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
- [IMetaDataTables Interface](imetadatatables-interface.md)
