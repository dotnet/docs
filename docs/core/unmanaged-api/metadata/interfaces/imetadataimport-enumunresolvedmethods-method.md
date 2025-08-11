---
description: "Learn more about: IMetaDataImport::EnumUnresolvedMethods Method"
title: "IMetaDataImport::EnumUnresolvedMethods Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumUnresolvedMethods"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumUnresolvedMethods"
  - "IMetaDataImport::EnumUnresolvedMethods method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumUnresolvedMethods Method

Enumerates MemberDef tokens representing the unresolved methods in the current metadata scope.

## Syntax

```cpp
HRESULT EnumUnresolvedMethods (
   [in, out] HCORENUM    *phEnum,
   [out]     mdToken     rMethods[],
   [in]      ULONG       cMax,
   [out]     ULONG       *pcTokens
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.

 `rMethods`
 [out] The array used to store the MemberDef tokens.

 `cMax`
 [in] The maximum size of the `rMethods` array.

 `pcTokens`
 [out] The number of MemberDef tokens returned in `rMethods`.

## Return Value

| HRESULT | Description |
|-------------|-----------------|
| `S_OK` | `EnumUnresolvedMethods` returned successfully. |
| `S_FALSE` | There are no tokens to enumerate. In that case, `pcTokens` is zero. |

## Remarks

 An unresolved method is one that has been declared but not implemented. A method is included in the enumeration if the method is marked `miForwardRef` and either `mdPinvokeImpl` or `miRuntime` is set to zero. In other words, an unresolved method is a class method that is marked `miForwardRef` but which is not implemented in unmanaged code (reached via PInvoke) nor implemented internally by the runtime itself

 The enumeration excludes all methods that are defined either at module scope (globals) or in interfaces or abstract classes.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
