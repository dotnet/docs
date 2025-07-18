---
description: "Learn more about: IMetaDataTables::GetNextUserString Method"
title: "IMetaDataTables::GetNextUserString Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetNextUserString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetNextUserString"
helpviewer_keywords:
  - "GetNextUserString method [.NET Framework metadata]"
  - "IMetaDataTables::GetNextUserString method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetNextUserString Method

Gets the index of the row that contains the next hard-coded string in the current table column.

## Syntax

```cpp
HRESULT GetNextUserString (
    [in]  ULONG   ixUserString,
    [out] ULONG   *pNext
);
```

## Parameters

 `ixUserString`
 [in] An index value from the current string column.

 `pNext`
 [out] A pointer to the row index of the next string in the column.

## Remarks

 We do not recommend the use of this method, because it does not return consistent results. For information about the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics". The documentation is available online; see [ECMA C# and Common Language Infrastructure Standards](../../../fundamentals/standards.md) and [Standard ECMA-335 - Common Language Infrastructure (CLI)](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/).

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
