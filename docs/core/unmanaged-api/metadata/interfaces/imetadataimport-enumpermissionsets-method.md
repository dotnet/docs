---
description: "Learn more about: IMetaDataImport::EnumPermissionSets Method"
title: "IMetaDataImport::EnumPermissionSets Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumPermissionSets"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumPermissionSets"
  - "IMetaDataImport::EnumPermissionSets method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumPermissionSets Method

Enumerates permissions for the objects in a specified metadata scope.

## Syntax

```cpp
HRESULT EnumPermissionSets
   [in, out] HCORENUM      *phEnum,
   [in]      mdToken       tk,
   [in]      DWORD         dwActions,
   [out]     mdPermission  rPermission[],
   [in]      ULONG         cMax,
   [out]     ULONG         *pcTokens
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be NULL for the first call of this method.

 `tk`
 [in] A metadata token that limits the scope of the search, or NULL to search the widest scope possible.

 `dwActions`
 [in] Flags representing the <xref:System.Security.Permissions.SecurityAction> values to include in `rPermission`, or zero to return all actions.

 `rPermission`
 [out] The array used to store the Permission tokens.

 `cMax`
 [in] The maximum size of the `rPermission` array.

 `pcTokens`
 [out] The number of Permission tokens returned in `rPermission`.

## Return Value

| HRESULT | Description |
|-------------|-----------------|
| `S_OK` | `EnumPermissionSets` returned successfully. |
| `S_FALSE` | There are no tokens to enumerate. In that case, `pcTokens` is zero. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
