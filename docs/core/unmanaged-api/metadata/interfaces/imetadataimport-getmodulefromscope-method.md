---
description: "Learn more about: IMetaDataImport::GetModuleFromScope Method"
title: "IMetaDataImport::GetModuleFromScope Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetModuleFromScope"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetModuleFromScope"
  - "IMetaDataImport::GetModuleFromScope method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetModuleFromScope Method

Gets a metadata token for the module referenced in the current metadata scope.

## Syntax

```cpp
HRESULT GetModuleFromScope (
   [out] mdModule    *pmd
);
```

## Parameters

 `pmd`
 [out] A pointer to the token representing the module referenced in the current metadata scope.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
