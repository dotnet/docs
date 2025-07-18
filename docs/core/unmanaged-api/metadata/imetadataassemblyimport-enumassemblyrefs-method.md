---
description: "Learn more about: IMetaDataAssemblyImport::EnumAssemblyRefs Method"
title: "IMetaDataAssemblyImport::EnumAssemblyRefs Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyImport.EnumAssemblyRefs"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyImport::EnumAssemblyRefs"
helpviewer_keywords:
  - "IMetaDataAssemblyImport::EnumAssemblyRefs method [.NET Framework metadata]"
  - "EnumAssemblyRefs method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyImport::EnumAssemblyRefs Method

Enumerates the `mdAssemblyRef` instances that are defined in the assembly manifest.

## Syntax

```cpp
HRESULT EnumAssemblyRefs (
    [in, out] HCORENUM        *phEnum,
    [out]     mdAssemblyRef   rAssemblyRefs[],
    [in]      ULONG           cMax,
    [out]     ULONG           *pcTokens
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be a null value when the `EnumAssemblyRefs` method is called for the first time.

 `rAssemblyRefs`
 [out] The enumeration of `mdAssemblyRef` metadata tokens.

 `cMax`
 [in] The maximum number of tokens that can be placed in the `rAssemblyRefs` array.

 `pcTokens`
 [out] The number of tokens actually placed in `rAssemblyRefs`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|`EnumAssemblyRefs` returned successfully.|
|`S_FALSE`|There are no tokens to enumerate. In this case, `pcTokens` is set to zero.|

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
