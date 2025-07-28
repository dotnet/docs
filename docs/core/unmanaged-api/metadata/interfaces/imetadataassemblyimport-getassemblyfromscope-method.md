---
description: "Learn more about: IMetaDataAssemblyImport::GetAssemblyFromScope Method"
title: "IMetaDataAssemblyImport::GetAssemblyFromScope Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyImport.GetAssemblyFromScope"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyImport::GetAssemblyFromScope"
  - "GetAssemblyFromScope method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyImport::GetAssemblyFromScope Method

Gets a pointer to the assembly in the current scope.

## Syntax

```cpp
HRESULT GetAssemblyFromScope (
    [out] mdAssembly  *ptkAssembly
);
```

## Parameters

 `ptkAssembly`
 [out] A pointer to the retrieved `mdAssembly` token that identifies the assembly.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
