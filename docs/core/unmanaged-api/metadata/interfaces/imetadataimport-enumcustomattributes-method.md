---
description: "Learn more about: IMetaDataImport::EnumCustomAttributes Method"
title: "IMetaDataImport::EnumCustomAttributes Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumCustomAttributes"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumCustomAttributes"
  - "IMetaDataImport::EnumCustomAttributes method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumCustomAttributes Method

Enumerates custom attribute-definition tokens associated with the specified type or member.

## Syntax

```cpp
HRESULT EnumCustomAttributes (
   [in, out] HCORENUM      *phEnum,
   [in]  mdToken            tk,
   [in]  mdToken            tkType,
   [out] mdCustomAttribute  rCustomAttributes[],
   [in]  ULONG              cMax,
   [out, optional] ULONG   *pcCustomAttributes
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the returned enumerator.

 `tk`
 [in] A token for the scope of the enumeration, or zero for all custom attributes.

 `tkType`
 [in] A token for the constructor of the type of the attributes to be enumerated, or `null` for all types.

 `rCustomAttributes`
 [out] An array of custom attribute tokens.

 `cMax`
 [in] The maximum size of the `rCustomAttributes` array.

 `pcCustomAttributes`
 [out, optional] The actual number of token values returned in `rCustomAttributes`.

## Return Value

| HRESULT | Description |
|-------------|-----------------|
| `S_OK` | `EnumCustomAttributes` returned successfully. |
| `S_FALSE` | There are no custom attributes to enumerate. In that case, `pcCustomAttributes` is zero. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
