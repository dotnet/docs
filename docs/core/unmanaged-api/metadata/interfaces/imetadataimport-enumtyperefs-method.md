---
description: "Learn more about: IMetaDataImport::EnumTypeRefs Method"
title: "IMetaDataImport::EnumTypeRefs Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumTypeRefs"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumTypeRefs"
  - "IMetaDataImport::EnumTypeRefs method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumTypeRefs Method

Enumerates TypeRef tokens defined in the current metadata scope.

## Syntax

```cpp
HRESULT EnumTypeRefs (
   [in, out] HCORENUM    *phEnum,
   [out] mdTypeRef       rTypeRefs[],
   [in]  ULONG           cMax,
   [out] ULONG           *pcTypeRefs
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.

 `rTypeRefs`
 [out] The array used to store the TypeRef tokens.

 `cMax`
 [in] The maximum size of the `rTypeRefs` array.

 `pcTypeRefs`
 [out] A pointer to the number of TypeRef tokens returned in `rTypeRefs`.

## Return Value

| HRESULT | Description |
|-------------|-----------------|
| `S_OK` | `EnumTypeRefs` returned successfully. |
| `S_FALSE` | There are no tokens to enumerate. In that case, `pcTypeRefs` is zero. |

## Remarks

 A TypeRef token represents a reference to a type.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
