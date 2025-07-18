---
description: "Learn more about: IMetaDataAssemblyImport::EnumExportedTypes Method"
title: "IMetaDataAssemblyImport::EnumExportedTypes Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyImport.EnumExportedTypes"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyImport::EnumExportedTypes"
helpviewer_keywords:
  - "EnumExportedTypes method [.NET Framework metadata]"
  - "IMetaDataAssemblyImport::EnumExportedTypes method [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyImport::EnumExportedTypes Method

Enumerates the exported types referenced in the assembly manifest in the current metadata scope.

## Syntax

```cpp
HRESULT EnumExportedTypes (
    [in, out] HCORENUM     *phEnum,
    [out] mdExportedType   rExportedTypes[],
    [in]  ULONG            cMax,
    [out] ULONG            *pcTokens
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator. This must be a null value when the `EnumExportedTypes` method is called for the first time.

 `rExportedTypes`
 [out] The enumeration of `mdExportedType` metadata tokens.

 `cMax`
 [in] The maximum number of `mdExportedType` tokens that can be placed in the `rExportedTypes` array.

 `pcTokens`
 [out] The number of `mdExportedType` tokens actually placed in `rExportedTypes`.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|`EnumExportedTypes` returned successfully.|
|`S_FALSE`|There are no tokens to enumerate. In this case, `pcTokens` is set to zero.|

## Requirements

 **Platform:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Used as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataAssemblyImport Interface](imetadataassemblyimport-interface.md)
