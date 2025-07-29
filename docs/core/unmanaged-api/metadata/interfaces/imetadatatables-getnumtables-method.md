---
description: "Learn more about: IMetaDataTables::GetNumTables Method"
title: "IMetaDataTables::GetNumTables Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetNumTables"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetNumTables"
  - "IMetaDataTables::GetNumTables method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetNumTables Method

Gets the number of tables in the scope of the current `IMetaDataTables` instance.

## Syntax

```cpp
HRESULT GetNumTables (
    [out]  ULONG   *pcTables
);
```

## Parameters

 `pcTables`
 [out] A pointer to the number of tables in the current instance scope.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
