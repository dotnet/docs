---
description: "Learn more about: IMetaDataTables::GetTableIndex Method"
title: "IMetaDataTables::GetTableIndex Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetTableIndex"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetTableIndex"
  - "IMetaDataTables::GetTableIndex method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataTables::GetTableIndex Method

Gets the index for the table referenced by the specified token.

## Syntax

```cpp
HRESULT GetTableIndex (
    [in]  ULONG   token,
    [out] ULONG   *pixTbl
);
```

## Parameters

 `token`
 [in] The token that references the table.

 `pixTbl`
 [out] A pointer to the returned index for the referenced table.

## Remarks

 We do not recommend the use of this method, because it does not return consistent results. For information about the GUID table, see the Common Language Infrastructure (CLI) documentation, especially "Partition II: Metadata Definition and Semantics". The documentation is available online; see [ECMA C# and Common Language Infrastructure Standards](../../../../fundamentals/standards.md) and [Standard ECMA-335 - Common Language Infrastructure (CLI)](https://www.ecma-international.org/publications-and-standards/standards/ecma-335/).

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
