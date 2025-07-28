---
description: "Learn more about: IMetaDataAssemblyImport::CloseEnum Method"
title: "IMetaDataAssemblyImport::CloseEnum Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyImport.CloseEnum"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyImport::CloseEnum"
  - "IMetaDataAssemblyImport::CloseEnum method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyImport::CloseEnum Method

Releases a reference to the specified enumeration instance.

## Syntax

```cpp
void CloseEnum (
    [in] HCORENUM     hEnum
);
```

## Parameters

 `hEnum`
 [in] The enumeration instance to be closed.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
