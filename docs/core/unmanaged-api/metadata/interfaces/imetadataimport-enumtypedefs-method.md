---
description: "Learn more about: IMetaDataImport::EnumTypeDefs Method"
title: "IMetaDataImport::EnumTypeDefs Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumTypeDefs"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumTypeDefs"
  - "IMetaDataImport::EnumTypeDefs method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumTypeDefs Method

Enumerates TypeDef tokens representing all types within the current scope.

## Syntax

```cpp
HRESULT EnumTypeDefs (
   [out] HCORENUM   *phEnum,
   [in]  mdTypeDef  rTypeDefs[],
   [in]  ULONG      cMax,
   [out] ULONG      *pcTypeDefs
);
```

## Parameters

 `phEnum`
 [out] A pointer to the new enumerator. This must be NULL for the first call of this method.

 `rTypeDefs`
 [in] The array used to store the TypeDef tokens.

 `cMax`
 [in] The maximum size of the `rTypeDefs` array.

 `pcTypeDefs`
 [out] The number of TypeDef tokens returned in `rTypeDefs`.

## Return Value

| HRESULT | Description |
|-------------|-----------------|
| `S_OK` | `EnumTypeDefs` returned successfully. |
| `S_FALSE` | There are no tokens to enumerate. In that case, `pcTypeDefs` is zero. |

## Remarks

 The TypeDef token represents a type such as a class or an interface, as well as any type added via an extensibility mechanism.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
