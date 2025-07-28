---
description: "Learn more about: IMetaDataAssemblyImport::EnumFiles Method"
title: "IMetaDataAssemblyImport::EnumFiles Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyImport.EnumFiles"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyImport::EnumFiles"
  - "EnumFiles method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyImport::EnumFiles Method

Enumerates the files referenced in the current assembly manifest.

## Syntax

```cpp
HRESULT EnumFiles (
    [in, out] HCORENUM    *phEnum,
    [out] mdFile          rFiles[],
    [in]  ULONG           cMax,
    [out] ULONG           *pcTokens
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be a null value for the first call of this method.

 `rFiles`
 [out] The array used to store the `mdFile` metadata tokens.

 `cMax`
 [in] The maximum number of `mdFile` tokens that can be placed in `rFiles`.

 `pcTokens`
 [out] The number of `mdFile` tokens actually placed in `rFiles`.

## Return Value

| HRESULT | Description |
|-------------|-----------------|
| `S_OK` | `EnumFiles` returned successfully. |
| `S_FALSE` | There are no tokens to enumerate. In this case, `pcTokens` is set to zero. |

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
