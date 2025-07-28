---
description: "Learn more about: IMetaDataEmit::DefineSecurityAttributeSet Method"
title: "IMetaDataEmit::DefineSecurityAttributeSet Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineSecurityAttributeSet"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineSecurityAttributeSet"
  - "DefineSecurityAttributeSet method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineSecurityAttributeSet Method

Creates a set of security permissions to attach to the object referenced by the specified token.

## Syntax

```cpp
HRESULT DefineSecurityAttributeSet (
    [in]  mdToken       tkObj,
    [in]  COR_SECATTR   rSecAttrs[],
    [in]  ULONG         cSecAttrs,
    [out] ULONG         *pulErrorAttr
);
```

## Parameters

 `tkObj`
 [in] The token to which the security information is attached.

 `rSecAttrs`
 [in] An array of `COR_SECATTR` structures.

 `cSecAttrs`
 [in] The number of elements in `rSecAttrs`.

 `pulErrorAttr`
 [out] If the method fails, specifies the index in `rSecAttrs` of the element that caused the problem.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
