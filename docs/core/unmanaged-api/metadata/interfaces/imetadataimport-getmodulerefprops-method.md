---
description: "Learn more about: IMetaDataImport::GetModuleRefProps Method"
title: "IMetaDataImport::GetModuleRefProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetModuleRefProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetModuleRefProps"
  - "IMetaDataImport::GetModuleRefProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetModuleRefProps Method

Gets the name of the module referenced by the specified metadata token.

## Syntax

```cpp
HRESULT GetModuleRefProps (
   [in]  mdModuleRef         mur,
   [out] LPWSTR              szName,
   [in]  ULONG               cchName,
   [out] ULONG               *pchName
);
```

## Parameters

 `mur`
 [in] The ModuleRef metadata token that references the module to get metadata information for.

 `szName`
 [out] A buffer to hold the module name.

 `cchName`
 [in] The requested size of `szName` in wide characters.

 `pchName`
 [out] The returned size of `szName` in wide characters.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
