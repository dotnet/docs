---
description: "Learn more about: IMetaDataAssemblyEmit::DefineAssembly Method"
title: "IMetaDataAssemblyEmit::DefineAssembly Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataAssemblyEmit.DefineAssembly"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataAssemblyEmit::DefineAssembly"
  - "DefineAssembly method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataAssemblyEmit::DefineAssembly Method

Creates an `Assembly` structure containing metadata for the specified assembly and returns the associated metadata token.

## Syntax

```cpp
HRESULT DefineAssembly (
    [in]  void                 *pbPublicKey,
    [in]  ULONG                cbPublicKey,
    [in]  ULONG                uHashAlgId,
    [in]  LPCWSTR              szName,
    [in]  ASSEMBLYMETADATA     *pMetaData,
    [in]  DWORD                dwAssemblyFlags,
    [out] mdAssembly           *pmda
);
```

## Parameters

 `pbPublicKey`
 [in] The public key that identifies the publisher of the assembly, or NULL if the assembly is not strongly named.

 `cbPublicKey`
 [in] The size in bytes of `pbPublicKey`.

 `uHashAlgId`
 [in] The identifier of the hashing algorithm to use to encrypt the files in the assembly, or NULL to specify the SHA-1 algorithm.

 `szName`
 [in] The human-readable text name of the assembly. This value must not exceed 1024 characters.

 `pMetaData`
 [in] A pointer to an [ASSEMBLYMETADATA](../structures/assemblymetadata-structure.md) instance that contains the version, platform, and locale information for the assembly.

 `dwAssemblyFlags`
 [in] A combination of [CorAssemblyFlags](../enumerations/corassemblyflags-enumeration.md) values that describe features of the assembly.

 `pmda`
 [out] A pointer to the metadata token.

## Remarks

 Only one `Assembly` metadata structure can be defined within a manifest.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataAssemblyEmit Interface](imetadataassemblyemit-interface.md)
