---
description: "Learn more about: IMetaDataImport::GetPermissionSetProps Method"
title: "IMetaDataImport::GetPermissionSetProps Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetPermissionSetProps"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetPermissionSetProps"
  - "IMetaDataImport::GetPermissionSetProps method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetPermissionSetProps Method

Gets the metadata associated with the <xref:System.Security.PermissionSet?displayProperty=nameWithType> represented by the specified Permission token.

## Syntax

```cpp
HRESULT GetPermissionSetProps (
   [in]  mdPermission      pm,
   [out] DWORD             *pdwAction,
   [out] void const        **ppvPermission,
   [out] ULONG             *pcbPermission
);
```

## Parameters

 `pm`
 [in] The Permission metadata token that represents the permission set to get the metadata properties for.

 `pdwAction`
 [out] A pointer to the permission set.

 `ppvPermission`
 [out] A pointer to the binary metadata signature of the permission set.

 `pcbPermission`
 [out] The size in bytes of `ppvPermission`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- <xref:System.Security.PermissionSet>
- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
