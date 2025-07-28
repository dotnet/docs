---
description: "Learn more about: IMetaDataEmit2::SetGenericParamProps Method"
title: "IMetaDataEmit2::SetGenericParamProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit2.SetGenericParamProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit2::SetGenericParamProps"
  - "SetGenericParamProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit2::SetGenericParamProps Method

Sets property values for the generic parameter definition referenced by the specified token.

## Syntax

```cpp
HRESULT SetGenericParamProps (
    [in] mdGenericParam   gp,
    [in] DWORD            dwParamFlags,
    [in] LPCWSTR          szName,
    [in] DWORD            reserved,
    [in] mdToken          rtkConstraints[]
);
```

## Parameters

 `gp`
 [in] The token for the generic parameter definition for which to set values.

 `dwParamFlags`
 [in] A value of the [CorGenericParamAttr](../enumerations/corgenericparamattr-enumeration.md) enumeration that describes the type for the generic parameter.

 `szName`
 [in] Optional. The name of the parameter for which to set values.

 `reserved`
 [in] Reserved for future extensibility.

 `rtkConstraints`
 [in] Optional. A zero-terminated array of type constraints. Array members must be an `mdTypeDef`, `mdTypeRef`, or `mdTypeSpec` metadata token.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
- [IMetaDataEmit Interface](imetadataemit-interface.md)
