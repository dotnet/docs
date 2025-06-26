---
description: "Learn more about: IMetaDataTables::GetNextGuid Method"
title: "IMetaDataTables::GetNextGuid Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetNextGuid"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetNextGuid"
helpviewer_keywords:
  - "GetNextGuid method [.NET Framework metadata]"
  - "IMetaDataTables::GetNextGuid method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetNextGuid Method

Gets the index of the next GUID value in the current table column.

## Syntax

```cpp
HRESULT GetNextGuid (
    [in]  ULONG   ixGuid,
    [out] ULONG   *pNext
);
```

## Parameters

 `ixGuid`
 [in] The index value from a GUID table column.

 `pNext`
 [out] A pointer to the index of the next GUID value.

## Remarks

  We do not recommend the use of this method, because it does not return consistent results. For information about the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics". The documentation is available online; see [ECMA C# and Common Language Infrastructure Standards](../../../fundamentals/standards.md) and [Standard ECMA-335 - Common Language Infrastructure (CLI)](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/).

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
