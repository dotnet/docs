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
helpviewer_keywords:
  - "GetNumTables method [.NET Framework metadata]"
  - "IMetaDataTables::GetNumTables method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
