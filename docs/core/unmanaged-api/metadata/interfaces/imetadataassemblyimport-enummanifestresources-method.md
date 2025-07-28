---
description: "Learn more about: IMetaDataAssemblyImport::EnumManifestResources Method"
title: "IMetaDataAssemblyImport::EnumManifestResources Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyImport.EnumManifestResources"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyImport::EnumManifestResources"
  - "EnumManifestResources method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyImport::EnumManifestResources Method

Gets a pointer to an enumerator for the resources referenced in the current assembly manifest.

## Syntax

```cpp
HRESULT EnumManifestResources (
    [in, out] HCORENUM         *phEnum,
    [out] mdManifestResource   rManifestResources[],
    [in]  ULONG                cMax,
    [out] ULONG                *pcTokens
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be a null value when the `EnumManifestResources` method is called for the first time.

 `rManifestResources`
 [out] The array used to store the `mdManifestResource` metadata tokens.

 `cMax`
 [in] The maximum number of `mdManifestResource` tokens that can be placed in `rManifestResources`.

 `pcTokens`
 [out] The number of `mdManifestResource` tokens actually placed in `rManifestResources`.

## Return Value

| HRESULT | Description |
|-------------|-----------------|
| `S_OK` | `EnumManifestResources` returned successfully. |
| `S_FALSE` | There are no tokens to enumerate. In this case, `pcTokens` is set to zero. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
