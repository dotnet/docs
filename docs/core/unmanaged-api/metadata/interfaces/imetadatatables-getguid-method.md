---
description: "Learn more about: IMetaDataTables::GetGuid Method"
title: "IMetaDataTables::GetGuid Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetGuid"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetGuid"
  - "IMetaDataTables::GetGuid method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetGuid Method

Gets a GUID from the row at the specified index.

## Syntax

```cpp
HRESULT GetGuid (
    [in]  ULONG       ixGuid,
    [out] const GUID  **ppGUID
);
```

## Parameters

 `ixGuid`
 [in] The index of the row from which to get the GUID.

 `ppGuid`
 [out] A pointer to a pointer to the GUID.

## Remarks

  We do not recommend the use of this method, because it does not return consistent results. For information about the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics". The documentation is available online; see [ECMA C# and Common Language Infrastructure Standards](../../../../fundamentals/standards.md) and [Standard ECMA-335 - Common Language Infrastructure (CLI)](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/).

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
