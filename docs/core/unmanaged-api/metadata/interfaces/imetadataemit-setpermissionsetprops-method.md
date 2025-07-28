---
description: "Learn more about: IMetaDataEmit::SetPermissionSetProps Method"
title: "IMetaDataEmit::SetPermissionSetProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataEmit.SetPermissionSetProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataEmit::SetPermissionSetProps"
  - "IMetaDataEmit::SetPermissionSetProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataEmit::SetPermissionSetProps Method

Sets or updates features of the metadata signature of a permission set defined by a prior call to [IMetaDataEmit::DefinePermissionSet](imetadataemit-definepermissionset-method.md).

## Syntax

```cpp
HRESULT SetPermissionSetProps (
    [in]  mdToken         tk,
    [in]  DWORD           dwAction,
    [in]  void const      *pvPermission,
    [in]  ULONG           cbPermission,
    [out] mdPermission    *ppm
);
```

## Parameters

 `tk`
 [in] A metadata token that represents the object to be decorated.

 `dwAction`
 [in] A [CorDeclSecurity](../enumerations/cordeclsecurity-enumeration.md) value that specifies the type of declarative security to be used.

 `pvPermission`
 [in] The permission BLOB.

 `cbPermission`
 [in] The size, in bytes, of `pvPermission`.

 `ppm`
 [out] An `mdPermission` metadata token that represents the updated permissions.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataEmit Interface](imetadataemit-interface.md)
- [IMetaDataEmit2 Interface](imetadataemit2-interface.md)
