---
description: "Learn more about: IMetaDataImport::IsGlobal Method"
title: "IMetaDataImport::IsGlobal Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.IsGlobal"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::IsGlobal"
  - "IMetaDataImport::IsGlobal method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::IsGlobal Method

Gets a value indicating whether the field, method, or type represented by the specified metadata token has global scope.

## Syntax

```cpp
HRESULT IsGlobal (
   [in]  mdToken     pd,
   [out] int         *pbGlobal
);
```

## Parameters

 `pd`
 [in] A metadata token that represents a type, field, or method.

 `pbGlobal`
 [out] 1 if the object has global scope; otherwise, 0 (zero).

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
