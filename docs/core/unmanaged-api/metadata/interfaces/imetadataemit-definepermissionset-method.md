---
description: "Learn more about: IMetaDataEmit::DefinePermissionSet Method"
title: "IMetaDataEmit::DefinePermissionSet Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.DefinePermissionSet"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::DefinePermissionSet"
  - "IMetaDataEmit::DefinePermissionSet method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::DefinePermissionSet Method

Creates a definition for a permission set with the specified metadata signature, and gets a token to that permission set definition.

## Syntax

```cpp
HRESULT DefinePermissionSet (
    [in]  mdToken        tk,
    [in]  DWORD          dwAction,
    [in]  void const     *pvPermission,
    [in]  ULONG          cbPermission,
    [out] mdPermission   *ppm
);
```

## Parameters

 `tk`
 [in] The object to be decorated.

 `dwAction`
 [in] A [CorDeclSecurity](../enumerations/cordeclsecurity-enumeration.md) value that specifies the type of declarative security to be used.

 `pvPermission`
 [in] The permission BLOB.

 `cbPermission`
 [in] The size, in bytes, of `pvPermission`.

 `ppm`
 [out] The returned permission token.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
