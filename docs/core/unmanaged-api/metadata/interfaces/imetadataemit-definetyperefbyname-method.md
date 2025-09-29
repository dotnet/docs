---
description: "Learn more about: IMetaDataEmit::DefineTypeRefByName Method"
title: "IMetaDataEmit::DefineTypeRefByName Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefineTypeRefByName"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefineTypeRefByName"
  - "IMetaDataEmit::DefineTypeRefByName method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefineTypeRefByName Method

Gets a metadata token for a type that is defined in the specified scope, which is outside the current scope.

## Syntax

```cpp
HRESULT DefineTypeRefByName (
    [in]  mdToken     tkResolutionScope,
    [in]  LPCWSTR     szName,
    [out] mdTypeRef   *ptr
);
```

## Parameters

 `tkResolutionScope`
 [in] The token specifying the resolution scope. The following token types are valid:

- `mdModuleRef`, if the type is defined in the same assembly in which the caller is defined.

- `mdAssemblyRef`, if the type is defined in an assembly other than the one in which the caller is defined.

- `mdTypeRef`, if the type is a nested type.

- `mdModule`, if the type is defined in the same module in which the caller is defined.

- Null, if the type is defined globally.

 `szName`
 [in] The name of the target type in Unicode.

 `ptr`
 [out] A pointer to the `mdTypeRef` token that is assigned to the type.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
