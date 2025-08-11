---
description: "Learn more about: IMetaDataTables2::GetMetaDataStreamInfo Method"
title: "IMetaDataTables2::GetMetaDataStreamInfo Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables2.GetMetaDataStreamInfo"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables2::GetMetaDataStreamInfo"
  - "IMetaDataTables2::GetMetaDataStreamInfo method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables2::GetMetaDataStreamInfo Method

Gets the name, size, and contents of the metadata stream at the specified index.

## Syntax

```cpp
HRESULT GetMetaDataStreamInfo (
   [in]  ULONG        ix,
   [out] const char   **ppchName,
   [out] const void   **ppv,
   [out] ULONG        *pcb
);
```

## Parameters

 `ix`
 [in] The index of the requested metadata stream.

 `ppchName`
 [out] A pointer to the name of the stream.

 `ppv`
 [out] A pointer to the metadata stream.

 `pcb`
 [out] The size, in bytes, of `ppv`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
- [IMetaDataTables Interface](imetadatatables-interface.md)
